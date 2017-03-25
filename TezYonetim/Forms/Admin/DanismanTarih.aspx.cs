using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Admin_DanismanTarih : TezBaseAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void btnGiris_Click(object sender, EventArgs e)
    {
        Label1.Text = DBas.Text.Replace("T", " ");
        Label2.Text = DBit.Text.Replace("T", " ");
    }
}