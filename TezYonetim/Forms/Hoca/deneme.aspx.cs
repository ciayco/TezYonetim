using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Hoca_Default : TezBase
{
    protected void Page_Load(object sender, EventArgs e)
       
    {
        TezDBEntities db = new TezDBEntities();

        var hocaId = AppKontrol.id;


        var Ogrenci = db.Ogrenci.Where(o => o.Hoca_Onay == true && o.Hoca_ID == hocaId && o.Tez_Onay != true && o.Id != AppKontrol.id).ToList();

        Repeater1.DataSource = Ogrenci;
        Repeater1.DataBind();
        Repeater2.DataSource = Ogrenci;
        Repeater2.DataBind();
    }
}
