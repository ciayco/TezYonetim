<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Forms/Ogrenci/MasterPageUser.master" EnableEventValidation="false"  CodeFile="TezSec.aspx.cs" Inherits="TezSec" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">

    <title>Tez Seçimi</title>
   
    
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <div runat="server" id="sec" visible="false">
              <!--Tez Seçimi -->
          <!--Repeater -->
          <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
          <HeaderTemplate>
          <table class="table table-striped">
               <thead>
                  <tr>
                          <th style="text-align:center;">Konu </th>
                          <th style="text-align:center;">Aciklama</th>    
                  </tr>
                    </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate> 
            <tr>
                <td><%#metin_kisalt_yan(Eval("Konu").ToString().Trim()) %></td>
                <td><%#metin_kisalt_yan(Eval("Aciklama").ToString().Trim()) %></td>
                 <td>
                    <asp:Button ID="incBut" CommandName="incele" Text="İncele" runat="server" class="btn btn-success btn-xs btn-round" CommandArgument='<%# Eval("Id") %>' />
                </td>
                <td>
                    <asp:Button ID="SecBut" CommandName="Sec" class="btn btn-primary btn-xs btn-round" Text="Seç" runat="server" CommandArgument='<%# Eval("Id") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody> </table>
        </FooterTemplate>
    </asp:Repeater>
           <!--Repeater -->
    </div>
    <!--Tez Seçimi -->
     <!--Onay bekleme -->
    <div id="bekleme" runat="server" visible="false">
         <table class="table table-striped">
             
            <tr>                
                <th style="text-align:center;">Konu </th>
                <th style="text-align:center;">Aciklama</th>
                <th style="text-align:center;">Durum</th>    
            </tr>                 
            <tr>           
                <td><asp:Label ID="DurumBekleme1" runat="server"></asp:Label></td>
                <td><asp:Label ID="DurumBekleme2" runat="server"></asp:Label></td>
                <td><asp:Label ID="DurumBekleme" runat="server"></asp:Label></td>
                
            </tr>
        </table>
    </div>
     <!--Onay bekleme-->
        <!--Danışman bekleme -->
    <div id="danisman" runat="server" visible="false">
         <table class="table table-striped">
             
            <tr>                
                <th style="text-align:center;">Durum</th>    
            </tr>                 
            <tr>           
                <td><asp:Label ID="danismanOnay" runat="server"></asp:Label></td>
               
                
            </tr>
        </table>
    </div>
     <!--Danışman bekleme-->
    <!--Onaylanmış-->
    <div id="onay" runat="server" visible="false">

        <table class="table table-striped">
             
            <tr>                
                <th style="text-align:center;">Konu </th>
                <th style="text-align:center;">Aciklama</th>
                <th style="text-align:center;">Durum</th>    
            </tr>                 
            <tr>           
                <td><asp:Label ID="DurumOnay1" runat="server"></asp:Label></td>
                <td><asp:Label ID="DurumOnay2" runat="server"></asp:Label></td>
                <td><asp:Label ID="DurumOnay" runat="server"></asp:Label></td>
                
            </tr>
        </table>
    </div>
 <!--Onaylanmış-->
        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="exampleModalLabel">Tez Ayrıntıları</h4>
                </div>
                <div class="modal-body">
                    <div class="panel-body" style="text-align: left;">
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <div style="text-align: left; float: left;">
                                    <i class="glyphicon glyphicon-text-background">&nbsp;</i>
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                </div>
                                <div style="text-align: right; float: right">
                                    <i class="glyphicon glyphicon-user">&nbsp;</i><asp:Label ID="Label3" runat="server"></asp:Label><br />
                                </div>
                            </div>
                            <div class="panel-footer" style="text-align: left;">
                                <i class="glyphicon glyphicon-user">&nbsp;</i>Tezi Alan Öğrenciler:
                                <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater1_ItemCommand">

                                    <ItemTemplate>
                                        <a href="#"><%#Eval("Ad") %></a>
                                    </ItemTemplate>
                                </asp:Repeater>


                                <blockquote style="font-size: 14px;">
                                    <asp:Label ID="Label5" runat="server"></asp:Label>
                                </blockquote>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Kapat</button>
                </div>
            </div>
        </div>
    </div>
    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>


      <!-- Morris Charts JavaScript -->

    <script src="../../js/plugins/morris/raphael.min.js"></script>
    <script src="../../js/plugins/morris/morris.min.js"></script>
    <script src="../../js/plugins/morris/morris-data.js"></script>
    
</asp:Content>