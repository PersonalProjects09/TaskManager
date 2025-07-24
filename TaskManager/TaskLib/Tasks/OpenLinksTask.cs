using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TaskLib.Tasks
{
	public class OpenLinksTask : Task
	{
		public override string Name => "Open Links";

		public override string Description => "Open saved links from file";

		public override bool RequiresAdmin => false;

        public OpenLinksTask()
        {
			CustomActionText = "Edit Links";
        }

        public override void Run()
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

		public override void CustomAction()
		{
			string path = "Resources\\Links.txt";
			if (File.Exists(path))
			{
				TaskMethods.StartProcess(path);
			}
			else
			{
				FileStream f = File.Create(path);
				f.Close();
				TaskMethods.StartProcess(path);
			}
		}
	}
}
