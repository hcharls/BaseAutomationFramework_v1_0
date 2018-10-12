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
	public class DocsOut : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public DocsOut()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static DocsOut Initialize()
		{
			return new DocsOut();
		}

		public static DocsOut Open_FromLogTab()
		{
			new LogTab()
                .CollapseAll().SelectItem_DocsOut();

			return new DocsOut();
		}

		#region Checkboxes

		private SearchCriteria chk_Finish = SearchCriteria.ByAutomationId("checkBoxFinished");

		public DocsOut chk_Finish_Check()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Finished"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "check box")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);

			return this;
		}

		#endregion

		#region Tasks

		public DocsOut chk_ReviewTasks_Check()
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gridViewTasks"));

			Point Task1 = new Point(1131, 314);

			Mouse.Instance.Location = Task1;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(1000);

			return this;
		}

		#endregion

		#region Buttons

		private PropertyCondition btn_Funder = new PropertyCondition(AutomationElement.AutomationIdProperty, "pictureBoxNextLA");
		//
		public DocsOut btn_Funder_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_Funder);
			aElement.ClickCenterOfBounds();
			Thread.Sleep(1000);

			return this;
		}

		#endregion

		#region Required Fields

		private PropertyCondition txt_PropertyInfoParcelNumber = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_1894");

		public DocsOut txt_PropertyInfoParcelNumber_SendKeys()
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_PropertyInfoParcelNumber);
			aElement.SetFocus();
			Keyboard.Instance.Enter("76876786");
			Thread.Sleep(500);

			return this;
		}

		#endregion

	}
}