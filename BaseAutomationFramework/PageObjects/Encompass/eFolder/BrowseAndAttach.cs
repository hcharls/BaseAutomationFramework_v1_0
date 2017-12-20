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
	public class BrowseAndAttach : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("AddDocumentDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, Encompass_eFolder.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		public BrowseAndAttach()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static BrowseAndAttach Initialize()
		{
			return new BrowseAndAttach();
		}

		#region Buttons

		private SearchCriteria btn_TestDocument = SearchCriteria.ByAutomationId("System.ItemNameDisplay");

		//
		public void btn_TestDocument_DoubleClick()
		{
			GetButton(btn_TestDocument).DoubleClick();
			Thread.Sleep(2000);
		}

		#endregion

	}
}