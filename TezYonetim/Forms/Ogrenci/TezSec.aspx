<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Forms/Ogrenci/MasterPageUser.master" EnableEventValidation="false"  CodeFile="TezSec.aspx.cs" Inherits="TezSec" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">

    <title>Tez Seçimi</title>
   
    
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    

          <!--Repeater -->
          <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
          <HeaderTemplate>
          <table class="table table-striped">
               <thead>
                  <tr>
                          <th style="text-align:center;">Id </th>
                          <th style="text-align:center;">Hoca Id </th>
                          <th style="text-align:center;">Ogr Id </th>
                          <th style="text-align:center;">Konu </th>
                          <th style="text-align:center;">Aciklama</th>    
                  </tr>
                    </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("Id") %></td>
                <td><%#Eval("Hoca_ID") %></td>
                <td><%#Eval("Og_ID") %></td>
                <td><%#Eval("Konu") %></td>
                <td><%#Eval("Aciklama") %></td>
                 <td>
                    <asp:Button ID="SecBut" CommandName="Sec" Text="Seç" runat="server" CommandArgument='<%# Eval("Id") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody> </table>
        </FooterTemplate>
    </asp:Repeater>
           <!--Repeater -->

    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>


      <!-- Morris Charts JavaScript -->

    <script src="../../js/plugins/morris/raphael.min.js"></script>
    <script src="../../js/plugins/morris/morris.min.js"></script>
    <script src="../../js/plugins/morris/morris-data.js"></script>
    
</asp:Content>