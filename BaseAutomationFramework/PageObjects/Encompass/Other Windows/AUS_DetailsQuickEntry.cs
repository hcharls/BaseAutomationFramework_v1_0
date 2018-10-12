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
    public class AUS_DetailsQuickEntry : BaseScreen
    {
        public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("QuickEntryPopupDialog");
        public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
        public const bool SET_MAXIMIZED = false;
        private AutomationElement aePanel = null;

        public AUS_DetailsQuickEntry()
        {
            Set_Screen(scArray, SET_MAXIMIZED);
            aeScreen = Screen.AutomationElement;
            aePanel = null;
        }
        public static AUS_DetailsQuickEntry Initialize()
        {
            return new AUS_DetailsQuickEntry();
        }
        public static AUS_DetailsQuickEntry OpenFrom_AUSTracking()
        {
            new ToolsTab()
                 .lstbx_Tools_SelectTool("AUS Tracking");
            new AUS_Tracking()
                .btn_NewDecision_Click();

            return new AUS_DetailsQuickEntry();
        }

        #region Combo Boxes

        private PropertyCondition cmb_UnderwritingRiskAssessType = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox1");

        public AUS_DetailsQuickEntry cmb_UnderwritingRiskAssessType_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_UnderwritingRiskAssessType);
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            Thread.Sleep(500);

            return this;
        }

        #endregion
        
        #region Buttons

        private SearchCriteria btn_OK = SearchCriteria.ByAutomationId("btnOK");
        //
        public void btn_OK_Click()
        {
            GetButton(btn_OK).Click();
            Thread.Sleep(10000);
        }

        #endregion

    }
}