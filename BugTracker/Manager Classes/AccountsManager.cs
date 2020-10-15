using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using BugTracker.Properties;
using BugTracker.Data_Classes;
using BugTracker.Utility_Classes;
using System;

namespace BugTracker.Manager_Classes {
	class AccountsManager {

		bool Test;
		BTModel Model;

		public AccountsManager(BTModel _Model, bool IsTest) {
			Test = IsTest;
			Model = _Model;
		}

		public void CreateAccount(string Email, string Name, string Password) {

			if(Email.Length > 25 || Password.Length < 10 || Password.Length > 25)
				return;

			int NewId = 1;
			string query = "SELECT UserId FROM UserAccounts";
			Console.WriteLine("Creating Account: " + Name);
			using(SQLiteDataReader DR = new SQLiteCommand(query, Model.connection).ExecuteReader()){
					while(DR.Read())
						NewId++;
			}
			

			query = "INSERT INTO UserAccounts VALUES (@Id, @Email, @Name, 'Guest', @Password, @Image)";
			using(SQLiteCommand command = new SQLiteCommand(query, Model.connection)) {
				command.Parameters.AddWithValue("@Id", NewId);
					command.Parameters.AddWithValue("@Email", Email);
					command.Parameters.AddWithValue("@Name", Name);
					command.Parameters.AddWithValue("@Password", Password);
					command.Parameters.AddWithValue("@Image", ConvertImageToBinary(Resources.spy));
					command.ExecuteScalar();
					Console.WriteLine("Created Account (" + NewId + ") - " + Name);
				}
			}
		

		public void ChangeMyPicture(Account ActiveAccount, Bitmap Image) {

			string query = "UPDATE UserAccounts " +
				"SET UserEmail = @Email, " +
				"UserName = @Name, " +
				"UserRole = @Role, " +
				"UserPassword = @Password, " +
				"UserImage = @Image " +
				"WHERE UserId = @Id"
				;

				using(SQLiteCommand command = new SQLiteCommand(query, Model.connection)) {
					command.Parameters.AddWithValue("@Email", ActiveAccount.Email);
					command.Parameters.AddWithValue("@Name", ActiveAccount.Name);
					command.Parameters.AddWithValue("@Password", ActiveAccount.Password);
					command.Parameters.AddWithValue("@Role", ActiveAccount.Role);
					command.Parameters.AddWithValue("@Image", ConvertImageToBinary(Image));
					command.Parameters.AddWithValue("@Id", ActiveAccount.Id);
					command.ExecuteScalar();
				}
		}
		public bool DoesAccountExist(string Email) {

			string query = "Select UserEmail From UserAccounts Where @Email = UserEmail";

			using(SQLiteCommand command = new SQLiteCommand(query, Model.connection)) {
			command.Parameters.AddWithValue("@Email", Email);
					SQLiteDataReader DR = command.ExecuteReader();

					if(DR.Read()) {
						return true;
					}
				}
				return false;
			}

		public Account GetAccount(string Email, string Password) {

			Account ReturnAccount = null;

			string query = "Select * From UserAccounts Where @Email = UserEmail AND @Password = UserPassword";

			using(SQLiteCommand command = new SQLiteCommand(query, Model.connection)) {
				command.Parameters.AddWithValue("@Email", Email);
				command.Parameters.AddWithValue("@Password", Password);
				using(SQLiteDataReader DR = command.ExecuteReader()) {
					if(DR.Read()) {
						ReturnAccount = new Account(DR.GetInt32(0), DR.GetString(1).ToString(), DR.GetValue(2).ToString(), DR.GetValue(3).ToString(), DR.GetValue(4).ToString(),
							//Resources.EmptyProfileGrey
							ConvertBinaryToImage(GetBytes(DR))
							);
					}
				}	
			}
			

			return ReturnAccount;
		}
		public Account GetAccount(int Id) {

			Account ReturnAccount = null;

			string query = " Select * From UserAccounts Where UserId = @Id";

			using(SQLiteCommand command = new SQLiteCommand(query, Model.connection)) {
				command.Parameters.AddWithValue("@Id", Id);
					using(SQLiteDataReader DR = command.ExecuteReader()) {
						if(DR.Read()) {
							ReturnAccount = new Account(DR.GetInt32(0), DR.GetValue(1).ToString(), DR.GetValue(2).ToString(), DR.GetValue(3).ToString(), DR.GetValue(4).ToString(), Resources.EmptyProfileGrey
								//ConvertBinaryToImage((byte[])DR.GetValue(5))
								);
					}
				}
			}

			return ReturnAccount;
		}

