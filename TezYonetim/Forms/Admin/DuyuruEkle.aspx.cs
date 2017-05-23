using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Admin_DuyuruEkle : TezBaseAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGiris_Click(object sender, EventArgs e)
    {
        TezDBEntities db = new TezDBEntities();

        string baslik = Request["Baslik"].Trim();
        string duyuruT = Request["Duyuru"].Trim();
        if (duyuruT == "" || baslik == "" )
        {
            LabelSignUP.Text = "Lütfen Boş Geçmeyiniz";
        }
        else
        {
                     
                Duyuru_Admin duyuru = new Duyuru_Admin();

                duyuru.Duyuru_Baslik =baslik;
                duyuru.Duyuru_Text = duyuruT;
                duyuru.Duyuru_Tarih = DateTime.Now;
                db.Duyuru_Admin.Add(duyuru);
                db.SaveChanges();
                Response.Redirect(@"~/Forms/Admin/DuyuruEkle.aspx");
           

        }
    }
}