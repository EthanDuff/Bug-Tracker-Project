
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Interop;

namespace BugTracker {
	partial class TopForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.RoleLabel = new System.Windows.Forms.Label();
			this.LoginLabel = new System.Windows.Forms.Label();
			this.AlertLabel = new System.Windows.Forms.Label();
			this.GreetingLabel = new System.Windows.Forms.Label();
			this.LoginEmailLabel = new System.Windows.Forms.Label();
			this.LoginEmailTextbox = new System.Windows.Forms.TextBox();
			this.LoginPasswordLabel = new System.Windows.Forms.Label();
			this.LoginPasswordTextbox = new System.Windows.Forms.TextBox();
			this.LoginButton = new System.Windows.Forms.Button();
			this.SignUpButton = new System.Windows.Forms.Button();
			this.BackdropPanel = new System.Windows.Forms.Panel();
			this.CancelSignUpButton = new System.Windows.Forms.Button();
			this.ImagePanel = new System.Windows.Forms.Panel();
			this.UploadImageButton = new System.Windows.Forms.Button();
			this.MyProjectsButton = new System.Windows.Forms.Button();
			this.MyBugsButton = new System.Windows.Forms.Button();
			this.ResultsBox = new System.Windows.Forms.ListView();
			this.CoralLabel1 = new System.Windows.Forms.Label();
			this.CoralLabel2 = new System.Windows.Forms.Label();
			this.LogOutButton = new System.Windows.Forms.Button();
			this.ChangePasswordButton = new System.Windows.Forms.Button();
			this.SubmitBugButton = new System.Windows.Forms.Button();
			this.ResultsBox2 = new System.Windows.Forms.ListView();
			this.TitleLabel = new System.Windows.Forms.Label();
			this.BackdropPanel2 = new System.Windows.Forms.Panel();
			this.UpdateBugButton = new System.Windows.Forms.Button();
			this.ViewUpdatesButton = new System.Windows.Forms.Button();
			this.GeneralTextbox = new System.Windows.Forms.TextBox();
			this.BackButton = new System.Windows.Forms.Button();
			this.ProjectOverviewButton = new System.Windows.Forms.Button();
			this.ViewProjectUpdatesButton = new System.Windows.Forms.Button();
			this.AddProjectUpdateButton = new System.Windows.Forms.Button();
			this.CoralLabel3 = new System.Windows.Forms.Label();
			this.TextBox = new System.Windows.Forms.RichTextBox();
			this.ConfirmProjectUpdateButton = new System.Windows.Forms.Button();
			this.ReportBugButton = new System.Windows.Forms.Button();
			this.CoralLabel4 = new System.Windows.Forms.Label();
			this.EditAccountRoleButton = new System.Windows.Forms.Button();
			this.DeleteAccountButton = new System.Windows.Forms.Button();
			this.AdministratorButton = new System.Windows.Forms.Button();
			this.EngineerButton = new System.Windows.Forms.Button();
			this.GuestButton = new System.Windows.Forms.Button();
			this.CreateProjectButton = new System.Windows.Forms.Button();
			this.AssignAccountToProjectButton = new System.Windows.Forms.Button();
			this.RemoveAccountFromProjectButton = new System.Windows.Forms.Button();
			this.RetireProjectButton = new System.Windows.Forms.Button();
			this.GeneralTextBox2 = new System.Windows.Forms.TextBox();
			this.GeneralTextBox3 = new System.Windows.Forms.TextBox();
			this.GeneralTextBox4 = new System.Windows.Forms.TextBox();
			this.GeneralTextBox5 = new System.Windows.Forms.TextBox();
			this.CoralLabel5 = new System.Windows.Forms.Label();
			this.ConfirmSignUpButton = new System.Windows.Forms.Button();
			this.CoralLabel6 = new System.Windows.Forms.Label();
			this.CoralLabel7 = new System.Windows.Forms.Label();
			this.ViewSubmittedBugsButton = new System.Windows.Forms.Button();
			this.ViewUnassignedBugsButton = new System.Windows.Forms.Button();
			this.ResolveBugButton = new System.Windows.Forms.Button();
			this.AssignBugButton = new System.Windows.Forms.Button();
			this.RejectBugButton = new System.Windows.Forms.Button();
			this.AdminBugsButton = new System.Windows.Forms.Button();
			this.AdminProjectsButton = new System.Windows.Forms.Button();
			this.AdminAccountsButton = new System.Windows.Forms.Button();
			this.ExitButton = new System.Windows.Forms.Button();
			this.AdminButton = new System.Windows.Forms.Button();
			this.ProjectsButton = new System.Windows.Forms.Button();
			this.BugsButton = new System.Windows.Forms.Button();
			this.ProfileButton = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Black;
			this.panel1.Controls.Add(this.AdminButton);
			this.panel1.Controls.Add(this.ProjectsButton);
			this.panel1.Controls.Add(this.BugsButton);
			this.panel1.Controls.Add(this.ProfileButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(100, 1080);
			this.panel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.panel2.Controls.Add(this.RoleLabel);
			this.panel2.Controls.Add(this.LoginLabel);
			this.panel2.Controls.Add(this.ExitButton);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(100, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1820, 110);
			this.panel2.TabIndex = 1;
			// 
			// RoleLabel
			// 
			this.RoleLabel.AutoSize = true;
			this.RoleLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.RoleLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F);
			this.RoleLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.RoleLabel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.RoleLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.RoleLabel.Location = new System.Drawing.Point(33, 61);
			this.RoleLabel.Name = "RoleLabel";
			this.RoleLabel.Size = new System.Drawing.Size(27, 28);
			this.RoleLabel.TabIndex = 6;
			this.RoleLabel.Text = "...";
			// 
			// LoginLabel
			// 
			this.LoginLabel.AutoSize = true;
			this.LoginLabel.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.LoginLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold);
			this.LoginLabel.ForeColor = System.Drawing.Color.Black;
			this.LoginLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.LoginLabel.Location = new System.Drawing.Point(29, 19);
			this.LoginLabel.Name = "LoginLabel";
			this.LoginLabel.Size = new System.Drawing.Size(45, 42);
			this.LoginLabel.TabIndex = 2;
			this.LoginLabel.Text = "...";
			// 
			// AlertLabel
			// 
			this.AlertLabel.AutoSize = true;
			this.AlertLabel.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold);
			this.AlertLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.AlertLabel.Location = new System.Drawing.Point(94, 113);
			this.AlertLabel.Name = "AlertLabel";
			this.AlertLabel.Size = new System.Drawing.Size(374, 26);
			this.AlertLabel.TabIndex = 3;
			this.AlertLabel.Text = "Please log in to access the bugs panel";
			this.AlertLabel.Visible = false;
			this.AlertLabel.Click += new System.EventHandler(this.Click_AlertLabel);
			// 
			// GreetingLabel
			// 
			this.GreetingLabel.AutoSize = true;
			this.GreetingLabel.Font = new System.Drawing.Font("Arial Black", 60F, System.Drawing.FontStyle.Bold);
			this.GreetingLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.GreetingLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.GreetingLabel.Location = new System.Drawing.Point(290, 683);
			this.GreetingLabel.Name = "GreetingLabel";
			this.GreetingLabel.Size = new System.Drawing.Size(1119, 226);
			this.GreetingLabel.TabIndex = 4;
			this.GreetingLabel.Text = "Hello!\r\nWelcome to Bug Tracker\r\n";
			this.GreetingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LoginEmailLabel
			// 
			this.LoginEmailLabel.AutoSize = true;
			this.LoginEmailLabel.BackColor = System.Drawing.Color.Black;
			this.LoginEmailLabel.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold);
			this.LoginEmailLabel.ForeColor = System.Drawing.Color.Coral;
			this.LoginEmailLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.LoginEmailLabel.Location = new System.Drawing.Point(1501, 181);
			this.LoginEmailLabel.Name = "LoginEmailLabel";
			this.LoginEmailLabel.Size = new System.Drawing.Size(69, 28);
			this.LoginEmailLabel.TabIndex = 5;
			this.LoginEmailLabel.Text = "Email";
			this.LoginEmailLabel.Visible = false;
			// 
			// LoginEmailTextbox
			// 
			this.LoginEmailTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.LoginEmailTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.LoginEmailTextbox.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F);
			this.LoginEmailTextbox.Location = new System.Drawing.Point(1245, 221);
			this.LoginEmailTextbox.MaxLength = 25;
			this.LoginEmailTextbox.Name = "LoginEmailTextbox";
			this.LoginEmailTextbox.Size = new System.Drawing.Size(325, 26);
			this.LoginEmailTextbox.TabIndex = 6;
			this.LoginEmailTextbox.Visible = false;
			// 
			// LoginPasswordLabel
			// 
			this.LoginPasswordLabel.AutoSize = true;
			this.LoginPasswordLabel.BackColor = System.Drawing.Color.Black;
			this.LoginPasswordLabel.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold);
			this.LoginPasswordLabel.ForeColor = System.Drawing.Color.Coral;
			this.LoginPasswordLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.LoginPasswordLabel.Location = new System.Drawing.Point(1459, 147);
			this.LoginPasswordLabel.Name = "LoginPasswordLabel";
			this.LoginPasswordLabel.Size = new System.Drawing.Size(113, 28);
			this.LoginPasswordLabel.TabIndex = 7;
			this.LoginPasswordLabel.Text = "Password";
			this.LoginPasswordLabel.Visible = false;
			// 
			// LoginPasswordTextbox
			// 
			this.LoginPasswordTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.LoginPasswordTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.LoginPasswordTextbox.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F);
			this.LoginPasswordTextbox.Location = new System.Drawing.Point(1245, 261);
			this.LoginPasswordTextbox.MaxLength = 25;
			this.LoginPasswordTextbox.Name = "LoginPasswordTextbox";
			this.LoginPasswordTextbox.PasswordChar = '*';
			this.LoginPasswordTextbox.Size = new System.Drawing.Size(325, 26);
			this.LoginPasswordTextbox.TabIndex = 8;
			this.LoginPasswordTextbox.Visible = false;
			// 
			// LoginButton
			// 
			this.LoginButton.BackColor = System.Drawing.Color.Black;
			this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LoginButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.LoginButton.ForeColor = System.Drawing.Color.Coral;
			this.LoginButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.LoginButton.Location = new System.Drawing.Point(1330, 301);
			this.LoginButton.Name = "LoginButton";
			this.LoginButton.Size = new System.Drawing.Size(116, 45);
			this.LoginButton.TabIndex = 9;
			this.LoginButton.Text = "Log In";
			this.LoginButton.UseMnemonic = false;
			this.LoginButton.UseVisualStyleBackColor = false;
			this.LoginButton.Visible = false;
			this.LoginButton.Click += new System.EventHandler(this.Click_LoginButton);
			// 
			// SignUpButton
			// 
			this.SignUpButton.BackColor = System.Drawing.Color.Black;
			this.SignUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SignUpButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.SignUpButton.ForeColor = System.Drawing.Color.Coral;
			this.SignUpButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.SignUpButton.Location = new System.Drawing.Point(1454, 301);
			this.SignUpButton.Name = "SignUpButton";
			this.SignUpButton.Size = new System.Drawing.Size(116, 45);
			this.SignUpButton.TabIndex = 10;
			this.SignUpButton.Text = "Sign Up";
			this.SignUpButton.UseVisualStyleBackColor = false;
			this.SignUpButton.Visible = false;
			this.SignUpButton.Click += new System.EventHandler(this.Click_SignUpButton);
			// 
			// BackdropPanel
			// 
			this.BackdropPanel.BackColor = System.Drawing.Color.Black;
			this.BackdropPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.BackdropPanel.Location = new System.Drawing.Point(1331, 116);
			this.BackdropPanel.Name = "BackdropPanel";
			this.BackdropPanel.Size = new System.Drawing.Size(50, 50);
			this.BackdropPanel.TabIndex = 11;
			this.BackdropPanel.Visible = false;
			// 
			// CancelSignUpButton
			// 
			this.CancelSignUpButton.BackColor = System.Drawing.Color.Black;
			this.CancelSignUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CancelSignUpButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.CancelSignUpButton.ForeColor = System.Drawing.Color.Coral;
			this.CancelSignUpButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.CancelSignUpButton.Location = new System.Drawing.Point(1456, 352);
			this.CancelSignUpButton.Name = "CancelSignUpButton";
			this.CancelSignUpButton.Size = new System.Drawing.Size(116, 45);
			this.CancelSignUpButton.TabIndex = 13;
			this.CancelSignUpButton.Text = "Cancel";
			this.CancelSignUpButton.UseMnemonic = false;
			this.CancelSignUpButton.UseVisualStyleBackColor = false;
			this.CancelSignUpButton.Visible = false;
			this.CancelSignUpButton.Click += new System.EventHandler(this.Click_ProfileButton);
			// 
			// ImagePanel
			// 
			this.ImagePanel.BackColor = System.Drawing.Color.DimGray;
			this.ImagePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ImagePanel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
			this.ImagePanel.Location = new System.Drawing.Point(1387, 116);
			this.ImagePanel.Name = "ImagePanel";
			this.ImagePanel.Size = new System.Drawing.Size(50, 50);
			this.ImagePanel.TabIndex = 15;
			this.ImagePanel.Visible = false;
			// 
			// UploadImageButton
			// 
			this.UploadImageButton.BackColor = System.Drawing.Color.Black;
			this.UploadImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.UploadImageButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.UploadImageButton.ForeColor = System.Drawing.Color.Coral;
			this.UploadImageButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.UploadImageButton.Location = new System.Drawing.Point(1297, 403);
			this.UploadImageButton.Name = "UploadImageButton";
			this.UploadImageButton.Size = new System.Drawing.Size(149, 45);
			this.UploadImageButton.TabIndex = 16;
			this.UploadImageButton.Text = "Upload Image";
			this.UploadImageButton.UseMnemonic = false;
			this.UploadImageButton.UseVisualStyleBackColor = false;
			this.UploadImageButton.Visible = false;
			this.UploadImageButton.Click += new System.EventHandler(this.Click_UploadImageButton);
			// 
			// MyProjectsButton
			// 
			this.MyProjectsButton.BackColor = System.Drawing.Color.Black;
			this.MyProjectsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.MyProjectsButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.MyProjectsButton.ForeColor = System.Drawing.Color.Coral;
			this.MyProjectsButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.MyProjectsButton.Location = new System.Drawing.Point(1103, 116);
			this.MyProjectsButton.Name = "MyProjectsButton";
			this.MyProjectsButton.Size = new System.Drawing.Size(178, 45);
			this.MyProjectsButton.TabIndex = 19;
			this.MyProjectsButton.Text = "Show My Projects";
			this.MyProjectsButton.UseMnemonic = false;
			this.MyProjectsButton.UseVisualStyleBackColor = false;
			this.MyProjectsButton.Visible = false;
			this.MyProjectsButton.Click += new System.EventHandler(this.Click_MyProjectsButton);
			// 
			// MyBugsButton
			// 
			this.MyBugsButton.BackColor = System.Drawing.Color.Black;
			this.MyBugsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.MyBugsButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.MyBugsButton.ForeColor = System.Drawing.Color.Coral;
			this.MyBugsButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.MyBugsButton.Location = new System.Drawing.Point(1103, 164);
			this.MyBugsButton.Name = "MyBugsButton";
			this.MyBugsButton.Size = new System.Drawing.Size(178, 45);
			this.MyBugsButton.TabIndex = 20;
			this.MyBugsButton.Text = "Show My Bugs";
			this.MyBugsButton.UseMnemonic = false;
			this.MyBugsButton.UseVisualStyleBackColor = false;
			this.MyBugsButton.Visible = false;
			this.MyBugsButton.Click += new System.EventHandler(this.Click_MyBugsButton);
			// 
			// ResultsBox
			// 
			this.ResultsBox.Alignment = System.Windows.Forms.ListViewAlignment.Left;
			this.ResultsBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.ResultsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ResultsBox.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ResultsBox.HideSelection = false;
			this.ResultsBox.Location = new System.Drawing.Point(1287, 116);
			this.ResultsBox.Name = "ResultsBox";
			this.ResultsBox.Size = new System.Drawing.Size(38, 50);
			this.ResultsBox.TabIndex = 21;
			this.ResultsBox.UseCompatibleStateImageBehavior = false;
			this.ResultsBox.View = System.Windows.Forms.View.List;
			this.ResultsBox.Visible = false;
			this.ResultsBox.SelectedIndexChanged += new System.EventHandler(this.ResultsBox_SelectedIndexChanged);
			// 
			// CoralLabel1
			// 
			this.CoralLabel1.AutoSize = true;
			this.CoralLabel1.BackColor = System.Drawing.Color.Black;
			this.CoralLabel1.Font = new System.Drawing.Font("Microsoft YaHei", 27.75F, System.Drawing.FontStyle.Bold);
			this.CoralLabel1.ForeColor = System.Drawing.Color.Coral;
			this.CoralLabel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.CoralLabel1.Location = new System.Drawing.Point(544, 120);
			this.CoralLabel1.Name = "CoralLabel1";
			this.CoralLabel1.Size = new System.Drawing.Size(45, 50);
			this.CoralLabel1.TabIndex = 22;
			this.CoralLabel1.Text = "1";
			this.CoralLabel1.Visible = false;
			// 
			// CoralLabel2
			// 
			this.CoralLabel2.AutoSize = true;
			this.CoralLabel2.BackColor = System.Drawing.Color.Black;
			this.CoralLabel2.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F);
			this.CoralLabel2.ForeColor = System.Drawing.Color.Coral;
			this.CoralLabel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.CoralLabel2.Location = new System.Drawing.Point(504, 116);
			this.CoralLabel2.Name = "CoralLabel2";
			this.CoralLabel2.Size = new System.Drawing.Size(34, 38);
			this.CoralLabel2.TabIndex = 23;
			this.CoralLabel2.Text = "2";
			this.CoralLabel2.Visible = false;
			// 
			// LogOutButton
			// 
			this.LogOutButton.BackColor = System.Drawing.Color.Black;
			this.LogOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.LogOutButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.LogOutButton.ForeColor = System.Drawing.Color.Coral;
			this.LogOutButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.LogOutButton.Location = new System.Drawing.Point(919, 116);
			this.LogOutButton.Name = "LogOutButton";
			this.LogOutButton.Size = new System.Drawing.Size(178, 45);
			this.LogOutButton.TabIndex = 24;
			this.LogOutButton.Text = "Log Out";
			this.LogOutButton.UseMnemonic = false;
			this.LogOutButton.UseVisualStyleBackColor = false;
			this.LogOutButton.Visible = false;
			this.LogOutButton.Click += new System.EventHandler(this.Click_LogOutButton);
			// 
			// ChangePasswordButton
			// 
			this.ChangePasswordButton.BackColor = System.Drawing.Color.Black;
			this.ChangePasswordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ChangePasswordButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.ChangePasswordButton.ForeColor = System.Drawing.Color.Coral;
			this.ChangePasswordButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.ChangePasswordButton.Location = new System.Drawing.Point(919, 164);
			this.ChangePasswordButton.Name = "ChangePasswordButton";
			this.ChangePasswordButton.Size = new System.Drawing.Size(178, 45);
			this.ChangePasswordButton.TabIndex = 25;
			this.ChangePasswordButton.Text = "Change Password";
			this.ChangePasswordButton.UseMnemonic = false;
			this.ChangePasswordButton.UseVisualStyleBackColor = false;
			this.ChangePasswordButton.Visible = false;
			this.ChangePasswordButton.Click += new System.EventHandler(this.Click_ChangePasswordButton);
			// 
			// SubmitBugButton
			// 
			this.SubmitBugButton.BackColor = System.Drawing.Color.Black;
			this.SubmitBugButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SubmitBugButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.SubmitBugButton.ForeColor = System.Drawing.Color.Coral;
			this.SubmitBugButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.SubmitBugButton.Location = new System.Drawing.Point(827, 215);
			this.SubmitBugButton.Name = "SubmitBugButton";
			this.SubmitBugButton.Size = new System.Drawing.Size(248, 45);
			this.SubmitBugButton.TabIndex = 26;
			this.SubmitBugButton.TabStop = false;
			this.SubmitBugButton.Text = "Submit Bug for Resolution";
			this.SubmitBugButton.UseMnemonic = false;
			this.SubmitBugButton.UseVisualStyleBackColor = false;
			this.SubmitBugButton.Visible = false;
			this.SubmitBugButton.Click += new System.EventHandler(this.Click_SubmitBugButton);
			// 
			// ResultsBox2
			// 
			this.ResultsBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.ResultsBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ResultsBox2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ResultsBox2.HideSelection = false;
			this.ResultsBox2.Location = new System.Drawing.Point(875, 116);
			this.ResultsBox2.Name = "ResultsBox2";
			this.ResultsBox2.Size = new System.Drawing.Size(38, 50);
			this.ResultsBox2.TabIndex = 27;
			this.ResultsBox2.UseCompatibleStateImageBehavior = false;
			this.ResultsBox2.View = System.Windows.Forms.View.List;
			this.ResultsBox2.Visible = false;
			// 
			// TitleLabel
			// 
			this.TitleLabel.AutoSize = true;
			this.TitleLabel.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold);
			this.TitleLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.TitleLabel.Location = new System.Drawing.Point(101, 149);
			this.TitleLabel.Name = "TitleLabel";
			this.TitleLabel.Size = new System.Drawing.Size(374, 26);
			this.TitleLabel.TabIndex = 28;
			this.TitleLabel.Text = "Please log in to access the bugs panel";
			this.TitleLabel.Visible = false;
			// 
			// BackdropPanel2
			// 
			this.BackdropPanel2.BackColor = System.Drawing.Color.Black;
			this.BackdropPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.BackdropPanel2.Location = new System.Drawing.Point(1331, 172);
			this.BackdropPanel2.Name = "BackdropPanel2";
			this.BackdropPanel2.Size = new System.Drawing.Size(50, 43);
			this.BackdropPanel2.TabIndex = 12;
			this.BackdropPanel2.Visible = false;
			// 
			// UpdateBugButton
			// 
			this.UpdateBugButton.BackColor = System.Drawing.Color.Black;
			this.UpdateBugButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.UpdateBugButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.UpdateBugButton.ForeColor = System.Drawing.Color.Coral;
			this.UpdateBugButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.UpdateBugButton.Location = new System.Drawing.Point(849, 266);
			this.UpdateBugButton.Name = "UpdateBugButton";
			this.UpdateBugButton.Size = new System.Drawing.Size(189, 45);
			this.UpdateBugButton.TabIndex = 29;
			this.UpdateBugButton.TabStop = false;
			this.UpdateBugButton.Text = "Add Update to Bug";
			this.UpdateBugButton.UseMnemonic = false;
			this.UpdateBugButton.UseVisualStyleBackColor = false;
			this.UpdateBugButton.Visible = false;
			this.UpdateBugButton.Click += new System.EventHandler(this.Click_UpdateBugButton);
			// 
			// ViewUpdatesButton
			// 
			this.ViewUpdatesButton.BackColor = System.Drawing.Color.Black;
			this.ViewUpdatesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ViewUpdatesButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.ViewUpdatesButton.ForeColor = System.Drawing.Color.Coral;
			this.ViewUpdatesButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.ViewUpdatesButton.Location = new System.Drawing.Point(1081, 215);
			this.ViewUpdatesButton.Name = "ViewUpdatesButton";
			this.ViewUpdatesButton.Size = new System.Drawing.Size(153, 45);
			this.ViewUpdatesButton.TabIndex = 30;
			this.ViewUpdatesButton.TabStop = false;
			this.ViewUpdatesButton.Text = "View Updates";
			this.ViewUpdatesButton.UseMnemonic = false;
			this.ViewUpdatesButton.UseVisualStyleBackColor = false;
			this.ViewUpdatesButton.Visible = false;
			this.ViewUpdatesButton.Click += new System.EventHandler(this.Click_ViewUpdatesButton);
			// 
			// GeneralTextbox
			// 
			this.GeneralTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.GeneralTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.GeneralTextbox.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F);
			this.GeneralTextbox.Location = new System.Drawing.Point(164, 360);
			this.GeneralTextbox.Name = "GeneralTextbox";
			this.GeneralTextbox.Size = new System.Drawing.Size(325, 26);
			this.GeneralTextbox.TabIndex = 31;
			this.GeneralTextbox.Visible = false;
			this.GeneralTextbox.TextChanged += new System.EventHandler(this.GeneralTextbox_TextChanged);
			// 
			// BackButton
			// 
			this.BackButton.BackColor = System.Drawing.Color.Black;
			this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BackButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.BackButton.ForeColor = System.Drawing.Color.Coral;
			this.BackButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.BackButton.Location = new System.Drawing.Point(1044, 266);
			this.BackButton.Name = "BackButton";
			this.BackButton.Size = new System.Drawing.Size(103, 45);
			this.BackButton.TabIndex = 33;
			this.BackButton.Text = "Back";
			this.BackButton.UseMnemonic = false;
			this.BackButton.UseVisualStyleBackColor = false;
			this.BackButton.Visible = false;
			this.BackButton.Click += new System.EventHandler(this.Click_BackButton);
			// 
			// ProjectOverviewButton
			// 
			this.ProjectOverviewButton.BackColor = System.Drawing.Color.Black;
			this.ProjectOverviewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ProjectOverviewButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.ProjectOverviewButton.ForeColor = System.Drawing.Color.Coral;
			this.ProjectOverviewButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.ProjectOverviewButton.Location = new System.Drawing.Point(859, 350);
			this.ProjectOverviewButton.Name = "ProjectOverviewButton";
			this.ProjectOverviewButton.Size = new System.Drawing.Size(162, 45);
			this.ProjectOverviewButton.TabIndex = 34;
			this.ProjectOverviewButton.Text = "Project Overview";
			this.ProjectOverviewButton.UseMnemonic = false;
			this.ProjectOverviewButton.UseVisualStyleBackColor = false;
			this.ProjectOverviewButton.Visible = false;
			this.ProjectOverviewButton.Click += new System.EventHandler(this.Click_ProjectOverviewButton);
			// 
			// ViewProjectUpdatesButton
			// 
			this.ViewProjectUpdatesButton.BackColor = System.Drawing.Color.Black;
			this.ViewProjectUpdatesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ViewProjectUpdatesButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.ViewProjectUpdatesButton.ForeColor = System.Drawing.Color.Coral;
			this.ViewProjectUpdatesButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.ViewProjectUpdatesButton.Location = new System.Drawing.Point(859, 403);
			this.ViewProjectUpdatesButton.Name = "ViewProjectUpdatesButton";
			this.ViewProjectUpdatesButton.Size = new System.Drawing.Size(162, 45);
			this.ViewProjectUpdatesButton.TabIndex = 35;
			this.ViewProjectUpdatesButton.Text = "View Updates";
			this.ViewProjectUpdatesButton.UseMnemonic = false;
			this.ViewProjectUpdatesButton.UseVisualStyleBackColor = false;
			this.ViewProjectUpdatesButton.Visible = false;
			this.ViewProjectUpdatesButton.Click += new System.EventHandler(this.Click_ViewProjectUpdatesButton);
			// 
			// AddProjectUpdateButton
			// 
			this.AddProjectUpdateButton.BackColor = System.Drawing.Color.Black;
			this.AddProjectUpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AddProjectUpdateButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.AddProjectUpdateButton.ForeColor = System.Drawing.Color.Coral;
			this.AddProjectUpdateButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.AddProjectUpdateButton.Location = new System.Drawing.Point(859, 454);
			this.AddProjectUpdateButton.Name = "AddProjectUpdateButton";
			this.AddProjectUpdateButton.Size = new System.Drawing.Size(162, 45);
			this.AddProjectUpdateButton.TabIndex = 36;
			this.AddProjectUpdateButton.Text = "Add Update";
			this.AddProjectUpdateButton.UseMnemonic = false;
			this.AddProjectUpdateButton.UseVisualStyleBackColor = false;
			this.AddProjectUpdateButton.Visible = false;
			this.AddProjectUpdateButton.Click += new System.EventHandler(this.Click_AddProjectUpdateButton);
			// 
			// CoralLabel3
			// 
			this.CoralLabel3.AutoSize = true;
			this.CoralLabel3.BackColor = System.Drawing.Color.Black;
			this.CoralLabel3.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F);
			this.CoralLabel3.ForeColor = System.Drawing.Color.Coral;
			this.CoralLabel3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.CoralLabel3.Location = new System.Drawing.Point(504, 162);
			this.CoralLabel3.Name = "CoralLabel3";
			this.CoralLabel3.Size = new System.Drawing.Size(34, 38);
			this.CoralLabel3.TabIndex = 37;
			this.CoralLabel3.Text = "3";
			this.CoralLabel3.Visible = false;
			// 
			// TextBox
			// 
			this.TextBox.BackColor = System.Drawing.Color.Black;
			this.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TextBox.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextBox.ForeColor = System.Drawing.Color.Coral;
			this.TextBox.Location = new System.Drawing.Point(813, 116);
			this.TextBox.Name = "TextBox";
			this.TextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.TextBox.Size = new System.Drawing.Size(56, 50);
			this.TextBox.TabIndex = 38;
			this.TextBox.Text = "Test";
			this.TextBox.Visible = false;
			// 
			// ConfirmProjectUpdateButton
			// 
			this.ConfirmProjectUpdateButton.BackColor = System.Drawing.Color.Black;
			this.ConfirmProjectUpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ConfirmProjectUpdateButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.ConfirmProjectUpdateButton.ForeColor = System.Drawing.Color.Coral;
			this.ConfirmProjectUpdateButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.ConfirmProjectUpdateButton.Location = new System.Drawing.Point(1027, 350);
			this.ConfirmProjectUpdateButton.Name = "ConfirmProjectUpdateButton";
			this.ConfirmProjectUpdateButton.Size = new System.Drawing.Size(121, 45);
			this.ConfirmProjectUpdateButton.TabIndex = 39;
			this.ConfirmProjectUpdateButton.Text = "Confirm";
			this.ConfirmProjectUpdateButton.UseMnemonic = false;
			this.ConfirmProjectUpdateButton.UseVisualStyleBackColor = false;
			this.ConfirmProjectUpdateButton.Visible = false;
			this.ConfirmProjectUpdateButton.Click += new System.EventHandler(this.Click_ConfirmProjectUpdateButton);
			// 
			// ReportBugButton
			// 
			this.ReportBugButton.BackColor = System.Drawing.Color.Black;
			this.ReportBugButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ReportBugButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.ReportBugButton.ForeColor = System.Drawing.Color.Coral;
			this.ReportBugButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.ReportBugButton.Location = new System.Drawing.Point(859, 506);
			this.ReportBugButton.Name = "ReportBugButton";
			this.ReportBugButton.Size = new System.Drawing.Size(162, 45);
			this.ReportBugButton.TabIndex = 40;
			this.ReportBugButton.Text = "Report New Bug";
			this.ReportBugButton.UseMnemonic = false;
			this.ReportBugButton.UseVisualStyleBackColor = false;
			this.ReportBugButton.Visible = false;
			this.ReportBugButton.Click += new System.EventHandler(this.Click_ReportBugButton);
			// 
			// CoralLabel4
			// 
			this.CoralLabel4.AutoSize = true;
			this.CoralLabel4.BackColor = System.Drawing.Color.Black;
			this.CoralLabel4.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F);
			this.CoralLabel4.ForeColor = System.Drawing.Color.Coral;
			this.CoralLabel4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.CoralLabel4.Location = new System.Drawing.Point(595, 116);
			this.CoralLabel4.Name = "CoralLabel4";
			this.CoralLabel4.Size = new System.Drawing.Size(34, 38);
			this.CoralLabel4.TabIndex = 41;
			this.CoralLabel4.Text = "4";
			this.CoralLabel4.Visible = false;
			// 
			// EditAccountRoleButton
			// 
			this.EditAccountRoleButton.BackColor = System.Drawing.Color.Black;
			this.EditAccountRoleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.EditAccountRoleButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.EditAccountRoleButton.ForeColor = System.Drawing.Color.Coral;
			this.EditAccountRoleButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.EditAccountRoleButton.Location = new System.Drawing.Point(108, 202);
			this.EditAccountRoleButton.Name = "EditAccountRoleButton";
			this.EditAccountRoleButton.Size = new System.Drawing.Size(189, 45);
			this.EditAccountRoleButton.TabIndex = 42;
			this.EditAccountRoleButton.TabStop = false;
			this.EditAccountRoleButton.Text = "Edit Account Role";
			this.EditAccountRoleButton.UseMnemonic = false;
			this.EditAccountRoleButton.UseVisualStyleBackColor = false;
			this.EditAccountRoleButton.Visible = false;
			this.EditAccountRoleButton.Click += new System.EventHandler(this.Click_EditAccountRoleButton);
			// 
			// DeleteAccountButton
			// 
			this.DeleteAccountButton.BackColor = System.Drawing.Color.Black;
			this.DeleteAccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.DeleteAccountButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.DeleteAccountButton.ForeColor = System.Drawing.Color.Coral;
			this.DeleteAccountButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.DeleteAccountButton.Location = new System.Drawing.Point(108, 253);
			this.DeleteAccountButton.Name = "DeleteAccountButton";
			this.DeleteAccountButton.Size = new System.Drawing.Size(189, 45);
			this.DeleteAccountButton.TabIndex = 43;
			this.DeleteAccountButton.TabStop = false;
			this.DeleteAccountButton.Text = "Delete Account";
			this.DeleteAccountButton.UseMnemonic = false;
			this.DeleteAccountButton.UseVisualStyleBackColor = false;
			this.DeleteAccountButton.Visible = false;
			this.DeleteAccountButton.Click += new System.EventHandler(this.Click_DeleteAccountButton);
			// 
			// AdministratorButton
			// 
			this.AdministratorButton.BackColor = System.Drawing.Color.Black;
			this.AdministratorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AdministratorButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.AdministratorButton.ForeColor = System.Drawing.Color.Coral;
			this.AdministratorButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.AdministratorButton.Location = new System.Drawing.Point(309, 202);
			this.AdministratorButton.Name = "AdministratorButton";
			this.AdministratorButton.Size = new System.Drawing.Size(180, 45);
			this.AdministratorButton.TabIndex = 44;
			this.AdministratorButton.TabStop = false;
			this.AdministratorButton.Text = "Administrator";
			this.AdministratorButton.UseMnemonic = false;
			this.AdministratorButton.UseVisualStyleBackColor = false;
			this.AdministratorButton.Visible = false;
			this.AdministratorButton.Click += new System.EventHandler(this.Click_AdministratorButton);
			// 
			// EngineerButton
			// 
			this.EngineerButton.BackColor = System.Drawing.Color.Black;
			this.EngineerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.EngineerButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.EngineerButton.ForeColor = System.Drawing.Color.Coral;
			this.EngineerButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.EngineerButton.Location = new System.Drawing.Point(309, 253);
			this.EngineerButton.Name = "EngineerButton";
			this.EngineerButton.Size = new System.Drawing.Size(180, 45);
			this.EngineerButton.TabIndex = 45;
			this.EngineerButton.TabStop = false;
			this.EngineerButton.Text = "Engineer";
			this.EngineerButton.UseMnemonic = false;
			this.EngineerButton.UseVisualStyleBackColor = false;
			this.EngineerButton.Visible = false;
			this.EngineerButton.Click += new System.EventHandler(this.Click_EngineerButton);
			// 
			// GuestButton
			// 
			this.GuestButton.BackColor = System.Drawing.Color.Black;
			this.GuestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.GuestButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.GuestButton.ForeColor = System.Drawing.Color.Coral;
			this.GuestButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.GuestButton.Location = new System.Drawing.Point(309, 304);
			this.GuestButton.Name = "GuestButton";
			this.GuestButton.Size = new System.Drawing.Size(180, 45);
			this.GuestButton.TabIndex = 46;
			this.GuestButton.TabStop = false;
			this.GuestButton.Text = "Guest";
			this.GuestButton.UseMnemonic = false;
			this.GuestButton.UseVisualStyleBackColor = false;
			this.GuestButton.Visible = false;
			this.GuestButton.Click += new System.EventHandler(this.Click_GuestButton);
			// 
			// CreateProjectButton
			// 
			this.CreateProjectButton.BackColor = System.Drawing.Color.Black;
			this.CreateProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CreateProjectButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.CreateProjectButton.ForeColor = System.Drawing.Color.Coral;
			this.CreateProjectButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.CreateProjectButton.Location = new System.Drawing.Point(495, 202);
			this.CreateProjectButton.Name = "CreateProjectButton";
			this.CreateProjectButton.Size = new System.Drawing.Size(189, 45);
			this.CreateProjectButton.TabIndex = 47;
			this.CreateProjectButton.TabStop = false;
			this.CreateProjectButton.Text = "Create New Project";
			this.CreateProjectButton.UseMnemonic = false;
			this.CreateProjectButton.UseVisualStyleBackColor = false;
			this.CreateProjectButton.Visible = false;
			this.CreateProjectButton.Click += new System.EventHandler(this.Click_CreateProjectButton);
			// 
			// AssignAccountToProjectButton
			// 
			this.AssignAccountToProjectButton.BackColor = System.Drawing.Color.Black;
			this.AssignAccountToProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AssignAccountToProjectButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.AssignAccountToProjectButton.ForeColor = System.Drawing.Color.Coral;
			this.AssignAccountToProjectButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.AssignAccountToProjectButton.Location = new System.Drawing.Point(495, 304);
			this.AssignAccountToProjectButton.Name = "AssignAccountToProjectButton";
			this.AssignAccountToProjectButton.Size = new System.Drawing.Size(189, 60);
			this.AssignAccountToProjectButton.TabIndex = 48;
			this.AssignAccountToProjectButton.TabStop = false;
			this.AssignAccountToProjectButton.Text = "Assign Account To Project";
			this.AssignAccountToProjectButton.UseMnemonic = false;
			this.AssignAccountToProjectButton.UseVisualStyleBackColor = false;
			this.AssignAccountToProjectButton.Visible = false;
			this.AssignAccountToProjectButton.Click += new System.EventHandler(this.Click_AssignAccountToProjectButton);
			// 
			// RemoveAccountFromProjectButton
			// 
			this.RemoveAccountFromProjectButton.BackColor = System.Drawing.Color.Black;
			this.RemoveAccountFromProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.RemoveAccountFromProjectButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.RemoveAccountFromProjectButton.ForeColor = System.Drawing.Color.Coral;
			this.RemoveAccountFromProjectButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.RemoveAccountFromProjectButton.Location = new System.Drawing.Point(495, 377);
			this.RemoveAccountFromProjectButton.Name = "RemoveAccountFromProjectButton";
			this.RemoveAccountFromProjectButton.Size = new System.Drawing.Size(189, 60);
			this.RemoveAccountFromProjectButton.TabIndex = 49;
			this.RemoveAccountFromProjectButton.TabStop = false;
			this.RemoveAccountFromProjectButton.Text = "Remove Account From Project";
			this.RemoveAccountFromProjectButton.UseMnemonic = false;
			this.RemoveAccountFromProjectButton.UseVisualStyleBackColor = false;
			this.RemoveAccountFromProjectButton.Visible = false;
			this.RemoveAccountFromProjectButton.Click += new System.EventHandler(this.Click_RemoveAccountFromProjectButton);
			// 
			// RetireProjectButton
			// 
			this.RetireProjectButton.BackColor = System.Drawing.Color.Black;
			this.RetireProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.RetireProjectButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.RetireProjectButton.ForeColor = System.Drawing.Color.Coral;
			this.RetireProjectButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.RetireProjectButton.Location = new System.Drawing.Point(495, 253);
			this.RetireProjectButton.Name = "RetireProjectButton";
			this.RetireProjectButton.Size = new System.Drawing.Size(189, 45);
			this.RetireProjectButton.TabIndex = 50;
			this.RetireProjectButton.TabStop = false;
			this.RetireProjectButton.Text = "Retire Project";
			this.RetireProjectButton.UseMnemonic = false;
			this.RetireProjectButton.UseVisualStyleBackColor = false;
			this.RetireProjectButton.Visible = false;
			this.RetireProjectButton.Click += new System.EventHandler(this.Click_RetireProjectButton);
			// 
			// GeneralTextBox2
			// 
			this.GeneralTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.GeneralTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.GeneralTextBox2.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F);
			this.GeneralTextBox2.Location = new System.Drawing.Point(164, 396);
			this.GeneralTextBox2.Name = "GeneralTextBox2";
			this.GeneralTextBox2.Size = new System.Drawing.Size(325, 26);
			this.GeneralTextBox2.TabIndex = 51;
			this.GeneralTextBox2.Visible = false;
			// 
			// GeneralTextBox3
			// 
			this.GeneralTextBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.GeneralTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.GeneralTextBox3.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F);
			this.GeneralTextBox3.Location = new System.Drawing.Point(164, 432);
			this.GeneralTextBox3.Name = "GeneralTextBox3";
			this.GeneralTextBox3.Size = new System.Drawing.Size(325, 26);
			this.GeneralTextBox3.TabIndex = 53;
			this.GeneralTextBox3.Visible = false;
			// 
			// GeneralTextBox4
			// 
			this.GeneralTextBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.GeneralTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.GeneralTextBox4.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F);
			this.GeneralTextBox4.Location = new System.Drawing.Point(164, 466);
			this.GeneralTextBox4.Name = "GeneralTextBox4";
			this.GeneralTextBox4.Size = new System.Drawing.Size(325, 26);
			this.GeneralTextBox4.TabIndex = 55;
			this.GeneralTextBox4.Visible = false;
			// 
			// GeneralTextBox5
			// 
			this.GeneralTextBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.GeneralTextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.GeneralTextBox5.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F);
			this.GeneralTextBox5.Location = new System.Drawing.Point(164, 501);
			this.GeneralTextBox5.Name = "GeneralTextBox5";
			this.GeneralTextBox5.Size = new System.Drawing.Size(325, 26);
			this.GeneralTextBox5.TabIndex = 56;
			this.GeneralTextBox5.Visible = false;
			// 
			// CoralLabel5
			// 
			this.CoralLabel5.AutoSize = true;
			this.CoralLabel5.BackColor = System.Drawing.Color.Black;
			this.CoralLabel5.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F);
			this.CoralLabel5.ForeColor = System.Drawing.Color.Coral;
			this.CoralLabel5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.CoralLabel5.Location = new System.Drawing.Point(595, 162);
			this.CoralLabel5.Name = "CoralLabel5";
			this.CoralLabel5.Size = new System.Drawing.Size(34, 38);
			this.CoralLabel5.TabIndex = 57;
			this.CoralLabel5.Text = "5";
			this.CoralLabel5.Visible = false;
			// 
			// ConfirmSignUpButton
			// 
			this.ConfirmSignUpButton.BackColor = System.Drawing.Color.Black;
			this.ConfirmSignUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ConfirmSignUpButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.ConfirmSignUpButton.ForeColor = System.Drawing.Color.Coral;
			this.ConfirmSignUpButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.ConfirmSignUpButton.Location = new System.Drawing.Point(1325, 352);
			this.ConfirmSignUpButton.Name = "ConfirmSignUpButton";
			this.ConfirmSignUpButton.Size = new System.Drawing.Size(121, 45);
			this.ConfirmSignUpButton.TabIndex = 12;
			this.ConfirmSignUpButton.Text = "Confirm";
			this.ConfirmSignUpButton.UseMnemonic = false;
			this.ConfirmSignUpButton.UseVisualStyleBackColor = false;
			this.ConfirmSignUpButton.Visible = false;
			this.ConfirmSignUpButton.Click += new System.EventHandler(this.Click_ConfirmSignUpButton);
			// 
			// CoralLabel6
			// 
			this.CoralLabel6.AutoSize = true;
			this.CoralLabel6.BackColor = System.Drawing.Color.Black;
			this.CoralLabel6.Font = new System.Drawing.Font("Microsoft YaHei", 21.75F);
			this.CoralLabel6.ForeColor = System.Drawing.Color.Coral;
			this.CoralLabel6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.CoralLabel6.Location = new System.Drawing.Point(800, 465);
			this.CoralLabel6.Name = "CoralLabel6";
			this.CoralLabel6.Size = new System.Drawing.Size(34, 38);
			this.CoralLabel6.TabIndex = 58;
			this.CoralLabel6.Text = "6";
			this.CoralLabel6.Visible = false;
			// 
			// CoralLabel7
			// 
			this.CoralLabel7.AutoSize = true;
			this.CoralLabel7.BackColor = System.Drawing.Color.Black;
			this.CoralLabel7.Font = new System.Drawing.Font("Microsoft YaHei", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CoralLabel7.ForeColor = System.Drawing.Color.Coral;
			this.CoralLabel7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.CoralLabel7.Location = new System.Drawing.Point(738, 311);
			this.CoralLabel7.Name = "CoralLabel7";
			this.CoralLabel7.Size = new System.Drawing.Size(20, 24);
			this.CoralLabel7.TabIndex = 59;
			this.CoralLabel7.Text = "7";
			this.CoralLabel7.Visible = false;
			// 
			// ViewSubmittedBugsButton
			// 
			this.ViewSubmittedBugsButton.BackColor = System.Drawing.Color.Black;
			this.ViewSubmittedBugsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ViewSubmittedBugsButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.ViewSubmittedBugsButton.ForeColor = System.Drawing.Color.Coral;
			this.ViewSubmittedBugsButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.ViewSubmittedBugsButton.Location = new System.Drawing.Point(495, 454);
			this.ViewSubmittedBugsButton.Name = "ViewSubmittedBugsButton";
			this.ViewSubmittedBugsButton.Size = new System.Drawing.Size(189, 66);
			this.ViewSubmittedBugsButton.TabIndex = 60;
			this.ViewSubmittedBugsButton.TabStop = false;
			this.ViewSubmittedBugsButton.Text = "View Submitted Bugs";
			this.ViewSubmittedBugsButton.UseMnemonic = false;
			this.ViewSubmittedBugsButton.UseVisualStyleBackColor = false;
			this.ViewSubmittedBugsButton.Visible = false;
			this.ViewSubmittedBugsButton.Click += new System.EventHandler(this.Click_ViewSubmittedBugsButton);
			// 
			// ViewUnassignedBugsButton
			// 
			this.ViewUnassignedBugsButton.BackColor = System.Drawing.Color.Black;
			this.ViewUnassignedBugsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ViewUnassignedBugsButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.ViewUnassignedBugsButton.ForeColor = System.Drawing.Color.Coral;
			this.ViewUnassignedBugsButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.ViewUnassignedBugsButton.Location = new System.Drawing.Point(495, 526);
			this.ViewUnassignedBugsButton.Name = "ViewUnassignedBugsButton";
			this.ViewUnassignedBugsButton.Size = new System.Drawing.Size(189, 66);
			this.ViewUnassignedBugsButton.TabIndex = 61;
			this.ViewUnassignedBugsButton.TabStop = false;
			this.ViewUnassignedBugsButton.Text = "View Unassigned Bugs";
			this.ViewUnassignedBugsButton.UseMnemonic = false;
			this.ViewUnassignedBugsButton.UseVisualStyleBackColor = false;
			this.ViewUnassignedBugsButton.Visible = false;
			this.ViewUnassignedBugsButton.Click += new System.EventHandler(this.Click_ViewUnassignedBugsButton);
			// 
			// ResolveBugButton
			// 
			this.ResolveBugButton.BackColor = System.Drawing.Color.Black;
			this.ResolveBugButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ResolveBugButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.ResolveBugButton.ForeColor = System.Drawing.Color.Coral;
			this.ResolveBugButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.ResolveBugButton.Location = new System.Drawing.Point(495, 598);
			this.ResolveBugButton.Name = "ResolveBugButton";
			this.ResolveBugButton.Size = new System.Drawing.Size(189, 45);
			this.ResolveBugButton.TabIndex = 62;
			this.ResolveBugButton.TabStop = false;
			this.ResolveBugButton.Text = "Resolve Bug";
			this.ResolveBugButton.UseMnemonic = false;
			this.ResolveBugButton.UseVisualStyleBackColor = false;
			this.ResolveBugButton.Visible = false;
			this.ResolveBugButton.Click += new System.EventHandler(this.Click_ResolveBugButton);
			// 
			// AssignBugButton
			// 
			this.AssignBugButton.BackColor = System.Drawing.Color.Black;
			this.AssignBugButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AssignBugButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.AssignBugButton.ForeColor = System.Drawing.Color.Coral;
			this.AssignBugButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.AssignBugButton.Location = new System.Drawing.Point(495, 649);
			this.AssignBugButton.Name = "AssignBugButton";
			this.AssignBugButton.Size = new System.Drawing.Size(189, 45);
			this.AssignBugButton.TabIndex = 63;
			this.AssignBugButton.TabStop = false;
			this.AssignBugButton.Text = "Assign Bug";
			this.AssignBugButton.UseMnemonic = false;
			this.AssignBugButton.UseVisualStyleBackColor = false;
			this.AssignBugButton.Visible = false;
			this.AssignBugButton.Click += new System.EventHandler(this.Click_AssignBugButton);
			// 
			// RejectBugButton
			// 
			this.RejectBugButton.BackColor = System.Drawing.Color.Black;
			this.RejectBugButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.RejectBugButton.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold);
			this.RejectBugButton.ForeColor = System.Drawing.Color.Coral;
			this.RejectBugButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.RejectBugButton.Location = new System.Drawing.Point(690, 598);
			this.RejectBugButton.Name = "RejectBugButton";
			this.RejectBugButton.Size = new System.Drawing.Size(189, 45);
			this.RejectBugButton.TabIndex = 64;
			this.RejectBugButton.TabStop = false;
			this.RejectBugButton.Text = "Reject Bug";
			this.RejectBugButton.UseMnemonic = false;
			this.RejectBugButton.UseVisualStyleBackColor = false;
			this.RejectBugButton.Visible = false;
			this.RejectBugButton.Click += new System.EventHandler(this.Click_RejectBugButton);
			// 
			// AdminBugsButton
			// 
			this.AdminBugsButton.BackColor = System.Drawing.Color.Coral;
			this.AdminBugsButton.BackgroundImage = global::BugTracker.Properties.Resources.Bugs;
			this.AdminBugsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.AdminBugsButton.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.AdminBugsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AdminBugsButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AdminBugsButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.AdminBugsButton.Location = new System.Drawing.Point(1180, 403);
			this.AdminBugsButton.Name = "AdminBugsButton";
			this.AdminBugsButton.Size = new System.Drawing.Size(70, 70);
			this.AdminBugsButton.TabIndex = 6;
			this.AdminBugsButton.UseVisualStyleBackColor = false;
			this.AdminBugsButton.Visible = false;
			this.AdminBugsButton.Click += new System.EventHandler(this.Click_AdminBugsTab);
			// 
			// AdminProjectsButton
			// 
			this.AdminProjectsButton.BackColor = System.Drawing.Color.Coral;
			this.AdminProjectsButton.BackgroundImage = global::BugTracker.Properties.Resources.Projects;
			this.AdminProjectsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.AdminProjectsButton.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.AdminProjectsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AdminProjectsButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AdminProjectsButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.AdminProjectsButton.Location = new System.Drawing.Point(1104, 403);
			this.AdminProjectsButton.Name = "AdminProjectsButton";
			this.AdminProjectsButton.Size = new System.Drawing.Size(70, 70);
			this.AdminProjectsButton.TabIndex = 6;
			this.AdminProjectsButton.UseVisualStyleBackColor = false;
			this.AdminProjectsButton.Visible = false;
			this.AdminProjectsButton.Click += new System.EventHandler(this.Click_AdminProjectsTab);
			// 
			// AdminAccountsButton
			// 
			this.AdminAccountsButton.BackColor = System.Drawing.Color.Coral;
			this.AdminAccountsButton.BackgroundImage = global::BugTracker.Properties.Resources.Profiles;
			this.AdminAccountsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.AdminAccountsButton.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.AdminAccountsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AdminAccountsButton.ForeColor = System.Drawing.Color.Black;
			this.AdminAccountsButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.AdminAccountsButton.Location = new System.Drawing.Point(1028, 403);
			this.AdminAccountsButton.Name = "AdminAccountsButton";
			this.AdminAccountsButton.Size = new System.Drawing.Size(70, 70);
			this.AdminAccountsButton.TabIndex = 6;
			this.AdminAccountsButton.UseVisualStyleBackColor = false;
			this.AdminAccountsButton.Visible = false;
			this.AdminAccountsButton.Click += new System.EventHandler(this.Click_AdminAccountsTab);
			// 
			// ExitButton
			// 
			this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ExitButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.ExitButton.BackgroundImage = global::BugTracker.Properties.Resources.Exit;
			this.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ExitButton.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ExitButton.ForeColor = System.Drawing.SystemColors.AppWorkspace;
			this.ExitButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.ExitButton.Location = new System.Drawing.Point(1706, 0);
			this.ExitButton.Name = "ExitButton";
			this.ExitButton.Size = new System.Drawing.Size(114, 110);
			this.ExitButton.TabIndex = 5;
			this.ExitButton.UseVisualStyleBackColor = false;
			this.ExitButton.Click += new System.EventHandler(this.Exit);
			// 
			// AdminButton
			// 
			this.AdminButton.BackColor = System.Drawing.Color.Black;
			this.AdminButton.BackgroundImage = global::BugTracker.Properties.Resources.minions;
			this.AdminButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.AdminButton.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.AdminButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AdminButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.AdminButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.AdminButton.Location = new System.Drawing.Point(10, 462);
			this.AdminButton.Name = "AdminButton";
			this.AdminButton.Size = new System.Drawing.Size(92, 89);
			this.AdminButton.TabIndex = 5;
			this.AdminButton.UseVisualStyleBackColor = false;
			this.AdminButton.Click += new System.EventHandler(this.Click_AdminButton);
			// 
			// ProjectsButton
			// 
			this.ProjectsButton.BackColor = System.Drawing.Color.Black;
			this.ProjectsButton.BackgroundImage = global::BugTracker.Properties.Resources.Projects;
			this.ProjectsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ProjectsButton.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.ProjectsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ProjectsButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ProjectsButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.ProjectsButton.Location = new System.Drawing.Point(10, 231);
			this.ProjectsButton.Name = "ProjectsButton";
			this.ProjectsButton.Size = new System.Drawing.Size(92, 89);
			this.ProjectsButton.TabIndex = 4;
			this.ProjectsButton.UseVisualStyleBackColor = false;
			this.ProjectsButton.Click += new System.EventHandler(this.Click_ProjectsButton);
			// 
			// BugsButton
			// 
			this.BugsButton.BackColor = System.Drawing.Color.Black;
			this.BugsButton.BackgroundImage = global::BugTracker.Properties.Resources.Bugs;
			this.BugsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.BugsButton.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.BugsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BugsButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BugsButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.BugsButton.Location = new System.Drawing.Point(10, 350);
			this.BugsButton.Name = "BugsButton";
			this.BugsButton.Size = new System.Drawing.Size(92, 89);
			this.BugsButton.TabIndex = 3;
			this.BugsButton.UseVisualStyleBackColor = false;
			this.BugsButton.Click += new System.EventHandler(this.Click_BugsButton);
			// 
			// ProfileButton
			// 
			this.ProfileButton.BackColor = System.Drawing.Color.Black;
			this.ProfileButton.BackgroundImage = global::BugTracker.Properties.Resources.Profiles;
			this.ProfileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ProfileButton.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.ProfileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ProfileButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ProfileButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.ProfileButton.Location = new System.Drawing.Point(10, 120);
			this.ProfileButton.Name = "ProfileButton";
			this.ProfileButton.Size = new System.Drawing.Size(92, 89);
			this.ProfileButton.TabIndex = 2;
			this.ProfileButton.UseVisualStyleBackColor = false;
			this.ProfileButton.Click += new System.EventHandler(this.Click_ProfileButton);
			// 
			// TopForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.Coral;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(1920, 1080);
			this.Controls.Add(this.RejectBugButton);
			this.Controls.Add(this.AssignBugButton);
			this.Controls.Add(this.ResolveBugButton);
			this.Controls.Add(this.ViewUnassignedBugsButton);
			this.Controls.Add(this.ViewSubmittedBugsButton);
			this.Controls.Add(this.CoralLabel7);
			this.Controls.Add(this.CoralLabel6);
			this.Controls.Add(this.CoralLabel5);
			this.Controls.Add(this.GeneralTextBox5);
			this.Controls.Add(this.GeneralTextBox4);
			this.Controls.Add(this.GeneralTextBox3);
			this.Controls.Add(this.GeneralTextBox2);
			this.Controls.Add(this.RetireProjectButton);
			this.Controls.Add(this.RemoveAccountFromProjectButton);
			this.Controls.Add(this.AssignAccountToProjectButton);
			this.Controls.Add(this.CreateProjectButton);
			this.Controls.Add(this.GuestButton);
			this.Controls.Add(this.EngineerButton);
			this.Controls.Add(this.AdministratorButton);
			this.Controls.Add(this.DeleteAccountButton);
			this.Controls.Add(this.EditAccountRoleButton);
			this.Controls.Add(this.AdminBugsButton);
			this.Controls.Add(this.AdminProjectsButton);
			this.Controls.Add(this.AdminAccountsButton);
			this.Controls.Add(this.CoralLabel4);
			this.Controls.Add(this.ReportBugButton);
			this.Controls.Add(this.ConfirmProjectUpdateButton);
			this.Controls.Add(this.TextBox);
			this.Controls.Add(this.CoralLabel3);
			this.Controls.Add(this.AddProjectUpdateButton);
			this.Controls.Add(this.ViewProjectUpdatesButton);
			this.Controls.Add(this.ProjectOverviewButton);
			this.Controls.Add(this.BackButton);
			this.Controls.Add(this.GeneralTextbox);
			this.Controls.Add(this.ViewUpdatesButton);
			this.Controls.Add(this.UpdateBugButton);
			this.Controls.Add(this.SubmitBugButton);
			this.Controls.Add(this.ResultsBox2);
			this.Controls.Add(this.TitleLabel);
			this.Controls.Add(this.ChangePasswordButton);
			this.Controls.Add(this.LogOutButton);
			this.Controls.Add(this.CoralLabel2);
			this.Controls.Add(this.CoralLabel1);
			this.Controls.Add(this.ResultsBox);
			this.Controls.Add(this.MyBugsButton);
			this.Controls.Add(this.MyProjectsButton);
			this.Controls.Add(this.UploadImageButton);
			this.Controls.Add(this.ImagePanel);
			this.Controls.Add(this.CancelSignUpButton);
			this.Controls.Add(this.ConfirmSignUpButton);
			this.Controls.Add(this.LoginButton);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.SignUpButton);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.LoginPasswordTextbox);
			this.Controls.Add(this.LoginEmailTextbox);
			this.Controls.Add(this.LoginEmailLabel);
			this.Controls.Add(this.AlertLabel);
			this.Controls.Add(this.GreetingLabel);
			this.Controls.Add(this.LoginPasswordLabel);
			this.Controls.Add(this.BackdropPanel);
			this.Controls.Add(this.BackdropPanel2);
			this.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "TopForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button ProfileButton;
		private System.Windows.Forms.Button ProjectsButton;
		private System.Windows.Forms.Button BugsButton;
		private System.Windows.Forms.Button ExitButton;
		private System.Windows.Forms.Label RoleLabel;
		private System.Windows.Forms.Label LoginLabel;
		private System.Windows.Forms.Label AlertLabel;
		private System.Windows.Forms.Label GreetingLabel;
		private System.Windows.Forms.Label LoginEmailLabel;
		private System.Windows.Forms.TextBox LoginEmailTextbox;
		private System.Windows.Forms.Label LoginPasswordLabel;
		private System.Windows.Forms.TextBox LoginPasswordTextbox;
		private System.Windows.Forms.Button LoginButton;
		private System.Windows.Forms.Button SignUpButton;
		private System.Windows.Forms.Panel BackdropPanel;
		private System.Windows.Forms.Button CancelSignUpButton;
		private System.Windows.Forms.Panel ImagePanel;
		private System.Windows.Forms.Button UploadImageButton;
		private System.Windows.Forms.Button MyProjectsButton;
		private System.Windows.Forms.Button MyBugsButton;
		private System.Windows.Forms.ListView ResultsBox;
		private System.Windows.Forms.Label CoralLabel1;
		private System.Windows.Forms.Label CoralLabel2;
		private System.Windows.Forms.Button LogOutButton;
		private System.Windows.Forms.Button ChangePasswordButton;
		private System.Windows.Forms.Button SubmitBugButton;
		private System.Windows.Forms.Button AdminButton;
		private System.Windows.Forms.ListView ResultsBox2;
		private System.Windows.Forms.Label TitleLabel;
		private System.Windows.Forms.Panel BackdropPanel2;
		private System.Windows.Forms.Button UpdateBugButton;
		private System.Windows.Forms.Button ViewUpdatesButton;
		private System.Windows.Forms.TextBox GeneralTextbox;
		private System.Windows.Forms.Button BackButton;
		private System.Windows.Forms.Button ProjectOverviewButton;
		private System.Windows.Forms.Button ViewProjectUpdatesButton;
		private System.Windows.Forms.Button AddProjectUpdateButton;
		private System.Windows.Forms.Label CoralLabel3;
		private System.Windows.Forms.RichTextBox TextBox;
		private System.Windows.Forms.Button ConfirmProjectUpdateButton;
		private System.Windows.Forms.Button ReportBugButton;
		private System.Windows.Forms.Label CoralLabel4;
		private System.Windows.Forms.Button AdminAccountsButton;
		private System.Windows.Forms.Button AdminProjectsButton;
		private System.Windows.Forms.Button AdminBugsButton;
		private System.Windows.Forms.Button EditAccountRoleButton;
		private System.Windows.Forms.Button DeleteAccountButton;
		private System.Windows.Forms.Button AdministratorButton;
		private System.Windows.Forms.Button EngineerButton;
		private System.Windows.Forms.Button GuestButton;
		private System.Windows.Forms.Button CreateProjectButton;
		private System.Windows.Forms.Button AssignAccountToProjectButton;
		private System.Windows.Forms.Button RemoveAccountFromProjectButton;
		private System.Windows.Forms.Button RetireProjectButton;
		private System.Windows.Forms.TextBox GeneralTextBox2;
		private System.Windows.Forms.TextBox GeneralTextBox3;
		private System.Windows.Forms.TextBox GeneralTextBox4;
		private System.Windows.Forms.TextBox GeneralTextBox5;
		private System.Windows.Forms.Label CoralLabel5;
		private System.Windows.Forms.Button ConfirmSignUpButton;
		private System.Windows.Forms.Label CoralLabel6;
		private System.Windows.Forms.Label CoralLabel7;
		private System.Windows.Forms.Button ViewSubmittedBugsButton;
		private System.Windows.Forms.Button ViewUnassignedBugsButton;
		private System.Windows.Forms.Button ResolveBugButton;
		private System.Windows.Forms.Button AssignBugButton;
		private System.Windows.Forms.Button RejectBugButton;
	}
}
