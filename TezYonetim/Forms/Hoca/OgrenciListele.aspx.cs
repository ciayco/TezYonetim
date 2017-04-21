using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

public partial class Admin : TezBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TezDBEntities db = new TezDBEntities();
        var Ogrenci = db.Ogrenci.Where(o => o.Hoca_ID == AppKontrol.id && o.Hoca_Onay == true).ToList();

        Repeater1.DataSource = Ogrenci;
        Repeater1.DataBind();
            if (Request.QueryString["Id"] != null)
            {
                int id = int.Parse(Request.QueryString["Id"]);
                var silKayit = db.Ogrenci.Find(id);
                db.Ogrenci.Remove(silKayit);
                db.SaveChanges();
                Repeater1.DataBind();
                Response.Redirect(@"~/Forms/Hoca/OgrenciListele.aspx");
            }
    }
    
}