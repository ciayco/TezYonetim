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
        var tezim = db.Tez.Where(w => w.Id == Ogrenci.Tez_ID).FirstOrDefault();
       

        if (Ogrenci.Tez_ID == null)
        {
            onaysiz.Visible = true;
            onayli.Visible = false;
            Label3.Text = "Tez Seçimi yapınız";
        }
        else if (Ogrenci.Tez_Onay == false)
        {
            onaysiz.Visible = true;
            onayli.Visible = false;
            Label3.Text = "Tez onay beklemede";
        }
        else
        {
            onayli.Visible = true;
            onaysiz.Visible = false;
            Repeater2.DataSource = Ogrdb;
            Repeater2.DataBind();
            Label1.Text = tezim.Konu;
            Label2.Text = tezim.Aciklama;
            Label4.Text = db.Hoca.Find(Ogrenci.Hoca_ID).Ad;
        }             
    }
    protected void LogOut_Click(object sender, EventArgs e)
    {
        Response.Cookies["MyCookie"].Expires = DateTime.Now.AddDays(-1);
        Session.RemoveAll();
        Response.Redirect(@"~/Default.aspx");
    }
}
