<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Ogrenci/MasterPageUser.master" AutoEventWireup="true" CodeFile="PosterEkle.aspx.cs" Inherits="Forms_Ogrenci_PosterEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <input type="file" runat="server" id="filMyFile" />
    <asp:Button  type="button" runat="server" OnClick="PosterEkle_Click"  class="btn btn-primary" Text="Kaydet"></asp:Button>
</asp:Content>

