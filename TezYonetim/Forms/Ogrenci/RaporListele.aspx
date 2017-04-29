<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Ogrenci/MasterPageUser.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="RaporListele.aspx.cs" Inherits="Forms_Ogrenci_RaporListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br>
    <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="headingTwo">
                        <h6 class="panel-title" style="text-align: left;">
                            <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#<%#Eval("Id") %>" aria-expanded="false" aria-controls="<%#Eval("Id") %>"><%#Eval("RaporBas") %> - <%#Eval("RaporBit") %>                          
                            </a>
                        </h6>
                    </div>
                    <div id="<%#Eval("Id") %>" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">                     
                        <div class="panel-body" style="text-align: left;">
                           
                            Rapor id = <%#Eval("Id") %><br />
                            Danışman Hoca =<%#Eval("Hoca_Id") %><br />
                            Rapor Başlangıç = <%#Eval("RaporBas") %><br />
                            Rapor Biriş = <%#Eval("RaporBit") %><br />
                            <br />
                            <asp:Button type="button" runat="server" OnClick="Rapor_goruntule_Click" class="btn btn-primary" Text="Rapor Görüntüle"/>&nbsp;&nbsp;
                            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal2" data-whatever="@mdo">Rapor Ekle</button>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
    </div>    
    <div class="modal fade" id="exampleModal2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Kapat"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="exampleModalLabel2">Rapor Yükleme</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <input type="file" runat="server" id="filMyFile" />
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Kapat</button>
                    <asp:Button type="button" runat="server" OnCommand="Rapor_Yukle_Click" class="btn btn-primary" Text="Kaydet" CommandName="Kaydet" CommandArgument='<%# Eval("Id") %>'></asp:Button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

