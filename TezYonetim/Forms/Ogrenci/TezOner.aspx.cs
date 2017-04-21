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
        if (tarih >= trh.DanismanSBas && tarih <= trh.DanismanSBit)
        {
            //yapılacak işlemler
        }
        else
        {
            Response.Redirect(@"~/Forms/Ogrenci/index.aspx");
        }
     }
    protected void btnGiris_Click(object sender, EventArgs e)
    {
    }

protected void LogOut_Click(object sender, EventArgs e)
    {
        Response.Cookies["MyCookie"].Expires = DateTime.Now.AddDays(-1);
        Session.RemoveAll();
        Response.Redirect(@"~/Default.aspx");
    }
} 