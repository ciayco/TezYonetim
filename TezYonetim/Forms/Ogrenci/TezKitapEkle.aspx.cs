using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Ogrenci_PosterEkle : TezBaseUser
{
    TezDBEntities db = new TezDBEntities();
    Tez_Kitap rpr = new Tez_Kitap();
    protected void Page_Load(object sender, EventArgs e)
    {
        var ogr = db.Ogrenci.Find(AppKontrol.id);
        var kontrol = db.Tez_Kitap.Where(o => o.Hoca_id == ogr.Hoca_ID && o.Tez_id == ogr.Tez_ID && o.Ogr_id == AppKontrol.id).FirstOrDefault();
        if (kontrol != null)
        {
            if (kontrol.Durum == 3)
            {
                onay.Visible = true;
                bekleme.Visible = false;
                DurumOnay1.Text = "Tez Kitap Durumunuz ";
                DurumOnay.Text = "Onaylandı";
            }
            else if (kontrol.Durum == 2)
            {
                onay.Visible = false;
                bekleme.Visible = true;
                DurumBekleme1.Text = "Tez Kitap Durumunuz ";
                DurumBekleme.Text = "Onaylanmadı";
            }
            else
            {
                onay.Visible = false;
                bekleme.Visible = true;
                DurumBekleme1.Text = "Tez Kitap Durumunuz ";
                DurumBekleme.Text = "Onay Beklemede";
            }
        }
        else
        {
            onay.Visible = false;
            bekleme.Visible = true;
            DurumBekleme1.Text = "Tez Kitap Durumunuz ";
            DurumBekleme.Text = "Bulunmamaktadır";
        }
       
        
            
    }
    protected void TezKitapEkle_Click(object sender, EventArgs e)
    {
        var ogr = db.Ogrenci.Where(w => w.Id == AppKontrol.id && w.Hoca_ID != null && w.Hoca_Onay == true && w.Tez_ID != null && w.Tez_Onay == true).FirstOrDefault();
        var tezkitap = db.Tez_Kitap.Where(o => o.Hoca_id == ogr.Hoca_ID && o.Tez_id == ogr.Tez_ID && o.Ogr_id == AppKontrol.id).FirstOrDefault();
        var kontrol = db.Tez_Kitap.Where(o => o.Hoca_id == ogr.Hoca_ID && o.Tez_id == ogr.Tez_ID && o.Ogr_id == AppKontrol.id && o.Durum == 3).FirstOrDefault();
        HttpPostedFile myFile = filMyFile.PostedFile;
      
            if (myFile.ContentLength > 0)
            {
                string[] parcalar = myFile.FileName.Split('.');//.dan sonrakı uzantıyı parcalar[1] içine atar 

                if (parcalar[1] == "doc" || parcalar[1] == "docx" || parcalar[1] == "DOC" || parcalar[1] == "DOCX")
                {
                if (tezkitap == null)
                {
                    myFile.SaveAs(Server.MapPath("~/TezKitaplar/") + ogr.Hoca_ID + ogr.Tez_ID + AppKontrol.id + "." + parcalar[1]);
                    rpr.Hoca_id = ogr.Hoca_ID;
                    rpr.Tez_id = ogr.Tez_ID;
                    rpr.Ogr_id = AppKontrol.id;
                    rpr.Dosya_Uzanti = parcalar[1];
                    rpr.Dosya_ad = Convert.ToInt16(ogr.Hoca_ID + "" + ogr.Tez_ID + "" + AppKontrol.id);
                    rpr.Durum = 1;//ilk Eklenme
                    db.Tez_Kitap.Add(rpr);
                    db.SaveChanges();
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Kaydedildi');</script>");
                }
                else
                {
                    if (kontrol==null)
                    {
                        File.Delete(Server.MapPath("~/TezKitaplar/") + ogr.Hoca_ID + ogr.Tez_ID + AppKontrol.id + "." + tezkitap.Dosya_ad);
                        myFile.SaveAs(Server.MapPath("~/TezKitaplar/") + ogr.Hoca_ID + ogr.Tez_ID + AppKontrol.id + "." + parcalar[1]);
                        tezkitap.Hoca_id = ogr.Hoca_ID;
                        tezkitap.Tez_id = ogr.Tez_ID;
                        tezkitap.Ogr_id = AppKontrol.id;
                        tezkitap.Dosya_Uzanti = parcalar[1];
                        tezkitap.Durum = 1;//güncelleme
                        tezkitap.Dosya_ad = Convert.ToInt16(ogr.Hoca_ID +""+ ogr.Tez_ID+"" + AppKontrol.id);
                        db.SaveChanges();
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Kaydedildi');</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Onaylanmış kitap için tekrar yükleme yapılmaz');</script>");
                    }
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
       
        
    }
}