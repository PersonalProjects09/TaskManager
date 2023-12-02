using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLib
{
    public class TaskOptions
    {
        public string Name { get; set; }
        public bool Hidden { get; set; }
        public string Directory { get; set; }
        public string CompleteMsg { get; set; }
        public bool WaitForComplete { get; set; }
        public bool RequireAdmin { get; set; }
        public bool CloseOnComplete { get; set; }

        public TaskOptions(string name, bool hidden, bool requireAdmin = false, bool waitForComplete = false, string directory = "", string completeMsg = "", bool closeOnComplete = true)
        {
            Name = name;
            Hidden = hidden;
            Directory = directory;
            CompleteMsg = completeMsg;
            WaitForComplete = waitForComplete;
            RequireAdmin = requireAdmin;
            CloseOnComplete = closeOnComplete;
        }
    }
}
