﻿///------------------------------------------------------------------------------------------------------------------------
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
            aeScreen = Screen.AutomationElement;
            aePanel = null;
		}

		public static SendDisclosures Initialize()
		{
			return new SendDisclosures();
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

		private PropertyCondition txt_BorrowerAuthorization = new PropertyCondition(AutomationElement.AutomationIdProperty, "txtBorrPassword");
		//
		public SendDisclosures txt_BorrowerAuthorization_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_BorrowerAuthorization);
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
