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
	public class AggregateSetup : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("HUD1ESSetupDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		public AggregateSetup()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static AggregateSetup Initialize()
		{
			return new AggregateSetup();
		}

		public static AggregateSetup OpenFromItemization()
		{
			new Itemization()
				.btn_AggregateSetup_Click();

			return new AggregateSetup();
		}
        public static AggregateSetup OpenFromItemizationQuickEntry()
        {
            new ItemizationQuickEntry()
                .btn_AggregateSetup_Click();

            return new AggregateSetup();
        }

        #region Text Boxes

        private PropertyCondition txt_HazardInsurance = new PropertyCondition(AutomationElement.AutomationIdProperty, "box_19");
		//

		public AggregateSetup txt_HazardInsurance_Tab()
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

		public void DragWindow_AggregateSetup()
		{
			Point point1 = new Point(719, 245);
			Point point2 = new Point(902, 324);

			Mouse.Instance.Location = point1;
			Mouse.LeftDown();
			Mouse.Instance.Location = point2;
			Mouse.LeftUp();
			Thread.Sleep(2000);

			//Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
			//Keyboard.Instance.Enter("s");
			//Keyboard.Instance.LeaveAllKeys();
		}


	}
}