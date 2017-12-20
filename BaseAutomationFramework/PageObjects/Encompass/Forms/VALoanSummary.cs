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
    public class VALoanSummary : BaseScreen
    {
        public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
        public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };//, scWindow };
        public const bool SET_MAXIMIZED = false;
        public VALoanSummary()
        {
            PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
            PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
            aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
            aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
            aeScreen.WaitWhileBusy();

            if (aeScreen == null)
                throw new Exception("Screen is null!!!");
        }

        public static VALoanSummary OpenForm_FromFormsTab()
        {
            new FormsTab()
                .lstbx_Forms_SelectForm("VA 26-0286 Loan Summary");
            Thread.Sleep(250);

            return new VALoanSummary();
        }

        #region Combo Boxes
        private PropertyCondition cmb_VeteranInformationfor = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox1");

        public VALoanSummary cmb_VeteranInformationfor_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_VeteranInformationfor);
            aElement.SetFocus();
            aElement.ClickCenterOfBounds();
            Thread.Sleep(250);
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return new VALoanSummary();
        }

        #endregion

        #region Text Boxes

        private PropertyCondition txt_PaidInFullVALoanNumber = new PropertyCondition(AutomationElement.NameProperty, "VASUMM.X14: For an IRRRL, the VA loan number of the refinanced loan that will be paid off.");
        private PropertyCondition txt_OriginalLoanAmount = new PropertyCondition(AutomationElement.NameProperty, "VASUMM.X15: For an IRRRL, the original amount of the loan being refinanced.");
        private PropertyCondition txt_OriginalIntRate = new PropertyCondition(AutomationElement.NameProperty, "VASUMM.X16: For an IRRRL, the original interest rate of the loan being refinanced. The IRRRL must bear a lower interest rate unless the loan being refinanced is an ARM.");
        private PropertyCondition txt_OriginalTermMths = new PropertyCondition(AutomationElement.NameProperty, "VASUMM.X18");

        public VALoanSummary txt_PaidInFullVALoanNumber_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_PaidInFullVALoanNumber);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }

        public VALoanSummary txt_OriginalLoanAmount_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_OriginalLoanAmount);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }
        public VALoanSummary txt_OriginalIntRate_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_OriginalIntRate);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }

        public VALoanSummary txt_OriginalTermMths_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_OriginalTermMths);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }
        #endregion


    }
}