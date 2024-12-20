<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Practica.Users.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Авторизация</title>


    <link rel="stylesheet" href="../assets/css/general.css" />
</head>
<body>
    <div class="site-title">
        Online Stilist
    </div>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            <div class="left-side">
                <asp:Image ID="img1" runat="server" ImageUrl="~/image/wardrop_register.png" />
            </div>
            <div class="right-side">
                <div class="header">
                    <h2>Авторизация</h2>
                </div>

                <div class="form-group">
                    <label for="phone_email">Телефон/Почта:</label>
                    <asp:TextBox ID="phone_email" runat="server" type="text" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="nickname">Логин:</label>
                    <asp:TextBox ID="nickname" runat="server" type="text" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="password">Введите пароль:</label>
                    <asp:TextBox ID="password" runat="server" type="password" ClientIDMode="Static"></asp:TextBox>
                </div>
                <asp:Button ID="btnLogin" runat="server" Text="Войти" OnClick="btnLogin_Click" ClientIDMode="Static" />
                <div class="login-link">
                    <a href="Register.aspx">Еще нет аккаунта? Зарегистрироваться</a>
                </div>

                <script>
                    function validateFields() {
                        const phoneEmail = document.getElementById('phone_email').value;
                        const nickname = document.getElementById('nickname').value;
                        const password = document.getElementById('password').value;
                        const btnLogin = document.getElementById('btnLogin');


                        if (phoneEmail && nickname && password) {
                            btnLogin.classList.add('active');
                        } else {
                            btnLogin.classList.remove('active');
                        }
                    }

                    document.getElementById('phone_email').addEventListener('input', validateFields);
                    document.getElementById('nickname').addEventListener('input', validateFields);
                    document.getElementById('password').addEventListener('input', validateFields);
                </script>



            </div>
        </div>
    </form>
</body>
</html>
