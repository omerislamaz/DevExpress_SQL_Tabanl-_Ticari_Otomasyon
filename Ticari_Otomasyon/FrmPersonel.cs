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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        void Listele()
        {
            SqlDataAdapter komut = new SqlDataAdapter("select * From TBL_PERSONELLER", bgl.baglanti());
            DataTable dt = new DataTable();
            komut.Fill(dt);
            gridControl1.DataSource = dt;
        }


        void SehirListesi()
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
            MskTc.Text = "";
            TxtMailAdresi.Text = "";
            TxtGorev.Text = "";
            CmbIl.Text = "";
            CmbIlce.Text = "";
            RchAdres.Text = "";
        }

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            Listele();
            SehirListesi();
            gridView1.OptionsBehavior.Editable = false;
            Temizle();

            BtnGüncelle.Enabled = false;
            BtnSil.Enabled = false;
            BtnTemizle.Enabled = false;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            if (TxtAd.Text == "" || TxtSoyad.Text == "" || MskTc.Text == "" || MskTelefon1.Text == "" || RchAdres.Text == "" || TxtGorev.Text == "" || CmbIl.Text == "" || CmbIlce.Text == "")
            {
                MessageBox.Show("Boş Alanları Doldurunuz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                SqlCommand kmt = new SqlCommand("Select Count(*) From TBL_PERSONELLER where TC=@p1", bgl.baglanti());
                kmt.Parameters.AddWithValue("@p1", Convert.ToInt64(MskTc.Text));
                int kontrol = (int)kmt.ExecuteScalar();

                if (kontrol != 0)
                {
                    MessageBox.Show("Mükerrer Kayıt Gerçekleştirilemez, Lütfen Bilgileri Tekrar Kontrol Edin", "Kontrol", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Listele();
                }
                else
                {
                    DialogResult kayit = MessageBox.Show(TxtAd.Text + " " + TxtSoyad.Text + " " + "Personel Veritabanına Kaydı gerçekleşecektir. Onaylıyor musunuz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (kayit == DialogResult.Yes)

                    {
                        try
                        {
                            SqlCommand komut = new SqlCommand("insert into TBL_PERSONELLER (AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
                            komut.Parameters.AddWithValue("@p1", TxtAd.Text.ToUpper());
                            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text.ToUpper());
                            komut.Parameters.AddWithValue("@p3", MskTelefon1.Text);
                            komut.Parameters.AddWithValue("@p4", MskTc.Text);
                            komut.Parameters.AddWithValue("@p5", TxtMailAdresi.Text);
                            komut.Parameters.AddWithValue("@p6", CmbIl.Text.ToUpper());
                            komut.Parameters.AddWithValue("@p7", CmbIlce.Text.ToUpper());
                            komut.Parameters.AddWithValue("@p8", RchAdres.Text.ToUpper());
                            komut.Parameters.AddWithValue("@p9", TxtGorev.Text.ToUpper());
                            komut.ExecuteNonQuery();
                            bgl.baglanti().Close();
                            MessageBox.Show("Personel Sisteme Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Listele();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("İlgili alanları kontrol edin", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Listele();
                        }
                    }
                    if (kayit == DialogResult.No)
                    {
                        MessageBox.Show("Kayıt işlemi İPTAL Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Listele();
                    }
                }
            }
        }


        private void CmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbIlce.Properties.Items.Clear();
            SqlCommand ilce = new SqlCommand("Select ILCE From TBL_ILCELER where SEHIR=@p1", bgl.baglanti());
            ilce.Parameters.AddWithValue("@p1", CmbIl.SelectedIndex + 1);
            SqlDataReader dr = ilce.ExecuteReader();
            while (dr.Read())
            {
                CmbIlce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtID.Text = dr["ID"].ToString();
                TxtAd.Text = dr["AD"].ToString().ToUpper();
                TxtSoyad.Text = dr["SOYAD"].ToString().ToUpper();
                MskTelefon1.Text = dr["TELEFON"].ToString();
                MskTc.Text = dr["TC"].ToString();
                TxtMailAdresi.Text = dr["MAIL"].ToString();
                CmbIl.Text = dr["IL"].ToString().ToUpper();
                CmbIlce.Text = dr["ILCE"].ToString().ToUpper();
                RchAdres.Text = dr["ADRES"].ToString().ToUpper();
                TxtGorev.Text = dr["GOREV"].ToString().ToUpper();
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void TxtID_EditValueChanged(object sender, EventArgs e)
        {
            BtnGüncelle.Enabled = true;
            BtnSil.Enabled = true;
            BtnTemizle.Enabled = true;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult silme = MessageBox.Show(TxtAd.Text + " " + TxtSoyad.Text + " " + "Sistemden Silinecektir, Onaylıyor musun?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (silme == DialogResult.Yes)
            {
                SqlCommand sil = new SqlCommand("Delete From TBL_PERSONELLER where ID=@p1", bgl.baglanti());
                sil.Parameters.AddWithValue("@p1", TxtID.Text);
                sil.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Personel Sistemden Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                Temizle();
            }
            if (silme == DialogResult.No)
            {
                MessageBox.Show("Silme işlemi İPTAL edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            DialogResult guncelle = MessageBox.Show("Güncelleme işlemi gerçekleşecektir, Onaylıyor musun?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (guncelle == DialogResult.Yes)
            {

                SqlCommand komut = new SqlCommand("Update TBL_PERSONELLER Set Ad=@p1,Soyad=@p2,Telefon=@p3,Tc=@p4,Maıl=@p5,IL=@p6,ILCE=@p7,ADRES=@p8,GOREV=@p9 where ID=@p10", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtAd.Text.ToUpper());
                komut.Parameters.AddWithValue("@p2", TxtSoyad.Text.ToUpper());
                komut.Parameters.AddWithValue("@p3", MskTelefon1.Text);
                komut.Parameters.AddWithValue("@p4", MskTc.Text);
                komut.Parameters.AddWithValue("@p5", TxtMailAdresi.Text);
                komut.Parameters.AddWithValue("@p6", CmbIl.Text.ToUpper());
                komut.Parameters.AddWithValue("@p7", CmbIlce.Text.ToUpper());
                komut.Parameters.AddWithValue("@p8", RchAdres.Text.ToUpper());
                komut.Parameters.AddWithValue("@p9", TxtGorev.Text.ToUpper());
                komut.Parameters.AddWithValue("@p10", TxtID.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Personel Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }
            if (guncelle == DialogResult.No)
            {
                MessageBox.Show("Güncelleme işlemi İPTAL Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Listele();
            }
        }
    }
}
