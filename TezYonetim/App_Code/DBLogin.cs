using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DBLogin
/// </summary>
public class DBLogin
{
    public DBLogin()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string MSSqlConnectionString
    {
        get
        {

            string SqlServerName = ".\\SQLEXPRESS";
            string SqlServerDatabase = "TezDB";

            return "Data Source=" + SqlServerName + ";Initial Catalog=" + SqlServerDatabase + ";Integrated Security=True";

        }
    }
}
