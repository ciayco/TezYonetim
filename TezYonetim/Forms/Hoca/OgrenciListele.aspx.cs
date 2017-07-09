using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

public partial class Admin : TezBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TezDBEntities db = new TezDBEntities();
        var Ogrenci = db.Ogrenci.Where(o => o.Hoca_ID == AppKontrol.id && o.Hoca_Onay == true).ToList();
        if (Ogrenci.Count>0)
        {
            goster.Visible = true;
            gosterme.Visible = false;
            Repeater1.DataSource = Ogrenci;
            Repeater1.DataBind();
        }
        else
        {
            goster.Visible = false;
            gosterme.Visible = true;
            lbgosterme.Text = "Size Kayıtlı Öğrenci Bulunamadı!!";
        }

        if (Request.QueryString["Id"] != null)
        {
            int id = int.Parse(Request.QueryString["Id"]);
            var ogr2 = db.Ogrenci.Where(w => w.Id == id).FirstOrDefault();
            var goster = db.Tez.Where(o => o.Id == ogr2.Tez_ID).FirstOrDefault();
            Label1.Text = ogr2.Ad;
            Label2.Text = ogr2.No;
            Label3.Text = ogr2.Mail;
            Label5.Text = ogr2.Bolum;
            if (ogr2.Tez_Onay == null) { Label6.Text = "Tez Almamış"; }
            else if (ogr2.Tez_Onay == true) { Label6.Text = goster.Konu; }
            else { Label6.Text = "Onay Beklemede"; }
            Page.ClientScript.RegisterStartupScript(GetType(), "modelBox", "$('.modal').modal()", true);

        }
    }

}