using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Admin_AdminListele : TezBaseAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TezDBEntities db = new TezDBEntities();
        var admin = db.Admin.ToList();

        Repeater1.DataSource = admin;
        Repeater1.DataBind();
    }
}