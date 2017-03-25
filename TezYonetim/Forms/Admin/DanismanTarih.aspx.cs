using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Admin_DanismanTarih : TezBaseAdmin
{
        TezDBEntities db;
        Sistem trh;
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new TezDBEntities();
        trh = db.Sistem.Where(q => q.Id == 1).FirstOrDefault();
      
        Label1.Text = "Başlangıç " + trh.DanismanSBas.ToString();
        Label2.Text = "Bitiş " + trh.DanismanSBit.ToString();
    }
    protected void btnGiris_Click(object sender, EventArgs e)
    {

        //DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');
        //Tarih kayıt
        trh.DanismanSBas = DateTime.Parse(DBas.Text.Replace("T", " "));
        trh.DanismanSBit = DateTime.Parse(DBit.Text.Replace("T", " "));
        db.SaveChanges();

        //Label yenileme
        Label1.Text = "Başlangıç " + trh.DanismanSBas.ToString();
        Label2.Text = "Bitiş " + trh.DanismanSBit.ToString();
 

    }
}