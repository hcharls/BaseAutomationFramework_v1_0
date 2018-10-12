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
	public class DisclosedLESnapshot : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LEDisclosureSnapshot");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		public DisclosedLESnapshot()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static DisclosedLESnapshot Initialize()
		{
			return new DisclosedLESnapshot();
		}

		#region Buttons

		private SearchCriteria btn_OK = SearchCriteria.ByAutomationId("btnOK");

		public void btn_OK_Click()
		{
			GetButton(btn_OK).Click();
            Thread.Sleep(3000);
		}

		#endregion



	}
}