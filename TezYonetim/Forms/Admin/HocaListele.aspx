﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Admin/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="HocaListele.aspx.cs" Inherits="Forms_Admin_HocaListele" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <title>Danışman Görüntüle</title>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <table class="display" id="students">
        <thead>
            <tr>
                <th style="text-align: center;">İsim Soyisim </th>
                <th style="text-align: center;">E-Mail </th>
                <th style="text-align: center;">Ders </th>
                <th style="text-align: center;">Düzenle</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("Ad") %></td>
                        <td><%#Eval("Mail") %></td>
                        <td><%#Eval("Ders") %></td>
                        <td>
                            <a href="Duzenle.aspx?IdD=<%#Eval("Id") %>" title="Şifre Değiştir" class="btn btn-primary btn-xs btn-round"><span class="glyphicon glyphicon-edit"></span></a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
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

