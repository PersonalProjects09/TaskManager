using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLib.Tasks
{
	public class DisableWindows11ContextTask : Task
	{
		public override string Name => "Classic Context";

		public override string Description => "Revert Windows 11 context (right click) menu changes";

		public override bool RequiresAdmin => false;

		public override void Run()
		{
			RunCommand("reg add HKCU\\Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32 /ve /d \"\" /f", true);

			RestartWindowsExplorer();
		}
	}
}
