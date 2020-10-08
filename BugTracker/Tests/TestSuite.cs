using System;
using System.Collections.Generic;
using System.Drawing;
using BugTracker.Properties;
using BugTracker.Data_Classes;
using BugTracker.Utility_Classes;
using BugTracker.MVC_Classes;

namespace BugTracker.Tests {
	class TestSuite {


		private TopForm View;

		private List<Account> AccountCache = new List<Account>();
		private List<Project> ProjectCache = new List<Project>();
		private List<Bug> BugCache = new List<Bug>();
		private List<Update> UpdateCache = new List<Update>();

		private string Test_Name;
		private List<TestResult> Results;

		public TestSuite() {

			// This first instantiation of the view is to trigger the database population
			View = new TopForm(false);
			Results = new List<TestResult>();

			Test_Page_Navigation();
			Test_Login();

			Test_View_Bugs();
			Test_View_Projects();
			Test_Change_Profile_Picture();
			Test_Change_Password();
			Test_Log_Out();

			Test_View_Project_Overview();
			Test_Access_To_Project_Updates();

			Test_View_Bugs_In_Project();
			Test_Report_Bug();
			Test_View_Bug_Updates();
			Test_Update_Bug();
			Test_Submit_Bug();

			Test_Edit_Account_Role();
			Test_Delete_Account();
			Test_Create_Project();
			Test_Retire_Project();
			Test_Assign_Account_To_Project();
			Test_Remove_Account_From_Project();
			Test_Resolve_Bug();
			Test_Reject_Bug();
			Test_Assign_Bug_To_Account();

			Print_Results();
		}


		// Home Page and Login Page Tests
		private void Test_Page_Navigation() {

			Test_Name = "Page Navigation Test";
			View = new TopForm(true);

			if(View.CurrentPage != "Home") { Fail("Landing page is not home page"); return;  }
			View.Click_AdminButton(this, new EventArgs());
			if(View.CurrentPage != "Home") { Fail("Admin page was accessed without an account"); return; }
			View.Click_BugsButton(this, new EventArgs());
			if(View.CurrentPage != "Home") { Fail("Bugs page was accessed without an account"); return; }
			View.Click_ProjectsButton(this, new EventArgs());
			if(View.CurrentPage != "Home") { Fail("Projects page was accessed without an account"); return; }
			View.Click_ProfileButton(this, new EventArgs());
			if(View.CurrentPage != "Login") { Fail("Login page was not accessed"); return; }

			Pass();
		}
		private void Test_Login() {

			Test_Name = "Login Test";
			View = new TopForm(true);
			

			View.Controller.Login("test@gmail.com", "AdminAccount");
			View.Click_ProfileButton(this, new EventArgs());
			if(View.CurrentPage != "Profile") { Fail("Profile page was not accessed"); return; }

			Pass();
		}
		
