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
	public class SmartFees_Questions : BaseScreen
    {
        public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };
        public const bool SET_MAXIMIZED = false;

        public SmartFees_Questions()
        {
            int i = 0;
            PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
            PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.ClassNameProperty, "Internet Explorer_Server");

            do
            {
                aElement = null;
                aeScreen = null;
                Screen = null;
                GC.Collect();
                Thread.Sleep(1000);
                Set_Screen(scArray, SET_MAXIMIZED);
                aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
                aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
            } while (aeScreen == null && ++i < 60);

            if (aeScreen == null)
                throw new Exception("Screen is null!!!");
        }

        public static SmartFees_Questions Initialize()
		{
			return new SmartFees_Questions();
		}

        #region Required Fields

        private PropertyCondition btn_AppraisalProductName = new PropertyCondition(AutomationElement.AutomationIdProperty, "selectedAppraisalProductName");
        private PropertyCondition cmb_TaxAuthority = new PropertyCondition(AutomationElement.AutomationIdProperty, "TaxAuthorityId");

        //
        public SmartFees_Questions btn_AppraisalProductName_Click()
        {
            int i = 0;
            do
            {
                aElement = null;
                aeScreen = null;
                Screen = null;
                GC.Collect();
                new SmartFees_Questions();
                Thread.Sleep(1000);
                aElement = fn_DoActionWhileCOMException<TreeScope, PropertyCondition, AutomationElement>((treeScope, condition) => {
                    return aeScreen.FindFirst(treeScope, condition);
                }, TreeScope.Descendants, btn_AppraisalProductName);

            } while (aElement == null && ++i < 60);
            if (aElement == null)
                throw new Exception("Element could not be located!!!");
            aElement.ClickCenterOfBounds();

            return new SmartFees_Questions();
        }

        public SmartFees_Questions cmb_TaxAuthority_SendKeys(string Input)
        {
            AndCondition andCond = new AndCondition(
                    new PropertyCondition(AutomationElement.AutomationIdProperty, "TaxAuthorityId"),
                    new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "combo box")
                    );

            AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
            item.ClickCenterOfBounds();
            Thread.Sleep(500);
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            return new SmartFees_Questions();
        }

        #endregion


        #region Buttons

        public void btn_ContinueToFees_Click()
        {
             AndCondition andCond = new AndCondition(
                new PropertyCondition(AutomationElement.AutomationIdProperty, "btn_submit"),
                new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
                );

             AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
             item.ClickCenterOfBounds();
             Thread.Sleep(5000);
            
        }

        #endregion



    }
}