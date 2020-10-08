using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BugTracker.Data_Classes;
using BugTracker.Manager_Classes;
using BugTracker.Utility_Classes;

namespace BugTracker.MVC_Classes {
	public class BTController {

		private bool _IsTest;

		private TopForm View;
		private BTModel _Model;
		public BTModel Model { get { if(_IsTest) { return _Model; } else return null; } }

		public BTController(TopForm _View, bool IsTest) {
			View = _View;
			_Model = new BTModel(IsTest);
			_IsTest = IsTest;
		}
		
		////////////
		//  TABS  //
		////////////

		public void AccessProfile() {
			if(_Model.LoggedIn) {
				View.ShowProfilePage();
			}
			else {
				View.ShowLoginPage();
			}
		}
		public SuccessMessage AccessBugs() {
			if(_Model.LoggedIn) {
				View.ShowBugsPage();
				return new SuccessMessage();
			}
			return new SuccessMessage(false);
		}
		public SuccessMessage AccessProjects() {
			if(_Model.LoggedIn) {
				View.ShowProjectsPage();
				return new SuccessMessage();
			}
			return new SuccessMessage(false);
		}
		public SuccessMessage AccessAdmin() {
			if(!_Model.IsActiveAccountAdministrator()) {
				return new SuccessMessage(false);
			}
			View.ShowAdminPage();
			return new SuccessMessage();
		}

		public Account ActiveAccount { get { return _Model.ActiveAccount; } }

		public SuccessMessage Login(string Email, string Password) {
			SuccessMessage LoginAttempt = _Model.LoginAccount(Email, Password);
			if(LoginAttempt.Success) {
				View.ShowProfilePage();
				return new SuccessMessage(true);
			}
			return new SuccessMessage(false, LoginAttempt.Message);
		}
		public SuccessMessage InitiateSignUp(string Email, string Password) {
			SuccessMessage SignUpAttempt = _Model.InitiateSignUp(Email, Password);
			if(SignUpAttempt.Success) {
				View.ShowSignUpPage();
				return SignUpAttempt;
			}
			return SignUpAttempt;
		}
		public SuccessMessage ConfirmSignUp(string Name, string Code) {
			SuccessMessage SignUpAttempt = _Model.ConfirmSignUp(Name, Code);
			if(SignUpAttempt.Success) {
				View.ShowProfilePage();
				return SignUpAttempt;
			}
			return SignUpAttempt;
		}
		public void LogOut() {
			_Model.LogOut();
			View.ShowLoginPage();
		}
		public SuccessMessage ChangePassword(string Password) {
			return _Model.ChangeMyPassword(Password);
		}
		public void NewProfilePicture(Bitmap Image) {
			_Model.ChangeMyPicture(Image);
		}
		public bool IsActiveAccountAdministrator() { return _Model.IsActiveAccountAdministrator(); }
		public List<Account> GetAllAccounts() { return _Model.GetAllAccounts(); }
		public SuccessMessage EditAccountRole(int Id, string Role) {
			return _Model.EditAccountRole(Id, Role);
		}
		public SuccessMessage DeleteAccount(int Id) { 
			return _Model.DeleteAccount(Id); }
		public SuccessMessage AssignAccountToProject(int AccountId, int ProjectId) {
			return _Model.AssignAccountToProject(AccountId, ProjectId);
		}
		public SuccessMessage RemoveAccountFromProject(int AccountId, int ProjectId) {
			return _Model.RemoveAccountFromProject(AccountId, ProjectId);
		}
		public bool ClearanceToView(int ProjectId) { return _Model.ClearanceToView(ProjectId); }
		public bool IsAccountOnProject(int ProjectId) { return _Model.IsAccountOnProject(ProjectId); }

		public SuccessMessage ReportBug(int ProjectId, string Description) {
			return _Model.ReportBug(ProjectId, Description);
		}
		public List<Bug> GetMyBugs() {
			return _Model.GetMyBugs();
		}
		public List<Bug> GetMyBugs(int Id) {
			return _Model.GetMyBugs(Id);
		}
		public List<Bug> GetBugsFromProject(int Id) {
			return _Model.GetBugsFromProject(Id);
		}
		public List<Bug> GetSubmittedBugs() { return _Model.GetSubmittedBugs(); }
		public List<Bug> GetUnassignedBugs() { return _Model.GetUnassignedBugs(); }
		public int OpenBugsInProjectCount(int Id) {
			return _Model.OpenBugsInProjectCount(Id);
		}
		public SuccessMessage ResolveBug(string Designation) { return _Model.ResolveBug(Designation); }
		public SuccessMessage RejectBug(string Designation) { return _Model.RejectBug(Designation); }
		public SuccessMessage AssignBug(string Designation, int Id) { return _Model.AssignBug(Designation, Id); }

		public List<Project> GetMyProjects() {
			return _Model.GetMyProjects();
		}
		public List<Project> GetMyProjects(int Id) {
			return _Model.GetMyProjects(Id);
		}
		public List<Project> GetProjects() {
			return _Model.GetProjects();
		}
		public List<ProjectUpdate> ViewProjectUpdates(int Id) {
			return _Model.ViewProjectUpdates(Id);
		}
		public void UpdateProject(int Id, string Description) {
			_Model.UpdateProject(Id, Description);
		}
		public SuccessMessage CreateProject(string Name, string Description,  string BugDesignation) { return _Model.CreateProject(Name, Description, BugDesignation); }
		public SuccessMessage RetireProject(int Id) { return _Model.RetireProject(Id); }
		public List<Account> GetAccountsOnProject(int Id) {
			return _Model.GetAccountsOnProject(Id);
		}
		public List<Account> GetAccountsOffProject(int Id) {
			return _Model.GetAccountsOffProject(Id);
		}
		public SuccessMessage GetProjectOverview(int Id) {
			return _Model.GetProjectOverview(Id);
		}

		public SuccessMessage SubmitBug(string Designation) {
			SuccessMessage SubmitAttempt = _Model.SubmitBug(Designation);
			if(SubmitAttempt.Success) {
				View.PopulateBugList();
			}
			return SubmitAttempt;
		}
		public List<BugUpdate> GetBugUpdates(string Designation) {
			return _Model.GetBugUpdates(Designation);
		}
		public SuccessMessage UpdateBug(string Designation, string Description) {
			return _Model.UpdateBug(Designation, Description);
		}
		public void Exit() {
			_Model.Exit();
		}
	}
}
