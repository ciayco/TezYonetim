using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TezDBEntities db = new TezDBEntities();
        var Ogrenci = db.Ogrenci.ToList();
        if (Session["Id"] != null)
        {
            if ((int)Session["derece"] == 1) //2 veritabanında öğrenci demek
            {
                Response.Redirect(@"~/Admin.aspx");
            }
            Label1.Text = Session["name"].ToString();
        }
        else
        {
            if (Request.Cookies["MyCookie"] != null)
            {
                string name = Request.Cookies["MyCookie"]["Id"];
                string No = Request.Cookies["MyCookie"]["No"];
                var vt = db.Ogrenci.FirstOrDefault(u => u.No == No && u.Ad == name);
                if (vt != null)
                {
                    AppKontrol.id = System.Convert.ToInt32(vt.Id);
                    AppKontrol.derece = System.Convert.ToInt32(vt.Derece);
                }
                else
                {
                    Response.Redirect(@"~/Default.aspx");
                }
            }
            else
            {
                Response.Redirect(@"~/Default.aspx");
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
;