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
	public class PaymentProcessing : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("QuickEntryPopupDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		private AutomationElement aePanel = null;

		public PaymentProcessing()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
			aePanel = null;
		}

		public static PaymentProcessing Initialize()
		{
			return new PaymentProcessing();
		}

		public void DragWindow_PaymentProcessing()
		{
			Point point1 = new Point(610, 85);
			Point point2 = new Point(873, 184);

			Mouse.Instance.Location = point1;
			Mouse.LeftDown();
			Mouse.Instance.Location = point2;
			Mouse.LeftUp();
			Thread.Sleep(2000);
		}

		#region Buttons

		private SearchCriteria btn_Close = SearchCriteria.ByAutomationId("btnClose");
		//
		public void btn_Close_Click()
		{
			GetButton(btn_Close).Click();
		}

		#endregion
	}
}