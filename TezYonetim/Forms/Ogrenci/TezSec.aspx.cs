using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TezSec : TezBaseUser
{
  
    TezDBEntities db;
    Ogrenci Ogrenci;
    Tez tez;
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new TezDBEntities();
        //tarih kontrol
        DateTime tarih = DateTime.Now;
        Sistem trh = db.Sistem.Where(q => q.Id ==1).FirstOrDefault();
        if (tarih >= trh.DanismanSBas && tarih <= trh.DanismanSBit)
        {
                    
            Ogrenci = db.Ogrenci.Where(w => w.Id == AppKontrol.id).FirstOrDefault();
            var Tezdb = db.Tez.Where(t => t.Hoca_ID == Ogrenci.Hoca_ID && t.Tez_Alan < t.Tez_Limit).ToList();
            var Tezdb2 = db.Tez.Where(w => w.Id == Ogrenci.Tez_ID).FirstOrDefault();
            if (!IsPostBack)
            {
              if(Ogrenci.Tez_ID==null)
                {
                    sec.Visible = true;
                    Repeater1.DataSource = Tezdb;
                    Repeater1.DataBind();
                }
                else if (Ogrenci.Tez_Onay == false)
                {
                    bekleme.Visible = true;
                    DurumBekleme1.Text = Tezdb2.Konu;
                    DurumBekleme2.Text = Tezdb2.Aciklama;
                    DurumBekleme.Text = "Onay Beklemede";
                }
                else
                {
                    onay.Visible = true;
                    DurumOnay1.Text = metin_kisalt_yan(Tezdb2.Konu);
                    DurumOnay2.Text = metin_kisalt_yan(Tezdb2.Aciklama);
                    DurumOnay.Text = "Onaylandı";
                }
            }
        }
        else
        {
            Response.Redirect(@"~/Default.aspx");
        }
        //tarih kontrol
    }
    public string metin_kisalt_yan(string metin)

    {
        if (metin.Length > 40)
        {
            metin = metin.Substring(0, 40);

            metin = metin + "...";
        }

        return metin;

    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Label1.Text ="";
        Label3.Text ="";
        Label5.Text = "";
        string id;
        int tezid,ogid;
            switch (e.CommandName)
            {

                case "Sec":
                    id = e.CommandArgument.ToString();
                    tezid = Convert.ToInt32(id);                  
                    Ogrenci.Tez_ID = Convert.ToInt32(id);
                    Ogrenci.Tez_Onay = false;
                    db.SaveChanges();
                    Repeater1.DataBind();
                    Response.Redirect(@"~/Forms/Ogrenci/TezSec.aspx");

                break;
            case "incele":
                id = e.CommandArgument.ToString();
                ogid = Convert.ToInt32(id);
                Ogrenci = db.Ogrenci.Where(w => w.Id == AppKontrol.id).FirstOrDefault();
                var hoca = db.Hoca.Find(Ogrenci.Hoca_ID);
                tez = db.Tez.Where(oo => oo.Id == ogid).FirstOrDefault();
                Label1.Text += tez.Konu;
                Label3.Text = hoca.Ad;
                Label5.Text = Label5.Text + tez.Aciklama;
                var tezalan = db.Ogrenci.Where(oo => oo.Tez_ID == ogid).ToList();
                Repeater2.DataSource = tezalan;
                Repeater2.DataBind();
                Page.ClientScript.RegisterStartupScript(GetType(), "modelBox", "$('.modal').modal()", true);
                break;
        }
        
    }
    protected void LogOut_Click(object sender, EventArgs e)
    {
        Response.Cookies["MyCookie"].Expires = DateTime.Now.AddDays(-1);
        Session.RemoveAll();
        Response.Redirect(@"~/Default.aspx");
    }
}
