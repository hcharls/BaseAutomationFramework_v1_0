///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Namespace>
///   Class:          <SendDisclosures>
///   Description:    <Send_Disclosures_window>
///   Author:         <Hannah_Charls>           Date: <Novmeber_21_2017>
///   Notes:          <>
///   Revision History:
///   Name:				 Date:					Description:
///   
/// 
///------------------------------------------------------------------------------------------------------------------------

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
	public class SendDisclosures : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("SendDisclosuresDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, SelectDocuments.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		private AutomationElement aePanel = null;

		public SendDisclosures()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
			aePanel = null;
		}

		public static SendDisclosures Initialize()
		{
			return new SendDisclosures();
		}

		#region Panel

		private PropertyCondition pne_MainPanel = new PropertyCondition(AutomationElement.AutomationIdProperty, "gcSigning");
		//
		private void SetPanel()
		{
			int i = 0;
			do
			{
				aePanel = null;
				aeScreen = null;
				Screen = null;
				GC.Collect();
				new SendConsent();
				Thread.Sleep(1000);
				aePanel = Screen.AutomationElement.FindFirst(TreeScope.Descendants, pne_MainPanel);

			} while (aePanel == null && i++ < 60);
			if (aePanel == null)
				throw new Exception("Could not find the embedded panel!");
		}

		#endregion

		#region Buttons

		private SearchCriteria btn_Send = SearchCriteria.ByAutomationId("btnSend");

		public void btn_Send_Click()
		{
			GetButton(btn_Send).Click();
			Thread.Sleep(2000);
		}

		#endregion

		#region Text Boxes

		private PropertyCondition txt_BorrowerAuthorization = new PropertyCondition(AutomationElement.AutomationIdProperty, "txtBorrPassword");
		//
		public SendDisclosures txt_BorrowerAuthorization_SendKeys(string Input)
		{
			SetPanel();
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_BorrowerAuthorization);
			Thread.Sleep(1000);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return new SendDisclosures();
		}

		#endregion

		#region Combo Boxes

		private PropertyCondition cmb_BorrowerAuthenticationMethod = new PropertyCondition(AutomationElement.AutomationIdProperty, "cboAuthentication");
		//
		public SendDisclosures cmb_BorrowerAuthenticationMethod_SendKeys(string Input)
		{
			SetPanel();
			aElement = aePanel.FindFirst(TreeScope.Descendants, cmb_BorrowerAuthenticationMethod);
			aElement.ClickCenterOfBounds();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(3000);

			return new SendDisclosures();
		}

		#endregion


	}
}
