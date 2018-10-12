using BaseAutomationFramework.PageObjects.Encompass;
using NUnit.Framework;
using System.Threading;
using BaseAutomationFramework.PageObjects;
using BaseAutomationFramework.PageObjects.EncompassLoanCenter;
using System;

namespace BaseAutomationFramework.Tests.Encompass.LoanCreation

{
    [TestFixture]
    public class LaunchCreateNew : BaseTest
    {
        //string EnvironmentID = "TEBE11141905";
        string EnvironmentID = "TEBE11166948";
        //string EnvironmentID = "BE799584";
        string LoanOfficer = "test_qa_lo";

        [Test]
        public void DirectConvRefinance()
        //public void _01_PipelineCreateNew(IDictionary<string, string> data)

        {
            AttachToProcess(Processes.Encompass, 5);

            LaunchApplication(DesktopApps.Encompass); Launcher.Initialize().cmb_EnvironmentID_SelectByText(EnvironmentID).btn_Login_Click(); AttachToProcess(Processes.Encompass, 5);

            Login.Initialize().Login_Username_SendKeys(LoanOfficer);

            Pipeline.Initialize().btn_NewLoan_Click(); NewLoan.Initialize().SelectItem_DirectConvRefinance();

            FormsTab.Initialize().OpenFormsTab();

        }
    }

    [TestFixture]
    public class Regression : BaseTest
    {
        string LoanNumber = "5472130STG";
        string LoanCreator = "Hannah";
        string BorrowerEmail = "hcpemtesting@gmail.com";
        string AuthorizationCode = "13188";
        string LoanCenterPassword = "P@ramount1";
        string SubjectPropertyAddress = "101218 Mock Deploy";
        string SubjectPropertyZip = "02030";
        string LoanProgram = "LP CONF 30YR FIXED";

        //string EnvironmentID = "TEBE11141905";
        //string ClientID = "3011141905";
        //string OBLogin = "qa_testlo_direct";
        //string OBPassword = "Apple37";

        string EnvironmentID = "TEBE11166948";
        string ClientID = "3011166948";
        string OBLogin = "stg_testlo_direct";
        string OBPassword = "12345";

        //string EnvironmentID = "BE799584";
        //string ClientID = "3000799584";
        //string OBLogin = "test_lo_direct";
        //string OBPassword = "12345";

        string EquifaxLogin = "PARAMOUNTIT";
        string EquifaxPassword = "P@ramount2";
        string WestVMLogin = "PEMAdmin";
        string WESTVMPassword = "Pemadmin1";
        string SmartGFELogin = "test_lo";
        string SmartGFEPassword = "P@ramount1";
        string SmartGFELicenseKey = "44538732-3214-462b-ac0b-4dd95224ae83";

        string LoanOfficer = "test_qa_lo";
        string ProcessingMgr = "test_qa_som";
        string LoanProcessor = "test_qa_proc";
        string Underwriter = "test_qa_uw";
        string QualityControl = "test_qa_qc";
        string Shipper = "test_qa_shipper";
        string Secondary = "test_qa_sec";
        string PostCloser = "test_qa_pc";
        string DocFunder = "test_qa_fundd";

        [Test]
        public void _01_TestConsole()

        {
            AttachToProcess(Processes.Encompass, 5);

            TestConsole.OpenForm_FromFormsTab()
               .rdb_Conventional_Select()
               .rdb_NoCashOutRefi_Select()
               .rdb_Direct_Select()
               .rdb_FixedRate_Select()
               .btn_CreateNewLoan_Click(LoanCreator);

            CreditReport.Initialize().lstbx_Provider_Select("Equifax Mortgage Solutions")//.btn_Submit_Click();
            .btn_Cancel_Click();
           
            //CreditReportRequest.Initialize().txt_UserName_SendKeys(EquifaxLogin).txt_Password_SendKeys(EquifaxPassword).chk_SaveLoginInformation_Check(true).chk_Equifax_Check(true).chk_Experian_Check(true).chk_TransUnion_Check(true).btn_Finish_Click();

            TestConsole.Initialize()
               .txt_SubjectProperty_Address_SendKeys(SubjectPropertyAddress)
               .txt_SubjectProperty_ZipCode_SendKeys(SubjectPropertyZip)
               .chk_CreditReportBypass_Check();

        }

