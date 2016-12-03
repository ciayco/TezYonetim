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
                TextBox2.Text = guncelKayit.name;
                TextBox3.Text = guncelKayit.sifre;
                TextBox4.Text = guncelKayit.e_mail;
                TextBox5.Text = guncelKayit.bolum;

            }
        
       
    }
    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        TezDBEntities db = new TezDBEntities();
        int id = int.Parse(Request.QueryString["Id"]);
        var guncelKayit = db.Ogrenci.Find(id);
        guncelKayit.No = TextBox1.Text;
        guncelKayit.name = TextBox2.Text;
        guncelKayit.sifre = TextBox3.Text;
        guncelKayit.e_mail = TextBox4.Text;
        guncelKayit.bolum = TextBox5.Text;
        db.SaveChanges();
        Response.Redirect(@"~/Admin.aspx");
    }
}