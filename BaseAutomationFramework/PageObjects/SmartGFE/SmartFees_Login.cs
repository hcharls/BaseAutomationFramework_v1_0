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
	public class SmartFees_Login : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("FrmAuthUser");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;

		public SmartFees_Login()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
            aeScreen = Screen.AutomationElement;
        }

		public static SmartFees_Login Initialize()
		{
			return new SmartFees_Login();
		}

		#region Text Boxes

		private SearchCriteria txt_Username = SearchCriteria.ByAutomationId("tbUserName");
		private SearchCriteria txt_Password = SearchCriteria.ByAutomationId("tbPassword");

		public SmartFees_Login txt_Username_SendKeys(string Input)
		{
            GetTextBox(txt_Username).Text = Input;

            return this;
        }
		public SmartFees_Login txt_Password_SendKeys(string Input)
		{
            GetTextBox(txt_Password).Text = Input;

            return this;
        }

		#endregion

		#region Buttons

		private SearchCriteria btn_Login = SearchCriteria.ByAutomationId("btLogin");
		//
		public void btn_Login_Click()
		{
            GetButton(btn_Login).Click();
            Thread.Sleep(20000);
            
        }

		#endregion
	}
}