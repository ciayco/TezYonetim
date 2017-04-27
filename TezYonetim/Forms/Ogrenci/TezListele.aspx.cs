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

        if (Ogrenci.Tez_ID == null)
        {
            Label1.Text = "Tez Seçimi yapınız";
        }
        else if (Ogrenci.Tez_Onay == false)
        {
            Label1.Text = "Tez onay beklemede";
        }
        else
        {
            //var tezim2 = db.Tez.Where(w => w.Id == Ogrenci.Tez_ID).FirstOrDefault();
            //Label1.Text = tezim2.Konu;
            //Label2.Text = tezim2.Aciklama;
            Label1.Text = Ogrenci.Tez.Konu;
            Label2.Text = Ogrenci.Tez.Aciklama;
        }             
    }
    protected void LogOut_Click(object sender, EventArgs e)
    {
        Response.Cookies["MyCookie"].Expires = DateTime.Now.AddDays(-1);
        Session.RemoveAll();
        Response.Redirect(@"~/Default.aspx");
    }
}
