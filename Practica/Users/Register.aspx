<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Practica.Users.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Регистрация</title>

    <link rel="stylesheet" href="../assets/css/register.css" />


</head>
<body>
    <div class="site-title">
        Online Stilist
    </div>
    <form id="form1" runat="server">
        <div class="container">
            <div class="left-side">
                <asp:Image ID="img1" runat="server" ImageUrl="~/image/wardrop_register.png" />
            </div>
            <div class="right-side">
                <div class="header">
                    <h2>Регистрация</h2>
                </div>

                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>

                <div class="form-group">
                    <label for="phone_email">Телефон/Почта:</label>
                    <asp:TextBox ID="phone_email" runat="server" type="text" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="nickname">Придумайте Логин:</label>
                    <asp:TextBox ID="nickname" runat="server" type="text" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="password">Придумайте пароль:</label>
                    <asp:TextBox ID="password" runat="server" type="password" ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="confirm_password">Повторите пароль:</label>
                    <asp:TextBox ID="confirm_password" runat="server" type="password" ClientIDMode="Static"></asp:TextBox>
                </div>

                <asp:Button ID="btnRegister" runat="server" Text="Зарегистрироваться" OnClick="btnRegister_Click" ClientIDMode="Static" />

                <div class="login-link">
                    <a href="Login.aspx">Уже есть аккаунт? Войти</a>
                </div>
            </div>
        </div>
    </form>

    <script>
        function validateFields() {
            const phoneEmail = document.getElementById('<%= phone_email.ClientID %>').value;
            const nickname = document.getElementById('<%= nickname.ClientID %>').value;
            const password = document.getElementById('<%= password.ClientID %>').value;
            const confirmPassword = document.getElementById('<%= confirm_password.ClientID %>').value;
            const btnRegister = document.getElementById('<%= btnRegister.ClientID %>');

            if (phoneEmail && nickname && password && confirmPassword) {
                btnRegister.classList.add('active');
            } else {
                btnRegister.classList.remove('active');
            }
        }
        window.onload = function () {
            document.getElementById('<%= phone_email.ClientID %>').addEventListener('input', validateFields);
            document.getElementById('<%= nickname.ClientID %>').addEventListener('input', validateFields);
            document.getElementById('<%= password.ClientID %>').addEventListener('input', validateFields);
            document.getElementById('<%= confirm_password.ClientID %>').addEventListener('input', validateFields);
        };
    </script>
</body>
</html>
