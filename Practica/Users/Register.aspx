<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Practica.Users.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Регистрация</title>
    <style>
        body {
            background-color: lightblue;
            font-family: sans-serif;
            display: flex;
            flex-direction: column;
            min-height: 100vh;
            margin: 0;
        }

        .container {
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding: 20px;
            flex: 1;
            margin-top: 50px;
        }

        .left-side {
            width: 40%;
            margin-top: 30px;
        }

        .right-side {
            width: 50%;
            padding: 10px;
            background-color: #72bcd4;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            margin-top: -65px;
        }


        .header {
            text-align: center;
            margin-bottom: 20px;
        }

        .form-group {
            margin-bottom: 15px;
            text-align: left;
        }

            .form-group label {
                display: block;
                margin-bottom: 5px;
            }

            .form-group input[type="text"],
            .form-group input[type="password"] {
                width: 100%;
                padding: 10px;
                border: 1px solid #ccc;
                border-radius: 4px;
                box-sizing: border-box;
            }

        #btnRegister {
            background-color: #90EE90;
            border: none;
            color: white;
            padding: 15px 32px;
            text-align: center;
            text-decoration: none;
            display: block;
            margin: 20px auto;
            font-size: 16px;
            cursor: pointer;
            border-radius: 4px;
        }

        img {
            max-width: 100%;
            height: auto;
        }

        .login-link {
            text-align: center;
            margin-top: 10px;
        }


        .site-title {
            position: absolute;
            top: 20px;
            left: 20px;
            font-size: 24px;
            color: black;
            font: italic bold 24px sans-serif;
        }
    </style>
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
                <!— Вот здесь добавлен Label -->

                <div class="form-group">
                    <label for="phone_email">Телефон/Почта:</label>
                    <asp:TextBox ID="phone_email" runat="server" type="text"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="nickname">Придумайте Логин:</label>
                    <asp:TextBox ID="nickname" runat="server" type="text"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="password">Придумайте пароль:</label>
                    <asp:TextBox ID="password" runat="server" type="password"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="confirm_password">Повторите пароль:</label>
                    <asp:TextBox ID="confirm_password" runat="server" type="password"></asp:TextBox>
                </div>
                <asp:Button ID="btnRegister" runat="server" Text="Зарегистрироваться" OnClick="btnRegister_Click" />
                <div class="login-link">
                    <a href="Login.aspx">Уже есть аккаунт? Войти</a>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
