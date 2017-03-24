<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Hoca/MasterPageHoca.master" AutoEventWireup="true" CodeFile="TezListele.aspx.cs" Inherits="Forms_Hoca_TezListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <title>Tezlerim</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <br />
    <br />
 <!--Repeater -->
          <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" >
          <HeaderTemplate>
          <table class="table table-striped">
               <thead>
                  <tr>
                          <th style="text-align:center;">Id </th>
                          <th style="text-align:center;">Hoca_Id </th>
                          <th style="text-align:center;">Og_Id </th>       
                          <th style="text-align:center;">Og2_Id</th>
                          <th style="text-align:center;">Konu </th>
                          <th style="text-align:center;">Açıklama </th>                        
                  </tr>
                    </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("Id") %></td>
                <td><%#Eval("Hoca_id") %></td>
                <td><%#Eval("Og_id") %></td>
                <td><%#Eval("Og2_id") %></td>
                <td><%#Eval("Konu") %></td>
                <td><%#Eval("aciklama") %></td>
                <td>
                    <asp:Button ID="RedBut" CommandName="Red" Text="Sil" runat="server" CommandArgument='<%# Eval("Id") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody> </table>
        </FooterTemplate>
    </asp:Repeater>

    
    <br />




</asp:Content>

