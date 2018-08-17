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
	public class FinalUWApproval : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };
		public const bool SET_MAXIMIZED = false;
		public FinalUWApproval()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static FinalUWApproval Initialize()
		{
			return new FinalUWApproval();
		}

		public static FinalUWApproval Open_FromLogTab()
		{
			new LogTab()
                .CollapseAll().SelectItem_FinalUWApproval();
			Thread.Sleep(1000);

			return new FinalUWApproval();
		}

		#region Checkboxes

		private SearchCriteria chk_Finish = SearchCriteria.ByAutomationId("checkBoxFinished");

		public FinalUWApproval chk_Finish_Check()
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

		#region Tasks

		public FinalUWApproval chk_FinalUWApprovalTasks_Check()
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gridViewTasks"));

			Point UWtoCompleteCLP = new Point(1131, 314);
			Point UW_UCDP = new Point(1131, 332);
			Point UnderwritingApprovalExpirationDate = new Point(1131, 350);

			Mouse.Instance.Location = UWtoCompleteCLP;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(1000);
			Mouse.Instance.Location = UW_UCDP;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(1000);
			Mouse.Instance.Location = UnderwritingApprovalExpirationDate;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(1000);

			return this;
		}

		#endregion

		#region Required Fields

		private PropertyCondition cmb_ULDDPropertyValuationMethodType = new PropertyCondition(AutomationElement.AutomationIdProperty, "l_ULDD.X29");
		private PropertyCondition txt_TotalMortgagedPropertiesCount = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_ULDD.TotalMortgagedPropertiesCount");
		private PropertyCondition txt_ULDDInvestorFeatureID = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_ULDD.X36");
		private PropertyCondition cmb_UnderwritingLevelOfPrptyReview = new PropertyCondition(AutomationElement.AutomationIdProperty, "l_1541");
		private PropertyCondition cmb_DayOneCertainty = new PropertyCondition(AutomationElement.AutomationIdProperty, "l_CX.DAY.1.CERTAINTY");
		private PropertyCondition txt_UnderwritingClearToCloseDate = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_2305");


		public FinalUWApproval cmb_ULDDPropertyValuationMethodType_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_ULDDPropertyValuationMethodType);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
			Thread.Sleep(500);
            
			return this;
		}
		public FinalUWApproval txt_TotalMortgagedPropertiesCount_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_TotalMortgagedPropertiesCount);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public FinalUWApproval txt_ULDDInvestorFeatureID_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_ULDDInvestorFeatureID);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public FinalUWApproval cmb_UnderwritingLevelOfPrptyReview_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_UnderwritingLevelOfPrptyReview);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
			Thread.Sleep(500);

			return this;
		}
		public FinalUWApproval cmb_DayOneCertainty_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_DayOneCertainty);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
			Thread.Sleep(500);

			return this;
		}
		public FinalUWApproval txt_UnderwritingClearToCloseDate_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_UnderwritingClearToCloseDate);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}

		#endregion

		#region Buttons

		private PropertyCondition btn_QualityControl = new PropertyCondition(AutomationElement.AutomationIdProperty, "pictureBoxNextLA");
		//
		public FinalUWApproval btn_QualityControl_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_QualityControl);
			aElement.ClickCenterOfBounds();
			Thread.Sleep(1000);

			return this;
		}

		#endregion

	}
}