using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User : TezBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((int)Session["derece"] == 1) //2 veritabanında öğrenci demek
        {
            Response.Redirect(@"~/Admin.aspx");
        }
        Label1.Text = Session["name"].ToString();

        TezFonk fnk = new TezFonk();
        TezDBEntities db = new TezDBEntities();
        var Hoca = db.Hoca.ToList();
        Ogrenci Ogrenci = db.Ogrenci.Where(w => w.Id == AppKontrol.id).FirstOrDefault();

        Repeater1.DataSource = Hoca;
        Repeater1.DataBind();

        if (Request.QueryString["Id"] != null)
        {
            int id = int.Parse(Request.QueryString["Id"]);
            if (Request.QueryString["Sec"] != null && Ogrenci.Hoca_ID == null)
            {                             
                Ogrenci.Hoca_ID = id;
                db.SaveChanges();
                Repeater1.DataBind();
                Response.Redirect(@"~/user.aspx");
            }

            if (Request.QueryString["Sil"] != null && Ogrenci.Hoca_ID != null)
            {

                Ogrenci.Hoca_ID = null;
                db.SaveChanges();
                Repeater1.DataBind();
                Response.Redirect(@"~/user.aspx");
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
