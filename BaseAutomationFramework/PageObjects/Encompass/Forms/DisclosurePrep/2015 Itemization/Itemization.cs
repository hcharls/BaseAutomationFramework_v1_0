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
	public class Itemization : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public Itemization()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static Itemization OpenForm_FromFormsTab()
		{
			new FormsTab()
				.lstbx_Forms_SelectForm("2015 Itemization");
				Thread.Sleep(10000);

			return new Itemization();
		}

		public static Itemization Initialize()
		{
			return new Itemization();
		}

		private PropertyCondition btn_ScrollDown900 = new PropertyCondition(AutomationElement.NameProperty, "700. Total Sales / Brokers Commission");
		private PropertyCondition btn_ScrollDown1100 = new PropertyCondition(AutomationElement.NameProperty, "900. Items Required by Lender to be Paid in Advance");

		public Itemization btn_ScrollDown900_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_ScrollDown900);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Thread.Sleep(300);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Thread.Sleep(3000);

			return this;
		}

		public Itemization btn_ScrollDown1100_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_ScrollDown1100);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Thread.Sleep(300);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);

			return this;
		}

		#region Buttons

		private PropertyCondition btn_AggregateSetup = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button12");

		public Itemization btn_AggregateSetup_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_AggregateSetup);
			aElement.ClickCenterOfBounds();

			return new Itemization();

		}

		#endregion

		#region Text Boxes

		private PropertyCondition txt_PropertyTaxesMths = new PropertyCondition(AutomationElement.AutomationIdProperty, "TextBox658");

		public Itemization txt_PropertyTaxesMths_SendKeys(string Input)
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
