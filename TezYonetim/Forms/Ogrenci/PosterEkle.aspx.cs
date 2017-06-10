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
        var ogr = db.Ogrenci.Find(AppKontrol.id);
        var kontrol = db.Tez.Where(o => o.Id == ogr.Tez_ID).FirstOrDefault();
        if (kontrol.ResimDurum == 3)
        {
            onay.Visible = true;
            bekleme.Visible = false;
            DurumOnay1.Text = "Tez Poster Durumunuz ";
            DurumOnay.Text = "Onaylandı";
        }
        else if (kontrol.ResimDurum == 2)
        {
            onay.Visible = false;
            bekleme.Visible = true;
            DurumBekleme1.Text = "Tez Poster Durumunuz ";
            DurumBekleme.Text = "Onaylanmadı";
        }
        else
        {
            onay.Visible = false;
            bekleme.Visible = true;
            DurumBekleme1.Text = "Tez Poster Durumunuz ";
            DurumBekleme.Text = "Onay Beklemede";
        }
    }
    protected void PosterEkle_Click(object sender, EventArgs e)
    {
        var ogrenci = db.Ogrenci.Where(w=>w.Id == AppKontrol.id && w.Hoca_ID != null && w.Hoca_Onay == true && w.Tez_ID != null && w.Tez_Onay == true ).FirstOrDefault();
        var poster = db.Tez.Where(o => o.Id == ogrenci.Tez_ID).FirstOrDefault();
        var kontrol = db.Tez.Where(o => o.Id == ogrenci.Tez_ID && o.ResimDurum==3).FirstOrDefault();
        HttpPostedFile myFile = filMyFile.PostedFile;
        if (myFile.ContentLength > 0)
        {
            string[] parcalar = myFile.FileName.Split('.');
            if (parcalar[1] == "jpg" || parcalar[1] == "jpeg" || parcalar[1] == "png" || parcalar[1] == "JPG" || parcalar[1] == "PNG" || parcalar[1] == "JPEG")
            {
                
                if (poster != null)
                {
                    if (kontrol==null)
                    {
                        myFile.SaveAs(Server.MapPath("~/Posterler/") + ogrenci.Hoca_ID + ogrenci.Tez_ID + "." + parcalar[1]);
                        poster.ResimUzanti = parcalar[1];
                        poster.ResimAd = ogrenci.Hoca_ID + "" + ogrenci.Tez_ID;
                        poster.ResimDurum = 1;
                        db.SaveChanges();
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Kaydedildi');</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Onaylanmış poster için tekrar yükleme yapılmaz');</script>");
                    }
                    
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Tez Bulunmadı');</script>");
                }
            }else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('uzantı hatası');</script>");
            }
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Dosya Seçiniz');</script>");
        }
    }
}