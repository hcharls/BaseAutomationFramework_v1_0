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
using TestStack.White.Utility;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class WVM_PropertyAndOrderInformation : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("RequestDialog");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };
		public const bool SET_MAXIMIZED = true;

		public WVM_PropertyAndOrderInformation()
		{
			Set_Screen(scArray, SET_MAXIMIZED);

			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.NameProperty, "Fees");
			for (int i = 0; i < 30; i++) // ~30 Seconds
			{
				Thread.Sleep(1000);
				aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
				aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
				if (aeScreen != null)
					break;
			}

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static WVM_PropertyAndOrderInformation Initialize()
		{
			return new WVM_PropertyAndOrderInformation();
		}



	}
}