        [Test]
        public void _02_OptimalBluePricing()
        {
            AttachToProcess(Processes.Encompass, 5);

            #region Floating Product and Pricing

            OB_ProductandPricing.OpenFrom_MainMenu().lstbx_Provider_Select("Optimal Blue - Enhanced").btn_Submit_Click();

            OB_Login.Initialize().txt_LoginName_SendKeys(OBLogin).txt_Password_SendKeys(OBPassword).chk_SaveLoginInformation_Check(true).btn_Continue_Click();

            OB_ProductSearch.Initialize().btn_Submit_Click(); OB_SearchResults.Initialize().SelectLoanProgram_Click(LoanProgram); Thread.Sleep(10000); OB_LockForm.Initialize().btn_UpdateEncompass_Click(); Thread.Sleep(10000); OB_PricingImportEncompassUpdate.Initialize().btn_Close_Click();

            #endregion

            #region Locked Product and Pricing

            //OB_ProductandPricing.OpenFrom_MainMenu().lstbx_Provider_Select("Optimal Blue - Enhanced").btn_Submit_Click();

            //OB_Login.Initialize().txt_LoginName_SendKeys(OBLogin).txt_Password_SendKeys(OBPassword).chk_SaveLoginInformation_Check(true).btn_Continue_Click();

            //OB_ProductSearch.Initialize().btn_Submit_Click(); OB_SearchResults.Initialize().SelectLoanProgram_Click(LoanProgram); Thread.Sleep(10000); OB_LockForm.Initialize().btn_RequestLock_Click(); Thread.Sleep(10000); OB_PricingImportEncompassUpdate.Initialize().btn_Close_Click();

            //OB_LockRequestDialog.Initialize().btn_ExitLoan_Click();

            //Thread.Sleep(20000); Pipeline.Initialize().Pipeline_SelectCurrentLoan(LoanNumber);
            
            #endregion

        }

        [Test]
        public void _03_DisclosurePrepTRID()
        {
            AttachToProcess(Processes.Encompass, 5);

            //TestConsole.Initialize().chk_UnderwritingBypass_Check().chk_WestVM_Bypass_Check().chk_SmartGFE_Bypass_Check().btn_FancyMilestones_Click();

            DisclosurePrep
                .OpenForm_FromFormsTab()
                .cmb_WillThereBeSubordination_SendKeys("No")
                .cmb_BetterRateWarranty_SendKeys("No")
                .cmb_ImpoundsWaivedOrNotWaived_SendKeys("Not Waived")
                .cmb_ImpoundsWillBeFor_SendKeys("Taxes and Insurance (T & I)")
                .cmb_AddingRemovingSomeoneFromTitle_SendKeys("No")
                .btn_GenerateEstimatedClosingDatesandStandardFees_Click()
                .btn_WestVM_Click(); EncompassMain.Initialize().tab_Loan_Select();

            DisclosurePrep.Initialize().btn_Review2015Itemization_Click(); Itemization.OpenForm_FromFormsTab(); PropertyTaxesReserved.OpenFromItemization().cmb_ReserveBasedOn_SendKeys("B").txt_RatePercentage_SendKeys(".25").btn_OK_Click(); AggregateSetup.OpenFromItemization().btn_OK_Click();

            DisclosurePrep.OpenForm_FromFormsTab().btn_RunComplianceReport_Click();

            DisclosurePrep
                .OpenForm_FromFormsTab()
                .cmb_PropertyInspectionWaiver_SendKeys("No")
                .cmb_DocumentDeliveryPreference_SendKeys("Email - eSign")
                .btn_ReadytoDisclose_Click()
                .btn_GenerateDisclosures_Click();

        }

