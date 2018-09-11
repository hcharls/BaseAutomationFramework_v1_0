using System;
using System.Collections.Generic;
using BaseAutomationFramework.PageObjects.Encompass;
using NUnit.Framework;
using BaseAutomationFramework.Tools;
using BaseAutomationFramework.DataObjects;
using System.IO;
using BaseAutomationFramework.HTML_Report;
using BaseAutomationFramework.PageObjects;
using BaseAutomationFramework.PageObjects.EncompassLoanCenter;
using System.Threading;

namespace BaseAutomationFramework.Tests.Encompass.Regression
{
	[TestFixture]
	public class FloatingEndToEndConvRefi : BaseTest
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

                #region Application Milestone

                #region Launch and Login

                LaunchApplication(DesktopApps.Encompass); Launcher.Initialize().cmb_EnvironmentID_SelectByText(MasterData.EnvironmentID).btn_Login_Click(); AttachToProcess(Processes.Encompass, 5);

                Login.Initialize().txt_Username_SendKeys("test_qa_lo").txt_Password_SendKeys("P@ramount1").btn_Login_Click();

                Thread.Sleep(10000); EncompassMain.Initialize().Resize().tab_Pipeline_Select();

                Pipeline.Initialize().btn_NewLoan_Click(); NewLoan.Initialize().cmb_LoanTemplateFolder_SelectByText("PEM Direct").SelectItem_DirectConvRefinance();

                FormsTab.Initialize().chk_Show_Check(true).chk_ShowInAlpha_Check(true);

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

                #region Loan Creation w/ Test Console

                TestConsole.OpenForm_FromFormsTab().btn_CreateNewLoan_Click(MasterData.TestDescription); EncompassDialog.Initialize().btn_OK_Click();

                CreditReport.Initialize().lstbx_Provider_Select("Equifax Mortgage Solutions").btn_Submit_Click();//.btn_Cancel_Click();

                CreditReportRequest.Initialize().txt_UserName_SendKeys("PARAMOUNTIT").txt_Password_SendKeys("P@ramount2").chk_SaveLoginInformation_Check(true).chk_Equifax_Check(true).chk_Experian_Check(true).chk_TransUnion_Check(true).btn_Finish_Click(); EncompassMain.Initialize().tab_Loan_Select();

                TestConsole
                    .Initialize()
                    .rdb_NoCashOutRefi_Select()
                    .rdb_Direct_Select()
                    .rdb_FixedRate_Select()
                    .txt_SubjectProperty_Address_SendKeys(MasterData.Address)
                    .txt_SubjectProperty_ZipCode_SendKeys(MasterData.Zip);
                //.txt_SubjectProperty_City_SendKeys(MasterData.City)
                //.txt_SubjectProperty_State_SendKeys(MasterData.State)
                //.txt_SubjectProperty_County_SendKeys(MasterData.County)

                #endregion Loan Creation w/ Test Console

                #region eConsent

                eConsentNotYetReceived.Open_FromAlertsandMessagesTab().btn_Request_eConsent_Click();

                SendConsent.Initialize().chk_BorrowerConsent_Check(true).chk_NotifyWhenBorrowerReceives_Check(true).btn_Send_Click();

                BaseSeleniumPage.CreateDriver(BaseSeleniumPage.WebDrivers.Chrome); BaseSeleniumPage.NavigateToURL(@"https://www.mortgage-application.net/myaccount/accountlogin.aspx");

                BorrowerLoanCenterLogIn.Initialize().txt_Email_SendKeys(MasterData.BorrowerEmail).txt_Password_SendKeys("P@ramount1").btn_Login_Click();

                CheckLoanStatus.Initialize().fn_SelectFirstRow(); LoanDetail.Initialize().btn_View_Click();

                AgreeToReceiveDisclosuresElectronically.Initialize().btn_Agree_Click(); BaseSeleniumPage.CloseDriver();

                eConsentNotYetReceived.Initialize().btn_View_eConsent_Click();

                #endregion eConsent

                #region Product and Pricing

                OB_ProductandPricing.OpenFrom_MainMenu().lstbx_Provider_Select("Optimal Blue - Enhanced").btn_Submit_Click();

