<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Ogrenci/MasterPageUser.master" AutoEventWireup="true" CodeFile="MesajGoster.aspx.cs" Inherits="Forms_Ogrenci_MesajGoster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Mesaj Oku</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
   <div class="panel panel-default">
          <div class="panel-heading">
            <div style="text-align: center;">
                <h5>Mesajları Oku</h5>
            </div>
            <div style="text-align: right;"><a href="MesajGonder.aspx">Yeni Mesaj Gönder</a></div>
        </div>
        <div class="panel-body" style="text-align: left;">
            <div class="panel panel-default" id="dolumsg" runat="server">
                <div class="panel-body">
                    <div style="text-align: left; float: left;">
                        <i class="glyphicon glyphicon-envelope">&nbsp;</i>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </div>
                    <div style="text-align: right; float: right">
                        <asp:Label ID="Label4" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="panel-footer" style="text-align: left;">
                    <i class="glyphicon glyphicon-user">&nbsp;</i><asp:Label ID="Label3" runat="server"></asp:Label><br />
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </div>
            </div>
            <div id="bosmsg" runat="server" visible="false">
                <asp:Label ID="Label5" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

