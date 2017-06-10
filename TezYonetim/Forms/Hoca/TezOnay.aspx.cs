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

        var Ogrdb = db.Ogrenci.Where(t => t.Hoca_ID == AppKontrol.id && t.Tez_ID != null && t.Tez_Onay != true).ToList();

        if (Ogrdb.Count == 0)
        {
            tablo.Visible = false;
            label.Visible = true;
            Label2.Text = "Onay Bekleyen Tez Bulunmamaktadır.!";
        }
        else
        {
            if (!IsPostBack)
            {
                Repeater1.DataSource = Ogrdb;
                Repeater1.DataBind();

            }
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Label1.Text = "Konu  : ";
        Label5.Text = "<br/>";
        string id;
        int ogid;
        switch (e.CommandName)
        {
            case "incele":
                id = e.CommandArgument.ToString();
                ogid = Convert.ToInt32(id);
                Ogrenci = db.Ogrenci.Where(o => o.Id == ogid).FirstOrDefault();
                Tez = db.Tez.Where(oo => oo.Id == Ogrenci.Tez_ID).FirstOrDefault();
                Label1.Text += Tez.Konu;
                Label3.Text = Ogrenci.Ad;
                Label5.Text = Label5.Text + Tez.Aciklama;
                Page.ClientScript.RegisterStartupScript(GetType(), "modelBox", "$('.modal').modal()", true);
                break;
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
                Tez = db.Tez.Where(oo => oo.Id == Ogrenci.Tez_ID).FirstOrDefault();
                //Tezdeki boş yer kontrolü
                if (Tez.Tez_Alan < Tez.Tez_Limit)
                {
                    Ogrenci.Tez_Onay = true;
                    Tez.Tez_Alan += 1;
                    db.SaveChanges();
                    Response.Redirect(@"~/Forms/Hoca/TezOnay.aspx");
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