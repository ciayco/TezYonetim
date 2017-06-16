using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class MasterPageUser : System.Web.UI.MasterPage
{
    string okuma;
    static int kontrol = 0;
    TezDBEntities db;
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new TezDBEntities();
        if (Session["id"] == null)
        {
            Response.Redirect(@"~/Default.aspx");
        }
        Label1.Text = Session["name"].ToString();
        var msgcount = db.Mesaj.Where(m => m.Aid == AppKontrol.id && m.Okundu == false).ToList();

        if (msgcount.Count > 0)
        {
            Label2.Text = msgcount.Count.ToString();
            kontrol = 1;
        }
        else
        {
            Label2.Text = "0";
            kontrol = 0;
        }

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
        var ogr = db.Ogrenci.Find(AppKontrol.id);
        Sistem trh = db.Sistem.Where(q => q.Id == 1).FirstOrDefault();
        if (!(tarih >= trh.DanismanSBas && tarih <= trh.DanismanSBit))
        {
            TezHocaSec.Visible = false;
        }
        if (!(tarih >= trh.TezSBas && tarih <= trh.TezSBit) || ogr.Hoca_Onay != true)
        {
            TezSec.Visible = false;
            TezOner.Visible = false;
        }

    }

    protected void MesajOnizle()
    {
        List<Mesaj> mesajlist = new List<Mesaj>();
        var mesajlar = db.Mesaj.Where(m => m.Aid == AppKontrol.id).ToList();
        var mesajlar1 = db.Mesaj.Where(m => m.Aid == AppKontrol.id && m.Okundu == false).ToList();
        if (mesajlar1.Count > 0)
        {
            int i = mesajlar1.Count();
            int limit = mesajlar1.Count();
            if (limit > 3) limit = 3;
            for (int x = 0; x < limit; x++)
            {
                mesajlist.Add(mesajlar1[i - 1]);
                i--;
            }
            Repeatermsj.DataSource = mesajlist;
            Repeatermsj.DataBind();
        }
        else if(mesajlar.Count > 0)
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
    public string gelenkutusukontrol(string metin)
    {
        int id = Convert.ToInt16(metin);
        var msg = db.Mesaj.Find(id);

        if (msg.Okundu == false)
        {
            okuma = "Yeni";
            kontrol = 1;
        }
        else
        {
            kontrol = 0;
        }

        return okuma;

    }
    protected void Repeatermsj_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblUserId = (Label)e.Item.FindControl("yeni");
            HtmlGenericControl div = (HtmlGenericControl)e.Item.FindControl("msg");
            if (kontrol == 0)
            {
                div.Visible = false;
            }
            if (kontrol == 1)
            {
                div.Visible = true;
            }
        }
    }
}
