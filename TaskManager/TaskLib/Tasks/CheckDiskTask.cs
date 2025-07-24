using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLib.Tasks
{
	public class CheckDiskTask : Task
	{
		public override string Name => "Check Disk";

		public override string Description => "Check For Disk Errors (Requires Reboot)";

		public override bool RequiresAdmin => true;

		public override void Run()
		{
			RunCommand("chkdsk /f", false, true);
		}
	}
}
