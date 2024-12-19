using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace Practica.Users
{
	public partial class WardrobItem : System.Web.UI.Page
	{
		protected FileUpload GetFileUpload1()
		{
			return FileUpload1;
		}

		protected void btnUpload_Click(object sender, EventArgs e)
		{
			if (!FileUpload1.HasFile)
			{
				Label1.Text = "Ошибка: Файл не выбран.";
				return;
			}

			int userId = GetUserID();

			if (userId == 0)
			{
				Label1.Text = "Ошибка: Необходимо войти в систему.";
				return;
			}

			try
			{
				string fileName = Path.GetFileName(FileUpload1.FileName);
				string uploadsFolder = "~/uploads";
				string filePath = Path.Combine(Server.MapPath(uploadsFolder), fileName);

				if (string.IsNullOrWhiteSpace(fileName))
				{
					Label1.Text = "Ошибка: Имя файла не может быть пустым.";
					return;
				}

				string fileExtension = Path.GetExtension(fileName).ToLower();
				if (!new string[] { ".jpg", ".jpeg", ".png", ".gif" }.Contains(fileExtension))
				{
					Label1.Text = "Ошибка: Поддерживаются только изображения форматов JPG, JPEG, PNG и GIF.";
					return;
				}

				if (FileUpload1.PostedFile.ContentLength > 20 * 1024 * 1024) 
				{
					Label1.Text = "Ошибка: Максимальный размер файла - 20 МБ.";
					return;
				}

				if (System.IO.File.Exists(filePath))
				{
					Label1.Text = "Ошибка: Файл с таким именем уже существует. Пожалуйста, измените имя файла.";
					return;
				}

				FileUpload1.SaveAs(filePath);


				string relativeUrl = uploadsFolder + "/" + fileName;
				string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
				string query = "INSERT INTO Clothing (Type, Color, Season, Style, ImagePath, DateAdded, UserID) VALUES (@Type, @Color, @Season, @Style, @ImagePath, @DateAdded, @UserID)";

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@Type", ddlType.SelectedValue ?? "");
						command.Parameters.AddWithValue("@Color", ddlColor.SelectedValue ?? "");
						command.Parameters.AddWithValue("@Season", ddlSeason.SelectedValue ?? "");
						command.Parameters.AddWithValue("@Style", ddlStyle.SelectedValue ?? "");

						command.Parameters.AddWithValue("@ImagePath", relativeUrl);
						command.Parameters.AddWithValue("@DateAdded", DateTime.Now);
						command.Parameters.AddWithValue("@UserID", userId);

						try
						{
							connection.Open();
							command.ExecuteNonQuery();
							Label1.Text = "Изображение успешно загружено!";
							LoadUserImages(userId); // Перезагрузка изображений
						}

						catch (SqlException ex)
						{
							Label1.Text = $"Ошибка базы данных: {ex.Message}";
						}
						catch (System.IO.IOException ex)
						{
							Label1.Text = $"Ошибка файла: {ex.Message}";
						}
						catch (Exception ex)
						{
							Label1.Text = $"Непредвиденная ошибка (внутренний catch): {ex.Message}";

						}
						finally
						{
							// Это относится к внутреннему try
							FileUpload1.Dispose(); // Освобождение ресурсов FileUpload
							this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ResetForm", "document.forms[0].reset();", true);

						}
					}
				}
			}
			catch (Exception ex)
			{
				Label1.Text = $"Непредвиденная ошибка (внешний catch): {ex.Message}";

			}
		}
		protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				System.Data.DataRowView rowView = (System.Data.DataRowView)e.Row.DataItem;
				string imagePath = rowView["ImagePath"].ToString();
				Image image = (Image)e.Row.FindControl("Image1");
				if (image != null)
				{
					image.ImageUrl = ResolveUrl(imagePath);
					image.Width = Unit.Pixel(30);
					image.Height = Unit.Pixel(30);

				}
			}
		}
		private void LoadUserImages(int userId)
		{
			string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
			string query = "SELECT ImagePath FROM Clothing WHERE UserID = @UserID";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@UserID", userId);

					try
					{
						connection.Open();
						using (SqlDataReader reader = command.ExecuteReader())
						{
							List<string> imageUrls = new List<string>();
							while (reader.Read())
							{
								imageUrls.Add(reader["ImagePath"].ToString());
							}

							if (imageUrls.Count > 0)
							{
								DataList1.DataSource = imageUrls;
								DataList1.DataBind();
								DataList1.Visible = true;


							}

						}
					}
					catch (Exception ex)
					{
						Label1.Text = "Ошибка при загрузке изображений: " + ex.Message;

					}
				}
			}
		}

		private int GetUserID()
		{
			if (Session["ID"] != null && int.TryParse(Session["ID"].ToString(), out int userId))
			{
				return userId;
			}
			else
			{

				if (Request.Cookies["ID"] != null && int.TryParse(Request.Cookies["ID"].Value, out userId))
				{
					return userId;
				}
				else
				{
					throw new Exception("Пользователь не аутентифицирован. Пожалуйста, войдите в систему.");

				}
			}
		}
	}
}