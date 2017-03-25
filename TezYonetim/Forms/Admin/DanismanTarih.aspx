<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/MasterPageAdmin.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="DanismanTarih.aspx.cs" Inherits="Forms_Admin_DanismanTarih" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <br />
    <br />
    <div class="container">
        <div id="signupbox" style="margin-top: 50px" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <div class="panel-title">Danışman Hoca Seçim Tarihi Ekle</div>
                </div>
                <form id="signupform" class="form-horizontal" role="form">
                    <div class="panel-body">


                        <div id="signupalert" style="display: none" class="alert alert-danger">
                            <p>Error:</p>
                            <span></span>
                        </div> <br>
                        <div class="form-group">
                            <label for="name" class="col-md-3 control-label">Başlangıç</label>
                            <div class="col-md-9">
                                <asp:TextBox id="DBas" type="datetime-local" class="form-control" name="DBas"  runat="server" ></asp:TextBox>                               
                            </div>
                        </div>
                        <br> <br> <br>
                        <div class="form-group">
                              <label for="comment" class="col-md-3 control-label">Bitiş</label>
                            <div class="col-md-9">
                             <asp:TextBox id="DBit" type="datetime-local" class="form-control" name="DBit"  runat="server" ></asp:TextBox>    
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

                                <asp:Button ID="btnGiris" runat="server" Text=" Kayit " class="btn btn-info" OnClick="btnGiris_Click" />

                            </div>
                        </div>
                        
                    </div>
                </form>
            </div>
        </div>
    </div>
<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br /><br />
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
</asp:Content>

