using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TezBase
/// </summary>
public class TezBase : System.Web.UI.Page
{
    public TezBase()
    {        
    }
    protected override void OnInit(EventArgs e)
    {
        TezDBEntities db = new TezDBEntities();
        var Hoca = db.Hoca.ToList();
        if (Session["Id"] != null)
        {
            if ((int)Session["derece"] == 2) //2 veritabanında öğrenci demek
            {
                Response.Redirect(@"~/Forms/Ogrenci/index.aspx");
            }
            if((int)Session["derece"] == 0)
            {
                Response.Redirect(@"~/Forms/Admin/index.aspx");
            }
        }
       
        else
        {
            if (Request.Cookies["MyCookie"] != null)
            {
                string No = Request.Cookies["MyCookie"]["No"];
                string sifre = Request.Cookies["MyCookie"]["sifre"];
                Hoca hoca = db.Hoca.Where(u => u.Mail == No && u.Sifre == sifre).FirstOrDefault();
                if (hoca != null)
                {
                    AppKontrol.id = hoca.Id;
                    AppKontrol.name = hoca.Ad;
                    AppKontrol.derece = Convert.ToInt32(hoca.Derece);
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