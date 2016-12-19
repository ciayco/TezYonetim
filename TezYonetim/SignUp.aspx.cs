using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

public partial class SignUp : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGiris_Click(object sender, EventArgs e)
    {
        TezDBEntities db = new TezDBEntities();
        Ogrenci ogrenci = new Ogrenci();
        string sifrem=Sifreleme.Sifrele(Request["Sifre"].Trim());
        try
        {
            ogrenci.No = Request["No"].Trim();
            ogrenci.Ad = Request["Name"].Trim();
            ogrenci.Sifre =sifrem;
            ogrenci.Mail = Request["E-mail"].Trim();
            ogrenci.Bolum = Request["Bolum"].Trim();
            ogrenci.Derece = 2;
            db.Ogrenci.Add(ogrenci);
            db.SaveChanges();
            Response.Redirect(@"~/Default.aspx");

        }
        catch
        {
            Response.Write("<script LANGUAGE='JavaScript' >alert('mesaj')</script>");
        }
       

    }
}