///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Namespace>
///   Class:          <KillEncompass>
///   Description:    <Immediately_close_all_Encompass_windows_without_saving>
///   Author:         <Hannah_Charls>           Date: <Novmeber_21_2017>
///   Notes:          <>
///   Revision History:
///   Name:				 Date:					Description:
///   
/// 
///------------------------------------------------------------------------------------------------------------------------

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
