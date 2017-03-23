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
            Response.Write("<script>alert('Tez bulunamadı')</script>");
        }
        else if (Ogrenci.Tez_Onay == false)
        {
            Response.Write("<script>alert('Tez onay beklemede')</script>");
        }

        
        var tezim2 = db.Tez.Where(w => w.Og_ID ==AppKontrol.id).FirstOrDefault();

        Label1.Text = tezim2.Konu;
        Label2.Text = tezim2.Aciklama;
        Label3.Text = tezim2.Konu;
        Label4.Text = tezim2.Aciklama;
        Label5.Text = tezim2.Konu;
        Label6.Text = tezim2.Aciklama;

    }

    protected void LogOut_Click(object sender, EventArgs e)
    {
        Response.Cookies["MyCookie"].Expires = DateTime.Now.AddDays(-1);
        Session.RemoveAll();
        Response.Redirect(@"~/Default.aspx");
    }
}
