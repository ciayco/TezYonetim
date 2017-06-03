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
    public int sayac = 0;
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

        ogr = db.Ogrenci.Find(AppKontrol.id);
        switch (e.CommandName)
        {
            case "Goruntule":
                id = e.CommandArgument.ToString();
                string orgid = ogr.Hoca_ID.ToString() + ogr.Tez_ID.ToString() + id;
                var rapor = db.Rapor.Where(o => o.Dosya == orgid).FirstOrDefault();
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
    protected void Rapor_Yukle_Click(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Kaydet":
                HttpPostedFile myFile = filMyFile.PostedFile;
                if (myFile.ContentLength > 0)
                {
                    string[] parcalar = myFile.FileName.Split('.');//.dan sonrakı uzantıyı parcalar[1] içine atar 
                    string id = HiddenField1.Value.ToString();
                    int idi = Convert.ToInt32(id);
                    if (parcalar[1]=="doc" || parcalar[1] == "docx" || parcalar[1] == "pdf" || parcalar[1] == "DOC" || parcalar[1] == "DOCX" || parcalar[1] == "PDF")
                    {
                        var kontrol = db.Rapor.Where(w => w.Tarih_Id == idi && w.Hoca_Id == ogr.Hoca_ID && w.Tez_Id == ogr.Tez_ID).FirstOrDefault();
                        if (kontrol==null)
                        {
                            myFile.SaveAs(Server.MapPath("~/Raporlar/") + ogr.Hoca_ID + ogr.Tez_ID + id + "." + parcalar[1]);
                            rpr.Hoca_Id = ogr.Hoca_ID;
                            rpr.Tez_Id = ogr.Tez_ID;
                            rpr.Tarih_Id = Convert.ToInt32(id);
                            rpr.Ad = parcalar[1];
                            rpr.Dosya = ogr.Hoca_ID + "" + ogr.Tez_ID + "" + rpr.Tarih_Id;
                            db.Rapor.Add(rpr);
                            db.SaveChanges();
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Kaydedildi');</script>");
                        }
                        else
                        {
                            File.Delete(Server.MapPath("~/Raporlar/")+ ogr.Hoca_ID + ogr.Tez_ID + id + "." + kontrol.Ad);
                            myFile.SaveAs(Server.MapPath("~/Raporlar/") + ogr.Hoca_ID + ogr.Tez_ID + id + "." + parcalar[1]);
                            kontrol.Hoca_Id = ogr.Hoca_ID;
                            kontrol.Tez_Id = ogr.Tez_ID;
                            kontrol.Tarih_Id = Convert.ToInt32(id);
                            kontrol.Ad = parcalar[1];
                            kontrol.Dosya = ogr.Hoca_ID + "" + ogr.Tez_ID + "" + idi;
                            db.SaveChanges();
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Kaydedildi');</script>");
                        }
                       
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('uzantı hatası');</script>");
                    }
                   
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Hata');</script>");
                }
                break;
        }
    }
}

