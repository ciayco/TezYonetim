using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Duzenle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
            if (!Page.IsPostBack)
            {
                TezDBEntities db = new TezDBEntities();
                int idd = int.Parse(Request.QueryString["Id"]);
                var guncelKayit = db.Ogrenci.Find(idd);
                TextBox1.Text = guncelKayit.No;
                TextBox2.Text = guncelKayit.Ad;
                TextBox3.Text = guncelKayit.Sifre;
                TextBox4.Text = guncelKayit.Mail;
                TextBox5.Text = guncelKayit.Bolum;

        }


    }
    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        TezDBEntities db = new TezDBEntities();
        int id = (int)Session["id"];
        var guncelKayit = db.Ogrenci.Find(id);
        guncelKayit.No = TextBox1.Text;
        guncelKayit.Ad = TextBox2.Text;
        guncelKayit.Soyad = TextBox6.Text;
        guncelKayit.Sifre = TextBox3.Text;
        guncelKayit.Mail = TextBox4.Text;
        guncelKayit.Bolum = TextBox5.Text;
        db.SaveChanges();
        Response.Redirect(@"~/Admin.aspx");
    }
}