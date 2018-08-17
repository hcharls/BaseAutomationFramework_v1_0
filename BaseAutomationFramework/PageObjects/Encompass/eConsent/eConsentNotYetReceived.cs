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

		public static eConsentNotYetReceived Initialize()
		{
			return new eConsentNotYetReceived();
		}

		public static eConsentNotYetReceived Open_FromAlertsandMessagesTab()
		{
			new AlertsandMessagesTab()
				.SelectItem_eConsentNotYetReceived();

			return new eConsentNotYetReceived();
		}

		#region Buttons

		private PropertyCondition btn_Request_eConsent = new PropertyCondition(AutomationElement.NameProperty, "Request eConsent");
		private PropertyCondition btn_View_eConsent = new PropertyCondition(AutomationElement.NameProperty, "View eConsent");


		public eConsentNotYetReceived btn_Request_eConsent_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_Request_eConsent);
			aElement.ClickCenterOfBounds();
			aElement.WaitWhileBusy();
			Thread.Sleep(1000);

			return new eConsentNotYetReceived();
		}

		public eConsentNotYetReceived btn_View_eConsent_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_View_eConsent);
			aElement.ClickCenterOfBounds();
			aElement.WaitWhileBusy();
			Thread.Sleep(1000);
			Thread.Sleep(2000);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);

			return new eConsentNotYetReceived();
		}


		#endregion

	}
}