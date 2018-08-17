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
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class QuickEntryBankerLoanSubmission : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("QuickEntryPopupDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		private AutomationElement aePanel = null;

		public QuickEntryBankerLoanSubmission()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
			aePanel = null;
		}

		public static QuickEntryBankerLoanSubmission Initialize()
		{
			return new QuickEntryBankerLoanSubmission();
		}

		public QuickEntryBankerLoanSubmission ScrollDown()
		{
			Point Top = new Point(1382, 277);
			Point Bottom = new Point(1382, 794);

			Mouse.Instance.Location = Top;
			Mouse.LeftDown();
			Thread.Sleep(1000);
			Mouse.Instance.Location = Bottom;
			Mouse.LeftUp();
			Thread.Sleep(1000);

			return this;
		}

		#region Buttons

		private PropertyCondition btn_BankerCertificationBLS = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button3");
		private SearchCriteria btn_Close = SearchCriteria.ByAutomationId("btnClose");
		//
		public QuickEntryBankerLoanSubmission btn_BankerCertificationBLS_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Banker Certification"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_BankerCertificationBLS);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			Thread.Sleep(2000);

			return new QuickEntryBankerLoanSubmission();
		}

		public void btn_Close_Click()
		{
			GetButton(btn_Close).Click();
		}

		#endregion

	}
}