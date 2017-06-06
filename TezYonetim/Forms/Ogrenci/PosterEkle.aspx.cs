using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Ogrenci_PosterEkle : TezBaseUser
{
    TezDBEntities db = new TezDBEntities();
   
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void PosterEkle_Click(object sender, EventArgs e)
    {
        var ogrenci = db.Ogrenci.Where(w=>w.Id == AppKontrol.id && w.Hoca_ID != null && w.Hoca_Onay == true && w.Tez_ID != null && w.Tez_Onay == true ).FirstOrDefault();
        var poster = db.Tez.Where(o => o.Id == ogrenci.Tez_ID).FirstOrDefault();
        HttpPostedFile myFile = filMyFile.PostedFile;
        if (myFile.ContentLength > 0)
        {
            string[] parcalar = myFile.FileName.Split('.');
            if (poster != null)
            {
                myFile.SaveAs(Server.MapPath("~/Posterler/") + ogrenci.Hoca_ID + ogrenci.Tez_ID + "." + parcalar[1]);
                poster.ResimUzanti = parcalar[1];
                poster.ResimAd= ogrenci.Hoca_ID +""+ ogrenci.Tez_ID;
                db.SaveChanges();
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Kaydedildi');</script>");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Tez Bulunmadı');</script>");
            }
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Dosya Seçiniz');</script>");
        }
    }
}