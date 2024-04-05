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
    public partial class FrmRehber : Form
    {
        public FrmRehber()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void FrmRehber_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
            gridView2.OptionsBehavior.Editable = false;

            //Müşteri Bilgileri
            SqlDataAdapter da = new SqlDataAdapter("Select AD,SOYAD,TELEFON,TELEFON2,MAIL From TBL_MUSTERILER", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;


            //Firma Bilgileri
            SqlDataAdapter da2 = new SqlDataAdapter("Select AD,YETKILISTATU as 'ÜNVAN',YETKILIADSOYAD as 'YETKİLİ',TELEFON1,TELEFON2,TELEFON3,FAX,MAIL From TBL_FIRMALAR", bgl.baglanti());
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
        }

        
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frm= new FrmMail();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                frm.mail = dr[4].ToString();
                frm.Show();
            }
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frm = new FrmMail();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)
            {
                frm.mail = dr[7].ToString();
                frm.Show();
            }
        }
    }
}
