<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Projekt.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Renee logowanie</title>
    <link href="Login.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Dancing+Script|Didact+Gothic" rel="stylesheet" />
    <link rel="icon" href="high-heel.png" />
</head>
<body>
    <div id="banner"><h1>Reneè</h1></div>

    <form id="form1" runat="server">
        <h2>LOGOWANIE</h2>

        <div class="divsForm"  id="firstRow">
            login: 
            <asp:TextBox ID="TB1" runat="server"></asp:TextBox>
        </div>

        <div class="divsForm">
            hasło: 
            <asp:TextBox ID="TB2" runat="server" TextMode="Password"></asp:TextBox>
        </div>

        <asp:Label ID="LInfo" runat="server" Text=" "></asp:Label>


        <asp:Button ID="Button1"  class="buttons" runat="server" OnClick="Button1_Click" Text="Zaloguj" />
    </form>
</body>
</html>
