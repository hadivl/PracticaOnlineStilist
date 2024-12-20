<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WardrobeCapsule.aspx.cs" Inherits="Practica.Users.WardrobeCapsule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Wardrobe Capsule</title>


    <link rel="stylesheet" href="../assets/css/wardrobeCaps.css" />


</head>
<body>
    <form id="form1" runat="server">
        <div id="header">
            <h1>Online Stilist</h1>
        </div>

        <a href="HomePage.aspx" class="btn btn-home">На главную</a>
        <asp:Button ID="Button1" runat="server" Text="Получить капсульный гардероб" CssClass="btn-capsule" OnClick="Button1_Click" />


        <div id="capsule-container">
            <asp:PlaceHolder ID="placeholder" runat="server"></asp:PlaceHolder>
        </div>

        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>


    </form>
</body>
</html>
