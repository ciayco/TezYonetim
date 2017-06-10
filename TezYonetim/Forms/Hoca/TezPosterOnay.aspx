<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Hoca/MasterPageHoca.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="TezPosterOnay.aspx.cs" Inherits="Admin" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <title>Tez Onay</title>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <!--Repeater -->
    <div id="tablo" runat="server">
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
            <HeaderTemplate>
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th style="text-align: center;">Konu </th>
                            <th style="text-align: center;">İncele</th>
                            <th style="text-align: center;">Reddet</th>
                            <th style="text-align: center;">Onayla</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("Konu") %></td>

                    <td>
                        <asp:ImageButton ID="ImageButton1" OnCommand="ImageButton1_Command" CommandName="poster" CommandArgument='<%# Eval("Id") %>' runat="server" Height="20px" Width="20px" ImageUrl='<%# "~/Posterler/" + Eval("ResimAd") + "." + Eval("ResimUzanti") %>' />
                    </td>
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
    </div>
    <br />
    <div id="label" runat="server" visible="false">
        <asp:Label ID="Label2" runat="server"></asp:Label>
    </div>

    <div class="modal fade" id="postermodal" tabindex="-1" role="dialog" aria-labelledby="postermodalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="postermodalLabel">Tez Afişi</h4>
                </div>
                <div class="modal-body">
                    <div id="posterDiv" runat="server">
                        <asp:Image ID="posterimage" Height="400" Width="275px   " runat="server" /></div>
                    <div id="posterLabel" runat="server" visible="false">
                        <asp:Label ID="labelPoster" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

