<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Hoca/MasterPageHoca.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="TezEkle.aspx.cs" Inherits="TezEkle" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <title>Tez Ekle</title>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="position: relative; margin: auto; width: 100%;">
        <div style="position: relative; margin: auto; width: 100%;">
            <div id="signupbox" style="margin-top: 30px" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <div class="panel-title">Tez Ekle</div>
                    </div>
                    <form id="signupform" class="form-horizontal" role="form">
                        <div class="panel-body">
                            <div id="signupalert" style="display: none" class="alert alert-danger">
                                <p>Error:</p>
                                <span></span>
                            </div>
                            <div class="form-group">
                                <label for="name" class="col-md-3 control-label">Konu: </label>
                                <div class="col-md-9">
                                    <input type="text" class="form-control" name="Konu" placeholder="Tez Konu Başlığı">
                                </div>
                            </div>
                            <br>
                            <br>
                            <div class="form-group">
                                <label for="comment" class="col-md-3 control-label">Açıklama: </label>
                                <div class="col-md-9">
                                    <textarea class="form-control" rows="5" id="comment" name="Aciklama" placeholder="Tez Açıklama"></textarea>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <div class="form-group">
                                <label for="name" class="col-md-3 control-label">Öğrenci Sayısı: </label>
                                <div class="col-md-9">
                                    <input type="number" value="1" class="form-control" name="TezAdet">
                                </div>
                            </div>
                            <br />
                            <br />                         
                            <div class="form-group">
                                <label for="name" class="col-md-3 control-label">Keywords: </label>
                                <div class="col-md-9">
                                    <select name="KeywordBox" id="KeywordBox" class="js-example-basic-multiple form-control" multiple="multiple"></select>
                                </div>
                            </div>
                            <!--Select2-->
                            <script type="text/javascript">
                                $(".js-example-basic-multiple").select2(
                                    {
                                        maximumSelectionLength: 3,
                                        tags: true,
                                        tokenSeparators: [','],
                                        "language": {
                                            "noResults": function () {
                                                return "3 ADET 'Keyword' GİRİNİZ - Keywordleri girdikten sonra Enter'a basabilir ya da virgül (,) koyabilirsiniz.";
                                            },
                                            "maximumSelected": function () {
                                                return "En fazla 3 adet Keywords girebilirsiniz";
                                            }
                                        },
                                    });
                                $('form').on('submit', function () {
                                    var minimum = 3;

                                    if ($(".js-example-basic-multiple").select2('data').length >= minimum) {
                                        return true;
                                    }


                                    else {
                                        alert('Seçilmesi gereken keyword sayısı : ' + minimum)
                                        return false;
                                    }

                                });
                            </script>
                            <div class="form-group">
                                <div class="col-md-9">
                                    <p>
                                        <asp:Label ID="uyari" runat="server" ForeColor="Red"></asp:Label>
                                    </p>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div class="form-group">
                                <!-- Button -->
                                <div class="col-md-offset-3 col-md-9">

                                    <asp:Button ID="btnGiris" type="submit" runat="server" Text="  Kayit  " class="btn btn-info" OnClick="btnGiris_Click" />

                                </div>
                            </div>

                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
