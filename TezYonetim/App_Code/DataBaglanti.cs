using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DataBaglanti
/// </summary>
public class DataBaglanti
{
    public DataBaglanti()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static DataTable QueryExecute(string Query_, SqlCommand MSSqlCommand_, bool IsStoredProcedure)
    {

        SqlConnection con_ = new SqlConnection(DBLogin.MSSqlConnectionString);
        con_.Open();
        DataSet ds_ = new DataSet();
        if (IsStoredProcedure)
            MSSqlCommand_.CommandType = CommandType.StoredProcedure;
        MSSqlCommand_.Connection = con_;
        MSSqlCommand_.CommandText = Query_;
        SqlTransaction trans = con_.BeginTransaction();
        MSSqlCommand_.Transaction = trans;
        try
        {
            SqlDataAdapter adp = new SqlDataAdapter(MSSqlCommand_);
            adp.Fill(ds_);
            trans.Commit();
        }
        catch (Exception exc_)
        {
            trans.Rollback();
            ds_ = null;
            con_.Close();
            throw exc_;
        }
        finally
        {
            con_.Close();
        }

        if (ds_ == null)
            return null;
        if (ds_.Tables.Count <= 0)
            return null;

        return ds_.Tables[0];
    }

    public static DataTable QueryExecute(string Query_)
    {
        SqlCommand cmd_ = new SqlCommand();
        return DataBaglanti.QueryExecute(Query_, cmd_, false);
    }
}
