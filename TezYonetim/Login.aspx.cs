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
            Response.Redirect(@"~/Default.aspx");
    }

    protected void btnGiris_Click(object sender, EventArgs e)
    {
        try
        {
            string username = Request["username"].Trim();
            string pass = Request["pass"].Trim();
            DataTable dt_ = DataBaglanti.QueryExecute("SELECT * FROM Ogrenci WHERE No = '" + username + "' and sifre = '" + pass + "'");
      
           
            if (dt_ != null && dt_.Rows.Count > 0)
            {
                DataRow dr_ = dt_.Rows[0];
                string s = dr_["Id"].ToString();
                AppKontrol.CompanyID = Convert.ToInt32(s);
               // bool.TryParse(dr_["UsrsIsAdmin"].ToString(), out AppKontrol.isOgrenci);
               // if (!AppKontrol.isOgrenci) throw new Exception();
                Response.Redirect(@"~/Default.aspx");
            }
            /*admin kontrol admin değilse...
           else
           {

               dt_ = DataBaglanti.QueryExecute("SELECT * FROM Ogrenci WHERE No = '" + username + "' and sifre = '" + pass + "'");
               if (dt_ != null && dt_.Rows.Count > 0)
               {
                   DataRow dr_ = dt_.Rows[0];
                   string s = dr_["Id"].ToString();
                   AppKontrol.Id = Convert.ToInt32(s);
                   AppKontrol.isOgrenci = true;
                   Response.Redirect(@"~/Default.aspx");
               }
               else
                   throw new Exception();
           } */
        }

        catch (Exception ex)
        {
            Label1.Text = "HATALI GİRİŞ";
        }
       
    }

}