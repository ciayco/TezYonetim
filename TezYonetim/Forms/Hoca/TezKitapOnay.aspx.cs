using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Net;

public partial class Admin : TezBase
{
    TezDBEntities db;
    Tez_Kitap kitap;

    protected void Page_Load(object sender, EventArgs e)
    {
        db = new TezDBEntities();

        var tezkitap = db.Tez_Kitap.Where(t => t.Hoca_id == AppKontrol.id && t.Durum == 1).ToList();

        if (tezkitap.Count == 0)
        {
            tablo.Visible = false;
            label.Visible = true;
            Label2.Text = "Onay Bekleyen Tez Kitabı Bulunmamaktadır.!";
        }
        else
        {
            if (!IsPostBack)
            {
                Repeater1.DataSource = tezkitap;
                Repeater1.DataBind();

            }
        }

    }
    public string metin_kisalt_yan(string id)
    {
        string metin;
        int idi = Convert.ToInt32(id);
        var kitap = db.Tez_Kitap.Find(idi);
        var tez = db.Tez.Where(o => o.Id == kitap.Tez_id).FirstOrDefault();
        metin = tez.Konu;
        return metin;

    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Label1.Text = "Konu  : ";
        Label5.Text = "<br/>";
        string id;
        int ogid;
        switch (e.CommandName)
        {
            case "Red":
                id = e.CommandArgument.ToString();
                ogid = Convert.ToInt32(id);
                kitap = db.Tez_Kitap.Where(o => o.Id == ogid).FirstOrDefault();
                kitap.Durum = 2;//onaylanmadı
                db.SaveChanges();
                Response.Redirect(@"~/Forms/Hoca/TezKitapOnay.aspx");
                break;
            case "Onay":
                id = e.CommandArgument.ToString();
                ogid = Convert.ToInt32(id);
                kitap = db.Tez_Kitap.Where(o => o.Id == ogid).FirstOrDefault();
                kitap.Durum = 3;//onaylandı
                db.SaveChanges();
                Response.Redirect(@"~/Forms/Hoca/TezKitapOnay.aspx");
                break;
            case "incele":
                id = e.CommandArgument.ToString();
                ogid = Convert.ToInt32(id);
                kitap = db.Tez_Kitap.Where(o => o.Id == ogid).FirstOrDefault();
                string navigateURL = "../../../TezKitaplar/" + kitap.Dosya_ad + "." + kitap.Dosya_Uzanti;
                string windowProperties = "status=no, menubar=yes, toolbar=yes";
                string scriptText = "window.open('" + navigateURL + "','" + windowProperties + "')";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "eşsizAnahtar", scriptText, true);

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