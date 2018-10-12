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
using BaseAutomationFramework.PageObjects.Yahoo;
using BaseAutomationFramework.PageObjects;
using BaseAutomationFramework.PageObjects.EncompassLoanCenter;

namespace BaseAutomationFramework.Tests.OtherTests

{
	[TestFixture]
	public class TEST_WithoutTestConsole : BaseTest
	{
		private StreamWriter SW;
		private StatusReport SR;
		string runTime;
		string className;
		string pathStem;

		[GetTestSet("Test")]
		[TestCaseSource(typeof(GetTestData), "Screen")]
		public void Regression(IDictionary<string, string> data)
		{
			MasterData = new objMasterData(data);
			MasterData.TestResultPathStem = pathStem;
			className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
			Step step = new Step();

			step.Action = string.Format("Test: {0}", MasterData.TestID);
			step.ExpectedResult = string.Format("");
			step.ActualResult = string.Format("");
			step.Status = "Pass";
			step.Time = DateTime.Now.ToString();

            try
            {
                AttachToProcess(Processes.Encompass, 5);

                #region Launch and Login

                //LaunchApplication(DesktopApps.Encompass); Launcher.Initialize().cmb_EnvironmentID_SelectByText(MasterData.EnvironmentID).btn_Login_Click(); AttachToProcess(Processes.Encompass, 5);

                //Login.Initialize().txt_Username_SendKeys(MasterData.LoanOfficer).txt_Password_SendKeys("P@ramount1").btn_Login_Click();

                //Thread.Sleep(10000); EncompassMain.Initialize().Resize().tab_Pipeline_Select();

                //Pipeline.Initialize().btn_NewLoan_Click(); NewLoan.Initialize().cmb_LoanTemplateFolder_SelectByText("PEM Direct").SelectItem_DirectConvRefinance();

                //FormsTab.Initialize().chk_Show_Check(true).chk_ShowInAlpha_Check(true);

                #endregion Launch and Login

                #region Loan Creation w/o Test Console

                //BorrowerSummary
                //	.OpenForm_FromFormsTab()
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
                //	.cmb_InformationProvidedBy_SendKeys(MasterData.InformationProvidedBy)
                //	.chk_BorrowerVerbalAuthForCreditPull_Check(true)
                //	.btn_CopyfromPresent_Click()
                //	.txt_EstimatedValue_SendKeys(MasterData.EstimatedValue)
                //	.txt_AppraisedValue_SendKeys(MasterData.AppraisedValue)
                //	.chk_LoanPurpose_Check("No Cash-Out Refi")
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
                //	.chk_MailingAddress_Check("Same as present");

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
                //	.chk_PrimaryBorrower_Sex_Check(MasterData.BorrowerSex);

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
                //	.txt_ClosingMonthPayment_SendKeys("test")
                //	.txt_LastMortgagePayment_SendKeys("081517")
                //	.cmb_CreditOnNonBorrowingSpouse_SendKeys("CONFIRMED")
                //	.btn_BankerCertificationBLS_Click();

                //#region eFolder Bypass

                //EncompassMain.Initialize().ExitEncompass();EncompassDialog.Initialize().btn_Yes_Click();ComplianceAlert.Initialize().btn_Close_Click();

                //LaunchApplication(DesktopApps.Encompass);Launcher.Initialize().cmb_EnvironmentID_SelectByText(MasterData.EnvironmentID).btn_Login_Click();

                //Login.Initialize().txt_Username_SendKeys("test_qa_admin").txt_Password_SendKeys("P@ramount1").btn_Login_Click();EncompassMain.Initialize();Thread.Sleep(10000);EncompassMain.Initialize().Resize().tab_Pipeline_Select();

                //Pipeline.Initialize().cmb_PipelineView_SelectByText("QA View").cmb_LoanFolder_SelectByText(MasterData.LoanFolder).Pipeline_SelectCurrentLoan(MasterData.LoanNumber);

                //Encompass_eFolder.Open_eFolder().btn_New_Click();AddDocument.Initialize().rdb_NewDocument_Select().btn_OK_Click();DocumentDetails.Initialize().btn_BrowseAndAttach_Click();Thread.Sleep(10000);

                //DocumentDetails.Initialize().cmb_DocumentName_SelectByText("Underwriting").chk_Requested_Check(true).btn_Close_Click();Encompass_eFolder.Initialize().btn_Close_Click();

                //EncompassMain.Initialize().ExitEncompass();EncompassDialog.Initialize().btn_Yes_Click();ComplianceAlert.Initialize().btn_Close_Click();

                //LaunchApplication(DesktopApps.Encompass);

                //Launcher
                //	.Initialize()
                //	.cmb_EnvironmentID_SelectByText(MasterData.EnvironmentID)
                //	.btn_Login_Click();

                //Login
                //	.Initialize()
                //	.txt_Username_SendKeys("test_qa_lo")
                //	.txt_Password_SendKeys("P@ramount1")
                //	.btn_Login_Click();

                //EncompassMain
                //	.Initialize();
                //	Thread.Sleep(10000);

                //EncompassMain
                //	.Initialize()
                //	.Resize()
                //	.tab_Pipeline_Select();

                //Pipeline
                //	.Initialize()
                //	.cmb_PipelineView_SelectByText("QA View")
                //	.cmb_LoanFolder_SelectByText(MasterData.LoanFolder)
                //	.Pipeline_SelectCurrentLoan(MasterData.LoanNumber);

                //#endregion eFolder Bypass

                #endregion Loan Creation w/o Test Console

                #region eConsent

                //eConsentNotYetReceived.Open_FromAlertsandMessagesTab().btn_Request_eConsent_Click();

                //SendConsent.Initialize().chk_BorrowerConsent_Check(true).chk_NotifyWhenBorrowerReceives_Check(true).btn_Send_Click();

                //BaseSeleniumPage.CreateDriver(BaseSeleniumPage.WebDrivers.Chrome); BaseSeleniumPage.NavigateToURL(@"https://www.mortgage-application.net/myaccount/accountlogin.aspx");

                //BorrowerLoanCenterLogIn.Initialize().txt_Email_SendKeys(MasterData.BorrowerEmail).txt_Password_SendKeys("P@ramount1").btn_Login_Click();

                //CheckLoanStatus.Initialize().fn_SelectFirstRow(); LoanDetail.Initialize().btn_View_Click();

                //AgreeToReceiveDisclosuresElectronically.Initialize().btn_Agree_Click(); BaseSeleniumPage.CloseDriver();

                //eConsentNotYetReceived.Initialize().btn_View_eConsent_Click();

                #endregion eConsent

                #region Floating Product and Pricing

                //OB_ProductandPricing.OpenFrom_MainMenu().lstbx_Provider_Select("Optimal Blue - Enhanced").btn_Submit_Click();

                //OB_Login.Initialize().txt_LoginName_SendKeys(MasterData.OB_Login).txt_Password_SendKeys(MasterData.OB_Password).chk_SaveLoginInformation_Check(true).btn_Continue_Click();

                //OB_ProductSearch.Initialize().btn_Submit_Click(); Thread.Sleep(10000); OB_LockForm.Initialize().btn_UpdateEncompass_Click(); Thread.Sleep(10000); OB_PricingImportEncompassUpdate.Initialize().btn_Close_Click();

                #endregion 

                #region Floating Product and Pricing

                //OB_ProductandPricing.OpenFrom_MainMenu().lstbx_Provider_Select("Optimal Blue - Enhanced").btn_Submit_Click();

                //OB_Login.Initialize().txt_LoginName_SendKeys(MasterData.OB_Login).txt_Password_SendKeys(MasterData.OB_Password).chk_SaveLoginInformation_Check(true).btn_Continue_Click();

                //OB_ProductSearch.Initialize().btn_Submit_Click();OB_SearchResults.Initialize().SelectLoanProgram_Click("LP CONF 30YR FIXED");Thread.Sleep(10000); OB_LockForm.Initialize().btn_RequestLock_Click(); Thread.Sleep(10000); OB_PricingImportEncompassUpdate.Initialize().btn_Close_Click();

                //OB_LockRequestDialog.Initialize().btn_ExitLoan_Click();

                #endregion 

                BorrowerSummary.OpenForm_FromFormsTab().CopyLoanNumber();

            }

            catch (Exception ex)
            {
                //step.ModalText = ex.ToString();
                //step.Status = "Fail";
                //step.ScreenShotLocation = Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format("Failure\\{0}", System.Reflection.MethodBase.GetCurrentMethod().Name));
                //Assert.Fail(ex.ToString());
            }
            finally
            {
                //Report.addStep(step);
            }

		}

		[TestFixtureSetUp]
		public void OnFixtureSetup()
		{
			//runTime = CreateRuntimeString();
			//Report = StatusReport.getStatusReport();
			//string sub1 = string.Format("Tester: {0}", Environment.UserName);
			//string sub2 = string.Format("Release Version: {0}", "Not Assigned");
			//List<string> subheaders = new List<string>() { sub1, sub2 };
			//this.pathStem = string.Format("{0}\\{1}\\{2} - {3}", FileUtilities.DefaultTestResultDirectory, className, Environment.UserName, runTime);
			//string path = string.Format("{0}\\{1}.html", pathStem, "Results");
			//Report.reportSetup("Demo Script", path, null, subheaders);
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
			//string subject = string.Format("All your tests are finished, good job!");
			//string body = string.Format("All your tests are finished, good job!");
			//EmailUtilities.Email email = new EmailUtilities.Email(subject, body, "hannah.charls@aol.com");

			//EmailUtilities.SendEmail(email);
			//Report.writeReport();
		}
	}
}