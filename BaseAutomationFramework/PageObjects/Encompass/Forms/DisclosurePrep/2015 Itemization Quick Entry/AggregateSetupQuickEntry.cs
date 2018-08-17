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
	public class AggregateSetupQuickEntry : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("HUD1ESSetupDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, ItemizationQuickEntry.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		public AggregateSetupQuickEntry()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static AggregateSetupQuickEntry Initialize()
		{
			return new AggregateSetupQuickEntry();
		}

		
        public static AggregateSetupQuickEntry OpenFromItemizationQuickEntry()
        {
            new ItemizationQuickEntry()
                .btn_AggregateSetup_Click();

            return new AggregateSetupQuickEntry();
        }

        #region Text Boxes

        private PropertyCondition txt_HazardInsurance = new PropertyCondition(AutomationElement.AutomationIdProperty, "box_19");
		//

		public AggregateSetupQuickEntry txt_HazardInsurance_Tab()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_HazardInsurance);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Thread.Sleep(300);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			Thread.Sleep(1000);

			return this;
		}


		#endregion

		#region Buttons

		private SearchCriteria btn_Cancel = SearchCriteria.ByAutomationId("cancelBtn");
		private SearchCriteria btn_OK = SearchCriteria.ByAutomationId("okBtn");

		public void btn_Cancel_Click()
		{
			GetButton(btn_Cancel).Click();
		}

		public void btn_OK_Click()
		{
			GetButton(btn_OK).Click();
			Thread.Sleep(5000);
		}

		#endregion

		
	}
}