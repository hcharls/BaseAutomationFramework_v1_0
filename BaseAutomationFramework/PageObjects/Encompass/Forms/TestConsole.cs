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
using EllieMae.Encompass.BusinessObjects.Loans;

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

        private PropertyCondition rdb_NoCashOutRefi = new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_RadioButton3_Ctrl");
        private PropertyCondition rdb_Direct = new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_RadioButton7_Ctrl");
        private PropertyCondition rdb_FixedRate = new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_RadioButton8_Ctrl");

        //
        public TestConsole rdb_Conventional_Select(int retryFind = 90)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, rdb_NoCashOutRefi);
            aElement.ClickCenterOfBounds();
            Thread.Sleep(2000);

            return this;
        }
        public TestConsole rdb_NoCashOutRefi_Select()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, rdb_NoCashOutRefi);
            aElement.ClickCenterOfBounds();
            Thread.Sleep(2000);

            return this;
        }
        public TestConsole rdb_Direct_Select()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, rdb_Direct);
            aElement.ClickCenterOfBounds();
            Thread.Sleep(2000);

            return this;
        }
        public TestConsole rdb_FixedRate_Select()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, rdb_FixedRate);
            aElement.ClickCenterOfBounds();
            Thread.Sleep(2000);

            return this;
        }

        //public TestConsole rdb_FHA_Select()
        //{
        //    AndCondition andCond = new AndCondition(
        //            new PropertyCondition(AutomationElement.NameProperty, "1172: Loan type: Conventional, FHA, VA, US or other."),
        //            new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_FHA_Ctrl"),
        //            new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "radio button")
        //        );
        //    aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
        //    AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
        //    item.ClickCenterOfBounds();
        //    Thread.Sleep(2000);

        //    return this;
        //}
        //public TestConsole rdb_VA_Select()
        //{
        //    AndCondition andCond = new AndCondition(
        //            new PropertyCondition(AutomationElement.NameProperty, "1172: Loan type: Conventional, FHA, VA, US or other."),
        //            new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_VA_Ctrl"),
        //            new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "radio button")
        //        );
        //    aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
        //    AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
        //    item.ClickCenterOfBounds();
        //    Thread.Sleep(2000);

        //    return this;
        //}
        //public TestConsole rdb_Purchase_Select()
        //{
        //    AndCondition andCond = new AndCondition(
        //            new PropertyCondition(AutomationElement.NameProperty, "19: The purpose (purchase, refinance, construction, or other) for which the loan funds will be used."),
        //            new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_Purchase_Ctrl"),
        //            new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "radio button")
        //        );
        //    aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
        //    AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
        //    item.ClickCenterOfBounds();
        //    Thread.Sleep(2000);

        //    return this;
        //}
        //public TestConsole rdb_CashOutRefi_Select()
        //{
        //    AndCondition andCond = new AndCondition(
        //            new PropertyCondition(AutomationElement.NameProperty, "19: The purpose (purchase, refinance, construction, or other) for which the loan funds will be used."),
        //            new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CashOutRefinance_Ctrl"),
        //            new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "radio button")
        //        );
        //    aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
        //    AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
        //    item.ClickCenterOfBounds();
        //    Thread.Sleep(2000);

        //    return this;
        //}
        //public TestConsole rdb_NoCashOutRefi_Select()
        //{
        //    AndCondition andCond = new AndCondition(
        //            new PropertyCondition(AutomationElement.NameProperty, "19: The purpose (purchase, refinance, construction, or other) for which the loan funds will be used."),
        //            new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_NoCashOutRefinance_Ctrl"),
        //            new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "radio button")
        //        );
        //    aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
        //    AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
        //    item.ClickCenterOfBounds();
        //    Thread.Sleep(2000);

        //    return this;
        //}
        //public TestConsole rdb_Direct_Select()
        //{
        //    AndCondition andCond = new AndCondition(
        //            new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_Direct_Ctrl"),
        //            new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "radio button")
        //        );
        //    aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
        //    AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
        //    item.ClickCenterOfBounds();
        //    Thread.Sleep(2000);

        //    return this;
        //}
        //public TestConsole rdb_Partners_Select()
        //{
        //    AndCondition andCond = new AndCondition(
        //            new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_Partners_Ctrl"),
        //            new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "radio button")
        //        );
        //    aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
        //    AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
        //    item.ClickCenterOfBounds();
        //    Thread.Sleep(2000);

        //    return this;
        //}
        //public TestConsole rdb_Phoenix_Select()
        //{
        //    AndCondition andCond = new AndCondition(
        //            new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_Phoenix_Ctrl"),
        //            new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "radio button")
        //        );
        //    aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
        //    AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
        //    item.ClickCenterOfBounds();
        //    Thread.Sleep(2000);

        //    return this;
        //}
        //public TestConsole rdb_FixedRate_Select()
        //{
        //    AndCondition andCond = new AndCondition(
        //            new PropertyCondition(AutomationElement.NameProperty, "608"),
        //            new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_Fixed_Ctrl"),
        //            new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "radio button")
        //        );
        //    aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
        //    AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
        //    item.ClickCenterOfBounds();
        //    Thread.Sleep(2000);

        //    return this;
        //}
        //public TestConsole rdb_ARM_Select()
        //{
        //    AndCondition andCond = new AndCondition(
        //            new PropertyCondition(AutomationElement.NameProperty, "608"),
        //            new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_ARM_Ctrl"),
        //            new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "radio button")
        //        );
        //    aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
        //    AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
        //    item.ClickCenterOfBounds();
        //    Thread.Sleep(2000);

        //    return this;
        //}
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
        public void btn_GoToDisclosurePrep_Click()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_GoToDisclosurePrep);
            aElement.ClickCenterOfBounds();
           
        }
        public void btn_CreateNewLoan_Click(string input)
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

            EncompassDialog.Initialize().btn_OK_Click();
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
        public TestConsole txt_SubjectProperty_ZipCode_SendKeys(string Input)
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

            return this;

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
        private PropertyCondition chk_UnderwritingBypass = new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox1_Ctrl");
        private PropertyCondition chk_CreditReportBypass = new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox3_Ctrl");
        private PropertyCondition chk_WestVM_Bypass = new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox2_Ctrl");
        private PropertyCondition chk_SmartGFE_Bypass = new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox4_Ctrl");

        public TestConsole chk_UnderwritingBypass_Check()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, chk_UnderwritingBypass);
            setLegacyIAccessiblePattern(aElement);
            if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
                DoDefaultAction(aElement);
            Thread.Sleep(2000);

            return this;
        }
        public TestConsole chk_CreditReportBypass_Check()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, chk_CreditReportBypass);
            setLegacyIAccessiblePattern(aElement);
            if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
                DoDefaultAction(aElement);
            Thread.Sleep(2000);

            return this;
        }
        public TestConsole chk_WestVM_Bypass_Check()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, chk_WestVM_Bypass);
            setLegacyIAccessiblePattern(aElement);
            if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
                DoDefaultAction(aElement);
            Thread.Sleep(2000);

            return this;
        }
        public TestConsole chk_SmartGFE_Bypass_Check()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, chk_SmartGFE_Bypass);
            setLegacyIAccessiblePattern(aElement);
            if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
                DoDefaultAction(aElement);
            Thread.Sleep(2000);

            return this;
        }

        #endregion

        
    }
}
