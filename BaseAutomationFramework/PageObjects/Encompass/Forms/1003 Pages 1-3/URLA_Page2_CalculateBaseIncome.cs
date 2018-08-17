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
	public class URLA_Page2_CalculateBaseIncome : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("BorIncomeDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		public URLA_Page2_CalculateBaseIncome()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static URLA_Page2_CalculateBaseIncome Initialize()
		{
			return new URLA_Page2_CalculateBaseIncome();
		}

		#region Checkboxes

		private SearchCriteria chk_CopyfrompresentjobinVOE = SearchCriteria.ByAutomationId("copyVOEChk");

		public URLA_Page2_CalculateBaseIncome chk_CopyfrompresentjobinVOE_Check(bool Check)
		{
			ClickCheckBox(Check, chk_CopyfrompresentjobinVOE);

			return new URLA_Page2_CalculateBaseIncome();
		}

		#endregion

		#region Buttons

		private SearchCriteria btn_OK = SearchCriteria.ByAutomationId("okBtn");

		public void btn_OK_Click()
		{
			GetButton(btn_OK).Click();
			Thread.Sleep(1000);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.ESCAPE);
		}

		#endregion
	}
}