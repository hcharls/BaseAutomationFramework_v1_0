///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <VA>
///   Class:          <Partners_VA_CashOutRefi>
///   Description:    <>
///   Author:         <Hannah_Charls>           Date: <Novmeber_21_2017>
///   Notes:          <>
///   Revision History:
///   Name:				 Date:					Description:
///   
/// 
///------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using BaseAutomationFramework.PageObjects.Encompass;
using NUnit.Framework;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using BaseAutomationFramework.Tools;
using BaseAutomationFramework.DataObjects;
using System.Threading;
using System.IO;
using BaseAutomationFramework.HTML_Report;

namespace BaseAutomationFramework.Tests.Encompass.LoanCreation.VA
{
	[TestFixture]
	public class Partners_VA_CashOutRefi : BaseTest
	{
		private StreamWriter SW;
		private StatusReport SR;
		string runTime;
		string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
		string pathStem;

		[GetTestSet("Test")]
		[TestCaseSource(typeof(GetTestData), "Screen")]
		public void EncompassNewLoanCreation(IDictionary<string, string> data)
		{
			MasterData = new objMasterData(data);
			MasterData.TestResultPathStem = pathStem;

			Step step = new Step();

			step.Action = string.Format("Test: {0}", MasterData.TestID);
			step.ExpectedResult = string.Format("");
			step.ActualResult = string.Format("");
			step.Status = "Pass";
			step.Time = DateTime.Now.ToString();

			try
			{
				AttachToProcess(Processes.Encompass, 5);

				#region Co-Borrower

				//Pipeline
				//	.Initialize()
				//	.btn_NewLoan_Click();

				//NewLoan
				//	.Initialize()
				//	.cmb_LoanTemplateFolder_SelectByText("PEM Partners")
				//	.SelectItem_PartnersVARefinance();

				//FormsTab
				//	.Initialize()
				//	.chk_Show_Check(true)
				//	.chk_ShowInAlpha_Check(true);

				//BorrowerSummary
				//	.Initialize()
				//	.txt_FirstName_SendKeys(MasterData.BorrowerFirstName)
				//	.txt_LastName_SendKeys(MasterData.BorrowerLastName)
				//	.txt_SocialSecurityNumber_SendKeys(MasterData.BorrowerSSN)
				//	.txt_DOB_SendKeys(MasterData.BorrowerDOB)
				//	.txt_HomePhone_SendKeys(MasterData.HomePhone)
				//	.txt_MaritalStatus_SendKeys("u")
				//	.txt_HomeEmail_SendKeys(MasterData.HomeEmail)
				//	.txt_PresentAddress_SendKeys(MasterData.Address)
				//	.txt_PresentZip_SendKeys(MasterData.Zip)
				//	.txt_NumberofYears_SendKeys("10")
				//	.txt_NumberofMonths_SendKeys("11")
				//	.chk_PresentAddress_OwnRent_Check("Own")
				//	.btn_CopyfromBorrower_Click()
				//	.txt_CoBorrowerFirstName_SendKeys(MasterData.CoBorrowerFirstName)
				//	.txt_CoBorrowerSocialSecurityNumber_SendKeys(MasterData.CoBorrowerSSN)
				//	.txt_CoBorrowerDOB_SendKeys(MasterData.CoBorrowerDOB)
				//	.txt_CoBorrowerHomeEmail_SendKeys(MasterData.HomeEmail)
				//	.cmb_InformationProvidedBy_SendKeys(MasterData.InformationProvidedBy)
				//	.chk_BorrowerVerbalAuthForCreditPull_Check(true)
				//	.btn_CopyfromPresent_Click()
				//	.txt_EstimatedValue_SendKeys(MasterData.EstimatedValue)
				//	.txt_AppraisedValue_SendKeys(MasterData.AppraisedValue)
				//	.chk_LoanPurpose_Check("Cash-Out Refi")
				//	.chk_PropertyWillBe_Check(MasterData.PropertyWillBe)
				//	.txt_LoanAmount_SendKeys(MasterData.LoanAmount);

				//EncompassDialog
				//	.Initialize()
				//	.btn_OK_Click();

				//URLA_Page1
				//	.OpenForm_FromFormsTab()
				//	.txt_NoUnits_SendKeys("1")
				//	.txt_YearBuilt_SendKeys("2006")
				//	.txt_OriginalCost_SendKeys(MasterData.LoanAmount)
				//	.txt_ExistingLien_SendKeys(MasterData.LoanAmount)
				//	.cmb_SourceofDownPayment_SendKeys("Checking/Savings")
				//	.txt_School_SendKeys("20")
				//	.txt_Dependents_SendKeys("0")
				//	.chk_MailingAddress_Check("Same as present")
				//	.txt_CoBorrowerSchool_SendKeys("20")
				//	.txt_CoBorrowerDependents_SendKeys("0")
				//	.chk_CoBorrowerMailingAddress_Check("Same as present");

				//VerificationOfEmployment
				//	.OpenFromURLA_Page1()
				//	.btn_VOENewVerif_Click();

				//VOE_NewEmployment
				//	.Initialize()
				//	.rdb_Borrower_Select()
				//	.rdb_EmploymentStatus_Select()
				//	.btn_OK_Click();

				//VerificationOfEmployment
				//	.Initialize()
				//	.txt_EmployerName_SendKeys("test")
				//	.txt_EmployerAttn_SendKeys("test")
				//	.txt_EmployerAddress_SendKeys("test")
				//	.txt_EmployerZip_SendKeys("90210")
				//	.txt_EmployerPhone_SendKeys("5646546544")
				//	.txt_EmployerEmail_SendKeys("test@test.com")
				//	.txt_BusinessName_SendKeys("test")
				//	.txt_BusinessPhone_SendKeys("5646546544")
				//	.txt_BusinessPosition_SendKeys("test")
				//	.txt_DateHired_SendKeys("063000")
				//	.txt_YearsinthisJob_SendKeys("17")
				//	.txt_MonthsinthisJob_SendKeys("0")
				//	.txt_YearsinLineofWork_SendKeys("17")
				//	.txt_BasePay_SendKeys("6500")
				//	.btn_VOEClose_Click();

				//URLA_Page2
				//	.OpenForm_FromFormsTab()
				//	.btn_EditFieldValueBorrowerBase_Click();

				//URLA_Page2_CalculateBaseIncome
				//	.Initialize()
				//	.chk_CopyfrompresentjobinVOE_Check(true)
				//	.btn_OK_Click();

				//VerificationOfDepository
				//	.OpenFromURLA_Page2()
				//	.btn_VODNewVerif_Click()
				//	.cmb_VODisfor_SendKeys("Borrower")
				//	.txt_DepositoryName_SendKeys("test")
				//	.txt_DepositoryAttn_SendKeys("test")
				//	.txt_DepositoryAddress_SendKeys("test")
				//	.txt_DepositoryZip_SendKeys("90210")
				//	.txt_DepositoryPhone_SendKeys("5646546544")
				//	.txt_DepositoryEmail_SendKeys("test@test.com")
				//	.txt_AccountType1_SendKeys("Checking Account")
				//	.txt_AccountNumber1_SendKeys("32132132113")
				//	.txt_AccountBalance1_SendKeys("10000")
				//	.txt_AccountType2_SendKeys("Savings Account")
				//	.txt_AccountNumber2_SendKeys("56454656465")
				//	.txt_AccountBalance2_SendKeys("100000")
				//	.btn_VODClose_Click();

				//URLA_Page3
				//	.OpenForm_FromFormsTab()
				//	.btn_EnterDataManually_Refinance_Click()
				//	.txt_Refinance_SendKeys(MasterData.LoanAmount)
				//	.txt_Declaration_a_SendKeys("N")
				//	.txt_Declaration_b_SendKeys("N")
				//	.txt_Declaration_c_SendKeys("N")
				//	.txt_Declaration_d_SendKeys("N")
				//	.txt_Declaration_e_SendKeys("N")
				//	.txt_Declaration_f_SendKeys("N")
				//	.txt_Declaration_g_SendKeys("N")
				//	.txt_Declaration_h_SendKeys("N")
				//	.txt_Declaration_i_SendKeys("N")
				//	.txt_Declaration_j_SendKeys("Y")
				//	.txt_Declaration_k_SendKeys("N")
				//	.txt_Declaration_l_SendKeys("Y")
				//	.txt_Declaration_m_SendKeys("Y")
				//	.txt_Declaration_m1_SendKeys("PR")
				//	.txt_Declaration_m2_SendKeys("S")
				//	.chk_PrimaryBorrower_Ethnicity_Check(MasterData.BorrowerEthnicity)
				//	.chk_PrimaryBorrower_Race_Check(MasterData.BorrowerRace)
				//	.chk_PrimaryBorrower_Sex_Check(MasterData.BorrowerSex)
				//	.txt_CoBorrowerDeclaration_a_SendKeys("N")
				//	.txt_CoBorrowerDeclaration_b_SendKeys("N")
				//	.txt_CoBorrowerDeclaration_c_SendKeys("N")
				//	.txt_CoBorrowerDeclaration_d_SendKeys("N")
				//	.txt_CoBorrowerDeclaration_e_SendKeys("N")
				//	.txt_CoBorrowerDeclaration_f_SendKeys("N")
				//	.txt_CoBorrowerDeclaration_g_SendKeys("N")
				//	.txt_CoBorrowerDeclaration_h_SendKeys("N")
				//	.txt_CoBorrowerDeclaration_i_SendKeys("N")
				//	.txt_CoBorrowerDeclaration_j_SendKeys("Y")
				//	.txt_CoBorrowerDeclaration_k_SendKeys("N")
				//	.txt_CoBorrowerDeclaration_l_SendKeys("Y")
				//	.txt_CoBorrowerDeclaration_m_SendKeys("Y")
				//	.txt_CoBorrowerDeclaration_m1_SendKeys("PR")
				//	.txt_CoBorrowerDeclaration_m2_SendKeys("S")
				//	.chk_CoBorrower_Ethnicity_Check(MasterData.CoBorrowerEthnicity)
				//	.chk_CoBorrower_Race_Check(MasterData.CoBorrowerRace)
				//	.chk_CoBorrower_Sex_Check(MasterData.CoBorrowerSex);

				//VALoanSummary
				//	.OpenForm_FromFormsTab()
				//	.cmb_VeteranInformationfor_SendKeys("Borrower")
				//	.txt_PaidInFullVALoanNumber_SendKeys("564564564")
				//	.txt_OriginalLoanAmount_SendKeys("200000")
				//	.txt_OriginalIntRate_SendKeys("4")
				//	.txt_OriginalTermMths_SendKeys("360");

				//LeadManagementVelocify
				//	.OpenForm_FromFormsTab()
				//	.cmb_PEMPartnersLeadSource_SendKeys("Zillow");

				//BorrowerSummary
				//	.OpenForm_FromFormsTab()
				//	.btn_OrderCredit_Click();

				//CreditReport
				//	.Initialize()
				//	.lstbx_Provider_Select("Equifax Mortgage Solutions")
				//	.btn_Submit_Click();

				//CreditReportRequest
				//	.Initialize()
				//	.txt_UserName_SendKeys("PARAMOUNTIT")
				//	.txt_Password_SendKeys("P@ramount2")
				//	.chk_SaveLoginInformation_Check(true)
				//	.chk_Equifax_Check(true)
				//	.chk_Experian_Check(true)
				//	.chk_TransUnion_Check(true)
				//	.btn_Finish_Click();

				//EncompassMain
				//	.Initialize()
				//	.tab_Loan_Select();

				//TransmittalSummary
				//	.OpenForm_FromFormsTab()
				//	.cmb_PropertyType_SendKeys("1 unit");

				//BankerLoanSubmission
				//	.OpenForm_FromFormsTab()
				//	.txt_LastMortgagePayment_SendKeys("081517")
				//	.txt_ClosingMonthPayment_SendKeys("test")
				//	.cmb_CreditOnNonBorrowingSpouse_SendKeys("CONFIRMED")
				//	.txt_PestInspection_SendKeys("test")
				//	.btn_BankerCertificationBLS_Click();

				//EncompassMain
				//	.Initialize()
				//	.SaveAndExitLoan();

				//EncompassDialog
				//	.Initialize()
				//	.btn_Yes_Click();

				//ComplianceAlert
				//	.Initialize()
				//	.btn_Close_Click();

				#endregion Co-Borrower

				#region Single Borrower

				Pipeline
					.Initialize()
					.btn_NewLoan_Click();

				NewLoan
					.Initialize()
					.cmb_LoanTemplateFolder_SelectByText("PEM Partners")
					.SelectItem_PartnersVARefinance();

				FormsTab
					.Initialize()
					.chk_Show_Check(true)
					.chk_ShowInAlpha_Check(true);

				BorrowerSummary
					.Initialize()
					.txt_FirstName_SendKeys(MasterData.BorrowerFirstName)
					.txt_LastName_SendKeys(MasterData.BorrowerLastName)
					.txt_SocialSecurityNumber_SendKeys(MasterData.BorrowerSSN)
					.txt_DOB_SendKeys(MasterData.BorrowerDOB)
					.txt_HomePhone_SendKeys(MasterData.HomePhone)
					.txt_MaritalStatus_SendKeys("u")
					.txt_HomeEmail_SendKeys(MasterData.HomeEmail)
					.txt_PresentAddress_SendKeys(MasterData.Address)
					.txt_PresentZip_SendKeys(MasterData.Zip)
					.txt_NumberofYears_SendKeys("10")
					.txt_NumberofMonths_SendKeys("11")
					.chk_PresentAddress_OwnRent_Check("Own")
					.cmb_InformationProvidedBy_SendKeys(MasterData.InformationProvidedBy)
					.chk_BorrowerVerbalAuthForCreditPull_Check(true)
					.btn_CopyfromPresent_Click()
					.txt_EstimatedValue_SendKeys(MasterData.EstimatedValue)
					.txt_AppraisedValue_SendKeys(MasterData.AppraisedValue)
					.chk_LoanPurpose_Check("Cash-Out Refi")
					.chk_PropertyWillBe_Check(MasterData.PropertyWillBe)
					.txt_LoanAmount_SendKeys(MasterData.LoanAmount);

				EncompassDialog
					.Initialize()
					.btn_OK_Click();

				URLA_Page1
					.OpenForm_FromFormsTab()
					.txt_NoUnits_SendKeys("1")
					.txt_YearBuilt_SendKeys("2006")
					.txt_OriginalCost_SendKeys(MasterData.LoanAmount)
					.txt_ExistingLien_SendKeys(MasterData.LoanAmount)
					.cmb_SourceofDownPayment_SendKeys("Checking/Savings")
					.txt_School_SendKeys("20")
					.txt_Dependents_SendKeys("0")
					.chk_MailingAddress_Check("Same as present");

				VerificationOfEmployment
					.OpenFromURLA_Page1()
					.btn_VOENewVerif_Click();

				VOE_NewEmployment
					.Initialize()
					.rdb_Borrower_Select()
					.rdb_EmploymentStatus_Select()
					.btn_OK_Click();

				VerificationOfEmployment
					.Initialize()
					.txt_EmployerName_SendKeys("test")
					.txt_EmployerAttn_SendKeys("test")
					.txt_EmployerAddress_SendKeys("test")
					.txt_EmployerZip_SendKeys("90210")
					.txt_EmployerPhone_SendKeys("5646546544")
					.txt_EmployerEmail_SendKeys("test@test.com")
					.txt_BusinessName_SendKeys("test")
					.txt_BusinessPhone_SendKeys("5646546544")
					.txt_BusinessPosition_SendKeys("test")
					.txt_DateHired_SendKeys("063000")
					.txt_YearsinthisJob_SendKeys("17")
					.txt_MonthsinthisJob_SendKeys("0")
					.txt_YearsinLineofWork_SendKeys("17")
					.txt_BasePay_SendKeys("6500")
					.btn_VOEClose_Click();

				URLA_Page2
					.OpenForm_FromFormsTab()
					.btn_EditFieldValueBorrowerBase_Click();

				URLA_Page2_CalculateBaseIncome
					.Initialize()
					.chk_CopyfrompresentjobinVOE_Check(true)
					.btn_OK_Click();

				VerificationOfDepository
					.OpenFromURLA_Page2()
					.btn_VODNewVerif_Click()
					.cmb_VODisfor_SendKeys("Borrower")
					.txt_DepositoryName_SendKeys("test")
					.txt_DepositoryAttn_SendKeys("test")
					.txt_DepositoryAddress_SendKeys("test")
					.txt_DepositoryZip_SendKeys("90210")
					.txt_DepositoryPhone_SendKeys("5646546544")
					.txt_DepositoryEmail_SendKeys("test@test.com")
					.txt_AccountType1_SendKeys("Checking Account")
					.txt_AccountNumber1_SendKeys("32132132113")
					.txt_AccountBalance1_SendKeys("10000")
					.txt_AccountType2_SendKeys("Savings Account")
					.txt_AccountNumber2_SendKeys("56454656465")
					.txt_AccountBalance2_SendKeys("100000")
					.btn_VODClose_Click();

				URLA_Page3
					.OpenForm_FromFormsTab()
					.btn_EnterDataManually_Refinance_Click()
					.txt_Refinance_SendKeys(MasterData.LoanAmount)
					.txt_Declaration_a_SendKeys("N")
					.txt_Declaration_b_SendKeys("N")
					.txt_Declaration_c_SendKeys("N")
					.txt_Declaration_d_SendKeys("N")
					.txt_Declaration_e_SendKeys("N")
					.txt_Declaration_f_SendKeys("N")
					.txt_Declaration_g_SendKeys("N")
					.txt_Declaration_h_SendKeys("N")
					.txt_Declaration_i_SendKeys("N")
					.txt_Declaration_j_SendKeys("Y")
					.txt_Declaration_k_SendKeys("N")
					.txt_Declaration_l_SendKeys("Y")
					.txt_Declaration_m_SendKeys("Y")
					.txt_Declaration_m1_SendKeys("PR")
					.txt_Declaration_m2_SendKeys("S")
					.chk_PrimaryBorrower_Ethnicity_Check(MasterData.BorrowerEthnicity)
					.chk_PrimaryBorrower_Race_Check(MasterData.BorrowerRace)
					.chk_PrimaryBorrower_Sex_Check(MasterData.BorrowerSex);

				VALoanSummary
					.OpenForm_FromFormsTab()
					.cmb_VeteranInformationfor_SendKeys("Borrower")
					.txt_PaidInFullVALoanNumber_SendKeys("564564564")
					.txt_OriginalLoanAmount_SendKeys("200000")
					.txt_OriginalIntRate_SendKeys("4")
					.txt_OriginalTermMths_SendKeys("360");

				LeadManagementVelocify
					.OpenForm_FromFormsTab()
					.cmb_PEMPartnersLeadSource_SendKeys("Zillow");

				BorrowerSummary
					.OpenForm_FromFormsTab()
					.btn_OrderCredit_Click();

				CreditReport
					.Initialize()
					.lstbx_Provider_Select("Equifax Mortgage Solutions")
					.btn_Submit_Click();

				CreditReportRequest
					.Initialize()
					.txt_UserName_SendKeys("PARAMOUNTIT")
					.txt_Password_SendKeys("P@ramount2")
					.chk_SaveLoginInformation_Check(true)
					.chk_Equifax_Check(true)
					.chk_Experian_Check(true)
					.chk_TransUnion_Check(true)
					.btn_Finish_Click();

				EncompassMain
					.Initialize()
					.tab_Loan_Select();

				TransmittalSummary
					.OpenForm_FromFormsTab()
					.cmb_PropertyType_SendKeys("1 unit");

				BankerLoanSubmission
					.OpenForm_FromFormsTab()
					.txt_LastMortgagePayment_SendKeys("081517")
					.txt_ClosingMonthPayment_SendKeys("test")
					.cmb_CreditOnNonBorrowingSpouse_SendKeys("CONFIRMED")
					.txt_PestInspection_SendKeys("test")
					.btn_BankerCertificationBLS_Click();

				EncompassMain
					.Initialize()
					.SaveAndExitLoan();

				EncompassDialog
					.Initialize()
					.btn_Yes_Click();

				ComplianceAlert
					.Initialize()
					.btn_Close_Click();

				#endregion Single Borrower


			}

			catch (Exception ex)
			{
				step.ModalText = ex.ToString();
				step.Status = "Fail";
				step.ScreenShotLocation = Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format("Failure\\{0}", System.Reflection.MethodBase.GetCurrentMethod().Name));
				Assert.Fail(ex.ToString());
			}
			finally
			{
				Report.addStep(step);
			}

		}

		[TestFixtureSetUp]
		public void OnFixtureSetup()
		{
			runTime = CreateRuntimeString();
			Report = StatusReport.getStatusReport();
			string sub1 = string.Format("Tester: {0}", Environment.UserName);
			string sub2 = string.Format("Release Version: {0}", "Not Assigned");
			List<string> subheaders = new List<string>() { sub1, sub2 };
			this.pathStem = string.Format("{0}\\{1}\\{2} - {3}", FileUtilities.DefaultTestResultDirectory, className, Environment.UserName, runTime);
			string path = string.Format("{0}\\{1}.html", pathStem, "Results");
			Report.reportSetup("Demo Script", path, null, subheaders);
		}

		[SetUp]
		public void BeforeEachTest()
		{

		}

		[TearDown]
		public void AfterEachTest()
		{

		}

		[TestFixtureTearDown]
		public void OnFixtureTearDown()
		{
			Report.writeReport();
		}
	}
}