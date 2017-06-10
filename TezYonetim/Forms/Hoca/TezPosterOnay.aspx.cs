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
    Tez tez;

    protected void Page_Load(object sender, EventArgs e)
    {
        db = new TezDBEntities();

        var tezkitap = db.Tez.Where(t => t.Hoca_ID == AppKontrol.id && t.ResimDurum == 1 && t.ResimAd != "bosimg").ToList();

        if (tezkitap.Count == 0)
        {
            tablo.Visible = false;
            label.Visible = true;
            Label2.Text = "Onay Bekleyen Tez Posteri Bulunmamaktadır.!";
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

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string id;
        int ogid;
        switch (e.CommandName)
        {
            case "Red":
                id = e.CommandArgument.ToString();
                ogid = Convert.ToInt32(id);
                tez = db.Tez.Where(o => o.Id == ogid).FirstOrDefault();
                tez.ResimDurum = 2;//onaylanmadı
                db.SaveChanges();
                Response.Redirect(@"~/Forms/Hoca/TezPosterOnay.aspx");
                break;
            case "Onay":
                id = e.CommandArgument.ToString();
                ogid = Convert.ToInt32(id);
                tez = db.Tez.Where(o => o.Id == ogid).FirstOrDefault();
                tez.ResimDurum = 3;//onaylandı
                db.SaveChanges();
                Response.Redirect(@"~/Forms/Hoca/TezPosterOnay.aspx");
                break;
        }

    }
    protected void ImageButton1_Command(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "poster":
                int id = int.Parse(e.CommandArgument.ToString());
                var poster = db.Tez.Find(id);
                if (poster.ResimAd != "bosimg")
                {
                    posterDiv.Visible = true;
                    posterLabel.Visible = false;
                    posterimage.ImageUrl = "~/Posterler/" + poster.ResimAd + "." + poster.ResimUzanti;
                    Page.ClientScript.RegisterStartupScript(GetType(), "none", "$('#postermodal').modal()", true);
                }
                else
                {
                    posterDiv.Visible = false;
                    posterLabel.Visible = true;
                    labelPoster.Text = "Sisteme Tez Afişi Yüklenmemiş.!";
                    Page.ClientScript.RegisterStartupScript(GetType(), "none", "$('#postermodal').modal()", true);
                }

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