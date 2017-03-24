
<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Hoca/MasterPageHoca.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Duzenle.aspx.cs" Inherits="Duzenle"%>

  

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <title>Kullanıcı Düzenle</title>
      <!-- Bootstrap Core CSS -->
    <link href="~/css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="~/css/sb-admin.css" rel="stylesheet">

    <!-- Morris Charts CSS -->
    <link href="~/css/plugins/morris.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
</asp:Content>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
        <div class="container">    
        <div id="signupbox" style="margin-top:50px" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <div class="panel-title">Sign Up</div>
                        </div>  
                        <div class="panel-body" >
                            <form id="signupform" class="form-horizontal" role="form" >
                                
                                <div id="signupalert" style="display:none" class="alert alert-danger">
                                    <p>Error:</p>
                                    <span></span>
                                </div>

                               <div class="form-group">
                                    <label for="no" class="col-md-3 control-label">Öğrenci No</label>
                                    <div class="col-md-9">
                                        <asp:TextBox id="TextBox1" runat="server"  ></asp:TextBox>
                                        
                                    </div>
                                </div>
                                    
                                <div class="form-group">
                                    <label for="name" class="col-md-3 control-label">Ad</label>
                                    <div class="col-md-9">
                                        <asp:TextBox id="TextBox2" runat="server"  ></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="e-mail" class="col-md-3 control-label">E-Mail</label>
                                    <div class="col-md-9">
                                         <asp:TextBox id="TextBox4" runat="server"  ></asp:TextBox>
                                    </div>
                                </div>
                                    
                                <div class="form-group">
                                    <label for="bolum" class="col-md-3 control-label">Bölüm</label>
                                    <div class="col-md-9">
                                         <asp:TextBox id="TextBox5" runat="server"  ></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-9">
                                        <p><asp:Label ID="LabelGuncelle" runat="server" ForeColor="Red"></asp:Label></p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <!-- Button -->                                        
                                    <div class="col-md-offset-3 col-md-9">
                                        
                                        <asp:Button ID="btnGuncelle" runat="server" Text="Düzenle" class="btn btn-info" OnClick="btnGuncelle_Click"/>
                                        
                                    </div>
                                </div>                         
                            </form>
                         </div>
                       </div> 
                    </div>
            </div>
</asp:Content>
