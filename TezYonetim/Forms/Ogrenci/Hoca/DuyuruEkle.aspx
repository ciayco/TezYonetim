<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Hoca/MasterPageHoca.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="DuyuruEkle.aspx.cs" Inherits="Forms_Hoca_DuyuruEkle" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <title>Duyuru Ekle</title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="position: relative; margin: auto; width: 100%;">
        <div style="position: relative; margin: auto; width: 100%;">
            <div id="signupbox" style="margin-top: 50px" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <div class="panel-title">Duyuru Ekle</div>
                    </div>
                    <form id="signupform" class="form-horizontal" role="form">
                        <div class="panel-body">
                            <div id="signupalert" style="display: none" class="alert alert-danger">
                                <p>Error:</p>
                                <span></span>
                            </div>
                            <br />
                            <br />
                            <div class="form-group">
                                <label for="name" class="col-md-3 control-label">Başlık</label>
                                <div class="col-md-9">
                                    <input type="text" class="form-control" name="Baslik" placeholder="Baslik">
                                </div>
                            </div>
                            <br />
                            <br />
                            <div class="form-group">
                                <label for="bolum" class="col-md-3 control-label">Duyuru</label>
                                <div class="col-md-9">
                                    <textarea class="form-control" rows="5" name="Duyuru" placeholder="Duyuru"></textarea>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-9">
                                    <p>
                                        <asp:Label ID="LabelSignUP" runat="server" ForeColor="Red"></asp:Label>
                                    </p>
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                                <!-- Button -->
                                <div class="col-md-offset-3 col-md-9">
                                    <asp:Button ID="btnGiris" runat="server" Text="Kayit" class="btn btn-info" OnClick="btnGiris_Click" />
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
