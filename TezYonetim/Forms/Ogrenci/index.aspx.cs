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

        if (Ogrenci.Hoca_Onay != true && Ogrenci.Hoca_ID == null)
        {
            Label7.Text = "Seçilmemiş";
        }
        else if (Ogrenci.Hoca_Onay == false && Ogrenci.Hoca_ID != null)
        {
            Label7.Text = "Onay Beklemede";
        }
        else
        {
            Label7.Text = hoca.Ad;
        }
        Label4.Text = Ogrenci.No;
        if (Ogrenci.Tez_Onay == null)
        {
            Label5.Text = "Tez Almamış";
        }
        else if (Ogrenci.Tez_Onay == true)
        {
            Label5.Text = "Onaylandı";
        }
        else
        {
            Label5.Text = "Onay Bekliyor";
        }
        Label6.Text = Ogrenci.Mail;

        var Duyurular = db.Duyuru.Where(w => w.Hoca_Id == Ogrenci.Hoca_ID && Ogrenci.Hoca_Onay == true).ToList();
        Repeater1.DataSource = Duyurular;
        Repeater1.DataBind();

        var Mesajlar = db.Mesaj.Where(w => w.Aid == AppKontrol.id && w.ADerece == AppKontrol.derece).ToList();
        Repeater2.DataSource = Mesajlar;
        Repeater2.DataBind();
    }

    protected void LogOut_Click(object sender, EventArgs e)
    {
        Response.Cookies["MyCookie"].Expires = DateTime.Now.AddDays(-1);
        Session.RemoveAll();
        Response.Redirect(@"~/Default.aspx");
    }

    public string metin_kisalt_yan(string metin)
    {
        if (metin.Length > 50)
        {
            metin = metin.Substring(0, 50);
            metin = metin + "...";
        }
        return metin;
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

    protected void LinkButton1_Click(object sender, CommandEventArgs e)
    {
        string id;
        int did;
        switch (e.CommandName)
        {
            case "duyuru":
                id = e.CommandArgument.ToString();
                did = Convert.ToInt32(id);
                var duyuru = db.Duyuru.Where(o => o.Id == did).FirstOrDefault();
                if (duyuru != null)
                {
                    Label8.Text = duyuru.Duyuru_Baslik;
                    Label9.Text = duyuru.Duyuru_Text;
                    Page.ClientScript.RegisterStartupScript(GetType(), "none", "$('#exampleModal4').modal()", true);
                }
                else
                {
                    Label9.Text = "Görüntülenecek Duyuru Bulunmamaktadır.!";
                }
                break;
        }
    }
}
