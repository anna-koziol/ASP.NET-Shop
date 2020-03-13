<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Projekt.Main" %>

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
        <div id="banner2" >
            <h2>Załóż konto i otrzymaj 10% rabatu!</h2> 
        </div>

        <form id="form1" runat="server">
            <div id="banner">
                <h1>Reneè</h1>
                <div id="bannerIcons">
                     <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="icons/user.png" OnClick="ImageButton1_Click"  CssClass="icons"/>
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="icons/shopping-bag.png" OnClick="ImageButton2_Click"  CssClass="icons"/>
                </div>
             </div>
       
             <div class="divsForm">
                <h3>Witamy w Reneè, życzymy miłych zakupów</h3>
                rodzaj:             
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>Szpilki</asp:ListItem>
                    <asp:ListItem>Botki</asp:ListItem>
                    <asp:ListItem>Baletki</asp:ListItem>
                    <asp:ListItem>Kozaki</asp:ListItem>
                    <asp:ListItem>Sportowe</asp:ListItem>
                    <asp:ListItem>Wszystko</asp:ListItem>
                </asp:RadioButtonList>
                 <asp:Button ID="ShowByCategoery" runat="server" OnClick="ShowByCategory_Click"  Text="SZUKAJ" class="buttons"/>
            </div> 
            <asp:Panel ID="PanelProduct" runat="server"></asp:Panel>
        </form>

        <asp:Label ID="Test" runat="server" Text=" "></asp:Label>
        <asp:Label ID="LInfo" runat="server" Text=" "></asp:Label>
    </asp:Panel>

    <asp:Panel ID="PanelProductOne" runat="server" style="margin-top: 0px">
       <form id="form2" runat="server">
           <div id="bannerPanel2">
                <h1>Reneè</h1>
                <div id="bannerIconsPanel2">
                     <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="icons/user.png" OnClick="ImageButton1_Click"  CssClass="icons"/>
                    <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="icons/shopping-bag.png" OnClick="ImageButton2_Click"  CssClass="icons"/>
                </div>
             </div> 


           <asp:Panel ID="ProductDetails" runat="server">
               <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
               <asp:Button ID="Buy" runat="server" Text="DODAJ DO KOSZYKA" CssClass="buttons" OnClick="Buy_Click"/>
            <asp:Label ID="testID" runat="server" server="" Text=" "></asp:Label>
            <asp:LinkButton ID="LinkBBack" runat="server" OnClick="LinkBBack_Click"><i class="fas fa-angle-double-left"></i></asp:LinkButton>   
           </asp:Panel>

        </form>
    </asp:Panel>


</body>
</html>