                OB_Login.Initialize().txt_LoginName_SendKeys(MasterData.OB_Login).txt_Password_SendKeys(MasterData.OB_Password).chk_SaveLoginInformation_Check(true).btn_Continue_Click();

                OB_ProductSearch.Initialize().btn_Submit_Click(); Thread.Sleep(10000); OB_LockForm.Initialize().btn_UpdateEncompass_Click(); Thread.Sleep(10000); OB_PricingImportEncompassUpdate.Initialize().btn_Close_Click();

                #endregion Product and Pricing

                #region Locked Product and Pricing

                //OB_ProductandPricing.OpenFrom_MainMenu().lstbx_Provider_Select("Optimal Blue - Enhanced").btn_Submit_Click();

                //OB_Login.Initialize().txt_LoginName_SendKeys(MasterData.OB_Login).txt_Password_SendKeys(MasterData.OB_Password).chk_SaveLoginInformation_Check(true).btn_Continue_Click();

                //OB_ProductSearch.Initialize().btn_Submit_Click(); OB_SearchResults.Initialize().SelectRateClosestToZero();

                //OB_LockForm.Initialize().btn_RequestLock_Click(); OB_PricingImportEncompassUpdate.Initialize().btn_Close_Click();

                #endregion Locked Product and Pricing

                #region Disclosure Prep (TRID) 

                DisclosurePrep
                .OpenForm_FromFormsTab()
                .cmb_WillThereBeSubordination_SendKeys("No")
                .cmb_BetterRateWarranty_SendKeys("No")
                .cmb_ImpoundsWaivedOrNotWaived_SendKeys("Not Waived")
                .cmb_ImpoundsWillBeFor_SendKeys("Taxes and Insurance (T & I)")
                .cmb_AddingRemovingSomeoneFromTitle_SendKeys("No")
                .btn_GenerateEstimatedClosingDatesandStandardFees_Click()
                .btn_WestVM_Click();

                EncompassMain.Initialize().tab_Loan_Select();

                DisclosurePrep.Initialize().btn_Review2015Itemization_Click(); Itemization.OpenForm_FromFormsTab(); PropertyTaxesReserved.OpenFromItemization().cmb_ReserveBasedOn_SendKeys("B").txt_RatePercentage_SendKeys(".25").btn_OK_Click(); AggregateSetup.OpenFromItemization().btn_OK_Click();

                DisclosurePrep.OpenForm_FromFormsTab().btn_RunComplianceReport_Click(); DisclosurePrep.OpenForm_FromFormsTab().btn_NotNowContinue_Click().cmb_DocumentDeliveryPreference_SendKeys("Email - eSign").btn_ReadytoDisclose_Click().btn_GenerateDisclosures_Click();

                #endregion Disclosure Prep (TRID)

                #region Initial Disclosures 

                Order_eDisclosures.Initialize().InitialDisclosures_SelectTopPlanCode().btn_Order_eDisclosures_Click();

                SelectDocuments.Initialize().btn_Send_Click();

                SendDisclosures.Initialize().cmb_BorrowerAuthenticationMethod_SendKeys("a").txt_BorrowerAuthorization_SendKeys(MasterData.AuthorizationCode).btn_Send_Click();

                DisclosuresDialog.Initialize().btn_No_Click(); EncompassDialog.Initialize().btn_OK_Click();

                BaseSeleniumPage.CreateDriver(BaseSeleniumPage.WebDrivers.Chrome); BaseSeleniumPage.NavigateToURL(@"https://encompass.mortgage-application.net/EncompassAccount/AccountLogin.aspx");

                LoanOfficerLoanCenterLogIn.Initialize().txt_ClientID_SendKeys("3011141905").txt_UserID_SendKeys("test_qa_lo").txt_Password_SendKeys("P@ramount1").btn_Login_Click();

                CheckLoanStatus.Initialize().fn_SelectFirstRow(); LoanDetail.Initialize().btn_View_Click(); DocuSign.Initialize().fn_ESignWholeDocument();

                BaseSeleniumPage.NavigateToURL(@"https://www.mortgage-application.net/myaccount/accountlogin.aspx");

                BorrowerLoanCenterLogIn.Initialize().txt_Email_SendKeys(MasterData.BorrowerEmail).txt_Password_SendKeys("P@ramount1").btn_Login_Click();

