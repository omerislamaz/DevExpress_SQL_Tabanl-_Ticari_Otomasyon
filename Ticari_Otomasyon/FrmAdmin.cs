﻿using System;
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
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }


        sqlbaglantisi bgl = new sqlbaglantisi();

        private void button1_MouseHover(object sender, EventArgs e)
        {
            btngiris.BackColor = Color.Khaki;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btngiris.BackColor = Color.LightGray;
        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from TBL_ADMIN where KullaniciAd=@p1 and Sifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmAnaModul fr = new FrmAnaModul();
                fr.kullanici=TxtKullaniciAd.Text;
                fr.Show();
                this.Hide();
                
                
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Ad veya Şifre", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            bgl.baglanti().Close();
        }
    }
}
