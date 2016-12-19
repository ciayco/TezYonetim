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
        if (db.Ogrenci.Where(w => w.No == username).Any())
        {
            string sifre = Sifreleme.Sifrele(pass);
            Ogrenci Ogrenci = db.Ogrenci.Where(w => w.No == username && w.Sifre == sifre).FirstOrDefault();
        
        
        if (Ogrenci != null)
        {
            string name = Ogrenci.Ad ;
            AppKontrol.id = (int)Ogrenci.Id; //Id kontrolu           
            AppKontrol.derece = (int)Ogrenci.Derece;// derece kontrolü
            AppKontrol.name = name;// isim soyisim kontrolü
            HttpCookie myCookie = new HttpCookie("MyCookie");

            myCookie["No"] = Ogrenci.No.ToString();
            myCookie["Name"] = Ogrenci.Ad.ToString();
            myCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(myCookie);

            if (Ogrenci.Derece==2) //öğrenci ise User page git
            {
                Response.Redirect(@"~/User.aspx");
            }
           if(Ogrenci.Derece==1)// admin/Hoca ise Admin page git
            {
                Response.Redirect(@"~/Admin.aspx");
            }
        }else
        {
            Label1.Text = "hatalı";
        }
        }
    }
}