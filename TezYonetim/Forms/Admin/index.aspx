<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/MasterPageAdmin.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Forms_Admin_İndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Admin Anasayfa </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <br />
    <br />
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
                <i class="fa fa-envelope fa-1x" title="E-posta adresi"></i></span>
                <asp:Label ID="Label4" runat="server"></asp:Label></li>
        </ul>
    </div>
    <%-- Boşluk divi --%>
    <div style="float: left; width: 5%;"></div>

    <%-- Tab Başlangıc --%> 
    <div style="float: left; width: 70%;">
        <!-- Nav tabs -->
        <ul class="nav nav-tabs" role="tablist">
            <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Şifre İşlemleri</a></li>
            <li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">Diğer</a></li>
        </ul>

        <!-- Tab panes -->
        <div class="tab-content">
            <div role="tabpanel" class="tab-pane active" id="home">
               <br />
                <br />
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
            </div>
            <div role="tabpanel" class="tab-pane" id="profile">
               
            </div>
            
        </div>
        <!-- Tab Bitiş -->
    </div>

</asp:Content>

