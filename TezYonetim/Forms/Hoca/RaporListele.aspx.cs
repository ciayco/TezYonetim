using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Hoca_RaporListele : TezBase
{
    TezDBEntities db = new TezDBEntities();
    string idg1, idg2;
    int tezid, rprid, i;
    public int sayac = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        var tezler = db.Tez.Where(o => o.Hoca_ID == AppKontrol.id).ToList();
        Repeater1.DataSource = tezler;
        Repeater1.DataBind();
    }
    protected void Goster_Click(object sender, CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Goruntule":
                i = 0;
                TezOgrLbl.Text = "";
                idg1 = e.CommandArgument.ToString();
                tezid = Convert.ToInt32(idg1);
                Session["tezid"] = tezid;
                var raportrh = db.Rapor_Tarih.Where(o => o.Hoca_Id == 2).ToList();
                var ogrenci = db.Ogrenci.Where(o => o.Tez_ID == tezid).ToList();
                while (i < ogrenci.Count())
                {
                    TezOgrLbl.Text = TezOgrLbl.Text + ogrenci[i].Ad + "<br/>";
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
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Görüntülenecek Rapor Bulunamadı');</script>");
                }
                break;
        }
    }

}