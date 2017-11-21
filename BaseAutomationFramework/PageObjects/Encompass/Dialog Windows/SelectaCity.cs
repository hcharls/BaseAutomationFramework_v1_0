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
	public class SelectaCity : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("ZipcodeSelectorDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		private AutomationElement aePanel = null;

		public SelectaCity()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static SelectaCity Initialize()
		{
			return new SelectaCity();
		}

		private PropertyCondition SelectaCity_Close = new PropertyCondition(AutomationElement.AutomationIdProperty, "ZipcodeSelectorDialog");
		private SearchCriteria btn_Cancel = SearchCriteria.ByAutomationId("btnCancel");

		//
		public void btn_Cancel_Click()
		{
			GetButton(btn_Cancel).Click();
			Thread.Sleep(1000);
		}
		
	
	

	}
}