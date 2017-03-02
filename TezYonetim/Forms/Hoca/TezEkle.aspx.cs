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

    }
    protected void btnGiris_Click(object sender, EventArgs e)
    {
        TezDBEntities db = new TezDBEntities();
        Tez tez = new Tez();
        tez.Konu = Request["Konu"].Trim();
        tez.Aciklama = Request["Aciklama"].Trim();
        tez.Hoca_ID = AppKontrol.id;
        db.Tez.Add(tez);
        db.SaveChanges();
        Response.Redirect(@"~/Default.aspx");
        


    }
}