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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        void Listele()
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_ADMIN", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
            Listele();
        }

        private void BtnIslem_Click(object sender, EventArgs e)
        {
            if (BtnIslem.Text == "Kaydet")
            {
                SqlCommand komut = new SqlCommand("insert into TBL_ADMIN values (@p1,@p2)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtKullaniciAd.Text);
                komut.Parameters.AddWithValue("@p2", TxtSıfre.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                Listele();
                MessageBox.Show("Yeni Kullanıcı sisteme kayıt edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtKullaniciAd.Text = "";
                TxtSıfre.Text = "";
            }
            if (BtnIslem.Text == "Güncelle")
            {
                SqlCommand komut2 = new SqlCommand("Update TBL_ADMIN set sifre=@p2 where Kullaniciad=@p1", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", TxtKullaniciAd.Text);
                komut2.Parameters.AddWithValue("@p2", TxtSıfre.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                Listele();
                TxtKullaniciAd.Text = "";
                TxtSıfre.Text = "";
                BtnIslem.Text = "Kaydet";
                MessageBox.Show("Kayıt Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtKullaniciAd.Text = dr[0].ToString();
            TxtSıfre.Text = dr[1].ToString();
        }

        private void FrmAyarlar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TxtKullaniciAd.Text = "";
                TxtSıfre.Text = "";
                BtnIslem.Text = "Kaydet";
            }
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TxtKullaniciAd.Text = "";
                TxtSıfre.Text = "";
                BtnIslem.Text = "Kaydet";
            }
        }

        private void TxtKullaniciAd_TextChanged(object sender, EventArgs e)
        {
            if (TxtKullaniciAd.Text != null)
            {
                BtnIslem.Text = "Güncelle";
            }
            else
            {
                BtnIslem.Text = "Kaydet";
            }
        }
    }
}
