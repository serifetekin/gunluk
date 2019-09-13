using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUNLUK.admin
{
    public partial class Sayfa : System.Web.UI.Page
    {
        BLOGEntities1 db = new BLOGEntities1();

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = db.SAYFAs.ToList();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ref_no = Convert.ToInt32(GridView1.SelectedDataKey.Value);
            SAYFA s = db.SAYFAs.Find(ref_no);

            if(s != null)
            {
                txtSAYFA_REFNO.Text = s.SAYFA_REFNO.ToString();
                txtBASLIK.Text = s.BASLIK;
                txtICERIK.Text = s.ICERIK;
            }

            pnlKayit.Visible = true;
            pnlListe.Visible = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // kaydet
            if (txtSAYFA_REFNO.Text != "")
            {
                int ref_no = Convert.ToInt32(txtSAYFA_REFNO.Text);
                SAYFA s = db.SAYFAs.Find(ref_no);
                s.BASLIK = txtBASLIK.Text;
                s.ICERIK = txtICERIK.Text;
                db.SaveChanges();
            }
            else
            {
                SAYFA s = new SAYFA();
                s.BASLIK = txtBASLIK.Text;
                s.ICERIK = txtICERIK.Text;
                db.SAYFAs.Add(s);
                db.SaveChanges();
            }
            GridView1.DataSource = db.SAYFAs.ToList();
            GridView1.DataBind();

            pnlKayit.Visible = false;
            pnlListe.Visible = true;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            // Vazgeç
            GridView1.DataSource = db.SAYFAs.ToList();
            GridView1.DataBind();

            pnlKayit.Visible = false;
            pnlListe.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        { // yeni
            txtSAYFA_REFNO.Text = "";
            txtBASLIK.Text = "";
            txtICERIK.Text = "";

            pnlKayit.Visible = true;
            pnlListe.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //ara

            GridView1.DataSource = db.SAYFAs.Where(s => s.BASLIK.Contains(txtARA.Text)).ToList();
            GridView1.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            // sil
            int ref_no = Convert.ToInt32(txtSAYFA_REFNO.Text);
            SAYFA s = db.SAYFAs.Find(ref_no);

            db.SAYFAs.Remove(s);
            db.SaveChanges();

            GridView1.DataSource = db.SAYFAs.ToList();
            GridView1.DataBind();

            pnlKayit.Visible = false;
            pnlListe.Visible = true;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.DataSource = e.NewPageIndex;
            GridView1.DataSource = db.SAYFAs.Where(s => s.BASLIK.Contains(txtARA.Text)).ToList();
            GridView1.DataBind();
        }
    }
}