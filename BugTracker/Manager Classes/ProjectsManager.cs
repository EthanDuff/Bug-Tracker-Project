using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using BugTracker.Data_Classes;
using BugTracker.Utility_Classes;

namespace BugTracker.Manager_Classes {
	class ProjectsManager {

		bool Test;
		BTModel Model;

		public ProjectsManager(BTModel _Model, bool IsTest) {
			Test = IsTest;
			Model = _Model;
		}


		public List<Project> GetMyProjects(int Id) {

			string query = "SELECT * FROM Projects a INNER JOIN AccountsOnProjects b ON a.ProjectId = b.ProjectId WHERE b.AccountId = @MyId";
			List<Project> Projects = new List<Project>();

			using(SQLiteCommand command = new SQLiteCommand(query, Model.connection)) {
				command.Parameters.AddWithValue("@MyId", Id);
				using(SQLiteDataReader DataReader = command.ExecuteReader()) {
					while(DataReader.Read()) {
						Projects.Add(new Project(DataReader.GetInt32(0), DataReader.GetString(1), DataReader.GetString(2), DataReader.GetString(3)));
					}
				}
			}
			return Projects;
		}
		public List<Project> GetProjects() {
			List<Project> Projects = new List<Project>();

			string query = "SELECT * FROM Projects WHERE Retired = false";
			using(SQLiteDataReader DataReader = new SQLiteCommand(query, Model.connection).ExecuteReader()){
				while(DataReader.Read()) {
					Projects.Add(new Project(DataReader.GetInt32(0), DataReader.GetString(1), DataReader.GetString(2), DataReader.GetString(3)));
				}
			}
			return Projects;
		}
		public List<Account> GetAccountsOnProject(int Id) {

			string query = "SELECT UserId, UserEmail, UserName, UserRole FROM UserAccounts, AccountsOnProjects, Projects WHERE Projects.ProjectId = @Id AND Projects.ProjectId = AccountsOnProjects.ProjectId AND UserAccounts.UserId = AccountsOnProjects.AccountId ORDER BY UserName";

			List<Account> Accounts = new List<Account>();

			using(SQLiteCommand command = new SQLiteCommand(query, Model.connection)) {
				command.Parameters.AddWithValue("@Id", Id);
				using(SQLiteDataReader DataReader = command.ExecuteReader()) {
					while(DataReader.Read()) {
						Accounts.Add(new Account(DataReader.GetInt32(0), DataReader.GetString(1), DataReader.GetString(2), DataReader.GetString(3)));
					}
				}
			}
			return Accounts;
		}
		public List<Account> GetAccountsOffProject(int Id) {

			string query = "SELECT UserId, UserEmail, UserName, UserRole FROM UserAccounts WHERE NOT EXISTS ( " +
				"SELECT * FROM AccountsOnProjects " +
				"WHERE AccountsOnProjects.AccountId = UserAccounts.UserId " +
				"AND AccountsOnProjects.ProjectId = @Id" +
				")";

			List<Account> Accounts = new List<Account>();

			using(SQLiteCommand command = new SQLiteCommand(query, Model.connection)) {
				command.Parameters.AddWithValue("@Id", Id);
				using(SQLiteDataReader DataReader = command.ExecuteReader()) {
					while(DataReader.Read()) {
						Accounts.Add(new Account(DataReader.GetInt32(0), DataReader.GetString(1), DataReader.GetString(2), DataReader.GetString(3)));
					}
				}
			}
			return Accounts;
		}
		public string GetProjectOverview(int Id) {

			string Description = "";

			// Get Project //

			using(SQLiteCommand command = new SQLiteCommand("SELECT ProjectDescription FROM Projects WHERE ProjectId = @Id", Model.connection)) {
				command.Parameters.AddWithValue("@Id", Id);
				using(SQLiteDataReader DataReader = command.ExecuteReader()){
					DataReader.Read();
					Description = DataReader.GetString(0);
				}
			}
			return Description;

		}
		public void CreateProject(string Name, string Description, string Designation, string Creator_Name) {

			if(Test == false) {

				int NewId = 1;

					using(SQLiteDataReader DR = new SQLiteCommand("SELECT ProjectId FROM Projects", Model.connection).ExecuteReader()){
						while(DR.Read())
							NewId++;
					}
				

					using(SQLiteCommand command = new SQLiteCommand("INSERT INTO Projects VALUES(@Id, @Name, @Description, @Designation, 0)", Model.connection)) {
						command.Parameters.AddWithValue("@Id", NewId);
						command.Parameters.AddWithValue("@Name", Name);
						command.Parameters.AddWithValue("@Description", Description);
						command.Parameters.AddWithValue("@Designation", Designation);
						command.ExecuteScalar();
						Console.WriteLine("Created Project (" + NewId + ") - " + Name + " - " + Designation);
					}
				}

				int Id = 0;
				string query = "SELECT ProjectId FROM Projects WHERE ProjectName = @Name AND ProjectDescription = @Description AND BugDesignation = @Designation";


					using(SQLiteCommand command = new SQLiteCommand(query, Model.connection)) {
						command.Parameters.AddWithValue("@Name", Name);
						command.Parameters.AddWithValue("@Description", Description);
						command.Parameters.AddWithValue("@Designation", Designation);
						using(SQLiteDataReader DataReader = command.ExecuteReader()) {
							while(DataReader.Read()) {
								Id = DataReader.GetInt32(0);
							}
						}
					}
				

				if(Id != 0) {
						using(SQLiteCommand command = new SQLiteCommand("INSERT INTO ProjectUpdates VALUES(@ProjectId, @UpdateDate, @UpdateDescription)", Model.connection)) {
							command.Parameters.AddWithValue("@ProjectId", Id);
							command.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
							command.Parameters.AddWithValue("@UpdateDescription", "Project created by " + Creator_Name);
							command.ExecuteScalar();
						
					}
				}
			}
		
