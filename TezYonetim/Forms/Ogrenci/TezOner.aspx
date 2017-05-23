<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Ogrenci/MasterPageUser.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="TezOner.aspx.cs" Inherits="Forms_Ogrenci_TezOner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Tez Öneri</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <!--Select2-->
    <div class="container">
        <div id="signupbox" style="margin-top: 50px" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <div class="panel-title">Tez Öner</div>
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
                                <asp:TextBox type="text" class="form-control" ID="konu" runat="server" name="Konu" placeholder="Tez Konu Başlığı"></asp:TextBox>
                            </div>
                        </div>
                        <br>
                        <br>
                        <br>
                        <div class="form-group">
                            <label for="comment" class="col-md-3 control-label">Açıklama: </label>
                            <div class="col-md-9">
                                <asp:TextBox class="form-control" Rows="5" ID="comment" name="Aciklama" runat="server" placeholder="Tez Açıklama"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <br />
                        <br />
                        <div class="form-group">
                            <label for="name" class="col-md-3 control-label">Tezi Alan Diğer Öğrenciler(Varsa): </label>
                            <div class="col-md-9">
                                <select name="TeziAlanDigerOgrenciler" id="TeziAlanDigerOgrenciler" class="js-example-basic-multiple form-control" multiple="multiple"></select>
                            </div>
                        </div>
                        <!--Select2-->
                        <script type="text/javascript">
                            $(".js-example-basic-multiple").select2(
                                {
                                    tags: true,
                                    tokenSeparators: [','],
                                    "language": {
                                        "noResults": function () {
                                            return "Öğrenci numarasını girdikten sonra Enter'a basabilir ya da virgül (,) koyabilirsiniz.";
                                        }
                                    },
                                });
                        </script>
                        <div class="form-group">
                            <div class="col-md-9">
                                <p>
                                    <asp:Label ID="label1" runat="server" ForeColor="Red"></asp:Label>
                                </p>
                            </div>
                        </div>
                        <div class="form-group">
                            <!-- Button -->
                            <div class="col-md-offset-3 col-md-9">


                                <asp:Button runat="server" class="btn btn-primary" OnClick="btnGiris_Click" Text="Kaydet" />
                            </div>
                        </div>

                    </div>
                </form>
            </div>
        </div>
    </div>

    <%-- Modal başlangıç --%>
    <div class="modal fade" id="exampleModal2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Kapat"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="exampleModalLabel2">Tez Önerme</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">       
                        <asp:Label ID="label4" runat="server" ForeColor="Red"></asp:Label>                 
                         <asp:Label ID="Label2" runat="server"></asp:Label><br /><br /><br />
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                        <asp:Label ID="label5" runat="server" ForeColor="Red"></asp:Label>    

                    </div>
                </div>
                <div class="modal-footer">
                    <div style="float:right;" id="butonmodal" runat="server" ><asp:Button runat="server" class="btn btn-primary" OnClick="Onayla_Click" Text="Kaydet" /></div>&nbsp;&nbsp;&nbsp;
                    <div style="float:right;"> <button type="button" class="btn btn-default" data-dismiss="modal">Kapat</button></div>&nbsp;&nbsp;&nbsp;
                    
                </div>
            </div>
        </div>
    </div>
    <%-- Modal Bitiş --%>
</asp:Content>

