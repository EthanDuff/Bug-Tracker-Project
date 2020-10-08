using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BugTracker.Data_Classes;
using BugTracker.MVC_Classes;
using BugTracker.Utility_Classes;

namespace BugTracker {


	public partial class TopForm : Form {

		private bool _IsTest;

		private BTController _Controller;
		public BTController Controller { get { if(_IsTest) { return _Controller; } else return null; } }

		private List<Account> AccountCache = new List<Account>();
		private List<Project> ProjectCache = new List<Project>();
		private List<Bug> BugCache = new List<Bug>();

		enum Page { Home, Login, Profile, Projects, Bugs, Admin, Admin_Accounts, Admin_Projects, Admin_Bugs, Admin_Bugs_Unassigned, Admin_Bugs_Submitted};
		private Page _CurrentPage;
		public string CurrentPage { get { return _CurrentPage.ToString(); } }


		public TopForm(bool IsTest) {
				InitializeComponent();
				InitializeElementSizes();

				_CurrentPage = Page.Home;
				_Controller = new BTController(this, IsTest);
				_IsTest = IsTest;

				GreetingLabel.Font = new System.Drawing.Font("Arial Black", FontSize(60), System.Drawing.FontStyle.Bold);
				double X = 50 + (Size.Width / 2) - (GreetingLabel.Width / 2);
				double Y = 55 + (Size.Height / 2) - (GreetingLabel.Height / 2);
				GreetingLabel.Location = new System.Drawing.Point((int)X, (int)Y);
		}



		////////////
		//  TABS  //
		////////////

		public void Click_ProfileButton(object sender, EventArgs e) {
			_Controller.AccessProfile();
		}
		public void Click_ProjectsButton(object sender, EventArgs e) {
			if(!_Controller.AccessProjects().Success) {
				ClearForm();
				AlertLabel.Visible = true;
				AlertLabel.Text = "Please log in to access the projects tab";
				AlertLabel.Location = new System.Drawing.Point(ProjectsButton.Location.X + 110, ProjectsButton.Location.Y + 33);
			}

		}
		public void Click_BugsButton(object sender, EventArgs e) {
			if(!_Controller.AccessBugs().Success) {
				ClearForm();
				AlertLabel.Visible = true;
				AlertLabel.Text = "Please log in to access the bugs tab";
				AlertLabel.Location = new System.Drawing.Point(BugsButton.Location.X + 110, BugsButton.Location.Y + 33);
			}
		}
		public void Click_AdminButton(object sender, EventArgs e) {

			if(!_Controller.AccessAdmin().Success) {
			ClearForm();
				AlertLabel.Text = "You must log in as an administrator to access the admin tab";
				AlertLabel.Location = new System.Drawing.Point(AdminButton.Location.X+110, AdminButton.Location.Y + 33);
				AlertLabel.Visible = true;
			}
		}



		///////////////////
		//  PROFILE TAB  //
		///////////////////