        [Test]
        public void _04_InitialDisclosures()
        {
            AttachToProcess(Processes.Encompass, 5);

            Order_eDisclosures.Initialize().InitialDisclosures_SelectTopPlanCode().btn_Order_eDisclosures_Click();

            DisclosuresAudit.Initialize().btn_Order_eDisclosures_Click();

            SelectDocumentsInitial.Initialize().btn_Send_Click();

            SendDisclosuresInitial.Initialize().txt_BorrowerAuthorization_SendKeys(AuthorizationCode).btn_Send_Click();

            DisclosuresDialog.Initialize().btn_No_Click(); EncompassDialog.Initialize().btn_OK_Click();

            BaseSeleniumPage.CreateDriver(BaseSeleniumPage.WebDrivers.Chrome); BaseSeleniumPage.NavigateToURL(@"https://encompass.mortgage-application.net/EncompassAccount/AccountLogin.aspx");

            LoanOfficerLoanCenterLogIn.Initialize().txt_ClientID_SendKeys(ClientID).txt_UserID_SendKeys(LoanOfficer).txt_Password_SendKeys(LoanCenterPassword).btn_Login_Click();

            CheckLoanStatus.Initialize().fn_SelectFirstRow(); LoanDetail.Initialize().btn_View_Click(); DocuSign.Initialize().fn_ESignWholeDocument();

            BaseSeleniumPage.NavigateToURL(@"https://www.mortgage-application.net/myaccount/accountlogin.aspx");

            BorrowerLoanCenterLogIn.Initialize().txt_Email_SendKeys(BorrowerEmail).txt_Password_SendKeys(LoanCenterPassword).btn_Login_Click();

            CheckLoanStatus.Initialize().fn_SelectFirstRow(); LoanDetail.Initialize().btn_View_Click(); AgreeToReceiveDisclosuresElectronically.Initialize().btn_Agree_Click();

            VerifyIdentity.Initialize().txt_AuthorizationCode_SendKeys(AuthorizationCode).btn_Next_Click();

            DocuSign.Initialize().fn_ESignWholeDocument(); BaseSeleniumPage.CloseDriver();

            Retrieve.OpenFrom_eFolder().btn_Download_Click(); FileManager.Initialize().btn_Close_Click(); Encompass_eFolder.Initialize().btn_Close_Click();

        }

        [Test]
        public void _05_CompleteApplication()
        {
            AttachToProcess(Processes.Encompass, 5);

            DisclosureTracking.Initialize().btn_InitialDisclosureRecord_Click(); DisclosureDetails.Initialize().btn_SendDateManualEntry_Click().txt_DisclosureSentDate_SetBack().txt_ActualReceivedDate_SetDate().chk_IntentToProceed_Check(true).btn_OK_Click();

            BankerLoanSubmission.OpenForm_FromFormsTab().btn_CopyCashBackSTC_Click(); EncompassDialog.Initialize().btn_OKtoCertify_Click(); BankerLoanSubmission.Initialize().btn_BankerCertificationBLS_Click();

            Application.Open_FromLogTab().cmb_UnderwritingRiskAccessType_SendKeys("DU").cmb_LoanInfoRefiPurpose_SendKeys("No Cash-Out Other").chk_Finish_Check();

            BorrowerSummary.OpenForm_FromFormsTab().CopyLoanNumber();

            EncompassMain.Initialize().ExitEncompass(); EncompassDialog.Initialize().btn_Yes_Click(); ComplianceAlert.Initialize().btn_Close_Click(); TestedApplication.Kill();

        }

