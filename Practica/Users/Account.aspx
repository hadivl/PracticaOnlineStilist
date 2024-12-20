<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="Practica.Users.Account" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Аккаунт</title>

    <link rel="stylesheet" href="../assets/css/account.css" />

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
