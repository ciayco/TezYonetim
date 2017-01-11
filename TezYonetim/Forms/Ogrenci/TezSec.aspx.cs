using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User : TezBaseUser
{
    TezFonk fnk;
    TezDBEntities db;
    Ogrenci Ogrenci;
    Tez tez;
    protected void Page_Load(object sender, EventArgs e)
    {      
        fnk = new TezFonk();
        db = new TezDBEntities();
        Ogrenci = db.Ogrenci.Where(w => w.Id == AppKontrol.id).FirstOrDefault();
        var Tezdb = db.Tez.Where(t => t.Hoca_ID == Ogrenci.Hoca_ID && t.Durum == 0).ToList();
        
        
        if (!IsPostBack)
        {
            //if (Ogrenci.Hoca_ID == null)
            {
                Repeater1.DataSource = Tezdb;
                Repeater1.DataBind();
            }
            
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string id;
        int tezid;
            switch (e.CommandName)
            {

                case "Sec":
                    id = e.CommandArgument.ToString();
                    tezid = Convert.ToInt32(id);
                    tez = db.Tez.Where(t => t.Id == tezid).FirstOrDefault();
                    tez.Og_ID = AppKontrol.id;
                    tez.Durum = 1;
                    db.SaveChanges();
                    Repeater1.DataBind();
    
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
