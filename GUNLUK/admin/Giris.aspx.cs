using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUNLUK.admin
{
    public partial class Giris : System.Web.UI.Page
    {
        BLOGEntities1 db = new BLOGEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Giriş Yap
            KULLANICI k = db.KULLANICIs.Where(k1 => k1.KULLANICI_ADI == txtKULLANICI_ADI.Text && k1.PAROLA == txtPAROLA.Text).SingleOrDefault(); // tek kayıt geleceğinden eminsek veya hiç kayıt da gelebilir. kayıt gelmezse null atar.

            if (k != null)
            {
                Session["YETKI_GIRIS"] = true;
                Response.Redirect("kullanici.aspx");
            }
            else
            {
                Session["YETKI_GIRIS"] = false;
            }
        }
    }
}