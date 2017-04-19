<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Forms/Ogrenci/MasterPageUser.master" EnableEventValidation="false"  CodeFile="TezSec.aspx.cs" Inherits="TezSec" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">

    <title>Tez Seçimi</title>
   
    
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <div runat="server" id="sec" visible="false">
              <!--Tez Seçimi -->
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
    </div>
    <!--Tez Seçimi -->
     <!--Onay bekleme -->
    <div id="bekleme" runat="server" visible="false">
         <table class="table table-striped">
             
            <tr>                
                <th style="text-align:center;">Konu </th>
                <th style="text-align:center;">Aciklama</th>
                <th style="text-align:center;">Durum</th>    
            </tr>                 
            <tr>           
                <td><asp:Label ID="DurumBekleme1" runat="server"></asp:Label></td>
                <td><asp:Label ID="DurumBekleme2" runat="server"></asp:Label></td>
                <td><asp:Label ID="DurumBekleme" runat="server"></asp:Label></td>
                
            </tr>
        </table>
    </div>
     <!--Onay bekleme-->
    
    <!--Onaylanmış-->
    <div id="onay" runat="server" visible="false">

        <table class="table table-striped">
             
            <tr>                
                <th style="text-align:center;">Konu </th>
                <th style="text-align:center;">Aciklama</th>
                <th style="text-align:center;">Durum</th>    
            </tr>                 
            <tr>           
                <td><asp:Label ID="DurumOnay1" runat="server"></asp:Label></td>
                <td><asp:Label ID="DurumOnay2" runat="server"></asp:Label></td>
                <td><asp:Label ID="DurumOnay" runat="server"></asp:Label></td>
                
            </tr>
        </table>
    </div>
 <!--Onaylanmış-->

    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>


      <!-- Morris Charts JavaScript -->

    <script src="../../js/plugins/morris/raphael.min.js"></script>
    <script src="../../js/plugins/morris/morris.min.js"></script>
    <script src="../../js/plugins/morris/morris-data.js"></script>
    
</asp:Content>