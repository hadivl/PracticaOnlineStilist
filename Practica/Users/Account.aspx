<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="Practica.Users.Account" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Аккаунт</title>
    <style>
        body {
            font-family: sans-serif;
            background-color: lightblue;
            margin: 0;
            display: flex;
            min-height: 100vh;
            justify-content: center;
            align-items: center;
        }

        .main-content {
            display: grid;
            grid-template-columns: 1fr 4fr;
            gap: 20px;
            width: 80%;
            max-width: 1200px;
            padding: 30px;
            background-color: #f0f0f0;
            border-radius: 10px;
            box-shadow: 0px 0px 15px rgba(0, 0, 0, 0.2); /* Тень */
        }

        .account-info {
            background-color: white;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
            display: flex;
            flex-direction: column;
            align-items: center;
            grid-column: 2 / 3;
            min-height: 400px;
            text-align: center;
        }

            .account-info img {
                width: 150px;
                height: 150px;
                border-radius: 50%;
                object-fit: cover;
                margin-bottom: 20px;
            }

            .account-info p {
                margin-bottom: 10px;
                font-size: 18px;
                color: #333;
            }

        .logout-button {
            background-color: #dc3545;
            color: white;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            margin-top: 20px;
        }

        .buttons-container {
            display: flex;
            flex-direction: column;
            gap: 20px;
            grid-column: 1 / 2;
            align-items: center;
            justify-content: center;
        }

        .nav-button {
            display: flex;
            align-items: center;
            justify-content: center;
            width: 60px;
            height: 60px;
            background-size: cover;
            border-radius: 5px;
            cursor: pointer;
        }

            .nav-button img {
                max-width: 100%;
                max-height: 100%;
            }

        #favorites-button {
            background-image: url('../image/favorites.png');
            /
        }

        #saved-button {
            background-image: url('../image/saved.png');
        }

        .user-details {
            margin-bottom: 20px;
        }

        #home-button {
            margin-top: 100px;
        }

        .user-details p {
            margin: 5px 0;
        }

        .online-stylist {
            position: absolute;
            top: 20px;
            left: 20px;
            font-size: 30px;
            font-style: italic;
            font-weight: bold;
            color: white;
            text-shadow: 1px 1px 0 #000, -1px -1px 0 #000, 1px -1px 0 #000, -1px 1px 0 #000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="online-stylist">Online stilist</div>
        <asp:Label ID="lblNickname" runat="server" />
        <br />
        <asp:Label ID="lblEmailOrPhone" runat="server" />
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>

        <div class="main-content">
            <div class="buttons-container">
                <a href="Favorites.aspx" class="nav-button" id="favorites-button">
                    <img src="../image/favourite.png" alt="Избранное" />
                </a>
                <a href="Saved.aspx" class="nav-button" id="saved-button">
                    <img src="../image/saved.png" alt="Сохраненное" />
                </a>
                <a href="HomePage.aspx" class="nav-button" id="home-button">
                    <img src="../image/comeBack.png" alt="Домой" />
                </a>
            </div>
            <div class="account-info">
                <img src="../image/avatar.png" alt="Аватар" />
                <div class="user-details">
                    <p>
                        Имя:
                        <asp:Label ID="UserNameLabel" runat="server" Text=""></asp:Label>
                    </p>
                    <p>
                        Email/Телефон:
                        <asp:Label ID="UserContactLabel" runat="server" Text=""></asp:Label>
                    </p>
                </div>
                <asp:Button ID="LogoutButton" runat="server" Text="Выход" CssClass="logout-button" OnClick="LogoutButton_Click" OnClientClick="redirectToLogin()" />
            </div>
        </div>
    </form>
</body>
</html>
