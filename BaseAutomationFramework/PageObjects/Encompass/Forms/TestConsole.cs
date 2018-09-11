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

        #region Radio Buttons

        private SearchCriteria rdb_Conventional = SearchCriteria.ByAutomationId("__cid_RadioButton4_Ctrl");
        private SearchCriteria rdb_FHA = SearchCriteria.ByAutomationId("__cid_RadioButton5_Ctrl");
        private SearchCriteria rdb_VA = SearchCriteria.ByAutomationId("__cid_RadioButton6_Ctrl");
        private SearchCriteria rdb_Purchase = SearchCriteria.ByAutomationId("__cid_RadioButton1_Ctrl");
        private SearchCriteria rdb_CashOutRefi = SearchCriteria.ByAutomationId("__cid_RadioButton2_Ctrl");
        private SearchCriteria rdb_NoCashOutRefi = SearchCriteria.ByAutomationId("__cid_RadioButton3_Ctrl");
        private SearchCriteria rdb_Direct = SearchCriteria.ByAutomationId("__cid_RadioButton7_Ctrl");
        private SearchCriteria rdb_Partners = SearchCriteria.ByAutomationId("__cid_RadioButton9_Ctrl");
        private SearchCriteria rdb_Phoenix = SearchCriteria.ByAutomationId("__cid_RadioButton10_Ctrl");
        private SearchCriteria rdb_FixedRate = SearchCriteria.ByAutomationId("__cid_RadioButton8_Ctrl");
        private SearchCriteria rdb_ARM = SearchCriteria.ByAutomationId("__cid_RadioButton11_Ctrl");
        //
        public TestConsole rdb_Conventional_Select()
        {
            GetRadioButton(rdb_Conventional).Click();

            return new TestConsole();
        }
        public TestConsole rdb_FHA_Select()
        {
            GetRadioButton(rdb_FHA).Click();

            return new TestConsole();
        }
        public TestConsole rdb_VA_Select()
        {
            GetRadioButton(rdb_VA).Click();

            return new TestConsole();
        }
        public TestConsole rdb_Purchase_Select()
        {
            GetRadioButton(rdb_Purchase).Click();

            return new TestConsole();
        }
        public TestConsole rdb_CashOutRefi_Select()
        {
            GetRadioButton(rdb_CashOutRefi).Click();

            return new TestConsole();
        }
        public TestConsole rdb_NoCashOutRefi_Select()
        {
            GetRadioButton(rdb_NoCashOutRefi).Click();

            return new TestConsole();
        }
        public TestConsole rdb_Direct_Select()
        {
            GetRadioButton(rdb_Direct).Click();

            return new TestConsole();
        }
        public TestConsole rdb_Partners_Select()
        {
            GetRadioButton(rdb_Partners).Click();

            return new TestConsole();
        }
        public TestConsole rdb_Phoenix_Select()
        {
            GetRadioButton(rdb_Phoenix).Click();

            return new TestConsole();
        }
        public TestConsole rdb_FixedRate_Select()
        {
            GetRadioButton(rdb_FixedRate).Click();

            return new TestConsole();
        }
        public TestConsole rdb_ARM_Select()
        {
            GetRadioButton(rdb_ARM).Click();

            return new TestConsole();
        }
        #endregion

        #region Buttons

        private PropertyCondition btn_BLSCertification = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button16");
        private PropertyCondition btn_RunProductAndPricing = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button26");
        private PropertyCondition btn_GoToDisclosurePrep = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button25");
        private PropertyCondition btn_AddCoBorrower = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button15");
        private PropertyCondition btn_RemoveCoBorrower = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button1");
        private PropertyCondition btn_AddDisclosureRecord = new PropertyCondition(AutomationElement.AutomationIdProperty, "AddRecord");
        private PropertyCondition btn_FancyMilestones = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button28");

        //
        public TestConsole btn_BLSCertification_Click()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_BLSCertification);
            aElement.ClickCenterOfBounds();
            new TestConsole();
            Thread.Sleep(1000);

            return new TestConsole();
        }
        public TestConsole btn_RunProductAndPricing_Click()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_RunProductAndPricing);
            aElement.ClickCenterOfBounds();
            new TestConsole();
            Thread.Sleep(1000);

            return new TestConsole();
        }
        public TestConsole btn_GoToDisclosurePrep_Click()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_GoToDisclosurePrep);
            aElement.ClickCenterOfBounds();
            new TestConsole();
            Thread.Sleep(1000);

            return new TestConsole();
        }
        public TestConsole btn_CreateNewLoan_Click(string input)
        {
            AndCondition andCond = new AndCondition(
                    new PropertyCondition(AutomationElement.NameProperty, input),
                    new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
                );
            aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
            AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
            item.ClickCenterOfBounds();
            new TestConsole();
            Thread.Sleep(1000);

            return new TestConsole();
        }
        public TestConsole btn_AddCoBorrower_Click()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_AddCoBorrower);
            aElement.ClickCenterOfBounds();
            new TestConsole();
            Thread.Sleep(1000);

            return new TestConsole();
        }
        public TestConsole btn_RemoveCoBorrower_Click()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_RemoveCoBorrower);
            aElement.ClickCenterOfBounds();
            new TestConsole();
            Thread.Sleep(1000);

            return new TestConsole();
        }
        public TestConsole btn_AddDisclosureRecord_Click()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_AddDisclosureRecord);
            aElement.ClickCenterOfBounds();
            new TestConsole();
            Thread.Sleep(1000);

            return new TestConsole();
        }
        public TestConsole btn_FancyMilestones_Click()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_FancyMilestones);
            aElement.ClickCenterOfBounds();
            new TestConsole();
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

        #region Checkboxes
        private SearchCriteria chk_UnderwritingBypass = SearchCriteria.ByAutomationId("__cid_CheckBox1_Ctrl");
        private SearchCriteria chk_CreditReportBypass = SearchCriteria.ByAutomationId("__cid_CheckBox3_Ctrl");
        private SearchCriteria chk_WestVM_Bypass = SearchCriteria.ByAutomationId("__cid_CheckBox2_Ctrl");
        private SearchCriteria chk_SmartGFE_Bypass = SearchCriteria.ByAutomationId("__cid_CheckBox4_Ctrl");

        public TestConsole chk_UnderwritingBypass_Check(bool Check)
        {
            ClickCheckBox(Check, chk_UnderwritingBypass);
            Thread.Sleep(2000);

            return this;
        }
        public TestConsole chk_CreditReportBypass_Check(bool Check)
        {
            ClickCheckBox(Check, chk_CreditReportBypass);
            Thread.Sleep(2000);

            return this;
        }
        public TestConsole chk_WestVM_Bypass_Check(bool Check)
        {
            ClickCheckBox(Check, chk_WestVM_Bypass);
            Thread.Sleep(2000);

            return this;
        }
        public TestConsole chk_SmartGFE_Bypass_Check(bool Check)
        {
            ClickCheckBox(Check, chk_SmartGFE_Bypass);
            Thread.Sleep(2000);

            return this;
        }

        #endregion

    }
}
