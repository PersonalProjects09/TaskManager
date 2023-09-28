using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using TaskLib;

namespace TaskMain
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskController controller = new TaskController();
            controller.PrintDate();

            controller.Start();

            //controller.PrintDate();

            //controller.RunBatElevated(Bat.RestartAdapter);

            //controller.OpenWebPages();

            //controller.RestartExplorer();

            return;
        }

        /*
        private void sudoku()
        {
            Process process = new Process();

            ProcessStartInfo info = new ProcessStartInfo("ruby", "sudoku_process.rb --try ");
            info.UseShellExecute = false;
            info.RedirectStandardOutput = true;
            info.CreateNoWindow = true;

            process.StartInfo = info;
            process.Start();
            process.WaitForExit();

            //https://stackoverflow.com/questions/2959161/convert-string-to-int-array-using-linq
            string s1 = process.StandardOutput.ReadToEnd();
        }
        */
    }
}
