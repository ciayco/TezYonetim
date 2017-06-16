using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Hoca_Mesajlar : TezBase
{
    TezDBEntities db;
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new TezDBEntities();
        List<Mesaj> mesajlist = new List<Mesaj>();
        var Mesajlar = db.Mesaj.Where(w => w.Aid == AppKontrol.id && w.ADerece == AppKontrol.derece).ToList();
        if (Mesajlar.Count > 0)
        {
            int limit = Mesajlar.Count();
            int i = Mesajlar.Count();
            for (int x = 0; x < limit; x++)
            {
                mesajlist.Add(Mesajlar[i - 1]);
                i--;
            }
            Repeater2.DataSource = mesajlist;
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