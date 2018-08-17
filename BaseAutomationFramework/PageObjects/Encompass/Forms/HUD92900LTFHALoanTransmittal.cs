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
	public class HUD92900LTFHALoanTransmittal : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public HUD92900LTFHALoanTransmittal()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static HUD92900LTFHALoanTransmittal OpenForm_FromFormsTab()
		{
			new FormsTab()
				.lstbx_Forms_SelectForm("HUD-92900LT FHA Loan Transmittal");

			return new HUD92900LTFHALoanTransmittal();
		}

		#region Checkboxes

		private SearchCriteria chk_ConstructionExisting = SearchCriteria.ByAutomationId("__cid_CheckBox44_Ctrl");

		public HUD92900LTFHALoanTransmittal chk_ConstructionExisting_Check(bool Check)
		{
			ClickCheckBox(Check, chk_ConstructionExisting);

			return this;
		}

		#endregion

	}
}
