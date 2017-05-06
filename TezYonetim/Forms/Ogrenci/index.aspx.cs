using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User : TezBaseUser
{
    TezDBEntities db;
    string a;
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new TezDBEntities();
        var Ogrenci = db.Ogrenci.Where(w => w.Id == AppKontrol.id).FirstOrDefault();
        var hoca = db.Hoca.Find(Ogrenci.Hoca_ID);
        Label1.Text = "Tez Öğrencisi";
        Label2.Text = Ogrenci.Ad;
        Label3.Text = Ogrenci.Bolum;
        Label7.Text = hoca.Ad;
        Label4.Text = Ogrenci.No;
        if (Ogrenci.Tez_Onay == null) { Label5.Text = "Tez Almamış"; }
        else if (Ogrenci.Tez_Onay == true) { Label5.Text = "Onaylandı"; }
        else { Label5.Text = "Onay Bekliyor"; }
        Label6.Text = Ogrenci.Mail;
        var Duyurular = db.Duyuru.ToList();
        Repeater1.DataSource = Duyurular;
        Repeater1.DataBind();
    }        

    protected void LogOut_Click(object sender, EventArgs e)
    {
        Response.Cookies["MyCookie"].Expires = DateTime.Now.AddDays(-1);
        Session.RemoveAll();
        Response.Redirect(@"~/Default.aspx");
    }

    protected void Password_Click(object sender, EventArgs e)
    {
        if (Password.Text != null && Password1.Text != null && Password2.Text != null)
        {
            var guncelKayit = db.Ogrenci.Find(AppKontrol.id);
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
