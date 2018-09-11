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
	public class SmartFees_Fees : BaseScreen
    {
        public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };
        public const bool SET_MAXIMIZED = true;

        public SmartFees_Fees()
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

        public static SmartFees_Fees Initialize()
		{
			return new SmartFees_Fees();
		}
    

        #region Buttons

        public SmartFees_Fees btn_ExportToEncompasss_Click(int retryFind = 90)
        {
    
            UIAutomationClient.IUIAutomationPropertyCondition btn_ExportToEncompasss = (UIAutomationClient.IUIAutomationPropertyCondition)UIA_Extensions.AUTOCLASS.CreatePropertyCondition(UIAutomationClient.UIA_PropertyIds.UIA_AutomationIdPropertyId, "btn_submit");
            UIAutomationClient.IUIAutomationElement button = UIA_Extensions.ROOT.FindFirst(UIAutomationClient.TreeScope.TreeScope_Descendants, btn_ExportToEncompasss);
            button.xtClickCenterOfBounds();
            Thread.Sleep(10000);

            return this;

        }
 
        #endregion

       

    }
}