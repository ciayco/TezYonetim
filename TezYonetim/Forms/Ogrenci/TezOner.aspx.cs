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
        //tarih kontrol
        DateTime tarih = DateTime.Now;
        Sistem trh = db.Sistem.Where(q => q.Id == 1).FirstOrDefault();
        if (!(tarih >= trh.DanismanSBas && tarih <= trh.DanismanSBit))
        {
            Response.Redirect(@"~/Forms/Ogrenci/index.aspx");
        }
        else
        {

            var hocaId = db.Ogrenci.Find(AppKontrol.id).Hoca_ID;

        
            var Ogrenci = db.Ogrenci.Where(o => o.Hoca_Onay == true && o.Hoca_ID == hocaId && o.Tez_Onay != true && o.Id != AppKontrol.id).ToList();

            Repeater1.DataSource = Ogrenci;
            Repeater1.DataBind();
        }
        
     }
    
    protected void btnGiris_Click(object sender, EventArgs e)
    {
        var teziAlanDigerOgrenciler = Request["TeziAlanDigerOgrenciler"];

        // boş mu dolu mu kontrolünün yapılması lazım.

        foreach (var item in teziAlanDigerOgrenciler)
        {
            string ogrenciId = (item.ToString());
            
            if (ogrenciId !=",")
            {
                int a = Convert.ToInt32(ogrenciId);
                Ogrenci ogrenci = db.Ogrenci.Find(a);
                label1.Text =label1.Text+"<br>"+ ogrenci.Ad;
            }
           
        }
      

    }
  
    protected void LogOut_Click(object sender, EventArgs e)
    {
        Response.Cookies["MyCookie"].Expires = DateTime.Now.AddDays(-1);
        Session.RemoveAll();
        Response.Redirect(@"~/Default.aspx");
    }
} 