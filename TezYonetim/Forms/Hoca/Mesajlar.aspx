<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Hoca/MasterPageHoca.master" AutoEventWireup="true" CodeFile="Mesajlar.aspx.cs" Inherits="Forms_Hoca_Mesajlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Gelen Kutusu</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <div class="panel panel-default">
        <div class="panel-heading">
            <div style="text-align: center;">
                <h5>Gelen Mesaj Kutusu</h5>
            </div>
            <div style="text-align: right;"><a href="MesajGonder.aspx">Yeni Mesaj Gönder</a></div>
        </div>
        <div class="panel-body" style="text-align: left;">
            <div class="panel panel-default">
                <div class="panel-footer" style="text-align: left;">
                    <div id="dolumsg" runat="server">
                        <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                                <div class="alert alert-success" style="font-size: 12px; text-align: left" role="alert">
                                    <%#Eval("Gadi")%> <i style="text-align: right; float: right;"><%#Eval("MsjTarih") %></i>
                                    <br />
                                    <a style="text-decoration: none; color: green" href="MesajGoster.aspx?ID=<%#Eval("Id") %>">
                                        <div id="ana" style="width: 100%">
                                            <div id="sol" style="width: 20%; float: left;"><%#metin_kisalt_sol(Eval("MsjBaslik").ToString().Trim()) %></div>
                                            <div id="orta" style="width: 20%; float: left;">&nbsp;</div>
                                            <div id="sag" style="width: 60%; float: left;"><%#metin_kisalt_sag(Eval("MsjText").ToString().Trim()) %></div>
                                        </div>
                                    </a>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div id="bosmsg" runat="server" visible="false">
                        <asp:Label ID="Label5" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

