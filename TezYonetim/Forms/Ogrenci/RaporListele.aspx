<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Ogrenci/MasterPageUser.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="RaporListele.aspx.cs" Inherits="Forms_Ogrenci_RaporListele" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <title>Rapor Görüntüle</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br>
    <script type="text/javascript">
        $(function () {
            $('.modal-button').click(function () {
                //modal içindeki labelin textine data-id değerini ver
                //$('.hiddenfield1').val($(this).attr('data-id'));
                $("#exampleModal2").find("input[type='hidden']").val($(this).attr("data-id"));
                //modalı aç;
                $('.modal').modal();
                //false return etmezsen sayfa navigate olur
                return false;
            });
        });
    </script>
    <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="panel panel-primary">
                    <div class="panel-heading" role="tab" id="headingTwo">
                        <h6 class="panel-title" style="text-align: left;">
                            <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#<%#Eval("Id") %>" aria-expanded="false" aria-controls="<%#Eval("Id") %>"> Rapor <%=++sayac%>                       
                            </a>
                        </h6>
                    </div>
                    <div id="<%#Eval("Id") %>" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                        <div class="panel-body" style="text-align: left;">
                           <b>Rapor Başlangıç Tarihi</b> = <%#Eval("RaporBas") %><br />
                            <b>Rapor Bitiş Tarihi </b> = <%#Eval("RaporBit") %><br />
                            <br />
                            <span class="btn btn-primary">
                                <asp:Button type="button" runat="server" OnCommand="Rapor_goruntule_Click" CommandName="Goruntule" CommandArgument='<%#Eval("Id") %>' Text="Rapor Görüntüle" BorderStyle="None" BackColor="#337AB7" /></span>&nbsp;&nbsp;                          
                            <span class="btn btn-primary">
                                <asp:Button ID="makdes" class="btn btn-primary" data-id='<%#Eval("Id") %>' CssClass="modal-button" runat="server" Text="Rapor Ekle" BackColor="#337AB7" BorderStyle="None" /></span><br />
                            <h6><i class="glyphicon glyphicon-info-sign"> </i>Rapor dosyalarınız "pdf" yada "word" dosyası olması gereklidir.</h6>
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
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Kapat</button>
                    <asp:Button ID="buton123" type="button" runat="server" OnCommand="Rapor_Yukle_Click" class="btn btn-primary" Text="Kaydet" CommandName="Kaydet"></asp:Button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

