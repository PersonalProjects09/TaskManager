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
        public static bool IsLatestVersion()
        {
            if (!Directory.Exists($"{TaskMethods.CD}\\Data"))
            {
                Directory.CreateDirectory($"{TaskMethods.CD}\\Data");
            }

            TaskMethods.RunCommand(new TaskOptions(
                $"git rev-parse head > \"{TaskMethods.CD}\\Data\\CurrentVersion.txt\"", 
                true, waitForComplete: true));

            var current = File.ReadAllLines($"{TaskMethods.CD}\\Data\\CurrentVersion.txt")[0];

            //Refresh current git data
            TaskMethods.RunCommand(new TaskOptions(
                "git remote update", true, waitForComplete: true));

            TaskMethods.RunCommand(new TaskOptions(
                "git rev-parse main@{upstream} > \"" + TaskMethods.CD +
                "\\Data\\LatestVersion.txt\"", true, waitForComplete: true));

            var latest = File.ReadAllLines($"{TaskMethods.CD}\\Data\\LatestVersion.txt")[0];

            return latest == current;
        }

        public static void Update()
        {
            //Create update bat file
            List<string> lines = new List<string>();
            lines.Add("@echo off");
            lines.Add("timeout /t 3");
            lines.Add("echo Updating local git data");
            lines.Add("git remote update");
            lines.Add("echo Reverting changes to current version");
            lines.Add("git restore .");
            lines.Add("echo Updating to newest version");
            lines.Add("git pull");
            lines.Add("set /p E=Enter to close:");

            string parent = new DirectoryInfo(TaskMethods.CD).Parent.ToString();
            File.WriteAllLines($"{parent}\\Update.bat", lines);

            TaskMethods.StartProcess($"{parent}\\Update.bat");
        }
    }
}
