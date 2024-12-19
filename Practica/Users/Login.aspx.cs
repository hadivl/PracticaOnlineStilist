using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using BCrypt.Net;

namespace Practica.Users
{
	public partial class Login : Page
	{

		protected void btnLogin_Click(object sender, EventArgs e)
		{

			string login = nickname.Text;
			string emailOrPhone = phone_email.Text;
			string password = this.password.Text;

			string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					// Динамически формируем SQL-запрос
					string query = "SELECT Password, ID, Nickname, Email_or_PhoneNumber FROM [dbo].[MyUser] WHERE ";
					bool firstCondition = true; // Флаг для добавления "AND" или "OR"

					if (!string.IsNullOrEmpty(login))
					{
						query += "Nickname = @Login";
						firstCondition = false;
					}

					if (!string.IsNullOrEmpty(emailOrPhone))
					{
						if (!firstCondition)
						{
							query += " AND ";
						}

						query += "Email_or_PhoneNumber = @EmailOrPhone";
					}


					if (string.IsNullOrEmpty(emailOrPhone) && string.IsNullOrEmpty(login))
					{
						ShowError("Заполните поля");
						return;
					}

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						if (!string.IsNullOrEmpty(login))
						{
							command.Parameters.AddWithValue("@Login", login);
						}


						if (!string.IsNullOrEmpty(emailOrPhone))
						{
							command.Parameters.AddWithValue("@EmailOrPhone", emailOrPhone);
						}

						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.Read())
							{
								// Проверяем пароль
								if (BCrypt.Net.BCrypt.Verify(password, reader["Password"].ToString()))
								{
									SetSessionAndRedirect(reader);
									return;
								}
								else
								{
									ShowError("Неверный пароль.");
									return;
								}
							}
							else
							{
								// Ни логин, ни email не совпали
								if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(emailOrPhone))
								{

									ShowError("Неверный логин и/или email/телефон.");
								}
								else if (!string.IsNullOrEmpty(login))
								{
									ShowError("Неверный логин");


								}
								else if (!string.IsNullOrEmpty(emailOrPhone))
								{
									ShowError("Неверный email/телефон");
								}



								return;



							}
						}

					}
				}
			}
			catch (Exception ex)
			{
				ShowError("Ошибка базы данных: " + ex.Message);
				return;
			}


		}



		private void SetSessionAndRedirect(SqlDataReader reader)
		{
			Session["ID"] = reader["ID"];
			Session["Nickname"] = reader["Nickname"].ToString();
			Session["EmailOrPhone"] = reader["Email_or_PhoneNumber"].ToString();
			Response.Redirect("HomePage.aspx");
		}


		private void ShowError(string message)
		{
			ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{message}');", true);
		}
	}
}
