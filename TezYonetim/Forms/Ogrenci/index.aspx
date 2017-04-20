<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Forms/Ogrenci/MasterPageUser.master" EnableEventValidation="false"  CodeFile="index.aspx.cs" Inherits="User" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">

    <title>AnaSayfa</title>
   
    
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
   <h3>Öğrenci Anasayfa</h3>
           <div class="col-sm-3">
                <!--left col-->
                <ul class="list-group">
                    <li id="mainPagePanelHeaderBG1" class="list-group-item text-muted active">
                        <div style="display:inline;">
                            <asp:Label ID="Label1" runat="server" ></asp:Label> </div>
                    </li>
                    <li class="list-group-item text-right"><span class="pull-left">
                        <i class="fa fa-user fa-1x" title="Adı Soyadı"></i></span>
                         <asp:Label ID="Label2" runat="server" ></asp:Label></li>

                    <li class="list-group-item text-right"><span class="pull-left">
                        <i class="fa fa-briefcase fa-1x" title="Bağlı olduğu birim"></i></span>
                        <span><asp:Label ID="Label3" runat="server" ></asp:Label></span></li>

                    <li class="list-group-item text-right"><span class="pull-left">
                        <i class="fa fa-bookmark fa-1x" title="Sicil No veya Öğrenci No"></i></span>
                        <asp:Label ID="Label4" runat="server" ></asp:Label></li>

                    <li class="list-group-item text-right"><span class="pull-left">
                        <i class="fa fa-tag fa-1x" title="Tez durumu"></i></span>
                        <asp:Label ID="Label5" runat="server" ></asp:Label></li>

                    <li class="list-group-item text-right"><span class="pull-left">
                        <i class="fa fa-envelope fa-1x" title="E-posta adresi"></i></span>
                        <asp:Label ID="Label6" runat="server" ></asp:Label></li>                  
                </ul>

                

                
            </div>
       
</asp:Content>
