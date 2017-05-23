<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Forms/Ogrenci/MasterPageUser.master" EnableEventValidation="false" CodeFile="index.aspx.cs" Inherits="User" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <title>AnaSayfa</title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <script type="text/javascript">
        $(function () {
            $('.modal-button').click(function () {
                //modalı aç;
                $('.modal').modal();
                //false return etmezsen sayfa navigate olur
                return false;
            });
        });
    </script>
    <div class="col-sm-3" style="float: left; width: 25%;">
        <!--left col-->
        <ul class="list-group">
            <li id="mainPagePanelHeaderBG1" class="list-group-item text-muted active">
                <div style="display: inline;">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </div>
            </li>
            <li class="list-group-item text-right"><span class="pull-left">
                <i class="fa fa-user fa-1x" title="Adı Soyadı"></i></span>
                <asp:Label ID="Label2" runat="server"></asp:Label></li>

            <li class="list-group-item text-right"><span class="pull-left">
                <i class="fa fa-briefcase fa-1x" title="Bağlı olduğu birim"></i></span>
                <span>
                    <asp:Label ID="Label3" runat="server"></asp:Label></span></li>

            <li class="list-group-item text-right"><span class="pull-left">
                <i class="fa fa-bookmark fa-1x" title="Sicil No veya Öğrenci No"></i></span>
                <asp:Label ID="Label4" runat="server"></asp:Label></li>

            <li class="list-group-item text-right"><span class="pull-left">
                <i class="fa fa-briefcase fa-1x" title="Danışman Hoca"></i></span>
                <span>
                    <asp:Label ID="Label7" runat="server"></asp:Label></span></li>

            <li class="list-group-item text-right"><span class="pull-left">
                <i class="fa fa-tag fa-1x" title="Tez durumu"></i></span>
                <asp:Label ID="Label5" runat="server"></asp:Label></li>

            <li class="list-group-item text-right"><span class="pull-left">
                <i class="fa fa-envelope fa-1x" title="E-posta adresi"></i></span>
                <asp:Label ID="Label6" runat="server"></asp:Label></li>
        </ul>
    </div>
    <%-- Boşluk divi --%>
    <div style="float: left; width: 5%;"></div>

    <%-- Tab Başlangıc --%>
    <div style="float: left; width: 70%;">
        <!-- Nav tabs -->
        <ul class="nav nav-tabs" role="tablist">
            <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Duyuru</a></li>
            <li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">İşlemler</a></li>
            <li role="presentation"><a href="#messages" aria-controls="messages" role="tab" data-toggle="tab">Boş Alan 1</a></li>
            <li role="presentation"><a href="#settings" aria-controls="settings" role="tab" data-toggle="tab">Boş Alan 2</a></li>
        </ul>

        <!-- Tab panes -->
        <div class="tab-content">
            <div role="tabpanel" class="tab-pane active" id="home">
                <div class="panel panel-default">
                    <div class="panel-heading">Duyurular</div>
                    <div class="panel-body" style="text-align: left;">
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>

                                <i class="glyphicon glyphicon-bullhorn">&nbsp;</i>
                                <asp:LinkButton ID="LinkButton1" OnCommand="LinkButton1_Click" CommandName="duyuru" CommandArgument='<%#Eval("Id") %>' runat="server"><%#metin_kisalt_yan(Eval("Duyuru_Tarih").ToString().Trim()) %> - <%#metin_kisalt_yan(Eval("Duyuru_Baslik").ToString().Trim()) %> </asp:LinkButton>
                                <br />
                                <br />

                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <div role="tabpanel" class="tab-pane" id="profile">
                <br />
                <br />
                <form>
                    <div style="width: 70%; padding-left: 10%;">
                        <div class="form-group">
                            <asp:TextBox ID="Password" TextMode="Password" placeholder="Eski Şifre" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="Password1" TextMode="Password" placeholder="Yeni Şifre" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="Password2" TextMode="Password" placeholder="Yeni şifre Tekrar" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <asp:Button ID="Button1" class="btn btn-primary" OnClick="Password_Click" runat="server" Text="Şifre Güncelle" />
                </form>
            </div>
            <div role="tabpanel" class="tab-pane" id="messages">asdasdsad    </div>
            <div role="tabpanel" class="tab-pane" id="settings">.qweqweqwe.</div>
        </div>
        <!-- Tab Bitiş -->
    </div>
    <%-- Modal Başlangıc--%>
    <div class="modal fade" id="exampleModal4" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Kapat"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="exampleModalLabel2">Duyuru ayrıntılar</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <asp:Label ID="Label8" runat="server"></asp:Label><br />
                        <br />
                        <asp:Label ID="Label9" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Kapat</button>
                </div>
            </div>
        </div>
    </div>
    <%-- Modal Bitiş--%>
   
</asp:Content>
