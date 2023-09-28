using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLib;

namespace Task_GUI
{
    public class TaskDetailEXT : TaskDetail
    {
        public Task0? EditTask;
        public Task0? CompleteTask;

        public TaskDetailEXT(TaskLib.Task task, string name, string description, Task0? edit = null, Task0? complete = null) 
            : base(task, name, description, false)
        {
            CompleteTask = complete;
        }
    }
}
