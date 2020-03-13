<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Projekt.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Renee PANEL ADMINA</title>
    <link href="AdminPage.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Dancing+Script|Didact+Gothic" rel="stylesheet" />
    <link rel="icon" href="high-heel.png" />
</head>
<body>
   <div id="banner"><h1>Reneè</h1></div>

    <form id="form1" runat="server">
        <h2> ~ PANEL ADMINA ~</h2>

        <asp:Button ID="btAdd" runat="server" Text="Dodaj produkt" class="buttons" OnClick="Add_Click" />
        <asp:Button ID="btEdit" runat="server" Text="Edytuj produkt"  class="buttons" OnClick="Edit_Click"/>
        <asp:Button ID="btRemove" runat="server" Text="Usuń produkt" class="buttons" OnClick="Remove_Click"/>
        <asp:Button ID="btOrders" runat="server" Text="Zamówienia" class="buttons" OnClick="btOrders_Click" />
   

        <asp:Label ID="LInfo" runat="server" Text=" "></asp:Label>

    </form>
</body>
</html>
