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
        var Ogrenci = db.Ogrenci.ToList();
        if (Session["Id"] != null)
        {
            if ((int)Session["derece"] == 2) //2 veritabanında Admin demek
            {
                Response.Redirect(@"~/Forms/Ogrenci/User.aspx");
            }
        }
        else
        {
            if (Request.Cookies["MyCookie"] != null)
            {
                string No = Request.Cookies["MyCookie"]["No"];
                string sifre = Request.Cookies["MyCookie"]["sifre"];
                Ogrenci ogrenci = db.Ogrenci.Where(u => u.No == No && u.Sifre == sifre).FirstOrDefault();
                if (ogrenci != null)
                {
                    AppKontrol.id = ogrenci.Id;
                    AppKontrol.name = ogrenci.Ad;
                    AppKontrol.derece = Convert.ToInt32(ogrenci.Derece);
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