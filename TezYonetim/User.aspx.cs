using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User: System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Id"] != null)
        {

            if ((int)Session["derece"] == 1) //1 veritabanında Admin/Hoca demek
            {
                Response.Redirect(@"~/Admin.aspx");
            }

        }
        else
        {
            Response.Redirect(@"~/Default.aspx");
        }
    }
}