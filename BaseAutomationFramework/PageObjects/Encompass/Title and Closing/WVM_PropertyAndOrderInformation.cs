///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Namespace>
///   Class:          <WVM_PropertyAndOrderInformation>
///   Description:    <WVM_Property_and_Order_Information>
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
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("RequestDialog");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };
		public const bool SET_MAXIMIZED = true;

		public WVM_PropertyAndOrderInformation()
		{
			Set_Screen(scArray, SET_MAXIMIZED);

			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.NameProperty, "Fees");
			for (int i = 0; i < 30; i++) // ~30 Seconds
			{
				Thread.Sleep(1000);
				aeScreen = AutomationElement.RootElement.FindFirst(System.Windows.Automation.TreeScope.Children, pcWindow);
				aeScreen = aeScreen.FindFirst(System.Windows.Automation.TreeScope.Descendants, pcsubWindow);
				if (aeScreen != null)
					break;
			}

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

            //aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
            //aElement.ClickCenterOfBounds();
            //setLegacyIAccessiblePattern(aElement);
            //if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Jump")
            //    DoDefaultAction(aElement);

            return this;

        }

        public void UploadFees_Click()
        {
            Point UploadFees = new Point(1711, 195);
        
            Mouse.Instance.Location = UploadFees;
            Mouse.LeftDown();
            Mouse.LeftUp();
            Thread.Sleep(8000);
        }

        #endregion

        #region Checkboxes

        private SearchCriteria chk_Appraisal_included = SearchCriteria.ByAutomationId("appraisalIsIncluded");
        
        public WVM_PropertyAndOrderInformation chk_Appraisal_included_Check(bool Check)
        {
            ClickCheckBox(Check, chk_Appraisal_included);
            Thread.Sleep(20000);
            return this;
        }
        #endregion

    }
}