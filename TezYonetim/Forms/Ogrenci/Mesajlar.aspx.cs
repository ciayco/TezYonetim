using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Ogrenci_Mesajlar : System.Web.UI.Page
{
    TezDBEntities db;
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new TezDBEntities();
        var Mesajlar = db.Mesaj.Where(w => w.Aid == AppKontrol.id && w.ADerece == AppKontrol.derece).ToList();
        if (Mesajlar.Count > 0)
        {
            Repeater2.DataSource = Mesajlar;
            Repeater2.DataBind();
            dolumsg.Visible = true;
            bosmsg.Visible = false;
        }
        else
        {
            bosmsg.Visible = true;
            dolumsg.Visible = false;
            Label5.Text = "Gelen Kutusu Boş";
        }
    }
    public string metin_kisalt_sol(string metin)
    {
        if (metin.Length > 30)
        {
            metin = metin.Substring(0, 30);
            metin = metin + "...";
        }
        return metin;
    }
    public string metin_kisalt_sag(string metin)
    {
        if (metin.Length > 50)
        {
            metin = metin.Substring(0, 50);
            metin = metin + "...";
        }
        return metin;
    }
}