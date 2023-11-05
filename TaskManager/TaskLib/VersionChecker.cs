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
                true, true));

            var current = File.ReadAllLines($"{TaskMethods.CD}\\Data\\CurrentVersion.txt")[0];

            //Refresh current git data
            TaskMethods.RunCommand(new TaskOptions(
                "git remote update", true, true));

            TaskMethods.RunCommand(new TaskOptions(
                "git rev-parse main@{upstream} > \"" + TaskMethods.CD +
                "\\Data\\LatestVersion.txt\"", true, true));

            var latest = File.ReadAllLines($"{TaskMethods.CD}\\Data\\LatestVersion.txt")[0];

            return latest == current;
        }

        public static void Update()
        {
            //Create update bat file
            string[] lines = new string[10];
            lines[0] = "@echo off";
            lines[1] = "timeout /t 3";
            lines[3] = "echo Updating local git data";
            lines[4] = "call git remote update";
            lines[5] = "echo Restoring current version";
            lines[6] = "call git restore .";
            lines[7] = "echo Updating to newest version";
            lines[8] = "call git pull";
            lines[9] = "set /p E=Enter to close:";
            File.WriteAllLines($"{TaskMethods.CD}\\Resources\\Update.bat", lines);

            TaskMethods.StartProcess($"{TaskMethods.CD}\\Resources\\Update.bat");
        }
    }
}
