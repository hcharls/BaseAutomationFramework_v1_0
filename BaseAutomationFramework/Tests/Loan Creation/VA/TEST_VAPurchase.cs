using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using BaseAutomationFramework.PageObjects.Encompass;
using BaseAutomationFramework.PageObjects.Firefox;
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

namespace BaseAutomationFramework.Tests.Encompass
{
	[TestFixture]
	public class VA_Purchase : BaseTest
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

				#region Launch, Login, and create new loan

				//LaunchApplication(DesktopApps.Encompass);

				//Launcher
				//	.Initialize()
				//	.cmb_EnvironmentID_SelectByText("TEBE11141905")
				//	.btn_Login_Click();

				//Login
				//	.Initialize()
				//	.txt_Username_SendKeys("test_qa_lo")
				//	.txt_Password_SendKeys("P@ramount1")
				//	.btn_Login_Click();

				//EncompassMain
				//	.Initialize();
				//Thread.Sleep(10000);

				//EncompassMain
				//	.Initialize()
				//	.Resize()
				//	.tab_Pipeline_Select();

				//PipelineView
				//	.Initialize()
				//	.btn_NewLoan_Click();

				//NewLoan
				//	.Initialize()
				//	.SelectItem_DirectConvRefinance();

				FormsTab
					.Initialize()
					.chk_Show_Check(true);

				#endregion Launch, Login, and create new loan

				#region Application Milestone

				#region Co-Borrower

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
				//	.cmb_Sex_SendKeys(MasterData.BorrowerSex)
				//	.cmb_Ethnicity_SendKeys(MasterData.BorrowerEthnicity)
				//	.chk_PrimaryBorrower_Race_Check(MasterData.BorrowerRace)
				//	.cmb_CoBorrowerSex_SendKeys(MasterData.CoBorrowerSex)
				//	.cmb_CoBorrowerEthnicity_SendKeys(MasterData.CoBorrowerEthnicity)
				//	.chk_CoBorrower_Race_Check(MasterData.CoBorrowerRace)
				//	.txt_ExperianFICO_SendKeys(MasterData.CreditScore)
				//	.txt_TransUnionEmpirica_SendKeys(MasterData.CreditScore)
				//	.txt_EquifaxBEACON_SendKeys(MasterData.CreditScore)
				//	.txt_CoBorrowerExperianFICO_SendKeys(MasterData.CreditScore)
				//	.txt_CoBorrowerTransUnionEmpirica_SendKeys(MasterData.CreditScore)
				//	.txt_CoBorrowerEquifaxBEACON_SendKeys(MasterData.CreditScore)

				#endregion Co-Borrower

				#region Borrower Summary, 1003, Transmittal Summary, and BLS

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
					.cmb_Sex_SendKeys(MasterData.BorrowerSex)
					.cmb_Ethnicity_SendKeys(MasterData.BorrowerEthnicity)
					.chk_PrimaryBorrower_Race_Check(MasterData.BorrowerRace)
					.txt_ExperianFICO_SendKeys(MasterData.CreditScore)
					.txt_TransUnionEmpirica_SendKeys(MasterData.CreditScore)
					.txt_EquifaxBEACON_SendKeys(MasterData.CreditScore)
					//
					.btn_CopyfromPresent_Click()
					.txt_EstimatedValue_SendKeys(MasterData.EstimatedValue)
					.txt_AppraisedValue_SendKeys(MasterData.AppraisedValue)
					.chk_PropertyWillBe_Check(MasterData.PropertyWillBe)
					.txt_LoanAmount_SendKeys(MasterData.LoanAmount);

				EncompassDialog
					.Initialize()
					.btn_RESPA_OK_Click();

				BorrowerSummary
					.Initialize()
					.txt_PurchasePrice_SendKeys(MasterData.PurchasePrice)
					.txt_SellingAgentName_SendKeys("test")
					.txt_SellingAgentCellPhone_SendKeys(MasterData.HomePhone)
					.txt_ListingAgentName_SendKeys("test")
					.txt_ListingAgentCellPhone_SendKeys(MasterData.HomePhone)
					.txt_EstEscrowCloseDate_SendKeys("111117");

