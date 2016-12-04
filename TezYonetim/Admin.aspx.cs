using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class Admin : System.Web.UI.Page
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
        }
        else
        {
            if (Request.Cookies["MyCookie"] != null)
            {
                string name = Request.Cookies["MyCookie"]["Id"];
                string No = Request.Cookies["MyCookie"]["No"];
                string Id = Request.Cookies["MyCookie"]["Id"];
                string derece = Request.Cookies["MyCookie"]["No"];
                var deneme = db.Ogrenci.FirstOrDefault(u => u.No == No && u.Ad == name);
                if (deneme != null)
                {
                    AppKontrol.CompanyID = System.Convert.ToInt32(Id);
                    AppKontrol.CompanyDerece = System.Convert.ToInt32(derece);
                }
                else
                {
                    Response.Redirect(@"~/Default.aspx");
                }
            }
            else
            {
                Response.Redirect(@"~/Default.aspx");
            }
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
  
}