<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Hoca/MasterPageHoca.master" EnableEventValidation="false"  AutoEventWireup="true" CodeFile="OgrenciOnay.aspx.cs" Inherits="Admin" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <title>Öğrenci Onay</title>
    
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
 <!--Repeater --><div id="repeaterdiv" runat="server">
          <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
          <HeaderTemplate>
          <table class="table table-striped">
               <thead>
                  <tr>
                          <th style="text-align:center;">Ad & Soyad </th>
                          <th style="text-align:center;">No</th>
                          <th style="text-align:center;">Mail </th>
                          <th style="text-align:center;">Bölüm </th>               
                          <th style="text-align:center;">Seçim</th>
                          <th style="text-align:center;">Seçim</th>
                  </tr>
                    </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("Ad") %></td>
                <td><%#Eval("No") %></td>
                <td><%#Eval("Mail") %></td>
                <td><%#Eval("Bolum") %></td>
                <td>
                    <asp:Button ID="SilBut" CommandName="Sil" Text="  Reddet  " class="btn btn-danger btn-xs btn-round" runat="server" CommandArgument='<%# Eval("Id") %>' />
                </td>
                <td>
                    <asp:Button ID="SecBut" CommandName="Sec" Text="  Onayla  " class="btn btn-primary btn-xs btn-round" runat="server" CommandArgument='<%# Eval("Id") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody> </table>
        </FooterTemplate>
    </asp:Repeater>
     </div>
   <div id="labeldiv" runat="server"> <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></div>
    <br />







</asp:Content>

