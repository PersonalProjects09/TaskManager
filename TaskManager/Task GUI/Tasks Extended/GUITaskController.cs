using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLib;

namespace Task_GUI
{
    public class GUITaskController : TaskController
    {
        public new List<TaskDetailEXT> TaskList;

        public GUITaskController()
        {
            TaskList = new List<TaskDetailEXT>();

            TaskList.Add(new TaskDetailEXT(new Task0(new Method0(RestartExplorer)),
                "Restart Explorer", "Restart Windows Explorer Application"));
            TaskList.Add(new TaskDetailEXT(new Task1(new Method1(RunBatElevated),
                new TaskOptions("Restart_Adapter", false)),
                "Restart Adapter", "Restart Wireless Adapter"));
            TaskList.Add(new TaskDetailEXT(new Task0(new Method0(OpenWebPages)),
                "Open Links", "Open saved links from file"));
            TaskList.Add(new TaskDetailEXT(new Task1(new Method1(RunBat),
                new TaskOptions("Wifi_Passwords", true)),
                "Show Passwords", "Show all wifi passwords"));
            TaskList.Add(new TaskDetailEXT(new Task1(new Method1(RunBatElevated),
                new TaskOptions("Disable_Help", false)),
                "Disable Help", "Disable Windows Help Key"));
            TaskList.Add(new TaskDetailEXT(new Task1(new Method1(RunBatElevated),
                new TaskOptions("Enable_Help", false)),
                "Enable Help", "Enable Windows Help Key"));
            TaskList.Add(new TaskDetailEXT(new Task0(new Method0(ClassicContextMenu)),
                "Classic Context", "Revert Windows 11 context (right click) menu changes"));
            TaskList.Add(new TaskDetailEXT(new Task0(new Method0(Windows11ContextMenu)),
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