                CheckLoanStatus.Initialize().fn_SelectFirstRow(); LoanDetail.Initialize().btn_View_Click();

                VerifyIdentity.Initialize().txt_AuthorizationCode_SendKeys(MasterData.AuthorizationCode).btn_Next_Click();

                DocuSign.Initialize().fn_ESignWholeDocument(); BaseSeleniumPage.CloseDriver();

                Retrieve.OpenFrom_eFolder().btn_Download_Click(); FileManager.Initialize().btn_Close_Click(); Encompass_eFolder.Initialize().btn_Close_Click();

                #endregion Initial Disclosures

                DisclosureDetails.OpenFrom_DisclosureTracking().chk_IntentToProceed_Check(true).btn_SendDateManualEntry_Click().txt_DisclosureSentDate_SetBack().btn_OK_Click();

                AUS_DetailsQuickEntry.OpenFrom_AUSTracking().cmb_UnderwritingRiskAssessType_SendKeys("DU").btn_OK_Click();

                BankerLoanSubmission.OpenForm_FromFormsTab().btn_CopyCashBackSTC_Click(); EncompassDialog.Initialize().btn_OKtoCertify_Click(); BankerLoanSubmission.Initialize().btn_BankerCertificationBLS_Click();

                Application.Open_FromLogTab().cmb_LoanInfoRefiPurpose_SendKeys("Cash-Out Other").chk_Finish_Check();

                EncompassMain.Initialize().ExitEncompass(); EncompassDialog.Initialize().btn_Yes_Click(); ComplianceAlert.Initialize().btn_Close_Click();

                #endregion Application Milestone

                #region Pre Proc. Review Milestone

                //LaunchApplication(DesktopApps.Encompass);

                //Launcher
                //	.Initialize()
                //	.cmb_EnvironmentID_SelectByText(MasterData.EnvironmentID)
                //	.btn_Login_Click();

                //AttachToProcess(Processes.Encompass, 5);

                //Login
                //	.Initialize()
                //	.txt_Username_SendKeys("test_qa_som")
                //	.txt_Password_SendKeys("P@ramount1")
                //	.btn_Login_Click();

                //Thread.Sleep(10000);

                //EncompassMain
                //	.Initialize()
                //	.Resize()
                //	.tab_Pipeline_Select();

                //Pipeline
                //	.Initialize()
                //	.cmb_PipelineView_SelectByText("QA View")
                //	.cmb_LoanFolder_SelectByText(MasterData.LoanFolder)
                //	.Pipeline_SelectCurrentLoan(MasterData.LoanNumber);

                //PreProcReview
                //	.Open_FromLogTab()
                //	.cmb_Disclosures_eSigned_SendKeys("Yes")
                //	.btn_LoanProcessor_Click();

                //SelectLoanTeamMember
                //	.Initialize()
                //	.PreProcReview_SelectLoanProcessor();

                //PreProcReview
                //	.Initialize()
                //	.chk_Finish_Check();

                #endregion Pre Proc. Review Milestone

                #region Proc. Pre Approval and Submit to UW Milestones

                //ProcPreApproval
                //	.Open_FromLogTab()
                //	.btn_LoanProcessor_Click();

                //SelectLoanTeamMember
                //	.Initialize()
                //	.ProcPreApproval_SelectLoanProcessor();

                //PreProcReview
                //	.Initialize()
                //	.chk_Finish_Check();

                //SubmitToUW
                //	.Open_FromLogTab()
                //	.btn_Underwriter_Click();

                //SelectLoanTeamMember
                //	.Initialize()
                //	.SubmitToUW_SelectUnderwriter();

                //PreProcReview
                //	.Initialize()
                //	.chk_Finish_Check();

                //EncompassMain
                //	.Initialize()
                //	.ExitEncompass();

                //ExitEncompass
                //	.Initialize()
                //	.btn_Yes_Click();

                //ComplianceAlert
                //	.Initialize()
                //	.btn_Close_Click();

                //ComplianceReview
                //	.Initialize()
                //	.btn_Close_Click();

                #endregion Submit to UW and Submit to UW Milestones

                #region Initial UW Decision Milestone

                //LaunchApplication(DesktopApps.Encompass);

