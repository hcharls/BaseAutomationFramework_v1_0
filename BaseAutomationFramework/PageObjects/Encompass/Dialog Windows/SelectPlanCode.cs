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
	public class SelectPlanCode : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByText("Select Plan Code");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		private AutomationElement aePanel = null;

		public SelectPlanCode()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static SelectPlanCode Initialize()
		{
			return new SelectPlanCode();
		}

		public void ClosingDocs_SelectPlanCode()
		{
			Point AllFixedRateConventional = new Point(840, 475);

			Mouse.Instance.Location = AllFixedRateConventional;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);

		}

	}
}