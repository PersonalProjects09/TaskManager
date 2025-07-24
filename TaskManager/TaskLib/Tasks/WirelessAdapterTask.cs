using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLib.Tasks
{
	public class WirelessAdapterTask : Task
	{
		public override string Name => "Restart Adapter";

		public override string Description => "Restart Wireless Adapter";

		public override bool RequiresAdmin => true;

		public override void Run()
		{
			RunBat("Restart_Adapter", false, true);
		}
	}
}
