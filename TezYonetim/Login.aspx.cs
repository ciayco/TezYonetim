using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Id"] != null)
            Response.Redirect(@"~/user.aspx");
    }

    protected void btnGiris_Click(object sender, EventArgs e)
    {
        string username = Request["username"].Trim();
        string pass = Request["pass"].Trim();

        TezDBEntities db = new TezDBEntities();


        var deneme = db.Ogrenci.FirstOrDefault(u => u.No == username && u.sifre == pass);
        if (deneme != null)
        {
            string s = deneme.Id.ToString();
            AppKontrol.CompanyID = Convert.ToInt32(s);
           
            Response.Redirect(@"~/user.aspx");
        }
        else
        {
            Label1.Text = "hatalı";
        }
                  
                
                
    }

}