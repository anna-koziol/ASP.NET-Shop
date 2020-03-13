<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminRemove.aspx.cs" Inherits="Projekt.AdminRemove" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Renee PANEL ADMINA</title>
    <link href="AdminEdit.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Dancing+Script|Didact+Gothic" rel="stylesheet" />
    <link rel="icon" href="high-heel.png" />
</head>
<body>

    <form id="form1" runat="server">
        <h2> ~ REMOVE  ~</h2>
        <asp:Label ID="LInfo" runat="server" Text=" "></asp:Label>

         <asp:Label ID="TextLb" runat="server" Text="Wybierz element do usunięcia:"></asp:Label>
        <asp:Label ID="lbRemove" runat="server" Text=""></asp:Label>

        <asp:Panel ID="PanelRemove" runat="server"> 
            <div class="divsForm">
                <asp:Button ID="backAdmin" runat="server" Text="Powrót" class="buttons" OnClick="backAdmin_Click1" />
                <asp:Button ID="LogOut" runat="server" Text="Wyloguj się" class="buttons" OnClick="LogOut_Click1"/>
            </div>
        </asp:Panel>
    </form>
</body>
</html>

