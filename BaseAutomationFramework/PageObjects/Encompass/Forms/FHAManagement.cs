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
	public class FHAManagement : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public FHAManagement()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static FHAManagement OpenForm_FromFormsTab()
		{
			new FormsTab()
				.lstbx_Forms_SelectForm("FHA Management");
                Thread.Sleep(250);

			return new FHAManagement();
		}

        #region Tabs

        private PropertyCondition tab_Tracking = new PropertyCondition(AutomationElement.NameProperty, "Tracking");

        public FHAManagement tab_Tracking_Click()
        {
            //AndCondition andCond = new AndCondition(
            //        new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "tab item")
            //    );
            //aElement = aeScreen.FindFirst(TreeScope.Descendants, tab_Tracking);
            //AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
            //item.ClickCenterOfBounds();
            //new FHAManagement();
            //Thread.Sleep(2000);

            aElement = aeScreen.FindFirst(TreeScope.Descendants, tab_Tracking);
            aElement.ClickCenterOfBounds();
            new FHAManagement();
            Thread.Sleep(2000);

            return new FHAManagement();
        }

        #endregion

        #region Text Boxes

        private PropertyCondition txt_FHACaseNumber = new PropertyCondition(AutomationElement.NameProperty, "1040: The loan tracking number for the loan. For FHA loans, enter the case number retrieved from the FHA Connections website. For VA loans, enter the case number supplied by the VA.");
		private PropertyCondition txt_FHACaseNumberDate = new PropertyCondition(AutomationElement.NameProperty, "3042: The date entered in this field determines which mortgage insurance pricing scenario to use.");

		public FHAManagement txt_FHACaseNumber_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_FHACaseNumber);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}

		public FHAManagement txt_FHACaseNumberDate_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_FHACaseNumberDate);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}

		#endregion

	}
}