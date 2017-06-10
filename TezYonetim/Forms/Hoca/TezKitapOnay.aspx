<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Hoca/MasterPageHoca.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="TezKitapOnay.aspx.cs" Inherits="Admin" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <title>Tez Kitap Onay</title>

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
                            <th></th>
                            <th></th>
                            <th style="text-align: center;">İncele</th>
                            <th style="text-align: center;">Reddet</th>
                            <th style="text-align: center;">Onayla</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#metin_kisalt_yan(Eval("id").ToString().Trim()) %></td>
                    <td></td>
                    <td></td>
                    <td>
                        <asp:Button ID="incBut" CommandName="incele" Text="İncele" runat="server" class="btn btn-success btn-xs btn-round" CommandArgument='<%# Eval("Id") %>' />
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
                                    <asp:Label ID="Label4" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="panel-footer" style="text-align: left;">
                                <i class="glyphicon glyphicon-user">&nbsp;</i><asp:Label ID="Label3" runat="server"></asp:Label><br />
                                <blockquote>
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

</asp:Content>

