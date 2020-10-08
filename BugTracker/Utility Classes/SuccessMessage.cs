using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Utility_Classes {
	public class SuccessMessage {

		private bool _Success;
		private string _Message;

		public bool Success { get { return _Success; } }
		public string Message { get { return _Message; } }

		public SuccessMessage(bool Success, string Message) {
			_Success = Success;
			_Message = Message;
		}
		public SuccessMessage(bool Success) {
			_Success = Success;
			_Message = "";
		}
		public SuccessMessage() {
			_Success = true;
			_Message = "";
		}
	}
}
