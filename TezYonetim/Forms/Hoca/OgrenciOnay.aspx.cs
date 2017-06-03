using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

public partial class Admin : TezBase
{
   
    TezDBEntities db;
    Ogrenci Ogrenci;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        db = new TezDBEntities();
       
        var Ogrdb = db.Ogrenci.Where(t => t.Hoca_ID == AppKontrol.id && t.Hoca_Onay==false).ToList();

        if (!IsPostBack)
        {
            if (Ogrdb.Count>0)
            {
                labeldiv.Visible = false;
                Repeater1.DataSource = Ogrdb;
                Repeater1.DataBind();
            }
            else
            {
                repeaterdiv.Visible = false;
                labeldiv.Visible = true;
                Label1.Text = "Onay bekleyen Öğrenci bulunmamaktadır.!";
            }
                         
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string id;
        int ogid;
        switch (e.CommandName)
        {

            case "Red":
                id = e.CommandArgument.ToString();
                ogid = Convert.ToInt32(id);
                Ogrenci = db.Ogrenci.Where(o => o.Id == ogid).FirstOrDefault();
                Ogrenci.Hoca_ID = null;
                Ogrenci.Hoca_Onay = false;
                db.SaveChanges();
                Repeater1.DataBind();
                Response.Redirect(@"~/Forms/Hoca/OgrenciOnay.aspx");
                break;

            case "Sec":
                id = e.CommandArgument.ToString();
                ogid = Convert.ToInt32(id);
                Ogrenci = db.Ogrenci.Where(o => o.Id == ogid).FirstOrDefault();
                Ogrenci.Hoca_ID = AppKontrol.id;
                Ogrenci.Hoca_Onay = true;
                db.SaveChanges();
                Repeater1.DataBind();
                Response.Redirect(@"~/Forms/Hoca/OgrenciOnay.aspx");
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