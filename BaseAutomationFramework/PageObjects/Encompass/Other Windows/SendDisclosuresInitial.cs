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
	public class SendDisclosuresInitial : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("SendDisclosuresDialog");
		public static SearchCriteria[] scArray = { Encompass_eFolder.scWindow, SelectDocumentsInitial.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		private AutomationElement aePanel = null;

		public SendDisclosuresInitial()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
            aeScreen = Screen.AutomationElement;
            aePanel = null;
		}

		public static SendDisclosuresInitial Initialize()
		{
			return new SendDisclosuresInitial();
		}

		#region Buttons

		private SearchCriteria btn_Send = SearchCriteria.ByAutomationId("btnSend");

		public void btn_Send_Click()
		{
			GetButton(btn_Send).Click();
			Thread.Sleep(2000);
		}

		#endregion

		#region Text Boxes

		private PropertyCondition txt_BorrowerAuthorization = new PropertyCondition(AutomationElement.AutomationIdProperty, "txtAuthenticationCode");
		//
		public SendDisclosuresInitial txt_BorrowerAuthorization_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_BorrowerAuthorization);
			Thread.Sleep(1000);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return new SendDisclosuresInitial();
		}

		#endregion

		#region Combo Boxes

		private PropertyCondition cmb_BorrowerAuthenticationMethod = new PropertyCondition(AutomationElement.AutomationIdProperty, "cboAuthentication");
		//
		public SendDisclosuresInitial cmb_BorrowerAuthenticationMethod_SendKeys(string Input)
		{
            aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_BorrowerAuthenticationMethod);
            aElement.SetFocus();
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(1000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            Thread.Sleep(1000);
            return this;
        }

		#endregion


	}
}
