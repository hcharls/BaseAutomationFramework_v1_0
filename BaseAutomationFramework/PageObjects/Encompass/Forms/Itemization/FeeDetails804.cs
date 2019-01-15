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
	public class FeeDetails804 : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("QuickEntryPopupDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		public FeeDetails804()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static FeeDetails804 Initialize()
		{
			return new FeeDetails804();
		}

		public static FeeDetails804 OpenFromItemization()
		{
			new Itemization()
				.btn_line804_Click();

			return new FeeDetails804();
		}

		#region Buttons

		private SearchCriteria btn_Close = SearchCriteria.ByAutomationId("btnClose");
		
		public void btn_Close_Click()
		{
			GetButton(btn_Close).Click();
            Thread.Sleep(1000);
		}

		#endregion

		public void DragWindow_FeeDetails804()
		{

            Point point1 = new Point(707, 239);
			Point point2 = new Point(1446, 239);

			Mouse.Instance.Location = point1;
			Mouse.LeftDown();
			Mouse.Instance.Location = point2;
			Mouse.LeftUp();
			Thread.Sleep(2000);

			//Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
			//Keyboard.Instance.Enter("s");
			//Keyboard.Instance.LeaveAllKeys();
		}


	}
}