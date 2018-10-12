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
	public class DisclosurePlanCode : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("OrderDisclosureDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		private AutomationElement aePanel = null;

		public DisclosurePlanCode()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static DisclosurePlanCode SelectPlanCode()
		{
			Point AllFixedRateConventional = new Point(840, 466);

			Mouse.Instance.Location = AllFixedRateConventional;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
			return new DisclosurePlanCode();
		}

		#region Buttons

		private SearchCriteria btn_Order_eDisclosures = SearchCriteria.ByAutomationId("processBtn");

		public void btn_Order_eDisclosures_Click()
		{
			GetButton(btn_Order_eDisclosures).Click();
			Thread.Sleep(10000);
		}

		#endregion

	}
}