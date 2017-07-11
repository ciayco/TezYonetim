using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Hoca_MesajGonder : TezBase
{
    TezDBEntities db = new TezDBEntities();
    Hoca hca = new Hoca();
    List<string> ogrlist = new List<string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hca = db.Hoca.Where(h => h.Id == AppKontrol.id).FirstOrDefault();
            var ogrenci = db.Ogrenci.Where(x => x.Hoca_ID == AppKontrol.id).Select(x => new { x.Ad, x.Id }).ToList();
            Alici.DataSource = ogrenci;
            Alici.DataTextField = "Ad";
            Alici.DataValueField = "Id";
            Alici.DataBind();
        }
    }
    protected void btnGiris_Click(object sender, EventArgs e)
    {
        TezDBEntities db = new TezDBEntities();
        hca = db.Hoca.Where(h => h.Id == AppKontrol.id).FirstOrDefault();
        string baslik = Request["Baslik"].Trim();
        string mesajT = Request["Mesaj"].Trim();
        if (mesajT == "" || baslik == "" || Alici.SelectedValue=="")
        {
            msgbilgi.Text = "Lütfen Boş Geçmeyiniz";
        }
        else
        {
            Mesaj mesaj = new Mesaj();
            mesaj.MsjBaslik = baslik;
            mesaj.MsjText = mesajT;
            mesaj.Gid = AppKontrol.id;
            mesaj.Aid = Convert.ToInt32(Alici.SelectedValue);
            mesaj.Gadi = hca.Ad;
            mesaj.Aadi = Alici.SelectedItem.Text;
            mesaj.GDerece = AppKontrol.derece;
            mesaj.ADerece = 2;
            mesaj.Okundu = false;
            mesaj.MsjTarih = DateTime.Now;
            db.Mesaj.Add(mesaj);
            db.SaveChanges();
            msgbilgi.Text = "Mesajınız Gönderilmiştir.";
        }
    }

}