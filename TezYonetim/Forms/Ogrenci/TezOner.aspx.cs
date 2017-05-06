using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Ogrenci_TezOner : TezBaseUser
{
    // Kullanıcı tarafından girilen diğer öğrenci numaralarından doğru olanlar.
    List<string> TeziAlanDigerOgrenciListesi;
    List<string> TeziAlanDigerOgrenciNumaralari;
    TezDBEntities db;
    Ogrenci Ogrenci;
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new TezDBEntities();
        Ogrenci = db.Ogrenci.Find(AppKontrol.id);
        //tarih kontrol
        DateTime tarih = DateTime.Now;
        Sistem trh = db.Sistem.Where(q => q.Id == 1).FirstOrDefault();
        if (!(tarih >= trh.DanismanSBas && tarih <= trh.DanismanSBit))
        {
            Response.Redirect(@"~/Forms/Ogrenci/index.aspx");
        }
    }
    protected void btnGiris_Click(object sender, EventArgs e)
    {
        TeziAlanDigerOgrenciListesi = new List<string>();
        Label2.Text = "";
        if (konu.Text != "" && comment.Text != "" /*&& Request["TeziAlanDigerOgrenciler"].Trim() !=""*/)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "modelBox", "$('.modal').modal()", true);
            var teziAlanDigerOgrenciler = Request["TeziAlanDigerOgrenciler"].Trim();
            TeziAlanDigerOgrenciNumaralari = teziAlanDigerOgrenciler.Split(',').ToList();
            foreach (var item in TeziAlanDigerOgrenciNumaralari)
            {
                if (OgrenciyiKontrolEt(item.Trim()) && !TeziAlanDigerOgrenciListesi.Contains(item.Trim()))
                {
                    TeziAlanDigerOgrenciListesi.Add(item.Trim());
                }
            }
            if (TeziAlanDigerOgrenciListesi.Count > 0)
            {
                butonmodal.Visible = true;
                foreach (var item in TeziAlanDigerOgrenciListesi)
                {
                    Label2.Text = Label2.Text + "<br>" + item.Trim() + " " + db.Ogrenci.Where(w => w.No == item.Trim()).FirstOrDefault().Ad;
                }
                Label3.Text = "Yukarıda bilgileri verilen Öğrencileri Eklemek istiyomusunuz.?";
            }
            else
            {
                butonmodal.Visible = false;
                Label2.Text = "Sistemde Şartlara Uygun Öğrenci Bulunamadı";
                Page.ClientScript.RegisterStartupScript(GetType(), "modelBox", "$('.modal').modal()", true);
            }
        }
        else
        {
            label1.Text = "Boş Geçilemez";
        }
        Session["ogrList"] = TeziAlanDigerOgrenciListesi;
    }
    public bool OgrenciyiKontrolEt(string OgrenciNumarasi)
    {
        if (db.Ogrenci.Where(w => w.No == OgrenciNumarasi).Any())
            return true;

        return false;
    }
    protected void LogOut_Click(object sender, EventArgs e)
    {
        Response.Cookies["MyCookie"].Expires = DateTime.Now.AddDays(-1);
        Session.RemoveAll();
        Response.Redirect(@"~/Default.aspx");
    }
    protected void Onayla_Click(object sender, EventArgs e)
    {
        List<string> yeniList = Session["ogrList"] as List<string>;
        Session.Remove("ogrList");
        if (IsPostBack)
        {
            if (yeniList.Count > 0)
            {
                foreach (var item in yeniList)
                {
                    Ogrenci DigerOgr = db.Ogrenci.Where(o => o.Hoca_Onay == true &&
                                                             o.Hoca_ID == Ogrenci.Hoca.Id &&
                                                             o.Tez_ID == null &&
                                                             o.Tez_Onay != true &&
                                                             o.Id != AppKontrol.id &&
                                                             o.No == item.Trim()).FirstOrDefault();
                    if (DigerOgr != null)
                    {
                        Tez tezz = new Tez();
                        Tez tez = db.Tez.Where(o => o.Konu == konu.Text).FirstOrDefault();
                        if (!(tez != null))
                        {
                            tezz.Hoca_ID = Ogrenci.Hoca.Id;
                            tezz.Konu = konu.Text;
                            tezz.Aciklama = comment.Text;
                            db.Tez.Add(tezz);
                            db.SaveChanges();
                            Ogrenci.Tez_ID = tezz.Id;
                            Ogrenci.Tez_Onay = false;
                            DigerOgr.Tez_ID = tezz.Id;
                            DigerOgr.Tez_Onay = false;
                            db.SaveChanges();
                        }
                        else
                        {
                            Ogrenci.Tez_ID = tez.Id;
                            Ogrenci.Tez_Onay = false;
                            DigerOgr.Tez_ID = tez.Id;
                            DigerOgr.Tez_Onay = false;
                            db.SaveChanges();
                        }
                        label1.Text = "Tez Onay İçin Gönderildi";
                    }
                    else
                    {
                        label1.Text = "Sistemde Şartlara Uygun Öğrenci Bulunamadı";
                    }
                }
            }
            else
            {
                label1.Text = "Girdiğin bilgilerle eşleşen herhangi bir öğrenci bulunamadı.";
            }
        }
    }
}