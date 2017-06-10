using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Hoca_RaporTarih : TezBase
{
    TezDBEntities db;
    Rapor_Tarih trh;

    protected void Page_Load(object sender, EventArgs e)
    {
        db = new TezDBEntities();
        trh = new Rapor_Tarih();
    }
    protected void btnGiris_Click(object sender, EventArgs e)
    {
        if (DBas.Text != "" && DBit.Text != "")
        {
            DateTime tarih = DateTime.Now;
            DateTime RaporBas = DateTime.Parse(DBas.Text.Replace("T", " "));
            DateTime RaporBit = DateTime.Parse(DBit.Text.Replace("T", " "));
            var rptarih = db.Rapor_Tarih.Where(r => r.Hoca_Id == AppKontrol.id && r.tur == 2).FirstOrDefault();
            if (rptarih == null && RaporBas < RaporBit && RaporBas >= tarih && RaporBit > tarih)
            {
                trh.Hoca_Id = AppKontrol.id;
                trh.RaporBas = RaporBas;
                trh.RaporBit = RaporBit;
                trh.tur = 2;
                db.Rapor_Tarih.Add(trh);
                db.SaveChanges();
                Label2.Text = "Vize rapor tarihi kaydedildi.";
            }
            else if (rptarih != null && RaporBas < RaporBit && RaporBas >= tarih && RaporBit > tarih)
            {
                rptarih.RaporBas = RaporBas;
                rptarih.RaporBit = RaporBit;
                db.SaveChanges();
                Label2.Text = "Vize rapor tarihi güncellendi.";
            }
            else
            {
                Label2.Text = "Bitiş Tarihi Başlangıç tarihinden önce olamaz .!";
            }
        }
        else
        {
            Label2.Text = "Başlangıç ve Bitiş Tarihini Boş Geçemezsin.!";
        }
    }
}