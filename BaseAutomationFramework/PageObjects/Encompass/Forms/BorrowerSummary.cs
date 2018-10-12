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
	public class BorrowerSummary : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public BorrowerSummary()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();
            aeScreen = Screen.AutomationElement;

            if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		//public static SearchCriteria[] scArray = { EncompassMain.scWindow };
		//public const bool SET_MAXIMIZED = false;

		//public BorrowerSummary()
		//{
		//	iterationCounter++;
		//	DateTime dt1 = DateTime.Now;
		//	Set_Screen(scArray, SET_MAXIMIZED);
		//	DateTime dt2 = DateTime.Now;
		//	Console.WriteLine("Iteration: "+ iterationCounter + " - 1st Wait: " + (dt2-dt1).ToString());
		//	PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
		//	PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.ClassNameProperty, "Internet Explorer_Server");
		//	aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
		//	DateTime dt3 = DateTime.Now;
		//	aeScreen.WaitWhileBusy();
		//	DateTime dt4 = DateTime.Now;
		//	Console.WriteLine("2nd Wait: " + (dt4 - dt3).ToString());
		//	aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
		//	DateTime dt5 = DateTime.Now;
		//	aeScreen.WaitWhileBusy();
		//	DateTime dt6 = DateTime.Now;
		//	Console.WriteLine("3rd Wait: " + (dt6 - dt5).ToString());

		//	if (aeScreen == null)
		//		throw new Exception("Screen is null!!!");
		//}

		public static BorrowerSummary Initialize()
		{
			return new BorrowerSummary();
		}

		public static BorrowerSummary OpenForm_FromFormsTab()
		{
			new FormsTab()
				.lstbx_Forms_SelectForm("Borrower Summary");
				Thread.Sleep(2000);

			return new BorrowerSummary();
		}

		#region Buttons

		private PropertyCondition btn_CopyfromPresent = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button6");
		private PropertyCondition btn_CopyfromBorrower = new PropertyCondition(AutomationElement.NameProperty, "Button1");
		private PropertyCondition btn_OrderCredit = new PropertyCondition(AutomationElement.NameProperty, "Button4");

		//
		public BorrowerSummary btn_CopyfromPresent_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_CopyfromPresent);
			aElement.ClickCenterOfBounds();
			new BorrowerSummary();
			Thread.Sleep(10000);

			return new BorrowerSummary();
		}

		public BorrowerSummary btn_CopyfromBorrower_Click()
		{
				AndCondition andCond = new AndCondition(
						new PropertyCondition(AutomationElement.NameProperty, "Copy From Borrower"),
						new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
					);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_CopyfromBorrower);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			new BorrowerSummary();
			Thread.Sleep(1000);

			return new BorrowerSummary();
		}

		public BorrowerSummary btn_OrderCredit_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Order Credit"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_OrderCredit);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			Thread.Sleep(10000);

			return new BorrowerSummary();
		}

		#endregion

		#region Borrower Fields

		#region Functions

		private void fn_CheckAddressLabel(string StringToCheck, int MaxSecondsToWait = 30)
		{
			PropertyCondition pc = new PropertyCondition(AutomationElement.AutomationIdProperty, "lblStreet");
			for (int i = 0; i < MaxSecondsToWait * 4; i++)
			{
				Thread.Sleep(250);
				Screen = null;
				aElement = null;
				GC.Collect();
				new BorrowerSummary();
				aElement = aeScreen.FindFirst(TreeScope.Descendants, pc);
				if (aElement != null)
					if (aElement.Current.Name.Contains(StringToCheck))
						return;
			}
		}
		private void fn_CheckCSZLabel(string StringToCheck, int MaxSecondsToWait = 30)
		{
			PropertyCondition pc = new PropertyCondition(AutomationElement.AutomationIdProperty, "lblCityStateZip");
			for (int i = 0; i < MaxSecondsToWait * 4; i++)
			{
				Thread.Sleep(250);
				Screen = null;
				aElement = null;
				GC.Collect();
				new BorrowerSummary();
				aElement = aeScreen.FindFirst(TreeScope.Descendants, pc);
				if (aElement != null)
					if (aElement.Current.Name.Contains(StringToCheck))
						return;
			}
		}

		#endregion

		#region Text Boxes
		//Borrower Information
		private PropertyCondition txt_FirstName = new PropertyCondition(AutomationElement.NameProperty, "4000: The borrower's first name.");
		private PropertyCondition txt_LastName = new PropertyCondition(AutomationElement.NameProperty, "4002: The borrower's last name.");
		private PropertyCondition txt_SocialSecurityNumber = new PropertyCondition(AutomationElement.NameProperty, "65: The borrower's social security number.");
		private PropertyCondition txt_DOB = new PropertyCondition(AutomationElement.NameProperty, "1402: The borrower's date of birth.");
		private PropertyCondition txt_HomePhone = new PropertyCondition(AutomationElement.NameProperty, "66: The borrower's home phone number in the format nnn-nnn-nnnn nnnn.");
		private PropertyCondition txt_MaritalStatus = new PropertyCondition(AutomationElement.NameProperty, "1490: The borrower's cell phone number.");
		private PropertyCondition txt_HomeEmail = new PropertyCondition(AutomationElement.NameProperty, "1240: The borrower's home email address.");
		//Present Address
		private PropertyCondition txt_PresentAddress = new PropertyCondition(AutomationElement.NameProperty, "FR0104: The borrower's present street address.");
		private PropertyCondition txt_PresentCity = new PropertyCondition(AutomationElement.NameProperty, "FR0106: The city in which the borrower's present address is located.");
		private PropertyCondition txt_PresentState = new PropertyCondition(AutomationElement.NameProperty, "FR0107: The state in which the borrower's present address is located.");
		private PropertyCondition txt_PresentZip = new PropertyCondition(AutomationElement.NameProperty, "FR0108: The zip code in which the borrower's present address is located.");
		private PropertyCondition txt_NumberofYears = new PropertyCondition(AutomationElement.NameProperty, "FR0112: The number of years and months at the present address.");
		private PropertyCondition txt_NumberofMonths = new PropertyCondition(AutomationElement.NameProperty, "FR0124: The number of years and months at the present address.");
		//Credit Information
		private PropertyCondition txt_ExperianFICO = new PropertyCondition(AutomationElement.NameProperty, "67: The borrower's credit score as reported by Experian/FICO. If you order credit through the service provider network, the credit score is automatically populated when you import the returned report.");
		private PropertyCondition txt_TransUnionEmpirica = new PropertyCondition(AutomationElement.NameProperty, "1450: The borrower's credit score as reported by Trans Union/Empirica. If you order credit through the service provider network, the credit score is automatically populated when you import the returned report.");
		private PropertyCondition txt_EquifaxBEACON = new PropertyCondition(AutomationElement.NameProperty, "1414: The borrower's credit score as reported by Equifax/BEACON. If you order credit through the service provider network, the credit score is automatically populated when you import the returned report.");
		//Subject Property Information
		private PropertyCondition txt_SubjectProperty_Address = new PropertyCondition(AutomationElement.NameProperty, "11: The street address of the subject property. The subject property is the property for which the loan is being obtained.");
		private PropertyCondition txt_SubjectProperty_City = new PropertyCondition(AutomationElement.NameProperty, "12: The city in which the subject property is located.");
		private PropertyCondition txt_SubjectProperty_State = new PropertyCondition(AutomationElement.NameProperty, "14: The state in which the subject property is located.");
		private PropertyCondition txt_SubjectProperty_ZipCode = new PropertyCondition(AutomationElement.NameProperty, "15: The zip code in which the subject property is located.");
		private PropertyCondition txt_EstimatedValue = new PropertyCondition(AutomationElement.NameProperty, "1821: The estimated value of the subject property. The value can be estimated based on information such as the list price, recent sales of similar properties in the area, or recent property tax assessments.");
		private PropertyCondition txt_AppraisedValue = new PropertyCondition(AutomationElement.NameProperty, "356: The appraised value of the subject property.");
        //Transaction Details
        private PropertyCondition txt_LoanNumber = new PropertyCondition(AutomationElement.NameProperty, "364: The alpha-numeric identifier assigned to the loan. You can use the Auto Loan Numbering feature to automatically create a loan number when a loan is started or sent to processing, or you can type a loan number.");
        private PropertyCondition txt_DownPaymentPercent = new PropertyCondition(AutomationElement.NameProperty, "1771: Percent of the purchase price paid by the borrower that is not covered by the loan amount or other financing. The dollar value of the down payment (field 1335) will be calculated for you.");
		private PropertyCondition txt_DownPayment = new PropertyCondition(AutomationElement.NameProperty, "1335: The portion of the purchase price paid by the borrower that is not covered by the loan amount or other financing. The Down Payment % (field 1771) will be calculated for you.");
		private PropertyCondition txt_DueIn = new PropertyCondition(AutomationElement.NameProperty, "325: Length of time in months before the principal balance is due. For a fully amortizing loan, this field is equal to the amortization term (field 4). For a balloon loan, this field is less than the amortization term.");
		private PropertyCondition txt_EstClosingDate = new PropertyCondition(AutomationElement.NameProperty, "763: The loan's estimated closing date.");
		private PropertyCondition txt_LastRateSetDate = new PropertyCondition(AutomationElement.NameProperty, "3253: For compliance with Section 35 HPML, the date when the interest rate for the loan was last set. For example, if you do not issue rate locks, enter the date when the interest rate was last set or revised. If you lock rates and you want to keep the original lock period as defined by the Lock Date (field ID: 761) and the # of Days (field ID: 432), use this field to enter the date when the rate is revised. In Encompass360 Banker Edition, the date is copied from the Secondary Lock tool when the most recent lock request is locked and confirmed.");
		private PropertyCondition txt_Lender = new PropertyCondition(AutomationElement.NameProperty, "1264: The name of the lender. Right-click to select a lender from your business contacts, or type a company name.");
		private PropertyCondition txt_LoanAmount = new PropertyCondition(AutomationElement.NameProperty, "1109: The amount of the loan, excluding any funds for PMI/MIP financing.");
		private PropertyCondition txt_LoanProgram = new PropertyCondition(AutomationElement.NameProperty, "1401: The Loan Program associated with the loan. Click the Find icon to view details of the current selection or select a different program.");
		private PropertyCondition txt_LockDate = new PropertyCondition(AutomationElement.NameProperty, "761: The date when the rate lock is set for the loan.");
		private PropertyCondition txt_LockExpires = new PropertyCondition(AutomationElement.NameProperty, "762: The date the rate lock expires, calculated by adding the value in the # of Days field to the date in the Lock Date field. Your system administrator can also set the start date for the calculation to the day after the lock date. The status of the Rate Lock icon in the loan header is based on the date in this field.");
		private PropertyCondition txt_MonthlyPayment = new PropertyCondition(AutomationElement.NameProperty, "5: The calculated monthly principal and interest payment.");
		private PropertyCondition txt_NoteRate = new PropertyCondition(AutomationElement.NameProperty, "3: The interest rate of the loan.");
		private PropertyCondition txt_NumberOfDays = new PropertyCondition(AutomationElement.NameProperty, "432: The number of days the rate lock is in effect.");
		private PropertyCondition txt_PurchasePrice = new PropertyCondition(AutomationElement.NameProperty, "136: The purchase price of the subject property.");
		private PropertyCondition txt_QualRate = new PropertyCondition(AutomationElement.NameProperty, "1014: The rate, if any, to qualify for the loan. Qualifying rates are typically used with loans whose rates can adjust during the life of the loan, such as an ARM. The borrower is qualified at a rate that is higher than the note rate to ensure the ability to make larger payments.");
		private PropertyCondition txt_RateLockDescription = new PropertyCondition(AutomationElement.NameProperty, "431: A description of the rate lock.");
		private PropertyCondition txt_Term = new PropertyCondition(AutomationElement.NameProperty, "4: The amortization term, or the length of time (in months) over which the payments for the loan are spread. For a fully amortized loan, the amortization term and payment term (field 325) are the same. For a balloon loan, the amortization term is longer.");
		private PropertyCondition txt_TotalMonthlyPayment = new PropertyCondition(AutomationElement.NameProperty, "912: The total monthly housing expense for the subject property. The value is populated from the total proposed expenses in the Monthly Housing Expense section of the 1003 Page 2. Click the Edit icon to calculate the value.");
		private PropertyCondition txt_UnDiscountedRate = new PropertyCondition(AutomationElement.NameProperty, "3293: The rate at par pricing: the rate the borrower would pay if there were no discount points.");
		//Purchase - Additional Information
		private PropertyCondition txt_SellingAgentName = new PropertyCondition(AutomationElement.NameProperty, "VEND.X133: The name of the buyer's real estate agent. Right-click to select an agent from your business contacts, or type an agent name.");
		private PropertyCondition txt_SellingAgentCellPhone = new PropertyCondition(AutomationElement.NameProperty, "VEND.X500: The buyer's agent's cell phone number.");
		private PropertyCondition txt_ListingAgentName = new PropertyCondition(AutomationElement.NameProperty, "VEND.X144: The name of the seller's real estate agency. Right-click to select a company from your business contacts, or type a company name.");
		private PropertyCondition txt_ListingAgentCellPhone = new PropertyCondition(AutomationElement.NameProperty, "VEND.X501: The seller's agent's cell phone number.");
		private PropertyCondition txt_EstEscrowCloseDate = new PropertyCondition(AutomationElement.NameProperty, "CX.EST.ESCROW.CLOSE.DT");


		//Borrower Information
		public BorrowerSummary txt_FirstName_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_FirstName);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			aElement.WaitWhileBusy();
			Thread.Sleep(1000);

			return new BorrowerSummary();
		}
		public BorrowerSummary txt_LastName_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_LastName);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			aElement.WaitWhileBusy();
			Thread.Sleep(1000);

			return new BorrowerSummary();
		}
		public BorrowerSummary txt_SocialSecurityNumber_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SocialSecurityNumber);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public BorrowerSummary txt_DOB_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_DOB);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(1000);

			return this;
		}
		public BorrowerSummary txt_HomePhone_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_HomePhone);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);

			return new BorrowerSummary();
		}
		public BorrowerSummary txt_MaritalStatus_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_MaritalStatus);
			aElement.SetFocus();
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			Thread.Sleep(500);
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(1000);

			return this;
		}
		public BorrowerSummary txt_HomeEmail_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_HomeEmail);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		//Present Address
		public BorrowerSummary txt_PresentAddress_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_PresentAddress);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(1000);

			return this;
		}
		public BorrowerSummary txt_PresentCity_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_PresentCity);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public BorrowerSummary txt_PresentState_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_PresentState);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public BorrowerSummary txt_PresentZip_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_PresentZip);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			Thread.Sleep(1000);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
			Thread.Sleep(3000);

			return this;
		}
		public BorrowerSummary txt_NumberofYears_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_NumberofYears);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public BorrowerSummary txt_NumberofMonths_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_NumberofMonths);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		//Credit Information
		public BorrowerSummary txt_ExperianFICO_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_ExperianFICO);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public BorrowerSummary txt_TransUnionEmpirica_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_TransUnionEmpirica);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public BorrowerSummary txt_EquifaxBEACON_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_EquifaxBEACON);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		//Subject Property Information
		public BorrowerSummary txt_EstimatedValue_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_EstimatedValue);
			EnterTextToTextBox(aElement, Input);
			//aElement.SetFocus();
			//aElement.ClickCenterOfBounds();
			//Keyboard.Instance.Enter(Input);
			//Thread.Sleep(500);
   //         Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);

            return this;
		}
		public BorrowerSummary txt_AppraisedValue_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_AppraisedValue);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public BorrowerSummary txt_SubjectProperty_ZipCode_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SubjectProperty_ZipCode);			
			EnterTextToTextBox(aElement, Input);
			//aElement.SetFocus();
			//aElement.ClickCenterOfBounds();
			//Keyboard.Instance.Enter(Input);
			//Thread.Sleep(750);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			//fn_CheckCSZLabel(Input);

			return new BorrowerSummary();
		}
		public BorrowerSummary txt_SubjectProperty_Address_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SubjectProperty_Address);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			//fn_CheckAddressLabel(Input);

			return new BorrowerSummary();
		}
		public BorrowerSummary txt_SubjectProperty_City_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SubjectProperty_City);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(1000);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			fn_CheckCSZLabel(Input);

			return new BorrowerSummary();
		}
		public BorrowerSummary txt_SubjectProperty_State_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SubjectProperty_State);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			fn_CheckCSZLabel(Input);

			return new BorrowerSummary();
		}
		//Transaction Details
		public BorrowerSummary txt_PurchasePrice_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_PurchasePrice);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			Thread.Sleep(5000);

			return this;
		}
		public BorrowerSummary txt_LoanAmount_SendKeys(string Input)
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
        public BorrowerSummary CopyLoanNumber()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_LoanNumber);
            aElement.SetFocus();
            aElement.ClickCenterOfBounds(); Thread.Sleep(500);
            Mouse.LeftDown(); Mouse.LeftUp(); Mouse.LeftDown(); Mouse.LeftUp(); Thread.Sleep(1000);
            Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            Keyboard.Instance.Enter("c");
            Keyboard.Instance.LeaveAllKeys();
            Thread.Sleep(1000);

            return this;
        }

        //Purchase - Additional Information
        public BorrowerSummary txt_SellingAgentName_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SellingAgentName);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public BorrowerSummary txt_SellingAgentCellPhone_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SellingAgentCellPhone);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public BorrowerSummary txt_ListingAgentName_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_ListingAgentName);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public BorrowerSummary txt_ListingAgentCellPhone_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_ListingAgentCellPhone);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public BorrowerSummary txt_EstEscrowCloseDate_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_EstEscrowCloseDate);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
        public BorrowerSummary txt_Term_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Term);
            aElement.SetFocus();
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(1000);

            return this;
        }
        public BorrowerSummary txt_NoteRate_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_NoteRate);
            aElement.SetFocus();
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(1000);

            return this;
        }


        #endregion

        #region Combo Boxes
        //Borrower Information
        private PropertyCondition cmb_MaritalStatus = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox2");
		//Information for Government Monitoring
		private PropertyCondition cmb_InformationProvidedBy = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox16");
		//Subject Property Information
		private PropertyCondition cmb_PropertyType = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox4");

		//Borrower Information
		//public BorrowerSummary cmb_MaritalStatus_SendKeys(string Input)
		//{
		//	if (allElements == null)
		//		for (int i = 0; i < 30; i++)
		//		{
		//			aeScreen = null;
		//			Screen = null;
		//			GC.Collect();
		//			new BorrowerSummary();
		//			Thread.Sleep(5000);
		//			allElements = null;
		//			allElements = new AutomationElement[623];
		//			aeScreen.FindAll(TreeScope.Descendants, Condition.TrueCondition).CopyTo(allElements, 0);
		//			if (allElements[623 - 1] != null)
		//				break;
		//		}
		//	aElement = null;
		//	aElement = Array.Find(allElements, x => x.Current.AutomationId == "DropdownBox2");			
		//	if (aElement == null)
		//		throw new Exception("Control not found!!!");

		//	AndCondition andCond = new AndCondition(
		//			new PropertyCondition(AutomationElement.NameProperty, Input),
		//			new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "list item")
		//		);			
		//	aElement.SetFocus();
		//	aElement.ClickCenterOfBounds();
		//	Thread.Sleep(1000);
		//	new BorrowerSummary();
		//	AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
		//	item.ClickCenterOfBounds();
		//	Thread.Sleep(500);

		//	return new BorrowerSummary();
		//}
		//Information for Government Monitoring

		public BorrowerSummary cmb_InformationProvidedBy_SendKeys(string Input)
		{
            aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_InformationProvidedBy);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);

            return this;

            //        AndCondition andCond = new AndCondition(
            //	new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox16"),
            //	new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "combo box")
            //);

            //        //aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_InformationProvidedBy);
            //        AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
            //        item.ClickCenterOfBounds();
            //       // aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
            //       // aElement.SetFocus();
            //       // aElement.ClickCenterOfBounds();
            //        Keyboard.Instance.Enter(Input);
            //        Thread.Sleep(1000);
            //        Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            //        Thread.Sleep(1000);
            //        new BorrowerSummary();
        }

		//Subject Property Information
		public BorrowerSummary cmb_PropertyType_SendKeys(string Input)
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, Input),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "list item")
				);

			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_PropertyType);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Thread.Sleep(1000);
			new BorrowerSummary();
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			Thread.Sleep(500);

			return new BorrowerSummary();
		}
	
		#endregion

		#region Checkboxes
		//Transaction Details
		private SearchCriteria chk_CopyLoanNumberToLenderCaseNumber = SearchCriteria.ByAutomationId("__cid_CheckBox9_Ctrl");
		private SearchCriteria chk_TransactionDetailsTX50a6 = SearchCriteria.ByAutomationId("__cid_CheckBox30_Ctrl");
		private SearchCriteria chk_TransactionDetailsLPMI = SearchCriteria.ByAutomationId("__cid_CheckBox39_Ctrl");
		private SearchCriteria chk_TransactionDetailsBRW = SearchCriteria.ByAutomationId("__cid_CheckBox38_Ctrl");
		private SearchCriteria chk_TransactionDetailsMCC = SearchCriteria.ByAutomationId("__cid_CheckBox37_Ctrl");
		private SearchCriteria chk_BorrowerVerbalAuthForCreditPull = SearchCriteria.ByAutomationId("__cid_CheckBox26_Ctrl");
		//Present Address
		//public BorrowerSummary chk_PresentAddress_OwnRent_Check(string OwnOrRent)
		//{
		//	string id = "";
		//	switch (OwnOrRent.ToLower())
		//	{
		//		case "Own": id = "__cid_CheckBox1_Ctrl"; break;
		//		case "Rent": id = "__cid_CheckBox2_Ctrl"; break;
		//		default: throw new Exception("Did not specify a proper input!!!");
		//	}
		//	aElement = aeScreen.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, id));
		//	setLegacyIAccessiblePattern(aElement);
		//	if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
		//		DoDefaultAction(aElement);

		//	return this;
		//}
		public BorrowerSummary chk_PresentAddress_OwnRent_Check(string PresentAddress_OwnRent)
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, PresentAddress_OwnRent),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "check box")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);

			return this;
		}

		//Purpose of Loan
		public BorrowerSummary chk_LoanPurpose_Check(string LoanPurpose)
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, LoanPurpose),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "check box")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);

			return this;
		}
		//Property Will Be
		public BorrowerSummary chk_PropertyWillBe_Check(string PropertyWillBe)
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, PropertyWillBe),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "check box")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);
			Thread.Sleep(500);

			return new BorrowerSummary();
		}
		//Amortization Type
		public BorrowerSummary chk_AmortizationType_Check(string AmortizationType)
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, AmortizationType),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "check box")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);
			Thread.Sleep(500);

			return new BorrowerSummary();
		}
		//Credit Pull
			public BorrowerSummary chk_BorrowerVerbalAuthForCreditPull_Check(bool Check)
			{
				ClickCheckBox(Check, chk_BorrowerVerbalAuthForCreditPull);
				Thread.Sleep(2000);

			return this;
			}

		#endregion

		#endregion

		#region Co-Borrower Fields

		#region Text Boxes
		//Co-Borrower Information
		private PropertyCondition txt_CoBorrowerFirstName = new PropertyCondition(AutomationElement.NameProperty, "4004: The co-borrower's first name. A co-borrower (along with the borrower) accepts responsibility for repaying the loan.");
		private PropertyCondition txt_CoBorrowerSocialSecurityNumber = new PropertyCondition(AutomationElement.NameProperty, "97: The co-borrower's social security number.");
		private PropertyCondition txt_CoBorrowerDOB = new PropertyCondition(AutomationElement.NameProperty, "1403: The co-borrower's date of birth.");
		private PropertyCondition txt_CoBorrowerHomeEmail = new PropertyCondition(AutomationElement.NameProperty, "1268: The co-borrower's home email address.");
		//Co-Borrower Credit Information
		private PropertyCondition txt_CoBorrowerExperianFICO = new PropertyCondition(AutomationElement.NameProperty, "60: The co-borrower's credit score as reported by Experian/FICO. If you order credit through the service provider network, the credit score is automatically populated when you import the returned report.");
		private PropertyCondition txt_CoBorrowerTransUnionEmpirica = new PropertyCondition(AutomationElement.NameProperty, "1452: The co-borrower's credit score as reported by Trans Union/Empirica. If you order credit through the service provider network, the credit score is automatically populated when you import the returned report.");
		private PropertyCondition txt_CoBorrowerEquifaxBEACON = new PropertyCondition(AutomationElement.NameProperty, "1415: The co-borrower's credit score as reported by Equifax/BEACON. If you order credit through the service provider network, the credit score is automatically populated when you import the returned report.");
		
		//Co-Borrower Information
		public BorrowerSummary txt_CoBorrowerFirstName_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CoBorrowerFirstName);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			aElement.WaitWhileBusy();
			Thread.Sleep(1000);

			return new BorrowerSummary();
		}
		public BorrowerSummary txt_CoBorrowerSocialSecurityNumber_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CoBorrowerSocialSecurityNumber);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public BorrowerSummary txt_CoBorrowerDOB_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CoBorrowerDOB);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public BorrowerSummary txt_CoBorrowerHomeEmail_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CoBorrowerHomeEmail);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		//Co-Borrower Credit Information
		public BorrowerSummary txt_CoBorrowerExperianFICO_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CoBorrowerExperianFICO);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public BorrowerSummary txt_CoBorrowerTransUnionEmpirica_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CoBorrowerTransUnionEmpirica);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public BorrowerSummary txt_CoBorrowerEquifaxBEACON_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CoBorrowerEquifaxBEACON);
			aElement.ClickCenterOfBounds();
			Keyboard.Instance.Enter(Input);

			return this;
		}

		#endregion

		#region Combo Boxes
		//Co-Borrower Information for Government Monitoring
		private PropertyCondition cmb_CoBorrowerSex = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox15");
		private PropertyCondition cmb_CoBorrowerEthnicity = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox14");

		//Co-Borrower Information for Government Monitoring
		public BorrowerSummary cmb_CoBorrowerSex_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_CoBorrowerSex);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public BorrowerSummary cmb_CoBorrowerEthnicity_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_CoBorrowerEthnicity);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}

		#endregion

		#region Checkboxes

		//Co-Borrower Information for Government Monitoring
		public BorrowerSummary chk_CoBorrower_Race_Check(string CoBorrowerRace)
		{
			string id = "";
			switch (CoBorrowerRace)
			{
				case "American Indian or Alaska Native": id = "__cid_CheckBox59_Ctrl"; break;
				case "Asian": id = "__cid_CheckBox60_Ctrl"; break;
				case "Black or African American": id = "__cid_CheckBox61_Ctrl"; break;
				case "Native Hawaiian or Other Pac. Islander": id = "__cid_CheckBox62_Ctrl"; break;
				case "White": id = "__cid_CheckBox63_Ctrl"; break;
				case "Information not provided": id = "__cid_CheckBox64_Ctrl"; break;
				default: throw new Exception("Did not specify a proper race!!!");
			}

			aElement = aeScreen.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, id));
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);

			return this;
		}
		
		#endregion

		#endregion

	}
}
