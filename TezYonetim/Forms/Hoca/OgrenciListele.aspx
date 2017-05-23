<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Hoca/MasterPageHoca.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="OgrenciListele.aspx.cs" Inherits="Admin" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <title>Öğrenci Görüntüle</title>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <table class="display" id="students">
        <thead>
            <tr>
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
                        <td><%#Eval("No") %></td>
                        <td><%#Eval("Ad") %></td>
                        <td><%#Eval("Mail") %></td>
                        <td><%#Eval("Bolum") %></td>
                        <td>
                            <div class="btn-group">
                                <button class="btn btn-default btn-sm dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    İşlemler <span class="caret"></span>
                                </button>
                                <ul class="dropdown-menu">
                                    <li><a href="OgrenciListele.aspx?ID=<%#Eval("Id") %>">İncele</a></li>
                                    <li><a href="#">işlem 2</a></li>
                                </ul>
                            </div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <br />
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="exampleModalLabel">Öğrenci Bilgileri</h4>
                </div>
                <div class="modal-body">
                    <div class="panel-body" style="text-align: left;">
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <div style="text-align: left; float: left;">
                                    <i class="glyphicon glyphicon-user">&nbsp;</i>
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                </div>
                                <div style="text-align: right; float: right">
                                    <asp:Label ID="Label4" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="panel-footer" style="text-align: left;">
                                <blockquote style="font-size: 14px;">
                                    <i class="fa fa-bookmark fa-1x" title="Sicil No veya Öğrenci No">&nbsp;&nbsp;</i><asp:Label ID="Label2" runat="server"></asp:Label><br />
                                    <br />
                                    <i class="fa fa-envelope fa-1x" title="E-posta adresi">&nbsp;&nbsp;</i><asp:Label ID="Label3" runat="server"></asp:Label><br />
                                    <br />
                                    <i class="fa fa-briefcase fa-1x" title="Bağlı olduğu birim">&nbsp;&nbsp;</i><asp:Label ID="Label5" runat="server"></asp:Label><br />
                                    <br />
                                    <i class="fa fa-tag fa-1x" title="Tez durumu">&nbsp;&nbsp;</i><asp:Label ID="Label6" runat="server"></asp:Label>
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

