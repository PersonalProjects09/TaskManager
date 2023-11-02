using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TaskLib;

namespace Task_GUI
{
    public class GUITaskController : TaskController
    {
        public new List<TaskDetailGUI> TaskList;

        public GUITaskController()
        {
            TaskList = new List<TaskDetailGUI>();
        }

        public void GenerateTaskList(MainWindow window)
        {
            TaskList.Add(new TaskDetailGUI(new Task0(new Method0(RestartExplorer)),
                "Restart Explorer", "Restart Windows Explorer Application"));

            TaskList.Add(new TaskDetailGUI(new Task1(new Method1(RunBatElevated),
                new TaskOptions("Restart_Adapter", false)),
                "Restart Adapter", "Restart Wireless Adapter", true));

            TaskList.Add(new TaskDetailGUI(new Task0(new Method0(OpenWebPages)),
                "Open Links", "Open saved links from file", false,
                new Task0(window.EditLinks)));

            TaskList.Add(new TaskDetailGUI(new Task1(new Method1(RunBat),
                new TaskOptions("Wifi_Passwords", true)),
                "Show Passwords", "Show all wifi passwords", false,
                null, new Task0(window.LoadWIFIPasswords)));

            TaskList.Add(new TaskDetailGUI(new Task1(new Method1(RunBatElevated),
                new TaskOptions("Disable_Help", false)),
                "Disable Help", "Disable Windows Help Key", true));

            TaskList.Add(new TaskDetailGUI(new Task1(new Method1(RunBatElevated),
                new TaskOptions("Enable_Help", false)),
                "Enable Help", "Enable Windows Help Key", true));

            TaskList.Add(new TaskDetailGUI(new Task0(new Method0(ClassicContextMenu)),
                "Classic Context", "Revert Windows 11 context (right click) menu changes"));

            TaskList.Add(new TaskDetailGUI(new Task0(new Method0(Windows11ContextMenu)),
                "Windows 11 Context", "Return to normal Windows 11 context (right click) menu"));
        }

        override public void RunTask(int taskNum)
        {
            if (TaskList.Count >= taskNum)
            {
                TaskList[taskNum].RunTask();

                if (TaskList[taskNum].CompleteTask != null)
                {
                    TaskList[taskNum].CompleteTask.Run();
                }
            }
        }
    }
}
