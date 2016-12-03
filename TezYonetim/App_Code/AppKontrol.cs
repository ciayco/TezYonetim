using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class AppKontrol
{
    public AppKontrol()
    {
       
    }
    public static int CompanyDerece //Session["Derece"] ' yi kontrol eder
    {
        get
        {
            if (HttpContext.Current.Session["derece"] != null)
            {
                return (int)HttpContext.Current.Session["derece"];
            }
            else
                return 1;
        }
        set
        {
            HttpContext.Current.Session["derece"] = value;
        }
    }
    public static int CompanyID //Session["Id"] ' yi kontrol eder
    {
        get
        {
            if (HttpContext.Current.Session["ID"] != null)
                return (int)HttpContext.Current.Session["ID"];
            else
                return 1;
            
        }
        set
        {
            HttpContext.Current.Session["ID"] = value;
        }
    }
    public static bool isOgrenci;
}