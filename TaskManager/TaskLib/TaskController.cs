using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using TaskLib.Tasks;

namespace TaskLib
{
  //  public class TaskController : TaskMethods
  //  {
  //      public List<TaskDetail> TaskList;

  //      public TaskController()
  //      {
  //          TaskList = new List<TaskDetail>();

  //          var testList = new List<TaskLib.Task>();
		//	testList.Add(new WindowsExplorerTask());

		//	TaskList.Add(new TaskDetail(new Task0(new Method0(RestartExplorer)),
  //              "Restart Explorer", "Restart Windows Explorer Application", false));
  //          TaskList.Add(new TaskDetail(new Task1(new Method1(RunBatElevated),
  //              new TaskOptions("Restart_Adapter", false)),
  //              "Restart Adapter", "Restart Wireless Adapter"));
  //          TaskList.Add(new TaskDetail(new Task0(new Method0(OpenWebPages)),
  //              "Open Links", "Open saved links from file", true));
  //          TaskList.Add(new TaskDetail(new Task1(new Method1(RunBat),
  //              new TaskOptions("Wifi_Passwords", true)),
  //              "Show Passwords", "Show all wifi passwords"));
  //          TaskList.Add(new TaskDetail(new Task1(new Method1(RunBatElevated),
  //              new TaskOptions("Disable_Help", false)),
  //              "Disable Help", "Disable Windows Help Key"));
  //          TaskList.Add(new TaskDetail(new Task1(new Method1(RunBatElevated),
  //              new TaskOptions("Enable_Help", false)),
  //              "Enable Help", "Enable Windows Help Key"));
		//}

  //      public void Start()
  //      {
  //          int choice = -1;
  //          while (choice != 0)
  //          {
  //              Console.WriteLine("Available Tasks: ");
  //              Console.WriteLine("0) Exit");
  //              ViewTasks();

  //              Console.Write("Choose a task number: ");

  //              //If parse fails
  //              if (!(int.TryParse(Console.ReadLine(), out choice)))
  //              {
  //                  Console.WriteLine("Invalid input received. Please enter a valid number");
  //                  choice = -1;
  //              }
  //              else if (choice != 0)
  //              {
  //                  RunTask(choice);
  //              }
  //              else if (choice == 0)
  //              {
  //                  Console.WriteLine("Exiting Task Manager");
  //              }
  //          }
            
  //      }

  //      private void ViewTasks()
  //      {
  //          int count = 1;
  //          foreach (TaskDetail taskD in TaskList)
  //          {
  //              Console.WriteLine((count++) + ") " + taskD.Name + ": " + taskD.Description);
  //          }
  //      }

  //      public virtual void RunTask(int taskNum)
  //      {
  //          if (TaskList.Count >= taskNum && taskNum > 0)
  //          {
  //              TaskList[taskNum - 1].RunTask();
  //          }
  //          else
  //          {
  //              Console.WriteLine("Invalid task number entered");
  //          }

  //          Console.WriteLine("");
  //      }

  //      public void PrintDate(string format = "MM/dd/yyyy")
  //      {
  //          Console.WriteLine("Today's date is: " + DateTime.Now.ToString(format));
  //          //DateTime.Now.ToString("MM/dd HH:mm:ss")
  //      }
  //  }
}
