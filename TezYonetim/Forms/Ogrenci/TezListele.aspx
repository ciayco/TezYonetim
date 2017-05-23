<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Forms/Ogrenci/MasterPageUser.master" EnableEventValidation="false" CodeFile="TezListele.aspx.cs" Inherits="TezListele" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">

    <title>Tez Görüntüle</title>


</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <div class="panel panel-default">
        <div class="panel-heading">Tezim</div>
        <div class="panel-body">
             <div class="panel-body" style="text-align: left;">
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <div style="text-align: left; float: left;">
                                    <i class="glyphicon glyphicon-text-background">&nbsp;</i>
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                </div>
                                
                            </div>
                            <div class="panel-footer" style="text-align: left;">
                                <i class="glyphicon glyphicon-user">&nbsp;</i>Tezi Alan Öğrenciler:
                                <asp:Repeater ID="Repeater2" runat="server">

                                    <ItemTemplate>
                                        <a href="#"><%#Eval("Ad") %></a>
                                    </ItemTemplate>
                                </asp:Repeater>


                                <blockquote style="font-size: 14px;">
                                    <asp:Label ID="Label2" runat="server"></asp:Label>
                                </blockquote>
                            </div>
                        </div>
                    </div>
        </div>
    </div>
</asp:Content>
