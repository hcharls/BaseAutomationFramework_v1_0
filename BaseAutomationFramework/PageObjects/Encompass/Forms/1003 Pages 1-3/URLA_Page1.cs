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
using TestStack.White.Utility;
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class URLA_Page1 : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public URLA_Page1()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static URLA_Page1 OpenForm_FromFormsTab()
		{
			new FormsTab()
				.lstbx_Forms_SelectForm("1003 Page 1");
            Thread.Sleep(2000);

			return new URLA_Page1();
		}

		public void ChangeSubjectProperty(string County, string City, string State, string Zip)
		{
			txt_SubjectProperty_County_SendKeys(County);
			txt_SubjectProperty_City_SendKeys(City);
			txt_SubjectProperty_State_SendKeys(State);
			txt_SubjectProperty_ZipCode_SendKeys(Zip);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);

			//if (Tests.BaseTest.checkForWindow(SelectaCity.scWindow))
			//{
			//	SelectaCity
			//		.Initialize()
			//		.btn_Cancel_Click();
			//}
		}

		#region Text Boxes
		//
		private PropertyCondition txt_NoUnits = new PropertyCondition(AutomationElement.NameProperty, "16: The number of separate living spaces in the subject property. If the loan is for a single-family home, the number of units is 1.");
		private PropertyCondition txt_YearBuilt = new PropertyCondition(AutomationElement.NameProperty, "18: The year in which the subject property was built.");
		private PropertyCondition txt_School = new PropertyCondition(AutomationElement.NameProperty, "39: The number of years of school completed by the borrower.");
		private PropertyCondition txt_Dependents = new PropertyCondition(AutomationElement.NameProperty, "53: The borrower's number of dependents.");
		private PropertyCondition txt_CoBorrowerSchool = new PropertyCondition(AutomationElement.NameProperty, "71: The number of years of school completed by the co-borrower.");
		private PropertyCondition txt_CoBorrowerDependents = new PropertyCondition(AutomationElement.NameProperty, "85: The co-borrower's number of dependents.");
		private PropertyCondition txt_OriginalCost = new PropertyCondition(AutomationElement.NameProperty, "25: The original cost of the property to the borrower.");
		private PropertyCondition txt_ExistingLien = new PropertyCondition(AutomationElement.NameProperty, "26: The amount of any existing liens on the property.");
		private PropertyCondition txt_SubjectProperty_ZipCode = new PropertyCondition(AutomationElement.NameProperty, "15: The zip code in which the subject property is located.");
		private PropertyCondition txt_SubjectProperty_County = new PropertyCondition(AutomationElement.NameProperty, "13: The county in which the subject property is located.");
		private PropertyCondition txt_SubjectProperty_City = new PropertyCondition(AutomationElement.NameProperty, "12: The city in which the subject property is located.");
		private PropertyCondition txt_SubjectProperty_State = new PropertyCondition(AutomationElement.NameProperty, "14: The state in which the subject property is located.");

		//

		public URLA_Page1 txt_NoUnits_SendKeys(string Input)
		{
			Retry.For(() => aeScreen.FindFirst(TreeScope.Descendants, txt_NoUnits).SetFocus(), TimeSpan.FromSeconds(10));
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page1 txt_YearBuilt_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_YearBuilt);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page1 txt_School_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_School);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page1 txt_Dependents_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Dependents);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page1 txt_CoBorrowerSchool_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CoBorrowerSchool);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page1 txt_CoBorrowerDependents_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CoBorrowerDependents);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page1 txt_OriginalCost_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_OriginalCost);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page1 txt_ExistingLien_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_ExistingLien);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

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

		}
		public URLA_Page1 txt_SubjectProperty_County_SendKeys(string Input)
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
		public URLA_Page1 txt_SubjectProperty_City_SendKeys(string Input)
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
		public URLA_Page1 txt_SubjectProperty_State_SendKeys(string Input)
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

		#endregion

		#region Checkboxes

		private PropertyCondition chk_MailingAddress = new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox26_Ctrl");
		private PropertyCondition chk_CoBorrowerMailingAddress = new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox30_Ctrl");

		public URLA_Page1 chk_MailingAddress_Check(string MailingAddress)
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Same as present"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "check box"),
					new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox26_Ctrl")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);

			return this;
		}
		public URLA_Page1 chk_CoBorrowerMailingAddress_Check(string MailingAddress)
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Same as present"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "check box"),
					new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox30_Ctrl")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);

			return this;
		}
		#endregion

		#region Combo Boxes

		private PropertyCondition cmb_SourceofDownPayment = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox2");

		public URLA_Page1 cmb_SourceofDownPayment_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_SourceofDownPayment);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}

		#endregion

		#region Buttons

		private PropertyCondition btn_ShowAllVOE = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button7");

		public URLA_Page1 btn_ShowAllVOE_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_ShowAllVOE);
			aElement.ClickCenterOfBounds();

			return new URLA_Page1();
		}
		#endregion
	}
}