		// Accounts Page Tests
		private void Test_View_Bugs() {

			Test_Name = "View My Bugs Test";
			View = new TopForm(true);
			View.Controller.Login("test@gmail.com", "AdminAccount");

			BugCache = View.Controller.GetMyBugs();

			BugCache.ForEach(delegate (Bug bug) {
				if(bug.AccountId != View.Controller.ActiveAccount.Id) {
					Fail("A bug belonging to a different user was listed");
					return;
				}
			});
			if(BugCache.Count != 2) {
				Fail("Incorrect number of bugs returned: " + BugCache.Count);
				return;
			}

			Pass();
		}
		private void Test_View_Projects() {

			Test_Name = "View My Projects Test";
			View = new TopForm(true);

			View.Controller.Login("test@gmail.com", "AdminAccount");
			View.Click_ProfileButton(this, new EventArgs());
			ProjectCache = View.Controller.GetMyProjects();

			ProjectCache.ForEach(delegate (Project project) {
				if(!View.Controller.Model.IsAccountOnProject(project.Id)) {
					Fail("A project was returned that the account was not assigned to");
					return;
				}
			});
			if(ProjectCache.Count != 1) {
				Fail("Incorrect number of projects returned");
				return;
			}

			Pass();
		}
		private void Test_Change_Profile_Picture() {

			Test_Name = "Change Profile Picture Test";
			View = new TopForm(true);
			
			View.Controller.Login("test@gmail.com", "AdminAccount");

			Bitmap NewProfilePicture = Resources.TestProfilePicture;
			View.Controller.NewProfilePicture(NewProfilePicture);
			Bitmap CurrentProfilePicture = (Bitmap)View.Controller.ActiveAccount.ProfilePicture;

			int PixelDifference = 0;
			for(int x = 0 ; x < NewProfilePicture.Size.Width ; x++)
				for(int y = 0 ; y < NewProfilePicture.Size.Height ; y++) {
					if(NewProfilePicture.GetPixel(x, y) != CurrentProfilePicture.GetPixel(x, y)) {
						PixelDifference++;
					}
				}

			double Percent_Difference = ((double)PixelDifference/((double)NewProfilePicture.Size.Height * (double)NewProfilePicture.Size.Width))*100;
			if(Percent_Difference < 10) {
				Fail("Picture did not update correctly");
				View.Controller.NewProfilePicture(Resources.EmptyProfileGrey);
				return;
			}

			View.Controller.NewProfilePicture(Resources.EmptyProfileGrey);

			Pass();
		}
		private void Test_Change_Password() {

			Test_Name = "Change Password Test";
			View = new TopForm(true);
			
			View.Controller.Login("test@gmail.com", "AdminAccount");

			string Current_Password = View.Controller.ActiveAccount.Password;
			SuccessMessage ChangePasswordAttempt = View.Controller.ChangePassword("TooShort");
			if(ChangePasswordAttempt.Success == true) {
				View.Controller.ChangePassword(Current_Password);
				Fail("The password was accepted despite it being too short");
				return;
			}

			ChangePasswordAttempt = View.Controller.ChangePassword("WaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaayTooLong");
			if(ChangePasswordAttempt.Success == true) {
				View.Controller.ChangePassword(Current_Password);
				Fail("The password was accepted despite it being too long");
				return;
			}

			ChangePasswordAttempt = View.Controller.ChangePassword("JustRightLength");
			if(ChangePasswordAttempt.Success == false) {
				View.Controller.ChangePassword(Current_Password);
				Fail("The password was rejected despite being the correct length");
				return;
			}

			ChangePasswordAttempt = View.Controller.ChangePassword(Current_Password);

			Pass();
		}
		private void Test_Log_Out() {

			Test_Name = "Log Out Test";
			View = new TopForm(true);
			
			View.Controller.Login("test@gmail.com", "AdminAccount");

			View.Click_LogOutButton(this, new EventArgs());

			if(View.Controller.ActiveAccount != null || View.CurrentPage != "Login") {
				Fail("Log out was unsuccessful");
			}

			Pass();
		}

		// Projects Page Tests
		private void Test_View_Project_Overview() {

			Test_Name = "View Project Overview Test";
			View = new TopForm(true);
			
			View.Controller.Login("test@gmail.com", "AdminAccount");

			ProjectCache = View.Controller.GetProjects();
			int Test_Project_1_Id = 0;
			int Test_Project_2_Id = 0;

			for(int i = 0 ; i < ProjectCache.Count ; i++) {
				if(ProjectCache[i].Name == "Test Project 1") Test_Project_1_Id = ProjectCache[i].Id;
				if(ProjectCache[i].Name == "Test Project 2") Test_Project_2_Id = ProjectCache[i].Id;
			}

			//
			//  Tests for Admin Account
			//

			SuccessMessage OverviewAttempt = View.Controller.GetProjectOverview(Test_Project_1_Id);
			if(!OverviewAttempt.Success) {
				Fail("An account was not able to access the overview of a project it was assigned to.");
				return;
			}

			OverviewAttempt = View.Controller.GetProjectOverview(Test_Project_2_Id);
			if(!OverviewAttempt.Success) {
				Fail("An administrator account was not able to see the overview of a project it was not assigned to");
				return;
			}


			//
			//  Tests for Engineer Account
			//

			View.Click_LogOutButton(this, new EventArgs());
			View.Controller.Login("test@gmail.com", "EngineerAccount");

			 OverviewAttempt = View.Controller.GetProjectOverview(Test_Project_1_Id);
			if(!OverviewAttempt.Success) {
				Fail("An account was not able to access the overview of a project it was assigned to.");
				return;
			}

			OverviewAttempt = View.Controller.GetProjectOverview(Test_Project_2_Id);
			if(OverviewAttempt.Success) {
				Fail("An account was not able to access the overview of a project it was assigned to.");
				return;
			}

			Pass();
		}
		private void Test_Access_To_Project_Updates() {

			Test_Name = "View Project Updates Test";
			View = new TopForm(true);
			View.Controller.Login("test@gmail.com", "AdminAccount");

			ProjectCache = View.Controller.GetProjects();
			int Test_Project_1_Id = 0;
			int Test_Project_2_Id = 0;

			for(int i = 0 ; i < ProjectCache.Count ; i++) {
				if(ProjectCache[i].Name == "Test Project 1") Test_Project_1_Id = ProjectCache[i].Id;
				if(ProjectCache[i].Name == "Test Project 2") Test_Project_2_Id = ProjectCache[i].Id;
			}

			//
			//  Tests for Admin Account
			//
			if(View.Controller.ViewProjectUpdates(Test_Project_1_Id).Count == 0) {
				Fail("An administrator account was not able to access the updates of a project it was assigned to.");
				return;
			}

			if(View.Controller.ViewProjectUpdates(Test_Project_2_Id).Count == 0) {
				Fail("An administrator account was not able to see the updates of a project it was not assigned to");
				return;
			}


			//
			//  Tests for Engineer Account
			//

			View.Click_LogOutButton(this, new EventArgs());
			View.Controller.Login("test@gmail.com", "EngineerAccount");

			if(View.Controller.ViewProjectUpdates(Test_Project_1_Id).Count == 0) {
				Fail("An engineer account was not able to access the updates of a project it was assigned to.");
				return;
			}

			if(View.Controller.ViewProjectUpdates(Test_Project_2_Id).Count != 0) {
				Fail("An engineer account was able to access the updates of a project it was not assigned to.");
				return;
			}

			Pass();
		}

