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
    Tez Tez;
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new TezDBEntities();

        var Ogrdb = db.Ogrenci.Where(t => t.Hoca_ID == AppKontrol.id && t.Tez_ID != null || t.Tez_Onay == false).ToList();

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

            case "Red":
                id = e.CommandArgument.ToString();
                ogid = Convert.ToInt32(id);
                Ogrenci = db.Ogrenci.Where(o => o.Id == ogid).FirstOrDefault();
                Ogrenci.Tez_ID = null;
                Ogrenci.Tez_Onay = false;
                db.SaveChanges();
                Repeater1.DataBind();
                break;

            case "Onay":
                id = e.CommandArgument.ToString();
                ogid = Convert.ToInt32(id);
                Ogrenci = db.Ogrenci.Where(o => o.Id == ogid).FirstOrDefault();
                Ogrenci.Tez_Onay = true;
                Tez = db.Tez.Where(oo => oo.Id == Ogrenci.Tez_ID).FirstOrDefault();
                //Tezdeki boş yer kontrolü
                if (Tez.Og_ID != null)
                {
                    Tez.Og_ID = ogid;
                }
                else if (Tez.Og2_ID != null)
                {
                    Tez.Og2_ID = ogid;
                }
                else
                {
                    //Uyarı
                }
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