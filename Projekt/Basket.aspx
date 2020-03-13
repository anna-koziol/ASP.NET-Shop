<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Basket.aspx.cs" Inherits="Projekt.Basket" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Renee</title>
    <link href="Style.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Dancing+Script|Didact+Gothic" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css" integrity="sha384-B4dIYHKNBt8Bc12p+WXckhzcICo0wtJAoU8YZTY5qE0Id1GSseTk6S+L3BlXeVIU" crossorigin="anonymous">
    <link rel="icon" href="high-heel.png" />
    </head>
<body>
    <asp:Panel ID="PanelMain" runat="server">

        <form id="form1" runat="server">
            <div id="banner">
                <h1>Reneè</h1>
             </div>
       
            <asp:Label ID="Hello" runat="server" Text=""></asp:Label>
            <asp:Panel ID="PanelBasket" runat="server">

            </asp:Panel>

            <hr />

            <div class="rows"><asp:Label ID="LKupon" runat="server" Text="Kupon: "></asp:Label><asp:TextBox ID="Kupon" runat="server"></asp:TextBox></div>
            <div class="rows"><asp:Label ID="LDostawy" runat="server" Text="Sposób dostawy (po przedpłacie): "></asp:Label></div>
            <div class="rows">
                <asp:RadioButtonList ID="RBDostawy" runat="server">
                    <asp:ListItem Selected="True">Kurier Poczta Polska - 10 zł</asp:ListItem>
                    <asp:ListItem>Kurier DPD - 11 zł</asp:ListItem>
                    <asp:ListItem>Kurier DHL - 15 zł</asp:ListItem>
                    <asp:ListItem>Paczkomaty InPost - 12zł</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="rows"><asp:Button ID="BtPrice" runat="server" Text="Oblicz cenę" class="buttons" OnClick="BtPrice_Click"/></div>
            <div class="rows"><asp:Label ID="Summary" runat="server" Text=""></asp:Label></div>
            <div class="rows"><asp:Label ID="SumaryDostawa" runat="server" Text=""></asp:Label></div>

            <asp:Button ID="BtBuy" runat="server" Text="Zamów" class ="buttons" OnClick="BtBuy_Click"/>

    <asp:LinkButton ID="LinkBBack" runat="server" OnClick="LinkBBack_Click"><i class="fas fa-angle-double-left"></i></asp:LinkButton>   

        </form>

    </asp:Panel>

</body>
</html>

