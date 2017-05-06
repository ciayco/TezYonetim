using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Hoca_RaporListele : TezBase
{
    TezDBEntities db = new TezDBEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        var tezler = db.Tez.Where(o => o.Hoca_ID == AppKontrol.id ).ToList();
        Repeater1.DataSource = tezler;
        Repeater1.DataBind();
    }
    protected void Goster_Click(object sender, CommandEventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(GetType(), "modelBox", "$('.modal').modal()", true);

        string id;
        int tezid;
     

        switch (e.CommandName)
        {
            case "Goruntule":
                id = e.CommandArgument.ToString();
                tezid = Convert.ToInt32(id);
                Label1.Text = "deneme";
                var rapor = db.Rapor.Where(o => o.Tez_Id == tezid).FirstOrDefault();

                if (rapor != null)
                {

                    string navigateURL = "../../../Raporlar/" + rapor.Dosya + "." + rapor.Ad;
                    string target = "_blank";
                    string windowProperties = "status=no, menubar=yes, toolbar=yes";
                    string scriptText = "window.open('" + navigateURL + "','" + target + "','" + windowProperties + "')";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "eşsizAnahtar", scriptText, true);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Görüntülenecek Rapor Bulunamadı');</script>");
                }
                break;
        }
    }
}