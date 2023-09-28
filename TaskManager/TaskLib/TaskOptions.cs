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

        public TaskOptions(string name, bool hidden, string directory = "", string completeMsg = "")
        {
            Name = name;
            Hidden = hidden;
            Directory = directory;
            CompleteMsg = completeMsg;
        }
    }
}
