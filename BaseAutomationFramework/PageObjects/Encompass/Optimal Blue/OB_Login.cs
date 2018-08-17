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
	public class OB_Login : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("RequestDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;

		public OB_Login()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static OB_Login Initialize()
		{
			return new OB_Login();
		}

		#region Text Boxes

		private SearchCriteria txt_LoginName = SearchCriteria.ByAutomationId("tbLoginName");
		private SearchCriteria txt_Password = SearchCriteria.ByAutomationId("tbPassword");

		public OB_Login txt_LoginName_SendKeys(string Input)
		{
			GetTextBox(txt_LoginName).Text = Input;

			return this;
		}
		public OB_Login txt_Password_SendKeys(string Input)
		{
			GetTextBox(txt_Password).Text = Input;

			return this;
		}

		#endregion

		#region Checkboxes

		private SearchCriteria chk_SaveLoginInformation = SearchCriteria.ByAutomationId("cbSaveLoginInformation");
		private SearchCriteria chk_UpdateUpfrontMIdataforFHAloans = SearchCriteria.ByAutomationId("cbMIupdate");

		public OB_Login chk_SaveLoginInformation_Check(bool Check)
		{
			ClickCheckBox(Check, chk_SaveLoginInformation);

			return this;
		}
		public OB_Login chk_UpdateUpfrontMIdataforFHAloans_Check(bool Check)
		{
			ClickCheckBox(Check, chk_UpdateUpfrontMIdataforFHAloans);

			return this;
		}

		#endregion

		#region Buttons

		private SearchCriteria btn_Continue = SearchCriteria.ByAutomationId("btnContinue");
		//
		public void btn_Continue_Click()
		{
			GetButton(btn_Continue).Click();
			Thread.Sleep(10000);
		}

		#endregion
	}
}