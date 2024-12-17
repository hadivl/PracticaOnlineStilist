using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.Security;
using System.Configuration;
using BCrypt.Net;

namespace Practica.Users
{
	public partial class Login : Page
	{

		protected void btnLogin_Click(object sender, EventArgs e)
		{
			string login = nickname.Text;
			string password = this.password.Text;


			if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
			{
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Логин и пароль обязательны.');", true);
				return;
			}

			string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
			string query = "SELECT Password, ID, Nickname, Email_or_PhoneNumber FROM [dbo].[MyUser] WHERE Nickname = @Login";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@Login", login);

					try
					{
						connection.Open();
						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.Read())
							{
								string hashedPasswordFromDb = reader["Password"].ToString();
								int userId = (int)reader["ID"];

								if (BCrypt.Net.BCrypt.Verify(password, hashedPasswordFromDb))
								{
									Session["ID"] = userId;
									Session["Nickname"] = reader["Nickname"].ToString();
									Session["EmailOrPhone"] = reader["Email_or_PhoneNumber"].ToString();
									Response.Redirect("HomePage.aspx");
								}
								else
								{
									ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Неверный пароль.');", true);
								}
							}
							else
							{
								ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Пользователь не найден.');", true);
							}
						}
					}
					catch (Exception ex)
					{

						ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ошибка: " + ex.Message + "');", true);
					}
				}
			}
		}
	}
}
