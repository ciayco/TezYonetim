<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Hoca/MasterPageHoca.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Forms_Hoca_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="panel">
        <div class="panel-body">
            <div class="example-box-wrapper">
                <div id="form-wizard-1">
                    <ul class="nav nav-pills">
                        <asp:Repeater ID="Repeater1" runat="server">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li class=""><a href="#<%#Eval("ad") %>" data-toggle="tab"><%#Eval("id") %></a></li>
                            </ItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="tab-content">
                        <asp:Repeater ID="Repeater2" runat="server">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                               <div class="tab-pane" id="<%#Eval("ad") %>">
                            <div class="content-box">
                                <h3 class="content-box-header bg-default"><%#Eval("id") %></h3>
                                <div class="content-box-wrapper"><%#Eval("Mail")%></div>
                            </div>
                        </div>
                            </ItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:Repeater>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