				URLA_Page1
					.OpenForm_FromFormsTab()
					.txt_NoUnits_SendKeys("1")
					.txt_YearBuilt_SendKeys("2006")
					.cmb_SourceofDownPayment_SendKeys("Checking/Savings")
					.txt_School_SendKeys("20")
					.txt_Dependents_SendKeys("0")
					.chk_MailingAddress_Check("Same as present");
					//
					//.txt_CoBorrowerSchool_SendKeys("20")
					//.txt_CoBorrowerDependents_SendKeys("0")
					//.chk_CoBorrowerMailingAddress_Check("Same as present");

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
					.txt_EmployerZip_SendKeys(MasterData.Zip)
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
					.txt_DepositoryZip_SendKeys(MasterData.Zip)
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
					.txt_Declaration_m2_SendKeys("S");
					//
					//.txt_CoBorrowerDeclaration_a_SendKeys("N")
					//.txt_CoBorrowerDeclaration_b_SendKeys("N")
					//.txt_CoBorrowerDeclaration_c_SendKeys("N")
					//.txt_CoBorrowerDeclaration_d_SendKeys("N")
					//.txt_CoBorrowerDeclaration_e_SendKeys("N")
					//.txt_CoBorrowerDeclaration_f_SendKeys("N")
					//.txt_CoBorrowerDeclaration_g_SendKeys("N")
					//.txt_CoBorrowerDeclaration_h_SendKeys("N")
					//.txt_CoBorrowerDeclaration_i_SendKeys("N")
					//.txt_CoBorrowerDeclaration_j_SendKeys("Y")
					//.txt_CoBorrowerDeclaration_k_SendKeys("N")
					//.txt_CoBorrowerDeclaration_l_SendKeys("Y")
					//.txt_CoBorrowerDeclaration_m_SendKeys("Y")
					//.txt_CoBorrowerDeclaration_m1_SendKeys("PR")
					//.txt_CoBorrowerDeclaration_m2_SendKeys("S");

				TransmittalSummary
					.OpenForm_FromFormsTab()
					.cmb_PropertyType_SendKeys("1 unit");

				BankerLoanSubmission
					.OpenForm_FromFormsTab()
					.txt_LastMortgagePayment_SendKeys("081517")
					.txt_ClosingMonthPayment_SendKeys("test")
					.cmb_CreditOnNonBorrowingSpouse_SendKeys("CONFIRMED")
					.btn_BankerCertificationBLS_Click();

				#endregion Borrower Summary, 1003, Transmittal Summary, and BLS

				#region Product and Pricing

				OB_ProductandPricing
					.OpenFrom_MainMenu()
					.lstbx_Provider_Select("Optimal Blue - Enhanced")
					.btn_Submit_Click();

				OB_Login
					.Initialize()
					.txt_LoginName_SendKeys("qa_testlo_direct")
					.txt_Password_SendKeys("12345")
					.chk_SaveLoginInformation_Check(true)
					.chk_UpdateUpfrontMIdataforFHAloans_Check(true)
					.btn_Continue_Click();

				OB_ProductSearch
					.Initialize()
					.btn_Submit_Click();

				OB_SearchResults
					.Initialize()
					.SelectRateClosestToZero();

				OB_LockForm
					.Initialize()
					.btn_UpdateEncompass_Click();

				OB_PricingImportEncompassUpdate
					.Initialize()
					.btn_Close_Click();

				#endregion Run Product and Pricing

				#region eConsent

				//eConsentNotYetReceived
				//	.Open_FromAlertsandMessagesTab()
				//	.btn_RequesteConsent_Click();

				//SendConsent
				//	.Initialize()
				//	.chk_BorrowerConsent_Check()
				//	.chk_NotifyWhenBorrowerReceives_Check();

				//AttachToProcess(Processes.Firefox, 5);
				//LaunchApplication(DesktopApps.Firefox);

				//FirefoxMain
				//	.Initialize()
				//	.btn_BorrowerLoanCenter_Click();

