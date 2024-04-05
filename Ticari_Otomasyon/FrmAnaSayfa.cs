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
using System.Xml;

namespace Ticari_Otomasyon
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void azalanstoklar()
        {
            gridView1.OptionsBehavior.Editable = false;
            SqlDataAdapter da = new SqlDataAdapter("select URUNAD as 'Ürün Adı',sum(ADET) as 'Miktar' from TBL_URUNLER  group by URUNAD having sum(ADET)<=20 order by sum(adet)", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void ajanda()
        {
            gridView2.OptionsBehavior.Editable = false;
            SqlDataAdapter da = new SqlDataAdapter("select top 10 TARIH, Saat,BASLIK,detay,olusturan from tbl_notlar order by ID asc", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        void FirmaHareketleri()
        {
            gridView3.OptionsBehavior.Editable = false;
            SqlDataAdapter da = new SqlDataAdapter("execute firmaanasayfa", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl3.DataSource = dt;
        }


        void fihrist()
        {
            gridView4.OptionsBehavior.Editable = false;
            SqlDataAdapter da = new SqlDataAdapter("select ad,telefon1 from TBL_FIRMALAR", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl4.DataSource = dt;
        }

        void haberler()
        {
            XmlTextReader xmloku = new XmlTextReader("https://www.ekonomidunya.com/rss_haberler_5.xml");
            while (xmloku.Read())
            {
                if (xmloku.Name == "title")
                {
                    listBox1.Items.Add(xmloku.ReadString());
                }
            }
        }


        void haberler1()
        {
            XmlTextReader cnn = new XmlTextReader("https://www.cnnturk.com/feed/rss/all/news");
            while (cnn.Read())
            {
                if (cnn.Name == "title")
                {
                    listBox1.Items.Add(cnn.ReadString());
                }
            }
        }

        void haberler2()
        {
            XmlTextReader mllyt = new XmlTextReader("https://www.milliyet.com.tr/rss/rssNew/SonDakikaRss.xml");
            while (mllyt.Read())
            {
                if (mllyt.Name == "title")
                {
                    listBox1.Items.Add(mllyt.ReadString());
                }
            }
        }


        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            azalanstoklar();
            ajanda();
            FirmaHareketleri();
            fihrist();
            webBrowser1.Navigate("https://tcmb.gov.tr/kurlar/today.xml");
            haberler();
        }

        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if (sayac == 1)
            {
                azalanstoklar();
                ajanda();
                FirmaHareketleri();
            }
            if (sayac == 2)
            {
                sayac = 0;
            }
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            FrmNotDetay fr = new FrmNotDetay();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)
            {
                fr.notid = dr["detay"].ToString();
                fr.Show();
            }

        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            FrmHareketFirmaDetay fr = new FrmHareketFirmaDetay();
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (dr != null)
            {
                fr.detayid = double.Parse(dr["HAREKETID"].ToString());
            }
            fr.Show();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            haberler();
        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            haberler1();
        }

        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            haberler2();
        }
    }
}
