using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System;
using System.Web.UI.WebControls;
using System.Web.UI;



namespace Practica.Users
{

	public class Clothing
	{
		public int IDClothing { get; set; }
		public string ImagePath { get; set; }
		public string Style { get; set; }
		public string Color { get; set; }
		public string Season { get; set; }
		public string Type { get; set; }
	}

	public partial class WardrobeCapsule : System.Web.UI.Page
	{
		protected void Button1_Click(object sender, EventArgs e)
		{
			try
			{
				int userId = GetUserID();

				List<Clothing> capsule = FindSpecificClothes(userId);
				if (capsule.Count > 0)
				{
					DisplayCapsuleWardrobe(new List<List<Clothing>> { capsule });
					SaveCapsuleWardrobe(userId, "Название капсулы"); 
				}
				else
				{
					Label1.Text = "Вещи не найдены";
				}
			}
			catch (Exception ex)
			{
				Label1.Text = ex.Message;
			}
		}

		private List<Clothing> FindSpecificClothes(int userId)
		{
			List<Clothing> clothes = new List<Clothing>();
			string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string skirtQuery = "SELECT ImagePath FROM Clothing WHERE UserID = @UserID AND Type = 'Юбка' AND Color = 'Черный' AND Style = 'Повседневный' AND Season = 'Лето'";
				string shirtQuery = "SELECT ImagePath FROM Clothing WHERE UserID = @UserID AND Type = 'Рубашка' AND Color = 'Белый' AND Style = 'Повседневный' AND Season = 'Лето'";

				clothes.AddRange(GetClothesByQuery(connection, skirtQuery, userId));
				clothes.AddRange(GetClothesByQuery(connection, shirtQuery, userId));
			}

			return clothes;
		}

		private int GetUserID()
		{
			if (Session["ID"] != null && int.TryParse(Session["ID"].ToString(), out int userId))
			{
				return userId;
			}

			if (Request.Cookies["ID"] != null && int.TryParse(Request.Cookies["ID"].Value, out userId))
			{
				return userId;
			}

			throw new Exception("Пользователь не аутентифицирован."); 
		}

		private List<Clothing> GetClothesByQuery(SqlConnection connection, string query, int userId)
		{
			List<Clothing> clothes = new List<Clothing>();

			using (SqlCommand command = new SqlCommand(query, connection))
			{
				command.Parameters.AddWithValue("@UserID", userId);

				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						clothes.Add(new Clothing { ImagePath = reader["ImagePath"].ToString() });
					}
				}
			}
			return clothes;
		}

		private void DisplayCapsuleWardrobe(List<List<Clothing>> capsuleWardrobe)
		{
			placeholder.Controls.Clear();

			foreach (List<Clothing> look in capsuleWardrobe)
			{
				foreach (Clothing item in look)
				{
					System.Web.UI.WebControls.Image image = new System.Web.UI.WebControls.Image
					{
						ImageUrl = ResolveUrl(item.ImagePath),
						AlternateText = "Clothing Image",
						Width = 80,
						Height = 80,
						CssClass = "clothing-image"
					};

					placeholder.Controls.Add(image);
					placeholder.Controls.Add(new LiteralControl("<br />"));
				}
				placeholder.Controls.Add(new LiteralControl("<hr />"));
			}
		}



		private int SaveCapsuleWardrobe(int userId, string capsuleName)
		{
			string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				string query = "INSERT INTO CapsuleWardrobe (UserID, Name) VALUES (@UserID, @Name); SELECT SCOPE_IDENTITY();";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@UserID", userId);
					command.Parameters.AddWithValue("@Name", capsuleName);
					return Convert.ToInt32(command.ExecuteScalar());
				}
			}
		}

		private int GetClothingIdByImagePath(SqlConnection connection, string imagePath)
		{
			string normalizedImagePath = imagePath.Replace("~/", "");

			string query = "SELECT IDClothing FROM Clothing WHERE ImagePath = @ImagePath";

			using (SqlCommand command = new SqlCommand(query, connection))
			{
				command.Parameters.AddWithValue("@ImagePath", normalizedImagePath);
				object result = command.ExecuteScalar();

				return result != null && int.TryParse(result.ToString(), out int clothingId) ? clothingId : -1;
			}
		}


	}

}

	