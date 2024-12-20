using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using WebGrease.Activities;



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


		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				int userId = GetUserID();


				if (userId != -1)
				{
					List<List<Clothing>> combinations = FindSpecificClothes(userId);
					DisplayCombinations(combinations);
				}
			}
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			int userId = GetUserID();
			List<List<Clothing>> clothesCombinations = FindSpecificClothes(userId);
			List<Clothing> capsule = new List<Clothing>();

			if (clothesCombinations.Count > 0)
			{
				foreach (var combination in clothesCombinations)
				{
					capsule.AddRange(combination);
				}


				DisplayCapsuleWardrobe(new List<List<Clothing>> { capsule });

				SaveCapsuleWardrobe(userId, "Название капсулы");
			}

		}

		private List<List<Clothing>> FindSpecificClothes(int userId)
		{
			List<List<Clothing>> combinations = new List<List<Clothing>>();
			string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();

				List<Tuple<string, string>> queryCombinations = new List<Tuple<string, string>>()
		{
			Tuple.Create(
				"SELECT ImagePath FROM Clothing WHERE UserID = @UserID AND Type = 'Юбка' AND Color = 'Черный' AND Style = 'Повседневный' AND Season = 'Лето'",
				"SELECT ImagePath FROM Clothing WHERE UserID = @UserID AND Type = 'Рубашка' AND Color = 'Белый' AND Style = 'Повседневный' AND Season = 'Лето'"
			),
			Tuple.Create(
				"SELECT ImagePath FROM Clothing WHERE UserID = @UserID AND Type = 'Рубашка' AND Color = 'Белый' AND Style = 'Деловой' AND Season = 'Лето '",
				"SELECT ImagePath FROM Clothing WHERE UserID = @UserID AND Type = 'Брюки' AND Color = 'Черный' AND Style = 'Деловой' AND Season = 'Лето'"
			),
			Tuple.Create(
				"SELECT ImagePath FROM Clothing WHERE UserID = @UserID AND Type = 'Кофта' AND Color = 'Фиолетовый' AND Style = 'Спортивный' AND Season = 'Лето'",
				"SELECT ImagePath FROM Clothing WHERE UserID = @UserID AND Type = 'Брюки' AND Color = 'Фиолетовый' AND Style = 'Спортивный' AND Season = 'Лето'"
			),
			Tuple.Create(
				"SELECT ImagePath FROM Clothing WHERE UserID = @UserID AND Type = 'Шорты' AND Color = 'Белый' AND Style = 'Повседневный' AND Season = 'Лето '",
				"SELECT ImagePath FROM Clothing WHERE UserID = @UserID AND Type = 'Футболка' AND Color = 'Голубой' AND Style = 'Повседневный' AND Season = 'Лето'"
			)
		};




				foreach (var queryCombination in queryCombinations)
				{
					List<Clothing> combination = new List<Clothing>();
					combination.AddRange(GetClothesByQuery(connection, queryCombination.Item1, userId));
					combination.AddRange(GetClothesByQuery(connection, queryCombination.Item2, userId));
					combinations.Add(combination);
				}

			}

			return combinations;
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
			lblError.Text = "Вы не авторизованы, пожалуйста, войдите в учетную запись.";


			return -1;
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

			HtmlGenericControl containerDiv = new HtmlGenericControl("div");
			containerDiv.Attributes["class"] = "capsule-container";

			foreach (List<Clothing> look in capsuleWardrobe)
			{
				HtmlGenericControl divRow = new HtmlGenericControl("div");
				divRow.Attributes["class"] = "row";

				foreach (Clothing item in look)
				{
					System.Web.UI.WebControls.Image image = new System.Web.UI.WebControls.Image
					{
						ImageUrl = ResolveUrl(item.ImagePath),
						AlternateText = "Clothing Image",
						Width = 100,
						Height = 100,
						CssClass = "clothing-image"
					};

					HtmlGenericControl divCol = new HtmlGenericControl("div");
					divCol.Controls.Add(image);
					divRow.Controls.Add(divCol);
				}

				containerDiv.Controls.Add(divRow);
			}

			placeholder.Controls.Add(containerDiv);
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



		private void DisplayCombinations(List<List<Clothing>> combinations)//соединить с DisplayCapsuleWardrobe?
		{
			foreach (var combination in combinations)
			{
				Panel panel = new Panel();
				panel.CssClass = "combination-frame";


				foreach (var clothing in combination)
				{
					Image img = new Image();
					img.ImageUrl = clothing.ImagePath;
					img.AlternateText = "Одежда";
					img.CssClass = "image-item";

					panel.Controls.Add(img);
				}
				placeholder.Controls.Add(panel);
			}
		}

	}

}

