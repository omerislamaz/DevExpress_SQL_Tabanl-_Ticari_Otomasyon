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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_NOTLAR", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void Temizle()
        {
            TxtID.Text = "";
            MskTarıh.Text = "";
            MskSaat.Text = "";
            TxtBaslık.Text = "";
            RchDetay.Text = "";
            TxtOlusturan.Text = "";
            TxtHitap.Text = "";
            MskTarıh.Focus();
        }

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            listele();
            Temizle();
            gridView1.OptionsBehavior.Editable = false;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (MskTarıh.Text == "" || MskSaat.Text == "" || TxtBaslık.Text == "" || RchDetay.Text == "" || TxtOlusturan.Text == "" || TxtHitap.Text == "")
            {
                MessageBox.Show("Lütfen boş alanları doldurun", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlCommand komut = new SqlCommand("insert into TBL_NOTLAR (TARIH,SAAT,BASLIK,DETAY,OLUSTURAN,HITAP) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", MskTarıh.Text);
                komut.Parameters.AddWithValue("@p2", MskSaat.Text);
                komut.Parameters.AddWithValue("@p3", TxtBaslık.Text);
                komut.Parameters.AddWithValue("@p4", RchDetay.Text);
                komut.Parameters.AddWithValue("@p5", TxtOlusturan.Text);
                komut.Parameters.AddWithValue("@p6", TxtHitap.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                listele();
                Temizle();
                MessageBox.Show("Yeni Not sisteme kayıt edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtID.Text = dr[0].ToString();
            MskTarıh.Text = dr[1].ToString();
            MskSaat.Text = dr[2].ToString();
            TxtBaslık.Text = dr[3].ToString();
            RchDetay.Text = dr[4].ToString();
            TxtOlusturan.Text = dr[5].ToString();
            TxtHitap.Text = dr[6].ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult silme = MessageBox.Show("Seçilen Not sistemden silinecektir. Onaylıyor musun ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (silme == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Delete From TBL_NOTLAR where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtID.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Not sistemden silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                Temizle();
            }
            if (silme == DialogResult.No)
            {
                MessageBox.Show("Silme işlemi İPTAL edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                listele();
                Temizle();
            }
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_NOTLAR set TARIH=@p1,SAAT=@p2,BASLIK=@p3,DETAY=@p4,OLUSTURAN=@p5,HITAP=@p6 where ID=@p7", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTarıh.Text);
            komut.Parameters.AddWithValue("@p2", MskSaat.Text);
            komut.Parameters.AddWithValue("@p3", TxtBaslık.Text);
            komut.Parameters.AddWithValue("@p4", RchDetay.Text);
            komut.Parameters.AddWithValue("@p5", TxtOlusturan.Text);
            komut.Parameters.AddWithValue("@p6", TxtHitap.Text);
            komut.Parameters.AddWithValue("@p7", TxtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Güncelleme işlemi gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            Temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmNotDetay fr = new FrmNotDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.notid = dr["DETAY"].ToString();
                fr.Show();
            }

        }
    }
}
