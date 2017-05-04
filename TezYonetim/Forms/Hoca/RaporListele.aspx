<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Hoca/MasterPageHoca.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="RaporListele.aspx.cs" Inherits="Forms_Hoca_RaporListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
     <script type="text/javascript">
        $(function () {
            $('.modal-button').click(function () {
                //modalı aç;
                $('.modal').modal();
                //false return etmezsen sayfa navigate olur
                return false;
            });
        });
    </script>
    <table class="display"  id="students">
        <thead>
            <tr>
                <th style="text-align: center;">Id </th>
                <th style="text-align: center;">Numara </th>
                <th style="text-align: center;">İsim Soyisim </th>
                <th style="text-align: center;">E-Mail </th>
                <th style="text-align: center;">Bölüm </th>
                <th style="text-align: center;">Düzenle</th>
            </tr>
        </thead>
        <tbody>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                
                    <tr>
                        <td><%#Eval("Id") %></td>
                        <td><%#Eval("No") %></td>
                        <td><%#Eval("Ad") %></td>
                        <td><%#Eval("Mail") %></td>
                        <td><%#Eval("Bolum") %></td>
                        <td>
                            <asp:Button type="button" runat="server" OnCommand="Goster_Click"   CssClass="modal-button" CommandName="Goruntule" CommandArgument='<%#Eval("Id") %>' Text="Rapor Görüntüle" class="btn btn-primary"  />
                        </td>
                    </tr>

                
            </ItemTemplate>
        </asp:Repeater>
            </tbody>
    </table>
    <br />
 
    <%-- Modal başlangıç --%>
     <div class="modal fade" id="exampleModal2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Kapat"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="exampleModalLabel2">Rapor Yükleme</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Kapat</button>
                </div>
            </div>
        </div>
    </div>  
    <%-- Modal Bitiş --%>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#students').DataTable({
                "aLengthMenu": [[20, 40, 60, 100, -1], [20, 40, 60, 100, "Hepsi"]],
                "iDisplayLength": 20,
                "language": {
                    "sDecimal": ",",
                    "sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
                    "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
                    "sInfoEmpty": "Kayıt yok",
                    "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
                    "sInfoPostFix": "",
                    "sInfoThousands": ".",
                    "sLengthMenu": "Sayfada _MENU_ kayıt göster",
                    "sLoadingRecords": "Yükleniyor...",
                    "sProcessing": "İşleniyor...",
                    "sSearch": "Ara:",
                    "sZeroRecords": "Eşleşen kayıt bulunamadı",
                    "oPaginate": {
                        "sFirst": "İlk",
                        "sLast": "Son",
                        "sNext": "Sonraki",
                        "sPrevious": "Önceki"
                    },
                    "oAria": {
                        "sSortAscending": ": artan sütun sıralamasını aktifleştir",
                        "sSortDescending": ": azalan sütun soralamasını aktifleştir"
                    },
                    
                    
                }
            });
        });
    </script>
</asp:Content>

