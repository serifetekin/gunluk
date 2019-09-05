using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUNLUK.admin
{
    public partial class Yazi : System.Web.UI.Page
    {
        BLOGEntities1 db = new BLOGEntities1();

        public string HtmlUtility { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = db.VW_YAZI.ToList();
            GridView1.DataBind();

            // SAYFA ilk kez çağırıldığında doldur, ilk kez çağırılıyorsa doldurma
            if (IsPostBack == false)
            {
                // kategori bilgisi veritabanından çekip ddlKATEGORI_REFNO'ya aktarıldı.
                ddlKATEGORI_REFNO.DataSource = db.KATEGORIs.ToList();
                ddlKATEGORI_REFNO.DataTextField = "KATEGORI_ADI";
                ddlKATEGORI_REFNO.DataValueField = "KATEGORI_REFNO";
                ddlKATEGORI_REFNO.DataBind();
                // not:sayfayı link olarak bir kez çağırdığınızda postback olayı gerçekleşmiyor; sayfayı açıp butona bir kez tıkladığımızda postback olayı gerçekleşiyor.
                // pageload -> PostBack event-> page_unload -> dispose
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ref_no = Convert.ToInt32(GridView1.SelectedDataKey.Value);

            YAZI y = db.YAZIs.Find(ref_no);

            if (y != null)
            {
                txtBASLIK.Text = y.BASLIK;
                txtICERIK.Text = y.ICERIK;
                txtOZET.Text = y.OZET;
                txtTARIH.Text = y.TARIH.ToString("dd.MM.yyyy");
                txtTIKLANMA_SAYISI.Text = y.TIKLANMA_SAYISI.ToString();
                txtYAZI_REFNO.Text = y.YAZI_REFNO.ToString();
                ddlDURUMU.SelectedValue = y.DURUMU.ToString();
                ddlKATEGORI_REFNO.SelectedValue = y.KATEGORI_REFNO.ToString();
            }
            pnlKayit.Visible = true;
            pnlListe.Visible = false;


        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // Kaydet
            if(txtYAZI_REFNO.Text != "")
            {
                int ref_no = Convert.ToInt32(txtYAZI_REFNO.Text);
                YAZI y = db.YAZIs.Find(ref_no);

                y.BASLIK = txtBASLIK.Text;
                y.DURUMU = Convert.ToBoolean(ddlDURUMU.SelectedValue);
                y.ICERIK = HttpUtility.HtmlDecode(txtICERIK.Text);
                y.KATEGORI_REFNO = Convert.ToInt32(ddlKATEGORI_REFNO.SelectedValue);
                y.OZET = txtOZET.Text;
                y.TARIH = Convert.ToDateTime(txtTARIH.Text);
                y.TIKLANMA_SAYISI = Convert.ToInt32(txtTIKLANMA_SAYISI.Text);

                db.SaveChanges();
            }
            else
            {
                YAZI y = new YAZI();

                y.BASLIK = txtBASLIK.Text;
                y.DURUMU = Convert.ToBoolean(ddlDURUMU.SelectedValue);
                y.ICERIK = HttpUtility.HtmlDecode(txtICERIK.Text);
                y.KATEGORI_REFNO = Convert.ToInt32(ddlKATEGORI_REFNO.SelectedValue);
                y.OZET = txtOZET.Text;
                y.TARIH = Convert.ToDateTime(txtTARIH.Text);
                y.TIKLANMA_SAYISI = Convert.ToInt32(txtTIKLANMA_SAYISI.Text);
                db.YAZIs.Add(y);
                db.SaveChanges();
            }
            GridView1.DataSource = db.VW_YAZI.ToList();
            GridView1.DataBind();

            pnlKayit.Visible = false;
            pnlListe.Visible = true;

        }
    }
}