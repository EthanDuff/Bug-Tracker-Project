using System;
using System.Collections.Generic;

namespace BugTracker.Tests {
	class TestResult {

		private bool _Passed;
		private string _Name;
		private string _Error;

		public bool Passed { get { return _Passed; } }

		public TestResult(bool Passed, string Name, string Error) {
			_Passed = Passed;
			_Name = Name;
			_Error = Error;
		}

		public string FormatSelf() {
			if (_Passed)
				return  "(PASS) - " + _Name;
			return "(FAIL) - " + _Name + " - " + _Error;
		}

		public string FormatFail() {
			return "\t" + _Name + "\n\t\t" + _Error + "\n";
		}
	}
}
