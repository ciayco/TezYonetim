using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Hoca_MesajGoster : System.Web.UI.Page
{
    TezDBEntities db = new TezDBEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = "Konu  : ";
        Label2.Text = "<br/>";
        if (Request.QueryString["Id"] != null)
        {
            int id = int.Parse(Request.QueryString["Id"]);
            var msg = db.Mesaj.Find(id);
            if (msg != null)
            {
                Label4.Text = msg.MsjTarih.ToString();
                Label3.Text = msg.Gadi;
                Label1.Text = Label1.Text + msg.MsjBaslik;
                Label2.Text = Label2.Text + "<blockquote>" + msg.MsjText;
            }
            else
            {
                Label2.Text = Label2.Text + "<blockquote>" + "Mesaj Bulunamadı.";
            }


        }
    }
}