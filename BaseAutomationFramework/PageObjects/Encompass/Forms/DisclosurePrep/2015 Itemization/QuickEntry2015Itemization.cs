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
	public class QuickEntry2015Itemization : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("QuickEntryPopupDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = true;
		private AutomationElement aePanel = null;

		public QuickEntry2015Itemization()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
			SetPanel();
		}

		public static QuickEntry2015Itemization OpenFromDisclosurePrep()
		{
			new DisclosurePrep()
				.btn_Review2015Itemization_Click();

			return new QuickEntry2015Itemization();
		}

		#region Panel

		//private SearchCriteria pne_MainPanel = SearchCriteria.ByAutomationId("Form1");
		private PropertyCondition pne_MainPanel = new PropertyCondition(AutomationElement.AutomationIdProperty, "Form1");
		//
		private void SetPanel()
		{
			for (int i = 0; i < 10; i++)
			{
				Thread.Sleep(100);
				if (this.aePanel == null)
				{
					this.aePanel = Screen.AutomationElement.FindFirst(TreeScope.Descendants, pne_MainPanel);
				}
				else
					break;
			}


		}

		#endregion

		#region Buttons

		private SearchCriteria btn_Close = SearchCriteria.ByAutomationId("btnClose");
		//
		public void btn_Close_Click()
		{
			GetButton(btn_Close).Click();
		}

		#endregion



	}
}
