using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems.Finders;

namespace BaseAutomationFramework.PageObjects.Encompass.Tabs
{
	public class LoanTab : BaseScreen
	{
		//public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("NewResidenceDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow };
		public const bool SET_MAXIMIZED = false;

		public LoanTab()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		#region Tabs & Tab Items

		private SearchCriteria tab_WorkflowTabs = SearchCriteria.ByAutomationId("toolsFormsTabControl");
		//
		public LoanTab tab_Services_Select()
		{
			GetTab(tab_WorkflowTabs).SelectTabPage("Services");

			return new LoanTab();
		}

		#endregion

	}
}
