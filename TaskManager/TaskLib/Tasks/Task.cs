using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLib.Tasks
{
	public delegate void Method0();

	public abstract class Task
	{
		public abstract string Name { get; }
		public abstract string Description { get; }
		public static string CD { get => Environment.CurrentDirectory; }
		public abstract bool RequiresAdmin { get; }
		public string CustomActionText { get; set; }
		public bool HasCustomAction { get => !String.IsNullOrWhiteSpace(CustomActionText); }
		public virtual Method0 CustomActionHandler { get; set; }

		public override string ToString()
		{
			return Name + ": " + Description;
		}

		public abstract void Run();
		public virtual void CustomAction() { }

		public static void StartProcess(string process)
		{
			//https://github.com/dotnet/core/issues/4109
			Process.Start(new ProcessStartInfo(process) { UseShellExecute = true });
		}

		public void RunBat(string batName, bool runHidden, bool runAsAdmin = false)
		{
			//bool ShellExecute = true;
			//string[] args = Environment.GetCommandLineArgs();
			string filePath = CD + "\\Resources\\" + batName + ".bat";

			ProcessStartInfo startInfo;
			startInfo = new ProcessStartInfo
			{
				FileName = filePath,
				UseShellExecute = true,
			};
			
			if (runHidden)
				startInfo.WindowStyle = ProcessWindowStyle.Hidden;
			if (runAsAdmin)
				startInfo.Verb = "runas";

			Process process = Process.Start(startInfo);
			process.WaitForExit();
		}

		public static void RunCommand(string command, bool runHidden, bool runAsAdmin = false, 
			bool closeOnComplete = false, bool waitForComplete = false, string directory = "")
		{
			Process process = new Process();
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.FileName = "cmd.exe";

			if (closeOnComplete)
				startInfo.Arguments = "/C " + command;
			else
				startInfo.Arguments = "/K " + command;

			startInfo.UseShellExecute = true;

			if (!String.IsNullOrEmpty(directory))
				startInfo.WorkingDirectory = directory;
			else
				startInfo.WorkingDirectory = CD;

			if (runHidden)
				startInfo.WindowStyle = ProcessWindowStyle.Hidden;

			if (runAsAdmin)
				startInfo.Verb = "runas";

			process.StartInfo = startInfo;

			try
			{
				process.Start();

				if (waitForComplete)
					process.WaitForExit();
			}
			catch (System.ComponentModel.Win32Exception ex)
			{

			}
		}

		public void RestartWindowsExplorer()
		{
			//https://stackoverflow.com/questions/565405/how-to-programmatically-restart-windows-explorer-process

			Process close = new Process();
			close.StartInfo = new ProcessStartInfo
			{
				FileName = "cmd.exe",
				Arguments = "/c taskkill -f -im explorer.exe",
				WindowStyle = ProcessWindowStyle.Hidden,
				UseShellExecute = true
			};
			close.Start();
			close.WaitForExit();

			string explorer = string.Format("{0}\\{1}", Environment.GetEnvironmentVariable("WINDIR"), "explorer.exe");
			Process restart = new Process();
			restart.StartInfo = new ProcessStartInfo
			{
				FileName = explorer,
				UseShellExecute = true,
			};

			restart.Start();
			System.Threading.Thread.Sleep(1000);
		}
	}
}
