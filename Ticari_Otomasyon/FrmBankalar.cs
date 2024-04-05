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
using System.Data.SqlTypes;

namespace Ticari_Otomasyon
{
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Execute BankaBilgileri", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.RefreshDataSource();
            gridControl1.DataSource = dt;
            firmalistesi();
        }

        void firmalistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID,AD From TBL_FIRMALAR", bgl.baglanti());
            da.Fill(dt);
            LkpFirma.Properties.NullText = "Firma Seçiniz";
            LkpFirma.Properties.ValueMember = "ID";
            LkpFirma.Properties.DisplayMember = "AD";
            LkpFirma.Properties.DataSource = dt;
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
            TxtBankaAdı.Text = "";
            CmbIl.Text = "";
            CmbIlce.Text = "";
            TxtSube.Text = "";
            TxtIban.Text = "";
            TxtHesapNo.Text = "";
            TxtYetkili.Text = "";
            MskTelefon.Text = "";
            MskTarih.Text = "";
            TxtHesapTuru.Text = "";
            LkpFirma.Text = "";
            BtnGüncelle.Enabled = false;
            BtnSil.Enabled = false;
            BtnTemizle.Enabled = false;
            BtnKaydet.Enabled = true;
        }

        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
            firmalistesi();
            Listele();
            SehirListesi();
            BtnGüncelle.Enabled = false;
            BtnSil.Enabled = false;
            BtnTemizle.Enabled = false;
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            DialogResult güncelle = MessageBox.Show("Banka Bilgisi Güncellenecektir, Onaylıyor musun ?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (güncelle == DialogResult.Yes)
            {
                try
                {
                    SqlCommand komut = new SqlCommand("Update TBL_BANKALAR set BANKAADI=@p1,Il=@p2,ILCE=@p3,SUBE=@p4,IBAN=@p5,HESAPNO=@p6,YETKILI=@p7,TELEFON=@p8,TARIH=@p9,HESAPTURU=@p10,FIRMAID=@p11 where ID=@p12", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", TxtBankaAdı.Text);
                    komut.Parameters.AddWithValue("@p2", CmbIl.Text);
                    komut.Parameters.AddWithValue("@p3", CmbIlce.Text);
                    komut.Parameters.AddWithValue("@p4", TxtSube.Text);
                    komut.Parameters.AddWithValue("@p5", TxtIban.Text);
                    komut.Parameters.AddWithValue("@p6", TxtHesapNo.Text);
                    komut.Parameters.AddWithValue("@p7", TxtYetkili.Text);
                    komut.Parameters.AddWithValue("@p8", MskTelefon.Text);
                    komut.Parameters.AddWithValue("@p9", MskTarih.Text);
                    komut.Parameters.AddWithValue("@p10", TxtHesapTuru.Text);
                    komut.Parameters.AddWithValue("@p11", LkpFirma.EditValue);
                    komut.Parameters.AddWithValue("@p12", TxtID.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    Listele();
                    MessageBox.Show("Güncelleme gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("İlgili alanları kontrol edin", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (güncelle == DialogResult.No)
            {
                MessageBox.Show("Güncelleme işlemi iptal edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Listele();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtID.Text = dr[0].ToString();
                TxtBankaAdı.Text = dr[1].ToString();
                CmbIl.Text = dr[2].ToString();
                CmbIlce.Text = dr[3].ToString();
                TxtSube.Text = dr[4].ToString();
                TxtIban.Text = dr[5].ToString();
                TxtHesapNo.Text = dr[6].ToString();
                TxtYetkili.Text = dr[7].ToString();
                MskTelefon.Text = dr[8].ToString();
                MskTarih.Text = dr[9].ToString();
                TxtHesapTuru.Text = dr[10].ToString();
            }

            BtnGüncelle.Enabled = true;
            BtnSil.Enabled = true;
            BtnTemizle.Enabled = true;
            BtnKaydet.Enabled = false;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtBankaAdı.Text == "" || TxtHesapNo.Text == "" || TxtIban.Text == "" || TxtYetkili.Text == "" || MskTelefon.Text == "")
            {
                MessageBox.Show("Boş Alanları Doldurunuz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                SqlCommand kmt = new SqlCommand("Select Count(*) From TBL_BANKALAR where HESAPNO=@p1 or IBAN=@p2", bgl.baglanti());
                kmt.Parameters.AddWithValue("@p1", TxtHesapNo.Text);
                kmt.Parameters.AddWithValue("@p2", TxtIban.Text);
                int kontrol = (int)kmt.ExecuteScalar();

                if (kontrol != 0)
                {
                    MessageBox.Show("Aynı Hesap NO ve Iban Bilgileri Kayıt Edilemez, Lütfen Bilgileri Tekrar Kontrol Edin", "Mükerrer Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Listele();
                    BtnTemizle.Enabled = true;
                }
                else
                {
                    SqlCommand komut = new SqlCommand("insert into TBL_BANKALAR (BANKAADI,IL,ILCE,SUBE,IBAN,HESAPNO,YETKILI,TELEFON,TARIH,HESAPTURU,FIRMAID) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());

                    komut.Parameters.AddWithValue("@p1", TxtBankaAdı.Text);
                    komut.Parameters.AddWithValue("@p2", CmbIl.Text);
                    komut.Parameters.AddWithValue("@p3", CmbIlce.Text);
                    komut.Parameters.AddWithValue("@p4", TxtSube.Text);
                    komut.Parameters.AddWithValue("@p5", TxtIban.Text);
                    komut.Parameters.AddWithValue("@p6", TxtHesapNo.Text);
                    komut.Parameters.AddWithValue("@p7", TxtYetkili.Text);
                    komut.Parameters.AddWithValue("@p8", MskTelefon.Text);
                    komut.Parameters.AddWithValue("@p9", MskTarih.Text);
                    komut.Parameters.AddWithValue("@p10", TxtHesapTuru.Text);
                    komut.Parameters.AddWithValue("@p11", LkpFirma.EditValue);
                    komut.ExecuteNonQuery();
                    Listele();
                    bgl.baglanti().Close();
                    MessageBox.Show("Banka Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Temizle();
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Listele();
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

            DialogResult silme = MessageBox.Show(TxtBankaAdı.Text + " " + "Sistemden silinecektir. Onaylıyor musun ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (silme == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Delete From TBL_BANKALAR where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtID.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                Temizle();
                Listele();
                MessageBox.Show("Banka Sistemden Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (silme == DialogResult.No)
            {
                MessageBox.Show("Silme İşlemi İPTAL edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }
        }
    }
}