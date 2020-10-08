using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BugTracker.Data_Classes {
	public class Account {

		private int _Id;
		private string _Email;
		private string _Name;
		private string _Role;
		private string _Password;
		private Image _ProfilePicture;

		public int Id { get { return _Id; } }
		public string Email { get {return _Email;} }
		public string Name { get { return _Name; } }
		public string Role { get { return _Role; } set {; } }
		public string Password { get { return _Password; } set {; } }
		public Image ProfilePicture { get { return _ProfilePicture; } set {; } }


		public Account(int Id, string Email, string Name, string Role, string Password, Image ProfilePicture) {
			_Id = Id;
			_Email = Email;
			_Name = Name;
			_Role = Role;
			_Password = Password;
			_ProfilePicture = ProfilePicture;
		}
		public Account(int Id, string Email, string Name, string Role) {
			_Id = Id;
			_Email = Email;
			_Name = Name;
			_Role = Role;
		}
	}
}
