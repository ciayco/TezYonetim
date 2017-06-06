<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Hoca/MasterPageHoca.master" AutoEventWireup="true" CodeFile="TezAlinmayan.aspx.cs" Inherits="Forms_Hoca_TezListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <title>Alınmayan Tezler</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <!--Repeater -->
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
        <HeaderTemplate>
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th style="text-align: center;">Konu </th>
                        <th style="text-align: center;">Açıklama </th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#metin_kisalt_yan(Eval("Konu").ToString().Trim()) %></td>
                <td><%#metin_kisalt_yan(Eval("aciklama").ToString().Trim()) %></td>
                <td>
                    <asp:ImageButton ID="ImageButton1" OnCommand="ImageButton1_Command" CommandName="poster" CommandArgument='<%# Eval("Id") %>' runat="server" Height="20px" Width="20px" ImageUrl='<%# "~/Posterler/" + Eval("ResimAd") + "." + Eval("ResimUzanti") %>' />
                </td>
                <td>
                    <asp:Button ID="incBut" CommandName="incele" Text="İncele" runat="server" class="btn btn-default btn-xs btn-round" CommandArgument='<%# Eval("Id") %>' />
                </td>
                <td>
                    <a href="TezDuzenle.aspx?ID=<%#Eval("Id") %>" class="btn btn-success btn-xs btn-round">Düzenle</a>
                </td>
                <td>
                    <asp:Button ID="RedBut" CommandName="Red" Text="Sil" runat="server" class="btn btn-danger btn-xs btn-round" CommandArgument='<%# Eval("Id") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody> </table>
        </FooterTemplate>
    </asp:Repeater>
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="exampleModalLabel">Tez Ayrıntıları</h4>
                </div>
                <div class="modal-body">
                    <div class="panel-body" style="text-align: left;">
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <div style="text-align: left; float: left;">
                                    <i class="glyphicon glyphicon-text-background">&nbsp;</i>
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                </div>
                                <div style="text-align: right; float: right">
                                    <i class="glyphicon glyphicon-user">&nbsp;</i><asp:Label ID="Label3" runat="server"></asp:Label><br />
                                </div>
                            </div>
                            <div class="panel-footer" style="text-align: left;">
                                <i class="glyphicon glyphicon-user">&nbsp;</i>Tezi Alan Öğrenciler:
                                <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater1_ItemCommand">

                                    <ItemTemplate>
                                        <a href="#"><%#Eval("Ad") %></a>
                                    </ItemTemplate>
                                </asp:Repeater>


                                <blockquote style="font-size: 14px;">
                                    <asp:Label ID="Label5" runat="server"></asp:Label>
                                </blockquote>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Kapat</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="postermodal" tabindex="-1" role="dialog" aria-labelledby="postermodalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="postermodalLabel">Tez Afişi</h4>
                </div>
                <div class="modal-body">
                   <div id="posterDiv" runat="server"><asp:Image ID="posterimage" Height="400" Width="275px   " runat="server" /></div> 
                    <div id="posterLabel" runat="server" visible="false">
                        <asp:Label ID="labelPoster" runat="server" Text=""></asp:Label></div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

