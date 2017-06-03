<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Hoca/MasterPageHoca.master" AutoEventWireup="true" enableEventValidation="false" CodeFile="TezDuzenle.aspx.cs" Inherits="Forms_Hoca_TezDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div style="position: relative; margin: auto; width: 100%;">
        <div style="position: relative; margin: auto; width: 100%;">
            <div id="signupbox" style="margin-top: 30px" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <div class="panel-title">Tez Ekle</div>
                    </div>
                    <form id="signupform" class="form-horizontal" role="form">
                        <div class="panel-body">
                            <div id="signupalert" style="display: none" class="alert alert-danger">
                                <p>Error:</p>
                                <span></span>
                            </div>
                            <div class="form-group">
                                <label for="name" class="col-md-3 control-label">Konu: </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="konu" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <br>
                            <br>
                            <div class="form-group" style="padding-top:10px;">
                                <label for="comment" class="col-md-3 control-label">Açıklama: </label>
                                <div class="col-md-9">
                                   <asp:TextBox ID="aciklama" runat="server" class="form-control"  TextMode="MultiLine" Height="150px"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group" style="padding-top:150px;">
                                <label for="name" class="col-md-3 control-label">Öğrenci Sayısı: </label>
                                <div class="col-md-9">
                                   <asp:TextBox ID="sayi" runat="server" class="form-control" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-9">
                                    <p>
                                        <asp:Label ID="uyari" runat="server" ForeColor="Red"></asp:Label>
                                    </p>
                                </div>
                            </div><br /><br />
                            <div class="form-group">
                                <!-- Button -->
                                <div class="col-md-offset-3 col-md-9">

                                    <asp:Button ID="btnGiris" runat="server" Text="  Kayit  " class="btn btn-info" OnClick="btnGiris_Click" />

                                </div>
                            </div>

                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