		// Bugs Page Tests
		private void Test_View_Bugs_In_Project() {

			Test_Name = "View Bugs In project Test";
			View = new TopForm(true);
			
			View.Controller.Login("test@gmail.com", "AdminAccount");

			ProjectCache = View.Controller.GetProjects();
			int Test_Project_1_Id = 0;

			for(int i = 0 ; i < ProjectCache.Count ; i++) {
				if(ProjectCache[i].Name == "Test Project 1") Test_Project_1_Id = ProjectCache[i].Id;
			}

			BugCache = View.Controller.GetBugsFromProject(Test_Project_1_Id);
			if(BugCache.Count != 4) {
				Fail("Incorrect Bug Count retirved");
				return;
			}

			Pass();
		}
		private void Test_Report_Bug() {

			Test_Name = "Report Bug Test";
			View = new TopForm(true);
			
			View.Controller.Login("test@gmail.com", "AdminAccount");

			ProjectCache = View.Controller.GetProjects();
			int Test_Project_1_Id = 0;

			for(int i = 0 ; i < ProjectCache.Count ; i++) {
				if(ProjectCache[i].Name == "Test Project 1") {
					Test_Project_1_Id = ProjectCache[i].Id;
					break;
				}
			}

			if(View.Controller.ReportBug(Test_Project_1_Id, "AbcdefghijklmnopqrstuvwxyzAbcdefghijklmnopqrstuvwxyzAbcdefghijklmnopqrstuvwxyzAbcdefghijklmnopqrstuvwxyz").Success) {
				Fail("Bug reported despite description being too long");
				return;
			}

			if(!View.Controller.ReportBug(Test_Project_1_Id, "A new bug created by the test suite").Success) {
					Fail("Failed to report valid bug");
					return;
				}


				Pass();
		}
		private void Test_View_Bug_Updates() {

			Test_Name = "View Bug Updates Test";
			View = new TopForm(true);
			
			View.Controller.Login("test@gmail.com", "AdminAccount");

			ProjectCache = View.Controller.GetProjects();
			int Test_Project_1_Id = 0;

			for(int i = 0 ; i < ProjectCache.Count ; i++) {
				if(ProjectCache[i].Name == "Test Project 1") {
					Test_Project_1_Id = ProjectCache[i].Id;
					break;
				}
			}
			if(View.Controller.GetBugUpdates(BugCache[0].Designation).Count != 2) {
				Fail("Incorrect number of updates returned");
				return;
			}
			if(View.Controller.GetBugUpdates(BugCache[1].Designation).Count != 2) {
				Fail("Incorrect number of updates returned");
				return;
			}

			Pass();
		}
		private void Test_Update_Bug() {

			Test_Name = "Update Bug Test";
			View = new TopForm(true);
			
			View.Controller.Login("test@gmail.com", "AdminAccount");

			ProjectCache = View.Controller.GetProjects();
			int Test_Project_1_Id = 0;

			for(int i = 0 ; i < ProjectCache.Count ; i++) {
				if(ProjectCache[i].Name == "Test Project 1") {
					Test_Project_1_Id = ProjectCache[i].Id;
					break;
				}
			}
			BugCache = View.Controller.GetBugsFromProject(Test_Project_1_Id);

			if(View.Controller.UpdateBug(BugCache[0].Designation, "AbcdefghijklmnopqrstuvwxyzAbcdefghijklmnopqrstuvwxyzAbcdefghijklmnopqrstuvwxyzAbcdefghijklmnopqrstuvwxyz").Success) {
				Fail("Bug update was accepted despite being too long");
				return;
			}

			if(!View.Controller.UpdateBug(BugCache[0].Designation, "Lorem Ipsum").Success) {
				Fail("Bug failed to update");
				return;
			}

			Pass();
		}
		private void Test_Submit_Bug() {

			Test_Name = "Submit Bug Test";
			View = new TopForm(true);
			
			View.Controller.Login("test@gmail.com", "AdminAccount");

			ProjectCache = View.Controller.GetProjects();
			int Test_Project_1_Id = 0;

			for(int i = 0 ; i < ProjectCache.Count ; i++) {
				if(ProjectCache[i].Name == "Test Project 1") Test_Project_1_Id = ProjectCache[i].Id;
			}

			BugCache = View.Controller.GetBugsFromProject(Test_Project_1_Id);
			if(!View.Controller.SubmitBug(BugCache[0].Designation).Success) {
				Fail("Unable to submit a valid bug");
			}
			if(View.Controller.SubmitBug(BugCache[2].Designation).Success) {
				Fail("A bug assigned to another engineer was uncorrectly submitted");

			}

			Pass();
		}

