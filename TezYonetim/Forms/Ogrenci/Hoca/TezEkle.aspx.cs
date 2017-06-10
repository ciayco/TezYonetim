using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

public partial class TezEkle : TezBase
{

    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnGiris_Click(object sender, EventArgs e)
    {
        TezDBEntities db = new TezDBEntities();
        Tez tez = new Tez();
        if (Request["Konu"].Trim() != "" && Request["Aciklama"].Trim() != "" && Convert.ToInt32(Request["TezAdet"].Trim()) > 0)
        {
            tez.Konu = Request["Konu"].Trim();
            tez.Aciklama = Request["Aciklama"].Trim();
            tez.Tez_Limit = Convert.ToInt32(Request["TezAdet"].Trim());
            tez.Hoca_ID = AppKontrol.id;
            tez.ResimAd = "bosimg";
            tez.ResimUzanti = "png";
            tez.Tez_Alan = 0;
            db.Tez.Add(tez);
            db.SaveChanges();
            uyari.Text = ("<br>") + "Teziniz Kaydedilmiştir.!";
        }
        else
        {
            uyari.Text = ("<br>") + "Hatalı Veri Girişi Yada Boş Veri Girişi";
        }
    }
}