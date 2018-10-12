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
	public class DisclosuresAudit : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("AuditDialog");
		public static SearchCriteria[] scArray = { scWindow };
		public const bool SET_MAXIMIZED = false;
		private AutomationElement aePanel = null;

		public DisclosuresAudit()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
			aePanel = null;
		}

		public static DisclosuresAudit Initialize()
		{
			return new DisclosuresAudit();
		}

		#region Buttons

		private SearchCriteria btn_Order_eDisclosures = SearchCriteria.ByAutomationId("orderBtn");

		public void btn_Order_eDisclosures_Click()
		{
			GetButton(btn_Order_eDisclosures).Click();
			Thread.Sleep(5000);
		}

		#endregion

	}
}