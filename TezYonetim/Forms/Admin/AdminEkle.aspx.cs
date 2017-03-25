﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Admin_AdminEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGiris_Click(object sender, EventArgs e)
    {
        TezDBEntities db = new TezDBEntities();

        string sifrem = Sifreleme.Sifrele(Request["Sifre"].Trim());
        string no = Request["E-mail"].Trim();

        if (db.Admin.Where(w => w.Mail == no).Any())
        {
            LabelSignUP.Text = "Bu Kullanıcı Sistemde Mevcut";
        }
        else
        {
            Admin admin2 = new Admin();

            admin2.KullanıcıAdi = Request["Name"].Trim();
            admin2.Sifre = sifrem;
            admin2.Mail = Request["E-mail"].Trim();
            admin2.Derece = 0;
            db.Admin.Add(admin2);
            db.SaveChanges();
            Response.Redirect(@"~/Default.aspx");
        }


    }
}