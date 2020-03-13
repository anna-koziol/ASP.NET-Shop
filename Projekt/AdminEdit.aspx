<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminEdit.aspx.cs" Inherits="Projekt.AdminEdit" %>

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
        <h2> ~ EDIT ~</h2>
        <asp:Label ID="TextLb" runat="server" Text="Wybierz element do edycji:"></asp:Label>
        <asp:Label ID="lbEdit" runat="server" Text=""></asp:Label>

        <asp:Panel ID="Panel1" runat="server"> 
            <div class="divsForm">
                <asp:Button ID="backAdmin" runat="server" Text="Powrót" class="buttons" OnClick="backAdmin_Click1" />
                <asp:Button ID="LogOut" runat="server" Text="Wyloguj się" class="buttons" OnClick="LogOut_Click1"/>
            </div>
        </asp:Panel>

        <asp:Panel ID="Panel2" runat="server">
            <div class="divsForm"  id="firstRow">
            nazwa: 
            <asp:TextBox ID="TB1" runat="server" CssClass="inputs"></asp:TextBox>
        </div>
        <div class="divsForm">
            rodzaj:             
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem>Szpilki</asp:ListItem>
                <asp:ListItem>Botki</asp:ListItem>
                <asp:ListItem>Baletki</asp:ListItem>
                <asp:ListItem>Kozaki</asp:ListItem>
                <asp:ListItem>Sportowe</asp:ListItem>
            </asp:RadioButtonList>
            
        </div>    
        <div class="divsForm">
            cena: 
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Number" CssClass="inputs"></asp:TextBox>
        </div>       
        <div class="divsForm">
            rozmiary: 
            <asp:TextBox ID="TextBox3" runat="server" CssClass="inputs"></asp:TextBox>
        </div>        
        <div class="divsForm">
            zdjęcie: 
            <asp:FileUpload ID="FileUpload1" runat="server"/>
        </div>        
        <div class="divsForm">
            kolor: 
            <asp:TextBox ID="TextBox5" runat="server" CssClass="inputs"></asp:TextBox>
        </div>
        <div class="divsForm">
            obcas: 
            <asp:TextBox ID="TextBox6" runat="server" TextMode="Number" CssClass="inputs"></asp:TextBox>
        </div>
        <div class="divsForm">
            materiał: 
            <asp:TextBox ID="TextBox7" runat="server" CssClass="inputs"></asp:TextBox>
        </div>
        <div class="divsForm">
            dodatkowe: 
            <asp:TextBox ID="TextBox8" runat="server" CssClass="inputs"></asp:TextBox>
        </div>
            <asp:Button ID="btEdit" class="buttons" runat="server" Text="Edytuj" OnClick="btEdit_Click" />
        </asp:Panel>


    </form>
</body>
</html>

