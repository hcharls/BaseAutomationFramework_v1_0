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
	public class SendConsent : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("SendConsentRequestDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		private AutomationElement aePanel = null;

		public SendConsent()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
			aePanel = null;
		}

		public static SendConsent Initialize()
		{
			return new SendConsent();
		}

		#region Panel

		private PropertyCondition pne_MainPanel = new PropertyCondition(AutomationElement.AutomationIdProperty, "gcMessage");
		//
		private void SetPanel()
		{
			int i = 0;
			do
			{
				aePanel = null;
				aeScreen = null;
				Screen = null;
				GC.Collect();
				new SendConsent();
				Thread.Sleep(1000);
				aePanel = Screen.AutomationElement.FindFirst(TreeScope.Descendants, pne_MainPanel);

			} while (aePanel == null && i++ < 60);
			if (aePanel == null)
				throw new Exception("Could not find the embedded panel!");
		}

		#endregion

		#region Checkboxes

		//public SendConsent chk_BorrowerConsent_Check()
		//{
		//	AndCondition andCond = new AndCondition(
		//		new PropertyCondition(AutomationElement.AutomationIdProperty, "chkBorrName"),
		//		new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "check box")
		//		);
		//	aElement = aePanel.FindFirst(TreeScope.Descendants, andCond);
		//	Thread.Sleep(1000);
		//	setLegacyIAccessiblePattern(aElement);
		//	if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
		//		DoDefaultAction(aElement);

		//	return this;
		//}

		//public SendConsent chk_NotifyWhenBorrowerReceives_Check()
		//{
		//	AndCondition andCond = new AndCondition(
		//			new PropertyCondition(AutomationElement.AutomationIdProperty, "chkReadReceipt"),
		//			new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "check box")
		//		);
		//	aElement = aePanel.FindFirst(TreeScope.Descendants, andCond);
		//	setLegacyIAccessiblePattern(aElement);
		//	if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Uncheck")
		//		DoDefaultAction(aElement);

		//	return this;

		private SearchCriteria chk_BorrowerConsent = SearchCriteria.ByAutomationId("chkBorrName");
		private SearchCriteria chk_NotifyWhenBorrowerReceives = SearchCriteria.ByAutomationId("chkReadReceipt");
		//
		public SendConsent chk_BorrowerConsent_Check(bool Check)
		{
			ClickCheckBox(Check, chk_BorrowerConsent);

			return this;
		}
		public SendConsent chk_NotifyWhenBorrowerReceives_Check(bool Check)
		{
			ClickCheckBox(Check, chk_NotifyWhenBorrowerReceives);

			return this;
		}

		#endregion

		#region Buttons

		//private PropertyCondition btn_Send = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnSend");
		////
		//public SendConsent btn_Send_Click()
		//{
		//	aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_Send);
		//	aElement.ClickCenterOfBounds();
		//	new SendConsent();
		//	Thread.Sleep(1000);

		//	return new SendConsent();
		//}

		private SearchCriteria btn_Send = SearchCriteria.ByAutomationId("btnSend");

		public void btn_Send_Click()
		{
			GetButton(btn_Send).Click();
			Thread.Sleep(2000);
		}

		#endregion

	}
}
