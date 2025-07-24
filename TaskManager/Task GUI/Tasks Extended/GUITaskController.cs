using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TaskLib;
using TaskLib.Tasks;

namespace Task_GUI
{
    public class GUITaskController
    {
        public new List<TaskLib.Tasks.Task> TaskList;

        public GUITaskController()
        {
            TaskList = new List<TaskLib.Tasks.Task>();
        }

        public void GenerateTaskList(MainWindow window)
        {
            TaskList.Add(new WindowsExplorerTask());
			TaskList.Add(new WirelessAdapterTask());
			TaskList.Add(new CheckSystemFilesTask());
			TaskList.Add(new CheckDiskTask());
			TaskList.Add(new OpenLinksTask());
			var wifiTask = new WifiPasswordsTask();
			wifiTask.CustomActionHandler = new Method0(window.LoadWIFIPasswords);
			TaskList.Add(wifiTask);
			TaskList.Add(new DisableWindows11ContextTask());
			TaskList.Add(new EnableWindows11ContextTask());

			//TaskList.Add(new TaskDetailGUI(new Task0(new Method0(RestartExplorer)),
			//    "Restart Explorer", "Restart Windows Explorer Application"));

			//TaskList.Add(new TaskDetailGUI(new Task1(new Method1(RunBatElevated),
			//    new TaskOptions("Restart_Adapter", false)),
			//    "Restart Adapter", "Restart Wireless Adapter", true));

			//TaskList.Add(new TaskDetailGUI(new Task1(new Method1(RunCommand),
			//    new TaskOptions("sfc /scannow", false, true, closeOnComplete:false)),
			//    "Check System Files", "Check For Corrupted System Files", true, 
			//    new EditOptions(new Task0(window.OpenLog), "Open Log File")));

			//TaskList.Add(new TaskDetailGUI(new Task1(new Method1(RunCommand),
			//    new TaskOptions("chkdsk /f", false, true)),
			//    "Check Disk", "Check For Disk Errors (Requires Reboot)", true));

			//TaskList.Add(new TaskDetailGUI(new Task0(new Method0(OpenWebPages)),
			//    "Open Links", "Open saved links from file", false,
			//    new EditOptions(new Task0(window.EditLinks), "Edit Links")));

			//         TaskList.Add(new TaskDetailGUI(new Task1(new Method1(RunBat),
			//             new TaskOptions("Wifi_Passwords", true)),
			//             "Show Passwords", "Show all wifi passwords", false,
			//             null, new Task0(window.LoadWIFIPasswords)));

			//         TaskList.Add(new TaskDetailGUI(new Task1(new Method1(RunBatElevated),
			//             new TaskOptions("Disable_Help", false)),
			//             "Disable Help", "Disable Windows Help Key", true));

			//         TaskList.Add(new TaskDetailGUI(new Task1(new Method1(RunBatElevated),
			//             new TaskOptions("Enable_Help", false)),
			//             "Enable Help", "Enable Windows Help Key", true));

			//         TaskList.Add(new TaskDetailGUI(new Task0(new Method0(ClassicContextMenu)),
			//             "Classic Context", "Revert Windows 11 context (right click) menu changes"));

			//         TaskList.Add(new TaskDetailGUI(new Task0(new Method0(Windows11ContextMenu)),
			//             "Windows 11 Context", "Return to normal Windows 11 context (right click) menu"));

			//TaskList.Add(new TaskDetailGUI(new Task1(new Method1(StartProcess),
			//	new TaskOptions($"{CD}\\Resources\\PasteHistory.exe", false)),
			//	"Windows Paste History", "Enable Windows Paste History (Win+V)"));

		}

        public void RunTask(int taskNum)
        {
            if (TaskList.Count >= taskNum)
            {
                TaskList[taskNum].Run();
            }
        }
    }
}
