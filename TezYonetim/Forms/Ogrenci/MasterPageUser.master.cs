using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPageUser : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id"] == null)
        {
            Response.Redirect(@"~/Default.aspx");
        }
        Label1.Text = Session["name"].ToString();

        Kontrol();
    }
    protected void LogOut_Click(object sender, EventArgs e)
    {
        Response.Cookies["MyCookie"].Expires = DateTime.Now.AddDays(-1);
        Session.RemoveAll();
        Response.Redirect(@"~/Default.aspx");
    }
    protected void Kontrol()
    {
        TezDBEntities db = new TezDBEntities();
        DateTime tarih = DateTime.Now;
        Sistem trh = db.Sistem.Where(q => q.Id == 1).FirstOrDefault();
        if (!(tarih >= trh.DanismanSBas && tarih <= trh.DanismanSBit))
        {
            TezHocaSec.Visible = false;        
        }
        if (!(tarih >= trh.TezSBas && tarih <= trh.TezSBit))
        {
            TezSec.Visible = false;
            TezOner.Visible = false;
            TezOner.Visible = false;
        }

    }
}
