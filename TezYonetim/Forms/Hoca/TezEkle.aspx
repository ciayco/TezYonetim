<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Hoca/MasterPageAdmin.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="TezEkle.aspx.cs" Inherits="TezEkle" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <title>Tez Ekle</title>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <div class="container">
        <div id="signupbox" style="margin-top: 50px" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <div class="panel-title">Kayıt Ol</div>
                </div>
                <form id="signupform" class="form-horizontal" role="form">
                    <div class="panel-body">


                        <div id="signupalert" style="display: none" class="alert alert-danger">
                            <p>Error:</p>
                            <span></span>
                        </div>
                        <div class="form-group">
                            <label for="name" class="col-md-3 control-label">Ad</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" name="Konu" placeholder="Ad">
                            </div>
                        </div>
                        <br> <br> <br>
                        <div class="form-group">
                              <label for="comment" class="col-md-3 control-label">Comment:</label>
                            <div class="col-md-9">
                              <textarea class="form-control" rows="5" id="comment" name="Aciklama"></textarea>
                            </div>
                        </div>
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
                </form>
            </div>
        </div>
    </div>
</asp:Content>
