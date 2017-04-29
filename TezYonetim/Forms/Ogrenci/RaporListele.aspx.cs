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
    protected void Rapor_goruntule_Click(object sender, EventArgs e)
    {
        //Raporlar klasorunde 1.pdf var direk onu çekiyorum vt kaydettıgımız ısme gore cekıccez DUZENLENECEK 
        string navigateURL = "../../../Raporlar/1.pdf";//DUZENLENECEK
        string target = "_blank";
        string windowProperties = "status=no, menubar=yes, toolbar=yes";
        string scriptText = "window.open('" + navigateURL + "','" + target + "','" + windowProperties + "')";

        Page.ClientScript.RegisterStartupScript(this.GetType(), "eşsizAnahtar", scriptText, true);
    }

    protected void Rapor_Yukle_Click(object sender, CommandEventArgs e)
    {
        string abcf = Label1.Text;//null donuyo bakılcak
        string id;
        switch (e.CommandName)
        {
            case "Kaydet":
                id = e.CommandArgument.ToString();
                HttpPostedFile myFile = filMyFile.PostedFile;
                if (myFile.ContentLength > 0)//kontrol edılcek bos durumda false vermıyo
                {
                    myFile.SaveAs(Server.MapPath("~/Raporlar/") + myFile.FileName);
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

