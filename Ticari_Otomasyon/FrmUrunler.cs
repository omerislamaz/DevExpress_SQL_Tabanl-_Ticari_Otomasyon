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
using DevExpress.XtraSplashScreen;

namespace Ticari_Otomasyon
{
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_URUNLER Order By ID", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void Temizle()
        {
            TxtID.Text = "";
            TxtAd.Text = "";
            TxtMarka.Text = "";
            TxtModel.Text = "";
            MskYıl.Text = "";
            NudAdet.Text = "";
            TxtAlıs.Text = "";
            TxtSatis.Text = "";
            RchDetay.Text = "";
        }

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            listele();
            //GridControl deki tüm paneli pasife alır.
            gridView1.OptionsBehavior.Editable = false;


            BtnGüncelle.Enabled = false;
            BtnSil.Enabled = false;
            BtnTemizle.Enabled = false;

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            //Araçlardaki Id verisine bağlı kayıtı veri tabanında kontrol etme kodu. Mükkerer Kayıt !

            SqlCommand kmt = new SqlCommand("Select Count(*) From TBL_URUNLER where ID=@p1", bgl.baglanti());
            kmt.Parameters.AddWithValue("@p1", TxtID.Text);
            int kontrol = (int)kmt.ExecuteScalar();

            if (kontrol != 0)
            {
                MessageBox.Show("Mükerrer Kayıt Gerçekleştirilemez, Lütfen Bilgileri Tekrar Kontrol Edin", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            else
            {
                try
                {
                    //verileri kaydetme
                    SqlCommand komut = new SqlCommand("insert into TBL_URUNLER (URUNAD,URUNMARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", TxtAd.Text);
                    komut.Parameters.AddWithValue("@p2", TxtMarka.Text);
                    komut.Parameters.AddWithValue("@p3", TxtModel.Text);
                    komut.Parameters.AddWithValue("@p4", MskYıl.Text);
                    komut.Parameters.AddWithValue("@p5", int.Parse((NudAdet.Value).ToString()));
                    komut.Parameters.AddWithValue("@p6", decimal.Parse(TxtAlıs.Text));
                    komut.Parameters.AddWithValue("@p7", decimal.Parse(TxtSatis.Text));
                    komut.Parameters.AddWithValue("@p8", RchDetay.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Ürün Sisteme Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Temizle();
                    listele();

                }
                catch (Exception)
                {
                    MessageBox.Show("İlgili alanları kontrol edin", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    listele();
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult soru = MessageBox.Show("Ürün Sistemden Silinsin mi ?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (soru == DialogResult.OK)
            {
                SqlCommand komutsil = new SqlCommand("Delete From TBL_URUNLER WHERE ID=@p1", bgl.baglanti());
                komutsil.Parameters.AddWithValue("@p1", TxtID.Text);
                komutsil.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Ürün Sistemden Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                Temizle();
            }
            if (soru == DialogResult.Cancel)
            {
                MessageBox.Show("Silme işlemi İPTAL edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                Temizle();
            }
        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Temizle();
        }


        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtID.Text = dr["ID"].ToString();
            TxtAd.Text = dr["URUNAD"].ToString();
            TxtMarka.Text = dr["URUNMARKA"].ToString();
            TxtModel.Text = dr["MODEL"].ToString();
            MskYıl.Text = dr["YIL"].ToString();
            NudAdet.Value = decimal.Parse(dr["ADET"].ToString());
            TxtAlıs.Text = dr["ALISFIYAT"].ToString();
            TxtSatis.Text = dr["SATISFIYAT"].ToString();
            RchDetay.Text = dr["DETAY"].ToString();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_URUNLER set URUNAD=@p1, URUNMARKA=@p2,MODEL=@p3,YIL=@p4,ADET=@p5,ALISFIYAT=@p6,SATISFIYAT=@p7,DETAY=@p8 where ID=@p9", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtMarka.Text);
            komut.Parameters.AddWithValue("@p3", TxtModel.Text);
            komut.Parameters.AddWithValue("@p4", MskYıl.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse((NudAdet.Value).ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(TxtAlıs.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(TxtSatis.Text));
            komut.Parameters.AddWithValue("@p8", RchDetay.Text);
            komut.Parameters.AddWithValue("@p9", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
            listele();
        }

        private void TxtID_EditValueChanged(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(TxtID.Text))
            {
                BtnGüncelle.Enabled = false;
                BtnSil.Enabled = false;
                BtnTemizle.Enabled = false;
            }
            else
            {
                BtnGüncelle.Enabled = true;
                BtnSil.Enabled = true;
                BtnTemizle.Enabled = true;
            }

        }
    }
}
