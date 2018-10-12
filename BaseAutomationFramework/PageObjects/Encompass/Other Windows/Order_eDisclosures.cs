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
	public class Order_eDisclosures : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("OrderDisclosureDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		private AutomationElement aePanel = null;

		public Order_eDisclosures()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
			aePanel = null;
		}

		public static Order_eDisclosures Initialize()
		{
			return new Order_eDisclosures();
		}

		public Order_eDisclosures InitialDisclosures_SelectTopPlanCode()
		{
			Point TopPlanCode = new Point(800, 465);

			Mouse.Instance.Location = TopPlanCode;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(500);

			return new Order_eDisclosures();

		}

		#region Buttons

		private SearchCriteria btn_Order_eDisclosures = SearchCriteria.ByAutomationId("processBtn");

		public void btn_Order_eDisclosures_Click()
		{
			GetButton(btn_Order_eDisclosures).Click();
			Thread.Sleep(5000);
		}

		#endregion

	}
}