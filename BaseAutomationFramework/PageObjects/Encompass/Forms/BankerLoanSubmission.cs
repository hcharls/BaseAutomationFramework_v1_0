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
				Thread.Sleep(10000);

			return new BankerLoanSubmission();
		}

		#region Text Boxes

		private PropertyCondition txt_LastMortgagePayment = new PropertyCondition(AutomationElement.AutomationIdProperty, "TextBox5");
		private PropertyCondition txt_ClosingMonthPayment = new PropertyCondition(AutomationElement.AutomationIdProperty, "MultilineTextBox14");

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
		
		#endregion

		#region Buttons

		private PropertyCondition btn_BankerCertificationBLS = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button3");
		//
		public BankerLoanSubmission btn_BankerCertificationBLS_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_BankerCertificationBLS);
			aElement.ClickCenterOfBounds();

			return new BankerLoanSubmission();
		}

		#endregion

		#region Combo Boxes

		private PropertyCondition cmb_CreditOnNonBorrowingSpouse = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox4");

		public BankerLoanSubmission cmb_CreditOnNonBorrowingSpouse_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_CreditOnNonBorrowingSpouse);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}

		#endregion


	}
}