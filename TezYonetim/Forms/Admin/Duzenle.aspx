<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="Duzenle.aspx.cs" Inherits="Forms_Admin_Duzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="signupbox" style="margin-top: 50px" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
        <div class="panel panel-info">
            <div class="panel-heading">
                <div class="panel-title">Şifre Değiştir</div>
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <div style="text-align: center;">
                        <asp:Label ID="kullanici" runat="server"></asp:Label></div>
                </div>
                <div class="form-group">
                    <label for="name" class="col-md-3 control-label">Şifre</label>
                    <div class="col-md-9">
                        <asp:TextBox ID="sifre" class="form-control" runat="server" placeholder="Şifre Giriniz" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <br />
                <br />
                <div class="form-group">
                    <label for="sifre" class="col-md-3 control-label">Şifre Tekrar</label>
                    <div class="col-md-9">
                        <asp:TextBox ID="sifretekrar" class="form-control" runat="server" placeholder="Şifre tekrar giriniz" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <div style="text-align: center;">
                        <asp:Label ID="Label1" runat="server"></asp:Label></div>
                </div>
                <br />
                <div class="form-group">
                    <!-- Button -->
                    <asp:Button ID="btnGiris" runat="server" Text="Şifre Değiştir" class="btn btn-info col-lg-2 btn-block" OnClick="btnGiris_Click" />

                </div>
            </div>
        </div>
    </div>
</asp:Content>

