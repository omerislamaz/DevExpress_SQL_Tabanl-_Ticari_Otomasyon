using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        void MusteriListele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_MUSTERILER Order By ID", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }

        void SehırListesi()
        {
            SqlCommand komut = new SqlCommand("Select SEHIR From TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbIl.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }


        void Temizle()
        {
            TxtID.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            MskTelefon1.Text = "";
            MskTelefon2.Text = "";
            MskTc.Text = "";
            TxtMailAdresi.Text = "";
            TxtVergiDairesi.Text = "";
            RchAdres.Text = "";
        }




        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            MusteriListele();
            SehırListesi();
            //GridControl deki tüm paneli pasife alır.
            gridView1.OptionsBehavior.Editable = false;


            BtnSil.Enabled = false;
            BtnGüncelle.Enabled = false;
            BtnTemizle.Enabled = false;
            bgl.baglanti().Close();

        }

        private void CmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbIlce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select ILCE From TBL_ILCELER where SEHIR=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbIl.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbIlce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtAd.Text == "" || TxtSoyad.Text == "" || MskTc.Text == "")
            {
                MessageBox.Show("Boş Alanları Doldurunuz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {

                DialogResult kayit = MessageBox.Show("Müşteri Kaydı gerçekleşecektir. Onaylıyor musun?", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (kayit == DialogResult.OK)
                {
                    SqlCommand kmt = new SqlCommand("Select Count(*) From TBL_MUSTERILER where TC=@p1", bgl.baglanti());
                    kmt.Parameters.AddWithValue("@p1", Convert.ToInt64(MskTc.Text));
                    int kontrol = (int)kmt.ExecuteScalar();

                    if (kontrol != 0)
                    {
                        MessageBox.Show("Mükerrer Kayıt Gerçekleştirilemez, Lütfen Bilgileri Tekrar Kontrol Edin", "Kontrol", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        MusteriListele();
                    }
                    else
                    {
                        try
                        {

                            SqlCommand komut = new SqlCommand("insert into TBL_MUSTERILER (AD,SOYAD,TELEFON,TELEFON2,TC,MAIL,IL,ILCE,ADRES,VERGIDAIRE) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.baglanti());
                            komut.Parameters.AddWithValue("@p1", TxtAd.Text.ToUpper());
                            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text.ToUpper());
                            komut.Parameters.AddWithValue("@p3", MskTelefon1.Text);
                            komut.Parameters.AddWithValue("@p4", MskTelefon2.Text);
                            komut.Parameters.AddWithValue("@p5", MskTc.Text);
                            komut.Parameters.AddWithValue("@p6", TxtMailAdresi.Text);
                            komut.Parameters.AddWithValue("@p7", CmbIl.Text.ToUpper());
                            komut.Parameters.AddWithValue("@p8", CmbIlce.Text.ToUpper());
                            komut.Parameters.AddWithValue("@p9", RchAdres.Text.ToUpper());
                            komut.Parameters.AddWithValue("@p10", TxtVergiDairesi.Text.ToUpper());
                            komut.ExecuteNonQuery();
                            bgl.baglanti().Close();
                            MessageBox.Show(TxtAd.Text + " " + TxtSoyad.Text + " " + "Sisteme Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MusteriListele();
                            Temizle();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("İlgili alanları kontrol edin", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MusteriListele();
                        }
                    }
                }

                if (kayit == DialogResult.Cancel)
                {
                    MessageBox.Show("Kayıt işlemi iptal edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MusteriListele();
                }
            }

        }


        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtID.Text = dr["ID"].ToString();
            TxtAd.Text = dr["AD"].ToString();
            TxtSoyad.Text = dr["SOYAD"].ToString();
            MskTelefon1.Text = dr["TELEFON"].ToString();
            MskTelefon2.Text = dr["TELEFON2"].ToString();
            MskTc.Text = dr["TC"].ToString();
            TxtMailAdresi.Text = dr["MAIL"].ToString();
            CmbIl.Text = dr["IL"].ToString();
            CmbIlce.Text = dr["ILCE"].ToString();
            RchAdres.Text = dr["ADRES"].ToString();
            TxtVergiDairesi.Text = dr["VERGIDAIRE"].ToString();
            BtnKaydet.Enabled = false;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {

            DialogResult sil = MessageBox.Show(TxtAd.Text + " " + TxtSoyad.Text + " " + "Sistemden Silinecektir. Onaylıyor musun?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sil == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Delete From TBL_MUSTERILER where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtID.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Silme işlemi Gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MusteriListele();
                SehırListesi();

            }
            if (sil == DialogResult.No)
            {
                MessageBox.Show("Silme işlemi İPTAL edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MusteriListele();
                SehırListesi();
            }
        }

        private void TxtID_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtID.Text))
            {

                BtnSil.Enabled = false;
                BtnGüncelle.Enabled = false;
                BtnTemizle.Enabled = false;

            }

            else
            {
                BtnSil.Enabled = true;
                BtnGüncelle.Enabled = true;
                BtnTemizle.Enabled = true;
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
            MusteriListele();
            BtnKaydet.Enabled = true;

        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_MUSTERILER set AD=@p1,SOYAD=@p2,TELEFON=@p3,TELEFON2=@p4,TC=@p5,MAIL=@p6,IL=@p7,ILCE=@p8,ADRES=@p9,VERGIDAIRE=@p10 where ID=@p11", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", TxtAd.Text.ToUpper());
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text.ToUpper());
            komut.Parameters.AddWithValue("@p3", MskTelefon1.Text);
            komut.Parameters.AddWithValue("@p4", MskTelefon2.Text);
            komut.Parameters.AddWithValue("@p5", MskTc.Text);
            komut.Parameters.AddWithValue("@p6", TxtMailAdresi.Text);
            komut.Parameters.AddWithValue("@p7", CmbIl.Text.ToUpper());
            komut.Parameters.AddWithValue("@p8", CmbIlce.Text.ToUpper());
            komut.Parameters.AddWithValue("@p9", RchAdres.Text.ToUpper());
            komut.Parameters.AddWithValue("@p10", TxtVergiDairesi.Text.ToUpper());
            komut.Parameters.AddWithValue("@p11", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MusteriListele();
            Temizle();

        }
    }
}



