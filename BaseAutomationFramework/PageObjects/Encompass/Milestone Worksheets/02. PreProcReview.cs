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
	public class PreProcReview : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public PreProcReview()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static PreProcReview Initialize()
		{
			return new PreProcReview();
		}

		public static PreProcReview Open_FromLogTab()
		{
			new LogTab()
                .CollapseAll().SelectItem_PreProcReview();

			return new PreProcReview();
		}

		#region Buttons

		private PropertyCondition btn_LoanProcessor = new PropertyCondition(AutomationElement.AutomationIdProperty, "pictureBoxNextLA");
		//
		public PreProcReview btn_LoanProcessor_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_LoanProcessor);
			aElement.ClickCenterOfBounds();
			Thread.Sleep(1000);

			return this;
		}

		#endregion
		
		#region Required Fields

		private PropertyCondition cmb_Disclosures_eSigned = new PropertyCondition(AutomationElement.AutomationIdProperty, "l_CX.INITIAL.DISC.ESIGNED");

		public PreProcReview cmb_Disclosures_eSigned_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Disclosures_eSigned);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
			Thread.Sleep(500);

			return this;
		}

		#endregion

		#region Checkboxes

		private SearchCriteria chk_Finish = SearchCriteria.ByAutomationId("checkBoxFinished");

		public PreProcReview chk_Finish_Check()
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