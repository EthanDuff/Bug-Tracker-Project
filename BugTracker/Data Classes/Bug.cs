using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Data_Classes {
	public class Bug {
		private int _ProjectId;
		private int _AccountId;
		private string _Designation;
		private string _Description;
		private string _Status;

		public int ProjectId { get { return _ProjectId; } }
		public int AccountId { get { return _AccountId; } }
		public string Designation { get { return _Designation; } }
		public string Description { get { return _Description; }}
		public string Status { get{return _Status; }}

		public Bug(int ProjectId, int AccountId, string Designation, string Description, string Status) {
			_ProjectId = ProjectId;
			_AccountId = AccountId;
			_Designation = Designation;
			_Description = Description;
			_Status = Status;
		}
		public Bug(int ProjectId, string Designation, string Description, string Status) {
			_ProjectId = ProjectId;
			_AccountId = 0;
			_Designation = Designation;
			_Description = Description;
			_Status = Status;
		}

	}
}
