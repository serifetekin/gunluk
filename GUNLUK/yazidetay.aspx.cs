using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUNLUK
{
    public partial class yazidetay : System.Web.UI.Page
    {
        BLOGEntities1 db = new BLOGEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["yazi_refno"] != null)
            {
                int ref_no = Convert.ToInt32(Request["yazi_refno"]);
                YAZI y = db.YAZIs.Find(ref_no);

                if (y != null)
                {
                    Label1.Text = y.BASLIK;
                    Label2.Text = y.ICERIK;
                }
                else
                {
                    Label1.Text = "";
                    Label2.Text = "";
                }
            }
        }
    }
}