		public void ShowLoginPage() {
			ClearForm();

			_CurrentPage = Page.Login;

			ProfileButton.BackColor = System.Drawing.Color.Coral;
			GreetingLabel.Visible = false;
			BackdropPanel.Location = Relocate(768, 395);
			BackdropPanel.Size = ResizeElement(440, 420);
			LoginButton.Location = Relocate(823, 645);
			SignUpButton.Location = Relocate(980, 645);
			BackdropPanel.Visible = true;
			LoginEmailLabel.Location = Relocate(818, 446);
			LoginEmailLabel.Visible = true;
			LoginEmailLabel.Text = "Email";
			LoginEmailTextbox.Visible = true;
			LoginEmailTextbox.Text = "";
			LoginEmailTextbox.Location = Relocate(823, 477);
			LoginEmailTextbox.Size = ResizeElement(325,32);
			LoginEmailTextbox.MaxLength = 25;
			LoginPasswordLabel.Text = "Password";
			LoginPasswordLabel.Visible = true;
			LoginPasswordLabel.Location = Relocate(818, 546);
			LoginPasswordTextbox.Location = Relocate(823, 577);
			LoginPasswordTextbox.Text = "";
			LoginPasswordTextbox.Size = ResizeElement(325,32);
			LoginPasswordTextbox.MaxLength = 25;
			LoginPasswordTextbox.Visible = true;
			LoginButton.Visible = true;
			SignUpButton.Visible = true;
			AlertLabel.Location = Relocate(770, 360);
		}
		public void ShowSignUpPage() {

			LoginEmailLabel.Text = "Enter Display Name";
			LoginPasswordLabel.Text = "Enter 6-Digit Email Code";
			LoginEmailTextbox.Text = "";
			LoginEmailTextbox.MaxLength = 25;
			LoginPasswordTextbox.Text = "";
			LoginPasswordTextbox.MaxLength = 6;
			AlertLabel.Visible = true;
			AlertLabel.Text = "An email has been sent to your account";
			LoginButton.Visible = false;
			SignUpButton.Visible = false;
			CancelSignUpButton.Visible = true;
			ConfirmSignUpButton.Visible = true;
			ConfirmSignUpButton.Location = Relocate(843, 645);
			CancelSignUpButton.Location = Relocate(1000, 645);
		}
		public void ShowProfilePage() {

			ClearForm();

			_CurrentPage = Page.Profile;
			Account AccountData = _Controller.ActiveAccount;

			ProfileButton.BackColor = System.Drawing.Color.Coral;
			BackdropPanel.Location = Relocate(400, 300);
			BackdropPanel.Size = ResizeElement(1200, 200);
			BackdropPanel.Visible = true;
			BackdropPanel2.Location = Relocate(400, 530);
			BackdropPanel2.Size = ResizeElement(1200, 395);
			BackdropPanel2.Visible = true;
			ImagePanel.Location = Relocate(500, 200);
			ImagePanel.Size = ResizeElement(200, 200);
			ImagePanel.Visible = true;
			ImagePanel.BackgroundImage = AccountData.ProfilePicture;
			UploadImageButton.Location = Relocate(720, 225);
			UploadImageButton.Size = ResizeElement(150, 50);
			UploadImageButton.Visible = true;
			MyBugsButton.Location = Relocate(475, 575);
			MyBugsButton.Size = ResizeElement(200, 50);
			MyBugsButton.Visible = true;
			MyProjectsButton.Location = Relocate(475, 650);
			MyProjectsButton.Size = ResizeElement(200, 50);
			MyProjectsButton.Visible = true;
			ResultsBox.Location = Relocate(750, 575);
			ResultsBox.Size = ResizeElement(800, 300);
			ResultsBox.Visible = true;
			ResultsBox.Font = new System.Drawing.Font("Consolas", FontSize(14), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			ResultsBox.Items.Clear();
			CoralLabel1.Visible = true;
			CoralLabel1.Text = AccountData.Name;
			CoralLabel1.Location = Relocate(720, 350);
			CoralLabel2.Visible = true;
			CoralLabel2.Text = AccountData.Role;
			CoralLabel2.Location = Relocate(722, 400);
			LogOutButton.Visible = true;
			ChangePasswordButton.Location = Relocate(1350, 340);
			ChangePasswordButton.Visible = true;
			LogOutButton.Location = Relocate(1350, 415);
			RoleLabel.Text = AccountData.Role;
			LoginLabel.Text = AccountData.Name;
		}

		private void Click_LoginButton(object sender, EventArgs e) {
			if(LoginEmailTextbox.Text == "" && LoginPasswordTextbox.Text == "") {
				LoginEmailTextbox.Text = "test@gmail.com";
				LoginPasswordTextbox.Text = "AdminAccount";
			}

			AlertLabel.Visible = false;
			SuccessMessage LoginAttempt = _Controller.Login(LoginEmailTextbox.Text, LoginPasswordTextbox.Text);
			if(!LoginAttempt.Success) {
				AlertLabel.Visible = true;
				AlertLabel.Location = Relocate(770, 360);
				AlertLabel.Text = LoginAttempt.Message;
			}
		}
		private void Click_SignUpButton(object sender, EventArgs e) {
			AlertLabel.Visible = false;
			SuccessMessage SignUpAttempt = _Controller.InitiateSignUp(LoginEmailTextbox.Text, LoginPasswordTextbox.Text);
			if(!SignUpAttempt.Success) {
				AlertLabel.Visible = true;
				AlertLabel.Text = SignUpAttempt.Message;
			}
		}
		private void Click_ConfirmSignUpButton(object sender, EventArgs e) {
			AlertLabel.Visible = false;
			SuccessMessage ConfirmAttempt = _Controller.ConfirmSignUp(LoginEmailTextbox.Text, LoginPasswordTextbox.Text);
			if(!ConfirmAttempt.Success) {
				AlertLabel.Visible = true;
				AlertLabel.Text = ConfirmAttempt.Message;
			}
		}

		private void Click_UploadImageButton(object sender, EventArgs e) {
			OpenFileDialog open = new OpenFileDialog();
			open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
			if(open.ShowDialog() == DialogResult.OK) {
				Bitmap NewImage = new Bitmap(open.FileName);
				ImagePanel.BackgroundImage = NewImage;
				_Controller.NewProfilePicture(NewImage);
			}
		}
		private void Click_MyProjectsButton(object sender, EventArgs e) {
			ResultsBox.Items.Clear();
			ProjectCache = _Controller.GetMyProjects();
			ProjectCache.ForEach(delegate (Project project) {
				ResultsBox.Items.Add(project.Name);
			});
		}
		private void Click_MyBugsButton(object sender, EventArgs e) {
			ResultsBox.Items.Clear();
			BugCache = _Controller.GetMyBugs();
			BugCache.ForEach(delegate (Bug bug) {
				ResultsBox.Items.Add(bug.Designation + " - " + bug.Description);
			});
		}

		public void Click_LogOutButton(object sender, EventArgs e) {
			LoginLabel.Text = "...";
			RoleLabel.Text = "...";
			_Controller.LogOut();
		}
		private void Click_ChangePasswordButton(object sender, EventArgs e) {
			if(LoginPasswordTextbox.Visible == false) {
				ChangePasswordButton.Text = "Confirm Password";
				LogOutButton.Visible = false;
				LoginPasswordTextbox.Visible = true;
				LoginPasswordTextbox.Location = Relocate(1350, 440);
				LoginPasswordTextbox.Size = LogOutButton.Size;
				LoginPasswordTextbox.MaxLength = 25;
			}
			else {
				SuccessMessage ChangePasswordAttempt = _Controller.ChangePassword(LoginPasswordTextbox.Text);
				if(ChangePasswordAttempt.Success) {
					LoginPasswordTextbox.Visible = false;
					LogOutButton.Visible = true;
					ChangePasswordButton.Text = "Change Password";
				}
				AlertLabel.Visible = true;
				AlertLabel.Text = ChangePasswordAttempt.Message;
				AlertLabel.Location = Relocate(1175, 270);
			}

		}



		////////////////////
		//  PROJECTS TAB  //
		////////////////////

		public void ShowProjectsPage() {
			ClearForm();
			_CurrentPage = Page.Projects;
			ProjectsButton.BackColor = System.Drawing.Color.Coral;
			BackdropPanel.Location = Relocate(345, 200);
			BackdropPanel.Size = ResizeElement(460, 700);
			BackdropPanel.Visible = true;
			CoralLabel1.Location = Relocate(375, 225);
			CoralLabel1.Text = "Projects";
			CoralLabel1.Visible = true;
			ResultsBox.Visible = true;
			ResultsBox.Location = Relocate(370, 300);
			ResultsBox.Size = ResizeElement(230, 550);
			ResultsBox.Font = new System.Drawing.Font("Consolas", FontSize(14), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			ResultsBox.Items.Clear();
			ProjectCache = _Controller.GetProjects();
			ProjectCache.ForEach(delegate (Project project) {
				ResultsBox.Items.Add(project.Name);
			});
			BackdropPanel2.Location = Relocate(850, 200);
			BackdropPanel2.Size = ResizeElement(800, 700);
			BackdropPanel2.Visible = true;
			ProjectOverviewButton.Location = Relocate(620, 300);
			ProjectOverviewButton.Visible = true;
			ViewProjectUpdatesButton.Location = Relocate(620, 365);
			ViewProjectUpdatesButton.Visible = true;
			AddProjectUpdateButton.Location = Relocate(620, 430);
			AddProjectUpdateButton.Visible = true;
		}
		private void Click_ProjectOverviewButton(object sender, EventArgs e) {
			if(ResultsBox.SelectedItems.Count != 0) {
				SuccessMessage GetOverviewAttempt = _Controller.GetProjectOverview(ProjectCache[ResultsBox.SelectedIndices[0]].Id);

				CoralLabel2.Text = "Project Overview - " + ProjectCache[ResultsBox.SelectedIndices[0]].Name;
				CoralLabel2.Location = Relocate(875, 225);
				CoralLabel2.Visible = true;
				CoralLabel3.Text = "Assigned Engineers";
				CoralLabel3.Location = Relocate(875, 550);
				CoralLabel3.Visible = true;
				CoralLabel4.Location = Relocate(1400, 550);
				CoralLabel4.Visible = true;
				if(GetOverviewAttempt.Success)
					CoralLabel4.Text = "Open Bugs: " + _Controller.OpenBugsInProjectCount(ProjectCache[ResultsBox.SelectedIndices[0]].Id).ToString();
				else
					CoralLabel4.Text = "Open Bugs: ";
				ResultsBox2.Location = Relocate(875, 600);
				ResultsBox2.Size = ResizeElement(750, 250);
				ResultsBox2.Visible = true;
				ResultsBox2.Items.Clear();
				ResultsBox2.Font = new System.Drawing.Font("Consolas", FontSize(20), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				TextBox.Location = Relocate(875, 275);
				TextBox.Size = ResizeElement(725, 200);
				TextBox.Text = "\t" + GetOverviewAttempt.Message;
				TextBox.Visible = true;

				GeneralTextbox.Visible = false;
				ConfirmProjectUpdateButton.Visible = false;

				if(GetOverviewAttempt.Success) {
					AccountCache = _Controller.GetAccountsOnProject(ProjectCache[ResultsBox.SelectedIndices[0]].Id);
					AccountCache.ForEach(delegate (Account account) {
						ResultsBox2.Items.Add(account.Name);
					});
				}
			}
		}
		private void Click_ViewProjectUpdatesButton(object sender, EventArgs e) {

			if(ResultsBox.SelectedItems.Count != 0) {
				CoralLabel2.Text = "Project Updates - " + ProjectCache[ResultsBox.SelectedIndices[0]].Name;
				CoralLabel2.Location = Relocate(875, 225);
				CoralLabel2.Visible = true;
				ResultsBox2.Location = Relocate(875, 275);
				ResultsBox2.Size = ResizeElement(750, 500);
				ResultsBox2.Visible = true;
				ResultsBox2.Items.Clear();
				ResultsBox2.Font = new System.Drawing.Font("Consolas", FontSize(14), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

				TextBox.Visible = false;
				CoralLabel3.Visible = false;
				CoralLabel4.Visible = false;
				GeneralTextbox.Visible = false;
				ConfirmProjectUpdateButton.Visible = false;

				if(_Controller.ClearanceToView(ProjectCache[ResultsBox.SelectedIndices[0]].Id)) {
					List<ProjectUpdate> Updates = _Controller.ViewProjectUpdates(ProjectCache[ResultsBox.SelectedIndices[0]].Id);
					Updates.ForEach(delegate (ProjectUpdate update) {
						ResultsBox2.Items.Add(update.Date + " - " + update.Description);
					});
				}
				else {
					ResultsBox2.Items.Add("You must be an administrator to view projects you are not assigned to");
				}
			}
		}
		private void Click_AddProjectUpdateButton(object sender, EventArgs e) {
			if(ResultsBox.SelectedItems.Count != 0) {
				if(_Controller.IsAccountOnProject(ProjectCache[ResultsBox.SelectedIndices[0]].Id)) {
					TextBox.Visible = false;
					CoralLabel4.Visible = false;
					CoralLabel2.Text = "Enter New Project Update";
					CoralLabel2.Location = Relocate(875, 225);
					CoralLabel2.Visible = true;
					GeneralTextbox.Visible = true;
					GeneralTextbox.Text = "";
					GeneralTextbox.Location = Relocate(875, 275);
					GeneralTextbox.Size = ResizeElement(500, 26);
					GeneralTextbox.MaxLength = 50;
					CoralLabel3.Text = "Project Updates";
					CoralLabel3.Location = Relocate(875, 325);
					CoralLabel3.Visible = true;
					ResultsBox2.Location = Relocate(875, 365);
					ResultsBox2.Size = ResizeElement(750, 500);
					ResultsBox2.Visible = true;
					ResultsBox2.Items.Clear();
					ResultsBox2.Font = new System.Drawing.Font("Consolas", FontSize(14), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
					ConfirmProjectUpdateButton.Visible = true;
					ConfirmProjectUpdateButton.Location = Relocate(1400, 265);

					List<ProjectUpdate> Updates = _Controller.ViewProjectUpdates(ProjectCache[ResultsBox.SelectedIndices[0]].Id);
					Updates.ForEach(delegate (ProjectUpdate update) {
						ResultsBox2.Items.Add(update.Date + " - " + update.Description);
					});
				}
				else {
					AlertLabel.Visible = true;
					AlertLabel.Location = Relocate(850, 160);
					AlertLabel.Text = "You must be assigned to the project to add updates";
				}
			}
		}
		private void Click_ConfirmProjectUpdateButton(object sender, EventArgs e) {
			if(GeneralTextbox.Text == "") {
				AlertLabel.Visible = true;
				AlertLabel.Location = Relocate(850, 160);
				AlertLabel.Text = "You cannot add an empty update";
			}
			else {
				_Controller.UpdateProject(ProjectCache[ResultsBox.SelectedIndices[0]].Id, GeneralTextbox.Text);
				Click_ViewProjectUpdatesButton(sender, e);
			}
		}



		/////////////////
		//  BUGS PAGE  //
		/////////////////

		public void ShowBugsPage() {
			ClearForm();
			_CurrentPage = Page.Bugs;
			BugsButton.BackColor = System.Drawing.Color.Coral;
			ImagePanel.Size = ResizeElement(200, 200);
			ImagePanel.Location = Relocate(450, 225);
			ImagePanel.Visible = true;
			BackdropPanel.Size = ResizeElement(300, 600);
			BackdropPanel.Location = Relocate(400, 325);
			BackdropPanel.Visible = true;
			CoralLabel2.Visible = true;
			CoralLabel2.Location = Relocate(420, 450);
			CoralLabel2.Text = "Your Projects";
			ResultsBox.Size = ResizeElement(260, 400);
			ResultsBox.Visible = true;
			ResultsBox.Items.Clear();
			ResultsBox.Location = Relocate(420, 500);
			ResultsBox.Font = new System.Drawing.Font("Consolas", FontSize(14), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			BackdropPanel2.Size = ResizeElement(840, 520);
			BackdropPanel2.Visible = true;
			BackdropPanel2.Location = Relocate(780, 290);
			ResultsBox2.Size = ResizeElement(800, 300);
			ResultsBox2.Visible = true;
			ResultsBox2.Location = Relocate(800, 380);
			ResultsBox2.Font = new System.Drawing.Font("Consolas", FontSize(14), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			ResultsBox2.Items.Clear();
			CoralLabel1.Location = Relocate(800, 320);
			CoralLabel1.Visible = true;
			CoralLabel1.Text = "Bugs";
			ReportBugButton.Visible = true;
			ReportBugButton.Location = Relocate(800, 700);
			SubmitBugButton.Visible = true;
			SubmitBugButton.Location = Relocate(980, 700);
			ViewUpdatesButton.Visible = true;
			ViewUpdatesButton.Location = Relocate(1245, 700);
			BackButton.Visible = false;
			ReportBugButton.Text = "Report Bug";

			ResultsBox.Items.Clear();
			ProjectCache = _Controller.GetMyProjects();
			ProjectCache.ForEach(delegate (Project project) {
				ResultsBox.Items.Add(project.Name);
			});

		}
		public void PopulateBugList() {
			CoralLabel1.Text = "Bugs";
			if(ResultsBox2.Visible == true && ResultsBox.SelectedItems.Count != 0) {
				ResultsBox2.Items.Clear();
				BugCache = _Controller.GetBugsFromProject(ProjectCache[ResultsBox.SelectedIndices[0]].Id);
				BugCache.ForEach(delegate (Bug bug) {
					ResultsBox2.Items.Add(" " + bug.Designation + " - " + bug.Status.PadRight(15, ' ') + " - " + bug.Description);
				});
				if(BugCache.Count == 0) ResultsBox2.Items.Add("No listed bugs for this project");
			}

		}
		private void Click_SubmitBugButton(object sender, EventArgs e) {
			if(ResultsBox2.SelectedItems.Count != 0 && BugCache[ResultsBox2.SelectedIndices[0]].Status == "Assigned To You") {
				string Designation = BugCache[ResultsBox2.SelectedIndices[0]].Designation;
				SuccessMessage SubmitAttempt = _Controller.SubmitBug(Designation);
				AlertLabel.Visible = true;
				AlertLabel.Text = SubmitAttempt.Message;
				AlertLabel.Location = Relocate(800, 825);
			}
			else {
				AlertLabel.Visible = true;
				AlertLabel.Text = "You can only submit bugs assigned to you";
				AlertLabel.Location = Relocate(800, 825);
			}
		}
		private void ResultsBox_SelectedIndexChanged_Bugs() {
			ReportBugButton.Visible = true;
			ReportBugButton.Location = Relocate(800, 700);
			SubmitBugButton.Visible = true;
			SubmitBugButton.Location = Relocate(980, 700);
			ViewUpdatesButton.Visible = true;
			ViewUpdatesButton.Location = Relocate(1245, 700);
			BackButton.Visible = false;
			UpdateBugButton.Visible = false;
			GeneralTextbox.Visible = false;
			GeneralTextbox.Text = "";
			ReportBugButton.Text = "Report Bug";
			PopulateBugList();
		}
		private void Click_ViewUpdatesButton(object sender, EventArgs e) {
			if(ResultsBox2.SelectedItems.Count != 0) {
				CoralLabel1.Text = ResultsBox2.SelectedItems[0].Text.Substring(1, 6);
				PopulateUpdatesList(CoralLabel1.Text);
			}
		}
		private void PopulateUpdatesList(string Designation) {
			List<BugUpdate> Updates = _Controller.GetBugUpdates(Designation);
			ResultsBox2.Items.Clear();
			Updates.ForEach(delegate (BugUpdate Update) {
				ResultsBox2.Items.Add(" " + Update.Date.ToString() + " - " + Update.Description);
			});

			ViewUpdatesButton.Visible = false;
			SubmitBugButton.Visible = false;
			GeneralTextbox.Visible = false;
			ReportBugButton.Visible = false;

			UpdateBugButton.Visible = true;
			UpdateBugButton.Text = "Add Update to Bug";
			UpdateBugButton.Location = Relocate(800, 700);

			BackButton.Visible = true;
			BackButton.Location = Relocate(1000, 700);

			GeneralTextbox.Text = "";
		}
		private void Click_BackButton(object sender, EventArgs e) {
			ResultsBox_SelectedIndexChanged(sender, e);
		}
		private void Click_UpdateBugButton(object sender, EventArgs e) {
			if(!GeneralTextbox.Visible) {
				BackButton.Visible = false;
				ReportBugButton.Visible = false;
				GeneralTextbox.Visible = true;
				GeneralTextbox.Location = Relocate(1010, 710);
				GeneralTextbox.Size = ResizeElement(500, 50);
				GeneralTextbox.Text = "";
				GeneralTextbox.MaxLength = 50;
				UpdateBugButton.Location = Relocate(800, 700);
				UpdateBugButton.Text = "Confirm Update";
			}
			else {
				if(GeneralTextbox.Text == "") {
					AlertLabel.Visible = true;
					AlertLabel.Text = "You cannot create an empty update";
					AlertLabel.Location = Relocate(800, 825);
				}
				else {
					_Controller.UpdateBug(CoralLabel1.Text, GeneralTextbox.Text);
					PopulateUpdatesList(CoralLabel1.Text);

				}
			}
		}
		private void Click_ReportBugButton(object sender, EventArgs e) {
			if(ResultsBox.SelectedItems.Count != 0) {
				if(!GeneralTextbox.Visible) {
					BackButton.Visible = false;
					SubmitBugButton.Visible = false;
					ViewUpdatesButton.Visible = false;

					GeneralTextbox.Visible = true;
					GeneralTextbox.Location = Relocate(1010, 710);
					GeneralTextbox.Size = ResizeElement(500, 50);
					GeneralTextbox.Text = "";
					GeneralTextbox.MaxLength = 50;
					ReportBugButton.Location = Relocate(800, 700);
					ReportBugButton.Text = "Confirm Bug";
				}
				else {
					if(GeneralTextbox.Text != "") {
						SuccessMessage ReportAttempt = _Controller.ReportBug(ProjectCache[ResultsBox.SelectedIndices[0]].Id, GeneralTextbox.Text);
						ReportBugButton.Text = "Report Bug";
						ResultsBox_SelectedIndexChanged_Bugs();
					}
					else {
						AlertLabel.Visible = true;
						AlertLabel.Text = "Your bug cannot have an empty description";
						AlertLabel.Location = Relocate(800, 825);
					}
				}
			}
		}



		//////////////////
		//  ADMIN PAGE  //
		//////////////////

		public void ShowAdminPage() {
			ClearForm();
			_CurrentPage = Page.Admin;
			AdminButton.BackColor = System.Drawing.Color.Coral;
			Account AccountData = _Controller.ActiveAccount;

			BackdropPanel.Location = Relocate(400, 275);
			BackdropPanel.Size = ResizeElement(925, 200);
			BackdropPanel.Visible = true;
			BackdropPanel2.Location = Relocate(400, 500);
			BackdropPanel2.Size = ResizeElement(1200, 400);
			BackdropPanel2.Visible = true;

			ImagePanel.Location = Relocate(1350, 275);
			ImagePanel.Size = ResizeElement(200, 200);
			ImagePanel.Visible = true;
			CoralLabel1.Visible = true;
			CoralLabel1.Text = AccountData.Name;
			CoralLabel1.Location = Relocate(450, 325);
			CoralLabel2.Visible = true;
			CoralLabel2.Text = AccountData.Role;
			CoralLabel2.Location = Relocate(450, 375);

			AdminAccountsButton.Visible = true;
			AdminAccountsButton.Location = new System.Drawing.Point(BackdropPanel2.Location.X-AdminAccountsButton.Size.Width+1, (int)(BackdropPanel2.Location.Y + (AdminAccountsButton.Size.Height*0.25)));
			AdminProjectsButton.Visible = true;
			AdminProjectsButton.Location = new System.Drawing.Point(BackdropPanel2.Location.X - AdminAccountsButton.Size.Width + 1, (int)(BackdropPanel2.Location.Y + (AdminAccountsButton.Size.Height*1.5)));
			AdminBugsButton.Visible = true;
			AdminBugsButton.Location = new System.Drawing.Point(BackdropPanel2.Location.X - AdminAccountsButton.Size.Width + 1, (int)(BackdropPanel2.Location.Y + (AdminAccountsButton.Size.Height*2.75)));

		}

		private void GeneralTextbox_TextChanged(object sender, EventArgs e) {

			// Accounts Tab //
			if(_CurrentPage == Page.Admin_Accounts) {
				AccountCache = _Controller.GetAllAccounts();

				if(GeneralTextbox.Text != "") {
					for(int i = 0 ; i < AccountCache.Count ; i++) {
						if(!AccountCache[i].Name.ToLower().Contains(GeneralTextbox.Text.ToLower())) {
							AccountCache.RemoveAt(i);
							i--;
						}
					}
				}
				ResultsBox.Items.Clear();
				ResultsBox2.Items.Clear();
				AccountCache.ForEach(delegate (Account account) {
					string Role = account.Role;
					if (Role == "Administrator") Role = "Admin";
					ResultsBox.Items.Add(account.Name.PadRight(26, ' ') + " - " + Role);
				});

				DeleteAccountButton.Text = "Delete Account";
			}

			// Projects Tab //
			if(_CurrentPage == Page.Admin_Projects) {
				ProjectCache = _Controller.GetProjects();

				if(GeneralTextbox.Text != "") {
					for(int i = 0 ; i < ProjectCache.Count ; i++) {
						if(!ProjectCache[i].Name.ToLower().Contains(GeneralTextbox.Text.ToLower())) {
							ProjectCache.RemoveAt(i);
							i--;
						}
					}
				}
				ResultsBox.Items.Clear();
				ResultsBox2.Items.Clear();
				ProjectCache.ForEach(delegate (Project project) {
					ResultsBox.Items.Add(project.Name.PadRight(23, ' ') + " - Bugs: " + _Controller.OpenBugsInProjectCount(project.Id));
				});

				DeleteAccountButton.Text = "Delete Account";
			}
		}
		private void ResultsBox_SelectedIndexChanged_Admin() {
			if(ResultsBox.SelectedItems.Count == 1) {
				if(_CurrentPage == Page.Admin_Accounts) {
					int AccountIndex = ResultsBox.SelectedIndices[0];
					Account account = AccountCache[AccountIndex];

					AdministratorButton.Visible = false;
					EngineerButton.Visible = false;
					GuestButton.Visible = false;
					CoralLabel3.Text = "Account Details";
					ResultsBox2.Visible = true;

					ResultsBox2.Items.Clear();
					ResultsBox2.Items.Add("Name:  " + account.Name);
					ResultsBox2.Items.Add("ID:    " + account.Id.ToString().PadLeft(6, '0'));
					ResultsBox2.Items.Add("Role:  " + account.Role);
					ResultsBox2.Items.Add("Email: " + account.Email);
					ResultsBox2.Items.Add("");
					ResultsBox2.Items.Add("Projects: ");

					ProjectCache = _Controller.GetMyProjects(account.Id);
					ProjectCache.ForEach(delegate (Project project) {
						ResultsBox2.Items.Add("    " + project.Name);
					});
					ResultsBox2.Items.Add("");

					BugCache = _Controller.GetMyBugs(account.Id);
					ResultsBox2.Items.Add("Open Bugs: " + BugCache.Count.ToString());
				}
				if(_CurrentPage == Page.Admin_Projects) {
					CreateProjectButton.Visible = true;
					CreateProjectButton.Text = "Create New Project";
					RetireProjectButton.Visible = true;
					RetireProjectButton.Text = "Retire Project";
					AssignAccountToProjectButton.Visible = true;
					AssignAccountToProjectButton.Text = "Assign Account To Project";
					RemoveAccountFromProjectButton.Visible = true;
					RemoveAccountFromProjectButton.Text = "Remove Account From Project";
					CoralLabel3.Visible = true;
					ResultsBox2.Visible = true;

					AccountCache = _Controller.GetAccountsOnProject(ProjectCache[ResultsBox.SelectedIndices[0]].Id);
					ResultsBox2.Items.Clear();
					AccountCache.ForEach(delegate (Account account) {
						ResultsBox2.Items.Add(account.Name.PadRight(20, ' ') + " - " + account.Role);
					});
				}
				if(_CurrentPage == Page.Admin_Bugs_Submitted) {
					List<BugUpdate> Updates = _Controller.GetBugUpdates(BugCache[ResultsBox.SelectedIndices[0]].Designation);
					ResultsBox2.Items.Clear();
					Updates.ForEach(delegate (BugUpdate Update) {
						ResultsBox2.Items.Add(Update.Date + " - " + Update.Description);
					});
				}
				if(_CurrentPage == Page.Admin_Bugs_Unassigned) {
					AccountCache = _Controller.GetAccountsOnProject(BugCache[ResultsBox.SelectedIndices[0]].ProjectId);
					ResultsBox2.Items.Clear();
					AccountCache.ForEach(delegate (Account account) {
						ResultsBox2.Items.Add(account.Name);
					});
				}
			}
		}

		private void Click_DeleteAccountButton(object sender, EventArgs e) {
			if(ResultsBox.SelectedItems.Count != 0) {
				if(DeleteAccountButton.Text != "Confirm Deletion") { DeleteAccountButton.Text = "Confirm Deletion"; }
				else {
					SuccessMessage DeleteAttempt = _Controller.DeleteAccount(AccountCache[ResultsBox.SelectedIndices[0]].Id);
					Click_AdminAccountsTab(sender, e);
					if(!DeleteAttempt.Success) {
						AlertLabel.Visible = true;
						AlertLabel.Text = DeleteAttempt.Message;
						AlertLabel.Location = Relocate(1100, 925);
					}
				}
			}
		}
		private void Click_EditAccountRoleButton(object sender, EventArgs e) {
			if(ResultsBox.SelectedItems.Count != 0) {
				CoralLabel3.Text = "New Role for " + AccountCache[ResultsBox.SelectedIndices[0]].Name;
				ResultsBox2.Visible = false;

				AdministratorButton.Visible = true;
				AdministratorButton.Location = Relocate(1135, 625);
				EngineerButton.Visible = true;
				EngineerButton.Location = Relocate(1135, 690);
				GuestButton.Visible = true;
				GuestButton.Location = Relocate(1135, 755);
			}
		}

		private void Click_AdministratorButton(object sender, EventArgs e) {

				int SelectedIndex = ResultsBox.SelectedIndices[0];
				SuccessMessage EditAttempt = _Controller.EditAccountRole(AccountCache[SelectedIndex].Id, "Administrator");
				Click_AdminAccountsTab(sender, e);
				ResultsBox.SelectedIndices.Add(SelectedIndex);
				if(!EditAttempt.Success) {
					AlertLabel.Visible = true;
					AlertLabel.Text = EditAttempt.Message;
					AlertLabel.Location = Relocate(1100, 915);
				}

		}
		private void Click_EngineerButton(object sender, EventArgs e) {
				int SelectedIndex = ResultsBox.SelectedIndices[0];
				SuccessMessage EditAttempt = _Controller.EditAccountRole(AccountCache[ResultsBox.SelectedIndices[0]].Id, "Engineer");
				Click_AdminAccountsTab(sender, e);
				ResultsBox.SelectedIndices.Add(SelectedIndex);
				if(!EditAttempt.Success) {
					AlertLabel.Visible = true;
					AlertLabel.Text = EditAttempt.Message;
					AlertLabel.Location = Relocate(1100, 915);
				}
			

		}
		private void Click_GuestButton(object sender, EventArgs e) {
				int SelectedIndex = ResultsBox.SelectedIndices[0];
				SuccessMessage EditAttempt = _Controller.EditAccountRole(AccountCache[ResultsBox.SelectedIndices[0]].Id, "Guest");
				Click_AdminAccountsTab(sender, e);
				ResultsBox.SelectedIndices.Add(SelectedIndex);
				if(!EditAttempt.Success) {
					AlertLabel.Visible = true;
					AlertLabel.Text = EditAttempt.Message;
					AlertLabel.Location = Relocate(1100, 915);
				}
			}

		private void Click_CreateProjectButton(object sender, EventArgs e) {
			if(CreateProjectButton.Text != "Confirm Project") {
				CreateProjectButton.Text = "Confirm Project";

				RetireProjectButton.Visible = false;
				AssignAccountToProjectButton.Visible = false;
				RemoveAccountFromProjectButton.Visible = false;
				ResultsBox.Visible = false;
				GeneralTextbox.Text = "";
				ResultsBox2.Visible = false;

				CoralLabel3.Text = "New Project Name";
				CoralLabel3.Location = Relocate(675, 550);
				GeneralTextbox.Visible = true;
				GeneralTextbox.Location = Relocate(680, 600);
				GeneralTextbox.MaxLength = 50;

				CoralLabel4.Visible = true;
				CoralLabel4.Text = "New Project Description";
				CoralLabel4.Location = Relocate(675, 665);
				GeneralTextBox2.Visible = true;
				GeneralTextBox2.Location = Relocate(680, 715);
				GeneralTextBox2.MaxLength = 500;

				CoralLabel5.Visible = true;
				CoralLabel5.Text = "Bug Designation";
				CoralLabel5.Location = Relocate(675, 780);
				GeneralTextBox3.Visible = true;
				GeneralTextBox3.Location = Relocate(680, 830);
				GeneralTextBox3.MaxLength = 2;
				GeneralTextBox3.Size = ResizeElement(30, 36);

			}
			else {
				SuccessMessage CreateAttempt = _Controller.CreateProject(GeneralTextbox.Text, GeneralTextBox2.Text, GeneralTextBox3.Text.ToUpper());
					AlertLabel.Visible = true;
					AlertLabel.Text = CreateAttempt.Message;
					AlertLabel.Location = Relocate(1000, 910);
				CreateProjectButton.Text = "Create Project";
				Click_AdminProjectsTab(sender, e);
			}

		}
		private void Click_RetireProjectButton(object sender, EventArgs e) {
			if(RetireProjectButton.Text != "Confirm Retire" && ResultsBox.SelectedItems.Count != 0) {
				CoralLabel3.Visible = false;
				ResultsBox2.Visible = false;
				CreateProjectButton.Visible = false;
				AssignAccountToProjectButton.Visible = false;
				RemoveAccountFromProjectButton.Visible = false;
				RetireProjectButton.Text = "Confirm Retire";

			}
			else if(RetireProjectButton.Text == "Confirm Retire" && ResultsBox.SelectedItems.Count != 0) {
				CoralLabel3.Visible = true;
				ResultsBox2.Visible = true;
				CreateProjectButton.Visible = true;
				AssignAccountToProjectButton.Visible = true;
				RemoveAccountFromProjectButton.Visible = true;
				RetireProjectButton.Text = "Retire Project";

				SuccessMessage RetireAttempt = _Controller.RetireProject(ProjectCache[ResultsBox.SelectedIndices[0]].Id);
				if(RetireAttempt.Success) {
					AlertLabel.Visible = true;
					AlertLabel.Text = RetireAttempt.Message;
					AlertLabel.Location = Relocate(1000, 910);
				}
					GeneralTextbox_TextChanged(sender, e);
			}
		}
		private void Click_AssignAccountToProjectButton(object sender, EventArgs e) {
			if(AssignAccountToProjectButton.Text != "Confirm Assign" && ResultsBox.SelectedItems.Count != 0) {
				CoralLabel3.Text = "Available Engineers";
				CreateProjectButton.Visible = false;
				RetireProjectButton.Visible = false;
				RemoveAccountFromProjectButton.Visible = false;
				AssignAccountToProjectButton.Text = "Confirm Assign";

				AccountCache = _Controller.GetAccountsOffProject(ProjectCache[ResultsBox.SelectedIndices[0]].Id);
				ResultsBox2.Items.Clear();
				AccountCache.ForEach(delegate (Account account) {
					ResultsBox2.Items.Add(account.Name.PadRight(20, ' ') + " - " + account.Role);
				});
			}
			else if(AssignAccountToProjectButton.Text == "Confirm Assign" && ResultsBox.SelectedItems.Count != 0 && ResultsBox2.SelectedItems.Count != 0) {
				CoralLabel3.Text = "Assigned Engineers";
				CreateProjectButton.Visible = true;
				RetireProjectButton.Visible = true;
				RemoveAccountFromProjectButton.Visible = true;
				AssignAccountToProjectButton.Text = "Assign Account To Project";
				SuccessMessage AssignAttempt = _Controller.AssignAccountToProject(AccountCache[ResultsBox2.SelectedIndices[0]].Id, ProjectCache[ResultsBox.SelectedIndices[0]].Id);
				if(AssignAttempt.Success) {
					AlertLabel.Visible = true;
					AlertLabel.Text = AssignAttempt.Message;
					AlertLabel.Location = Relocate(1000, 910);
				}
				GeneralTextbox_TextChanged(sender, e);
			}
		}
		private void Click_RemoveAccountFromProjectButton(object sender, EventArgs e) {
			if(ResultsBox.SelectedItems.Count != 0 && ResultsBox2.SelectedItems.Count != 0) {

				SuccessMessage RemovalAttempt = _Controller.RemoveAccountFromProject(AccountCache[ResultsBox2.SelectedIndices[0]].Id, ProjectCache[ResultsBox.SelectedIndices[0]].Id);
				if(RemovalAttempt.Success) {
					AlertLabel.Visible = true;
					AlertLabel.Text = RemovalAttempt.Message;
					AlertLabel.Location = Relocate(1000, 910);
				}
				GeneralTextbox_TextChanged(sender, e);
			}
		}

		private void Click_ViewSubmittedBugsButton(object Sender, EventArgs e) {
			ResultsBox.Items.Clear();
			ResultsBox2.Items.Clear();
			_CurrentPage = Page.Admin_Bugs_Submitted;
			CoralLabel3.Visible = true;
			CoralLabel3.Location = Relocate(675, 550);
			CoralLabel3.Text = "Submitted Bugs";
			CoralLabel4.Visible = true;
			CoralLabel4.Location = Relocate(1115, 550);
			CoralLabel4.Text = "Bug Updates";

			ResultsBox.Font = new System.Drawing.Font("Consolas", FontSize(11), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			ResultsBox2.Font = new System.Drawing.Font("Consolas", FontSize(11), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

			ResolveBugButton.Visible = true;
			ResolveBugButton.Location = Relocate(450, 770);
			RejectBugButton.Visible = true;
			RejectBugButton.Location = Relocate(450, 830);

			AssignBugButton.Visible = false;


			BugCache = _Controller.GetSubmittedBugs();
			BugCache.ForEach(delegate (Bug bug) {
				ResultsBox.Items.Add(bug.Designation + " - " + bug.Description);
			});

		}

		private void Click_RejectBugButton(object sender, EventArgs e) {
			if(ResultsBox.SelectedItems.Count != 0) {
				SuccessMessage ResolveAttempt = _Controller.RejectBug(BugCache[ResultsBox.SelectedIndices[0]].Designation);
				if(ResolveAttempt.Success) {
					AlertLabel.Visible = true;
					AlertLabel.Text = "Bug: " + BugCache[ResultsBox.SelectedIndices[0]].Designation + " was rejected";
					AlertLabel.Location = Relocate(1000, 910);
				}
				Click_ViewSubmittedBugsButton(sender, e);
			}
		}
		private void Click_ResolveBugButton(object Sender, EventArgs e) {
			if(ResultsBox.SelectedItems.Count != 0) {
				SuccessMessage ResolveAttempt = _Controller.ResolveBug(BugCache[ResultsBox.SelectedIndices[0]].Designation);
				if(ResolveAttempt.Success) {
					AlertLabel.Visible = true;
					AlertLabel.Text = "Bug Successfully Resolved";
					AlertLabel.Location = Relocate(1000, 910);
				}
				Click_ViewSubmittedBugsButton(Sender, e);
			}
		}
		private void Click_ViewUnassignedBugsButton(object Sender, EventArgs e) {
			ResultsBox.Items.Clear();
			ResultsBox2.Items.Clear();
			_CurrentPage = Page.Admin_Bugs_Unassigned;
			CoralLabel3.Visible = true;
			CoralLabel3.Location = Relocate(675, 550);
			CoralLabel3.Text = "Unassigned Bugs";
			CoralLabel4.Visible = true;
			CoralLabel4.Location = Relocate(1115, 550);
			CoralLabel4.Text = "Project Engineers";
			ResultsBox.Font = new System.Drawing.Font("Consolas", FontSize(11), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			ResultsBox2.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

			ResolveBugButton.Visible = false;
			RejectBugButton.Visible = false;

			AssignBugButton.Location = Relocate(450, 770);
			AssignBugButton.Visible = true;

			BugCache = _Controller.GetUnassignedBugs();
			BugCache.ForEach(delegate (Bug bug) {
				ResultsBox.Items.Add(bug.Designation + " - " + bug.Description);
			});

		}
		private void Click_AssignBugButton(object Sender, EventArgs e) {
			if(ResultsBox.SelectedItems.Count != 0 && ResultsBox2.SelectedItems.Count != 0) {
				SuccessMessage AssignAttempt = _Controller.AssignBug(BugCache[ResultsBox.SelectedIndices[0]].Designation, AccountCache[ResultsBox2.SelectedIndices[0]].Id);
				if(AssignAttempt.Success) {
					AlertLabel.Visible = true;
					AlertLabel.Text = "Bug Successfully Assigned to " + AccountCache[ResultsBox2.SelectedIndices[0]].Name;
					AlertLabel.Location = Relocate(1000, 910);
				}
				Click_ViewUnassignedBugsButton(Sender, e);
			}
		}

		private void Click_AdminAccountsTab(object sender, EventArgs e) {
			_CurrentPage = Page.Admin_Accounts;
			ClearAdminPanel();

			AdminAccountsButton.BackColor = System.Drawing.Color.Black;

			EditAccountRoleButton.Visible = true;
			EditAccountRoleButton.Location = Relocate(450, 600);
			DeleteAccountButton.Visible = true;
			DeleteAccountButton.Location = Relocate(450, 660);
			DeleteAccountButton.Text = "Delete Account";

			ResultsBox.Visible = true;
			ResultsBox.Location = Relocate(675, 600);
			ResultsBox.Size = ResizeElement(375, 275);
			ResultsBox2.Font = new System.Drawing.Font("Consolas", FontSize(14), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			GeneralTextbox.Visible = true;
			GeneralTextbox.Location = Relocate(675, 550);
			GeneralTextbox.MaxLength = 25;

			ResultsBox2.Visible = true;
			ResultsBox2.Location = Relocate(1115, 600);
			ResultsBox2.Size = ResizeElement(400, 275);
			ResultsBox2.Font = new System.Drawing.Font("Consolas", FontSize(12), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			CoralLabel3.Visible = true;
			CoralLabel3.Location = Relocate(1115, 550);
			CoralLabel3.Text = "Account Details";


			GeneralTextbox_TextChanged(sender, e);
		}
		private void Click_AdminProjectsTab(object sender, EventArgs e) {
			_CurrentPage = Page.Admin_Projects;
			ClearAdminPanel();

			AdminProjectsButton.BackColor = System.Drawing.Color.Black;

			ResultsBox.Visible = true;
			ResultsBox.Location = Relocate(675, 600);
			ResultsBox.Size = ResizeElement(375, 275);
			ResultsBox.Font = new System.Drawing.Font("Consolas", FontSize(14), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			GeneralTextbox.Visible = true;
			GeneralTextbox.Location = Relocate(675, 550);
			GeneralTextbox.Text = "";
			GeneralTextbox.MaxLength = 50;

			ResultsBox2.Visible = true;
			ResultsBox2.Location = Relocate(1115, 600);
			ResultsBox2.Size = ResizeElement(400, 275);
			ResultsBox2.Font = new System.Drawing.Font("Consolas", FontSize(12), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			CoralLabel3.Visible = true;
			CoralLabel3.Location = Relocate(1115, 550);
			CoralLabel3.Text = "Engineers Assigned";

			CreateProjectButton.Visible = true;
			CreateProjectButton.Text = "Create New Project";
			CreateProjectButton.Location = Relocate(450, 600);

			RetireProjectButton.Visible = true;
			RetireProjectButton.Location = Relocate(450, 662);
			RetireProjectButton.Text = "Retire Project";

			AssignAccountToProjectButton.Visible = true;
			AssignAccountToProjectButton.Location = Relocate(450, 724);
			AssignAccountToProjectButton.Text = "Assign Account To Project";

			RemoveAccountFromProjectButton.Visible = true;
			RemoveAccountFromProjectButton.Location = Relocate(450, 801);
			RemoveAccountFromProjectButton.Text = "Remove Account From Project";

			GeneralTextbox_TextChanged(sender, e);
		}
		private void Click_AdminBugsTab(object sender, EventArgs e) {
			_CurrentPage = Page.Admin_Bugs;
			ClearAdminPanel();

			AdminBugsButton.BackColor = System.Drawing.Color.Black;

			ViewSubmittedBugsButton.Visible = true;
			ViewSubmittedBugsButton.Location = Relocate(450, 600);
			ViewUnassignedBugsButton.Visible = true;
			ViewUnassignedBugsButton.Location = Relocate(450, 685);

			ResultsBox.Visible = true;
			ResultsBox.Location = Relocate(675, 600);
			ResultsBox.Size = ResizeElement(375, 275);
			ResultsBox.Items.Clear();

			ResultsBox2.Items.Clear();
			ResultsBox2.Visible = true;
			ResultsBox2.Location = Relocate(1115, 600);
			ResultsBox2.Size = ResizeElement(400, 275);
			ResultsBox2.Font = new System.Drawing.Font("Consolas", FontSize(11), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		}

		private void ClearAdminPanel() {
			AdminAccountsButton.BackColor = System.Drawing.Color.Coral;
			AdminProjectsButton.BackColor = System.Drawing.Color.Coral;
			AdminBugsButton.BackColor = System.Drawing.Color.Coral;
			ResultsBox.Visible = false;
			ResultsBox2.Visible = false;
			EditAccountRoleButton.Visible = false;
			DeleteAccountButton.Visible = false;
			AdministratorButton.Visible = false;
			EngineerButton.Visible = false;
			GuestButton.Visible = false;
			CoralLabel3.Visible = false;
			CoralLabel4.Visible = false;
			CoralLabel5.Visible = false;
			CoralLabel6.Visible = false;
			CoralLabel7.Visible = false;
			GeneralTextbox.Visible = false;
			GeneralTextBox2.Visible = false;
			GeneralTextBox3.Visible = false;
			GeneralTextBox4.Visible = false;
			GeneralTextBox5.Visible = false;
			GeneralTextbox.Text = "";
			GeneralTextBox2.Text = "";
			GeneralTextBox3.Text = "";
			GeneralTextBox4.Text = "";
			GeneralTextBox5.Text = "";
			CreateProjectButton.Visible = false;
			RetireProjectButton.Visible = false;
			AssignAccountToProjectButton.Visible = false;
			RemoveAccountFromProjectButton.Visible = false;
			ViewSubmittedBugsButton.Visible = false;
			ViewUnassignedBugsButton.Visible = false;
			ResolveBugButton.Visible = false;
			AssignBugButton.Visible = false;
			RejectBugButton.Visible = false;
		}



		////////////////////////
		// GENERAL FUNCTIONS  //
		////////////////////////

		private void Exit(object sender, EventArgs e) {
			_Controller.Exit();
			System.Windows.Forms.Application.ExitThread();
		}
		private void ClearForm() {
			ProjectsButton.BackColor = System.Drawing.Color.Black;
			BugsButton.BackColor = System.Drawing.Color.Black;
			ProfileButton.BackColor = System.Drawing.Color.Black;
			AdminButton.BackColor = System.Drawing.Color.Black;
			ClearAdminPanel();
			GreetingLabel.Visible = false;
			AlertLabel.Visible = false;
			BackdropPanel.Visible = false;
			ImagePanel.Visible = false;
			ResultsBox.Visible = false;
			LoginEmailLabel.Visible = false;
			LoginEmailLabel.Text = "Email";
			LoginPasswordLabel.Visible = false;
			LoginEmailTextbox.Visible = false;
			LoginEmailTextbox.Text = "";
			LoginPasswordTextbox.Visible = false;
			LoginPasswordTextbox.Text = "";
			LoginButton.Visible = false;
			SignUpButton.Visible = false;
			CancelSignUpButton.Visible = false;
			ConfirmSignUpButton.Visible = false;
			MyBugsButton.Visible = false;
			MyProjectsButton.Visible = false;
			UploadImageButton.Visible = false;
			LogOutButton.Visible = false;
			ChangePasswordButton.Visible = false;
			CoralLabel1.Visible = false;
			CoralLabel2.Visible = false;
			CoralLabel3.Visible = false;
			CoralLabel4.Visible = false;
			SubmitBugButton.Visible = false;
			ResultsBox2.Visible = false;
			TitleLabel.Visible = false;
			BackdropPanel2.Visible = false;
			GeneralTextbox.Visible = false;
			ViewUpdatesButton.Visible = false;
			AddProjectUpdateButton.Visible = false;
			ViewProjectUpdatesButton.Visible = false;
			ProjectOverviewButton.Visible = false;
			TextBox.Visible = false;
			ReportBugButton.Visible = false;
			AdminAccountsButton.Visible = false;
			AdminBugsButton.Visible = false;
			AdminProjectsButton.Visible = false;
			DeleteAccountButton.Visible = false;
			EditAccountRoleButton.Visible = false;
			RejectBugButton.Visible = false;

			GeneralTextbox.Text = "";
			GeneralTextBox2.Text = "";
			GeneralTextBox3.Text = "";
			GeneralTextBox4.Text = "";
			GeneralTextBox5.Text = "";
		}
		private void Click_AlertLabel(object sender, EventArgs e) {
			AlertLabel.Visible = false;
		}
		private void ResultsBox_SelectedIndexChanged(object sender, EventArgs e) {
			AlertLabel.Visible = false;
			if(_CurrentPage == Page.Bugs) ResultsBox_SelectedIndexChanged_Bugs();
			else if(CurrentPage.Substring(0,5) == "Admin") ResultsBox_SelectedIndexChanged_Admin();
		}
		private System.Drawing.Point Relocate(int _X, int _Y) {
			double X = ((((double)_X-100) / 1920) * this.Bounds.Width) + 100;
			double Y = ((((double)_Y-110) / 1080) * this.Bounds.Height) + 110;
			return new System.Drawing.Point((int)X, (int)Y);
		}
		private System.Drawing.Size ResizeElement(int _X, int _Y) {
			double X = ((double)_X / 1920) * this.Bounds.Width;
			double Y = ((double)_Y / 1080) * this.Bounds.Height;
			return new System.Drawing.Size((int)X, (int)Y);
		}
		private float FontSize(double font) {
			return (float)(font * ((double)Bounds.Width / 1920) * ((double)Bounds.Height / 1080)); 
		}
		private void InitializeElementSizes() {
			InitializeButton(LoginButton);
			InitializeButton(SignUpButton);
			InitializeButton(EditAccountRoleButton);
			InitializeButton(DeleteAccountButton);
			InitializeButton(AdminAccountsButton);
			InitializeButton(AdminProjectsButton);
			InitializeButton(AdminBugsButton);
			InitializeButton(AdministratorButton);
			InitializeButton(EngineerButton);
			InitializeButton(GuestButton);
			InitializeButton(CreateProjectButton);
			InitializeButton(RetireProjectButton);
			InitializeButton(AssignAccountToProjectButton);
			InitializeButton(RemoveAccountFromProjectButton);
			InitializeButton(ViewSubmittedBugsButton);
			InitializeButton(ViewUnassignedBugsButton);
			InitializeButton(ResolveBugButton);
			InitializeButton(AssignBugButton);
			InitializeButton(LogOutButton);
			InitializeButton(ChangePasswordButton);
			InitializeButton(SubmitBugButton);
			InitializeButton(UpdateBugButton);
			InitializeButton(ProjectOverviewButton);
			InitializeButton(ViewProjectUpdatesButton);
			InitializeButton(AddProjectUpdateButton);
			InitializeButton(ReportBugButton);
			InitializeButton(MyProjectsButton);
			InitializeButton(MyBugsButton);
			InitializeButton(ViewUpdatesButton);
			InitializeButton(BackButton);
			InitializeButton(ConfirmProjectUpdateButton);
			InitializeButton(ConfirmSignUpButton);
			InitializeButton(CancelSignUpButton);
			InitializeButton(UploadImageButton);
			InitializeButton(RejectBugButton);

			CoralLabel1.Font = new System.Drawing.Font("Microsoft YaHei", FontSize(27.75), System.Drawing.FontStyle.Bold);
			CoralLabel2.Font = new System.Drawing.Font("Microsoft YaHei", FontSize(21.75), System.Drawing.FontStyle.Bold);
			CoralLabel3.Font = new System.Drawing.Font("Microsoft YaHei", FontSize(21.75), System.Drawing.FontStyle.Bold);
			CoralLabel4.Font = new System.Drawing.Font("Microsoft YaHei", FontSize(21.75), System.Drawing.FontStyle.Bold);
			CoralLabel5.Font = new System.Drawing.Font("Microsoft YaHei", FontSize(21.75), System.Drawing.FontStyle.Bold);
			CoralLabel6.Font = new System.Drawing.Font("Microsoft YaHei", FontSize(21.75), System.Drawing.FontStyle.Bold);
			CoralLabel7.Font = new System.Drawing.Font("Microsoft YaHei", FontSize(12.75), System.Drawing.FontStyle.Bold);
			AlertLabel.Font = new System.Drawing.Font("Microsoft YaHei", FontSize(14.25), System.Drawing.FontStyle.Bold);
			TitleLabel.Font = new System.Drawing.Font("Microsoft YaHei", FontSize(14.25), System.Drawing.FontStyle.Bold);
			LoginEmailLabel.Font = new System.Drawing.Font("Microsoft YaHei", FontSize(15.75), System.Drawing.FontStyle.Bold);
			LoginPasswordLabel.Font = new System.Drawing.Font("Microsoft YaHei", FontSize(15.75), System.Drawing.FontStyle.Bold);

			LoginEmailTextbox.Font = new System.Drawing.Font("Microsoft YaHei", FontSize(14.25), System.Drawing.FontStyle.Bold);
			LoginPasswordTextbox.Font = new System.Drawing.Font("Microsoft YaHei", FontSize(14.25), System.Drawing.FontStyle.Bold);
			GeneralTextbox.Font = new System.Drawing.Font("Microsoft YaHei", FontSize(14.25), System.Drawing.FontStyle.Regular);
			GeneralTextBox2.Font = new System.Drawing.Font("Microsoft YaHei", FontSize(14.25), System.Drawing.FontStyle.Regular);
			GeneralTextBox3.Font = new System.Drawing.Font("Microsoft YaHei", FontSize(14.25), System.Drawing.FontStyle.Regular);
			GeneralTextBox4.Font = new System.Drawing.Font("Microsoft YaHei", FontSize(14.25), System.Drawing.FontStyle.Regular);
			GeneralTextBox5.Font = new System.Drawing.Font("Microsoft YaHei", FontSize(14.25), System.Drawing.FontStyle.Regular);


		}
		private void InitializeButton(System.Windows.Forms.Button Button) {

			Button.Size = ResizeElement(Button.Size.Width, Button.Size.Height);
			Button.Font = new System.Drawing.Font("Microsoft YaHei", FontSize(12), System.Drawing.FontStyle.Bold);
		}
	}
}
