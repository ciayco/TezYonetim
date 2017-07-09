using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Hoca_RaporListele : TezBase
{
    static int kontrol = 1;
    TezDBEntities db = new TezDBEntities();
    string idg1, idg2;
    int tezid, rprid, i;
    public int sayac = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        var tezler = db.Tez.Where(o => o.Hoca_ID == AppKontrol.id && o.Tez_Alan > 0).ToList();
        if (tezler.Count > 0)
        {
            goster.Visible = true;
            gosterme.Visible = false;
            Repeater1.DataSource = tezler;
            Repeater1.DataBind();
        }
        else
        {
            goster.Visible = false;
            gosterme.Visible = true;
            lbgosterme.Text = "Görüntülenecek Rapor Bulunamadı!!";
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
    protected void Goster_Click(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Goruntule":
                i = 0;
                kontrol = 2;
                TezOgrLbl.Text = "";
                idg1 = e.CommandArgument.ToString();
                tezid = Convert.ToInt32(idg1);
                Session["tezid"] = tezid;
                var raportrh = db.Rapor_Tarih.Where(o => o.Hoca_Id == 2 && o.tur == 1).ToList();
                var ogrenci = db.Ogrenci.Where(o => o.Tez_ID == tezid).ToList();
                while (i < ogrenci.Count())
                {
                    TezOgrLbl.Text = TezOgrLbl.Text + ogrenci[i].Ad + " ";
                    i++;
                }
                if (raportrh != null)
                {
                    Repeater2.DataSource = raportrh;
                    Repeater2.DataBind();

                    Page.ClientScript.RegisterStartupScript(GetType(), "modelBox", "$('.modal').modal()", true);

                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Görüntülenecek Rapor Bulunamadı');</script>");
                }
                break;
            case "Goruntulevize":
                i = 0;
                kontrol = 3;
                TezOgrLbl.Text = "";
                idg1 = e.CommandArgument.ToString();
                tezid = Convert.ToInt32(idg1);
                Session["tezid"] = tezid;
                var raporvizetrh = db.Rapor_Tarih.Where(o => o.Hoca_Id == 2 && o.tur == 2).ToList();
                var ogr = db.Ogrenci.Where(o => o.Tez_ID == tezid).ToList();
                while (i < ogr.Count())
                {
                    TezOgrLbl.Text = TezOgrLbl.Text + ogr[i].Ad + " ";
                    i++;
                }
                if (raporvizetrh != null)
                {
                    Repeater2.DataSource = raporvizetrh;
                    Repeater2.DataBind();
                    Page.ClientScript.RegisterStartupScript(GetType(), "modelBox", "$('.modal').modal()", true);

                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Görüntülenecek Rapor Bulunamadı');</script>");
                }
                break;
            case "Goruntulefinal":
                i = 0;
                kontrol = 4;
                TezOgrLbl.Text = "";
                idg1 = e.CommandArgument.ToString();
                tezid = Convert.ToInt32(idg1);
                Session["tezid"] = tezid;
                var raporfinaltrh = db.Rapor_Tarih.Where(o => o.Hoca_Id == 2 && o.tur == 3).ToList();
                var ogrfinal = db.Ogrenci.Where(o => o.Tez_ID == tezid).ToList();
                while (i < ogrfinal.Count())
                {
                    TezOgrLbl.Text = TezOgrLbl.Text + ogrfinal[i].Ad + " ";
                    i++;
                }
                if (raporfinaltrh != null)
                {
                    Repeater2.DataSource = raporfinaltrh;
                    Repeater2.DataBind();
                    Page.ClientScript.RegisterStartupScript(GetType(), "modelBox", "$('.modal').modal()", true);

                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Görüntülenecek Rapor Bulunamadı');</script>");
                }
                break;
        }
    }
    protected void RaporGoruntule(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Goruntule":
                idg2 = e.CommandArgument.ToString();
                rprid = Convert.ToInt32(idg2);
                string tezidi = Session["tezid"].ToString();
                Session.Remove("tezid");
                int id = Convert.ToInt32(tezidi);
                var rapor = db.Rapor.Where(o => o.Tarih_Id == rprid && o.Tez_Id == id).FirstOrDefault();
                if (rapor != null)
                {
                    string navigateURL = "../../../Raporlar/" + rapor.Dosya + "." + rapor.Ad;
                    string target = "_blank";
                    string windowProperties = "status=no, menubar=yes, toolbar=yes";
                    string scriptText = "window.open('" + navigateURL + "','" + target + "','" + windowProperties + "')";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "eşsizAnahtar", scriptText, true);
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "Başlık", "<script>alert('Görüntülenecek Rapor Bulunamadı');</script>");
                }
                break;
        }
    }

    protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblUserId = (Label)e.Item.FindControl("lblrapor");
            Button btn = (Button)e.Item.FindControl("goruntule");

            if (kontrol == 2)
            {
                lblUserId.Text = "Rapor ";
            }
            if (kontrol == 3)
            {
                lblUserId.Text = "Vize Rapor ";
            }
            if (kontrol == 4)
            {
                lblUserId.Text = "Final Rapor ";
            }
        }
    }
}