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
	public class ReportingDatabase : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByClassName("WindowsForms10.Window.8.app.0.2eed1ca_r12_ad1");
		public static SearchCriteria[] scArray = new SearchCriteria[] { scWindow };
		public const bool SET_MAXIMIZED = true;


		public static ReportingDatabase Initialize()
		{
			return new ReportingDatabase();
		}

		#region Text Boxes

		private PropertyCondition txt_FirstPaymentDate = new PropertyCondition(AutomationElement.AutomationIdProperty, "l_682");

		public ReportingDatabase txt_FirstPaymentDate_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_FirstPaymentDate);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Thread.Sleep(500);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
			Keyboard.Instance.Enter("a");
			Keyboard.Instance.LeaveAllKeys();
			Thread.Sleep(250);
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            aElement.WaitWhileBusy();
			Thread.Sleep(5000);

			return this;
		}
		
		#endregion

		#region Buttons

		private PropertyCondition btn_Add = new PropertyCondition(AutomationElement.NameProperty, "Add");
		//
		public ReportingDatabase btn_Add_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_Add);
			aElement.ClickCenterOfBounds();
			Thread.Sleep(2000);

			return new ReportingDatabase();
		}

		#endregion
	}
}
