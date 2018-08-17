using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BaseAutomationFramework.Tests;
using TestStack.White.UIItems.Finders;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	class MI_FeeImport : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("MIFeeImport");
		public static SearchCriteria[] scArray = { scWindow };
		public const bool SET_MAXIMIZED = false;

		public static MI_FeeImport Initialize()
		{
			return new MI_FeeImport();
		}

		public MI_FeeImport()
		{
			try
			{
				BaseTest.TestedApplication.WaitWhileBusy();
			}
			catch (InvalidOperationException e) { Thread.Sleep(5000); } 

			if (Screen == null)
				throw new Exception("Screen must not be null");
		}

		private SearchCriteria btn_ImportFee = SearchCriteria.ByAutomationId("btnImport");
		
		//
		public MI_FeeImport btn_ImportFee_Click()
		{
			GetButton(btn_ImportFee).Click();
			return new MI_FeeImport();
		}

	}
}
