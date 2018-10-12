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
	public class ClosingTracking : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public ClosingTracking()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static ClosingTracking Initialize()
		{
			return new ClosingTracking();
		}

		public static ClosingTracking OpenForm_FromFormsTab()
		{
			new FormsTab()
				.lstbx_Forms_SelectForm("Closing Tracking");
			Thread.Sleep(2000);

			return new ClosingTracking();
		}

		#region Text Boxes

		private PropertyCondition txt_EarliestClosingDate = new PropertyCondition(AutomationElement.AutomationIdProperty, "TextBox6");
        private PropertyCondition txt_CD_Ordered = new PropertyCondition(AutomationElement.AutomationIdProperty, "TextBox9");

        public ClosingTracking txt_EarliestClosingDate_CopyField()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_EarliestClosingDate);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Thread.Sleep(1500);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
			Keyboard.Instance.Enter("a");
			Thread.Sleep(1000);
			Keyboard.Instance.LeaveAllKeys();
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
			Keyboard.Instance.Enter("c");
			Keyboard.Instance.LeaveAllKeys();
			Thread.Sleep(2000);

			return this;
		}
        public ClosingTracking txt_CD_Ordered_SetTodaysDate()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CD_Ordered);
            aElement.SetFocus();
            aElement.ClickCenterOfBounds();
            Thread.Sleep(1500);
            Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            Keyboard.Instance.Enter("d");
            Thread.Sleep(1000);
            Keyboard.Instance.LeaveAllKeys();
            Thread.Sleep(2000);

            return this;
        }

        #endregion
    }
}
