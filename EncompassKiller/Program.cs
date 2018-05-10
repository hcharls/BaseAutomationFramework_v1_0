using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncompassKiller
{
	class Program
	{
		static void Main(string[] args)
		{
			Process[] processes = Process.GetProcesses();

			foreach (Process process in processes)
			{
				if (process.ProcessName == "Encompass")
				{
					process.Kill();
				}
			}

		}
	}
}
