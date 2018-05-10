///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Namespace>
///   Class:          <eSignDocuments>
///   Description:    <eSign_Documents>
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
using System.Threading.Tasks;
using System.Windows;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class eSignDocuments : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("DocuSignSigning");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;

		public eSignDocuments()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static eSignDocuments Initialize()
		{
			return new eSignDocuments();
		}

		#region Buttons

		private SearchCriteria btn_Next = SearchCriteria.ByAutomationId("action-bar-btn-continue");
		private SearchCriteria btn_Start = SearchCriteria.ByAutomationId("navigate-btn");
		private SearchCriteria btn_eSign = SearchCriteria.ByText("Required - Sign Here");
		private SearchCriteria btn_Finish = SearchCriteria.ByAutomationId("action-bar-btn-finish");

		//
		public eSignDocuments btn_Next_Click()
		{
			GetButton(btn_Next).Click();

			return new eSignDocuments();
		}
		public eSignDocuments btn_Start_Click()
		{
			GetButton(btn_Start).Click();

			return new eSignDocuments();
		}
		public eSignDocuments btn_eSign_Click()
		{
			GetButton(btn_eSign).Click();

			return new eSignDocuments();
		}
		public void btn_Finish_Click()
		{
			GetButton(btn_Finish).Click();
		}


		#endregion

	}
}
