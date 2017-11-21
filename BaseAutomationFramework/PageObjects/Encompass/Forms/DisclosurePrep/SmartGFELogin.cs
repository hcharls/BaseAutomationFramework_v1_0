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

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class SmartGFELogin : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("FrmAuthUser");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, VerificationOfEmployment.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		public SmartGFELogin()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static SmartGFELogin Initialize()
		{
			return new SmartGFELogin();
		}

		#region Buttons

		private SearchCriteria btn_Cancel = SearchCriteria.ByAutomationId("btCancel");

		//
		public void btn_Cancel_Click()
		{
			GetButton(btn_Cancel).Click();
		}

		#endregion
	}
}