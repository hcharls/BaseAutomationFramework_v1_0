using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class SelectDocuments : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("FormSelectionDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;

		public SelectDocuments()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static SelectDocuments Initialize()
		{
			return new SelectDocuments();
		}

		#region Buttons

		private SearchCriteria btn_Send = SearchCriteria.ByAutomationId("btnSend");

		//
		public void btn_Send_Click()
		{
			GetButton(btn_Send).Click();
		}

		#endregion

	}
}
