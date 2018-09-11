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
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class BankerLoanSubmission : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public BankerLoanSubmission()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static BankerLoanSubmission OpenForm_FromFormsTab()
		{
			new FormsTab()
				.lstbx_Forms_SelectForm("Banker Loan Submission Form");
				Thread.Sleep(7000);
			
			return new BankerLoanSubmission();
		}
        public static BankerLoanSubmission Initialize()
        {
            return new BankerLoanSubmission();
        }

        public void ScrollDown()
        {
            Point Top = new Point(1902, 339);
            Point Bottom = new Point(1902, 782);

            Mouse.Instance.Location = Top;
            Mouse.LeftDown();
            Thread.Sleep(500);
            Mouse.Instance.Location = Bottom;
            Mouse.LeftUp();
            Thread.Sleep(2000);
        }

        #region Text Boxes

        private PropertyCondition txt_LastMortgagePayment = new PropertyCondition(AutomationElement.AutomationIdProperty, "TextBox5");
		private PropertyCondition txt_ClosingMonthPayment = new PropertyCondition(AutomationElement.AutomationIdProperty, "MultilineTextBox14");
        private PropertyCondition txt_PestInspection = new PropertyCondition(AutomationElement.AutomationIdProperty, "MultilineTextBox14");
        private PropertyCondition txt_AdditionalNotes = new PropertyCondition(AutomationElement.AutomationIdProperty, "MultilineTextBox3");

        public BankerLoanSubmission txt_LastMortgagePayment_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_LastMortgagePayment);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			aElement.WaitWhileBusy();
			Thread.Sleep(500);

			return this;
		}
		public BankerLoanSubmission txt_ClosingMonthPayment_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_ClosingMonthPayment);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
        public BankerLoanSubmission txt_PestInspection_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_PestInspection);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }
        public BankerLoanSubmission txt_AdditionalNotes_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_AdditionalNotes);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }


        #endregion

        #region Buttons

        private PropertyCondition btn_BankerCertificationBLS = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button3");
        private PropertyCondition btn_CopyCashBackSTC = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button1");

        //
        public BankerLoanSubmission btn_BankerCertificationBLS_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_BankerCertificationBLS);
			aElement.ClickCenterOfBounds();

			return new BankerLoanSubmission();
		}
        public BankerLoanSubmission btn_CopyCashBackSTC_Click()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_CopyCashBackSTC);
            aElement.ClickCenterOfBounds();

            return this;
        }

        #endregion

        #region Combo Boxes

        private PropertyCondition cmb_CreditOnNonBorrowingSpouse = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox4");
        private PropertyCondition cmb_ConditionsSentByBorrower = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox6");
        private PropertyCondition cmb_AppraisalRequired = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox7");

        public BankerLoanSubmission cmb_CreditOnNonBorrowingSpouse_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_CreditOnNonBorrowingSpouse);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);

            return this;
        }
        public BankerLoanSubmission cmb_ConditionsSentByBorrower_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_ConditionsSentByBorrower);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);

            return this;
        }
        public BankerLoanSubmission cmb_AppraisalRequired_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_AppraisalRequired);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);

            return this;
        }

        #endregion


    }
}