using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLib.Tasks
{
	public class WindowsExplorerTask : Task
	{
		public override string Name => "Restart Explorer";

		public override string Description => "Restart Windows Explorer Application";

		public override bool RequiresAdmin => false;

		public override void Run()
		{
			RestartWindowsExplorer();
		}
	}
}
