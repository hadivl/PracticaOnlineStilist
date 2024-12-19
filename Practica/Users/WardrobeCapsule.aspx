<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WardrobeCapsule.aspx.cs" Inherits="Practica.Users.WardrobeCapsule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Wardrobe Capsule</title>
    <style>
        body {
            font-family: sans-serif;
            background-color: lightblue;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            min-height: 100vh;
            margin: 0;
            position: relative;
        }

        #header {
            position: fixed;
            top: 0px;
            left: 0px;
            text-align: center;
            margin-bottom: 20px;
        }

        .container {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            height: 100vh;
        }

        .btn-capsule {
            position: absolute;
            right: 20px;
            bottom: 20px;
            display: inline-block;
            padding: 10px 20px;
            background-color: azure;
            color: blue;
            text-decoration: none;
            border-radius: 10px;
            cursor: pointer;
        }

        .btn {
            display: inline-block;
            padding: 10px 20px;
            background-color: azure;
            color: blue;
            text-decoration: none;
            border-radius: 10px;
            cursor: pointer;
        }

        .btn-home {
            position: absolute;
            background-color: azure;
            margin-top: 25px;
            left: 20px;
            bottom: 20px;
            display: inline-block;
            padding: 10px 20px;
            color: blue;
            text-decoration: none;
            border-radius: 10px;
            cursor: pointer;
        }



.capsule-container {
    display: flex;
    flex-wrap: wrap; /* Позволяет переходить на новую строку для избыточных элементов */
    gap: 20px;
    justify-content: flex-start; /* Выравнивание комбинаций по начальной точке контейнера */
}

.row {
display: flex
;
    flex-direction: row-reverse;
    gap: 10px;
    width: 200px;
    flex-wrap: wrap;
    justify-content: space-between;
}

.clothing-image {
    width: 100px;
    height: 100px;
}


 
    </style>
</head>
<body>
<form id="form1" runat="server">
    <div id="header">
        <h1>Online Stilist</h1>
    </div>

    <asp:Button ID="Button1" runat="server" Text="Получить капсульный гардероб" CssClass="btn-capsule" OnClick="Button1_Click" />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <a href="HomePage.aspx" class="btn btn-home">На главную</a>

<div id="capsule-container">
    <asp:PlaceHolder ID="placeholder" runat="server"></asp:PlaceHolder>
</div>

    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>


</form>
</body>
</html>
