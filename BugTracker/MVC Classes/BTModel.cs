using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BugTracker.Properties;
using Microsoft.SqlServer.Server;
using BugTracker.Data_Classes;
using BugTracker.Utility_Classes;
using BugTracker.Manager_Classes;
using System.Data.SQLite;
using System.Windows;

namespace BugTracker {

	public class BTModel {

		bool Test;

		private SQLiteConnection _connection;
		public SQLiteConnection connection { get { return _connection; } }


		private string EmailCode;
		private string EmailPledge;
		private string PasswordPledge;

		private Account _ActiveAccount = null;
		public Account ActiveAccount { get { return _ActiveAccount; } }

		private bool _LoggedIn = false;
		public bool LoggedIn { get { return _LoggedIn; } }

		private AccountsManager _AccountManager;
		private BugsManager _BugManager;
		private ProjectsManager _ProjectManager;

		public BTModel(bool IsTest) {

			_AccountManager = new AccountsManager(this, IsTest);
			_BugManager = new BugsManager(this, IsTest);
			_ProjectManager = new ProjectsManager(this, IsTest);

			PopulateDatabase();

			Test = IsTest;
		}


		public SuccessMessage InitiateSignUp(string Email, string Password) {

			if(!Regex.IsMatch(Email, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*")) {
				return new SuccessMessage(false, "That is not a valid email address");
			}
			if(Email.Length > 25) {
				return new SuccessMessage(false, "Emails cannot be more than 25 characters");
			}
			if(Password.Length < 10) {
				return new SuccessMessage(false, "Passwords must be at least 10 characters");
			}
			if(Password.Length > 25) {
				return new SuccessMessage(false, "Passwords cannot be more than 25 characters");
			}
			if(FindAccount(Email)) {
				return new SuccessMessage(false, "An account with that email already exists");
			}

			Random r = new Random();
			int rInt = r.Next(0, 999999);
			int range = 999999;
			range = Convert.ToInt32(r.NextDouble() * range);
			if(range < 100000) range *= 10;
			EmailCode = range.ToString();
			EmailPledge = Email;
			PasswordPledge = Password;
			SendEmail(EmailPledge, "Thank you for signing up for BugTracker, please enter this code in the application: " + EmailCode);

			return new SuccessMessage();
		}
		public SuccessMessage ConfirmSignUp(string Name, string Code) {
			if(Code != EmailCode) {
				return new SuccessMessage(false, "Your code is incorrect");
			}
			_AccountManager.CreateAccount(EmailPledge, Name, PasswordPledge);
			LoginAccount(EmailPledge, PasswordPledge);
			return new SuccessMessage();
		}
		public SuccessMessage LoginAccount(string Email, string Password) {

			if(Password.Length < 10 || Password.Length > 25)
				return (new SuccessMessage(false, "Your password must be between 10 and 25 characters"));

			_ActiveAccount = _AccountManager.GetAccount(Email, Password);
			if(_ActiveAccount == null) {
				return new SuccessMessage(false, "Account could not be found") ;
			}
			_LoggedIn = true;
			return new SuccessMessage();
		}
		public void LogOut() {
			_ActiveAccount = null;
			_LoggedIn = false;
		}


		public Account GetAccount(string Email, string Password) {
			return _AccountManager.GetAccount(Email,Password);
		}
		public Account GetAccount(int Id) {
			return _AccountManager.GetAccount(Id);
		}
		public bool FindAccount(string Email) {
			return _AccountManager.DoesAccountExist(Email);
		}
		public SuccessMessage EditAccountRole(int Id, string Role) {
			if(Id == _ActiveAccount.Id) return new SuccessMessage(false, "You cannot edit your own account");
			return _AccountManager.EditAccountRole(Id, Role);
		}
		public SuccessMessage DeleteAccount(int Id) {
			if(Id == _ActiveAccount.Id) return new SuccessMessage(false, "You cannot delete your own account");
			return _AccountManager.DeleteAccount(Id);
		}
		public SuccessMessage ChangeMyPassword(string NewPassword) {

			if(NewPassword.Length < 10 || NewPassword.Length > 25)
				return new SuccessMessage(false, "Passwords must be between 10 and 25 characters");
			Console.WriteLine("Old PW:  " + _ActiveAccount.Password);
			SuccessMessage ChangePasswordAttempt = _AccountManager.ChangeMyPassword(_ActiveAccount, NewPassword);
			Console.WriteLine("New PW:  " + _ActiveAccount.Password);
			return ChangePasswordAttempt;
		}

		public List<Account> GetAllAccounts() {
			return _AccountManager.GetAllAccounts();
		}
		public SuccessMessage AssignAccountToProject(int AccountId, int ProjectId) {

			if(_ActiveAccount.Role != "Administrator")
				return new SuccessMessage(false, "You must be an administrator to assign engineers");

			if(_AccountManager.GetAccount(AccountId).Role == "Guest")
				return new SuccessMessage(false, "Guests cannot be assigned to projects");

			SuccessMessage AssignAttempt =  _ProjectManager.AssignAccountToProject(AccountId, ProjectId);

			if (AssignAttempt.Success && Test == false)
				UpdateProject(ProjectId, GetAccount(AccountId).Name + " was assigned to the project.");

			return AssignAttempt;

		}
		public SuccessMessage RemoveAccountFromProject(int AccountId, int ProjectId) {


			if(!_ActiveAccount.Role.Equals("Administrator")) {
				return new SuccessMessage(false, "You must be an administrator to assign engineers");
			}

			SuccessMessage RemoveAttempt = _ProjectManager.RemoveAccountFromProject(AccountId, ProjectId);

			if (RemoveAttempt.Success && Test == false)
				UpdateProject(ProjectId, GetAccount(AccountId).Name + " was removed from the project.");

			return RemoveAttempt;
		}
		public void CreateAccount(string Email, string Name, string Password) {
			if(!_AccountManager.DoesAccountExist(Email))
				_AccountManager.CreateAccount(Email, Name, Password);
		}
		public void ChangeMyPicture(Bitmap Image) {
			_AccountManager.ChangeMyPicture(_ActiveAccount, Image);
			_ActiveAccount = _AccountManager.GetAccount(_ActiveAccount.Email, _ActiveAccount.Password);
		}
		public bool IsAccountOnProject(int ProjectId) {
			return _AccountManager.IsAccountOnProject(_ActiveAccount.Id, ProjectId);
		}
		public bool IsActiveAccountAdministrator() {
			if(_ActiveAccount != null && _ActiveAccount.Role == "Administrator") return true;
			return false;
		}

		public List<Project> GetMyProjects() {
			if(_ActiveAccount == null)
				return new List<Project>();
			else
				return _ProjectManager.GetMyProjects(_ActiveAccount.Id);
		}
		public List<Project> GetMyProjects(int Id) {

			if(_ActiveAccount == null)
				return new List<Project>();

			return _ProjectManager.GetMyProjects(_ActiveAccount.Id);
		}
		public List<Project> GetProjects() {
			if(_ActiveAccount == null) new List<Project>();
			return _ProjectManager.GetProjects();
		}
		public List<Account> GetAccountsOnProject(int Id) {
			return _ProjectManager.GetAccountsOnProject(Id);
		}
		public List<Account> GetAccountsOffProject(int Id) {
			return _ProjectManager.GetAccountsOffProject(Id);
		}
		public SuccessMessage GetProjectOverview(int Id) {

			if(_ActiveAccount.Role != "Administrator" && !_AccountManager.IsAccountOnProject(_ActiveAccount.Id, Id))
				return new SuccessMessage(false, "You must be an administrator to view projects you are not assigned to");

			return new SuccessMessage(true, _ProjectManager.GetProjectOverview(Id));

		}
		public SuccessMessage CreateProject(string Name, string Description, string Designation) {
			if(Designation.Length != 2)		return new SuccessMessage(false, "Your bug designation cannot be any other length than 2 " + Designation);
			if(Name.Length < 10)			return new SuccessMessage(false, "Your project name is too short");
			if(Name.Length > 50)			return new SuccessMessage(false, "Your project name cannot be more than 50 characters");
			if(Description.Length < 10)		return new SuccessMessage(false, "Your description cannot be blank");
			if(Description.Length > 500)	return new SuccessMessage(false, "Your description cannot be more than 500 characters");

			// Check if project name already exists //
			if(_ProjectManager.DoesProjectExist(Name))
				return new SuccessMessage(false, "A project with that name already exists");

			// Check if bug designation exists //
			if(_BugManager.DoesBugDesignationExist(Designation))
				return new SuccessMessage(false, "A project with that bug designation already exists");

			// Create Project //
			_ProjectManager.CreateProject(Name, Description, Designation, _ActiveAccount.Name);

			return new SuccessMessage(true, Name + " was successfully created");
		}
		public SuccessMessage RetireProject(int Id) {
			if(_ActiveAccount.Role != "Administrator")
				return new SuccessMessage(false, "Only administrators can retire projects");
			return _ProjectManager.RetireProject(Id, _ActiveAccount.Name);
		}
		public List<ProjectUpdate> ViewProjectUpdates(int ProjectId) {
			if (ClearanceToView(ProjectId))
				return _ProjectManager.ViewProjectUpdates(ProjectId);

			return new List<ProjectUpdate>();
		}
		public void UpdateProject(int Id, string Description) {
			if(Description.Length > 50) return;
			_ProjectManager.UpdateProject(Id, Description);
		}

		public SuccessMessage ReportBug(int ProjectId, string Description) {
			return _BugManager.ReportBug(ProjectId, Description);
		}
		public List<Bug> GetMyBugs() {
			return _BugManager.GetMyBugs(_ActiveAccount.Id);
		}
		public List<Bug> GetMyBugs(int Id) {
			return _BugManager.GetMyBugs(Id);
		}
		public List<Bug> GetBugsFromProject(int Id) {
			return _BugManager.GetBugsFromProject(Id);
		}
		public int OpenBugsInProjectCount(int Id) {

			if(ClearanceToView(Id)) {
				return _BugManager.OpenBugsInProjectCount(Id);
			}
			else return 0;
		}
		public int BugsInProjectCount(int Id) {
			return _BugManager.BugsInProjectCount(Id);
		}
		public SuccessMessage SubmitBug(string Designation) {
			return _BugManager.SubmitBug(Designation);
		}
		public List<BugUpdate> GetBugUpdates(string Designation) {
			return _BugManager.GetBugUpdates(Designation);
		}
		public SuccessMessage UpdateBug(string Designation, string Description) {
				return _BugManager.UpdateBug(Designation, Description);
		}
		public List<Bug> GetSubmittedBugs() {
			return _BugManager.GetSubmittedBugs();
		}
		public List<Bug> GetUnassignedBugs() {
			return _BugManager.GetUnassignedBugs();
		}
		public SuccessMessage ResolveBug(string Designation) {
			if(_ActiveAccount.Role != "Administrator")
				return new SuccessMessage(false, "Only administrators can resolve bugs");


			return _BugManager.ResolveBug(Designation);
		}
		public SuccessMessage RejectBug(string Designation) {
			if(_ActiveAccount.Role != "Administrator")
				return new SuccessMessage(false, "You must be an administrator in order to reject bugs");


			return _BugManager.RejectBug(Designation);
		}
		public SuccessMessage AssignBug(string Designation, int Id) {
			if(_ActiveAccount.Role != "Administrator")
				return new SuccessMessage(false, "You must be an administrator in order to assign Bugs");

			return _BugManager.AssignBug(Designation, Id);
		}
		public void UnassignBug(string Designation) {
			_BugManager.UnassignBug(Designation);
		}

		public bool ClearanceToView(int ProjectId) {
			if(_ActiveAccount.Role == "Administrator") {
				return true;
			}
			return _AccountManager.IsAccountOnProject(_ActiveAccount.Id, ProjectId);
		}
		public string GetProjectDesignation(int ProjectId) {

			string query = "SELECT BugDesignation FROM Projects WHERE ProjectId = @Id";

			using(SQLiteCommand command = new SQLiteCommand(query, _connection)) {
				command.Parameters.AddWithValue("@Id", ProjectId);
				SQLiteDataReader DataReader = command.ExecuteReader();
				if(DataReader.Read())
					return DataReader.GetString(0);
			}
			return "";
		}
		private void SendEmail(string _Address, string _Body) {

			//Email Stuff For Login Info

			var smtpClient = new SmtpClient() {
				Host = "smtp.gmail.com",
				Port = 587,
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential() {
					UserName = "EthanDevMail@gmail.com",
					Password = "Stormhawk016"
				}
			};
			MailAddress FromEmail = new MailAddress("EthanDevMail@gmail.com", "Bug Tracker Bot");
			MailAddress ToEmail = new MailAddress(_Address, "Someone");
			MailMessage Message = new MailMessage() {
				From = FromEmail,
				Subject = "Test Subject",
				Body = _Body,
			};
			Message.To.Add(ToEmail);
			smtpClient.Send(Message);

		}

		private void PopulateDatabase() {
			Console.WriteLine("Checking if database needs to be created...");
			String AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			Directory.CreateDirectory(Path.Combine(AppDataPath, "Bug Tracker"));
			bool Populate = !File.Exists(AppDataPath + "\\Bug Tracker\\BugTrackerDatabase.sqlite");
			

			if(Populate) {
				Console.WriteLine("Creating and populating database");
				File.Delete(AppDataPath + "\\Bug Tracker\\BugTrackerDatabase.sqlite");
				SQLiteConnection.CreateFile(AppDataPath + "\\Bug Tracker\\BugTrackerDatabase.sqlite");
				_connection = new SQLiteConnection("DataSource=" + AppDataPath + "\\Bug Tracker\\BugTrackerDatabase.sqlite; Version=3;");
				_connection.Open();

				// Create Tables
				using(SQLiteCommand command = new SQLiteCommand("" +
					"CREATE TABLE \"UserAccounts\"(" +
					"\"UserId\"  int NOT NULL," +
					"\"UserEmail\" nvarchar(25) NOT NULL," +
					"\"UserName\"nvarchar(25) NOT NULL," +
					"\"UserRole\"nvarchar(13) NOT NULL," +
					"\"UserPassword\"nvarchar(25) NOT NULL," +
					"\"UserImage\" blob NOT NULL," +
					"PRIMARY KEY(\"UserId\"));", _connection)) {
					command.ExecuteNonQuery();
				}
				using(SQLiteCommand command = new SQLiteCommand("" +
					"CREATE TABLE Projects (" +
					"\"ProjectId\"      int NOT NULL," +
					"\"ProjectName\" nvarchar(50) NOT NULL, " +
					"\"ProjectDescription\" nvarchar(500) NOT NULL, " +
					"\"BugDesignation\" nchar(2) NOT NULL, " +
					"\"Retired\" bit NOT NULL,"+
					"PRIMARY KEY(\"ProjectId\"));", _connection)) {
					command.ExecuteNonQuery();
				}
				using(SQLiteCommand command = new SQLiteCommand("" +
					"CREATE TABLE Bugs (" +
					"\"ProjectId\" int NOT NULL, " +
					"\"AccountId\" int, " +
					"\"BugDesignation\" nvarchar(6) NOT NULL, " +
					"\"BugDescription\" nvarchar(100) NOT NULL, " +
					"\"BugStatus\" nvarchar(10) NOT NULL," +
					"PRIMARY KEY(\"BugDesignation\"));", _connection)) {
					command.ExecuteNonQuery();
				}
				using(SQLiteCommand command = new SQLiteCommand("" +
					"CREATE TABLE AccountsOnProjects (" +
					"\"AccountId\" int NOT NULL, " +
					"\"ProjectId\" int NOT NULL," +
					"FOREIGN KEY(AccountId) REFERENCES UserAccounts(UserId)" +
					"FOREIGN KEY(ProjectId) REFERENCES Projects(ProjectId)" +
					"PRIMARY KEY(\"AccountId\", \"ProjectId\"));", _connection)) {
					command.ExecuteNonQuery();
				}
				using(SQLiteCommand command = new SQLiteCommand("" +
					"CREATE TABLE BugUpdates (" +
					"\"BugDesignation\" nvarchar(6) NOT NULL, " +
					"\"UpdateDate\" datetime NOT NULL," +
					"\"UpdateDescription\" nvarchar(50) NOT NULL," +
					"FOREIGN KEY(BugDesignation) REFERENCES Bugs(BugDesignation));", _connection)) {
					command.ExecuteNonQuery();
				}
				using(SQLiteCommand command = new SQLiteCommand("" +
					"CREATE TABLE ProjectUpdates (" +
					"\"ProjectId\" int NOT NULL, " +
					"\"UpdateDate\" datetime NOT NULL," +
					"\"UpdateDescription\" nvarchar(50) NOT NULL," +
					"FOREIGN KEY(ProjectId) REFERENCES Projects(ProjectId));", _connection)) {
					command.ExecuteNonQuery();
				}


				// Create Accounts
				_AccountManager.CreateAccount("test@gmail.com", "Admin Account", "AdminAccount");
				_AccountManager.CreateAccount("test@gmail.com", "Engineer Account", "EngineerAccount");
				_AccountManager.CreateAccount("test@gmail.com", "Guest Account", "GuestAccount");
				_AccountManager.CreateAccount("test@gmail.com", "John Smith", "Password_Tony");
				_AccountManager.CreateAccount("test@gmail.com", "Jim Harris", "Password_Bruce");
				_AccountManager.CreateAccount("test@gmail.com", "Janet Howe", "Password_Reed");
				_AccountManager.CreateAccount("test@gmail.com", "Laura Vance", "Password_Shuri");


				_AccountManager.EditAccountRole(1, "Administrator");
				_AccountManager.EditAccountRole(2, "Engineer");
				_AccountManager.EditAccountRole(4, "Engineer");
				_AccountManager.EditAccountRole(5, "Engineer");
				_AccountManager.EditAccountRole(6, "Engineer");
				_AccountManager.EditAccountRole(7, "Engineer");


				LoginAccount("test@gmail.com", "AdminAccount");
				Console.WriteLine("Account Logged In: " + _ActiveAccount.Name);

				// Create Testing Suite Necessities
				_ProjectManager.CreateProject("Test Project 1", "A project used entirely for in house testing purposes.", "PO", "Admin Account");
				_ProjectManager.CreateProject("Test Project 2", "A project used entirely for in house testing purposes.", "PT", "Admin Account");
				_ProjectManager.AssignAccountToProject(1, 1);
				_ProjectManager.AssignAccountToProject(2, 1);
				_BugManager.ReportBug(1, "Sample Bug used for in house testing");
				_BugManager.ReportBug(1, "Sample Bug used for in house testing");
				_BugManager.ReportBug(1, "Sample Bug used for in house testing");
				_BugManager.ReportBug(1, "Sample Bug used for in house testing");
				_BugManager.AssignBug("PO-001", 1);
				_BugManager.AssignBug("PO-002", 1);
				_BugManager.AssignBug("PO-003", 2);
				_BugManager.AssignBug("PO-004", 2);

				LogOut();
				LoginAccount("test@gmail.com", "EngineerAccount");
				_BugManager.SubmitBug("PO-004");
				LogOut();
				LoginAccount("test@gmail.com", "AdminAccount");

				// Create Misc Projects
				_ProjectManager.CreateProject("Project Blue Sands", "An AI based project with the intent to turn all sand in the world blue.  With all the world's sand blue it will be impossible to distinguish beach from sky.", "BS", "Admin Account");
				_ProjectManager.CreateProject("Project Goliath", "An AI based project with the intent of attacking anyone who grows too tall.", "PG", "Admin Account");
				_ProjectManager.CreateProject("Thin Paper Foundation", "A project intended to create a solution to supply to a company that wants to make incredibly thin paper for comedic purposes.", "TP", "Admin Account");

				// Assign Accounts
				_ProjectManager.AssignAccountToProject(4, 3);
				_ProjectManager.AssignAccountToProject(5, 3);
				_ProjectManager.AssignAccountToProject(6, 3);
				_ProjectManager.AssignAccountToProject(5, 4);
				_ProjectManager.AssignAccountToProject(6, 4);
				_ProjectManager.AssignAccountToProject(7, 4);
				_ProjectManager.AssignAccountToProject(4, 5);
				_ProjectManager.AssignAccountToProject(7, 5);

				// Create Bugs
				_BugManager.ReportBug(3, "Blue sand dye is ending up looking too purple");
				_BugManager.ReportBug(3, "Massive shortage of blue dye");
				_BugManager.ReportBug(3, "Dye is not waterproof");
				_BugManager.ReportBug(4, "AI has proven too peaceful for violence");
				_BugManager.ReportBug(4, "Sensors unable to tell relative differences in height");
				_BugManager.ReportBug(4, "AI cannot connect to robot killer body");
				_BugManager.ReportBug(5, "Paper is too thick");
				_BugManager.ReportBug(5, "Paper is too serious");
				_BugManager.ReportBug(5, "Public does not seen to care about the comedicly thin paper product");

				// Assign Bugs
				_BugManager.AssignBug("BS-001", 4);
				_BugManager.AssignBug("BS-002", 5);
				_BugManager.AssignBug("PG-001", 6);
				_BugManager.AssignBug("PG-002", 7);
				_BugManager.AssignBug("TP-001", 7);
				_BugManager.AssignBug("TP-002", 4);

				LogOut();
			}
			else {
				Console.WriteLine("Not Populating Database");
				_connection = new SQLiteConnection("DataSource=" + AppDataPath + "\\Bug Tracker\\BugTrackerDatabase.sqlite; Version=3;");
				_connection.Open();
			}
		}
		public void Exit() {
			_connection.Close();
			_connection.Dispose();
		}
	}
}