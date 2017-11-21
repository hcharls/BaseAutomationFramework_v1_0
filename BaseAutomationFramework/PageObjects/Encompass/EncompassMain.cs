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

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class EncompassMain : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("MainForm");
		public static SearchCriteria[] scArray = { scWindow };
		public const bool SET_MAXIMIZED = false;

		private AutomationElement MenuParent { get; set; }

		public EncompassMain()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
			MenuParent = GetMenuBar(mnu_MenuBar).AutomationElement;
		}

		public static EncompassMain Initialize()
		{
			return new EncompassMain();
		}


		public EncompassMain Resize()
		{
			Screen.DisplayState = TestStack.White.UIItems.WindowItems.DisplayState.Restored;
			System.Threading.Thread.Sleep(500);
			Screen.DisplayState = TestStack.White.UIItems.WindowItems.DisplayState.Maximized;
			Screen.WaitTill(() => Screen.DisplayState == TestStack.White.UIItems.WindowItems.DisplayState.Maximized, TimeSpan.FromSeconds(15.0));

			return new EncompassMain();
		}


		#region Menus & Menu Items

		private SearchCriteria mnu_MenuBar = SearchCriteria.ByAutomationId("mainMenu");

		private PropertyCondition mnu_TitleAndClosing = new PropertyCondition(AutomationElement.NameProperty, "Title & Closing");
		private PropertyCondition mnu_ProductAndPricing = new PropertyCondition(AutomationElement.NameProperty, "Product and Pricing");
		private PropertyCondition mnu_Services = new PropertyCondition(AutomationElement.NameProperty, "Services");
		//private SearchCriteria mnu_ProductAndPricing = SearchCriteria.ByText("Product and Pricing");
		//private SearchCriteria mnu_Services = SearchCriteria.ByText("Services");		
		//
		public EncompassMain mnu_TitleAndClosing_Click()
		{
			Thread.Sleep(250);
			MenuParent.FindFirst(TreeScope.Children, mnu_TitleAndClosing).ClickCenterOfBounds();

			return new EncompassMain();
		}
		public EncompassMain mnu_ProductAndPricing_Click()
		{
			Thread.Sleep(250);
			MenuParent.FindFirst(TreeScope.Children, mnu_ProductAndPricing).ClickCenterOfBounds();			

			return new EncompassMain();
		}
		public EncompassMain mnu_Services_Click()
		{
			Thread.Sleep(250);
			aElement = MenuParent.FindFirst(TreeScope.Children, mnu_Services);
			aElement.ClickCenterOfBounds();
			MenuParent = aElement;			

			return this;
		}

		#endregion

		#region Tab & Tab Items

		private SearchCriteria tab_MainTabs = SearchCriteria.ByAutomationId("tabControl");
		//
		private Tab tab_MainTabs_Return()
		{
			return GetTab(tab_MainTabs);
		}

		public void tab_Pipeline_Select()
		{
			tab_MainTabs_Return().SelectTabPage("Pipeline");
		}
		public void tab_Loan_Select()
		{
			tab_MainTabs_Return().SelectTabPage("Loan");
		}

		#endregion

		#region Buttons

		private PropertyCondition btn_Close = new PropertyCondition(AutomationElement.AutomationIdProperty, "closeBtn");
		//
		public EncompassMain btn_Close_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_Close);
			aElement.ClickCenterOfBounds();

			return new EncompassMain();
		}
		
		#endregion
	}
}
