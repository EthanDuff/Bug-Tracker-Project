  -- READ ME --

Hello User!  This is a bug tracker and by extension a project management application written in a C# Windows Form.  This project is designed to demonstrate the programming/engineering abilities of Ethan Duff with the intent of getting a him a job doing software engineering.  This READ ME is intended for HR personel as well as Engineers, so I'll go over a few different details just in case.


  -- How Does It Work --

Download the install wizard and install the Bug Tracker application, you can run it from the icon that will appear on the desktop or from the Bug Tracker folder in Program Files (x86).  Once you've started the application you will see four tabs on the left, "Accounts", "Projects", "Bugs", "Admin".  Clicking on any tab other than Accounts will remind you that you must login before accessing those pages.  When you click Accounts it will prompt you for a username and password.  You may create your own account, or you may login as a pre-programmed account.

Email 			Password
test@gmail.com		"AdminAccount"
test@gmail.com		"EngineerAccount"
test@gmail.com		"GuestAccount"

Each of these emails/passwords will log you in as as either an admin, giving you full access to view/edit every tab and piece of data, or as an engineer, giving you full access to your assigned projects and bugs, or as a guest, giving you access to basically nothing.  If you would like to create your own account to test it's functionality, you can totally do so and a dummy gmail I have set up will send a code to your email that will allow you to create an account.


  -- What Does It Do --

The application allows you to manage your account, create projects, assign engineers, update projects, report bugs, update bugs, submit bugs for resolution, and then mark them resolved.  Each of the different tabs allow you to work on their respective projects and bugs in the database.  The admin tab is only accessable by Administrator accounts and allows the user to do higher level commands like create and retire projects, assign and unassign engineers to said projects, assign bugs in a project to its engineers, mark submitted bugs as resolved or reject them, promote and demote other accounts, and delete accounts.  All of the basic functionality of a project management application.  Play around with it while logged in as an Administrator account and you will quickly see all that it can do.


  -- What About The Code --

The application is written in C# as a winform application developed in Visual Studio using an MVC design pattern and a SQLite database structure.  When the application begins for the very first time it will check to see if a database exists and will not find one.  The application will then proceed to create a folder in AppData with a BugTrackerDatabase file and populate it with enough dummy data to show the functionality of the program.  This includes dummy projects, dummy accounts, dummy bugs, and various updates and database connections between them.  I chose C# because of its compatability with WinForms and because it was a language I had not worked in before, so I learned it specifically for this project.  The View for the MVC pattern is the WinForm itself and the Model holds all the relevant data, like the current logged-in account's information and the connection to the SQLite database.  The Controller is the only line of communication between the two.  The model also has access to various Manager classes that each deal specifically with Accounts/Projects/Bugs and the creation/editing/deletion of them. There is also a testing suite that is accessable when the project is opened in Visual Studio. All of the documentation for the class structures, database schema, and use case diagrams are included in the same folder as the application.  