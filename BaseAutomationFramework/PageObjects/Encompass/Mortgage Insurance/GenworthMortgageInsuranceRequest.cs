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
	public class GenworthMortgageInsuranceRequest : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("CGenPropertySheet");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		private AutomationElement aePanel = null;

		public GenworthMortgageInsuranceRequest()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
            aePanel = null;
        }

        public static GenworthMortgageInsuranceRequest Initialize()
        {
            return new GenworthMortgageInsuranceRequest();
        }

        #region Panel

        private PropertyCondition pne_MainPanel = new PropertyCondition(AutomationElement.AutomationIdProperty, "lblCertID");
        //
        private void SetPanel()
        {
            int i = 0;
            do
            {
                aePanel = null;
                aeScreen = null;
                Screen = null;
                GC.Collect();
                new GenworthMortgageInsuranceRequest();
                Thread.Sleep(1000);
                aePanel = Screen.AutomationElement.FindFirst(TreeScope.Descendants, pne_MainPanel);

            } while (aePanel == null && i++ < 60);
            if (aePanel == null)
                throw new Exception("Could not find the embedded IE panel!!!");
        }

        #endregion


        #region Combo Boxes

        private PropertyCondition cmb_PremiumPaymentOption = new PropertyCondition(AutomationElement.AutomationIdProperty, "cboDuration");

        public GenworthMortgageInsuranceRequest cmb_PremiumPaymentOption_SendKeys(string Input)
        {
            SetPanel();
            aElement = aePanel.FindFirst(TreeScope.Descendants, cmb_PremiumPaymentOption);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(1000);

            return this;
        }

        #endregion

        #region Textboxes

        private PropertyCondition txt_MI_Coverage = new PropertyCondition(AutomationElement.AutomationIdProperty, "txtCoveragePercentage");

        public GenworthMortgageInsuranceRequest txt_MI_Coverage_SendKeys(string Input)
        {
            SetPanel();
            aElement = aePanel.FindFirst(TreeScope.Descendants, txt_MI_Coverage);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(1000);

            return this;
        }

        #endregion

        #region Checkboxes
        private SearchCriteria chk_PremiumFinanced = SearchCriteria.ByAutomationId("cbPremiumFinanced");

        public GenworthMortgageInsuranceRequest chk_PremiumFinanced_Check(bool Check)
        {
            ClickCheckBox(Check, chk_PremiumFinanced);
            Thread.Sleep(2000);

            return this;
        }

        #endregion

        #region Buttons

        private SearchCriteria btn_RateQuote = SearchCriteria.ByAutomationId("btnNext");
        private SearchCriteria btn_Cancel = SearchCriteria.ByAutomationId("btnCancel");

        //
        public void btn_RateQuote_Click()
		{
			GetButton(btn_RateQuote).Click();
		}
        public void btn_Cancel_Click()
        {
            GetButton(btn_Cancel).Click();
        }

        #endregion
    }
}