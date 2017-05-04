using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Ogrenci_TezOner : TezBaseUser
{
    TezDBEntities db;
    Ogrenci Ogrenci;
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new TezDBEntities();
        Ogrenci = db.Ogrenci.Find(AppKontrol.id);
        //tarih kontrol
        DateTime tarih = DateTime.Now;
        Sistem trh = db.Sistem.Where(q => q.Id == 1).FirstOrDefault();
        if (!(tarih >= trh.DanismanSBas && tarih <= trh.DanismanSBit))
        {
            Response.Redirect(@"~/Forms/Ogrenci/index.aspx");
        }
     
        
     }
    
    protected void btnGiris_Click(object sender, EventArgs e)
    {

        if(konu.Text != "" && comment.Text != "" && TextOgr.Text != "")
        {
  
        Ogrenci DigerOgr = db.Ogrenci.Where(o => o.Hoca_Onay == true &&
                                       o.Hoca_ID == Ogrenci.Hoca.Id &&
                                       o.Tez_ID == null &&
                                       o.Tez_Onay != true &&
                                       o.Id != AppKontrol.id &&
                                       o.No == TextOgr.Text).FirstOrDefault();
            if (DigerOgr != null)
            {
                Tez tez = new Tez();
                tez.Hoca_ID = Ogrenci.Hoca.Id;
                tez.Konu = konu.Text;
                tez.Aciklama = comment.Text;
                db.Tez.Add(tez);
                
                Ogrenci.Tez_ID = tez.Id;
                DigerOgr.Tez_ID = tez.Id;
                db.SaveChanges();
                label1.Text = "Tez Onay İçin Gönderildi";
            }
            else
            {
                label1.Text = "Sistemde Şartlara Uygun Öğrenci Bulunamadı";
            }
      

        }
        else
        {
            label1.Text = "Alanlar Boş Bırakılamaz";
        }
    }
  
    protected void LogOut_Click(object sender, EventArgs e)
    {
        Response.Cookies["MyCookie"].Expires = DateTime.Now.AddDays(-1);
        Session.RemoveAll();
        Response.Redirect(@"~/Default.aspx");
    }
} 