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
	public class Application : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public Application()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static Application Initialize()
		{
			return new Application();
		}

		public static Application Open_FromLogTab()
		{
			new LogTab()
				.CollapseAll().SelectItem_Application();

			return new Application();
		}

		#region Buttons

		private PropertyCondition btn_ProcessingMgr = new PropertyCondition(AutomationElement.AutomationIdProperty, "pictureBoxNextLA");
		//
		public Application btn_ProcessingMgr_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_ProcessingMgr);
			aElement.ClickCenterOfBounds();
			Thread.Sleep(1000);

			return this;
		}

		#endregion

		#region Required Fields

		private PropertyCondition cmb_UnderwritingRiskAccessType = new PropertyCondition(AutomationElement.AutomationIdProperty, "l_1543");
        private PropertyCondition cmb_LoanInfoRefiPurpose = new PropertyCondition(AutomationElement.AutomationIdProperty, "l_299");

        public Application cmb_UnderwritingRiskAccessType_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_UnderwritingRiskAccessType);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
			Thread.Sleep(500);

			return this;
		}
        public Application cmb_LoanInfoRefiPurpose_SendKeys(string Input)
        {
            Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
            aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_LoanInfoRefiPurpose);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(500);

            return this;
        }

        #endregion

        #region Checkboxes

        private SearchCriteria chk_Finish = SearchCriteria.ByAutomationId("checkBoxFinished");

		public Application chk_Finish_Check()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Finished"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "check box")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);

			Thread.Sleep(5000);

			return this;
		}

		#endregion

	}
}