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
	public class BorrowerLoanCenterLogIn : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByClassName("MozillaWindowClass");
		public static SearchCriteria[] scArray = { scWindow };
		public const bool SET_MAXIMIZED = true;

		private AutomationElement MenuParent { get; set; }

		public BorrowerLoanCenterLogIn()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static BorrowerLoanCenterLogIn Initialize()
		{
			return new BorrowerLoanCenterLogIn();
		}


		#region Buttons

		public BorrowerLoanCenterLogIn btn_Login_Click()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Login"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "hyperlink")
				);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "jump")
				DoDefaultAction(aElement);
			aElement.ClickCenterOfBounds();
			aElement.WaitWhileBusy();

			return new BorrowerLoanCenterLogIn();
		}

		#endregion



	}
}
