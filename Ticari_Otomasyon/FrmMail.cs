using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Ticari_Otomasyon
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }


        public string mail;
        private void FrmMail_Load(object sender, EventArgs e)
        {
            TxtMailAdresi.Text = mail;

        }

        private void BtnGonder_Click(object sender, EventArgs e)
        {

            try
            {
            MailMessage mesajim = new MailMessage();
            SmtpClient istemci = new SmtpClient("smtp.gmail.com");
            mesajim.From = new MailAddress("ornekhesap1001@gmail.com");
            mesajim.To.Add(TxtMailAdresi.Text);
            mesajim.Subject = TxtKonu.Text;
            mesajim.Body = RchMesaj.Text;
            istemci.Port = 587;

             //Google Güvenlik ayarlarından Uygulama Şifresi Oluşturulmalı.
            istemci.Credentials = new NetworkCredential("ornekhesap1001@gmail.com", "mfju raps klwd njbm");
            istemci.EnableSsl = true;
            istemci.Send(mesajim);
            MessageBox.Show("Mail Gönderildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Hata ile karşılaşıldı. \n\n\n Hata Mesajı: " + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