        [Test]
        public void _06_PreProcReview()
        {
            LaunchApplication(DesktopApps.Encompass); Launcher.Initialize().cmb_EnvironmentID_SelectByText(EnvironmentID).btn_Login_Click();

            AttachToProcess(Processes.Encompass, 5);

            Login.Initialize().Login_Username_SendKeys(ProcessingMgr);

            Pipeline.Initialize().Pipeline_SelectCurrentLoan(LoanNumber);

            PreProcReview
                .Open_FromLogTab()
                .cmb_Disclosures_eSigned_SendKeys("Yes")
                .chk_Finish_Check();

            EncompassMain.Initialize().ExitEncompass(); EncompassDialog.Initialize().btn_Yes_Click(); ComplianceAlert.Initialize().btn_Close_Click(); TestedApplication.Kill();

        }

        [Test]
        public void _07_ApprovalSubmitToUW()
        {
            LaunchApplication(DesktopApps.Encompass); Launcher.Initialize().cmb_EnvironmentID_SelectByText(EnvironmentID).btn_Login_Click();

            AttachToProcess(Processes.Encompass, 5);

            Login.Initialize().Login_Username_SendKeys(LoanProcessor);

            Pipeline.Initialize().Pipeline_SelectCurrentLoan(LoanNumber);

            ProcPreApproval.Open_FromLogTab().chk_Finish_Check();

            SubmitToUW.Open_FromLogTab().chk_Finish_Check();

            EncompassMain.Initialize().ExitEncompass(); EncompassDialog.Initialize().btn_Yes_Click(); ComplianceAlert.Initialize().btn_Close_Click(); CompliancePreview.Initialize().btn_Close_Click(); TestedApplication.Kill();

        }

        [Test]
        public void _08_InitialUWDecision()
        {
            LaunchApplication(DesktopApps.Encompass); Launcher.Initialize().cmb_EnvironmentID_SelectByText(EnvironmentID).btn_Login_Click();

            AttachToProcess(Processes.Encompass, 5);

            Login.Initialize().Login_Username_SendKeys(Underwriter);

            Pipeline.Initialize().Pipeline_SelectCurrentLoan(LoanNumber);

            UnderwriterSummary.OpenForm_FromToolsTab().txt_ApprovedByDate_SetDate().txt_ApprovalExpiresDate_SetDate();

            InitialUWDecision.Open_FromLogTab().chk_Finish_Check();

            EncompassMain.Initialize().ExitEncompass(); EncompassDialog.Initialize().btn_Yes_Click(); ComplianceAlert.Initialize().btn_Close_Click(); TestedApplication.Kill();

        }

        [Test]
        public void _09_ConditionsSent()
        {
            LaunchApplication(DesktopApps.Encompass); Launcher.Initialize().cmb_EnvironmentID_SelectByText(EnvironmentID).btn_Login_Click();

            AttachToProcess(Processes.Encompass, 5);

            Login.Initialize().Login_Username_SendKeys(LoanProcessor);

            EncompassMain.Initialize().Resize().tab_Pipeline_Select();

            Pipeline.Initialize().Pipeline_SelectCurrentLoan(LoanNumber);

            ClosingForm.OpenForm_FromFormsTab().btn_ProcessorAddData_Click().CompleteCurrentVesting().btn_ProcessorClicktoCertify_Click().cmb_IsFileReadyForUnderwriting_SendKeys("yes");

            AdditionalRequestsInformation.OpenForm_FromFormsTab().CompleteFields_HazardInsurance(); FloodInformation.OpenForm_FromFormsTab().CompleteFields_FloodCertification();

            URLA_Page2.OpenForm_FromFormsTab().cmb_MortgageType1_SendKeys("Mortgage"); MortgagePayoff.OpenForm_FromFormsTab().cmb_LenderName1_Select().txt_PrincipalBalance1_SendKeys("10,000");

            ClosingVendorInformation.Initialize().CompleteTitleEscrowFields();

            ConditionsSent.Open_FromLogTab().CompleteReqFields_DirectConvNoCashOutRefi().chk_Finish_Check();

            EncompassMain.Initialize().ExitEncompass(); EncompassDialog.Initialize().btn_Yes_Click(); ComplianceAlert.Initialize().btn_Close_Click(); TestedApplication.Kill();

        }

