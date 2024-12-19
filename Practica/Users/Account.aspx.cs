using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

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
			if (Session["ID"] != null && int.TryParse(Session["ID"].ToString(), out int userId))
			{
				string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
				string query = "SELECT Nickname, Email_or_PhoneNumber FROM MyUser WHERE ID = @ID";

				using (SqlConnection connection = new SqlConnection(connectionString))
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@ID", userId);

					try
					{
						connection.Open();
						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.Read())
							{
								UserNameLabel.Text = reader["Nickname"].ToString(); 
								UserContactLabel.Text = reader["Email_or_PhoneNumber"].ToString(); 
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
			else
			{
				Response.Redirect("Login.aspx"); // Перенаправление, если пользователь не авторизован
			}
		}

		protected void LogoutButton_Click(object sender, EventArgs e)
		{
			Session.Clear(); // Очистка сессии при выходе
			Response.Redirect("Login.aspx");
		}
	}
}

