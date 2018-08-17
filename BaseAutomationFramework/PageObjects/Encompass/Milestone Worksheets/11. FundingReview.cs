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
	public class FundingReview : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public FundingReview()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static FundingReview Initialize()
		{
			return new FundingReview();
		}

		public static FundingReview Open_FromLogTab()
		{
			new LogTab()
                .CollapseAll().SelectItem_FundingReview();

			return new FundingReview();
		}

		#region Checkboxes

		private SearchCriteria chk_Finish = SearchCriteria.ByAutomationId("checkBoxFinished");

		public FundingReview chk_Finish_Check()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Finished"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "check box")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);

			return this;
		}

		#endregion

		#region Buttons

		private PropertyCondition btn_Funder = new PropertyCondition(AutomationElement.AutomationIdProperty, "pictureBoxNextLA");
		//
		public FundingReview btn_Funder_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_Funder);
			aElement.ClickCenterOfBounds();
			Thread.Sleep(1000);

			return this;
		}

		#endregion

	}
}