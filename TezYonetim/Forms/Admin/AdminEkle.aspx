<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/MasterPageAdmin.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="AdminEkle.aspx.cs" Inherits="Forms_Admin_AdminEkle" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <title>Admin Ekle</title>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="position: relative; margin: auto; width: 100%;">
        <div style="position: relative; margin: auto; width: 100%;">
            <div id="signupbox" style="margin-top: 50px" class="mainbox col-md-6 col-md-offset-3 col-sm-6 col-sm-offset-2">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <div class="panel-title">Kayıt Ol</div>
                    </div>
                    <br />
                    <div class="panel-body">
                        <div id="signupalert" style="display: none" class="alert alert-danger">
                            <p>Error:</p>
                            <span></span>
                        </div>
                        <div class="form-group">
                            <label for="name" class="col-md-3 control-label">Ad</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" name="Name" placeholder="Kullanıcı Adı">
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="form-group">
                            <label for="sifre" class="col-md-3 control-label">Şifre</label>
                            <div class="col-md-9">
                                <input type="password" class="form-control" name="Sifre" placeholder="Şifre">
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="form-group">
                            <label for="e-mail" class="col-md-3 control-label">E-Mail</label>
                            <div class="col-md-9">
                                <input type="email" class="form-control" name="E-mail" placeholder="E-Mail">
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="form-group">
                            <div class="col-md-9">
                                <p>
                                    <asp:Label ID="LabelSignUP" runat="server" ForeColor="Red"></asp:Label>
                                </p>
                            </div>
                        </div>
                        <div class="form-group">
                            <!-- Button -->
                            <div class="col-md-offset-3 col-md-9">
                                <asp:Button ID="btnGiris" runat="server" Text="Kayit" class="btn btn-info" OnClick="btnGiris_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
