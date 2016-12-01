<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            background-color: #f4f4f4;
            color: #5a5656;
            font-family: 'Open Sans', Arial, Helvetica, sans-serif;
            font-size: 16px;
            line-height: 1.5em;
        }
        h1 { font-size: 1em; }
        h1, p {
            margin-bottom: 10px;
            text-align:center;
        }
        h2{
            font-size: 20px;
            text-align: center;
        }
        strong {
            font-weight: bold;
        }

        #login {
            margin: 10px auto;
            width: 300px;
        }
        input[type="password"],input[type="text"]{
            background-color: #e5e5e5;
            border: none;
            border-radius: 3px;
            -moz-border-radius: 3px;
            -webkit-border-radius: 3px;
            color: #5a5656;
            font-family: 'Open Sans', Arial, Helvetica, sans-serif;
            font-size: 14px;
            height: 50px;
            outline: none;
            padding: 0px 10px;
            width: 280px;
            -webkit-appearance:none;
        }
        #btnGiris, #btnUyeOl {
            background-color: #008dde;
            border: none;
            border-radius: 3px;
            -moz-border-radius: 3px;
            -webkit-border-radius: 3px;
            color: #f4f4f4;
            cursor: pointer;
            font-family: 'Open Sans', Arial, Helvetica, sans-serif;
            height: 50px;
            text-transform: uppercase;
            width: 125px;
            -webkit-appearance: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
        <div id="login">
            <h2>Üye Girişi</h2>
            <h1><strong>Hoş Geldiniz.</strong> Giriş Yapınız...</h1>
            <p><input name="username" type="text" value="Kullanıcı Adı" onblur="if(this.value=='')this.value='Kullanıcı Adı'" onfocus="if(this.value=='Kullanıcı Adı')this.value=''" /></p>
            <p><input name="pass" type="password" value="Password" onblur="if(this.value=='')this.value='Password'" onfocus="if(this.value=='Password')this.value=''" /></p>
            <table>
                <tr>
                    <td><p>&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</p></td>
                    <td style="width: 50px;"></td>
                    <td> <p><asp:Button ID="btnGiris" runat="server" Text="Giriş Yapınız" OnClick="btnGiris_Click" /></p>   </td>
                </tr>
            </table>
            
            
            <p><asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label></p>
        </div>
        
    </form>
</body>
</html>
