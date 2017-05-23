<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Hoca/MasterPageHoca.master" AutoEventWireup="true" CodeFile="MesajGoster.aspx.cs" Inherits="Forms_Hoca_MesajGoster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Mesaj Oku</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4>Mesajları Oku</h4>
        </div>
        <div class="panel-body" style="text-align: left;">
            <div class="panel panel-default">
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
        </div>
    </div>
</asp:Content>

