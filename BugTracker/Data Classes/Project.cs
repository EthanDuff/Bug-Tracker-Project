
namespace BugTracker.Data_Classes {
	public class Project {

		private int _Id;
		private string _Name;
		private string _Description;
		private string _ClearanceToView;


		public int Id { get { return _Id; } }
		public string Name {			get { return _Name; }}
		public string Description {			get { return _Description; }		}
		public string ClearanceToView {			get { return _ClearanceToView; }		}

		public Project(int Id, string Name, string Description, string ClearanceToView) {
			_Id = Id;
			_Name = Name;
			_Description = Description;
			_ClearanceToView = ClearanceToView;
		}
	}
}
