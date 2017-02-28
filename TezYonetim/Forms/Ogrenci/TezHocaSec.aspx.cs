using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User : TezBaseUser
{
    TezFonk fnk;
    TezDBEntities db;
    Ogrenci Ogrenci;
    protected void Page_Load(object sender, EventArgs e)
    {      
        fnk = new TezFonk();
        db = new TezDBEntities();
        var Hoca = db.Hoca.ToList();
        Ogrenci = db.Ogrenci.Where(w => w.Id == AppKontrol.id).FirstOrDefault();

        //tarih kontrol
        DateTime tarih = DateTime.Now;
        Tarih trh = db.Tarih.Where(q => q.Hoca_ID == Ogrenci.Hoca_ID).FirstOrDefault();

        if (tarih >= trh.DanismanSBas && tarih <= trh.DanismanSBit)
        {
            //sayfa işlemleri
        }
        //tarih kontrol


        if (!IsPostBack)
        {
            if (Ogrenci.Hoca_ID == null)
            {
                Repeater1.DataSource = Hoca;
                Repeater1.DataBind();
            }
            
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string id;
            switch (e.CommandName)
            {

                case "Sec":
                    id = e.CommandArgument.ToString();                                    
                    Ogrenci.Hoca_ID = Convert.ToInt32(id);
                    db.SaveChanges();
                    Repeater1.DataBind();
    
                    break;

                case "Sil":
                     id = e.CommandArgument.ToString();
                     Ogrenci.Hoca_ID = null;
                     db.SaveChanges();
                     Repeater1.DataBind();
                 
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