        [Test]
        public void _10_FinalUWApproval()
        {
            LaunchApplication(DesktopApps.Encompass); Launcher.Initialize().cmb_EnvironmentID_SelectByText(EnvironmentID).btn_Login_Click();

            AttachToProcess(Processes.Encompass, 5);

            Login.Initialize().Login_Username_SendKeys(Underwriter);

            Pipeline.Initialize().Pipeline_SelectCurrentLoan(LoanNumber);

            Encompass_eFolder.Open_eFolder().eFolder_UnderwriterReview("1003"); DocumentDetails.Initialize().chk_Reviewed_Check(true).btn_Close_Click();

            Encompass_eFolder.Initialize().eFolder_UnderwriterReview("Credit Report"); DocumentDetails.Initialize().chk_Reviewed_Check(true).btn_Close_Click();

            Encompass_eFolder.Initialize().eFolder_UnderwriterReview("Underwriting"); DocumentDetails.Initialize().chk_Reviewed_Check(true).btn_Close_Click();

            Encompass_eFolder.Initialize().btn_Close_Click();

            FinalUWApproval
                .Open_FromLogTab()
                .cmb_ULDDPropertyValuationMethodType_SendKeys("None")
                .txt_TotalMortgagedPropertiesCount_SendKeys("1")
                .txt_ULDDInvestorFeatureID_SendKeys("5645646446")
                .cmb_UnderwritingLevelOfPrptyReview_SendKeys("No Appraisal")
                .cmb_DayOneCertainty_SendKeys("NO")
                .txt_UnderwritingClearToCloseDate_SendKeys("030518")
                .chk_FinalUWApprovalTasks_Check()
                .chk_Finish_Check();

            EncompassMain.Initialize().ExitEncompass(); ExitEncompass.Initialize().btn_Yes_Click(); CompliancePreview.Initialize().btn_Close_Click(); TestedApplication.Kill();
            
        }

        [Test]
        public void _11_QCReview()
        {
            LaunchApplication(DesktopApps.Encompass); Launcher.Initialize().cmb_EnvironmentID_SelectByText(EnvironmentID).btn_Login_Click();

            AttachToProcess(Processes.Encompass, 5);

            Login.Initialize().Login_Username_SendKeys(QualityControl);

            Pipeline.Initialize().Pipeline_SelectCurrentLoan(LoanNumber);

            QCReview.Open_FromLogTab().chk_QCReviewTasks_Check().chk_Finish_Check();

            EncompassMain.Initialize().ExitEncompass(); ExitEncompass.Initialize().btn_Yes_Click(); CompliancePreview.Initialize().btn_Close_Click(); TestedApplication.Kill();
        
        }

