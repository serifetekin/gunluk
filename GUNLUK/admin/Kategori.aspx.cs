using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUNLUK.admin
{
    public partial class Kategori : System.Web.UI.Page
    {
        BLOGEntities1 db = new BLOGEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = db.KATEGORIs.ToList();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ref_no = Convert.ToInt32(GridView1.SelectedDataKey.Value);
            KATEGORI k = db.KATEGORIs.Find(ref_no);

            if (k != null)
            {
                txtKATEGORI_REFNO.Text = k.KATEGORI_REFNO.ToString();
                txtKATEGORI_ADI.Text = k.KATEGORI_ADI;
            }

            pnlKayit.Visible = true;
            pnlListe.Visible = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // Kaydet
            if(txtKATEGORI_REFNO.Text != "")
            {
                int ref_no = Convert.ToInt32(txtKATEGORI_REFNO.Text);
                KATEGORI k = db.KATEGORIs.Find(ref_no);
                k.KATEGORI_ADI = txtKATEGORI_ADI.Text;
                db.SaveChanges();
            }
            else
            {
                KATEGORI k = new KATEGORI();
                k.KATEGORI_ADI = txtKATEGORI_ADI.Text;
                db.KATEGORIs.Add(k);
                db.SaveChanges();
            }

            GridView1.DataSource = db.KATEGORIs.ToList();
            GridView1.DataBind();

            pnlKayit.Visible = false;
            pnlListe.Visible = true;
        }

        protected void Button4_Click(object sender, EventArgs e)
        { // Vazgeç
            GridView1.DataSource = db.KATEGORIs.ToList();
            GridView1.DataBind();

            pnlKayit.Visible = false;
            pnlListe.Visible = true;

        }

        protected void Button2_Click(object sender, EventArgs e)
        { // Yeni
            txtKATEGORI_ADI.Text = "";
            txtKATEGORI_REFNO.Text = "";

            pnlKayit.Visible = true;
            pnlListe.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Ara
            GridView1.DataSource = db.KATEGORIs.Where(k => k.KATEGORI_ADI.Contains(txtARA.Text)).ToList();
            GridView1.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            // Sil
            int ref_no = Convert.ToInt32(txtKATEGORI_REFNO.Text);
            KATEGORI k = db.KATEGORIs.Find(ref_no);

            db.KATEGORIs.Remove(k);
            db.SaveChanges();

            GridView1.DataSource = db.KATEGORIs.ToList();
            GridView1.DataBind();

            pnlKayit.Visible = false;
            pnlListe.Visible = true;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = db.KATEGORIs.Where(k => k.KATEGORI_ADI.Contains(txtARA.Text)).ToList();
            GridView1.DataBind();

        }

    }
}