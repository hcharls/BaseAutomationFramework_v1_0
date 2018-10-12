using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BaseAutomationFramework.Tests;
using TestStack.White.UIItems.Finders;
using TestStack.White.InputDevices;
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	class ComplianceAlert: BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("RegulationAlertDialog");
		public static SearchCriteria[] scArray = { scWindow };
		public const bool SET_MAXIMIZED = false;

		public static ComplianceAlert Initialize()
		{
			return new ComplianceAlert();
		}

		public ComplianceAlert()
		{
			try
			{
				BaseTest.TestedApplication.WaitWhileBusy();
			}
			catch (InvalidOperationException e) { Thread.Sleep(5000); }

			if (Screen == null)
				throw new Exception("Screen must not be null");
		}

		private SearchCriteria btn_Close = SearchCriteria.ByAutomationId("btnClose");

		//
		public ComplianceAlert btn_Close_Click()
		{
			GetButton(btn_Close).Click();
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			Thread.Sleep(2000);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
			return new ComplianceAlert();
		}

	}
}
