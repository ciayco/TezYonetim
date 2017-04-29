using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Ogrenci_RaporListele : TezBaseUser
{
    TezDBEntities db = new TezDBEntities();
    Rapor rpr = new Rapor();
    Ogrenci ogr = new Ogrenci();
    protected void Page_Load(object sender, EventArgs e)
    {
        ogr = db.Ogrenci.Find(AppKontrol.id);
        var trh = db.Rapor_Tarih.Where(t => t.Hoca_Id == ogr.Hoca_ID).ToList();
        Repeater1.DataSource = trh;
        Repeater1.DataBind();
    }
    protected void Rapor_goruntule_Click(object sender, CommandEventArgs e)
    {
        string id;
        int rprid;
        switch (e.CommandName)
        {
            case "Goruntule":
                id = e.CommandArgument.ToString();
                rprid = Convert.ToInt32(id);
                var rapor = db.Rapor.Where(o => o.Tarih_Id == rprid).FirstOrDefault();
                string navigateURL = "../../../Raporlar/" + rapor.Dosya + ".pdf";
                string target = "_blank";
                string windowProperties = "status=no, menubar=yes, toolbar=yes";
                string scriptText = "window.open('" + navigateURL + "','" + target + "','" + windowProperties + "')";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "eşsizAnahtar", scriptText, true);
                break;
        }
    }
    protected void Rapor_Yukle_Click(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Kaydet":
                HttpPostedFile myFile = filMyFile.PostedFile;
                if (myFile.ContentLength > 0)
                {
                    string id = HiddenField1.Value.ToString();
                    myFile.SaveAs(Server.MapPath("~/Raporlar/") + ogr.Hoca_ID + ogr.Tez_ID + id + ".pdf");
                    rpr.Hoca_Id = ogr.Hoca_ID;
                    rpr.Tez_Id = ogr.Tez_ID;
                    rpr.Tarih_Id = Convert.ToInt32(id);
                    rpr.Dosya = ogr.Hoca_ID + "" + ogr.Tez_ID + "" + rpr.Tarih_Id;
                    db.Rapor.Add(rpr);
                    db.SaveChanges();
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Kaydedildi');</script>");
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Hata');</script>");
                }
                break;
        }
    }

}

