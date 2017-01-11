<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Forms/Ogrenci/MasterPageUser.master" EnableEventValidation="false"  CodeFile="TezHocaSec.aspx.cs" Inherits="User" %>


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
                          <th style="text-align:center;">İsim Soyisim </th>
                          <th style="text-align:center;">Ders </th>
                          <th style="text-align:center;">Seç</th>                 
                          <th style="text-align:center;">Sil</th>
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
                <td>
                    <asp:Button ID="SilBut" CommandName="Click" Text="Sil" runat="server" CommandArgument='<%# Eval("Id") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody> </table>
        </FooterTemplate>
    </asp:Repeater>

    
</asp:Content>