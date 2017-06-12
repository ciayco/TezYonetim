using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Login : System.Web.UI.Page
{
    TezDBEntities db = new TezDBEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Id"] != null)
        {
            if ((int)Session["derece"] == 1) //1 veritabanında Hoca demek
            {
                Response.Redirect(@"~/Forms/Hoca/index.aspx");
            }
            if ((int)Session["derece"] == 2)//2 veritabanında Öğrencis demek
            {
                Response.Redirect(@"~/Forms/Ogrenci/index.aspx");
            }
            if ((int)Session["derece"] == 0)//0 veritabanında Admin demek
            {
                Response.Redirect(@"~/Forms/Admin/index.aspx");
            }
        }
    }
    protected void btnGiris_Click(object sender, EventArgs e)
    {
        string username = Request["username"].Trim();

        CheckUser(username, Request["pass"].Trim());

    }

    public bool IsAdmin(string Mail)
    {
        return db.Admin.Where(u => u.Mail == Mail).Any();
    }

    public void CheckUser(string UserName, string Password = null)
    {

        if (string.IsNullOrEmpty(UserName))
        {
            Label1.Text = "Lütfen Kullanıcı Adı Ve Şifre Giriniz!";
            return; 
        }
        else
        {
            Password = Sifreleme.Sifrele(Password);
        }


        if (!UserName.Contains("@"))
        {
            Ogrenci user = db.Ogrenci.Where(w => w.No == UserName && w.Sifre == Password).FirstOrDefault();

            if (user != null && user.durum==true)
            {
                Response.Cookies.Add(cookie.Cookie(user.No, user.Sifre));
                AuthenticateUser(user.Id, user.Derece, user.Ad, user.Sifre, "Ogrenci");               
            }
            else if (user.durum != true)
            {
                Label1.Text = "Teziniz Bitmiştir. Sisteme Giriş Yetkiniz Bulunmamaktadır.";
            }
               
            else
                Label1.Text = "Kullanıcı Adı Veya Şifresi Hatalı!";
        }
        else if (IsAdmin(UserName))
        {
            Admin user = db.Admin.Where(w => w.Mail == UserName && w.Sifre == Password).FirstOrDefault();

            if (user != null)
            {
                Response.Cookies.Add(cookie.Cookie(user.Mail, user.Sifre));
                AuthenticateUser(user.Id, user.Derece, user.KullanıcıAdi, user.Sifre, "Admin");                
            }
                
            else
                Label1.Text = "Kullanıcı Adı Veya Şifresi Hatalı!";

        }
        else
        {
            Hoca user = db.Hoca.Where(w => w.Mail == UserName && w.Sifre == Password).FirstOrDefault();

            if (user != null)
            {
                Response.Cookies.Add(cookie.Cookie(user.Mail, user.Sifre));
                AuthenticateUser(user.Id, user.Derece, user.Ad, user.Sifre, "Hoca");               
            }
                
            else
                Label1.Text = "Kullanıcı Adı Veya Şifresi Hatalı!";
        }

    }

    public void AuthenticateUser(int Id, int? Derece, string UserName, string Password, string Page)
    {
        AppKontrol.id = Id; //Id kontrolu           
        AppKontrol.derece = (int)Derece;// derece kontrolü
        AppKontrol.name = UserName;// isim soyisim kontrolü
        Response.Redirect(@"~/Forms/" + Page + "/index.aspx");
    }



}