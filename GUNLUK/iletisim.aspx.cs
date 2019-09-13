using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;
using System.Net.Mail;
using System.Net;


namespace GUNLUK
{
    public partial class iletişim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MailMessage mesaj = new MailMessage();
            mesaj.From = new MailAddress("serifetekin2451@gmail.com", "Mustafa Çelikcan"); // kimden
            mesaj.To.Add(txtMAIL.Text);
            mesaj.Body = txtMESAJ.Text;
            mesaj.Subject = txtKONU.Text;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("serifetekin2451@gmail.com","Universiteler.5020"); // yıldızlı yere şifre girildikten sonra çalıştırılacak
            smtp.EnableSsl = true; // güvenli bağlantı için gerekli.

            try
            {
                smtp.Send(mesaj);
                lblSONUC.Text = "Mail Gönderildi.";
                txtADI_SOYADI.Text = "";
                txtKONU.Text = "";
                txtMAIL.Text = "";
                txtMESAJ.Text = "";
            }
            catch(Exception hata)
            {
                lblSONUC.Text = "Mesaj Gönderilemedi" + hata.Message;
            }

        }
    }
}