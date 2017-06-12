<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Hoca/MasterPageHoca.master" AutoEventWireup="true" CodeFile="TezListele.aspx.cs" Inherits="Forms_Hoca_TezListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <title>Tez Görüntüle</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <ul class="nav nav-tabs" role="tablist">
        <li role="presentation" class="active"><a href="#devam" aria-controls="home" role="tab" data-toggle="tab">Devam Eden Tezler</a></li>
        <li role="presentation"><a href="#tum" aria-controls="tum" role="tab" data-toggle="tab">Tüm Tezler</a></li>
        <li role="presentation"><a href="#alinmayan" aria-controls="alinmayan" role="tab" data-toggle="tab">Alınmayan Tezler</a></li>
        <li role="presentation"><a href="#biten" aria-controls="biten" role="tab" data-toggle="tab">Biten Tezler</a></li>
    </ul>
    <!-- Tab panes -->
    <div class="tab-content">
        <!-- Tap Başlangıc -->
        <div role="tabpanel" class="tab-pane active" id="devam">
            <br />
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th style="text-align: center;">Konu </th>
                                <th style="text-align: center;">Açıklama </th>
                                <th style="text-align: center;">Poster </th>
                                <th style="text-align: center;">İşlemler </th>
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
                            <div class="btn-group">
                                <button class="btn btn-default btn-sm dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    Tüm İşlemler <span class="caret"></span>
                                </button>
                                <ul class="dropdown-menu">
                                    <li>
                                        <asp:LinkButton ID="incBut" CommandName="incele" runat="server" CommandArgument='<%# Eval("Id") %>'>İncele</asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="tezbit" CommandName="bitir" runat="server" CommandArgument='<%# Eval("Id") %>'>Tezi Bitir</asp:LinkButton></li>
                                </ul>
                            </div>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody> </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <!-- Tap Bitiş -->
        <!-- Tap Başlangıc -->
        <div role="tabpanel" class="tab-pane" id="tum">
            <br />
            <!--Repeater -->
            <asp:Repeater ID="Repeater3" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th style="text-align: center;">Konu </th>
                                <th style="text-align: center;">Açıklama </th>
                                <th style="text-align: center;">Poster </th>
                                <th style="text-align: center;">İşlemler </th>
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
                            <div class="btn-group">
                                <button class="btn btn-default btn-sm dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    Tüm İşlemler <span class="caret"></span>
                                </button>
                                <ul class="dropdown-menu">
                                    <li>
                                        <asp:LinkButton ID="incBut" CommandName="incele" runat="server" CommandArgument='<%# Eval("Id") %>'>İncele</asp:LinkButton></li>
                                    <li>
                                        <a href="TezDuzenle.aspx?ID=<%#Eval("Id") %>">Düzenle</a></li>
                                    <li>
                                        <asp:LinkButton ID="RedBut" CommandName="Red" runat="server" CommandArgument='<%# Eval("Id") %>'>Sil</asp:LinkButton></li>
                                </ul>
                            </div>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody> </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <!-- Tap Bitiş -->
        <!-- Tap Başlangıc -->
        <div role="tabpanel" class="tab-pane" id="alinmayan">
            <br />
            <!--Repeater -->
            <asp:Repeater ID="Repeater4" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th style="text-align: center;">Konu </th>
                                <th style="text-align: center;">Açıklama </th>
                                <th style="text-align: center;">İşlemler </th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#metin_kisalt_yan(Eval("Konu").ToString().Trim()) %></td>
                        <td><%#metin_kisalt_yan(Eval("aciklama").ToString().Trim()) %></td>
                        <td>
                            <div class="btn-group">
                                <button class="btn btn-default btn-sm dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    Tüm İşlemler <span class="caret"></span>
                                </button>
                                <ul class="dropdown-menu">
                                    <li>
                                        <asp:LinkButton ID="incBut" CommandName="incele" runat="server" CommandArgument='<%# Eval("Id") %>'>İncele</asp:LinkButton></li>
                                    <li>
                                        <a href="TezDuzenle.aspx?ID=<%#Eval("Id") %>">Düzenle</a></li>
                                    <li>
                                        <asp:LinkButton ID="RedBut" CommandName="Red" runat="server" CommandArgument='<%# Eval("Id") %>'>Sil</asp:LinkButton></li>
                                </ul>
                            </div>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody> </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <!-- Tap Bitiş -->
        <!-- Tap Başlangıc -->
        <div role="tabpanel" class="tab-pane" id="biten">
            <br />
            <asp:Repeater ID="Repeater5" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th style="text-align: center;">Konu </th>
                                <th style="text-align: center;">Açıklama </th>
                                <th style="text-align: center;">Poster </th>
                                <th style="text-align: center;">İşlemler </th>
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
                            <div class="btn-group">
                                <button class="btn btn-default btn-sm dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    Tüm İşlemler <span class="caret"></span>
                                </button>
                                <ul class="dropdown-menu">
                                    <li>
                                        <asp:LinkButton ID="incBut" CommandName="incele" runat="server" CommandArgument='<%# Eval("Id") %>'>İncele</asp:LinkButton></li>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody> </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <!-- Tap Bitiş -->
    </div>
    <!-- Tab panel Bitiş -->
    <!-- Modal başlangıç-->
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
    <!-- Modal Bitiş -->
    <!-- Modal başlangıç-->
    <div class="modal fade" id="postermodal" tabindex="-1" role="dialog" aria-labelledby="postermodalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="postermodalLabel">Tez Afişi</h4>
                </div>
                <div class="modal-body">
                    <div id="posterDiv" runat="server">
                        <asp:Image ID="posterimage" Height="400" Width="275px   " runat="server" />
                    </div>
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
    <!-- Modal Bitiş -->
</asp:Content>

