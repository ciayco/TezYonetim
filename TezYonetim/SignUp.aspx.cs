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
        
        string sifrem=Sifreleme.Sifrele(Request["Sifre"].Trim());
        string no = Request["No"].Trim();
        if (Request["No"].Trim() == "" || Request["Name"].Trim() == "" || Request["Sifre"].Trim() == "" || Request["E-mail"].Trim() == "" || Request["Bolum"].Trim() == "")
        {
            LabelSignUP.Text = "Lütfen Boş Geçmeyiniz";
        }
        else
        { 
            if (db.Ogrenci.Where(w => w.No == no).Any())
            {
                LabelSignUP.Text = "Bu Kullanıcı Sistemde Mevcut";
            }
            else
            {
                Ogrenci ogrenci = new Ogrenci();

                ogrenci.No = Request["No"].Trim();
                ogrenci.Ad = Request["Name"].Trim();
                ogrenci.Sifre = sifrem;
                ogrenci.Mail = Request["E-mail"].Trim();
                ogrenci.Bolum = Request["Bolum"].Trim();
                ogrenci.durum = true;
                ogrenci.Derece = 2;
                db.Ogrenci.Add(ogrenci);
                db.SaveChanges();
                Response.Redirect(@"~/Default.aspx");
            }
        }
        


    }
}