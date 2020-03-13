<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminOrders.aspx.cs" Inherits="Projekt.AdminOrders" %>

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

    <form id="form1Order" runat="server">
        <h2> ~ ORDERS ~</h2>
        <asp:Label ID="TextLb" runat="server" Text="Wybierz element do edycji:"></asp:Label>
        <asp:Label ID="lbEdit" runat="server" Text=""></asp:Label>

        <asp:Panel ID="Panel1" runat="server"> 
            <div class="divsForm">
                <asp:Button ID="backAdmin" runat="server" Text="Powrót" class="buttons" OnClick="backAdmin_Click1" />
                <asp:Button ID="LogOut" runat="server" Text="Wyloguj się" class="buttons" OnClick="LogOut_Click1"/>
            </div>
        </asp:Panel>

        <hr />
        <asp:Panel ID="Panel2" runat="server">
        </asp:Panel>

        <asp:Panel ID="Panel3" runat="server" Visible="false">
             <asp:RadioButtonList ID = "RadioButtonList1" runat="server">
                    <asp:ListItem Value = "Zamówienie przyjęte do realizacji" Selected="True">Zamówienie przyjęte do realizacji</asp:ListItem>
                    <asp:ListItem Value = " Zamówienie w trakcie realizacji" > Zamówienie w trakcie realizacji</asp:ListItem>
                    <asp:ListItem Value = "Zamówienie skompletowane" > Zamówienie skompletowane</asp:ListItem>
                    <asp:ListItem Value = "Zamówienie przekazane do wysyłki" > Zamówienie przekazane do wysyłki</asp:ListItem>
                    <asp:ListItem Value = "Zamówienie zrealizowane i wysłane" > Zamówienie zrealizowane i wysłane</asp:ListItem>
                </asp:RadioButtonList>
                    <asp:button type = "submit" id="Button1" Text="Zapisz status" email="" clickid="" runat="server" OnClick="Submit_Click" CssClass="buttons"/>
        </asp:Panel>


        <asp:Label ID="LInfo" runat="server" Text=""></asp:Label>


    </form>
</body>
</html>
