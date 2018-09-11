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
	public class OB_ProductSearch : BaseScreen
	{
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };
		public const bool SET_MAXIMIZED = false;

		public OB_ProductSearch()
		{
			int i = 0;
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.ClassNameProperty, "Internet Explorer_Server");

			do
			{
				aElement = null;
				aeScreen = null;
				Screen = null;
				GC.Collect();
				Thread.Sleep(1000);
				Set_Screen(scArray, SET_MAXIMIZED);
				aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
				aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			} while (aeScreen == null && ++i < 60);

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static OB_ProductSearch Initialize()
		{
			return new OB_ProductSearch();
		}


		#region Buttons

		private PropertyCondition btn_Submit = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnSubmit_search_top");
		//

		public OB_ProductSearch btn_Submit_Click()
		{
			int i = 0;
			do
			{
				aElement = null;
				aeScreen = null;
				Screen = null;
				GC.Collect();
				new OB_ProductSearch();
				Thread.Sleep(1000);
				aElement = fn_DoActionWhileCOMException<TreeScope, PropertyCondition, AutomationElement>((treeScope, condition) => {
					return aeScreen.FindFirst(treeScope, condition);
					}, TreeScope.Descendants, btn_Submit);

				//aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_Submit);

			} while (aElement == null && ++i < 60);
			if (aElement == null)
				throw new Exception("Element could not be located!!!");
			aElement.ClickCenterOfBounds();

			return new OB_ProductSearch();
		}

		#endregion

		#region Text Boxes
		//Lien Information
		private PropertyCondition txt_FirstLienAmt = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanAmount");
		private PropertyCondition txt_SecondLienAmt = new PropertyCondition(AutomationElement.AutomationIdProperty, "OtherFinancing");
		private PropertyCondition txt_HELOCLineAmt = new PropertyCondition(AutomationElement.AutomationIdProperty, "HELOCLineAmount");
		private PropertyCondition txt_HELOCDrawnAmt = new PropertyCondition(AutomationElement.AutomationIdProperty, "HELOCDrawnAmount");
		//Loan Information
		private PropertyCondition txt_PriceEstimatedValue = new PropertyCondition(AutomationElement.AutomationIdProperty, "SalesAmount");
		private PropertyCondition txt_AppraisalAmount = new PropertyCondition(AutomationElement.AutomationIdProperty, "AppraisalAmount");
		private PropertyCondition txt_CashOutAmount = new PropertyCondition(AutomationElement.AutomationIdProperty, "CashoutAmount");
		private PropertyCondition txt_LTV = new PropertyCondition(AutomationElement.AutomationIdProperty, "LTV");
		private PropertyCondition txt_CLTV = new PropertyCondition(AutomationElement.AutomationIdProperty, "CLTV");
		private PropertyCondition txt_HCLTVLineAmt = new PropertyCondition(AutomationElement.AutomationIdProperty, "HCLTVLine");
		private PropertyCondition txt_HCLTVDrawnAmt = new PropertyCondition(AutomationElement.AutomationIdProperty, "HCLTVDrawn");
		private PropertyCondition txt_MonthsofReserves = new PropertyCondition(AutomationElement.AutomationIdProperty, "MonthsReserves");
		//Borrower Information
		private PropertyCondition txt_FICO = new PropertyCondition(AutomationElement.AutomationIdProperty, "FICO");
		private PropertyCondition txt_DTIRatio = new PropertyCondition(AutomationElement.AutomationIdProperty, "DTIRatio");
		//Property Information
		private PropertyCondition txt_NumberofStories = new PropertyCondition(AutomationElement.AutomationIdProperty, "NumOfStories");
		private PropertyCondition txt_PropertyZip = new PropertyCondition(AutomationElement.AutomationIdProperty, "PropertyZip");
		//First Lien Search Criteria
		private PropertyCondition txt_DesiredPrice = new PropertyCondition(AutomationElement.AutomationIdProperty, "SearchPrice");
		private PropertyCondition txt_DesiredRate = new PropertyCondition(AutomationElement.AutomationIdProperty, "SearchRate");
		private PropertyCondition txt_DesiredLockPeriod = new PropertyCondition(AutomationElement.AutomationIdProperty, "SearchLock_Period");
	


		#endregion

		#region Combo Boxes
		//Loan Information
		private PropertyCondition cmb_LoanPurpose = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPurpose");
		private PropertyCondition cmb_WaiveEscrows = new PropertyCondition(AutomationElement.AutomationIdProperty, "WaiveEscrows");
		private PropertyCondition cmb_CurrentServicer = new PropertyCondition(AutomationElement.AutomationIdProperty, "CurrentServicer");
		//Borrower Information
		private PropertyCondition cmb_SelfEmployed = new PropertyCondition(AutomationElement.AutomationIdProperty, "SelfEmployed");
		private PropertyCondition cmb_IncomeDocumentation = new PropertyCondition(AutomationElement.AutomationIdProperty, "IncomeDocumentation");
		private PropertyCondition cmb_AssetDocumentation = new PropertyCondition(AutomationElement.AutomationIdProperty, "AssetDocumentation");
		private PropertyCondition cmb_EmploymentDocumentation = new PropertyCondition(AutomationElement.AutomationIdProperty, "EmploymentDocumentation");
		private PropertyCondition cmb_Citizenship = new PropertyCondition(AutomationElement.AutomationIdProperty, "Citizenship");
		private PropertyCondition cmb_FirstTimeHomeBuyer = new PropertyCondition(AutomationElement.AutomationIdProperty, "FirstTimeHomeBuyer");
		private PropertyCondition cmb_NonOccupantCoBorrower = new PropertyCondition(AutomationElement.AutomationIdProperty, "NonOccCoborrower");
		//Property Information
		private PropertyCondition cmb_Occupancy = new PropertyCondition(AutomationElement.AutomationIdProperty, "Occupancy");
		private PropertyCondition cmb_NumberofUnits = new PropertyCondition(AutomationElement.AutomationIdProperty, "NumofUnits");
		private PropertyCondition cmb_State = new PropertyCondition(AutomationElement.AutomationIdProperty, "State");
		private PropertyCondition cmb_County = new PropertyCondition(AutomationElement.AutomationIdProperty, "County");
		private PropertyCondition cmb_CorporateRelocation = new PropertyCondition(AutomationElement.AutomationIdProperty, "CorporateRelo");
		//First Lien Search Criteria
		private PropertyCondition cmb_InterestOnly = new PropertyCondition(AutomationElement.AutomationIdProperty, "InterestOnly");
		private PropertyCondition cmb_Buydown = new PropertyCondition(AutomationElement.AutomationIdProperty, "TemporaryBuydown");
		private PropertyCondition cmb_BorrowerPaysMI = new PropertyCondition(AutomationElement.AutomationIdProperty, "MIOption");
		private PropertyCondition cmb_AutomatedUWSystem = new PropertyCondition(AutomationElement.AutomationIdProperty, "AUS");
		private PropertyCondition cmb_PrepaymentPenalty = new PropertyCondition(AutomationElement.AutomationIdProperty, "PrepayPenalty");
		private PropertyCondition cmb_FHACaseAssigned = new PropertyCondition(AutomationElement.AutomationIdProperty, "FHACaseNumberTimeframe");


		#endregion

		#region Checkboxes
		//Loan Types
		private PropertyCondition chk_Conforming = new PropertyCondition(AutomationElement.AutomationIdProperty, "check_LoanType_1");
		private PropertyCondition chk_NonConforming = new PropertyCondition(AutomationElement.AutomationIdProperty, "check_LoanType_2");
		private PropertyCondition chk_FHA = new PropertyCondition(AutomationElement.AutomationIdProperty, "check_LoanType_3");
		private PropertyCondition chk_VA = new PropertyCondition(AutomationElement.AutomationIdProperty, "check_LoanType_4");
		private PropertyCondition chk_USDA = new PropertyCondition(AutomationElement.AutomationIdProperty, "check_LoanType_5");
		//Loan Terms
		private PropertyCondition chk_30Yr = new PropertyCondition(AutomationElement.AutomationIdProperty, "check_LoanTerm_1");
		private PropertyCondition chk_20Yr = new PropertyCondition(AutomationElement.AutomationIdProperty, "check_LoanTerm_2");
		private PropertyCondition chk_15Yr = new PropertyCondition(AutomationElement.AutomationIdProperty, "check_LoanTerm_3");
		private PropertyCondition chk_10Yr = new PropertyCondition(AutomationElement.AutomationIdProperty, "check_LoanTerm_4");
		//Amortization Types
		private PropertyCondition chk_Fixed = new PropertyCondition(AutomationElement.AutomationIdProperty, "check_AmortizationType_1");
		private PropertyCondition chk_ARM = new PropertyCondition(AutomationElement.AutomationIdProperty, "check_AmortizationType_2");
		//ARM Fixed Terms
		private PropertyCondition chk_5YrARM = new PropertyCondition(AutomationElement.AutomationIdProperty, "check_ARMFixedTerm_Index_1");
		private PropertyCondition chk_7YrARM = new PropertyCondition(AutomationElement.AutomationIdProperty, "check_ARMFixedTerm_Index_2");
		private PropertyCondition chk_10YrARM = new PropertyCondition(AutomationElement.AutomationIdProperty, "check_ARMFixedTerm_Index_3");

		#endregion
	}
}