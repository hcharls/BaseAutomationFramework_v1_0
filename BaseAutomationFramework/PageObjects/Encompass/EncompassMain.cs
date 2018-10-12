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
using TestStack.White.UIItems.TabItems;
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class EncompassMain : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("MainForm");
		public static SearchCriteria[] scArray = { scWindow };
		public const bool SET_MAXIMIZED = false;
		private AutomationElement aePanel = null;

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
			System.Threading.Thread.Sleep(5000);
			Screen.DisplayState = TestStack.White.UIItems.WindowItems.DisplayState.Maximized;
			Screen.WaitTill(() => Screen.DisplayState == TestStack.White.UIItems.WindowItems.DisplayState.Maximized, TimeSpan.FromSeconds(15.0));

			return new EncompassMain();
		}

		#region Menus & Menu Items

		private SearchCriteria mnu_MenuBar = SearchCriteria.ByAutomationId("mainMenu");

		private PropertyCondition mnu_TitleAndClosing = new PropertyCondition(AutomationElement.NameProperty, "Title & Closing");
		private PropertyCondition mnu_ProductAndPricing = new PropertyCondition(AutomationElement.NameProperty, "Product and Pricing");
        private PropertyCondition mnu_MortgageInsurance = new PropertyCondition(AutomationElement.NameProperty, "Mortgage Insurance");
        private PropertyCondition mnu_Services = new PropertyCondition(AutomationElement.NameProperty, "Services");
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
        public EncompassMain mnu_MortgageInsurance_Click()
        {
            Thread.Sleep(250);
            MenuParent.FindFirst(TreeScope.Children, mnu_MortgageInsurance).ClickCenterOfBounds();

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
		private PropertyCondition tab_Forms = new PropertyCondition(AutomationElement.NameProperty, "Forms");
		private PropertyCondition tab_Tools = new PropertyCondition(AutomationElement.NameProperty, "Tools");

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
        public void tab_ServicesView_Select()
        {
            tab_MainTabs_Return().SelectTabPage("Services View");
            Thread.Sleep(2000);
        }

        #endregion

        #region Functions

        public void SaveAndExitLoan()
		{
			tab_MainTabs_Return().SelectTabPage("Loan");
			Thread.Sleep(250);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.ALT);
			Keyboard.Instance.Enter("l");
			Keyboard.Instance.LeaveAllKeys();
			Thread.Sleep(250);
			Keyboard.Instance.Enter("x");
			Thread.Sleep(1000);
		}

		public void Open_eFolder()
		{
			tab_MainTabs_Return().SelectTabPage("Loan");
			Thread.Sleep(250);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.SHIFT);
			Keyboard.Instance.Enter("f");
            Thread.Sleep(500);
            Keyboard.Instance.LeaveAllKeys();
			Thread.Sleep(500);
		}

		public void ExitEncompass()
		{
			tab_MainTabs_Return().SelectTabPage("Loan");
			Thread.Sleep(250);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.ALT);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.F4);
			Keyboard.Instance.LeaveAllKeys();
			Thread.Sleep(250);

		}

       
        #endregion



    }
}
