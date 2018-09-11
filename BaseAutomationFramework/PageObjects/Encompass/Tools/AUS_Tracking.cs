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
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class AUS_Tracking : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
        public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };
		public const bool SET_MAXIMIZED = false;
		public AUS_Tracking()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static AUS_Tracking Initialize()
		{
			return new AUS_Tracking();
		}

		public static AUS_Tracking OpenTool_FromToolsTab()
		{
			new ToolsTab()
				.lstbx_Tools_SelectTool("AUS Tracking");

			return new AUS_Tracking();
		}

        #region Buttons

        private PropertyCondition btn_NewDecision = new PropertyCondition(AutomationElement.AutomationIdProperty, "stdIconNew");
    
        //
        public AUS_Tracking btn_NewDecision_Click()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_NewDecision);
            aElement.ClickCenterOfBounds();

            return this;
        }

        #endregion

    }
}