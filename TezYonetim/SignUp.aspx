<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>



<!DOCTYPE html>
<html lang="tr">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>SB Admin - Bootstrap Admin Template</title>

    <!-- Bootstrap Core CSS -->
    <link href="../../css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="../../css/sb-admin.css" rel="stylesheet">

    <!-- Morris Charts CSS -->
    <link href="../../css/plugins/morris.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="../../font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
</head>

<body>
 
<%-- Body  başlangıc  --%>



        <div class="container">    
        <div id="signupbox" style="margin-top:50px" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <div class="panel-title">Kayıt Ol</div>
                            <div style="float:right; font-size: 80%; position: relative; top:-10px"><a href="Default.aspx">Kullanıcı Girişi</a></div>
                        </div>  
                        <div class="panel-body" >
                            <form id="signupform" runat="server" class="form-horizontal" role="form" >
                                
                                <div id="signupalert" style="display:none" class="alert alert-danger">
                                    <p>Error:</p>
                                    <span></span>
                                </div>

                               <div class="form-group">
                                    <label for="no" class="col-md-3 control-label">Öğrenci No</label>
                                    <div class="col-md-9">
                                        <input type="text" class="form-control" name="No" placeholder="Öğrenci No">
                                    </div>
                                </div>
                                    
                                <div class="form-group">
                                    <label for="name" class="col-md-3 control-label">Ad</label>
                                    <div class="col-md-9">
                                        <input type="text" class="form-control" name="Name" placeholder="First Name">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="sifre" class="col-md-3 control-label">Şifre</label>
                                    <div class="col-md-9">
                                        <input type="password" class="form-control" name="Sifre" placeholder="Şifre">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="e-mail" class="col-md-3 control-label">E-Mail</label>
                                    <div class="col-md-9">
                                        <input type="email" class="form-control" name="E-mail" placeholder="E-Mail">
                                    </div>
                                </div>
                                    
                                <div class="form-group">
                                    <label for="bolum" class="col-md-3 control-label">Bölüm</label>
                                    <div class="col-md-9">
                                        <input type="text" class="form-control" name="Bolum" placeholder="Bölüm">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-9">
                                        <p><asp:Label ID="LabelSignUP" runat="server" ForeColor="Red"></asp:Label></p>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <!-- Button -->                                        
                                    <div class="col-md-offset-3 col-md-9">
                                        
                                        <asp:Button ID="btnGiris" runat="server" Text="Kayit" class="btn btn-info" OnClick="btnGiris_Click"/>
                                        
                                    </div>
                                </div>                         
                            </form>
                         </div>
                       </div> 
                    </div>

            </div>

<%--  Body  bitiş--%>

 <script src="../../js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="../../js/bootstrap.min.js"></script>

    <!-- Morris Charts JavaScript -->
    <script src="../../js/plugins/morris/raphael.min.js"></script>
    <script src="../../js/plugins/morris/morris.min.js"></script>
    <script src="../../js/plugins/morris/morris-data.js"></script>

</body>

</html>