                //Launcher
                //	.Initialize()
                //	.cmb_EnvironmentID_SelectByText(MasterData.EnvironmentID)
                //	.btn_Login_Click();

                //AttachToProcess(Processes.Encompass, 5);

                //Login
                //	.Initialize()
                //	.txt_Username_SendKeys("test_qa_uw")
                //	.txt_Password_SendKeys("P@ramount1")
                //	.btn_Login_Click();

                //EncompassMain
                //	.Initialize();
                //Thread.Sleep(10000);

                //EncompassMain
                //	.Initialize()
                //	.Resize()
                //	.tab_Pipeline_Select();

                //Pipeline
                //	.Initialize()
                //	.cmb_PipelineView_SelectByText("QA View")
                //	.cmb_LoanFolder_SelectByText(MasterData.LoanFolder)
                //	.Pipeline_SelectCurrentLoan(MasterData.LoanNumber);

                //UnderwriterSummary
                //	.OpenForm_FromToolsTab()
                //	.txt_ApprovedByDate_SendKeys()
                //	.txt_ApprovalExpiresDate_SendKeys("030518");

                //InitialUWDecision
                //	.Open_FromLogTab()
                //	.chk_Finish_Check();

                //EncompassMain
                //	.Initialize()
                //	.ExitEncompass();

                //ExitEncompass
                //	.Initialize()
                //	.btn_Yes_Click();

                #endregion Initial UW Decision Milestone

                #region Conditions Sent Milestone

                //LaunchApplication(DesktopApps.Encompass);

                //Launcher
                //	.Initialize()
                //	.cmb_EnvironmentID_SelectByText(MasterData.EnvironmentID)
                //	.btn_Login_Click();

                //AttachToProcess(Processes.Encompass, 5);

                //Login
                //	.Initialize()
                //	.txt_Username_SendKeys("test_qa_proc")
                //	.txt_Password_SendKeys("P@ramount3")
                //	.btn_Login_Click();

                //Thread.Sleep(10000);

                //EncompassMain
                //	.Initialize()
                //	.Resize()
                //	.tab_Pipeline_Select();

                //Pipeline
                //	.Initialize()
                //	.cmb_PipelineView_SelectByText("QA View")
                //	.cmb_LoanFolder_SelectByText(MasterData.LoanFolder)
                //	.Pipeline_SelectCurrentLoan(MasterData.LoanNumber);

                //ClosingForm
                //	.OpenForm_FromFormsTab()
                //	.btn_ProcessorAddData_Click()
                //	.txt_CurrentVesting_SendKeys("n")
                //	.cmb_ChangeVesting_SendKeys("n")
                //	.txt_VestingForDocs_SendKeys("n")
                //	.txt_GrantDeedRequested_SendKeys("n")
                //	.txt_NonObligorSigning_SendKeys("n")
                //	.cmb_IsFileReadyForUnderwriting_SendKeys("No, Conditions Review");
                //	.btn_ProcessorClicktoCertify_Click();

                //EncompassDialog
                //	.Initialize()
                //	.btn_OKtoCertify_Click();

                //ConditionsSent
                //	.Open_FromLogTab()
                //	.chk_Finish_Check();

                //EncompassMain
                //	.Initialize()
                //	.ExitEncompass();

                //ExitEncompass
                //	.Initialize()
                //	.btn_Yes_Click();

                #endregion Conditions Sent Milestone

                #region Final UW Approval Milestone

                //LaunchApplication(DesktopApps.Encompass);

                //Launcher
                //	.Initialize()
                //	.cmb_EnvironmentID_SelectByText(MasterData.EnvironmentID)
                //	.btn_Login_Click();

                //AttachToProcess(Processes.Encompass, 5);

                //Login
                //	.Initialize()
                //	.txt_Username_SendKeys("test_qa_uw")
                //	.txt_Password_SendKeys("P@ramount1")
                //	.btn_Login_Click();

                //Thread.Sleep(10000);

                //EncompassMain
                //	.Initialize()
                //	.Resize()
                //	.tab_Pipeline_Select();

                //Pipeline
                //	.Initialize()
                //	.cmb_PipelineView_SelectByText("QA View")
                //	.cmb_LoanFolder_SelectByText(MasterData.LoanFolder)
                //	.Pipeline_SelectCurrentLoan(MasterData.LoanNumber);

