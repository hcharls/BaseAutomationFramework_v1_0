using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestStack.White.UIItems.Finders;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class FormsTab : BaseScreen
	{
		//public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow };
		public const bool SET_MAXIMIZED = false;
		public FormsTab()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static FormsTab Initialize()
		{
			return new FormsTab();
		}


		#region List Boxes

		private SearchCriteria lstbx_Forms = SearchCriteria.ByAutomationId("emFormMenuBox");
		//
		public void lstbx_Forms_SelectForm(string FormName)
		{
			aElement = GetListBox(lstbx_Forms).GetElement(SearchCriteria.ByText(FormName));
			aElement.SetFocus();
			Thread.Sleep(500);
			aElement.ClickCenterOfBounds();
		}

		public FormsTab OpenAllForms_SelectForm(string Forms)
		{
			aElement = GetListBox(lstbx_Forms).GetElement(SearchCriteria.ByText(Forms));
			aElement.SetFocus();
			Thread.Sleep(500);
			aElement.ClickCenterOfBounds();
			Thread.Sleep(10000);

			return this;
		}

		#endregion

		#region Checkboxes

		private SearchCriteria chk_Show = SearchCriteria.ByAutomationId("allFormBox");

		public FormsTab chk_Show_Check(bool Check)
		{
			ClickCheckBox(Check, chk_Show);

			return this;
		}

		#endregion

	}
}
