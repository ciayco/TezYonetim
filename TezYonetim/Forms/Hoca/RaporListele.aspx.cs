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
        
        var ogrenci = db.Ogrenci.Where(o => o.Hoca_ID == AppKontrol.id && o.Hoca_Onay == true).ToList();        
        Repeater1.DataSource = ogrenci;
        Repeater1.DataBind();
       
    }

    protected void Goster_Click(object sender,CommandEventArgs e)
    {
        string id;
        int rprid;
        switch (e.CommandName)
        {
            case "Goruntule":
                id = e.CommandArgument.ToString();
                rprid = Convert.ToInt32(id);
                var rapor = db.Rapor.Where(o => o.Tarih_Id == rprid).FirstOrDefault();
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