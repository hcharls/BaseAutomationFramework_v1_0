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
	public class ItemizationQuickEntry : BaseScreen
	{
        public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("QuickEntryPopupDialog");
        public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
        public const bool SET_MAXIMIZED = false;
        private AutomationElement aePanel = null;

        public ItemizationQuickEntry()
        {
            Set_Screen(scArray, SET_MAXIMIZED);
            SetPanel();
        }
        public static ItemizationQuickEntry OpenForm_FromDisclosurePrep()
		{
			new DisclosurePrep()
				.btn_Review2015Itemization_Click();
				Thread.Sleep(10000);

			return new ItemizationQuickEntry();
		}

		public static ItemizationQuickEntry Initialize()
		{
			return new ItemizationQuickEntry();
		}

        #region Panel

        private PropertyCondition pne_MainPanel = new PropertyCondition(AutomationElement.AutomationIdProperty, "Form1");
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
                new ItemizationQuickEntry();
                Thread.Sleep(1000);
                aePanel = Screen.AutomationElement.FindFirst(TreeScope.Descendants, pne_MainPanel);

            } while (aePanel == null && i++ < 60);
            if (aePanel == null)
                throw new Exception("Could not find the embedded panel!!!");
        }
        

        #endregion

        #region Buttons

        private PropertyCondition btn_AggregateSetup = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button12");
		private PropertyCondition btn_PropertyTaxes = new PropertyCondition(AutomationElement.AutomationIdProperty, "StandardButton6");
        private PropertyCondition btn_Close = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnClose");

        public ItemizationQuickEntry btn_AggregateSetup_Click()
		{
			aElement = aePanel.FindFirst(TreeScope.Descendants, btn_AggregateSetup);
			aElement.ClickCenterOfBounds();

			return new ItemizationQuickEntry();
		}
		public ItemizationQuickEntry btn_PropertyTaxes_Click()
		{
			aElement = aePanel.FindFirst(TreeScope.Descendants, btn_PropertyTaxes);
			aElement.ClickCenterOfBounds();
			Thread.Sleep(5000);

			return new ItemizationQuickEntry();
		}
        public void btn_Close_Click()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_Close);
            aElement.ClickCenterOfBounds();
            Thread.Sleep(5000);
        }

        #endregion

        #region Text Boxes

        private PropertyCondition txt_PropertyTaxesMths = new PropertyCondition(AutomationElement.AutomationIdProperty, "TextBox658");

		public ItemizationQuickEntry txt_PropertyTaxesMths_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_PropertyTaxesMths);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Thread.Sleep(500);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
			Keyboard.Instance.Enter("a");
			Keyboard.Instance.LeaveAllKeys();
			Thread.Sleep(250);
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			aElement.WaitWhileBusy();
			Thread.Sleep(4000);

			return this;
		}

		#endregion

		
	}
}
