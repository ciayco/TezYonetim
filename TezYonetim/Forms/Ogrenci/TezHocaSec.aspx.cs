using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User : TezBaseUser
{
   
    TezDBEntities db;
    Ogrenci Ogrenci;
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new TezDBEntities();
        //tarih kontrol
        DateTime tarih = DateTime.Now;
        Sistem trh = db.Sistem.Where(q => q.Id ==1).FirstOrDefault();
        if (tarih >= trh.DanismanSBas && tarih <= trh.DanismanSBit)
        {
               
            var Hoca = db.Hoca.ToList();
            Ogrenci = db.Ogrenci.Where(w => w.Id == AppKontrol.id).FirstOrDefault();
            var hoca2 = db.Hoca.Where(w => w.Id == Ogrenci.Hoca_ID).FirstOrDefault();
            //sayfa işlemleri
            if (!IsPostBack)
            {
                if (Ogrenci.Hoca_ID == null)
                {
                    sec.Visible = true;
                    Repeater1.DataSource = Hoca;
                    Repeater1.DataBind();
                    
                }
                else if (Ogrenci.Hoca_Onay == false)
                {
                    bekleme.Visible = true;
                    DurumBekleme1.Text = hoca2.Ad;
                    DurumBekleme.Text = "Onay Beklemede";
                }
                else
                {
                    onay.Visible = true;
                    DurumOnay1.Text = hoca2.Ad;
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
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string id;
            switch (e.CommandName)
            {
                case "Sec":
                    id = e.CommandArgument.ToString();                                    
                    Ogrenci.Hoca_ID = Convert.ToInt32(id);
                    Ogrenci.Hoca_Onay = false;
                    db.SaveChanges();
                    Repeater1.DataBind();
                    Response.Redirect(@"~/Forms/Ogrenci/TezHocaSec.aspx");
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
