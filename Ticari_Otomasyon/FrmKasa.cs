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
using DevExpress.Charts;

namespace Ticari_Otomasyon
{
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        void musterihareket()
        {
            gridView1.OptionsBehavior.Editable = false;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("execute MusteriHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }


        void firmahareket()
        {
            gridView3.OptionsBehavior.Editable = false;
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("execute FirmaHareketleri", bgl.baglanti());
            da2.Fill(dt2);
            gridControl3.DataSource = dt2;
        }

        void giderler()
        {
            gridView2.OptionsBehavior.Editable = false;
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3= new SqlDataAdapter("Select * From TBL_GIDERLER",bgl.baglanti());
            da3.Fill(dt3);
            gridControl2.DataSource = dt3;
        }

        public string ad;
        private void FrmKasa_Load(object sender, EventArgs e)
        {
            LblAktifKullanici.Text = ad;
            musterihareket();
            firmahareket();
            giderler();


            //Toplam Tutarı Hesaplama
            SqlCommand komut1 = new SqlCommand("Select sum(tutar) from TBL_FATURADETAY", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblKasaToplam.Text = dr1[0].ToString() + " TL";
            }
            bgl.baglanti().Close();


            SqlCommand komut2 = new SqlCommand("Select (ELEKTRIK + SU + DOGALGAZ + INTERNET + EKSTRA) from TBL_GIDERLER order by ID asc", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblOdemeler.Text = dr2[0].ToString() + " TL";
            }
            bgl.baglanti().Close();


            //Son Ayın Personel Maaşları
            SqlCommand komut3 = new SqlCommand("Select MAASLAR from TBL_GIDERLER order by ID asc", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblPersonelMaaslari.Text = dr3[0].ToString() + " TL";
            }
            bgl.baglanti().Close();


            //Toplam Müşteri Sayısı
            SqlCommand komut4 = new SqlCommand("Select count(AD) from TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblMusteriSayisi.Text = dr4[0].ToString();
            }
            bgl.baglanti().Close();



            //Toplam Firma Sayısı
            SqlCommand komut5 = new SqlCommand("Select count(*) from TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblFirmaSayisi.Text = dr5[0].ToString();
            }
            bgl.baglanti().Close();


            //Toplam Firma Şehir Sayısı
            SqlCommand komut6 = new SqlCommand("Select count(Distinct(IL)) from TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                LblFirmaSehirSayisi.Text = dr6[0].ToString();
            }
            bgl.baglanti().Close();


            //Toplam Müşteri Şehir Sayısı
            SqlCommand komut7 = new SqlCommand("Select count(Distinct(IL)) from TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                LblSehirSayisi.Text = dr7[0].ToString();
            }
            bgl.baglanti().Close();


            //Toplam Personel Sayısı
            SqlCommand komut8 = new SqlCommand("Select count(*) from TBL_PERSONELLER", bgl.baglanti());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                LblPersonelSayisi.Text = dr8[0].ToString();
            }
            bgl.baglanti().Close();


            //Toplam Stok Sayısı
            SqlCommand komut9 = new SqlCommand("Select sum(adet) from TBL_URUNLER", bgl.baglanti());
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                LblStokSayisi.Text = dr9[0].ToString();
            }
            bgl.baglanti().Close();  

        }

        int sayac = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;

            //Elektrik
            if (sayac > 0 && sayac <= 5)
            {
                groupControl10.Text = "Elektrik";
                SqlCommand komut10 = new SqlCommand("Select top 4 Ay,Elektrık from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();
            }

            //Su
            if (sayac > 5 && sayac <= 10)
            {
                chartControl1.Series["Aylar"].Points.Clear();
                groupControl10.Text = "Su";
                SqlCommand komut11 = new SqlCommand("select top 4 ay,su from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }

            //Doğalgaz
            if (sayac > 10 && sayac <= 15)
            {
                chartControl1.Series["Aylar"].Points.Clear();
                groupControl10.Text = "Doğalgaz";
                SqlCommand komut12 = new SqlCommand("select top 4 ay,Dogalgaz from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr12 = komut12.ExecuteReader();
                while (dr12.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));
                }
                bgl.baglanti().Close();
            }

            //İnternet
            if (sayac > 15 && sayac <= 20)
            {
                chartControl1.Series["Aylar"].Points.Clear();
                groupControl10.Text = "İnternet";
                SqlCommand komut13 = new SqlCommand("select top 4 ay,Internet from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr13 = komut13.ExecuteReader();
                while (dr13.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr13[0], dr13[1]));
                }
                bgl.baglanti().Close();
            }


            //Ekstra
            if (sayac > 20 && sayac <= 25)
            {
                chartControl1.Series["Aylar"].Points.Clear();
                groupControl10.Text = "Ekstra";
                SqlCommand komut14 = new SqlCommand("select top 4 ay,Ekstra from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr14 = komut14.ExecuteReader();
                while (dr14.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr14[0], dr14[1]));
                }
                bgl.baglanti().Close();
            }

            if (sayac==26)
            {
                sayac = 0;
            }

        }


        int sayac2 = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            sayac2++;

            //Elektrik
            if (sayac2 > 0 && sayac2 <= 5)
            {
                groupControl11.Text = "Elektrik";
                SqlCommand komut10 = new SqlCommand("Select top 4 Ay,Elektrık from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();
            }

            //Su
            if (sayac2 > 5 && sayac2 <= 10)
            {
                chartControl2.Series["Aylar"].Points.Clear();
                groupControl11.Text = "Su";
                groupControl11.BackColor = Color.Aqua;
                SqlCommand komut11 = new SqlCommand("select top 4 ay,su from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }

            //Doğalgaz
            if (sayac2 > 10 && sayac2 <= 15)
            {
                chartControl2.Series["Aylar"].Points.Clear();
                groupControl11.Text = "Doğalgaz";
                groupControl11.BackColor = Color.LightGreen;
                SqlCommand komut12 = new SqlCommand("select top 4 ay,Dogalgaz from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr12 = komut12.ExecuteReader();
                while (dr12.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));
                }
                bgl.baglanti().Close();
            }

            //İnternet
            if (sayac2 > 15 && sayac2 <= 20)
            {
                chartControl2.Series["Aylar"].Points.Clear();
                groupControl11.Text = "İnternet";
                groupControl11.BackColor = Color.LightGoldenrodYellow;
                SqlCommand komut13 = new SqlCommand("select top 4 ay,Internet from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr13 = komut13.ExecuteReader();
                while (dr13.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr13[0], dr13[1]));
                }
                bgl.baglanti().Close();
            }


            //Ekstra
            if (sayac2 > 20 && sayac2 <= 25)
            {
                chartControl2.Series["Aylar"].Points.Clear();
                groupControl11.Text = "Ekstra";
                groupControl11.BackColor = Color.LightCoral;
                SqlCommand komut14 = new SqlCommand("select top 4 ay,Ekstra from TBL_GIDERLER order by ID desc", bgl.baglanti());
                SqlDataReader dr14 = komut14.ExecuteReader();
                while (dr14.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr14[0], dr14[1]));
                }
                bgl.baglanti().Close();
            }

            if (sayac2 == 26)
            {
                sayac2 = 0;
            }
        }
    }
}
