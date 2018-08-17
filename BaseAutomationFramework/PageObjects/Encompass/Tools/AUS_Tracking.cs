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
	public class DisclosureTracking : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public DisclosureTracking()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static DisclosureTracking Initialize()
		{
			return new DisclosureTracking();
		}

		public static DisclosureTracking OpenForm_FromToolsTab()
		{
			new ToolsTab()
				.lstbx_Tools_SelectTool("Disclosure Tracking");

			return new DisclosureTracking();
		}

        public void btn_InitialDisclosureRecord_Click()
        {
            Point InitialDisclosure = new Point(352, 539);

            Mouse.Instance.Location = InitialDisclosure;
            Mouse.LeftDown();
            Mouse.LeftUp();
            Mouse.LeftDown();
            Mouse.LeftUp();
            Thread.Sleep(1000);
        }

    }
}