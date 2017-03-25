<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Hoca/MasterPageHoca.master" EnableEventValidation="false"  AutoEventWireup="true" CodeFile="TezOnay.aspx.cs" Inherits="Admin" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <title>Kullanıcı Görüntüle</title>
    
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
                          <th style="text-align:center;">Hoca_Id </th>
                          <th style="text-align:center;">Tez_Id </th>       
                          <th style="text-align:center;">İsim Soyisim </th>
                          <th style="text-align:center;">No </th>
                          <th style="text-align:center;">Mail </th>
                          <th style="text-align:center;">Bolum </th>               
                          <th style="text-align:center;">Reddet</th>
                          <th style="text-align:center;">Onayla</th>
                  </tr>
                    </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("Id") %></td>
                <td><%#Eval("Hoca_ID") %></td>
                <td><%#Eval("Tez_ID") %></td>
                <td><%#Eval("Ad") %></td>
                <td><%#Eval("No") %></td>
                <td><%#Eval("Mail") %></td>
                <td><%#Eval("Bolum") %></td>
                <td>
                    <asp:Button ID="RedBut" CommandName="Red" Text="Reddet" runat="server" class="btn btn-danger btn-xs btn-round" CommandArgument='<%# Eval("Id") %>' />
                </td>
                <td>
                    <asp:Button ID="OnBut" CommandName="Onay" Text="Onayla" class="btn btn-primary btn-xs btn-round" runat="server" CommandArgument='<%# Eval("Id") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody> </table>
        </FooterTemplate>
    </asp:Repeater>

    
    <br />







</asp:Content>

