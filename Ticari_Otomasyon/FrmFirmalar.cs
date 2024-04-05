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
using System.Windows;

namespace Ticari_Otomasyon
{
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_FIRMALAR", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
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
            TxtYetkiliGörev.Text = "";
            TxtYetkili.Text = "";
            MskYetkiliTc.Text = "";
            TxtSektör.Text = "";
            MskTelefon1.Text = "";
            MskTelefon2.Text = "";
            MskTelefon3.Text = "";
            TxtMailAdresi.Text = "";
            MskFax.Text = "";
            CmbIl.Text = "";
            CmbIlce.Text = "";
            TxtVergiDairesi.Text = "";
            RchAdres.Text = "";
            TxtKod1.Text = "";
            TxtKod2.Text = "";
            TxtKod3.Text = "";
            TxtAd.Focus();
        }

        void carikodaciklamalar()
        {
            SqlCommand komut = new SqlCommand("select  FIRMAKOD1 from TBL_KODLAR", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                RchKod1.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();
        }
        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            listele();
            SehirListesi();
            carikodaciklamalar();
            gridView1.OptionsBehavior.Editable = false;

            BtnSil.Enabled = false;
            BtnGüncelle.Enabled = false;
            BtnTemizle.Enabled = false;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtID.Text = dr["ID"].ToString();
            TxtAd.Text = dr["AD"].ToString();
            TxtYetkiliGörev.Text = dr["YETKILISTATU"].ToString();
            TxtYetkili.Text = dr["YETKILIADSOYAD"].ToString();
            MskYetkiliTc.Text = dr["YETKILITC"].ToString();
            TxtSektör.Text = dr["SEKTOR"].ToString();
            MskTelefon1.Text = dr["TELEFON1"].ToString();
            MskTelefon2.Text = dr["TELEFON2"].ToString();
            MskTelefon3.Text = dr["TELEFON3"].ToString();
            TxtMailAdresi.Text = dr["MAIL"].ToString();
            MskFax.Text = dr["FAX"].ToString();
            CmbIl.Text = dr["IL"].ToString();
            CmbIlce.Text = dr["ILCE"].ToString();
            TxtVergiDairesi.Text = dr["VERGIDAIRE"].ToString();
            RchAdres.Text = dr["ADRES"].ToString();
            RchKod1.Text = dr["OZELKOD1"].ToString();
            RchKod2.Text = dr["OZELKOD2"].ToString();
            RchKod3.Text = dr["OZELKOD3"].ToString();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtAd.Text == "" && TxtYetkili.Text == "" && TxtYetkiliGörev.Text == "" && TxtSektör.Text == "" && MskYetkiliTc.Text == "")
            {
                MessageBox.Show("Boş Alanları Doldurunuz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                DialogResult kayit = MessageBox.Show(TxtAd.Text + " " + "Sisteme Kayıt Edilecektir, Onaylıyor musun ?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (kayit == DialogResult.Yes)
                {
                    SqlCommand kmt = new SqlCommand("Select Count(*) From TBL_FIRMALAR where ID=@p1", bgl.baglanti());
                    kmt.Parameters.AddWithValue("@p1", TxtID.Text);
                    int kontrol = (int)kmt.ExecuteScalar();

                    if (kontrol != 0)
                    {
                        MessageBox.Show("Mükerrer Kayıt Gerçekleştirilemez, Lütfen Bilgileri Tekrar Kontrol Edin", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        listele();
                        SehirListesi();
                    }
                    else
                    {
                        SqlCommand komut = new SqlCommand("insert into TBL_FIRMALAR (AD,YETKILISTATU,YETKILIADSOYAD,YETKILITC,SEKTOR,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX,IL,ILCE,VERGIDAIRE,ADRES,OZELKOD1,OZELKOD2,OZELKOD3) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)", bgl.baglanti());
                        komut.Parameters.AddWithValue("@p1", TxtAd.Text);
                        komut.Parameters.AddWithValue("@p2", TxtYetkiliGörev.Text);
                        komut.Parameters.AddWithValue("@p3", TxtYetkili.Text);
                        komut.Parameters.AddWithValue("@p4", MskYetkiliTc.Text);
                        komut.Parameters.AddWithValue("@p5", TxtSektör.Text);
                        komut.Parameters.AddWithValue("@p6", MskTelefon1.Text);
                        komut.Parameters.AddWithValue("@p7", MskTelefon2.Text);
                        komut.Parameters.AddWithValue("@p8", MskTelefon3.Text);
                        komut.Parameters.AddWithValue("@p9", TxtMailAdresi.Text);
                        komut.Parameters.AddWithValue("@p10", MskFax.Text);
                        komut.Parameters.AddWithValue("@p11", CmbIl.Text);
                        komut.Parameters.AddWithValue("@p12", CmbIlce.Text);
                        komut.Parameters.AddWithValue("@p13", TxtVergiDairesi.Text);
                        komut.Parameters.AddWithValue("@p14", RchAdres.Text);
                        komut.Parameters.AddWithValue("@p15", TxtKod1.Text);
                        komut.Parameters.AddWithValue("@p16", TxtKod2.Text);
                        komut.Parameters.AddWithValue("@p17", TxtKod3.Text);
                        komut.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        MessageBox.Show("Firma Sisteme Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listele();
                        SehirListesi();
                        Temizle();
                    }
                    if (kayit == DialogResult.No)
                    {
                        MessageBox.Show("Kayıt işlemi iptal edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        listele();
                        SehirListesi();
                        Temizle();

                    }
                }
            }
        }


        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            SehirListesi();
            Temizle();
        }

        private void CmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbIlce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select ILCE FROM TBL_ILCELER where SEHIR=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbIl.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbIlce.Properties.Items.Add(dr[0].ToString());
            }
            bgl.baglanti().Close();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {

            DialogResult silme = MessageBox.Show(TxtAd.Text + " " + "Sistemden silinecektir. Onaylıyor musun ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (silme == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Delete From TBL_FIRMALAR where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtID.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Firma Sistemden Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                SehirListesi();
                Temizle();
            }

            if (silme == DialogResult.No)
            {
                MessageBox.Show("Silme İşlemi İPTAL edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                SehirListesi();
                Temizle();
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

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            DialogResult kayit = MessageBox.Show("Firma Bilgileri Güncellenecektir, Onaylıyor musun ?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (kayit == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Update TBL_FIRMALAR Set AD=@p1, YETKILISTATU=@p2,YETKILIADSOYAD=@p3,YETKILITC=@p4,SEKTOR=@p5,TELEFON1=@p6,TELEFON2=@p7,TELEFON3=@p8,MAIL=@p9,FAX=@p10,IL=@p11,ILCE=@p12,VERGIDAIRE=@p13,ADRES=@p14,OZELKOD1=@p15,OZELKOD2=@p16,OZELKOD3=@p17 where ID=@p18", bgl.baglanti());

                komut.Parameters.AddWithValue("@p1", TxtAd.Text);
                komut.Parameters.AddWithValue("@p2", TxtYetkiliGörev.Text);
                komut.Parameters.AddWithValue("@p3", TxtYetkili.Text);
                komut.Parameters.AddWithValue("@p4", MskYetkiliTc.Text);
                komut.Parameters.AddWithValue("@p5", TxtSektör.Text);
                komut.Parameters.AddWithValue("@p6", MskTelefon1.Text);
                komut.Parameters.AddWithValue("@p7", MskTelefon2.Text);
                komut.Parameters.AddWithValue("@p8", MskTelefon3.Text);
                komut.Parameters.AddWithValue("@p9", TxtMailAdresi.Text);
                komut.Parameters.AddWithValue("@p10", MskFax.Text);
                komut.Parameters.AddWithValue("@p11", CmbIl.Text);
                komut.Parameters.AddWithValue("@p12", CmbIlce.Text);
                komut.Parameters.AddWithValue("@p13", TxtVergiDairesi.Text);
                komut.Parameters.AddWithValue("@p14", RchAdres.Text);
                komut.Parameters.AddWithValue("@p15", RchKod1.Text);
                komut.Parameters.AddWithValue("@p16", RchKod2.Text);
                komut.Parameters.AddWithValue("@p17", RchKod3.Text);
                komut.Parameters.AddWithValue("@p18", TxtID.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Güncelleme gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                SehirListesi();
                Temizle();
                //Temizle();
            }
            if (kayit == DialogResult.No)
            {
                MessageBox.Show("Güncelleme işlemi iptal edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listele();
                SehirListesi();
                Temizle();
            }
        }
    }
}
