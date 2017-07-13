using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Admin_İndex : TezBaseAdmin
{
    TezDBEntities db = new TezDBEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        var admin = db.Admin.Where(w => w.Id == AppKontrol.id).FirstOrDefault();

        Label1.Text = "Sistem Yöneticisi";
        Label2.Text = admin.KullanıcıAdi;
        Label3.Text = "Bilgisayar Mühendisliği";
        Label4.Text = admin.Mail;
    }

    protected void Password_Click(object sender, EventArgs e)
    {
        if (Password.Text != "" && Password1.Text != "" && Password2.Text != "")
        {
            var guncelKayit = db.Admin.Find(AppKontrol.id);
            string pass = Sifreleme.Sifrele(Password.Text);
            if (pass == guncelKayit.Sifre && Password1.Text == Password2.Text)
            {
                guncelKayit.Sifre = Sifreleme.Sifrele(Password1.Text);
                db.SaveChanges();
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Şifreniz başarıyla güncellendi');</script>");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Yanlış Bilgi Girişi Yapıldı');</script>");
            }
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Boş Geçilemez');</script>");
        }
    }
}