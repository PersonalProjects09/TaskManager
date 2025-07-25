﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace TaskLib
{
    public class TaskMethods
    {
        public static string CD { get => Environment.CurrentDirectory; }

        public static void StartProcess(string process)
        {
            //https://github.com/dotnet/core/issues/4109
            Process.Start(new ProcessStartInfo(process) { UseShellExecute = true });
        }

		public static void StartProcess(TaskOptions options)
		{
			//https://github.com/dotnet/core/issues/4109
			Process.Start(new ProcessStartInfo(options.Name) { UseShellExecute = true });
		}

		public void RunBat(TaskOptions options)
        {
            //bool ShellExecute = true;
            //string[] args = Environment.GetCommandLineArgs();
            string filePath = CD + "\\Resources\\" + options.Name + ".bat";

            ProcessStartInfo info;
            if (options.Hidden)
            {
                info = new ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                };
            }
            else
            {
                info = new ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true,
                };
            }

            Process process = Process.Start(info);
            process.WaitForExit();
        }

        public void RunBatElevated(TaskOptions options)
        {
            //string[] args = Environment.GetCommandLineArgs();
            string filePath = CD + "\\Resources\\" + options.Name + ".bat";
            ProcessStartInfo info = new ProcessStartInfo
            {
                FileName = filePath,
                UseShellExecute = true,
                Verb = "runas",         // Indicate to run the process as admin
            };

            try
            {
                Process process = Process.Start(info);
                process.WaitForExit();
                Console.WriteLine(options.CompleteMsg);
            }
            catch
            {
                //Handle operation being canceled by user
                Console.WriteLine("An error occurred: Task did not complete");
            }
        }

        public void OpenWebPages()
        {
            string path = "Resources\\Links.txt";
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                string dataRow = null;
                string[] data;
                List<string> pages = new List<string>();
                Regex regex = new Regex("https?:\\/\\/[a-zA-Z\\/]+");

                //Read all lines in file
                while ((dataRow = reader.ReadLine()) != null)
                {
                    data = dataRow.Split(' '); //Separate by space

                    //If Y(es), open page
                    if (data[0].ToUpper() == "Y")
                        pages.Add(data[1]);
                }
                reader.Close();

                foreach (string url in pages)
                {
                    if (regex.IsMatch(url))
                    {
                        Console.WriteLine("Opening " + url);

                        StartProcess(url);
                    }
                    else
                    {
                        Console.WriteLine("Error! " + url + " is not recognized as a URL");
                    }
                }
                Console.WriteLine("Complete");
            }
            else
            {
                FileStream f = File.Create(path);
                f.Close();
                StartProcess(path);
            }
        }

        public static void RunCommand(TaskOptions options)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";

            if (options.CloseOnComplete)
                startInfo.Arguments = "/C " + options.Name;
            else
                startInfo.Arguments = "/K " + options.Name;

            startInfo.UseShellExecute = true;

            if (!String.IsNullOrEmpty(options.Directory))
                startInfo.WorkingDirectory = options.Directory;
            else
                startInfo.WorkingDirectory = CD;

            if (options.Hidden)
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            if (options.RequireAdmin)
                startInfo.Verb = "runas";

            process.StartInfo = startInfo;

            try
            {
                process.Start();

                if (options.WaitForComplete)
                    process.WaitForExit();
            }
            catch (System.ComponentModel.Win32Exception ex)
            {

            }
        }

        public void RestartExplorer()
        {
            
        }

        //https://www.winhelponline.com/blog/get-classic-full-context-menu-windows-11/?expand_article=1
        public void ClassicContextMenu()
        {
            RunCommand(new TaskOptions("reg add HKCU\\Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32 /ve /d \"\" /f", true));

            RestartExplorer();
        }

        public void Windows11ContextMenu()
        {
            RunCommand(new TaskOptions("reg delete HKCU\\SOFTWARE\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2} /f", true));

            RestartExplorer();
        }
    }
}
