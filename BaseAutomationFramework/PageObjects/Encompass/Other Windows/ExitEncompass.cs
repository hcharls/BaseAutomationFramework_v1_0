using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.Utility;
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class ExitEncompass : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LogoutDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		private AutomationElement aePanel = null;

		public ExitEncompass()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static ExitEncompass Initialize()
		{
			return new ExitEncompass();
		}

		private SearchCriteria btn_Yes = SearchCriteria.ByAutomationId("btnYes");

		//
		public void btn_Yes_Click()
		{
			GetButton(btn_Yes).Click();
			Thread.Sleep(2000);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
			Thread.Sleep(2000);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
			Thread.Sleep(5000);
		}

	}
}