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
	public class ClosingDisclosurePage5 : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public ClosingDisclosurePage5()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

        public static ClosingDisclosurePage5 Initialize()
        {
            return new ClosingDisclosurePage5();
        }

		public static ClosingDisclosurePage5 OpenForm_FromFormsTab()
		{
			new FormsTab()
				.lstbx_Forms_SelectForm("Closing Disclosure Page 5");

			return new ClosingDisclosurePage5();
		}

        //public ClosingDisclosurePage5 GetFirstCheckBoxState(out bool IsChecked)
        //{
        //    IsChecked = Screen.AutomationElement.GetCurrentPropertyValue()
        //    return this;
        //}
        //public ClosingDisclosurePage5 GetSecondCheckBoxState(out bool IsChecked)
        //{
        //    IsChecked = Screen.Get<CheckBox>(chk_StateLawDoesNotProtect).AutomationElement.xtGetCheckedState();
        //    return this;
        //}

        #region Checkboxes

        private PropertyCondition chk_StateLawMayProtect = new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox1_Ctrl");
        private PropertyCondition chk_StateLawDoesNotProtect = new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox2_Ctrl");

        public ClosingDisclosurePage5 chk_StateLawMayProtect_Check()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, chk_StateLawMayProtect);
            setLegacyIAccessiblePattern(aElement);
            if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Uncheck")
                DoDefaultAction(aElement);

            return this;
        }
        public ClosingDisclosurePage5 chk_StateLawDoesNotProtect_Check()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, chk_StateLawDoesNotProtect);
            setLegacyIAccessiblePattern(aElement);
            if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Uncheck")
                DoDefaultAction(aElement);

            return this;
        }

        #endregion

        #region Textboxes

        private PropertyCondition txt_SettlementAgentName = new PropertyCondition(AutomationElement.AutomationIdProperty, "TextBox31");
        private PropertyCondition txt_SettlementAgentAddress = new PropertyCondition(AutomationElement.AutomationIdProperty, "TextBox32");
        private PropertyCondition txt_SettlementAgentCity = new PropertyCondition(AutomationElement.AutomationIdProperty, "TextBox33");
        private PropertyCondition txt_SettlementAgentState = new PropertyCondition(AutomationElement.AutomationIdProperty, "TextBox34");
        private PropertyCondition txt_SettlementAgentZip = new PropertyCondition(AutomationElement.AutomationIdProperty, "l_59");
        private PropertyCondition txt_SettlementAgentContact = new PropertyCondition(AutomationElement.AutomationIdProperty, "TextBox38");
        private PropertyCondition txt_SettlementAgentEmail = new PropertyCondition(AutomationElement.AutomationIdProperty, "TextBox41");
        private PropertyCondition txt_SettlementAgentPhone = new PropertyCondition(AutomationElement.AutomationIdProperty, "TextBox42");

        public ClosingDisclosurePage5 txt_SettlementAgentName_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SettlementAgentName);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }
        public ClosingDisclosurePage5 txt_SettlementAgentAddress_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SettlementAgentAddress);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }
        public ClosingDisclosurePage5 txt_SettlementAgentCity_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SettlementAgentCity);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }
        public ClosingDisclosurePage5 txt_SettlementAgentState_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SettlementAgentState);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }
        public ClosingDisclosurePage5 txt_SettlementAgentZip_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SettlementAgentZip);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }
        public ClosingDisclosurePage5 txt_SettlementAgentContact_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SettlementAgentContact);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }
        public ClosingDisclosurePage5 txt_SettlementAgentEmail_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SettlementAgentEmail);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }
        public ClosingDisclosurePage5 txt_SettlementAgentPhone_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SettlementAgentPhone);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }

        #endregion

        #region Loan Type Methods

        public ClosingDisclosurePage5 CompleteFields_SettlementAgent()
        {
            txt_SettlementAgentName_SendKeys("test")
            .txt_SettlementAgentAddress_SendKeys("test")
            .txt_SettlementAgentCity_SendKeys("Burbank")
            .txt_SettlementAgentState_SendKeys("CA")
            .txt_SettlementAgentZip_SendKeys("91502")
            .txt_SettlementAgentContact_SendKeys("test")
            .txt_SettlementAgentEmail_SendKeys("test@test.com")
            .txt_SettlementAgentPhone_SendKeys("876-654-6757");

            return this;
        }

        #endregion

    }
}