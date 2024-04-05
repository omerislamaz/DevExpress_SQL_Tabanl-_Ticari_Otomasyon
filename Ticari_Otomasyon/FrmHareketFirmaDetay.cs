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
    public partial class FrmHareketFirmaDetay : Form
    {
        public FrmHareketFirmaDetay()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        public double detayid;
        private void FrmHareketFirmaDetay_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT URUNAD,TBL_FIRMAHAREKETLER.ADET, TBL_FIRMALAR.AD, FIYAT,TOPLAM FROM TBL_FIRMAHAREKETLER inner join TBL_URUNLER ON  TBL_FIRMAHAREKETLER.URUNID=TBL_URUNLER.ID INNER JOIN TBL_FIRMALAR ON TBL_FIRMAHAREKETLER.FIRMA=TBL_FIRMALAR.ID where HAREKETID='"+detayid+"'", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
    }
}
