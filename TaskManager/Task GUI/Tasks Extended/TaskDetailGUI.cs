using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLib;

namespace Task_GUI
{
    public class TaskDetailGUI : TaskDetail
    {
        public EditOptions? EditOptions { get; set; }
        public Task0? CompleteTask { get; set; }
        public bool RequiresAdmin { get; set; }

        public TaskDetailGUI(TaskLib.Task task, string name, string description, bool requiresAdmin = false, EditOptions? edit = null, Task0? complete = null) 
            : base(task, name, description, false)
        {
            EditOptions = edit;
            CompleteTask = complete;
            RequiresAdmin = requiresAdmin;
        }
    }
}