		public SuccessMessage RetireProject(int Id, string Name) {

			if(Test == false) {

				// Unassign Engineers //

				using(SQLiteCommand command = new SQLiteCommand("DELETE FROM AccountsOnProjects WHERE ProjectId = @Id", Model.connection)) {
					command.Parameters.AddWithValue("@Id", Id);
					command.ExecuteScalar();
				}

				// Update Bugs //

				List<string> Bugs = new List<string>();
				using(SQLiteCommand command = new SQLiteCommand("SELECT BugDesignation FROM Bugs WHERE ProjectId = @Id", Model.connection)) {
					command.Parameters.AddWithValue("@Id", Id);
					SQLiteDataReader Reader = command.ExecuteReader();
					while(Reader.Read()) {
						Bugs.Add(Reader.GetString(0));
					}
				}
				Bugs.ForEach(delegate (string Designation) {
					Model.UpdateBug(Designation, "Project Retired By " + Name);
				});

				// Resolve Bugs //

				using(SQLiteCommand command = new SQLiteCommand("UPDATE Bugs SET BugStatus = 'Resolved' WHERE ProjectId = @Id", Model.connection)) {
					command.Parameters.AddWithValue("@Id", Id);
					command.ExecuteScalar();
				}

				// Retire Project //

				using(SQLiteCommand command = new SQLiteCommand("UPDATE Projects SET Retired = 'true' WHERE ProjectId = @Id", Model.connection)) {
					command.Parameters.AddWithValue("@Id", Id);
					command.ExecuteScalar();
				}
				UpdateProject(Id, "Project Retired by " + Name);
			}
			return new SuccessMessage(true, "Project was successfully retired");
		}
		public List<ProjectUpdate> ViewProjectUpdates(int Id) {

			List<ProjectUpdate> Updates = new List<ProjectUpdate>();


			using(SQLiteCommand command = new SQLiteCommand("SELECT * FROM ProjectUpdates WHERE ProjectId = @Id", Model.connection)){
				command.Parameters.AddWithValue("@Id", Id);
				using(SQLiteDataReader DataReader = command.ExecuteReader()) {
					while(DataReader.Read()) {
						Updates.Add(new ProjectUpdate(DataReader.GetInt32(0), DataReader.GetDateTime(1), DataReader.GetString(2)));
					}
				}
			}
			return Updates;
		}
		public void UpdateProject(int ProjectId, string Description) {

			if(Description.Length > 50) return;

			if(Model.IsAccountOnProject(ProjectId)) {
					using(SQLiteCommand command = new SQLiteCommand("INSERT INTO ProjectUpdates VALUES(@ProjectId, @UpdateDate, @UpdateDescription)", Model.connection)) {
						command.Parameters.AddWithValue("@ProjectId", ProjectId);
						command.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
						command.Parameters.AddWithValue("@UpdateDescription", Description);
						command.ExecuteScalar();
					}
				}
			}
		
		public bool DoesProjectExist(string Name) {
			using(SQLiteCommand command = new SQLiteCommand("SELECT Retired FROM Projects WHERE ProjectName = @Name", Model.connection)) {
				
				command.Parameters.AddWithValue("@Name", Name);
				SQLiteDataReader DataReader = command.ExecuteReader();
				if(DataReader.Read()) {
					return true;
				}
				
			}
			return false;
		}
		public SuccessMessage AssignAccountToProject(int AccountId, int ProjectId) {

			if(Test == false) {
					using(SQLiteCommand command = new SQLiteCommand("INSERT INTO AccountsOnProjects VALUES (@AID, @PID)", Model.connection)) {
						command.Parameters.AddWithValue("@AID", AccountId);
						command.Parameters.AddWithValue("@PID", ProjectId);
						command.ExecuteScalar();
					}
				
				UpdateProject(ProjectId, Model.GetAccount(AccountId).Name + " was assigned to the project by " + Model.ActiveAccount.Name);
				Console.WriteLine("Assigned: " + AccountId + " to project " + ProjectId);
			}
			return new SuccessMessage(true, "Assignment Successful");
		}
		public SuccessMessage RemoveAccountFromProject(int AccountId, int ProjectId) {
			if(Test == false) {
				// Remove Account on Project tuple //  
				using(SQLiteCommand command = new SQLiteCommand("DELETE FROM AccountsOnProjects WHERE AccountId = @AID AND ProjectID = @PID", Model.connection)) {
					
					command.Parameters.AddWithValue("@AID", AccountId);
					command.Parameters.AddWithValue("@PID", ProjectId);
					command.ExecuteScalar();
					
				}

				// Get Designations of assigned bugs in said project //

				List<string> Designations = new List<string>();

				using(SQLiteCommand command = new SQLiteCommand("SELECT BugDesignation FROM Bugs WHERE ProjectId = @PID AND AccountId = @AID", Model.connection)) {
					;
					command.Parameters.AddWithValue("@AID", AccountId);
					command.Parameters.AddWithValue("@PID", ProjectId);
					SQLiteDataReader DataReader = command.ExecuteReader();
					while(DataReader.Read()) {
						Designations.Add(DataReader.GetString(0));
					}
				}


				// Unassign Bugs Collected // 

				Designations.ForEach(delegate (string Designation) {
					Model.UnassignBug(Designation);
				});
				UpdateProject(ProjectId, Model.GetAccount(AccountId).Name + " was removed from the project by " + Model.ActiveAccount.Name);
			}
			return new SuccessMessage(true, "Remove Successful");

		}
	}
}
