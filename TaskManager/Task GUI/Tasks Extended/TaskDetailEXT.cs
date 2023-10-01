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
        public Task0? EditTask { get; set; }
        public Task0? CompleteTask { get; set; }
        public bool RequiresAdmin { get; set; }

        public TaskDetailEXT(TaskLib.Task task, string name, string description, bool requiresAdmin = false, Task0? edit = null, Task0? complete = null) 
            : base(task, name, description, false)
        {
            CompleteTask = complete;
            RequiresAdmin = requiresAdmin;
        }
    }
}