                //Encompass_eFolder
                //	.Open_eFolder()
                //	.eFolder_UnderwriterReview("1003");

                //DocumentDetails
                //	.Initialize()
                //	.Chk_Reviewed_Check(true)
                //	.btn_Close_Click();

                //Encompass_eFolder
                //	.Initialize()
                //	.eFolder_UnderwriterReview("Credit Report");

                //DocumentDetails
                //	.Initialize()
                //	.Chk_Reviewed_Check(true)
                //	.btn_Close_Click();

                //Encompass_eFolder
                //	.Initialize()
                //	.eFolder_UnderwriterReview("Underwriting");

                //DocumentDetails
                //	.Initialize()
                //	.Chk_Reviewed_Check(true)
                //	.btn_Close_Click();

                //Encompass_eFolder
                //	.Initialize()
                //	.btn_Close_Click();

                //FinalUWApproval
                //	.Open_FromLogTab()				
                //	.cmb_ULDDPropertyValuationMethodType_SendKeys("None")
                //	.txt_TotalMortgagedPropertiesCount_SendKeys("1")
                //	.txt_ULDDInvestorFeatureID_SendKeys("5645646446")
                //	.cmb_UnderwritingLevelOfPrptyReview_SendKeys("No Appraisal")
                //	.cmb_DayOneCertainty_SendKeys("NO")
                //	.txt_UnderwritingClearToCloseDate_SendKeys("030518")
                //	.chk_FinalUWApprovalTasks_Check()
                //	.btn_QualityControl_Click();

                //SelectLoanTeamMember
                //	.Initialize()
                //	.FinalUWApproval_SelectQualityControl();

                //FinalUWApproval
                //	.Initialize()
                //	.chk_Finish_Check();

                //EncompassMain
                //	.Initialize()
                //	.ExitEncompass();

                //ExitEncompass
                //	.Initialize()
                //	.btn_Yes_Click();

                //ComplianceReview
                //	.Initialize()
                //	.btn_Close_Click();

                #endregion Final UW Approval Milestone

                #region QC Review Milestone

                //LaunchApplication(DesktopApps.Encompass);

                //Launcher
                //	.Initialize()
                //	.cmb_EnvironmentID_SelectByText(MasterData.EnvironmentID)
                //	.btn_Login_Click();

                //AttachToProcess(Processes.Encompass, 5);

                //Login
                //	.Initialize()
                //	.txt_Username_SendKeys("test_qa_qc")
                //	.txt_Password_SendKeys("P@ramount1")
                //	.btn_Login_Click();

                //Thread.Sleep(10000);

                //EncompassMain
                //	.Initialize()
                //	.Resize()
                //	.tab_Pipeline_Select();

                //Pipeline
                //	.Initialize()
                //	.cmb_PipelineView_SelectByText("QA View")
                //	.cmb_LoanFolder_SelectByText(MasterData.LoanFolder)
                //	.Pipeline_SelectCurrentLoan(MasterData.LoanNumber);

                //FormsTab
                //	.Initialize()
                //	.chk_Show_Check(true)
                //	.chk_ShowInAlpha_Check(true);

                //PreFundingQCCustomForm
                //	.OpenForm_FromFormsTab()
                //	.chk_LoanSelected_Check(true)
                //	.chk_LoanReviewed_Check(true)
                //	.chk_LoanCleared_Check(true);

                //QCReview
                //	.Open_FromLogTab()
                //	.chk_QCReviewTasks_Check()
                //	.btn_DocDrawer_Click();

                //SelectLoanTeamMember
                //	.Initialize()
                //	.QCReview_SelectDocDrawer();

                //QCReview
                //	.Initialize()
                //	.chk_Finish_Check();

                //EncompassMain
                //	.Initialize()
                //	.ExitEncompass();

                //ExitEncompass
                //	.Initialize()
                //	.btn_Yes_Click();

                #endregion QC Review Milestone

                #region Docs Out Milestone

                //LaunchApplication(DesktopApps.Encompass);

                //Launcher
                //	.Initialize()
                //	.cmb_EnvironmentID_SelectByText(MasterData.EnvironmentID)
                //	.btn_Login_Click();

                //AttachToProcess(Processes.Encompass, 5);

