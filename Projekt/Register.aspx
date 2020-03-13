<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Projekt.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Renee rejestracja</title>
    <link href="Register.css" rel="stylesheet" />
    <link rel="icon" href="high-heel.png" />
    <link href="https://fonts.googleapis.com/css?family=Dancing+Script|Didact+Gothic" rel="stylesheet" />
</head>
<body>
    <div id="banner"><h1>Reneè</h1></div>


    <form id="form1" runat="server">
        <h2>REJESTRACJA</h2>
        <div class="divsForm" id="firstRow">
            login:
            <asp:TextBox ID="TB1" runat="server" OnTextChanged="TextBox1_TextChanged" Width="123px"></asp:TextBox>
        </div>
        <asp:Label ID="NickValid" runat="server"> </asp:Label>

        <div class="divsForm">
            hasło:
            <asp:TextBox ID="TB2" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <asp:RegularExpressionValidator ID="regexPasswordlValid" runat="server" ControlToValidate="TB2" ErrorMessage="Słabe hasło, użyj bardziej złożonego" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$"></asp:RegularExpressionValidator>

        <div class="divsForm">
            mail:
            <asp:TextBox ID="TB3" runat="server"></asp:TextBox>
        </div>
        <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ErrorMessage="Błędny mail" ControlToValidate="TB3" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>


        <div class="divsForm">
            zdjęcie:
            <asp:FileUpload ID="FU1" runat="server" />
        </div>
        <div class="divsForm">
            <asp:Label ID="message" runat="server" Text=""></asp:Label>
        </div>
 
        <asp:Button ID="Button1" class="buttons" runat="server" OnClick="Button1_Click" Text="ZAREJESTRUJ" />
    </form>
</body>
</html>
