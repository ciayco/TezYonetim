using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Ogrenci_MesajGonder : TezBaseUser
{
    TezDBEntities db = new TezDBEntities();
    Ogrenci ogr = new Ogrenci();
    protected void Page_Load(object sender, EventArgs e)
    {

        ogr = db.Ogrenci.Where(w => w.Id == AppKontrol.id).FirstOrDefault();
        Alici.Text = "Alıcı : " + ogr.Hoca.Ad;

    }
    protected void btnGiris_Click(object sender, EventArgs e)
    {
        TezDBEntities db = new TezDBEntities();

        string baslik = Request["Baslik"].Trim();
        string mesajT = Request["Mesaj"].Trim();
        if (mesajT == "" || baslik == "" )
        {
            LabelSignUP.Text = "Lütfen Boş Geçmeyiniz";
        }
        else
        {
                     
                Mesaj mesaj = new Mesaj();

                mesaj.MsjBaslik = baslik;
                mesaj.MsjText = mesajT;
                mesaj.Gonderenid = AppKontrol.id;
                mesaj.Alıcıid = ogr.Hoca.Id;
                mesaj.GonderenDerece = AppKontrol.derece;
                mesaj.AlıcıDerece = ogr.Hoca.Derece;                          
                db.Mesaj.Add(mesaj);
                db.SaveChanges();
                Response.Redirect(@"~/Default.aspx");
           

        }
    }
}