        [Test]
        public void _12_DocsOut()
        {
            LaunchApplication(DesktopApps.Encompass); Launcher.Initialize().cmb_EnvironmentID_SelectByText(EnvironmentID).btn_Login_Click();

            AttachToProcess(Processes.Encompass, 5);

            Login.Initialize().Login_Username_SendKeys(DocFunder);

            Pipeline.Initialize().Pipeline_SelectCurrentLoan(LoanNumber);

            BorrowerInformationVesting.OpenForm_FromFormsTab().btn_BuildFinal_Click();

            ClosingForm.OpenForm_FromFormsTab().btn_DocsAddData_Click();

            ClosingTracking.OpenForm_FromFormsTab().txt_CD_Ordered_SetTodaysDate().txt_EarliestClosingDate_CopyField();

            RegZCD.OpenForm_FromFormsTab().txt_DocumentDate_SendKeys().txt_ClosingDate_SendKeys().txt_DocSigningDate_SendKeys().btn_Audit_Click();

            SelectPlanCode.Initialize().ClosingDocs_SelectPlanCode();

            SelectReportType.Initialize().rdb_Preview_Select().btn_OK_Click();

            ClosingDocsAudit.Initialize().cmb_OrderType_SelectByText("Pre-Closing").btn_OrderDocs_Click();

            SelectDocumentsClosing.Initialize().btn_Send_Click();

            SendDisclosuresClosing.Initialize().txt_BorrowerAuthorization_SendKeys(AuthorizationCode).btn_Send_Click();

            EncompassDialogCDSent.Initialize().btn_OK_Click();

            BaseSeleniumPage.CreateDriver(BaseSeleniumPage.WebDrivers.Chrome); BaseSeleniumPage.NavigateToURL(@"https://www.mortgage-application.net/myaccount/accountlogin.aspx");

            BorrowerLoanCenterLogIn.Initialize().txt_Email_SendKeys(BorrowerEmail).txt_Password_SendKeys(LoanCenterPassword).btn_Login_Click();

            CheckLoanStatus.Initialize().fn_SelectFirstRow(); LoanDetail.Initialize().btn_View_Click();

            VerifyIdentity.Initialize().txt_AuthorizationCode_SendKeys(AuthorizationCode).btn_Next_Click();

            DocuSign.Initialize().fn_ESignWholeDocument(); BaseSeleniumPage.CloseDriver();
                        
            DocsOut.Open_FromLogTab().txt_PropertyInfoParcelNumber_SendKeys().chk_ReviewTasks_Check().chk_Finish_Check();

        }

        [Test]
        public void _13_DocsBack()
        {
            AttachToProcess(Processes.Encompass, 5);

            Encompass_eFolder.Open_eFolder(); Retrieve.OpenFrom_eFolder().btn_Download_Click(); Encompass_eFolder.Initialize().btn_Close_Click();

            DocsBack.Open_FromLogTab().chk_Finish_Check();

        }

        [Test]
        public void _14_FundingReview()
        {
            AttachToProcess(Processes.Encompass, 5);

            FundingReview.Open_FromLogTab().chk_Finish_Check();

        }

        [Test]
        public void _15_Funding()
        {
            AttachToProcess(Processes.Encompass, 5);

            FundingWorksheet.OpenForm_FromToolsTab().txt_FundsOrdered_SendKeys("").txt_FundsSent_SendKeys("");

            Funding.Open_FromLogTab().chk_Finish_Check();

        }

        [Test]
        public void _16_Shipping()
        {
            LaunchApplication(DesktopApps.Encompass); Launcher.Initialize().cmb_EnvironmentID_SelectByText(EnvironmentID).btn_Login_Click();

            AttachToProcess(Processes.Encompass, 5);

            Login.Initialize().Login_Username_SendKeys(Shipper);

            Pipeline.Initialize().Pipeline_SelectCurrentLoan(LoanNumber);

            Shipping.Open_FromLogTab().chk_Finish_Check();

        }

        [Test]
        public void _17_Purchase()
        {
            LaunchApplication(DesktopApps.Encompass); Launcher.Initialize().cmb_EnvironmentID_SelectByText(EnvironmentID).btn_Login_Click();

            AttachToProcess(Processes.Encompass, 5);

            Login.Initialize().Login_Username_SendKeys(Secondary);

            Pipeline.Initialize().Pipeline_SelectCurrentLoan(LoanNumber);

            Purchase.Open_FromLogTab().chk_Finish_Check();

        }

        [Test]
        public void _18_Completion()
        {
            LaunchApplication(DesktopApps.Encompass); Launcher.Initialize().cmb_EnvironmentID_SelectByText(EnvironmentID).btn_Login_Click();

            AttachToProcess(Processes.Encompass, 5);

            Login.Initialize().Login_Username_SendKeys(PostCloser);

            Pipeline.Initialize().Pipeline_SelectCurrentLoan(LoanNumber);

            Completion.Open_FromLogTab().chk_Finish_Check();

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