using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Admin_Duzenle : TezBaseAdmin
{
    TezDBEntities db = new TezDBEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["IdD"] != null)
        {
            int id = int.Parse(Request.QueryString["IdD"]);
            var hoca = db.Hoca.Find(id);
            if (hoca != null)
            {
                kullanici.Text = hoca.Ad;
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Sistemde Böyle Bir Kullanıcı Bulunamadı');</script>");
            }
        }
        else if (Request.QueryString["IdO"] != null)
        {
            int id = int.Parse(Request.QueryString["IdO"]);
            var ogr = db.Ogrenci.Find(id);
            if (ogr != null)
            {
                kullanici.Text = ogr.Ad;
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Sistemde Böyle Bir Kullanıcı Bulunamadı');</script>");
            }
        }
        else if (Request.QueryString["IdA"] != null)
        {
            int id = int.Parse(Request.QueryString["IdA"]);
            var admin = db.Admin.Find(id);
            if (admin != null)
            {
                kullanici.Text = admin.KullanıcıAdi;
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Sistemde Böyle Bir Kullanıcı Bulunamadı');</script>");
            }
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Sistemde Böyle Bir Kullanıcı Bulunamadı');</script>");
        }
    }

    protected void btnGiris_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["IdD"] != null)
        {
            int id = int.Parse(Request.QueryString["IdD"]);
            var hoca = db.Hoca.Find(id);
            if (hoca != null)
            {
                if (sifre.Text == sifretekrar.Text)
                {
                    hoca.Sifre = Sifreleme.Sifrele(sifre.Text);
                    db.SaveChanges();
                    Label1.Text = "Şifreniz Başarıyla Değiştirilmiştir.";
                }
                else
                {
                    Label1.Text = "Girilen Şifreler Uyuşmadı";
                }
            }
            else
            {
                Label1.Text = "Sistemde Böyle Bir Kullanıcı Bulunamadı";
            }
        }
       else if (Request.QueryString["IdO"] != null)
        {
            int id = int.Parse(Request.QueryString["IdO"]);
            var ogr = db.Ogrenci.Find(id);
            if (ogr != null)
            {
                if (sifre.Text == sifretekrar.Text)
                {
                    ogr.Sifre = Sifreleme.Sifrele(sifre.Text);
                    db.SaveChanges();
                    Label1.Text = "Şifreniz Başarıyla Değiştirilmiştir.";
                }
                else
                {
                    Label1.Text = "Girilen Şifreler Uyuşmadı";
                }
            }
            else
            {
                Label1.Text = "Sistemde Böyle Bir Kullanıcı Bulunamadı";
            }
        }
        else if (Request.QueryString["IdA"] != null)
        {
            int id = int.Parse(Request.QueryString["IdA"]);
            var admin = db.Admin.Find(id);
            if (admin != null)
            {
                if (sifre.Text == sifretekrar.Text)
                {
                    admin.Sifre = Sifreleme.Sifrele(sifre.Text);
                    db.SaveChanges();
                    Label1.Text = "Şifreniz Başarıyla Değiştirilmiştir.";
                }
                else
                {
                    Label1.Text = "Girilen Şifreler Uyuşmadı";
                }
            }
            else
            {
                Label1.Text = "Sistemde Böyle Bir Kullanıcı Bulunamadı";
            }            
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Sistemde Böyle Bir Kullanıcı Bulunamadı');</script>");
        }
    }
}