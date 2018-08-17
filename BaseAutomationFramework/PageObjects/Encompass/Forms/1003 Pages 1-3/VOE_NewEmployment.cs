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
	public class VOE_NewEmployment : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("NewResidenceDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, VerificationOfEmployment.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		public VOE_NewEmployment()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static VOE_NewEmployment Initialize()
		{
			return new VOE_NewEmployment();
		}

		#region Buttons

		private SearchCriteria btn_OK = SearchCriteria.ByAutomationId("okBtn");

		//
		public void btn_OK_Click()
		{
			GetButton(btn_OK).Click();
		}

		#endregion

		#region Radio Buttons

		private SearchCriteria rdb_Borrower = SearchCriteria.ByAutomationId("brwBtn");
		private SearchCriteria rdb_EmploymentStatus = SearchCriteria.ByAutomationId("currentBtn");
		//
		public VOE_NewEmployment rdb_Borrower_Select()
		{
			GetRadioButton(rdb_Borrower).Click();

			return new VOE_NewEmployment();
		}
		public VOE_NewEmployment rdb_EmploymentStatus_Select()
		{
			GetRadioButton(rdb_EmploymentStatus).Click();

			return new VOE_NewEmployment();
		}

		#endregion 

	}
}