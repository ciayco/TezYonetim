using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TezFonk
/// </summary>
public class TezFonk
{
    TezDBEntities db = new TezDBEntities();
   
    public TezFonk()
    {
        var Hoca = db.Hoca.ToList();
        var Ogrenci = db.Ogrenci.ToList();
        //
        // TODO: Add constructor logic here
        //
    }


    public void Sil(int id)
    {
  
        
    }
}