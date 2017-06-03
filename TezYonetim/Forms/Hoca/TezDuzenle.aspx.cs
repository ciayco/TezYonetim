using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Hoca_TezDuzenle : System.Web.UI.Page
{
    TezDBEntities db = new TezDBEntities();
    protected void Page_Load(object sender, EventArgs e)
    { TezDBEntities db = new TezDBEntities();
        if (Request.QueryString["Id"] != null&& !(IsPostBack))
        {
            int id = int.Parse(Request.QueryString["Id"]);
            var tez = db.Tez.Find(id);
            if (tez != null)
            {
                konu.Text = tez.Konu;
                aciklama.Text = tez.Aciklama;
                sayi.Text = Convert.ToString(tez.Tez_Limit);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Görüntülenecek Tez Bulunamadı');</script>");
                //Response.Redirect("~/Forms/Hoca/TezListele.aspx");
            }
        }
    }

    protected void btnGiris_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Id"] != null)
        {
            int id = int.Parse(Request.QueryString["Id"]);
            var tez = db.Tez.Find(id);
            if (tez != null)
            {
                tez.Konu = konu.Text;
                tez.Aciklama = aciklama.Text;
                tez.Tez_Limit = int.Parse(sayi.Text);
                db.SaveChanges();
                Response.Redirect("~/Forms/Hoca/TezListele.aspx");
            }
        }
    }
}