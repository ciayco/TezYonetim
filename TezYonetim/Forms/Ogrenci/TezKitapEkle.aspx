<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Ogrenci/MasterPageUser.master" AutoEventWireup="true" CodeFile="TezKitapEkle.aspx.cs" Inherits="Forms_Ogrenci_PosterEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Tez Kitap Ekle</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <ul class="nav nav-tabs" role="tablist">
        <li role="presentation" class="active"><a href="#goster" aria-controls="tumrapor" role="tab" data-toggle="tab">Tez Kitap Durumu</a></li>
        <li role="presentation"><a href="#ekle" aria-controls="vize" role="tab" data-toggle="tab">Tez Kitap Ekle</a></li>
    </ul>
    <!-- Tab panes -->
    <div class="tab-content">
        <div role="tabpanel" class="tab-pane active" id="goster">
            <br />
            <!--Onay bekleme -->
            <div id="bekleme" runat="server" visible="false">
                <table class="table table-striped">

                    <tr>
                        <th style="text-align: center;">Açıklama </th>
                        <th style="text-align: center;">Durum</th>
                    </tr>
                    <tr>
                        <td>
                            <asp:label id="DurumBekleme1" runat="server"></asp:label>
                        </td>
                        <td>
                            <asp:label id="DurumBekleme" runat="server"></asp:label>
                        </td>

                    </tr>
                </table>
            </div>
            <!--Onay bekleme-->

            <!--Onaylanmış-->
            <div id="onay" runat="server" visible="false">

                <table class="table table-striped">

                    <tr>
                        <th style="text-align: center;">Açıklama </th>
                        <th style="text-align: center;">Durum</th>
                    </tr>
                    <tr>
                        <td>
                            <asp:label id="DurumOnay1" runat="server"></asp:label>
                        </td>
                        <td>
                            <asp:label id="DurumOnay" runat="server"></asp:label>
                        </td>

                    </tr>
                </table>
            </div>
            <!--Onaylanmış-->

        </div>
        <div role="tabpanel" class="tab-pane" id="ekle">
            <br />
            <div style="position: relative; margin: auto; width: 100%;">
                <div style="position: relative; margin: auto; width: 100%;">
                    <div id="signupbox" style="margin-top: 30px" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                <div class="panel-title">Tez Kitap Ekle</div>
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
                                    <asp:button type="button" runat="server" onclick="TezKitapEkle_Click" class="btn btn-primary" text="Kaydet"></asp:button>
                                </div>
                                <div class="form-group" style="text-align: left;">
                                    <h6><i class="glyphicon glyphicon-info-sign"></i>Tez Kitabınız "word" dosyası olması gereklidir.</h6>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Tab Bitiş -->
</asp:Content>
