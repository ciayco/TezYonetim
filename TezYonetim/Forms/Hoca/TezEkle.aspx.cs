using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

public partial class TezEkle :TezBase
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request.QueryString["Id"]) == "1")
        {
            uyari.Text = ("<br>")+"Teziniz Kaydedilmiştir.!";
        }
    }
    protected void btnGiris_Click(object sender, EventArgs e)
    {
        TezDBEntities db = new TezDBEntities();
        Tez tez = new Tez();
        if(Request["Konu"].Trim()!="" && Request["Aciklama"].Trim()!="")
        { 
            tez.Konu = Request["Konu"].Trim();
            tez.Aciklama = Request["Aciklama"].Trim();
            tez.Tez_Limit = Convert.ToInt32(Request["TezAdet"].Trim());
            tez.Hoca_ID = AppKontrol.id;
            db.Tez.Add(tez);
            db.SaveChanges();
            Response.Redirect(@"~/Forms/Hoca/TezEkle.aspx?id=1");
        }
        uyari.Text = "Boş geçilemez";
    }
}