using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Admin_AdminEkle : TezBaseAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGiris_Click(object sender, EventArgs e)
    {
        TezDBEntities db = new TezDBEntities();

        string sifrem = Sifreleme.Sifrele(Request["Sifre"].Trim());
        string mail = Request["E-mail"].Trim();
        if (Request["Name"].Trim() == "" || Request["Sifre"].Trim() == "" || Request["E-mail"].Trim() == "")
        {
            LabelSignUP.Text = "Lütfen Boş Geçmeyiniz";
        }
        else
        {
            if (db.Admin.Where(w => w.Mail == mail).Any())
            {
                LabelSignUP.Text = "Bu Kullanıcı Sistemde Mevcut";
            }
            else
            {
                Admin admin = new Admin();

                admin.KullanıcıAdi = Request["Name"].Trim();
                admin.Sifre = sifrem;
                admin.Mail = Request["E-mail"].Trim();
                admin.Derece = 0;
                db.Admin.Add(admin);
                db.SaveChanges();
                Response.Redirect(@"~/Forms/Admin/AdminEkle.aspx");
            }

        }
    }
}