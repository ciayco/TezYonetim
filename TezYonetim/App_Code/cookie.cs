using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cookie
/// </summary>
public class cookie
{
    public cookie()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static HttpCookie Cookie(string no, string ad)
    {
        HttpCookie myCookie = new HttpCookie("MyCookie");
        myCookie["No"] = no.ToString();
        myCookie["Name"] = ad.ToString();
        myCookie.Expires = DateTime.Now.AddDays(1);
        return myCookie;
       
    }
}