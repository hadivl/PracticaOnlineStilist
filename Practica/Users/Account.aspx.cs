using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Practica.Users
{
	public partial class Account : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				LoadUserData();
			}
		}

		private void LoadUserData()
		{

			if (Session["ID"] != null) // Проверка наличия ID пользователя в сессии
			{
				int userID = Convert.ToInt32(Session["ID"]);

				string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
				string query = "SELECT Nickname, Email_or_PhoneNumber FROM MyUser WHERE ID = @ID";

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@ID", userID);

						try
						{
							connection.Open();
							using (SqlDataReader reader = command.ExecuteReader())
							{
								if (reader.Read())
								{
									lblNickname.Text = reader["Nickname"].ToString();
									lblEmailOrPhone.Text = reader["Email_or_PhoneNumber"].ToString();
								}
								else
								{

									lblError.Text = "Ошибка: пользователь не найден.";
								}
							}
						}
						catch (Exception ex)
						{
							lblError.Text = "Ошибка базы данных: " + ex.Message;
						}
					}
				}
			}
			else
			{
				// Пользователь не авторизован - перенаправление на страницу входа
				Response.Redirect("Login.aspx");
			}
		}



		protected void LogoutButton_Click(object sender, EventArgs e)
		{
			Session.Clear();
			Response.Redirect("Login.aspx");
		}
	}
}
