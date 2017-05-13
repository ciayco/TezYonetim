using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPageHoca : System.Web.UI.MasterPage
{
    TezDBEntities db;
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new TezDBEntities();
        if (Session["id"] == null)
        {
            Response.Redirect(@"~/Default.aspx");
        }
        MesajOnizle();
        Label1.Text = Session["name"].ToString();
    }
    protected void LogOut_Click(object sender, EventArgs e)
    {
        Response.Cookies["MyCookie"].Expires = DateTime.Now.AddDays(-1);
        Session.RemoveAll();
        Response.Redirect(@"~/Default.aspx");
    }
    protected void MesajOnizle()
    {
        List<Mesaj> mesajlist = new List<Mesaj>();
        var ogr = db.Hoca.Where(o => o.Id == AppKontrol.id).FirstOrDefault();
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
