using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLib.Tasks
{
	public class WifiPasswordsTask : Task
	{
		public override string Name => "Show Passwords";

		public override string Description => "Show all wifi passwords";

		public override bool RequiresAdmin => false;

		public override void Run()
		{
			RunBat("Wifi_Passwords", true);

			CustomActionHandler.Invoke();
		}
	}
}
