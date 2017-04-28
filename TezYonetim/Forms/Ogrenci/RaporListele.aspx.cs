using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Ogrenci_RaporListele : TezBaseUser
{
    TezDBEntities db = new TezDBEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        var ogr = db.Ogrenci.Find(AppKontrol.id);
        var trh = db.Rapor_Tarih.Where(t => t.Hoca_Id == ogr.Hoca_ID).ToList();
        Repeater1.DataSource = trh;
        Repeater1.DataBind();
    }
    protected void Rapor_goruntule_Click(object sender, EventArgs e)
    {
        //Modal rapor goruntule kayıt butonu işlemleri   
    }
    protected void Rapor_Yukle_Click(object sender, EventArgs e)
    {
        //Modal rapor yükle kayıt butonu işlemleri        
    }

}