		// Admin Page Tests
		private void Test_Edit_Account_Role() {

			Test_Name = "Edit Account Role Test";
			View = new TopForm(true);
			
			View.Controller.Login("test@gmail.com", "AdminAccount");


			if(!View.Controller.EditAccountRole(View.Controller.Model.GetAccount("test@gmail.com", "EngineerAccount").Id, "Guest").Success) {
				Fail("Failed to edit an account role");
				return;
			}

			if(View.Controller.EditAccountRole(View.Controller.Model.GetAccount("test@gmail.com", "AdminAccount").Id, "Guest").Success) {
				Fail("Incorrectly was allowed to edit your own role");
				return;
			}

			View.Controller.EditAccountRole(View.Controller.Model.GetAccount("test@gmail.com", "EngineerAccount").Id, "Engineer");
			View.Controller.EditAccountRole(View.Controller.Model.GetAccount("test@gmail.com", "AdminAccount").Id, "Administrator");

			Pass();
		}
		private void Test_Delete_Account() {

			Test_Name = "Delete Account Test";
			View = new TopForm(true);
			
			View.Controller.Login("test@gmail.com", "AdminAccount");


			if(!View.Controller.DeleteAccount(View.Controller.Model.GetAccount("test@gmail.com", "EngineerAccount").Id).Success) {
				Fail("Failed to delete an account");
				return;
			}

			if(View.Controller.DeleteAccount(View.Controller.Model.GetAccount("test@gmail.com", "AdminAccount").Id).Success) {
				Fail("Incorrectly was allowed to delete your own account");
				return;
			}


			Pass();
		}
		private void Test_Create_Project() {

			Test_Name = "Create Project Test";
			View = new TopForm(true);
			
			View.Controller.Login("test@gmail.com", "AdminAccount");

			if(View.Controller.CreateProject("Test_Project", "Lorem Ipsum", "XXX").Success) {
				Fail("Project created despite an incorrect bug desigantion length");
				return;
			}
			if(View.Controller.CreateProject("Project", "Lorem Ipsum", "XX").Success) {
				Fail("Project created despite a project name below 10 characters");
				return;
			}
			if(View.Controller.CreateProject("Test_Projectaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "Lorem Ipsum", "XX").Success) {
				Fail("Project created despite having a project name above 50 characters");
				return;
			}
			if(View.Controller.CreateProject("Test_Project", "Lorem", "XX").Success) {
				Fail("Project created despite having a description below 10 characters");
				return;
			}
			if(View.Controller.CreateProject("Test_Project", "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890", "XX").Success) {
				Fail("Project created despite having a description length above 500 characters");
				return;
			}
			if(View.Controller.CreateProject("Test Project 1", "Lorem_Ipsum", "XX").Success) {
				Fail("Project created despite a project with that name already existing");
				return;
			}
			if(View.Controller.CreateProject("Test_Project", "Lorem_Ipsum", "TP").Success) {
				Fail("Project created despite a project with that bug designation already existing");
				return;
			}
			if(!View.Controller.CreateProject("Test_Project", "Lorem_Ipsum", "XX").Success) {
				Fail("Project was incorrectly rejected");
				return;
			}

			Pass();
		}
		private void Test_Retire_Project() {

			Test_Name = "Retire Project Test";
			View = new TopForm(true);
			
			View.Controller.Login("test@gmail.com", "AdminAccount");

			ProjectCache = View.Controller.GetProjects();
			int Test_Project_1_Id = 0;

			for(int i = 0 ; i < ProjectCache.Count ; i++) {
				if(ProjectCache[i].Name == "Test Project 1") {
					Test_Project_1_Id = ProjectCache[i].Id;
					break;
				}
			}

			if(!View.Controller.RetireProject(Test_Project_1_Id).Success) {
				Fail("Project was not retired");
				return;
			}

			View.Click_LogOutButton(this, new EventArgs());
			View.Controller.Login("test@gmail.com", "EngineerAccount");

			if(View.Controller.RetireProject(Test_Project_1_Id).Success) {
				Fail("Project was retired despite active account not being an administrator");
				return;
			}

			Pass();
		}
		private void Test_Assign_Account_To_Project() {

			Test_Name = "Assign Account To Project Test";
			View = new TopForm(true);
			
			View.Controller.Login("test@gmail.com", "EngineerAccount");


			ProjectCache = View.Controller.GetProjects();
			int Test_Project_2_Id = 0;

			for(int i = 0 ; i < ProjectCache.Count ; i++) {
				if(ProjectCache[i].Name == "Test Project 2") {
					Test_Project_2_Id = ProjectCache[i].Id;
					break;
				}
			}

			int AdminstratorAccountId = View.Controller.Model.GetAccount("test@gmail.com", "AdminAccount").Id;
			int GuestAccountId = View.Controller.Model.GetAccount("test@gmail.com", "GuestAccount").Id;


			if(View.Controller.AssignAccountToProject(AdminstratorAccountId, Test_Project_2_Id).Success) {
				Fail("An engineer was incorrectly allowed to assign an account");
				return;
			}

			View.Controller.LogOut();
			View.Controller.Login("test@gmail.com", "AdminAccount");


			if(View.Controller.AssignAccountToProject(GuestAccountId, Test_Project_2_Id).Success) {
				Fail("An administrator was incorrectly allowed to assign a guest account to a project");
				return;
			}

			Pass();

		}
		private void Test_Remove_Account_From_Project() {

			Test_Name = "Remove Account From Project Test";
			View = new TopForm(true);
			
			View.Controller.Login("test@gmail.com", "EngineerAccount");

			ProjectCache = View.Controller.GetProjects();
			int Test_Project_1_Id = 0;

			for(int i = 0 ; i < ProjectCache.Count ; i++) {
				if(ProjectCache[i].Name == "Test Project 1") {
					Test_Project_1_Id = ProjectCache[i].Id;
					break;
				}
			}

			int AdminAccountId = View.Controller.Model.GetAccount("test@gmail.com", "AdminAccount").Id;
			int EngineerAccountId = View.Controller.Model.GetAccount("test@gmail.com", "EngineerAccount").Id;

			if(View.Controller.RemoveAccountFromProject(AdminAccountId, Test_Project_1_Id).Success) {
				Fail("A non-administrator was incorrectly allowed to remove an account from a project");
				return;
			}

			View.Controller.LogOut();
			View.Controller.Login("test@gmail.com", "AdminAccount");

			if(!View.Controller.RemoveAccountFromProject(EngineerAccountId, Test_Project_1_Id).Success) {
				Fail("An administrator was not allowed to remove an account from a project");
				return;
			}

			Pass();
		}
		private void Test_Resolve_Bug() {

			Test_Name = "Resolve Bug Test";
			View = new TopForm(true);
			
			View.Controller.Login("test@gmail.com", "EngineerAccount");

			ProjectCache = View.Controller.GetProjects();
			int Test_Project_1_Id = 0;

			for(int i = 0 ; i < ProjectCache.Count ; i++) {
				if(ProjectCache[i].Name == "Test Project 1") {
					Test_Project_1_Id = ProjectCache[i].Id;
					break;
				}
			}
			BugCache = View.Controller.GetSubmittedBugs();
			if(BugCache.Count != 0) {
				Fail("An engineer was allowed access to the list of submitted bugs");
				return;
			}

			View.Controller.LogOut();
			View.Controller.Login("test@gmail.com", "AdminAccount");

			BugCache = View.Controller.GetSubmittedBugs();

			if(!View.Controller.ResolveBug(BugCache[0].Designation).Success) {
				Fail("An administrator account was not allowed to resolve a bug");
				return;
			}



			Pass();
		}
		private void Test_Reject_Bug() {

			Test_Name = "Reject Bug Test";
			View = new TopForm(true);
			
			View.Controller.Login("test@gmail.com", "EngineerAccount");

			ProjectCache = View.Controller.GetProjects();
			int Test_Project_1_Id = 0;

			for(int i = 0 ; i < ProjectCache.Count ; i++) {
				if(ProjectCache[i].Name == "Test Project 1") {
					Test_Project_1_Id = ProjectCache[i].Id;
					break;
				}
			}
			BugCache = View.Controller.GetSubmittedBugs();

			if(BugCache.Count != 0) {
				Fail("An engineer was allowed access to the list of submitted bugs");
				return;
			}

			View.Controller.LogOut();
			View.Controller.Login("test@gmail.com", "AdminAccount");

			BugCache = View.Controller.GetSubmittedBugs();

			if(!View.Controller.RejectBug(BugCache[0].Designation).Success) {
				Fail("An administrator account was not allowed to reject a bug");
				return;
			}

			Pass();
		}
		private void Test_Assign_Bug_To_Account() {

			Test_Name = "Assign Bug To Account Test";
			View = new TopForm(true);
			
			View.Controller.Login("test@gmail.com", "EngineerAccount");

			ProjectCache = View.Controller.GetProjects();
			int Test_Project_1_Id = 0;
			int Unassigned_Bug_Index = 0;
			int AdminAccountId = View.Controller.Model.GetAccount("test@gmail.com", "AdminAccount").Id;

			for(int i = 0 ; i < ProjectCache.Count ; i++) {
				if(ProjectCache[i].Name == "Test Project 1") {
					Test_Project_1_Id = ProjectCache[i].Id;
					break;
				}
			}
			BugCache = View.Controller.GetBugsFromProject(Test_Project_1_Id);
			for(int i = 0 ; i < BugCache.Count ; i++) {
				if(BugCache[i].Status == "Unassigned") {
					Unassigned_Bug_Index = i;
					break;
				}
			}


			if(View.Controller.AssignBug(BugCache[Unassigned_Bug_Index].Designation, AdminAccountId).Success) {
				Fail("A non-administrator was allowed to assign a bug");
				return;
			}

			View.Controller.LogOut();
			View.Controller.Login("test@gmail.com", "AdminAccount");

			if(!View.Controller.AssignBug(BugCache[Unassigned_Bug_Index].Designation, AdminAccountId).Success) {
				Fail("An administrator was not allowed to assign a bug");
				return;
			}

			Pass();
		}

		// Testing Suite Functions
		private void Print_Results() {

			double Successes = 0;

			Console.WriteLine("\n\n-- Test Results --\n");

			Results.ForEach(delegate (TestResult Result) {
				Console.WriteLine(Result.FormatSelf());
				if(Result.Passed)
					Successes++;
			});

			Console.WriteLine("\nTests Passed: " + Successes + "/" + Results.Count);
			Console.WriteLine("Percentage Passed: %" + (int)(100*Successes/(double)Results.Count) + "\n");

			if(Successes != Results.Count) {
				Console.WriteLine("\n -- Failed Tests -- \n");

				Results.ForEach(delegate (TestResult Result) {
					if(!Result.Passed) Console.WriteLine(Result.FormatFail());
				});
			}
		}
		private void Fail(string Error) {
			Results.Add(new TestResult(false, Test_Name, Error));
		}
		private void Pass() {
			Results.Add(new TestResult(true, Test_Name, ""));
		}
	}
}
