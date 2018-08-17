using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BaseAutomationFramework.Tests.Encompass
{
	public class KillEncompass : BaseTest
	{
		[Test]
		public void Kill()
		{
			QuickAttachToProcess(Processes.Encompass);
			TestedApplication.Kill();
		}
	}
}
