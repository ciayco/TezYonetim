<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Forms/Ogrenci/MasterPageUser.master" EnableEventValidation="false"  CodeFile="TezListele.aspx.cs" Inherits="TezListele" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">

    <title>Tezim</title>
   
    
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    
    
        
            <div>
              <div class="panel panel-primary">
                <div class="panel-heading"><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></div>
                <div class="panel-body"><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></div>

                </div>
                **************************************************
                <div class="well">
                 Tez Konusu:  <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><br /><br />
               Tez Açıklama:  <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                </div>

            </div>
          


   **************************************************
    
          <table class="table table-striped">
               <thead>
                  <tr>
                          <th style="text-align:center;">Tez Konu </th>
                          <th style="text-align:center;">Tez Açıklama</th>
                          
                  </tr>
                    </thead>
                <tbody>
     
      
            <tr>
                <td><asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></td>
                <td><asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>/td>
           
            </tr>
       
       
            </tbody> </table>
     

           
       
</asp:Content>
