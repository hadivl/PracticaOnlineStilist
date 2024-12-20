<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Practica.Users.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <link rel="stylesheet" href="../assets/css/homepage.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <div class="page-title">Online Stilist</div>
            <div class="user-buttons">
                <a href="Account.aspx">
                    <img src="../image/icon.png" alt="Аккаунт" /></a>
                <a href="WardrobItem.aspx">
                    <img src="../image/wardrob_icon.png" alt="Гардероб" /></a>
            </div>
        </div>
        <div class="center-buttons">
            <div class="center-button">
                <a href="WardrobeCapsule.aspx">
                    <img src="../image/wardrob.png" alt="Капсульный гардероб" /></a>
                <span>Капсульный гардероб</span>
            </div>
            <div class="center-button">
                <a href="IndividualCapsule.aspx">
                    <img src="../image/individ.png" alt="Индивидуальный гардероб" /></a>
                <span>Индивидуальная капсула</span>
            </div>
        </div>
    </form>
</body>
</html>
