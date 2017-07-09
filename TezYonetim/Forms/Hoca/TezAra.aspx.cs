using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Hoca_TezAra : TezBase
{
    TezDBEntities db;
    Ogrenci Ogrenci;
    Tez Tez;
    List<Tez> Tezlist;
    List<string> KeywordListesi;
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new TezDBEntities();
        Tezlist = new List<Tez>();
        KeywordListesi = new List<string>();
        /*  var Ogrdb1 = db.Tez.Where(t => t.Hoca_ID == AppKontrol.id).ToList();//alınan

        
          if (!IsPostBack)
          {
              Repeater1.DataSource = Ogrdb1;
              Repeater1.DataBind();
          }*/
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
                Page.ClientScript.RegisterStartupScript(GetType(), "none", "$('#exampleModal').modal()", true);
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

    protected void Arama_Click(object sender, EventArgs e)
    {

        var keywordlist = Request["KeywordBox"].Trim();
        int i = 0;
        keywordlist = keywordlist.ToLower();
        KeywordListesi = keywordlist.Split(',').ToList();
       
        var Ogrdb2 = db.Tez.Where(t => t.Hoca_ID == AppKontrol.id).ToList();
        while (KeywordListesi.Count > i)
        {
            Tezlist.AddRange(Ogrdb2.Where(t => t.Hoca_ID == AppKontrol.id && t.keywords.Contains(KeywordListesi[i].ToString())).ToList());
            i++;

        
        }
        Tezlist = Tezlist.Distinct().ToList();

        Repeater1.DataSource = Tezlist;
        Repeater1.DataBind();


    }
}