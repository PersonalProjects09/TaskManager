using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskLib
{
    public static class VersionChecker
    {
        public static bool IsLatestVersion()
        {
            string url = "https://github.com/PersonalProjects09/TaskManager/commit/main";
            string html;

            GetLatestVersion();

            return false;
        }

        private static void GetLatestVersion()
        {
            TaskMethods.RunCommand(new TaskOptions(
                $"git show head > \"{TaskMethods.CD}\\Data\\version.txt\"", true));
        }
    }
}
