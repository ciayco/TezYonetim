using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

public partial class Admin : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TezDBEntities db = new TezDBEntities();
        var Ogrenci = db.Ogrenci.ToList();

        if (Session["Id"] != null)
        {
            if ((int)Session["derece"] == 2) //2 veritabanında öğrenci demek
            {
                Response.Redirect(@"~/User.aspx");
            }
            Label1.Text = Session["name"].ToString();
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
           Response.Redirect(@"~/Default.aspx");   
        }
        Repeater1.DataSource = Ogrenci;
        Repeater1.DataBind();
            if (Request.QueryString["Id"] != null)
            {
                int id = int.Parse(Request.QueryString["Id"]);
                var silKayit = db.Ogrenci.Find(id);
                db.Ogrenci.Remove(silKayit);
                db.SaveChanges();
                Repeater1.DataBind();
                Response.Redirect(@"~/Admin.aspx");
            }
    }
    protected void LogOut_Click(object sender, EventArgs e)
    {
        Response.Cookies["MyCookie"].Expires = DateTime.Now.AddDays(-1);
        Session.RemoveAll();
        Response.Redirect(@"~/Default.aspx");
    } 
}