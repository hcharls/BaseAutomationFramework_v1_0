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

		private SearchCriteria lstbx_Tools = SearchCriteria.ByAutomationId("emToolMenuBox");

		//


		public void lstbx_Tools_SelectTool(string ToolName)
		{
			Point ToolsTab = new Point(95, 598);

			Mouse.Instance.Location = ToolsTab;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(500);
			aElement = GetListBox(lstbx_Tools).GetElement(SearchCriteria.ByText(ToolName));
			aElement.SetFocus();
			Thread.Sleep(500);
			aElement.ClickCenterOfBounds();
		}

		public ToolsTab OpenAllTools_SelectForm(string Tools)
		{
			Point ToolsTab = new Point(97, 594);
			Mouse.Instance.Location = ToolsTab;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(1000);
			aElement = GetListBox(lstbx_Tools).GetElement(SearchCriteria.ByText(Tools));
			aElement.SetFocus();
			Thread.Sleep(500);
			aElement.ClickCenterOfBounds();
			Thread.Sleep(200000);

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
