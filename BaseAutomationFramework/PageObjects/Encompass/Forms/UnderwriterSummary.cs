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
	public class UnderwriterSummary : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public UnderwriterSummary()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static UnderwriterSummary Initialize()
		{
			return new UnderwriterSummary();
		}

		public static UnderwriterSummary OpenForm_FromToolsTab()
		{
			new ToolsTab()
				.lstbx_Tools_SelectTool("Underwriter Summary");
				Thread.Sleep(2000);

			return new UnderwriterSummary();
		}

		#region Text Boxes

		private PropertyCondition txt_ApprovedByDate = new PropertyCondition(AutomationElement.NameProperty, "2301: The date the underwriter recommended approval of the loan.");
		private PropertyCondition txt_ApprovalExpiresDate = new PropertyCondition(AutomationElement.NameProperty, "2302: The expiration date of the underwriter's approval.");

		public UnderwriterSummary txt_ApprovedByDate_SetDate()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_ApprovedByDate);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Thread.Sleep(250);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
			Keyboard.Instance.Enter("d");
			Keyboard.Instance.LeaveAllKeys();
			Thread.Sleep(500);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			Thread.Sleep(2000);

			return this;
		}

			public UnderwriterSummary txt_ApprovalExpiresDate_SetDate()
		{
            DateTime date = DateTime.Now;
            date = date.AddDays(30);

            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_ApprovalExpiresDate);
			aElement.SetFocus();
			Keyboard.Instance.Enter(date.ToString("mm/dd/yyyy"));
			Thread.Sleep(500);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			Thread.Sleep(500);

			return this;
		}

		#endregion
	}
}
