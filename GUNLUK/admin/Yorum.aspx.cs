using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUNLUK
{
    public partial class Yorum : System.Web.UI.Page
    {
        BLOGEntities1 db = new BLOGEntities1();

        public string HtmlUtility { get; private set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView2.DataSource = db.VW_YAZI_YORUM.ToList();
            GridView2.DataBind();

            if (IsPostBack == false)
            {
                // kategori bilgisi veritabanından çekip ddlKATEGORI_REFNO'ya aktarıldı.
                ddlYAZI_REFNO.DataSource = db.YAZIs.ToList();
                ddlYAZI_REFNO.DataTextField = "BASLIK";
                ddlYAZI_REFNO.DataValueField = "YAZI_REFNO";
                ddlYAZI_REFNO.DataBind();
                // not:sayfayı link olarak bir kez çağırdığınızda postback olayı gerçekleşmiyor; sayfayı açıp butona bir kez tıkladığımızda postback olayı gerçekleşiyor.
                // pageload -> PostBack event-> page_unload -> dispose
            }

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ref_no = Convert.ToInt32(GridView2.SelectedDataKey.Value);
            YORUM y = db.YORUMs.Find(ref_no);

            if(y != null)
            {
                txtAD_SOYAD.Text = y.AD_SOYAD;
                txtICERIK.Text = y.ICERIK;
                txtTARIH.Text = y.TARIH.ToString("dd.MM.yyyy");
                ddlYAZI_REFNO.SelectedValue = y.YAZI_REFNO.ToString();
                txtIP.Text = y.IP;
                txtMAIL.Text = y.MAIL;
                txtYORUM_REFNO.Text = y.YORUM_REFNO.ToString();

            }
            pnlKayit.Visible = true;
            pnlListe.Visible = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // Kaydet
            if (txtYORUM_REFNO.Text != "")
            {
                int ref_no = Convert.ToInt32(txtYORUM_REFNO.Text);
                YORUM y = db.YORUMs.Find(ref_no);
                y.AD_SOYAD = txtAD_SOYAD.Text;
                y.DURUMU = ddlDURUMU.SelectedValue;
                y.ICERIK = HttpUtility.HtmlDecode(txtICERIK.Text);
                y.IP = txtIP.Text;
                y.TARIH = Convert.ToDateTime(txtTARIH.Text);
                y.MAIL = txtMAIL.Text;
                y.YAZI_REFNO = Convert.ToInt32(ddlYAZI_REFNO.SelectedValue);
                db.SaveChanges();

            }
            else
            {
                YORUM y = new YORUM();
                y.AD_SOYAD = txtAD_SOYAD.Text;
                y.DURUMU = ddlDURUMU.SelectedValue;
                y.ICERIK = HttpUtility.HtmlDecode(txtICERIK.Text);
                y.IP = txtIP.Text;
                y.TARIH = Convert.ToDateTime(txtTARIH.Text);
                y.YAZI_REFNO = Convert.ToInt32(ddlYAZI_REFNO.SelectedValue);
                y.MAIL = txtMAIL.Text;
                db.YORUMs.Add(y);
                db.SaveChanges();
            }
            GridView2.DataSource = db.VW_YAZI_YORUM.ToList();
            GridView2.DataBind();

            pnlKayit.Visible = false;
            pnlListe.Visible = true;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {// vazgeç
            GridView2.DataSource = db.VW_YAZI_YORUM.ToList();
            GridView2.DataBind();

            pnlKayit.Visible = false;
            pnlListe.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // yeni
            txtAD_SOYAD.Text = "";
            txtICERIK.Text = "";
            txtIP.Text = "";
            txtMAIL.Text = "";
            txtTARIH.Text = "";
            txtYORUM_REFNO.Text = "";
            ddlDURUMU.SelectedValue = "True";

            pnlKayit.Visible = true;
            pnlListe.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // ara
            GridView2.DataSource = db.VW_YAZI_YORUM.Where(y=>y.ICERIK.Contains(txtARA.Text)).ToList();
            GridView2.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //sil
            int ref_no = Convert.ToInt32(txtYORUM_REFNO.Text);
            YORUM y = db.YORUMs.Find(ref_no);
            db.YORUMs.Remove(y);
            db.SaveChanges();

            GridView2.DataSource = db.VW_YAZI_YORUM.ToList();
            GridView2.DataBind();

            pnlKayit.Visible = false;
            pnlListe.Visible = true;

        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataSource = db.VW_YAZI_YORUM.Where(y => y.ICERIK.Contains(txtARA.Text)).ToList();
            GridView2.DataBind();
        }
    }
}