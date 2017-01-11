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
                Response.Redirect(@"~/Forms/Hoca/Admin.aspx");
            }
            if ((int)Session["derece"] == 2)
            {
                Response.Redirect(@"~/Forms/Ogrenci/User.aspx");
            }
        }
    }
    protected void btnGiris_Click(object sender, EventArgs e)
    {
        string username = Request["username"].Trim();

        TezDBEntities db = new TezDBEntities();
       

            if (db.Ogrenci.Where(w => w.No == username).Any())
            {
                string sifre = Sifreleme.Sifrele(Request["pass"].Trim());
                Ogrenci Ogrenci = db.Ogrenci.Where(w => w.No == username && w.Sifre == sifre).FirstOrDefault();
                if (Ogrenci != null)
                {
                    AppKontrol.id = (int)Ogrenci.Id; //Id kontrolu           
                    AppKontrol.derece = (int)Ogrenci.Derece;// derece kontrolü
                    AppKontrol.name = Ogrenci.Ad;// isim  kontrolü
                    Response.Cookies.Add(cookie.Cookie(Ogrenci.No, Ogrenci.Sifre));
                    Response.Redirect(@"~/Forms/Ogrenci/User.aspx");
                }
                else
                {
                    Label1.Text = "Kullanıcı adı veya Şifre Uyuşmadı!";
                }
            }
     
       
           else if (db.Hoca.Where(w => w.Mail == username).Any())
            {
                string sifre = Sifreleme.Sifrele(Request["pass"].Trim());
                Hoca hoca = db.Hoca.Where(w => w.Mail == username && w.Sifre == sifre).FirstOrDefault();
                if (hoca != null)
                {
                    AppKontrol.id = (int)hoca.Id; //Id kontrolu           
                    AppKontrol.derece = (int)hoca.Derece;// derece kontrolü
                    AppKontrol.name = hoca.Ad;// isim soyisim kontrolü
                    Response.Cookies.Add(cookie.Cookie(hoca.Mail, hoca.Sifre));
                    Response.Redirect(@"~/Forms/Hoca/Admin.aspx");

                }
                else
                {
                    Label1.Text = "Kullanıcı adı veya Şifre Uyuşmadı!";
                }
            }
       
        Label1.Text = "Kullanıcı adı veya Şifre Uyuşmadı!";
    }
}