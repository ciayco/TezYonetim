using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Admin_HocaListele : TezBaseAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TezDBEntities db = new TezDBEntities();
        var Hoca = db.Hoca.ToList();

        Repeater1.DataSource = Hoca;
        Repeater1.DataBind();
        //if (Request.QueryString["Id"] != null)
        //{
        //    int id = int.Parse(Request.QueryString["Id"]);
        //    var silKayit = db.Hoca.Find(id);
        //    db.Hoca.Remove(silKayit);
        //    db.SaveChanges();
        //    Repeater1.DataBind();
        //    Response.Redirect(@"~/HocaListele.aspx");
        //}
    }
}