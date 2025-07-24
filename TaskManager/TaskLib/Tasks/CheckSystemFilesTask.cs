using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLib.Tasks
{
	public class CheckSystemFilesTask : Task
	{
		public override string Name => "Check System Files";

		public override string Description => "Check For Corrupted System Files";

		public override bool RequiresAdmin => true;

		public CheckSystemFilesTask()
        {
			CustomActionText = "Open Log File";
        }

        public override void Run()
		{
			RunCommand("sfc /scannow", false, true, false);
		}

		public override void CustomAction()
		{
			StartProcess("C:\\Windows\\Logs\\CBS\\CBS.log");
		}
	}
}
