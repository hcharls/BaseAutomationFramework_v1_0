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
	public class VerificationOfDepository : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("QuickEntryPopupDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		private AutomationElement aePanel = null;

		public VerificationOfDepository()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
			SetPanel();
		}

		public static VerificationOfDepository OpenFromURLA_Page2()
		{
			new URLA_Page2()
				.btn_ShowAllVOD_Click();

			return new VerificationOfDepository();
		}
     
        #region Panel

        private PropertyCondition pne_MainPanel = new PropertyCondition(AutomationElement.ClassNameProperty, "Internet Explorer_Server");
		//
		private void SetPanel()
		{
			for (int i = 0; i < 10; i++)
			{
				Thread.Sleep(250);
				if (this.aePanel == null)
				{
					this.aePanel = Screen.AutomationElement.FindFirst(TreeScope.Descendants, pne_MainPanel);
				}
				else
					break;
			}


		}

		#endregion

		#region Combo Boxes
		private PropertyCondition cmb_VODisfor = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox1");
		private PropertyCondition cmb_AccountType1 = new PropertyCondition(AutomationElement.AutomationIdProperty, "1001");
		private PropertyCondition cmb_AccountType2 = new PropertyCondition(AutomationElement.AutomationIdProperty, "127086524");

		//Borrower Information
		public VerificationOfDepository cmb_VODisfor_SendKeys(string Input)
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, Input),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "list item")
				);

			aElement = aePanel.FindFirst(TreeScope.Descendants, cmb_VODisfor);
			aElement.ClickCenterOfBounds();
			Thread.Sleep(500);
			new VerificationOfDepository();
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();

			return this;
		}
		public VerificationOfDepository cmb_AccountType1_SendKeys(string Input)
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, Input),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "list item")
				);

			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_AccountInNameof_01);
			aElement.ClickCenterOfBounds();
			Thread.Sleep(500);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.SHIFT);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			Keyboard.Instance.LeaveAllKeys();
			Thread.Sleep(250);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.F4);

			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			Thread.Sleep(250);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);

			return this;
		}
		public VerificationOfDepository cmb_AccountType2_SendKeys(string Input)
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, Input),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "list item")
				);

			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_AccountInNameof_02);
			aElement.ClickCenterOfBounds();
			Thread.Sleep(500);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.SHIFT);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			Keyboard.Instance.LeaveAllKeys();
			Thread.Sleep(250);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.F4);

			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			Thread.Sleep(250);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);

			return this;
		}

		#endregion

		#region Text Boxes
		//
		private PropertyCondition txt_AccountInNameof_01 = new PropertyCondition(AutomationElement.NameProperty, "DD0109: The name in which the account is held.");
		private PropertyCondition txt_AccountInNameof_02 = new PropertyCondition(AutomationElement.NameProperty, "DD0113: The name in which the account is held.");
		private PropertyCondition txt_DepositoryName = new PropertyCondition(AutomationElement.NameProperty, "DD0102: The name of the depository.");
		private PropertyCondition txt_DepositoryAttn = new PropertyCondition(AutomationElement.NameProperty, "DD0103: The contact person at the depository who will verify the information on the VOD.");
		private PropertyCondition txt_DepositoryAddress = new PropertyCondition(AutomationElement.NameProperty, "DD0104: The depository's street address.");
		private PropertyCondition txt_DepositoryCity = new PropertyCondition(AutomationElement.NameProperty, "DD0105: The city in which the depository is located.");
		private PropertyCondition txt_DepositoryState = new PropertyCondition(AutomationElement.NameProperty, "DD0106: The state in which the depository is located.");
		private PropertyCondition txt_DepositoryZip = new PropertyCondition(AutomationElement.NameProperty, "DD0107: The zip code in which the depository is located.");
		private PropertyCondition txt_DepositoryPhone = new PropertyCondition(AutomationElement.NameProperty, "DD0126: The depository's phone number in the format nnn-nnn-nnnn nnnn.");
		private PropertyCondition txt_DepositoryEmail = new PropertyCondition(AutomationElement.NameProperty, "DD0128: The depository's email address.");
		private PropertyCondition txt_AccountNumber1 = new PropertyCondition(AutomationElement.NameProperty, "DD0110: The account's identification number.");
		private PropertyCondition txt_AccountBalance1 = new PropertyCondition(AutomationElement.NameProperty, "DD0111: The current balance in the account.");
		private PropertyCondition txt_AccountNumber2 = new PropertyCondition(AutomationElement.NameProperty, "DD0114: The account's identification number.");
		private PropertyCondition txt_AccountBalance2 = new PropertyCondition(AutomationElement.NameProperty, "DD0115: The current balance in the account.");

		private PropertyCondition txt_AccountType1 = new PropertyCondition(AutomationElement.NameProperty, "DD0145: Fax number for the individual at your company who can be contacted with questions regarding the verification.");
		private PropertyCondition txt_AccountType2 = new PropertyCondition(AutomationElement.NameProperty, "DD0111: The current balance in the account.");

		//
		public VerificationOfDepository txt_DepositoryName_SendKeys(string Input)
		{
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_DepositoryName);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfDepository txt_DepositoryAttn_SendKeys(string Input)
		{
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_DepositoryAttn);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfDepository txt_DepositoryAddress_SendKeys(string Input)
		{
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_DepositoryAddress);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfDepository txt_DepositoryCity_SendKeys(string Input)
		{
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_DepositoryCity);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfDepository txt_DepositoryState_SendKeys(string Input)
		{
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_DepositoryState);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfDepository txt_DepositoryZip_SendKeys(string Input)
		{
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_DepositoryZip);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfDepository txt_DepositoryPhone_SendKeys(string Input)
		{
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_DepositoryPhone);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfDepository txt_DepositoryEmail_SendKeys(string Input)
		{
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_DepositoryEmail);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfDepository txt_AccountNumber1_SendKeys(string Input)
		{
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_AccountNumber1);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfDepository txt_AccountBalance1_SendKeys(string Input)
		{
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_AccountBalance1);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfDepository txt_AccountNumber2_SendKeys(string Input)
		{
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_AccountNumber2);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfDepository txt_AccountBalance2_SendKeys(string Input)
		{
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_AccountBalance2);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfDepository txt_AccountType1_SendKeys(string Input)
		{
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_AccountType1);
			aElement.SetFocus();
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfDepository txt_AccountType2_SendKeys(string Input)
		{
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_AccountType2);
			aElement.SetFocus();
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			Thread.Sleep(500);

			return this;
		}

		#endregion

		#region Buttons

		private SearchCriteria btn_VODNewVerif = SearchCriteria.ByAutomationId("btnNew");
		private SearchCriteria btn_VODClose = SearchCriteria.ByAutomationId("btnClose");
		//
		public VerificationOfDepository btn_VODNewVerif_Click()
		{
			GetPanel(btn_VODNewVerif).Click();

			return new VerificationOfDepository();
		}
		public void btn_VODClose_Click()
		{
			GetButton(btn_VODClose).Click();
		}

		#endregion
	}
}