///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Namespace>
///   Class:          <DisclosureTracking>
///   Description:    <Disclosure_Tracking_Tool>
///   Author:         <Hannah_Charls>           Date: <Novmeber_21_2017>
///   Notes:          <>
///   Revision History:
///   Name:				 Date:					Description:
///   
/// 
///------------------------------------------------------------------------------------------------------------------------

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
        public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow, scWindow };
        public const bool SET_MAXIMIZED = false;
        public DisclosureDetails()
        {
            PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
            PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
            aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
            aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
            aeScreen.WaitWhileBusy();

            if (aeScreen == null)
                throw new Exception("Screen is null!!!");
        }

        public static DisclosureDetails OpenFrom_DisclosureTracking()
        {
            new DisclosureTracking()
                .btn_InitialDisclosureRecord_Click();

            return new DisclosureDetails();
        }

        

    }
}