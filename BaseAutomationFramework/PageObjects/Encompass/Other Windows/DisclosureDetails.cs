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
    public class DisclosureDetails : BaseScreen
    {
        public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("DisclosureDetailsDialog2015");
        public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
        public const bool SET_MAXIMIZED = false;
        private AutomationElement aePanel = null;

        public DisclosureDetails()
        {
            Set_Screen(scArray, SET_MAXIMIZED);
            aeScreen = Screen.AutomationElement;
            aePanel = null;
        }
        public static DisclosureDetails Initialize()
        {
            return new DisclosureDetails();
        }
        public static DisclosureDetails OpenFrom_DisclosureTracking()
        {
            new DisclosureTracking()
                .btn_InitialDisclosureRecord_Click();

            return new DisclosureDetails();
        }

        #region Checkboxes

        private SearchCriteria chk_IntentToProceed = SearchCriteria.ByAutomationId("chkIntent");
       
        public DisclosureDetails chk_IntentToProceed_Check(bool Check)
        {
            ClickCheckBox(Check, chk_IntentToProceed);

            return this;
        }

        #endregion

        #region Text Boxes

        private PropertyCondition txt_DisclosureSentDate = new PropertyCondition(AutomationElement.AutomationIdProperty, "dtDisclosedDate");
        private PropertyCondition txt_ActualReceivedDate = new PropertyCondition(AutomationElement.AutomationIdProperty, "dpBorrowerActualReceivedDate");

        public DisclosureDetails txt_DisclosureSentDate_SetBack()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_DisclosureSentDate);
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.LEFT);
            Thread.Sleep(500);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
            Thread.Sleep(500);

            return this;
        }
        public DisclosureDetails txt_ActualReceivedDate_SetDate()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_ActualReceivedDate);
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            Thread.Sleep(500);
            Keyboard.Instance.Enter("d");
            Keyboard.Instance.LeaveAllKeys();
            Thread.Sleep(500);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);

            return this;
        }

        #endregion

        #region Buttons

        private PropertyCondition btn_SentDateManualEntry = new PropertyCondition(AutomationElement.AutomationIdProperty, "lbtnSentDate");
        private SearchCriteria btn_OK = SearchCriteria.ByAutomationId("btnOK");
        //
        public DisclosureDetails btn_SendDateManualEntry_Click()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_SentDateManualEntry);
            aElement.ClickCenterOfBounds();
            Thread.Sleep(2000);

            return new DisclosureDetails();
        }

        public void btn_OK_Click()
        {
            GetButton(btn_OK).Click();
            Thread.Sleep(10000);
        }

        #endregion

    }
}