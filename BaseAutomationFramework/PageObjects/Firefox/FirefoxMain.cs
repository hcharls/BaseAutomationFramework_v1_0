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
using TestStack.White.UIItems.TabItems;
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.PageObjects.Firefox
{
	public class FirefoxMain : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByClassName("MozillaWindowClass");
		public static SearchCriteria[] scArray = { scWindow };
		public const bool SET_MAXIMIZED = true;
		private AutomationElement aePanel = null;

		private AutomationElement MenuParent { get; set; }

		public FirefoxMain()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
			SetPanel();
		}

		public static FirefoxMain Initialize()
		{
			Thread.Sleep(1000);
			return new FirefoxMain();
		}

		#region Panel

		private PropertyCondition pne_MainPanel = new PropertyCondition(AutomationElement.NameProperty, "Bookmarks Toolbar");
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
				new BorrowerLoanCenterLogIn();
				Thread.Sleep(1000);
				aePanel = Screen.AutomationElement.FindFirst(TreeScope.Descendants, pne_MainPanel);

			} while (aePanel == null && i++ < 60);
			if (aePanel == null)
				throw new Exception("Could not find the embedded IE panel!!!");
		}

		#endregion

		#region Buttons

		private PropertyCondition btn_BorrowerLoanCenter = new PropertyCondition(AutomationElement.NameProperty, "Borrower Loan Center");
		//
		public FirefoxMain btn_BorrowerLoanCenter_Click()
		{
				AndCondition andCond = new AndCondition(
						new PropertyCondition(AutomationElement.NameProperty, "Bookmarks Toolbar"),
						new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "tool bar")
					);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			aElement = aePanel.FindFirst(TreeScope.Descendants, btn_BorrowerLoanCenter);
				aElement.ClickCenterOfBounds();
				aElement.WaitWhileBusy();

				return new FirefoxMain();
		}

		#endregion

	}
}
