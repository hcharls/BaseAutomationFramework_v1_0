using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using BaseAutomationFramework.Tests;
using TestStack.White.InputDevices;
using TestStack.White.UIItems.Finders;
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	class EncompassDialogCDSent : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByClassName("#32770");
        public static SearchCriteria[] scArray = { EncompassMain.scWindow, SelectDocumentsClosing.scWindow, SendDisclosuresClosing.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;

		public static EncompassDialogCDSent Initialize()
		{
			return new EncompassDialogCDSent();
		}

        private PropertyCondition btn_OK = new PropertyCondition(AutomationElement.AutomationIdProperty, "2");

        public void btn_OK_Click()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_OK);
            aElement.ClickCenterOfBounds();
        }

    }
}
