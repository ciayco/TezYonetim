using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

public partial class Admin : TezBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TezDBEntities db = new TezDBEntities();
        var Ogrenci = db.Ogrenci.ToList();
        Label1.Text = Session["name"].ToString();
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

    protected void ListeleClick(object sender, EventArgs e)
    {

    }
}