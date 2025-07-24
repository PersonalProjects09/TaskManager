using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLib.Tasks
{
	public class EnableWindows11ContextTask : Task
	{
		public override string Name => "Windows 11 Context";

		public override string Description => "Return to normal Windows 11 context (right click) menu";

		public override bool RequiresAdmin => false;

		public override void Run()
		{
			RunCommand("reg delete HKCU\\SOFTWARE\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2} /f", true);

			RestartWindowsExplorer();
		}
	}
}
