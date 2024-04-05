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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void GiderListele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_GIDERLER Order By ID desc", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }


        void temizle()
        {
            TxtID.Text = "";
            CmbAy.Text = "";
            CmbYıl.Text = "";
            TxtElektrik.Text = "0,00";
            TxtSu.Text = "0,00";
            TxtDogalgaz.Text = "0,00";
            TxtInternet.Text = "0,00";
            TxtMaaslar.Text = "0,00";
            TxtEkstra.Text = "0,00";
            RchNotlar.Text = "";
            BtnKaydet.Enabled = true;
        }

        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            GiderListele();
            temizle();

            gridView1.OptionsBehavior.Editable = false;

            BtnGüncelle.Enabled = false;
            BtnSil.Enabled = false;
            BtnTemizle.Enabled = false;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {


            if (CmbAy.Text == "" || CmbYıl.Text == "")
            {
                MessageBox.Show("Ay ve Yıl Değerleri Boş Geçilemez.", "Bilgi", MessageBoxButtons.OK);
            }

            else
            {
                try
                {

                    SqlCommand komut = new SqlCommand("insert into TBL_GIDERLER (AY,YIL,ELEKTRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EKSTRA,NOTLAR) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", CmbAy.Text);
                    komut.Parameters.AddWithValue("@p2", CmbYıl.Text);
                    komut.Parameters.AddWithValue("@p3", decimal.Parse(TxtElektrik.Text));
                    komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtSu.Text));
                    komut.Parameters.AddWithValue("@p5", decimal.Parse(TxtDogalgaz.Text));
                    komut.Parameters.AddWithValue("@p6", decimal.Parse(TxtInternet.Text));
                    komut.Parameters.AddWithValue("@p7", decimal.Parse(TxtMaaslar.Text));
                    komut.Parameters.AddWithValue("@p8", decimal.Parse(TxtEkstra.Text));
                    komut.Parameters.AddWithValue("@p9", RchNotlar.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show(CmbAy.Text + " " + CmbYıl.Text + " " + "Giderleri Sisteme Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiderListele();
                }

                catch (Exception)
                {
                    MessageBox.Show("Boş Alanları doldurun", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

            private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
            {
                BtnGüncelle.Enabled = true;
                BtnSil.Enabled = true;
                BtnTemizle.Enabled = true;
                BtnKaydet.Enabled = false;

                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                TxtID.Text = dr[0].ToString();
                CmbAy.Text = dr[1].ToString();
                CmbYıl.Text = dr[2].ToString();
                TxtElektrik.Text = dr[3].ToString();
                TxtSu.Text = dr[4].ToString();
                TxtDogalgaz.Text = dr[5].ToString();
                TxtInternet.Text = dr[6].ToString();
                TxtMaaslar.Text = dr[7].ToString();
                TxtEkstra.Text = dr[8].ToString();
                RchNotlar.Text = dr[9].ToString();

            }

            private void BtnTemizle_Click(object sender, EventArgs e)
            {
                temizle();
                BtnGüncelle.Enabled = false;
                BtnSil.Enabled = false;
                BtnTemizle.Enabled = false;

            }

            private void BtnSil_Click(object sender, EventArgs e)
            {
                DialogResult gidersil = MessageBox.Show(CmbAy.Text + " " + CmbYıl.Text + " " + "Giderleri Silinecektir. Onaylıyor musun ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (gidersil == DialogResult.Yes)
                {
                    SqlCommand sil = new SqlCommand("Delete From TBL_GIDERLER where ID=@p1", bgl.baglanti());
                    sil.Parameters.AddWithValue("@p1", TxtID.Text);
                    sil.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Gider Silindi");
                    GiderListele();
                    temizle();
                    BtnGüncelle.Enabled = false;
                    BtnSil.Enabled = false;
                    BtnTemizle.Enabled = false;

                }
                if (gidersil == DialogResult.No)
                {
                    MessageBox.Show("İşlem İPTAL edildi");
                    GiderListele();
                    temizle();
                    BtnGüncelle.Enabled = false;
                    BtnSil.Enabled = false;
                    BtnTemizle.Enabled = false;
                    BtnKaydet.Enabled = true;
                }

            }

            private void BtnGüncelle_Click(object sender, EventArgs e)
            {
                SqlCommand giderguncelle = new SqlCommand("update TBL_GIDERLER set AY=@p1,YIL=@p2,ELEKTRIK=@p3,SU=@p4,DOGALGAZ=@p5,INTERNET=@p6,MAASLAR=@p7,EKSTRA=@p8,NOTLAR=@p9 where ID=@p10", bgl.baglanti());
                giderguncelle.Parameters.AddWithValue("@p1", CmbAy.Text);
                giderguncelle.Parameters.AddWithValue("@p2", CmbYıl.Text);
                giderguncelle.Parameters.AddWithValue("@p3", decimal.Parse(TxtElektrik.Text));
                giderguncelle.Parameters.AddWithValue("@p4", decimal.Parse(TxtSu.Text));
                giderguncelle.Parameters.AddWithValue("@p5", decimal.Parse(TxtDogalgaz.Text));
                giderguncelle.Parameters.AddWithValue("@p6", decimal.Parse(TxtInternet.Text));
                giderguncelle.Parameters.AddWithValue("@p7", decimal.Parse(TxtMaaslar.Text));
                giderguncelle.Parameters.AddWithValue("@p8", decimal.Parse(TxtEkstra.Text));
                giderguncelle.Parameters.AddWithValue("@p9", RchNotlar.Text);
                giderguncelle.Parameters.AddWithValue("@p10", TxtID.Text);
                giderguncelle.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show(CmbAy.Text + " " + CmbYıl.Text + " " + "Gideri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GiderListele();
                temizle();
                BtnKaydet.Enabled = true;
                BtnGüncelle.Enabled = false;
                BtnSil.Enabled = false;
                BtnTemizle.Enabled = false;
            }
        }
    }

