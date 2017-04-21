<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Forms/Ogrenci/MasterPageUser.master" EnableEventValidation="false"  CodeFile="TezHocaSec.aspx.cs" Inherits="User" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">

    <title>Tez Seçimi</title>
   
    
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
   
    <!--Tez Seçimi -->
     <div runat="server" id="sec" visible="false">
          <!--Repeater -->
          <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
          <HeaderTemplate>
          <table class="table table-striped">
               <thead>
                  <tr>
                          <th style="text-align:center;">Id </th>
                          <th style="text-align:center;">İsim Soyisim </th>
                          <th style="text-align:center;">Ders </th>
                          <th style="text-align:center;">Seç</th>
                  </tr>
                    </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("Id") %></td>
                <td><%#Eval("Ad") %></td>
                <td><%#Eval("Ders") %></td>
                 <td>
                    <asp:Button ID="SecBut" CommandName="Sec" Text="Seç" runat="server" CommandArgument='<%# Eval("Id") %>' />
                </td>
                
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody> </table>
        </FooterTemplate>
    </asp:Repeater>
        </div>
    <!--Tez Seçimi -->
    <!--Onay bekleme -->
    <div id="bekleme" runat="server" visible="false">
         <table class="table table-striped">
             
            <tr>                
                <th style="text-align:center;">Adı & Soyadı </th>
                <th style="text-align:center;">Durum</th>    
            </tr>                 
            <tr>           
                <td><asp:Label ID="DurumBekleme1" runat="server"></asp:Label></td>
                <td><asp:Label ID="DurumBekleme" runat="server"></asp:Label></td>
                
            </tr>
        </table>
    </div>
     <!--Onay bekleme-->
    
    <!--Onaylanmış-->
    <div id="onay" runat="server" visible="false">

        <table class="table table-striped">
             
            <tr>                
                <th style="text-align:center;">Adı & Soyadı </th>
                <th style="text-align:center;">Durum</th>    
            </tr>                 
            <tr>           
                <td><asp:Label ID="DurumOnay1" runat="server"></asp:Label></td>
                <td><asp:Label ID="DurumOnay" runat="server"></asp:Label></td>
                
            </tr>
        </table>
    </div>
 <!--Onaylanmış-->
</asp:Content>