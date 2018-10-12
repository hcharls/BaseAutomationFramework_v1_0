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
	public class OB_LockRequestDialog : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LockRequestProcessDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = true;
		private AutomationElement aePanel = null;

		public OB_LockRequestDialog()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static OB_LockRequestDialog Initialize()
		{
			return new OB_LockRequestDialog();
		}

		#region Buttons

		private SearchCriteria btn_ExitLoan = SearchCriteria.ByAutomationId("exitBtn");
		private SearchCriteria btn_KeepLoanOpen = SearchCriteria.ByAutomationId("keepBtn");
		//
		public void btn_ExitLoan_Click()
		{
			GetButton(btn_ExitLoan).Click();
		}
		public void btn_KeepLoanOpen_Click()
		{
			GetButton(btn_KeepLoanOpen).Click();
		}

		#endregion

	}
}

