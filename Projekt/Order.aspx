<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="Projekt.Order" %>

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
           <form id="form1Order" runat="server">
            <div id="banner">
                <h1>Reneè</h1>
             </div>

               <div class="block">
               <asp:Label ID="Err" runat="server" Text=""></asp:Label>

                   <h3>Adres wysyłki</h3>
                   <div class="rows">Imię: <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="   Proszę podać imię" Font-Bold="True" ForeColor="#333333" ControlToValidate="TextBox1"></asp:RequiredFieldValidator></div>
                   
                   <div class="rows">Nazwisko: <asp:TextBox ID="TextBox2" runat="server" CssClass="textbox"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="   Proszę podać nazwisko" ControlToValidate="TextBox2" Font-Bold="True" ForeColor="#333333"></asp:RequiredFieldValidator></div>
                   
                   <div class="rows">Ulica: <asp:TextBox ID="TextBox3" runat="server" CssClass="textbox"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="   Proszę podać ulicę" ControlToValidate="TextBox3" Font-Bold="True" ForeColor="#333333"></asp:RequiredFieldValidator></div>
                   
                   <div class="rows">Numer domu/lokalu: <asp:TextBox ID="TextBox4" runat="server" CssClass="textbox"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="   Proszę podać numer domu/lokalu" ForeColor="#333333" Font-Bold="True" ControlToValidate="TextBox4"></asp:RequiredFieldValidator></div>
                   
                   <div class="rows">Kod pocztowy: <asp:TextBox ID="TextBox5" runat="server" CssClass="textbox"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="   Proszę podać kod pocztowy" ControlToValidate="TextBox5" Font-Bold="True" ForeColor="#333333"></asp:RequiredFieldValidator></div>
                   
                   <div class="rows">Miejscowość: <asp:TextBox ID="TextBox6" runat="server" CssClass="textbox"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="   Proszę podać miejscowość" ControlToValidate="TextBox6" Font-Bold="True" ForeColor="#333333"></asp:RequiredFieldValidator></div>
                   
                   <div class="rows">Numer telefonu: <asp:TextBox ID="TextBox7" runat="server" CssClass="textbox" TextMode="Phone" CausesValidation="True"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="   Proszę podać numer telefonu" ForeColor="#333333" Font-Bold="True" ControlToValidate="TextBox7"></asp:RequiredFieldValidator></div>
               </div>

               <hr />

               <div class="block">
                   <h3>Płatność</h3>
                   <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                       <asp:ListItem Selected="true">Przelew tradycyjny</asp:ListItem>
                       <asp:ListItem>PayU</asp:ListItem>
                       <asp:ListItem>Blik</asp:ListItem>
                       <asp:ListItem>Karta płatnicza</asp:ListItem>
                       <asp:ListItem>PayPal</asp:ListItem>
                   </asp:RadioButtonList>
               </div>
               <hr />
               <asp:Label ID="PriceFull" runat="server" Text="RAZEM DO ZAPŁATY 330 ZŁ"></asp:Label>
                <br />
               <asp:Button ID="BuyFull" runat="server" Text="KUP" class="buttons" OnClick="BuyFull_Click"/>
        </form>
</body>
</html>
