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

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class Retrieve : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("RetrieveBorrowerDialog");
		public static SearchCriteria[] scArray = { Encompass_eFolder.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		public Retrieve()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
            aeScreen = Screen.AutomationElement;
		}

		public static Retrieve OpenFrom_eFolder()
		{
			new Encompass_eFolder()
				.btn_Retrieve_Click();
            Thread.Sleep(3000);
			return new Retrieve();
		}

		#region Buttons

		private SearchCriteria btn_Download = SearchCriteria.ByAutomationId("btnDownload");

		public void btn_Download_Click()
		{
			GetButton(btn_Download).Click();
			Thread.Sleep(10000);
		}

		#endregion

	
	}
}