		public SuccessMessage EditAccountRole(int Id, string Role) {

			string query = " UPDATE UserAccounts SET UserRole = @Role WHERE UserId = @Id";
			if(Test == false) {
				using(SQLiteCommand command = new SQLiteCommand(query, Model.connection)) {
					command.Parameters.AddWithValue("@Id", Id);
					command.Parameters.AddWithValue("@Role", Role);
					command.ExecuteScalar();
				}
			}
			return new SuccessMessage();
		}
		public SuccessMessage DeleteAccount(int Id) {

			if(Test == false) {
				// DELETE PROJECT CONNECTIONS //

				using(SQLiteCommand command = new SQLiteCommand(" DELETE FROM AccountsOnProjects WHERE AccountId = @Id", Model.connection)) {
					command.Parameters.AddWithValue("@Id", Id);
					command.ExecuteScalar();
				}

				// UNASSIGN BUGS //

				using(SQLiteCommand command = new SQLiteCommand(" UPDATE Bugs SET AccountId = null WHERE AccountId = @Id", Model.connection)) {
					command.Parameters.AddWithValue("@Id", Id);
					command.ExecuteScalar();
				}


				// DELETE ACCOUNT//

				using(SQLiteCommand command = new SQLiteCommand(" DELETE FROM UserAccounts WHERE UserId = @Id", Model.connection)) {
					command.Parameters.AddWithValue("@Id", Id);
					command.ExecuteScalar();
				}
			}
			return new SuccessMessage();
		}
		public SuccessMessage ChangeMyPassword(Account ActiveAccount,string NewPassword) {

			string query = " UPDATE UserAccounts " +
				"SET UserEmail = @Email, " +
				"UserName = @Name, " +
				"UserRole = @Role, " +
				"UserPassword = @Password, " +
				"UserImage = @Image " +
				"WHERE UserId = @Id"
				;

			using(SQLiteCommand command = new SQLiteCommand(query, Model.connection)) {
				command.Parameters.AddWithValue("@Email", ActiveAccount.Email);
				command.Parameters.AddWithValue("@Name", ActiveAccount.Name);
				command.Parameters.AddWithValue("@Password", NewPassword);
				command.Parameters.AddWithValue("@Role", ActiveAccount.Role);
				command.Parameters.AddWithValue("@Image", ConvertImageToBinary(ActiveAccount.ProfilePicture));
				command.Parameters.AddWithValue("@Id", ActiveAccount.Id);
				command.ExecuteScalar();
			}

			return new SuccessMessage(true, "Password has been successfully changed");
		}
		public List<Account> GetAllAccounts() {

			string query = " SELECT * FROM UserAccounts";
			List<Account> Accounts = new List<Account>();

			using(SQLiteCommand command = new SQLiteCommand(query, Model.connection)) {
				SQLiteDataReader DataReader = command.ExecuteReader();
				while(DataReader.Read()) {
					Accounts.Add(new Account(DataReader.GetInt32(0), DataReader.GetValue(1).ToString(), DataReader.GetValue(2).ToString(), DataReader.GetValue(3).ToString(), DataReader.GetValue(4).ToString(),
						ConvertBinaryToImage(GetBytes(DataReader))));
				}
			}
			return Accounts;
		}
		public bool IsAccountOnProject(int AccountId, int ProjectId) {

				using(SQLiteCommand command = new SQLiteCommand(" SELECT * FROM AccountsOnProjects WHERE ProjectId = @PId AND AccountId = @AId", Model.connection)) {
					command.Parameters.AddWithValue("@PId", ProjectId);
					command.Parameters.AddWithValue("@AId", AccountId);
					using(SQLiteDataReader Reader = command.ExecuteReader()) {
						if(Reader.Read()) {
							return true;
						
					}
				}
			}
			return false;
		}

		byte[] ConvertImageToBinary(Image img) {
			using(MemoryStream ms = new MemoryStream()) {
				Bitmap img_bitmap = new Bitmap(img);
				img_bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
				return ms.ToArray();
			}
		}
		Image ConvertBinaryToImage(byte[] data) {
			using(MemoryStream ms = new MemoryStream(data)) {
				return Image.FromStream(ms);
			}
		}
		static byte[] GetBytes(SQLiteDataReader reader) {
			const int CHUNK_SIZE = 2 * 1024;
			byte[] buffer = new byte[CHUNK_SIZE];
			long bytesRead;
			long fieldOffset = 0;
			using(MemoryStream stream = new MemoryStream()) {
				while((bytesRead = reader.GetBytes(5, fieldOffset, buffer, 0, buffer.Length)) > 0) {
					stream.Write(buffer, 0, (int)bytesRead);
					fieldOffset += bytesRead;
				}
				return stream.ToArray();
			}
		}
	}
}
