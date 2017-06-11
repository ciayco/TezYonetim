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
        Label1.Text = "Toplam gün sayısı.... ";
        //Label1.Text = "Başlangıç " + trh.DanismanSBas.ToString();
        //Label2.Text = "Bitiş " + trh.DanismanSBit.ToString();
    }
    protected void btnGiris_Click(object sender, EventArgs e)
    {
        if (DBas.Text != "" && DBit.Text != "")
        {
            var rptarih = db.Rapor_Tarih.Where(r => r.Hoca_Id == AppKontrol.id);
            int sayi = rptarih.Count();

            if (sayi == 0)
            {
                tarihekle();

                //Label1.Text = "Başlangıç " + trh.RaporBas.ToString();
                //Label2.Text = "Bitiş " + trh.RaporBit.ToString();               
            }
            else
            {
                db.Rapor_Tarih.RemoveRange(rptarih);
                db.SaveChanges();
                tarihekle();
            }


        }
        else
        {
            Label2.Text = "";
            Label1.Text = "Başlangıç ve Bitiş Tarihini Boş Geçemezsin.!";
        }

    }

    public void tarihekle()
    {
        DateTime RaporBas = DateTime.Parse(DBas.Text.Replace("T", " "));
        DateTime RaporBit = DateTime.Parse(DBit.Text.Replace("T", " "));
        double toplamgun = (RaporBit - RaporBas).TotalDays;
        toplamgun = toplamgun / Convert.ToInt32(RaporAdet.Text);
        double periyod = Math.Round(toplamgun);
        DateTime temp = new DateTime();
        temp = RaporBas;
        Label1.Text = "Toplam gün sayısı " + periyod;
        int raportext = Convert.ToInt32(RaporAdet.Text);
        for (int i = 0; i < raportext; i++)
        {
            trh.Hoca_Id = AppKontrol.id;
            trh.RaporBas = temp;
            temp = temp.AddDays(periyod);
            if (i + 1 == raportext) trh.RaporBit = RaporBit;
            else trh.RaporBit = temp;
            trh.tur = 1;
            db.Rapor_Tarih.Add(trh);
            db.SaveChanges();
            
        }
        Label1.Text += "<br/>" + "Kaydedildi";
    }
}