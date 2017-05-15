using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Hoca_TezListele : TezBase
{
    TezDBEntities db;
    Ogrenci Ogrenci;
    Tez Tez;
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new TezDBEntities();
        var Ogrdb = db.Tez.Where(t => t.Hoca_ID == AppKontrol.id).ToList();
        if (!IsPostBack)
        {
            Repeater1.DataSource = Ogrdb;
            Repeater1.DataBind();
        }
    }
    public string metin_kisalt_yan(string metin)

    {
        if (metin.Length > 50)
        {
            metin = metin.Substring(0, 50);

            metin = metin + "...";
        }

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
                Tez = db.Tez.Where(o => o.Id == ogid).FirstOrDefault();
                db.Tez.Remove(Tez);
                db.SaveChanges();
                Repeater1.DataBind();
                Response.Redirect(@"~/Forms/Hoca/TezListele.aspx");
                break;
            case "incele":
                id = e.CommandArgument.ToString();
                ogid = Convert.ToInt32(id);
                var hoca = db.Hoca.Where(w => w.Id == AppKontrol.id).FirstOrDefault();
                Tez = db.Tez.Where(oo => oo.Id == ogid).FirstOrDefault();
                Label1.Text += Tez.Konu;
                Label3.Text = hoca.Ad;
                Label5.Text = Label5.Text + Tez.Aciklama;
                var tezalan = db.Ogrenci.Where(oo => oo.Tez_ID == ogid).ToList();
                Repeater2.DataSource = tezalan;
                Repeater2.DataBind();
                Page.ClientScript.RegisterStartupScript(GetType(), "modelBox", "$('.modal').modal()", true);
                break;
        }
    }
}