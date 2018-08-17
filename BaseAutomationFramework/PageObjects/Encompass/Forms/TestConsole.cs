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
	public class TestConsole : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };
		public const bool SET_MAXIMIZED = false;
		public TestConsole()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static TestConsole Initialize()
		{
			return new TestConsole();
		}

		public static TestConsole OpenForm_FromFormsTab()
		{
			new FormsTab()
				.lstbx_Forms_SelectForm("QA Test Console");
			Thread.Sleep(2000);

			return new TestConsole();
		}

        #region Buttons

        private PropertyCondition btn_KenCustomer = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button5");
		private PropertyCondition btn_JohnMaryHomeowner = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button1");
		private PropertyCondition btn_AliceFirstimer = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button2");
		private PropertyCondition btn_Conventional = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button17");
		private PropertyCondition btn_FHA = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button18");
		private PropertyCondition btn_VA = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button19");
		private PropertyCondition btn_Purchase = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button22");
		private PropertyCondition btn_CashOutRefi = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button21");
		private PropertyCondition btn_NoCashOutRefi = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button20");
		private PropertyCondition btn_BLSCertification = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button16");
		private PropertyCondition btn_Direct = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button4");
		private PropertyCondition btn_Partners = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button9");
		private PropertyCondition btn_Phoenix = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button10");
		private PropertyCondition btn_Atlanta = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button11");
		private PropertyCondition btn_800FICO = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button12");
		private PropertyCondition btn_RunProductAndPricing = new PropertyCondition(AutomationElement.AutomationIdProperty, "prodPricingButton");
		private PropertyCondition btn_GoToDisclosurePrep = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button13");
		private PropertyCondition btn_KathleenEmail = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button3");
		private PropertyCondition btn_TonyEmail = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button6");
		private PropertyCondition btn_HannahEmail = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button7");
		private PropertyCondition btn_LavanyaEmail = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button8");
		private PropertyCondition btn_CoBorrowerEmail = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button15");
		private PropertyCondition btn_EnterDataManually_Refinance = new PropertyCondition(AutomationElement.AutomationIdProperty, "FieldLock2");
		
		//
		public TestConsole btn_KenCustomer_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Ken Customer - Single Borrower"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_NoCashOutRefi);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			new TestConsole();
			Thread.Sleep(1000);

			return new TestConsole();
		}
		public TestConsole btn_JohnMaryHomeowner_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "John & Mary Homeowner - Co-Borrowers"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_NoCashOutRefi);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			new TestConsole();
			Thread.Sleep(1000);

			return new TestConsole();
		}
		public TestConsole btn_AliceFirstimer_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Alice Firstimer - First Time Homebuyer"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_NoCashOutRefi);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			new TestConsole();
			Thread.Sleep(1000);

			return new TestConsole();
		}
		public TestConsole btn_Conventional_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Conventional"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_NoCashOutRefi);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			new TestConsole();
			Thread.Sleep(1000);

			return new TestConsole();
		}
		public TestConsole btn_FHA_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "FHA"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_NoCashOutRefi);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			new TestConsole();
			Thread.Sleep(1000);

			return new TestConsole();
		}
		public TestConsole btn_VA_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "VA"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_NoCashOutRefi);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			new TestConsole();
			Thread.Sleep(1000);

			return new TestConsole();
		}
		public TestConsole btn_Purchase_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Purchase"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_NoCashOutRefi);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			new TestConsole();
			Thread.Sleep(1000);

			return new TestConsole();
		}
		public TestConsole btn_CashOutRefi_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Cash-Out Refi"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_NoCashOutRefi);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			new TestConsole();
			Thread.Sleep(1000);

			return new TestConsole();
		}
		public TestConsole btn_NoCashOutRefi_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "No Cash-Out Refi"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_NoCashOutRefi);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			new TestConsole();
			Thread.Sleep(1000);

			return new TestConsole();
		}
		public TestConsole btn_BLSCertification_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "BLS Certification"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_NoCashOutRefi);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			new TestConsole();
			Thread.Sleep(1000);

			return new TestConsole();
		}
		public TestConsole btn_Direct_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Direct"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_NoCashOutRefi);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			new TestConsole();
			Thread.Sleep(1000);

			return new TestConsole();
		}
		public TestConsole btn_Partners_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Partners"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_NoCashOutRefi);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			new TestConsole();
			Thread.Sleep(1000);

			return new TestConsole();
		}
		public TestConsole btn_Phoenix_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Phoenix"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_NoCashOutRefi);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			new TestConsole();
			Thread.Sleep(1000);

			return new TestConsole();
		}
		public TestConsole btn_Atlanta_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Atlanta"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_NoCashOutRefi);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			new TestConsole();
			Thread.Sleep(1000);

			return new TestConsole();
		}
		public TestConsole btn_800FICO_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "800 FICO"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_NoCashOutRefi);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			new TestConsole();
			Thread.Sleep(1000);

			return new TestConsole();
		}
		public TestConsole btn_RunProductAndPricing_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Run Product and Pricing"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_NoCashOutRefi);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			new TestConsole();
			Thread.Sleep(1000);

			return new TestConsole();
		}
		public TestConsole btn_GoToDisclosurePrep_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Go to Disclosure Prep (TRID)"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_NoCashOutRefi);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			new TestConsole();
			Thread.Sleep(1000);

			return new TestConsole();
		}
		public TestConsole btn_KathleenEmail_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Kathleen"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_NoCashOutRefi);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			new TestConsole();
			Thread.Sleep(1000);

			return new TestConsole();
		}
		public TestConsole btn_TonyEmail_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Tony"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_NoCashOutRefi);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			new TestConsole();
			Thread.Sleep(1000);

			return new TestConsole();
		}
		public TestConsole btn_HannahEmail_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Hannah"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_NoCashOutRefi);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			new TestConsole();
			Thread.Sleep(1000);

			return new TestConsole();
		}
		public TestConsole btn_LavanyaEmail_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Lavanya"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_NoCashOutRefi);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			new TestConsole();
			Thread.Sleep(1000);

			return new TestConsole();
		}
		public TestConsole btn_CoBorrowerEmail_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Co-Borrower:"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_NoCashOutRefi);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			new TestConsole();
			Thread.Sleep(1000);

			return new TestConsole();
		}
        public TestConsole btn_EnterDataManually_Refinance_Click()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_EnterDataManually_Refinance);
            aElement.ClickCenterOfBounds();
            Thread.Sleep(1000);

            return new TestConsole();
        }

        #endregion

        #region Text Boxes
        private PropertyCondition txt_SubjectProperty_Address = new PropertyCondition(AutomationElement.NameProperty, "11: The street address of the subject property. The subject property is the property for which the loan is being obtained.");
		private PropertyCondition txt_SubjectProperty_City = new PropertyCondition(AutomationElement.NameProperty, "12: The city in which the subject property is located.");
		private PropertyCondition txt_SubjectProperty_State = new PropertyCondition(AutomationElement.NameProperty, "14: The state in which the subject property is located.");
		private PropertyCondition txt_SubjectProperty_ZipCode = new PropertyCondition(AutomationElement.NameProperty, "15: The zip code in which the subject property is located.");
		private PropertyCondition txt_SubjectProperty_County = new PropertyCondition(AutomationElement.NameProperty, "13: The county in which the subject property is located.");
		private PropertyCondition txt_EstimatedValue = new PropertyCondition(AutomationElement.NameProperty, "1821: The estimated value of the subject property. The value can be estimated based on information such as the list price, recent sales of similar properties in the area, or recent property tax assessments.");
		private PropertyCondition txt_AppraisedValue = new PropertyCondition(AutomationElement.NameProperty, "356: The appraised value of the subject property.");
		private PropertyCondition txt_LoanAmount = new PropertyCondition(AutomationElement.NameProperty, "1109: The amount of the loan, excluding any funds for PMI/MIP financing.");
		private PropertyCondition txt_PurchasePrice = new PropertyCondition(AutomationElement.NameProperty, "136: The purchase price of the subject property.");
		private PropertyCondition txt_DownPayment = new PropertyCondition(AutomationElement.NameProperty, "1335: The portion of the purchase price paid by the borrower that is not covered by the loan amount or other financing. The Down Payment % (field 1771) will be calculated for you.");
		private PropertyCondition txt_Refinance = new PropertyCondition(AutomationElement.NameProperty, "1092: If this is a refinance loan, the total liens and other debts to be paid from the loan proceeds. Liabilities included in the total are marked as 'to be paid off' on the VOL.");
        private PropertyCondition txt_BorrowerEmail = new PropertyCondition(AutomationElement.NameProperty, "1240: The borrower's home email address.");

        public TestConsole txt_SubjectProperty_Address_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SubjectProperty_Address);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Thread.Sleep(500);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
			Keyboard.Instance.Enter("a");
			Keyboard.Instance.LeaveAllKeys();
			Thread.Sleep(250);
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			aElement.WaitWhileBusy();
			Thread.Sleep(1000);

			return this;
		}
		public TestConsole txt_SubjectProperty_City_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SubjectProperty_City);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Thread.Sleep(500);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
			Keyboard.Instance.Enter("a");
			Keyboard.Instance.LeaveAllKeys();
			Thread.Sleep(250);
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			aElement.WaitWhileBusy();
			Thread.Sleep(1000);

			return this;
		}
		public TestConsole txt_SubjectProperty_State_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SubjectProperty_State);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Thread.Sleep(500);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
			Keyboard.Instance.Enter("a");
			Keyboard.Instance.LeaveAllKeys();
			Thread.Sleep(250);
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			aElement.WaitWhileBusy();
			Thread.Sleep(1000);

			return this;
		}
		public void txt_SubjectProperty_ZipCode_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SubjectProperty_ZipCode);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Thread.Sleep(500);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
			Keyboard.Instance.Enter("a");
			Keyboard.Instance.LeaveAllKeys();
			Thread.Sleep(250);
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			aElement.WaitWhileBusy();
			Thread.Sleep(1000);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
			Thread.Sleep(3000);

		}
		public TestConsole txt_SubjectProperty_County_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SubjectProperty_County);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Thread.Sleep(500);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
			Keyboard.Instance.Enter("a");
			Keyboard.Instance.LeaveAllKeys();
			Thread.Sleep(250);
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			aElement.WaitWhileBusy();
			Thread.Sleep(1000);

			return this;
		}
		public TestConsole txt_EstimatedValue_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_EstimatedValue);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);
			return this;
		}
		public TestConsole txt_AppraisedValue_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_AppraisedValue);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public TestConsole txt_LoanAmount_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_LoanAmount);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Thread.Sleep(250);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
			Keyboard.Instance.Enter("a");
			Keyboard.Instance.LeaveAllKeys();
			Thread.Sleep(250);
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);

			return this;
		}
		public TestConsole txt_PurchasePrice_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_PurchasePrice);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			Thread.Sleep(5000);

			return this;
		}
		public TestConsole txt_DownPayment_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_DownPayment);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			Thread.Sleep(5000);

			return this;
		}
        public TestConsole txt_Refinance_SendKeys(string Input)
        {
            AndCondition andCond = new AndCondition(
                    new PropertyCondition(AutomationElement.AutomationIdProperty, "l_1092"),
                    new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "edit")
                );
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Refinance);
            AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
            item.ClickCenterOfBounds();
            new TestConsole();
            Thread.Sleep(1000);

            return new TestConsole();
        }
        public TestConsole txt_BorrowerEmail_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_BorrowerEmail);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            Thread.Sleep(1000);

            return this;
        }

        #endregion


        #region Combo Boxes

        private PropertyCondition cmb_PartnersLeadSource = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox1");
		
		public TestConsole cmb_PartnersLeadSource_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_PartnersLeadSource);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return new TestConsole();
		}

		#endregion

	}
}