				//BorrowerLoanCenterLogIn
				//	.Initialize()
				//	.btn_Login_Click();

				#endregion eConsent

				#region Disclosure Prep (TRID)

				//DisclosurePrep
				//	.OpenForm_FromFormsTab()
				//	.cmb_WilltherebeSubordination_SendKeys("No")
				//	.cmb_BetterRateWarranty_SendKeys("No")
				//	.cmb_ImpoundsWaivedorNotWaived_SendKeys("Not Waived")
				//	.cmb_Impoundswillbefor_SendKeys("Taxes and Insurance (T & I)")
				//	.cmb_AddingRemovingSomeoneFromTitle_SendKeys("No")
				//	.btn_GenerateEstimatedClosingDatesandStandardFees_Click();

				//SmartGFELogin
				//	.Initialize()
				//	.btn_Cancel_Click();

				//WVM_TitleAndClosing
				//	.OpenFrom_MainMenu()
				//	.lstbx_Provider_Select("WESTVM Title")
				//	.btn_Next_Click();

				//WVM_LogOn
				//	.Initialize()
				//	.txt_Username_SendKeys("PEMAdmin")
				//	.txt_Password_SendKeys("Pemadmin1")
				//	.btn_LogOn_Click();

				//WVM_PropertyAndOrderInformation
				//	.Initialize();

				//EncompassMain
				//	.Initialize()
				//	.tab_Loan_Select();

				//QuickEntry2015Itemization
				//	.OpenFromDisclosurePrep();


				#endregion Disclosure Prep (TRID)

				#endregion Application Milestone

				#region Conditions Sent Milestone

				//ConditionsSent
				//	.Open_FromLogTab()
				//	.txt_HazardInsCoName_SendKeys("test")
				//	.txt_HazardInsCoAddress_SendKeys("test")
				//	.txt_HazardInsCoCity_SendKeys("Burbank")
				//	.txt_HazardInsCoState_SendKeys("CA")
				//	.txt_HazardInsCoZip_SendKeys("91502")
				//	.txt_HazardInsCoPhone_SendKeys("5645645644")
				//	.txt_HazardInsCoRef_SendKeys("123123123123")
				//	.txt_TaxPayHazardInsurance_SendKeys("100000")
				//	.txt_HazardInsLastPaidDate_SendKeys("081117")
				//	.txt_SettlementAgentName_SendKeys("test")
				//	.txt_SettlementAgentAddress_SendKeys("test")
				//	.txt_SettlementAgentCity_SendKeys("Burbank")
				//	.txt_SettlementAgentState_SendKeys("CA")
				//	.txt_SettlementAgentZip_SendKeys("91502")
				//	.txt_SettlementAgentContact_SendKeys("test")
				//	.txt_SettlementAgentEmail_SendKeys("test@test.com")
				//	.txt_SettlementAgentPhone_SendKeys("5645645644");

				//ClosingForm
				//	.OpenForm_FromFormsTab()
				//	.btn_ProcessorAddData_Click()
				//	.txt_CurrentVesting_SendKeys("n")
				//	.cmb_ChangeVesting_SendKeys("n")
				//	.txt_VestingForDocs_SendKeys("n")
				//	.txt_GrantDeedRequested_SendKeys("n")
				//	.txt_NonObligorSigning_SendKeys("n")
				//	.btn_ProcessorClicktoCertify_Click();

				//EncompassDialog
				//	.Initialize()
				//	.btn_OKtoCertify_Click();

				//ClosingForm
				//	.Initialize()
				//	.cmb_IsFileReadyForUnderwriting_SendKeys("n");

				//MortgagePayoff
				//	.OpenForm_FromFormsTab();

				//ConditionsSent
				//	.Open_FromLogTab()
				//	.chk_Finish_Check();

				#endregion Conditions Sent Milestone

				#region Save and Close

				//EncompassMain
				//	.Initialize()
				//	.btn_Close_Click();

				//EncompassDialog
				//	.Initialize()
				//	.btn_SaveYes_Click();

				//ComplianceAlert
				//	.Initialize()
				//	.btn_Close_Click();

				#endregion Save and Close

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