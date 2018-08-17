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
	public class MortgageInsurance : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("OrderDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
				
		public MortgageInsurance()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static MortgageInsurance Initialize()
		{
			return new MortgageInsurance();
		}

		public static MortgageInsurance OpenFrom_MainMenu()
		{
			new EncompassMain()
				.mnu_Services_Click()
				.mnu_MortgageInsurance_Click();

			return new MortgageInsurance();
		}

		#region List Items

		private SearchCriteria lstbx_Providers = SearchCriteria.ByAutomationId("myLst");
		//
		private ListBox lstbx_Providers_Return()
		{
			return GetListBox(lstbx_Providers);
		}
		public MortgageInsurance lstbx_Provider_Select(string ProviderName)
		{
			lstbx_Providers_Return().Select(ProviderName);

			return new MortgageInsurance();
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