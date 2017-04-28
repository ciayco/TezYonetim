using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Hoca_TezListele : TezBase
{
    TezDBEntities db;
    Ogrenci Ogrenci;
    Tez Tez;
    protected void Page_Load(object sender, EventArgs e)
    {
        db = new TezDBEntities();

        var Ogrdb = db.Tez.Where(t => t.Hoca_ID == AppKontrol.id ).ToList();

        if (!IsPostBack)
        {

            Repeater1.DataSource = Ogrdb;
            Repeater1.DataBind();


        }
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string id;
        int ogid;
        switch (e.CommandName)
        {

            case "Red":
                id = e.CommandArgument.ToString();
                ogid = Convert.ToInt32(id);
                Tez = db.Tez.Where(o => o.Id == ogid).FirstOrDefault();
                db.Tez.Remove(Tez);
                db.SaveChanges();
                Repeater1.DataBind();
                Response.Redirect(@"~/Forms/Hoca/TezListele.aspx");
                break;
                
        }

    }
}