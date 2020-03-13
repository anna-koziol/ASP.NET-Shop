<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckLoginRegister.aspx.cs" Inherits="Projekt.CheckLoginRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Renee</title>
    <link href="AdminPage.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Dancing+Script|Didact+Gothic" rel="stylesheet" />
    <link rel="icon" href="high-heel.png" />
</head>
<body>
   <div id="banner"><h1>Reneè</h1></div>

    <form id="form1" runat="server">
        <h2> ~ WYBIERZ ~</h2>
        <asp:Button ID="btLogin" runat="server" Text="Zaloguj" class="buttons" OnClick="btLogin_Click"  />
        <asp:Button ID="btRegister" runat="server" Text="Zarejestruj"  class="buttons" OnClick="btRegister_Click" />
        <asp:Button ID="btBack" runat="server" Text="Powrót" class="buttons" OnClick="btBack_Click"/>

        <asp:Label ID="LInfo" runat="server" Text=" "></asp:Label>
    </form>

   <form id="form2" runat="server">
        <h2> ~ WITAJ ~</h2>
        <asp:Panel ID="PanelImg" runat="server"></asp:Panel>
        <asp:Label ID="lName" runat="server" Text="  "></asp:Label>   
        <asp:Button ID="LogOut" runat="server" Text="Wyloguj" class="buttons" OnClick="LogOut_Click"/>
        <asp:Button ID="Back" runat="server" Text="Powrót" class="buttons" OnClick="Back_Click"/>

    </form>

</body>
</html>