                //Login
                //	.Initialize()
                //	.txt_Username_SendKeys("test_qa_admin")
                //	.txt_Password_SendKeys("P@ramount1")
                //	.btn_Login_Click();

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

                //ClosingForm
                //	.OpenForm_FromFormsTab()
                //	.btn_ProcessorClicktoCertify_Click();




                //EncompassMain
                //	.Initialize()
                //	.ExitEncompass();

                //EncompassDialog
                //	.Initialize()
                //	.btn_Yes_Click();

                //ComplianceAlert
                //	.Initialize()
                //	.btn_Close_Click();

                //LaunchApplication(DesktopApps.Encompass);

                //Launcher
                //	.Initialize()
                //	.cmb_EnvironmentID_SelectByText(MasterData.EnvironmentID)
                //	.btn_Login_Click();

                //AttachToProcess(Processes.Encompass, 5);

                //Login
                //	.Initialize()
                //	.txt_Username_SendKeys("test_qa_fundd")
                //	.txt_Password_SendKeys("P@ramount1")
                //	.btn_Login_Click();

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

                //BorrowerInformationVesting
                //	.OpenForm_FromFormsTab()
                //	.btn_BuildFinal_Click();

                //ClosingVendorInformation
                //	.OpenForm_FromFormsTab()
                //	.txt_EscrowCompanyName_SendKeys("test");

                //ClosingTracking
                //	.OpenForm_FromFormsTab()
                //	.txt_EarliestClosingDate_SendKeys("c");

                //RegZCD
                //	.OpenForm_FromFormsTab()
                //	.txt_DocumentDate_SendKeys("v")
                //	.txt_ClosingDate_SendKeys("v")
                //	.txt_DocSigningDate_SendKeys("v")
                //	.btn_Audit_Click();

                //SelectPlanCode
                //	.Initialize()
                //	.ClosingDocs_SelectPlanCode();

                //SelectReportType
                //	.Initialize()
                //	.rdb_Preview_Select()
                //	.btn_OK_Click();

                //ClosingDocsAudit
                //	.Initialize()
                //	.cmb_OrderType_SelectByText("Pre-Closing")
                //	.btn_OrderDocs_Click();

                //SelectDocuments
                //	.Initialize()
                //	.btn_Send_Click();

                //SendDisclosures
                //	.Initialize()
                //	.cmb_BorrowerAuthenticationMethod_SendKeys("Authorization Code")
                //	.txt_BorrowerAuthorization_SendKeys("13188")
                //	.btn_Send_Click();

                //EncompassDialog
                //	.Initialize()
                //	.btn_OK_Click();







                //DocsOut
                //	.Open_FromLogTab()
                //	.txt_PropertyInfoParcelNumber_SendKeys("564564564")
                //	.chk_DocsOutTasks_Check()
                //	.btn_Funder_Click();

                //SelectLoanTeamMember
                //	.Initialize()
                //	.DocsOut_SelectLoanFunder();

                //DocsOut
                //	.Initialize()
                //	.chk_Finish_Check();

                #endregion Docs Out Milestone

                #region Docs Back Milestone

                //Encompass_eFolder
                //	.Open_eFolder()
                //	.btn_Retrieve_Click();

                //Retrieve
                //	.Initialize()
                //	.btn_Download_Click();

                //FileManager
                //	.Initialize()
                //	.btn_Close_Click();

                //Encompass_eFolder
                //	.Initialize()
                //	.btn_Close_Click();

                //DocsBack
                //	.Open_FromLogTab()
                //	.btn_Funder_Click();

                //SelectLoanTeamMember
                //	.Initialize()
                //	.DocsBack_SelectLoanFunder();

                //DocsBack
                //	.Initialize()
                //	.chk_Finish_Check();

                #endregion Docs Back Milestone

                #region Funding Review Milestone

                //FundingReview
                //	.Open_FromLogTab()
                //	.btn_Funder_Click();

                //SelectLoanTeamMember
                //	.Initialize()
                //	.FundingReview_SelectLoanFunder();

                //FundingReview
                //	.Initialize()
                //	.chk_Finish_Check();

                #endregion Funding Review Milestone

                #region Funding Milestone

                //RegZCD
                //	.OpenForm_FromFormsTab()
                //	.txt_DisbursementDate_SendKeys("c");

