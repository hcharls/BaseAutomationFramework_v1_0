using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class AlertsandMessagesTab : BaseScreen
	{
		//public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow };
		public const bool SET_MAXIMIZED = false;
		public AlertsandMessagesTab()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static AlertsandMessagesTab Initialize()
		{
			return new AlertsandMessagesTab();
		}

		public void SelectItem_eConsentNotYetReceived()
		{
			Point AlertsAndMessages = new Point(60, 185);

			Mouse.Instance.Location = AlertsAndMessages;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);

			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gvAlerts"));
			Point point = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 25), Convert.ToInt32(thing.Bounds.TopLeft.Y + 10));

			Mouse.Instance.Location = point;
			System.Threading.Thread.Sleep(500);
			Mouse.Instance.Click(MouseButton.Left);
			System.Threading.Thread.Sleep(1000);
		}

	}
}