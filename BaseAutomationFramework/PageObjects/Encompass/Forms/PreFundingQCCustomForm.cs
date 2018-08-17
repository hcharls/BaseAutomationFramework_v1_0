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
	public class PreFundingQCCustomForm : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public PreFundingQCCustomForm()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static PreFundingQCCustomForm OpenForm_FromFormsTab()
		{
			new FormsTab()
				.lstbx_Forms_SelectForm("Pre-Funding QC Custom Form");
			Thread.Sleep(8000);

			return new PreFundingQCCustomForm();
		}

		#region Checkboxes

		private SearchCriteria chk_LoanSelected = SearchCriteria.ByAutomationId("__cid_CheckBox1_Ctrl");
		private SearchCriteria chk_LoanReviewed = SearchCriteria.ByAutomationId("__cid_CheckBox2_Ctrl");
		private SearchCriteria chk_LoanCleared = SearchCriteria.ByAutomationId("__cid_CheckBox3_Ctrl");

		public PreFundingQCCustomForm chk_LoanSelected_Check(bool Check)
		{
			ClickCheckBox(Check, chk_LoanSelected);
			Thread.Sleep(2000);

			return this;
		}
		public PreFundingQCCustomForm chk_LoanReviewed_Check(bool Check)
		{
			ClickCheckBox(Check, chk_LoanReviewed);
			Thread.Sleep(2000);

			return this;
		}
		public PreFundingQCCustomForm chk_LoanCleared_Check(bool Check)
		{
			ClickCheckBox(Check, chk_LoanCleared);
			Thread.Sleep(2000);

			return this;
		}

		#endregion

	}
}
