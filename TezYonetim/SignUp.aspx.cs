using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGiris_Click(object sender, EventArgs e)
    {
        // Response.Write("<script LANGUAGE='JavaScript' >alert('mesaj')</script>");
        TezDBEntities db = new TezDBEntities();
        Ogrenci ogrenci = new Ogrenci();
        ogrenci.No= Request["No"].Trim();
        ogrenci.name= Request["Name"].Trim();
        ogrenci.sifre= Request["Sifre"].Trim();
        ogrenci.e_mail= Request["E-mail"].Trim();
        ogrenci.bolum= Request["Bolum"].Trim();
        db.Ogrenci.Add(ogrenci);
        db.SaveChanges();

    }
}