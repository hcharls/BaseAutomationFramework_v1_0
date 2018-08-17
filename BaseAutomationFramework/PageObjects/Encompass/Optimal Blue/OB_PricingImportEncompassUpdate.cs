using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class OB_PricingImportEncompassUpdate : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("Changes");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		private AutomationElement aePanel = null;

		public OB_PricingImportEncompassUpdate()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
			aePanel = null;
		}

		public static OB_PricingImportEncompassUpdate Initialize()
		{
			return new OB_PricingImportEncompassUpdate();
		}

		private SearchCriteria btn_Close = SearchCriteria.ByAutomationId("CloseBut");
		//
		public void btn_Close_Click()
		{
			GetButton(btn_Close).Click();
		}


	}
}