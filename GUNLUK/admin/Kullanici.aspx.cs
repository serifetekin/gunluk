using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUNLUK.admin
{
    public partial class Kullanici : System.Web.UI.Page
    {
        BLOGEntities1 db = new BLOGEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if( Session["GIRIS_YETKİ"] == null)
            {
                Response.Redirect("giris.aspx");
            }
            else
            {
                if(Convert.ToBoolean(Session["GIRIS_YETKİ"]) == false)
                {
                    Response.Redirect("giris.aspx");
                }
            }
            GridView1.DataSource = db.KULLANICIs.ToList();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ref_no = Convert.ToInt32(GridView1.SelectedDataKey.Value);
            KULLANICI k = db.KULLANICIs.Find(ref_no);

            if(k != null)
            {
                txtKULLANICI_ADI.Text = k.KULLANICI_ADI;
                txtKULLANICI_REFNO.Text = k.KULLANICI_REFNO.ToString();
                txtPAROLA.Text = k.PAROLA;
                ddlDURUMU.SelectedValue = k.DURUMU.ToString();
            }

            // kayıt panelini aç liste panelini kapat.
            pnlKayit.Visible = true;
            pnlListe.Visible = false;
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // kaydet
            if (txtKULLANICI_REFNO.Text != "") // ekranda kayıt varsa
            {
                int ref_no = Convert.ToInt32(txtKULLANICI_REFNO.Text);
                KULLANICI k = db.KULLANICIs.Find(ref_no); // güncellenecek kayıt bulunuyor
                k.KULLANICI_ADI = txtKULLANICI_ADI.Text;
                k.PAROLA = txtPAROLA.Text;
                k.DURUMU = Convert.ToBoolean(ddlDURUMU.SelectedValue);
                db.SaveChanges();
            }
            else
            {
                KULLANICI k = new KULLANICI();
                k.KULLANICI_ADI = txtKULLANICI_ADI.Text;
                k.PAROLA = txtPAROLA.Text;
                k.DURUMU = Convert.ToBoolean(ddlDURUMU.SelectedValue);
                db.KULLANICIs.Add(k); // yeni kayıt dbye ekleniyor.
                db.SaveChanges();
            }
            // değişikliklerin ekrana yansıtılması için
            GridView1.DataSource = db.KULLANICIs.ToList();
            GridView1.DataBind();

            // kayıt panelini kapat liste panelini aç.
            pnlKayit.Visible = false;
            pnlListe.Visible = true;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            // vazgeç
            GridView1.DataSource = db.KULLANICIs.ToList();
            GridView1.DataBind();

            // kayıt panelini kapat liste panelini aç.
            pnlKayit.Visible = false;
            pnlListe.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Yeni
            txtKULLANICI_ADI.Text = "";
            txtKULLANICI_REFNO.Text = "";
            txtPAROLA.Text = "";
            ddlDURUMU.SelectedValue = "True";

            // kayıt panelini aç liste panelini kapat.
            pnlKayit.Visible = true;
            pnlListe.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Ara 
            GridView1.DataSource = db.KULLANICIs.Where(k => k.KULLANICI_ADI.Contains(txtAra.Text)).ToList();
            GridView1.DataBind();
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        { // sayfa numarasına tıkladığında içeriğini getirsin istiyoruz.
            // tıklanılan sayfa bilgisi "e" ile geliyor.
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = db.KULLANICIs.Where(k => k.KULLANICI_ADI.Contains(txtAra.Text)).ToList();
            GridView1.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            // Sil
            if(txtKULLANICI_REFNO.Text != "")
            {
                int ref_no = Convert.ToInt32(txtKULLANICI_REFNO.Text);
                KULLANICI k = db.KULLANICIs.Find(ref_no);

                db.KULLANICIs.Remove(k);

                db.SaveChanges();

                GridView1.DataSource = db.KULLANICIs.ToList();
                GridView1.DataBind();
                // kayıt panelini kapat liste panelini aç.
                pnlKayit.Visible = false;
                pnlListe.Visible = true;
            }
        }
    }
}