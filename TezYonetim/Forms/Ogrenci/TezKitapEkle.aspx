<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Ogrenci/MasterPageUser.master" AutoEventWireup="true" CodeFile="TezKitapEkle.aspx.cs" Inherits="Forms_Ogrenci_PosterEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Poster Ekle</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="position: relative; margin: auto; width: 100%;">
        <div style="position: relative; margin: auto; width: 100%;">
            <div id="signupbox" style="margin-top: 30px" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <div class="panel-title">Poster Ekle</div>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <label for="name" class="col-md-3 control-label"></label>
                            <div class="col-md-9">
                                <input type="file" runat="server" id="filMyFile" />
                            </div>
                        </div>
                        <br>
                        <br>
                        <div class="form-group">
                            <asp:Button type="button" runat="server" OnClick="TezKitapEkle_Click" class="btn btn-primary" Text="Kaydet"></asp:Button>
                        </div>
                        <div class="form-group" style="text-align: left;">
                            <h6><i class="glyphicon glyphicon-info-sign"></i> Tez Kitabınız "word" dosyası olması gereklidir.</h6>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
