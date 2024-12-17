<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Practica.Users.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        body {
            font-family: sans-serif;
            display: flex;
            flex-direction: column;
            min-height: 100vh;
            margin: 0;
            background-color: lightblue;
        }

        .header {
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding: 20px;
        }

        .page-title {
            font-size: 30px;
            font-style: italic;
            font-weight: bold;
            color: white;
            text-shadow: 1px 1px 0 #000, -1px -1px 0 #000, 1px -1px 0 #000, -1px 1px 0 #000;
        }

        .user-buttons {
            display: flex;
            gap: 20px;
        }

            .user-buttons img {
                width: 50px;
                height: 50px;
            }

        .center-buttons {
            display: flex;
            justify-content: center;
            align-items: center;
            gap: 80px;
            margin-top: 100px;
        }

        .center-button {
            display: flex;
            flex-direction: column;
            align-items: center;
        }

            .center-button img {
                width: 200px;
                height: 200px;
            }

            .center-button span {
                font-size: 18px;
                color: white;
            }
    </style>
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
