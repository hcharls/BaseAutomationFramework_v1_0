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
	public class FundingWorksheet : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public FundingWorksheet()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static FundingWorksheet Initialize()
		{
			return new FundingWorksheet();
		}

		public static FundingWorksheet OpenForm_FromToolsTab()
		{
			new ToolsTab()
				.lstbx_Tools_SelectTool("Funding Worksheet");

			return new FundingWorksheet();
		}
        
        #region Text Boxes

        private PropertyCondition txt_FundsOrdered = new PropertyCondition(AutomationElement.NameProperty, "2301: The date the underwriter recommended approval of the loan.");
		private PropertyCondition txt_FundsSent = new PropertyCondition(AutomationElement.NameProperty, "2302: The expiration date of the underwriter's approval.");

		public FundingWorksheet txt_FundsOrdered_SendKeys(string Input)
		{
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_FundsOrdered);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Thread.Sleep(500);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
			Keyboard.Instance.Enter("a");
			Keyboard.Instance.LeaveAllKeys();
			Thread.Sleep(250);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			aElement.WaitWhileBusy();
			Thread.Sleep(1000);

			return this;
		}

		public FundingWorksheet txt_FundsSent_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_FundsSent);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Thread.Sleep(500);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
			Keyboard.Instance.Enter("a");
			Keyboard.Instance.LeaveAllKeys();
			Thread.Sleep(250);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			aElement.WaitWhileBusy();
			Thread.Sleep(1000);

			return this;
		}

		#endregion
	}
}
