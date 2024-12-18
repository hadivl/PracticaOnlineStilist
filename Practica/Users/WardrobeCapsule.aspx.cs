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
				int userId = GetUserID(); // проверяем аутентификацию

				List<Clothing> capsule = FindSpecificClothes(userId); // Передаем userId в FindSpecificClothes
				if (capsule.Count > 0)
				{
					DisplayCapsuleWardrobe(new List<List<Clothing>> { capsule });
				}
				else
				{
					Label1.Text = "Вещи не найдены";
				}
			}
			catch (Exception ex)
			{
				Label1.Text = ex.Message; // сообщение об ошибке аутентификации
			}
		}
		private List<Clothing> FindSpecificClothes(int userId)
		{
			List<Clothing> clothes = new List<Clothing>();
			string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;



			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				//пока только для проверки работы
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
			else if (Request.Cookies["ID"] != null && int.TryParse(Request.Cookies["ID"].Value, out userId))
			{
				return userId;
			}
			else
			{
				// исключение, если пользователь не найден
				throw new Exception("Пользователь не аутентифицирован. Пожалуйста, войдите в систему.");
			}
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
					System.Web.UI.WebControls.Image image = new System.Web.UI.WebControls.Image();
					image.ImageUrl = ResolveUrl(item.ImagePath);

					image.AlternateText = "Clothing Image";
					//image.CssClass = "clothing-image";
					placeholder.Controls.Add(image);
					placeholder.Controls.Add(new LiteralControl("<br />"));

					image.Width = 80; // Ширина 80
					image.Height = 80;
					image.CssClass = "clothing-image";//

					placeholder.Controls.Add(image);
					placeholder.Controls.Add(new LiteralControl("<br />"));
				}
				placeholder.Controls.Add(new LiteralControl("<hr />"));
			}
		}


	}
}