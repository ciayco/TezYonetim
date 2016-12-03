using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Id"] != null)
        {
            
            if ((int)Session["derece"] == 2) //2 veritabanında öğrenci demek
            {
                Response.Redirect(@"~/User.aspx");
            }

        }
        else
        {
            Response.Redirect(@"~/Login.aspx");
        }
    }
}