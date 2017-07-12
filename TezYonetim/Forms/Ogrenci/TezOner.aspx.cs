using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Ogrenci_TezOner : TezBaseUser
{
    List<string> TeziAlanDigerOgrenciListesi;
    List<string> TeziAlanDigerOgrenciNumaralari;
    List<string> YanlisGirilenOgrenciListesi;
    TezDBEntities db;
    string keywordlist;
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
        YanlisGirilenOgrenciListesi = new List<string>();
        Label2.Text = "";
        label4.Text = "";
        label5.Text = "";
        if (Request.Form["KeywordBox"] != null)
        {
            keywordlist = Request["KeywordBox"].Trim();
            keywordlist = keywordlist.ToLower();
        }
        else
        {
            uyarı.Text = "Boş Geçilemez keyword";
        }

        if (konu.Text != "" && comment.Text != "")
        {
            if (Request.Form["TeziAlanDigerOgrenciler"] != null)
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
                    else
                    {
                        YanlisGirilenOgrenciListesi.Add(item.Trim());
                    }
                }
                if (YanlisGirilenOgrenciListesi.Count > 0)
                {
                    butonmodal.Visible = false;
                    foreach (var item in YanlisGirilenOgrenciListesi)
                    {
                        label4.Text = label4.Text + "<br>" + item.Trim();

                    }
                    label5.Text = "Yukarıda bilgileri verilen öğrenci(ler) sistemde bulunamadı";
                }
                else if (TeziAlanDigerOgrenciListesi.Count > 0)
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
                Label2.Text = "Tez Önerinizi Kaydetmek istiyomusunuz ?";
                Page.ClientScript.RegisterStartupScript(GetType(), "modelBox", "$('.modal').modal()", true);
            }

        }
        else
        {
            uyarı.Text = "Boş Geçilemez";
        }
        Session["ogrList"] = TeziAlanDigerOgrenciListesi;
        Session["keyword"] = keywordlist;
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
        string keywordlistesiyeni = Session["keyword"] as string;
        Session.Remove("ogrList");
        Session.Remove("keyword");
        if (IsPostBack)
        {
            if (Ogrenci.Tez_ID == null)
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
                            Tez tez = new Tez();
                            Tez tezKontrol = db.Tez.Where(o => o.Konu == konu.Text).FirstOrDefault();
                            if (!(tezKontrol != null))
                            {
                                tez.Hoca_ID = Ogrenci.Hoca.Id;
                                tez.Konu = konu.Text;
                                tez.Aciklama = comment.Text;
                                tez.Tez_Limit = (yeniList.Count) + 1;
                                tez.Tez_Alan = 0;
                                tez.ResimAd = "bosimg";
                                tez.ResimUzanti = "png";
                                tez.keywords = keywordlistesiyeni;
                                tez.ResimDurum = 1;
                                tez.durum = true;
                                db.Tez.Add(tez);
                                db.SaveChanges();
                                Ogrenci.Tez_ID = tez.Id;
                                Ogrenci.Tez_Onay = false;
                                DigerOgr.Tez_ID = tez.Id;
                                DigerOgr.Tez_Onay = false;
                                db.SaveChanges();
                            }
                            else
                            {
                                Ogrenci.Tez_ID = tezKontrol.Id;
                                Ogrenci.Tez_Onay = false;
                                DigerOgr.Tez_ID = tezKontrol.Id;
                                DigerOgr.Tez_Onay = false;
                                db.SaveChanges();
                            }
                            uyarı.Text = "Tez Onay İçin Gönderildi";
                        }
                        else
                        {
                            uyarı.Text = "Sistemde Şartlara Uygun Öğrenci Bulunamadı";
                        }
                    }
                }
                else
                {
                    if (Ogrenci.Tez_ID == null)
                    {
                        Tez tez = new Tez();
                        tez.Hoca_ID = Ogrenci.Hoca.Id;
                        tez.Konu = konu.Text;
                        tez.Aciklama = comment.Text;
                        tez.Tez_Limit = (yeniList.Count) + 1;
                        tez.Tez_Alan = 0;
                        tez.ResimAd = "bosimg";
                        tez.ResimUzanti = "png";
                        tez.keywords = keywordlistesiyeni;
                        tez.ResimDurum = 1;
                        tez.durum = true;
                        db.Tez.Add(tez);
                        db.SaveChanges();
                        Ogrenci.Tez_ID = tez.Id;
                        Ogrenci.Tez_Onay = false;
                        db.SaveChanges();
                        uyarı.Text = "Tez Onay İçin Gönderildi";
                    }
                    else
                    {
                        uyarı.Text = "Sisteme kayıtlı teziniz olduğundan tez önerisi yapamazsınız";
                    }
                }
            }
            else
            {
                uyarı.Text = "Sisteme kayıtlı teziniz olduğundan tez önerisi yapamazsınız";
            }
        }
        }
    }