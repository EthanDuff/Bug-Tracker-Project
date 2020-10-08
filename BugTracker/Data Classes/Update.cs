using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Data_Classes {

	public class Update {

		protected DateTime _Time;
		protected string _Description;

		public string Date { get { return _Time.ToString().Split(' ')[0]; } }
		public string Description { get{ return _Description; } }
	}

	public class BugUpdate : Update {

		private string _Designation;

		public BugUpdate(string Designation, DateTime Time, string Description) {
			_Designation = Designation;
			_Time = Time;
			_Description = Description; 
		}

		public string Designation { get { return _Designation; } }
	}

	public class ProjectUpdate : Update {

		private int _ProjectId;

		public ProjectUpdate(int ProjectId, DateTime Time, string Description) {
			_ProjectId = ProjectId;
			_Time = Time;
			_Description = Description;
		}

		public int ProjectId { get{ return _ProjectId; } }
	}
}
