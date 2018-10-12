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
	public class MortgagePayoff : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public MortgagePayoff()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static MortgagePayoff OpenForm_FromFormsTab()
		{
			new FormsTab()
				.lstbx_Forms_SelectForm("Mortgage Payoff v2");
            Thread.Sleep(2000);

			return new MortgagePayoff();
		}

        #region MortgagePayoff1
        private PropertyCondition cmb_LenderName1 = new PropertyCondition(AutomationElement.AutomationIdProperty, "lenderNameDropdownBoxUI");
        private PropertyCondition txt_PrincipalBalance1 = new PropertyCondition(AutomationElement.AutomationIdProperty, "principalBalanceTextBox");

        public MortgagePayoff cmb_LenderName1_Select()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_LenderName1);
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN); Thread.Sleep(500);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN); Thread.Sleep(500);

            return this;
        }
        public MortgagePayoff txt_PrincipalBalance1_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_PrincipalBalance1);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }

        #endregion
    }
}
	