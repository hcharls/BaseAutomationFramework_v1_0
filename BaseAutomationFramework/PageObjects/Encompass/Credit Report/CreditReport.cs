///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Namespace>
///   Class:          <CreditReport>
///   Description:    <Credit_Report_window>
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
using TestStack.White.UIItems.ListBoxItems;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class CreditReport : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("OrderDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;

		public CreditReport()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static CreditReport Initialize()
		{
			return new CreditReport();
		}

		#region List Items

		private SearchCriteria lstbx_Providers = SearchCriteria.ByAutomationId("myLst");
		//
		private ListBox lstbx_Providers_Return()
		{
			return GetListBox(lstbx_Providers);
		}
		public CreditReport lstbx_Provider_Select(string ProviderName)
		{
			lstbx_Providers_Return().Select(ProviderName);

			return new CreditReport();
		}

		#endregion


		#region Buttons

		private SearchCriteria btn_Submit = SearchCriteria.ByAutomationId("submitBtn");
		//

		public void btn_Submit_Click()
		{
			GetButton(btn_Submit).Click();
		}

		#endregion
	}
}