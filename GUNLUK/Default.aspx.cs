using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUNLUK
{
    public partial class Default : System.Web.UI.Page
    {
        BLOGEntities1 db = new BLOGEntities1();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataList1.DataSource = db.YAZIs.OrderByDescending(y => y.TARIH).Take(5).ToList();
            DataList1.DataBind();
        }

    }
}