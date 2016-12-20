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
    }
    protected void LogOut_Click(object sender, EventArgs e)
    {
        Response.Cookies["MyCookie"].Expires = DateTime.Now.AddDays(-1);
        Session.RemoveAll();
        Response.Redirect(@"~/Default.aspx");
    }
}
;