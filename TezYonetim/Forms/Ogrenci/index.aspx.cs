using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User : TezBaseUser
{
    TezDBEntities db;
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new TezDBEntities();
        var Ogrenci = db.Ogrenci.Where(w => w.Id == AppKontrol.id).FirstOrDefault();
        Label1.Text = "Tez Öğrencisi";
        Label2.Text = Ogrenci.Ad;
        Label3.Text = Ogrenci.Bolum;
        Label4.Text = Ogrenci.No;
        if (Ogrenci.Tez_Onay == null) { Label5.Text = "Tez Almamış"; }
        else if (Ogrenci.Tez_Onay == true) { Label5.Text = "Onaylandı"; }
        else { Label5.Text = "Onay Bekliyor"; }        
        Label6.Text = Ogrenci.Mail;
    }        

    protected void LogOut_Click(object sender, EventArgs e)
    {
        Response.Cookies["MyCookie"].Expires = DateTime.Now.AddDays(-1);
        Session.RemoveAll();
        Response.Redirect(@"~/Default.aspx");
    }
}
