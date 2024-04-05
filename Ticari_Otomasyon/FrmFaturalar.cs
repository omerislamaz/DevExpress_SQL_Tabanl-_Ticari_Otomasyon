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
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_FATURABILGI", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.OptionsBehavior.Editable = false;
        }


        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }

        void Temizle()
        {
            TxtID.Text = "";
            TxtSeri.Text = "";
            TxtSiraNo.Text = "";
            MskTarih.Text = "";
            MskSaat.Text = "";
            TxtVergiDairesi.Text = "";
            TxtAlici.Text = "";
            TxtTeslimEden.Text = "";
            TxtTeslimAlan.Text = "";

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

           
            if (TxtFaturaid.Text == "")
            {
                SqlCommand komut = new SqlCommand("insert into TBL_FATURABILGI (SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtSeri.Text);
                komut.Parameters.AddWithValue("@p2", TxtSiraNo.Text);
                komut.Parameters.AddWithValue("@p3", MskTarih.Text);
                komut.Parameters.AddWithValue("@p4", MskSaat.Text);
                komut.Parameters.AddWithValue("@p5", TxtVergiDairesi.Text);
                komut.Parameters.AddWithValue("@p6", TxtAlici.Text);
                komut.Parameters.AddWithValue("@p7", TxtTeslimEden.Text);
                komut.Parameters.AddWithValue("@p8", TxtTeslimAlan.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Bilgisi Sisteme Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }

            //FİRMA CARİSİ

            if (TxtFaturaid.Text != "" && comboBox1.Text == "Firma")
            {

                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(TxtFiyat.Text);
                miktar = Convert.ToDouble(TxtMiktar.Text);
                tutar = miktar * fiyat;
                TxtTutar.Text = tutar.ToString();
                SqlCommand komut2 = new SqlCommand("insert into TBL_FATURADETAY (URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID) values (@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", TxtUrunAd.Text);
                komut2.Parameters.AddWithValue("@p2", TxtMiktar.Text);
                komut2.Parameters.AddWithValue("@p3", decimal.Parse(TxtFiyat.Text));
                komut2.Parameters.AddWithValue("@p4", decimal.Parse(TxtTutar.Text));
                komut2.Parameters.AddWithValue("@p5", TxtFaturaid.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();


                //Hareket Tablosuna Veri Girişi

                SqlCommand komut3 = new SqlCommand("insert into TBL_FIRMAHAREKETLER (urunıd,adet,personel,fırma,fıyat,toplam,faturaıd,tarıh) values (@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8)", bgl.baglanti());
                komut3.Parameters.AddWithValue("@h1", TxtUrunId.Text);
                komut3.Parameters.AddWithValue("@h2", TxtMiktar.Text);
                komut3.Parameters.AddWithValue("@h3", TxtPersonel.Text);
                komut3.Parameters.AddWithValue("@h4", TxtFirma.Text);
                komut3.Parameters.AddWithValue("@h5", decimal.Parse(TxtFiyat.Text));
                komut3.Parameters.AddWithValue("@h6", decimal.Parse(TxtTutar.Text));
                komut3.Parameters.AddWithValue("@h7", TxtFaturaid.Text);
                komut3.Parameters.AddWithValue("@h8", MskTarih.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();


                //Stok sayısını azaltma

                SqlCommand komut4 = new SqlCommand("update TBL_URUNLER set adet=adet-@s1 where ID=@s2", bgl.baglanti());
                komut4.Parameters.AddWithValue("@s1", TxtMiktar.Text);
                komut4.Parameters.AddWithValue("@s2", TxtUrunId.Text);
                komut4.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Faturaya Ait Ürün Bilgisi Sisteme Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }


            //MÜŞTERİ CARİSİ

            if (TxtFaturaid.Text != "" && comboBox1.Text == "Müşteri")
            {

                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(TxtFiyat.Text);
                miktar = Convert.ToDouble(TxtMiktar.Text);
                tutar = miktar * fiyat;
                TxtTutar.Text = tutar.ToString();
                SqlCommand komut6 = new SqlCommand("insert into TBL_FATURADETAY (URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID) values (@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                komut6.Parameters.AddWithValue("@p1", TxtUrunAd.Text);
                komut6.Parameters.AddWithValue("@p2", TxtMiktar.Text);
                komut6.Parameters.AddWithValue("@p3", decimal.Parse(TxtFiyat.Text));
                komut6.Parameters.AddWithValue("@p4", decimal.Parse(TxtTutar.Text));
                komut6.Parameters.AddWithValue("@p5", TxtFaturaid.Text);
                komut6.ExecuteNonQuery();
                bgl.baglanti().Close();


                //Hareket Tablosuna Veri Girişi

                SqlCommand komut7 = new SqlCommand("insert into TBL_MUSTERIHAREKETLER (urunıd,adet,personel,musterı,fıyat,toplam,faturaıd,tarıh) values (@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8)", bgl.baglanti());
                komut7.Parameters.AddWithValue("@h1", TxtUrunId.Text);
                komut7.Parameters.AddWithValue("@h2", TxtMiktar.Text);
                komut7.Parameters.AddWithValue("@h3", TxtPersonel.Text);
                komut7.Parameters.AddWithValue("@h4", TxtFirma.Text);
                komut7.Parameters.AddWithValue("@h5", decimal.Parse(TxtFiyat.Text));
                komut7.Parameters.AddWithValue("@h6", decimal.Parse(TxtTutar.Text));
                komut7.Parameters.AddWithValue("@h7", TxtFaturaid.Text);
                komut7.Parameters.AddWithValue("@h8", MskTarih.Text);
                komut7.ExecuteNonQuery();
                bgl.baglanti().Close();


                //Stok sayısını azaltma

                SqlCommand komut8 = new SqlCommand("update TBL_URUNLER set adet=adet-@s1 where ID=@s2", bgl.baglanti());
                komut8.Parameters.AddWithValue("@s1", TxtMiktar.Text);
                komut8.Parameters.AddWithValue("@s2", TxtUrunId.Text);
                komut8.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Faturaya Ait Ürün Bilgisi Sisteme Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtID.Text = dr["FATURABILGIID"].ToString();
            TxtSeri.Text = dr["SERI"].ToString();
            TxtSiraNo.Text = dr["SIRANO"].ToString();
            MskTarih.Text = dr["TARIH"].ToString();
            MskSaat.Text = dr["SAAT"].ToString();
            TxtVergiDairesi.Text = dr["VERGIDAIRE"].ToString();
            TxtAlici.Text = dr["ALICI"].ToString();
            TxtTeslimEden.Text = dr["TESLIMEDEN"].ToString();
            TxtTeslimAlan.Text = dr["TESLIMALAN"].ToString();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {

        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_FATURABILGI set SERI=@p1,SIRANO=@p2,TARIH=@p3,SAAT=@p4,VERGIDAIRE=@p5,ALICI=@p6,TESLIMEDEN=@p7,TESLIMALAN=@p8 where FATURABILGIID=@p9", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtSeri.Text);
            komut.Parameters.AddWithValue("@p2", TxtSiraNo.Text);
            komut.Parameters.AddWithValue("@p3", MskTarih.Text);
            komut.Parameters.AddWithValue("@p4", MskSaat.Text);
            komut.Parameters.AddWithValue("@p5", TxtVergiDairesi.Text);
            komut.Parameters.AddWithValue("@p6", TxtAlici.Text);
            komut.Parameters.AddWithValue("@p7", TxtTeslimEden.Text);
            komut.Parameters.AddWithValue("@p8", TxtTeslimAlan.Text);
            komut.Parameters.AddWithValue("@p9", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            Listele();
            MessageBox.Show("Fatura Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunDetay fr = new FrmFaturaUrunDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.id = TxtID.Text;
            }
            fr.Show();
        }

        private void BtnBul_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select urunad,satısfıyat from TBL_URUNLER where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtUrunId.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtUrunAd.Text = dr[0].ToString();
                TxtFiyat.Text = dr[1].ToString();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
