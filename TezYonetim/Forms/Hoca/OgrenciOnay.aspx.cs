using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

public partial class Admin : TezBase
{
    TezFonk fnk;
    TezDBEntities db;
    Ogrenci Ogrenci;
    protected void Page_Load(object sender, EventArgs e)
    {
        fnk = new TezFonk();
        db = new TezDBEntities();
       
        var Ogrdb = db.Ogrenci.Where(t => t.Hoca_ID == AppKontrol.id).ToList();

        if (!IsPostBack)
        {
           
                Repeater1.DataSource = Ogrdb;
                Repeater1.DataBind();
           

        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string id;
        int ogid;
        switch (e.CommandName)
        {

            case "Sil":
                id = e.CommandArgument.ToString();
                ogid = Convert.ToInt32(id);
                Ogrenci = db.Ogrenci.Where(o => o.Id == ogid).FirstOrDefault();
                Ogrenci.Hoca_ID = null;
                db.SaveChanges();
                Repeater1.DataBind();

                break;
        }

    }
    protected void LogOut_Click(object sender, EventArgs e)
    {
        Response.Cookies["MyCookie"].Expires = DateTime.Now.AddDays(-1);
        Session.RemoveAll();
        Response.Redirect(@"~/Default.aspx");
    }
}