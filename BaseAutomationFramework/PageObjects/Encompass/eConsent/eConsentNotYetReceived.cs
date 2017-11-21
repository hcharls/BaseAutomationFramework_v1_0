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
	public class eConsentNotYetReceived : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public eConsentNotYetReceived()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static eConsentNotYetReceived Open_FromAlertsandMessagesTab()
		{
			new AlertsandMessagesTab()
				.SelectItem_eConsentNotYetReceived();

			return new eConsentNotYetReceived();
		}

		private PropertyCondition btn_RequesteConsent = new PropertyCondition(AutomationElement.NameProperty, "Request eConsent");
		//
		public eConsentNotYetReceived btn_RequesteConsent_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_RequesteConsent);
			aElement.ClickCenterOfBounds();
			aElement.WaitWhileBusy();
			Thread.Sleep(1000);

			return new eConsentNotYetReceived();
		}

	}
}