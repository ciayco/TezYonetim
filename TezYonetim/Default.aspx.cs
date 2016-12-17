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
        {
             
            if ((int)Session["derece"] == 1) //1 veritabanında Admin/Hoca demek
            {
                Response.Redirect(@"~/Admin.aspx");
            }
            if ((int)Session["derece"] == 2)
            {
                Response.Redirect(@"~/User.aspx");
            }

        }
        
    }

    protected void btnGiris_Click(object sender, EventArgs e)
    {
        string username = Request["username"].Trim();
        string pass = Request["pass"].Trim();
       

        TezDBEntities db = new TezDBEntities();

        var deneme = db.Ogrenci.FirstOrDefault(u => u.No == username && u.Sifre == pass);
        
        if (deneme != null)
        {
            string name = deneme.Ad ;
            AppKontrol.id = (int)deneme.Id; //Id kontrolu           
            AppKontrol.derece = (int)deneme.Derece;// derece kontrolü
            AppKontrol.name = name;// isim soyisim kontrolü
            HttpCookie myCookie = new HttpCookie("MyCookie");

            myCookie["No"] = deneme.No.ToString();
            myCookie["Name"] = deneme.Ad.ToString();
            myCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(myCookie);

            if (deneme.Derece==2) //öğrenci ise User page git
            {
                Response.Redirect(@"~/User.aspx");
            }
           if(deneme.Derece==1)// admin/Hoca ise Admin page git
            {
                Response.Redirect(@"~/Admin.aspx");
            }
        }else
        {
            Label1.Text = "hatalı";
        }         
    }

}