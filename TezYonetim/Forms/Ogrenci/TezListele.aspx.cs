using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TezListele : TezBaseUser
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tez tez = new Tez();
        TezDBEntities db = new TezDBEntities();
        Ogrenci Ogrenci = db.Ogrenci.Where(w => w.Id == AppKontrol.id).FirstOrDefault();
        db = new TezDBEntities();
        var Ogrdb = db.Ogrenci.Where(t => t.Tez_ID == Ogrenci.Tez_ID ).ToList();
        var tezim2 = db.Tez.Where(w => w.Id == Ogrenci.Tez_ID).FirstOrDefault();
       

        if (Ogrenci.Tez_ID == null)
        {
            Label2.Text = "Tez Seçimi yapınız";
        }
        else if (Ogrenci.Tez_Onay == false)
        {
            Label1.Text = tezim2.Konu;
            Label2.Text = "Tez onay beklemede";
        }
        else
        {
        
            Repeater2.DataSource = Ogrdb;
            Repeater2.DataBind();
            Label1.Text = tezim2.Konu;
            Label2.Text = tezim2.Aciklama;
        }             
    }
    protected void LogOut_Click(object sender, EventArgs e)
    {
        Response.Cookies["MyCookie"].Expires = DateTime.Now.AddDays(-1);
        Session.RemoveAll();
        Response.Redirect(@"~/Default.aspx");
    }
}
