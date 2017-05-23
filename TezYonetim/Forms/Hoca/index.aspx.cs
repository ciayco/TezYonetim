using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : TezBase
{
    TezDBEntities db;
    string a;
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new TezDBEntities();
        var hoca = db.Hoca.Where(w => w.Id == AppKontrol.id).FirstOrDefault();
     
        Label1.Text = "Tez Danışmanı";
        Label2.Text = hoca.Ad;
        Label3.Text = "Bilgisayar Mühendisliği";
        Label4.Text = hoca.Mail;
        var Duyurular = db.Duyuru_Admin.ToList();
        Repeater1.DataSource = Duyurular;
        Repeater1.DataBind();
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
                var duyuru = db.Duyuru_Admin.Where(o => o.Id == did).FirstOrDefault();

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
    protected void Password_Click(object sender, EventArgs e)
    {
        if (Password.Text != null && Password1.Text != null && Password2.Text != null)
        {
            var guncelKayit = db.Hoca.Find(AppKontrol.id);
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
    protected void LogOut_Click(object sender, EventArgs e)
    {
        Response.Cookies["MyCookie"].Expires = DateTime.Now.AddDays(-1);
        Session.RemoveAll();
        Response.Redirect(@"~/Default.aspx");
    }
}
