<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WardrobItem.aspx.cs" Inherits="Practica.Users.WardrobItem" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Online Stilist</title>


    <style>
        body {
            background-color: lightblue;
        }

        .image-container {
            width: 25%;
            display: flex;
            flex-wrap: wrap;
            justify-content: flex-start;
        }

        .image-item {
            width: 23%;
            margin: 1%;
            box-sizing: border-box;
        }

        #home-button {
            position: fixed;
            bottom: 10px;
            right: 10px;
            display: block;
        }

            #home-button img {
                width: 30px;
                height: 30px;
            }

        .file-upload {
            display: flex;
            align-items: center;
            gap: 20px;
        }

        .file-input {
            background-color: lightblue;
            padding: 5px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .upload-button {
            background-color: lightgreen;
            color: white;
            padding: 8px 15px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

            .upload-button.disabled {
                background-color: gray !important;
                color: white !important;
                cursor: default !important;
                pointer-events: none !important;
            }



            .upload-button.enabled {
                background-color: lightgreen;
                color: white;
                cursor: pointer;
                pointer-events: auto;
            }

        .input-group {
            display: inline-block;
            margin-right: 20px;
            vertical-align: middle;
        }

            .input-group label {
                display: inline-block;
                margin-right: 5px;
            }
    </style>


    <script>
        document.addEventListener('DOMContentLoaded', function () {
            const fileUpload = document.getElementById('FileUpload1');
            const uploadButton = document.getElementById('btnUpload');

            uploadButton.classList.add('disabled'); 

            fileUpload.addEventListener('change', function () {
                if (fileUpload.files.length > 0) {
                    uploadButton.classList.remove('disabled');
                    uploadButton.classList.add('enabled');
                } else {
                    uploadButton.classList.remove('enabled');
                    uploadButton.classList.add('disabled');
                }
            });
        });
    </script>


</head>
<body>
    <form id="form1" runat="server">
        <a href="HomePage.aspx" class="nav-button" id="home-button">
            <img src="../image/comeBack.png" alt="Домой" />
        </a>
        <div class="container">
            <h1>Online Stilist</h1>

            <div class="file-upload">
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="file-input" ClientIDMode="Static" />
                <asp:Button ID="btnUpload" runat="server" Text="Загрузить изображение" OnClick="btnUpload_Click" CssClass="upload-button" ClientIDMode="Static" />
            </div>


            <div class="input-group">
                <label for="ddlType">Тип одежды:</label>
                <asp:DropDownList ID="ddlType" runat="server">
                    <asp:ListItem Value="Цепочка">Цепочка</asp:ListItem>
                    <asp:ListItem Value="Кольцо">Кольцо</asp:ListItem>
                    <asp:ListItem Value="Сумка">Сумка</asp:ListItem>
                    <asp:ListItem Value="Обувь">Обувь</asp:ListItem>
                    <asp:ListItem Value="Рубашка">Рубашка</asp:ListItem>
                    <asp:ListItem Value="Футболка">Футболка</asp:ListItem>
                    <asp:ListItem Value="Свитер">Свитер</asp:ListItem>
                    <asp:ListItem Value="Пальто">Пальто</asp:ListItem>
                    <asp:ListItem Value="Куртка">Куртка</asp:ListItem>
                    <asp:ListItem Value="Шорты">Шорты</asp:ListItem>
                    <asp:ListItem Value="Юбка">Юбка</asp:ListItem>
                    <asp:ListItem Value="Платье">Платье</asp:ListItem>
                    <asp:ListItem Value="Кофта">Кофта</asp:ListItem>
                    <asp:ListItem Value="Джинсы">Джинсы</asp:ListItem>
                    <asp:ListItem Value="Брюки">Брюки</asp:ListItem>
                    <asp:ListItem Value="Топ">Топ</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="input-group">
                <label for="ddlColor">Цвет:</label>
                <asp:DropDownList ID="ddlColor" runat="server">
                    <asp:ListItem Value="Бордовый">Бордовый</asp:ListItem>
                    <asp:ListItem Value="Хаки">Хаки</asp:ListItem>
                    <asp:ListItem Value="Серебрянный">Серебрянный</asp:ListItem>
                    <asp:ListItem Value="Золотой">Золотой</asp:ListItem>
                    <asp:ListItem Value="Лиловый">Лиловый</asp:ListItem>
                    <asp:ListItem Value="Бирюзовый">Бирюзовый</asp:ListItem>
                    <asp:ListItem Value="голубой">Голубой</asp:ListItem>
                    <asp:ListItem Value="Бежевый">Бежевый</asp:ListItem>
                    <asp:ListItem Value="Серый">Серый</asp:ListItem>
                    <asp:ListItem Value="Коричневый">Коричневый</asp:ListItem>
                    <asp:ListItem Value="Розовый">Розовый</asp:ListItem>
                    <asp:ListItem Value="Фиолетовый">Фиолетовый</asp:ListItem>
                    <asp:ListItem Value="Оранжевый">Оранжевый</asp:ListItem>
                    <asp:ListItem Value="Желтый">Желтый</asp:ListItem>
                    <asp:ListItem Value="Зеленный">Зеленый</asp:ListItem>
                    <asp:ListItem Value="Красный">Красный</asp:ListItem>
                    <asp:ListItem Value="Синий">Синий</asp:ListItem>
                    <asp:ListItem Value="Белый">Белый</asp:ListItem>
                    <asp:ListItem Value="Черный">Черный</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="input-group">
                <label for="ddlSeason">Сезон:</label>
                <asp:DropDownList ID="ddlSeason" runat="server">
                    <asp:ListItem Value="Зима">Зима</asp:ListItem>
                    <asp:ListItem Value="Весна">Весна</asp:ListItem>
                    <asp:ListItem Value="Лето">Лето</asp:ListItem>
                    <asp:ListItem Value="Осень">Осень</asp:ListItem>
                    <asp:ListItem Value="Зима-Весна">Зима-Весна</asp:ListItem>
                    <asp:ListItem Value="Осень-Зима">Осень-Зима</asp:ListItem>
                    <asp:ListItem Value="Лето-Осень">Лето-Осень</asp:ListItem>
                    <asp:ListItem Value="Весна-Лето">Весна-Лето</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="input-group">
                <label for="ddlStyle">Стиль:</label>
                <asp:DropDownList ID="ddlStyle" runat="server">
                    <asp:ListItem Value="Уличный">Уличный</asp:ListItem>
                    <asp:ListItem Value="Романтический">Романтический</asp:ListItem>
                    <asp:ListItem Value="Классический">Классический</asp:ListItem>
                    <asp:ListItem Value="Вечерний">Вечерний</asp:ListItem>
                    <asp:ListItem Value="Деловой">Деловой</asp:ListItem>
                    <asp:ListItem Value="Спортивный">Спортивный</asp:ListItem>
                    <asp:ListItem Value="Повседневный">Повседневный</asp:ListItem>
                </asp:DropDownList>
            </div>

            <asp:DataList ID="DataList1" runat="server" RepeatColumns="9" Visible="false">
                <ItemTemplate>
                    <asp:Image ID="UploadedImage" runat="server" ImageUrl='<%# ResolveUrl(Container.DataItem.ToString()) %>' Width="150px" Height="150px" />
                </ItemTemplate>
            </asp:DataList>
        </div>


        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

    </form>

</body>
</html>
