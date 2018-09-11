using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.Utility;
using UIAutomationClient;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class WVM_PropertyAndOrderInformation : BaseScreen
    {
        public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };
        public const bool SET_MAXIMIZED = true;

        public WVM_PropertyAndOrderInformation()
        {
            int i = 0;
            PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
            PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.NameProperty, "Fees");

            do
            {
                aElement = null;
                aeScreen = null;
                Screen = null;
                GC.Collect();
                Thread.Sleep(1000);
                Set_Screen(scArray, SET_MAXIMIZED);
                aeScreen = AutomationElement.RootElement.FindFirst(System.Windows.Automation.TreeScope.Children, pcWindow);
                aeScreen = aeScreen.FindFirst(System.Windows.Automation.TreeScope.Descendants, pcsubWindow);
            } while (aeScreen == null && ++i < 60);

            if (aeScreen == null)
                throw new Exception("Screen is null!!!");
        }

        public static WVM_PropertyAndOrderInformation Initialize()
		{
			return new WVM_PropertyAndOrderInformation();
		}

        #region Buttons

        public WVM_PropertyAndOrderInformation btn_UploadFees_Click(int retryFind = 90)
        {
            //AndCondition andCond = new AndCondition(
            //        new PropertyCondition(AutomationElement.NameProperty, "Upload Fees"),
            //        new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "hyperlink")
            //    );
            UIAutomationClient.IUIAutomationPropertyCondition btn_UploadName = (UIAutomationClient.IUIAutomationPropertyCondition)UIA_Extensions.AUTOCLASS.CreatePropertyCondition(UIAutomationClient.UIA_PropertyIds.UIA_NamePropertyId, "Upload Fees");
            UIAutomationClient.IUIAutomationPropertyCondition btn_UploadType = (UIAutomationClient.IUIAutomationPropertyCondition)UIA_Extensions.AUTOCLASS.CreatePropertyCondition(UIAutomationClient.UIA_PropertyIds.UIA_LocalizedControlTypePropertyId, "hyperlink");
            UIAutomationClient.IUIAutomationAndCondition btn_Upload =
               (UIAutomationClient.IUIAutomationAndCondition)UIA_Extensions.AUTOCLASS.CreateAndConditionFromArray(new UIAutomationClient.IUIAutomationCondition[] { btn_UploadName, btn_UploadType });

            UIAutomationClient.IUIAutomationElement button =
                UIA_Extensions.ROOT.FindFirst(UIAutomationClient.TreeScope.TreeScope_Descendants, btn_Upload);

            int i = 0;
            do
            {
                Thread.Sleep(1000);
                button = UIA_Extensions.ROOT.FindFirst(UIAutomationClient.TreeScope.TreeScope_Descendants, btn_Upload);
                i++;
            } while (button == null && i != retryFind);

            
            button.xtClickCenterOfBounds();
            Thread.Sleep(10000);

            //aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
            //aElement.ClickCenterOfBounds();
            //setLegacyIAccessiblePattern(aElement);
            //if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Jump")
            //    DoDefaultAction(aElement);

            return this;

        }

       
 
        #endregion

        #region Checkboxes

        private SearchCriteria chk_AppraisalIncluded = SearchCriteria.ByAutomationId("appraisalIsIncluded");
        
        public WVM_PropertyAndOrderInformation chk_AppraisalIncluded_Check(bool Check)
        {
            ClickCheckBox(Check, chk_AppraisalIncluded);
            Thread.Sleep(1000);
            return this;
        }

        #endregion

    }
}