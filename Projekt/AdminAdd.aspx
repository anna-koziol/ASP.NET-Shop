<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminAdd.aspx.cs" Inherits="Projekt.AdminAdd" %>

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
    <form id="form1Add" runat="server">
        <h2> ~ ADD ~</h2>

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
            <asp:FileUpload ID="FileUpload1" runat="server" />
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

        <asp:Label ID="LInfo" runat="server" Text=" "></asp:Label>
        <asp:Button ID="addProduct" runat="server" Text="Dodaj produkt" class="buttons" OnClick="addProduct_Click"/>
        
         <div class="divsForm">
            <asp:Button ID="backAdmin" runat="server" Text="Powrót" class="buttons" OnClick="backAdmin_Click1" />
            <asp:Button ID="LogOut" runat="server" Text="Wyloguj się" class="buttons" OnClick="LogOut_Click1"/>
        </div>

        <asp:Label ID="messageAdd" runat="server" Text=""></asp:Label>
    </form>
             

</body>
</html>

