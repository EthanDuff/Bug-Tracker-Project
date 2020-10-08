using System;
using System.Windows.Forms;
using BugTracker.Tests;

namespace BugTracker {

	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {


			bool Run_Test_Suite_Instead_Of_Program = false;
			//Run_Test_Suite_Instead_Of_Program = true;

			if(!Run_Test_Suite_Instead_Of_Program) {
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new TopForm(false));
			}
			else {
				TestSuite _TestSuite = new TestSuite();
			}

		}

	}
}
