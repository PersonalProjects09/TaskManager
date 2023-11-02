using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskLib
{
    public static class VersionChecker
    {
        //using (WebClient client = new WebClient())
        //{
        //    html = client.DownloadString(url);
        //}
        public static bool IsLatestVersion()
        {
            TaskMethods.RunCommand(new TaskOptions(
                $"git rev-parse head > \"{TaskMethods.CD}\\Data\\currentVersion.txt\"", 
                true, true));

            var current = File.ReadAllLines($"{TaskMethods.CD}\\Data\\currentVersion.txt")[0];

            //Refresh current git data
            TaskMethods.RunCommand(new TaskOptions(
                "git remote update", true, true));

            TaskMethods.RunCommand(new TaskOptions(
                "git rev-parse main@{upstream} > \"" + TaskMethods.CD +
                "\\Data\\latestVersion.txt\"", true, true));

            var latest = File.ReadAllLines($"{TaskMethods.CD}\\Data\\latestVersion.txt")[0];

            return latest == current;
        }
    }
}
