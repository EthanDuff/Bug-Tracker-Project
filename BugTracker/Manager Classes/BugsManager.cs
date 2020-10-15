using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTracker.Data_Classes;
using BugTracker.Utility_Classes;

namespace BugTracker.Manager_Classes {
	class BugsManager {

		bool Test;
		BTModel Model;

		public BugsManager(BTModel _Model, bool IsTest) {
			Test = IsTest;
			Model = _Model;
		}

		public SuccessMessage ReportBug(int ProjectId, string Description) {

			if(Description.Length > 100)
				return new SuccessMessage(false, "Description is more than 100 characters");

			string Designation = Model.GetProjectDesignation(ProjectId) + "-" + (BugsInProjectCount(ProjectId) + 1).ToString().PadLeft(3, '0');

			if(Test == false) {
					using(SQLiteCommand command = new SQLiteCommand("INSERT INTO Bugs VALUES(@Id, NULL, @Designation, @Description, 'Unassigned')", Model.connection)) {
						command.Parameters.AddWithValue("@Id", ProjectId);
						command.Parameters.AddWithValue("@Designation", Designation);
						command.Parameters.AddWithValue("@Description", Description);
						command.ExecuteScalar();
					}
				
					using(SQLiteCommand command2 = new SQLiteCommand("INSERT INTO BugUpdates VALUES(@Designation, @DateTime, @Description)", Model.connection)) {
						
						command2.Parameters.AddWithValue("@DateTime", DateTime.Now);
						command2.Parameters.AddWithValue("@Designation", Designation);
						command2.Parameters.AddWithValue("@Description", "Bug was reported by " + Model.ActiveAccount.Name);
						command2.ExecuteScalar();
					}
				

				Console.WriteLine("Reported Bug (" + Designation + ")");
				Model.UpdateProject(ProjectId, "Bug " + Designation + " was reported.");
			}

			return new SuccessMessage(true);
		}
		public List<Bug> GetMyBugs(int Id) {

			List<Bug> Bugs = new List<Bug>();
			string query = "SELECT * FROM Bugs WHERE AccountId = @MyId AND NOT BugStatus = 'Resolved' ORDER BY BugStatus";

			using(SQLiteCommand command = new SQLiteCommand(query, Model.connection)) {
				
				command.Parameters.AddWithValue("@MyId", Id);
				SQLiteDataReader DataReader = command.ExecuteReader();

				while(DataReader.Read()) {
					Bug NextBug = null;
					if(!DataReader.IsDBNull(1)) {
						NextBug = new Bug(DataReader.GetInt32(0), DataReader.GetInt32(1), DataReader.GetString(2).Split(' ')[0], DataReader.GetString(3), DataReader.GetString(4));
					}
					else {
						NextBug = new Bug(DataReader.GetInt32(0), DataReader.GetString(2).Split(' ')[0], DataReader.GetString(3), DataReader.GetString(4));
					}
					Bugs.Add(NextBug);
				}
				
			}
			return Bugs;
		}
		public List<Bug> GetBugsFromProject(int Id) {

			List<Bug> Bugs = new List<Bug>();

			string query = "SELECT * FROM Bugs B INNER JOIN Projects P ON B.ProjectId = P.ProjectId WHERE P.ProjectId = @Id";

			using(SQLiteCommand command = new SQLiteCommand(query, Model.connection)) {
				
				command.Parameters.AddWithValue("@Id", Id);
				SQLiteDataReader DataReader = command.ExecuteReader();
				while(DataReader.Read()) {

					if(DataReader.GetString(4) == "Assigned" && Model.ActiveAccount.Id == DataReader.GetInt32(1)) {
						if(DataReader.IsDBNull(1))
							Bugs.Add(new Bug(DataReader.GetInt32(0), 0, DataReader.GetString(2), DataReader.GetString(3), DataReader.GetString(4) + " To You"));
						else
							Bugs.Add(new Bug(DataReader.GetInt32(0), DataReader.GetInt32(1), DataReader.GetString(2), DataReader.GetString(3), DataReader.GetString(4) + " To You"));
					}
					else {
						Bugs.Add(new Bug(DataReader.GetInt32(0), 0, DataReader.GetString(2), DataReader.GetString(3), DataReader.GetString(4)));
					}
				}
				
			}
			return Bugs;
		}
		public int OpenBugsInProjectCount(int Id) {

			string query = "SELECT ProjectId FROM Bugs WHERE ProjectId = @Id";
			int BugCount = 0;

				using(SQLiteCommand command = new SQLiteCommand(query, Model.connection)) {
					
					command.Parameters.AddWithValue("@Id", Id);
					SQLiteDataReader DataReader = command.ExecuteReader();
					while(DataReader.Read()) {
						BugCount += 1;
					}
				}
			
			return BugCount;
		}
		public int BugsInProjectCount(int Id) {

			string query = "SELECT ProjectId FROM Bugs WHERE ProjectId = @Id";
			int BugCount = 0;

				
				using(SQLiteCommand command = new SQLiteCommand(query, Model.connection)) {
					command.Parameters.AddWithValue("@Id", Id);
					SQLiteDataReader DataReader = command.ExecuteReader();
					while(DataReader.Read()) {
						BugCount++;
					}
				}
			
			return BugCount;
		}
		public SuccessMessage SubmitBug(string Designation) {

			if(Designation.Length != 6)
				return new SuccessMessage(false, "That is not a valid designation");

			string query = "SELECT * FROM Bugs WHERE BugDesignation = @Designation";

				
				using(SQLiteCommand command = new SQLiteCommand(query, Model.connection)) {
					command.Parameters.AddWithValue("@Designation", Designation);
					using(SQLiteDataReader DataReader = command.ExecuteReader()) {

						if(DataReader.Read()) {
							Bug NextBug = null;
							if(!DataReader.IsDBNull(1)) {
								NextBug = new Bug(DataReader.GetInt32(0), DataReader.GetInt32(1), DataReader.GetString(2), DataReader.GetString(3), DataReader.GetString(4));
							}
							else {
								NextBug = new Bug(DataReader.GetInt32(0), DataReader.GetString(2), DataReader.GetString(3), DataReader.GetString(4));
							}
							if(NextBug.Status == "Submitted") {
								return new SuccessMessage(false, "That bug has already been submitted for resolution");
							}
							if(NextBug.AccountId != Model.ActiveAccount.Id && Model.ActiveAccount.Role != "Admin") {
								return new SuccessMessage(false, "That bug has not been assigned to you");
							}
						}
					}
				
			}
			if(Test == false) {
					using(SQLiteCommand command = new SQLiteCommand("UPDATE Bugs SET BugStatus = 'Submitted' WHERE BugDesignation = @Designation", Model.connection)) {
						command.Parameters.AddWithValue("@Designation", Designation);
						command.ExecuteScalar();
					}
				
					using(SQLiteCommand command = new SQLiteCommand("INSERT INTO BugUpdates VALUES(@Designation, @DateTime, @Description)", Model.connection)) {
						command.Parameters.AddWithValue("@Designation", Designation);
						command.Parameters.AddWithValue("@DateTime", DateTime.Now);
						command.Parameters.AddWithValue("@Description", "Submitted for resolution by " + Model.ActiveAccount.Name);
						command.ExecuteScalar();
					
				}
			}
			return new SuccessMessage(true, "Bug: " + Designation + " has been successfuly submitted for resolution");
		}
		public List<BugUpdate> GetBugUpdates(string Designation) {
			List<BugUpdate> Updates = new List<BugUpdate>();

			string query = "SELECT * FROM BugUpdates WHERE BugDesignation = @Designation";

				
				using(SQLiteCommand command = new SQLiteCommand(query, Model.connection)) {
					command.Parameters.AddWithValue("@Designation", Designation);
					using(SQLiteDataReader DataReader = command.ExecuteReader()) {
						while(DataReader.Read()) {
							Updates.Add(new BugUpdate(DataReader.GetString(0), DataReader.GetDateTime(1), DataReader.GetString(2)));
						
					}
				}
			}
			return Updates;
		}
		public SuccessMessage UpdateBug(string Designation, string Description) {

			if(Designation.Length != 6 )
				return new SuccessMessage(false, "Designation is invalid");

			if(Description.Length > 50)
				return new SuccessMessage(false, "Description is more than 50 characters");

			if(Test == false) {
					
					using(SQLiteCommand command = new SQLiteCommand("INSERT INTO BugUpdates VALUES(@Designation, @DateTime, @Description)", Model.connection)) {
						command.Parameters.AddWithValue("@Designation", Designation);
						command.Parameters.AddWithValue("@DateTime", DateTime.Now);
						command.Parameters.AddWithValue("@Description", Description);
						command.ExecuteScalar();
					
				}
			}
			return new SuccessMessage(true);
		}
		public List<Bug> GetSubmittedBugs() {
			List<Bug> Bugs = new List<Bug>();
			if(Model.ActiveAccount.Role != "Administrator")
				return Bugs;

			string query = "SELECT * FROM Bugs WHERE BugStatus = 'Submitted'";

			using(SQLiteDataReader DataReader = new SQLiteCommand(query, Model.connection).ExecuteReader()){
				while(DataReader.Read()) {
					if(DataReader.IsDBNull(1))
						Bugs.Add(new Bug(DataReader.GetInt32(0), 0, DataReader.GetString(2), DataReader.GetString(3), DataReader.GetString(4)));
					else
						Bugs.Add(new Bug(DataReader.GetInt32(0), DataReader.GetInt32(1), DataReader.GetString(2), DataReader.GetString(3), DataReader.GetString(4)));
				}
			}
			return Bugs;
		}
		public List<Bug> GetUnassignedBugs() {
			List<Bug> Bugs = new List<Bug>();
			if(Model.ActiveAccount.Role != "Administrator")
				return Bugs;

			string query = "SELECT * FROM Bugs WHERE BugStatus = 'Unassigned'";

			using(SQLiteDataReader DataReader = new SQLiteCommand(query, Model.connection).ExecuteReader()) {
				while(DataReader.Read()) {
					Bugs.Add(new Bug(DataReader.GetInt32(0), 0, DataReader.GetString(2), DataReader.GetString(3), DataReader.GetString(4)));
				}
			}
			
			return Bugs;
		}
		public SuccessMessage ResolveBug(string Designation) {
			if(Test == false) {
				string query = "UPDATE Bugs SET BugStatus = 'Resolved' WHERE BugDesignation = @Designation";

				using(SQLiteCommand command = new SQLiteCommand(query, Model.connection)) {
					
					command.Parameters.AddWithValue("@Designation", Designation);
					command.ExecuteScalar();
					
				}
				UpdateBug(Designation, "Resolved by " + Model.ActiveAccount.Name);
			}
			return new SuccessMessage();
		}
		public SuccessMessage RejectBug(string Designation) {
			if(Test == false) {
				string query = "UPDATE Bugs SET BugStatus = 'Assigned' WHERE BugDesignation = @Designation";

				using(SQLiteCommand command = new SQLiteCommand(query, Model.connection)) {
					
					command.Parameters.AddWithValue("@Designation", Designation);
					command.ExecuteScalar();
					
				}
				UpdateBug(Designation, "Rejected by " + Model.ActiveAccount.Name);
			}
			return new SuccessMessage();
		}
		public SuccessMessage AssignBug(string Designation, int Id) {
			if(Test == false) {
				string query = "UPDATE Bugs SET BugStatus = 'Assigned', AccountId = @Id WHERE BugDesignation = @Designation";

				using(SQLiteCommand command = new SQLiteCommand(query, Model.connection)) {
					
					command.Parameters.AddWithValue("@Designation", Designation);
					command.Parameters.AddWithValue("@Id", Id);
					command.ExecuteScalar();
					
				}
				UpdateBug(Designation, "Assigned to " + Model.GetAccount(Id).Name + " by " + Model.ActiveAccount.Name);
			}
			return new SuccessMessage();
		}
		public SuccessMessage UnassignBug(string Designation) {

			string query = "UPDATE Bugs SET BugStatus = 'Unassigned', AccountId = NULL WHERE BugDesignation = @Designation";

			using(SQLiteCommand command = new SQLiteCommand(query, Model.connection)) {
				
				command.Parameters.AddWithValue("@Designation", Designation);
				command.ExecuteScalar();
				
			}
			UpdateBug(Designation, "Bug was unassigned");
			return new SuccessMessage();
		}
		public bool DoesBugDesignationExist(string Designation) {
			using(SQLiteCommand command = new SQLiteCommand("SELECT Retired FROM Projects WHERE BugDesignation = @Designation", Model.connection)) {

				command.Parameters.AddWithValue("@Designation", Designation);
				using(SQLiteDataReader DataReader = command.ExecuteReader()) {
					if(DataReader.Read()) {
						return true;
					}

				}
			}
			return false;
		}
	}
}
