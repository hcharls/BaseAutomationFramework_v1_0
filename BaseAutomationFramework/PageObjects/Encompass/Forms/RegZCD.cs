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
	public class RegZCD : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public RegZCD()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static RegZCD OpenForm_FromFormsTab()
		{
			new FormsTab()
				.lstbx_Forms_SelectForm("RegZ - CD");
				Thread.Sleep(8000);

			return new RegZCD();
		}

		public static RegZCD Initialize()
		{
			return new RegZCD();
		}

		#region Text Boxes

		private PropertyCondition txt_FirstPaymentDate = new PropertyCondition(AutomationElement.AutomationIdProperty, "l_682");
		private PropertyCondition txt_DocumentDate = new PropertyCondition(AutomationElement.AutomationIdProperty, "l_L770");
		private PropertyCondition txt_ClosingDate = new PropertyCondition(AutomationElement.AutomationIdProperty, "l_748");
		private PropertyCondition txt_DocSigningDate = new PropertyCondition(AutomationElement.AutomationIdProperty, "l_1887");
		private PropertyCondition txt_DisbursementDate = new PropertyCondition(AutomationElement.AutomationIdProperty, "l_L244");

		public RegZCD txt_FirstPaymentDate_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_FirstPaymentDate);
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
			Thread.Sleep(5000);

			return this;
		}
		public RegZCD txt_DocumentDate_SendKeys()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_DocumentDate);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Thread.Sleep(500);
            Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            Keyboard.Instance.Enter("a");
            Keyboard.Instance.LeaveAllKeys();
            Thread.Sleep(1000);
            Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
			Keyboard.Instance.Enter("v");
            Keyboard.Instance.LeaveAllKeys();
            Thread.Sleep(1000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			Thread.Sleep(2000);

			return this;
		}
		public RegZCD txt_ClosingDate_SendKeys()
		{
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_ClosingDate);
            aElement.SetFocus();
            aElement.ClickCenterOfBounds();
            Thread.Sleep(500);
            Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            Keyboard.Instance.Enter("a");
            Keyboard.Instance.LeaveAllKeys();
            Thread.Sleep(1000);
            Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            Keyboard.Instance.Enter("v");
            Keyboard.Instance.LeaveAllKeys();
            Thread.Sleep(1000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            Thread.Sleep(2000);

            return this;
		}
		public RegZCD txt_DocSigningDate_SendKeys()
		{
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_DocSigningDate);
            aElement.SetFocus();
            aElement.ClickCenterOfBounds();
            Thread.Sleep(500);
            Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            Keyboard.Instance.Enter("a");
            Keyboard.Instance.LeaveAllKeys();
            Thread.Sleep(1000);
            Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            Keyboard.Instance.Enter("v");
            Keyboard.Instance.LeaveAllKeys();
            Thread.Sleep(1000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            Thread.Sleep(2000);

            return this;

		}
		public RegZCD txt_DisbursementDate_SendKeys()
		{
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_DisbursementDate);
            aElement.SetFocus();
            aElement.ClickCenterOfBounds();
            Thread.Sleep(500);
            Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            Keyboard.Instance.Enter("a");
            Keyboard.Instance.LeaveAllKeys();
            Thread.Sleep(1000);
            Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            Keyboard.Instance.Enter("v");
            Keyboard.Instance.LeaveAllKeys();
            Thread.Sleep(1000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            aElement.WaitWhileBusy();
            Thread.Sleep(1000);

            return this;

		}

		#endregion

		#region Buttons

		private PropertyCondition btn_Audit = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnAudit");
		private PropertyCondition btn_LoanProgram = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button19");

		//
		public RegZCD btn_Audit_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_Audit);
			aElement.ClickCenterOfBounds();
			Thread.Sleep(2000);

			return new RegZCD();
		}
		public RegZCD btn_LoanProgram_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_LoanProgram);
			aElement.ClickCenterOfBounds();
			Thread.Sleep(2000);

			return new RegZCD();
		}

		#endregion
	}
}
