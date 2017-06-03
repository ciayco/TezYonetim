using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class TezBaseAdmin : System.Web.UI.Page
{
    public TezBaseAdmin()
    {
    }
    protected override void OnInit(EventArgs e)
    {
        TezDBEntities db = new TezDBEntities();
        var Admin = db.Admin.ToList();
        if (Session["Id"] != null)
        {
            if ((int)Session["derece"] == 1) //0 veritabanında Admin demek
            {
                Response.Redirect(@"~/Forms/Hoca/index.aspx");
            }
            if ((int)Session["derece"] == 2)
            {
                Response.Redirect(@"~/Forms/Ogrenci/index.aspx");
            }
        }
        else
        {
            if (Request.Cookies["MyCookie"] != null)
            {
                string No = Request.Cookies["MyCookie"]["No"];
                string sifre = Request.Cookies["MyCookie"]["sifre"];
                Admin admin = db.Admin.Where(u => u.Mail == No && u.Sifre == sifre).FirstOrDefault();
                if (admin != null)
                {
                    AppKontrol.id = admin.Id;
                    AppKontrol.name = admin.KullanıcıAdi;
                    AppKontrol.derece = Convert.ToInt32(admin.Derece);
                    Response.Redirect(@"~/Default.aspx");
                }
            }
            else
            {
                Response.Redirect(@"~/Default.aspx");
            }
        }
        base.OnInit(e);
    }
}