                //FundingWorksheet
                //	.OpenForm_FromToolsTab()
                //	.txt_FundsOrdered_SendKeys("v")
                //	.txt_FundsSent_SendKeys("v");

                //Funding
                //	.Open_FromLogTab()
                //	.btn_Shipper_Click();

                //SelectLoanTeamMember
                //	.Initialize()
                //	.Funding_SelectLoanShipper();

                //Funding
                //	.Initialize()
                //	.chk_Finish_Check();

                //EncompassMain
                //	.Initialize()
                //	.ExitEncompass();

                //EncompassDialog
                //	.Initialize()
                //	.btn_Yes_Click();

                //ComplianceAlert
                //	.Initialize()
                //	.btn_Close_Click();

                #endregion Funding Milestone

                #region Shipping Milestone

                //LaunchApplication(DesktopApps.Encompass);

                //Launcher
                //	.Initialize()
                //	.cmb_EnvironmentID_SelectByText(MasterData.EnvironmentID)
                //	.btn_Login_Click();

                //AttachToProcess(Processes.Encompass, 5);

                //Login
                //	.Initialize()
                //	.txt_Username_SendKeys("test_qa_shipper")
                //	.txt_Password_SendKeys("P@ramount1")
                //	.btn_Login_Click();

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

                //Shipping
                //	.Open_FromLogTab()
                //	.txt_ShippingActualShippingDate_SendKeys("05052018")
                //	.btn_Secondary_Click();

                //SelectLoanTeamMember
                //	.Initialize()
                //	.Shipping_SelectLoanSecondary();

                //Shipping
                //	.Initialize()
                //	.chk_Finish_Check();

                //EncompassMain
                //	.Initialize()
                //	.ExitEncompass();

                //EncompassDialog
                //	.Initialize()
                //	.btn_Yes_Click();

                //ComplianceAlert
                //	.Initialize()
                //	.btn_Close_Click();

                #endregion Shipping Milestone

                #region Purchase Milestone

                //LaunchApplication(DesktopApps.Encompass);

                //Launcher
                //	.Initialize()
                //	.cmb_EnvironmentID_SelectByText(MasterData.EnvironmentID)
                //	.btn_Login_Click();

                //AttachToProcess(Processes.Encompass, 5);

                //Login
                //	.Initialize()
                //	.txt_Username_SendKeys("test_qa_sec")
                //	.txt_Password_SendKeys("P@ramount1")
                //	.btn_Login_Click();

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

                //Purchase
                //	.Open_FromLogTab()
                //	.btn_PostCloser_Click();

                //SelectLoanTeamMember
                //	.Initialize()
                //	.Purchase_SelectLoanPostCloser();

                //Purchase
                //	.Initialize()
                //	.chk_Finish_Check();

                //EncompassMain
                //	.Initialize()
                //	.ExitEncompass();

                //EncompassDialog
                //	.Initialize()
                //	.btn_Yes_Click();

                //ComplianceAlert
                //	.Initialize()
                //	.btn_Close_Click();

                #endregion Purchase Milestone

                #region Completion Milestone

                //LaunchApplication(DesktopApps.Encompass);

                //Launcher
                //	.Initialize()
                //	.cmb_EnvironmentID_SelectByText(MasterData.EnvironmentID)
                //	.btn_Login_Click();

                //AttachToProcess(Processes.Encompass, 5);

                //Login
                //	.Initialize()
                //	.txt_Username_SendKeys("test_qa_pc")
                //	.txt_Password_SendKeys("P@ramount1")
                //	.btn_Login_Click();

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

                //Completion
                //	.Open_FromLogTab()
                //	.chk_Finish_Check();

                //EncompassMain
                //	.Initialize()
                //	.ExitEncompass();

                //EncompassDialog
                //	.Initialize()
                //	.btn_Yes_Click();

                //ComplianceAlert
                //	.Initialize()
                //	.btn_Close_Click();

                #endregion Completion Milestone

                #region Save and Close

                //EncompassMain
                //	.Initialize()
                //	.ExitEncompass();

                //EncompassDialog
                //	.Initialize()
                //	.btn_Yes_Click();

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
                //Assert.Fail(ex.ToString());
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
		//	TestedApplication.Kill();
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