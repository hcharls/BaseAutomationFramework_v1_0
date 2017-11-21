using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestStack.White.UIItems.Finders;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class ToolsTab : BaseScreen
	{
		//public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow };
		public const bool SET_MAXIMIZED = false;
		public ToolsTab()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static ToolsTab Initialize()
		{
			return new ToolsTab();
		}


		#region List Boxes

		private SearchCriteria lstbx_Forms = SearchCriteria.ByAutomationId("emToolMenuBox");
		//
		public void lstbx_Tools_SelectTool(string ToolName)
		{
			aElement = GetListBox(lstbx_Forms).GetElement(SearchCriteria.ByText(ToolName));
			aElement.SetFocus();
			Thread.Sleep(500);
			aElement.ClickCenterOfBounds();
		}

		public ToolsTab OpenAllTools_SelectForm(string Tools)
		{
			aElement = GetListBox(lstbx_Forms).GetElement(SearchCriteria.ByText(Tools));
			aElement.SetFocus();
			Thread.Sleep(500);
			aElement.ClickCenterOfBounds();
			Thread.Sleep(10000);

			return this;
		}

		#endregion

		#region Checkboxes

		private SearchCriteria chk_ShowInAlpha = SearchCriteria.ByAutomationId("chkAlphaTools");

		public ToolsTab chk_ShowInAlpha_Check(bool Check)
		{
			ClickCheckBox(Check, chk_ShowInAlpha);

			return this;
		}

		#endregion

	}
}
