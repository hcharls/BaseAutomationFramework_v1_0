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
	public class CreditReportRequest : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("RequestDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow,};
		public const bool SET_MAXIMIZED = false;

		public CreditReportRequest()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static CreditReportRequest Initialize()
		{
			return new CreditReportRequest();
		}

		#region Text Boxes

		private SearchCriteria txt_UserName = SearchCriteria.ByAutomationId("3063");
		private SearchCriteria txt_Password = SearchCriteria.ByAutomationId("3001");

		public CreditReportRequest txt_UserName_SendKeys(string Input)
		{
			GetTextBox(txt_UserName).Text = Input;

			return this;
		}
		public CreditReportRequest txt_Password_SendKeys(string Input)
		{
			GetTextBox(txt_Password).Text = Input;

			return this;
		}

		#endregion

		#region Checkboxes

		private SearchCriteria chk_SaveLoginInformation = SearchCriteria.ByAutomationId("3112");
		private SearchCriteria chk_Equifax = SearchCriteria.ByAutomationId("3043");
		private SearchCriteria chk_Experian = SearchCriteria.ByAutomationId("3044");
		private SearchCriteria chk_TransUnion = SearchCriteria.ByAutomationId("3111");

		public CreditReportRequest chk_SaveLoginInformation_Check(bool Check)
		{
			ClickCheckBox(Check, chk_SaveLoginInformation);

			return this;
		}
		public CreditReportRequest chk_Equifax_Check(bool Check)
		{
			ClickCheckBox(Check, chk_Equifax);

			return this;
		}
		public CreditReportRequest chk_Experian_Check(bool Check)
		{
			ClickCheckBox(Check, chk_Experian);

			return this;
		}
		public CreditReportRequest chk_TransUnion_Check(bool Check)
		{
			ClickCheckBox(Check, chk_TransUnion);

			return this;
		}

		#endregion

		#region Buttons

		private SearchCriteria btn_Finish = SearchCriteria.ByAutomationId("12325");
		//
		public void btn_Finish_Click()
		{
			GetButton(btn_Finish).Click();
            Thread.Sleep(10000);
            EncompassMain.Initialize().tab_Loan_Select();
           
        }

		#endregion
	}
}