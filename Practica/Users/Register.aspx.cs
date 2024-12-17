using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.Security;
using System.Security.Cryptography;
using BCrypt.Net;
using System.Web.Helpers;

namespace Practica.Users
{
	public partial class Register : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void btnRegister_Click(object sender, EventArgs e)
		{
			string login = nickname.Text;
			string password = this.password.Text;
			string emailOrPhone = phone_email.Text;
			string confirmedPassword = confirm_password.Text;

			if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(emailOrPhone) || string.IsNullOrEmpty(confirmedPassword))
			{
				lblError.Text = "Все поля обязательны для заполнения.";
				return;
			}

			if (password != confirmedPassword)
			{
				lblError.Text = "Пароли не совпадают.";
				return;
			}


			// Хеширование пароля с помощью BCrypt
			string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

			string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

			string query = "INSERT INTO [dbo].[MyUser] (Nickname, Email_or_PhoneNumber, RegistrationDate, Password) VALUES (@Nickname, @EmailOrPhone, @RegistrationDate, @Password)";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@Nickname", login);
					command.Parameters.AddWithValue("@EmailOrPhone", emailOrPhone);
					command.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);
					command.Parameters.AddWithValue("@Password", hashedPassword); // Добавляем хешированный пароль


					try
					{
						connection.Open();
						int rowsAffected = command.ExecuteNonQuery();

						if (rowsAffected > 0)
						{
							Response.Redirect("HomePage.aspx");
						}
						else
						{
							lblError.Text = "Ошибка регистрации.";
						}
					}
					catch (Exception ex)
					{
						lblError.Text = "Ошибка базы данных: " + ex.Message;
					}
				}
			}
		}

	}
}
