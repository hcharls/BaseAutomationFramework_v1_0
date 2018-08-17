using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems.Finders;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class Login : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoginScreen");
		public static SearchCriteria[] scArray = { scWindow };
		public const bool SET_MAXIMIZED = false;

		public Login()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static Login Initialize()
		{
			return new Login();
		}

		#region Buttons

		private SearchCriteria btn_Login = SearchCriteria.ByAutomationId("okBtn");
		//
		public void btn_Login_Click()
		{
			GetButton(btn_Login).Click();	
		}

		#endregion

		#region Text Boxes

		private SearchCriteria txt_Username = SearchCriteria.ByAutomationId("loginNameBox");
		private SearchCriteria txt_Password = SearchCriteria.ByAutomationId("passwordBox");
		//
		public Login txt_Username_SendKeys(string Username)
		{
			GetTextBox(txt_Username).Text = Username;

			return this;
		}
		public Login txt_Password_SendKeys(string Password)
		{
			GetTextBox(txt_Password).Text = Password;

			return this;
		}

		#endregion


	}
}
