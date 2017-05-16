using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPageUser : System.Web.UI.MasterPage
{
    TezDBEntities db;
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new TezDBEntities();
        if (Session["id"] == null)
        {
            Response.Redirect(@"~/Default.aspx");
        }
        Label1.Text = Session["name"].ToString();

        Kontrol();
        MesajOnizle();
    }
    protected void LogOut_Click(object sender, EventArgs e)
    {
        Response.Cookies["MyCookie"].Expires = DateTime.Now.AddDays(-1);
        Session.RemoveAll();
        Response.Redirect(@"~/Default.aspx");
    }
    public string metin_kisalt_yan(string metin)

    {
        if (metin.Length > 20)
        {
            metin = metin.Substring(0, 20);

            metin = metin + "...";
        }

        return metin;

    }
    protected void Kontrol()
    {
        DateTime tarih = DateTime.Now;
        Sistem trh = db.Sistem.Where(q => q.Id == 1).FirstOrDefault();
        if (!(tarih >= trh.DanismanSBas && tarih <= trh.DanismanSBit))
        {
            TezHocaSec.Visible = false;
        }
        if (!(tarih >= trh.TezSBas && tarih <= trh.TezSBit))
        {
            TezSec.Visible = false;
            TezOner.Visible = false;
        }

    }

    protected void MesajOnizle()
    {
        List<Mesaj> mesajlist = new List<Mesaj>();
        var ogr = db.Ogrenci.Where(o => o.Id == AppKontrol.id).FirstOrDefault();
        var mesajlar = db.Mesaj.Where(m => m.Aid == AppKontrol.id).ToList();
        if (mesajlar != null)
        {
            int i = mesajlar.Count();
            int limit = mesajlar.Count();
            if (limit > 3) limit = 3;
            for (int x = 0; x < limit; x++)
            {
                mesajlist.Add(mesajlar[i - 1]);
                i--;
            }
            Repeatermsj.DataSource = mesajlist;
            Repeatermsj.DataBind();
        }
    }
}
