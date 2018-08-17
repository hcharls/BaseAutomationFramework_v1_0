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
	public class BorrowerInformationVesting : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public BorrowerInformationVesting()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static BorrowerInformationVesting Initialize()
		{
			return new BorrowerInformationVesting();
		}

		public static BorrowerInformationVesting OpenForm_FromFormsTab()
		{
			new FormsTab()
				.lstbx_Forms_SelectForm("Borrower Information - Vesting");

			return new BorrowerInformationVesting();
		}

		#region Buttons

		private PropertyCondition btn_BuildFinal = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnFinal");
		//
		public BorrowerInformationVesting btn_BuildFinal_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_BuildFinal);
			aElement.ClickCenterOfBounds();
			Thread.Sleep(2000);

			return new BorrowerInformationVesting();
		}

		#endregion
	}
}
