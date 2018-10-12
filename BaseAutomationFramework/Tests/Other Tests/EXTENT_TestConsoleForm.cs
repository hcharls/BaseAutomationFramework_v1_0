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
using AventStack.ExtentReports;
using BaseAutomationFramework.PageObjects;
using BaseAutomationFramework.PageObjects.EncompassLoanCenter;

namespace BaseAutomationFramework.Tests.Encompass
{
    [TestFixture]
    public class Smoke_Test : BaseTest
    {
        private StreamWriter SW;
        private StatusReport SR;
        string runTime;
        string className;
        string pathStem;
        string testMethodName;
        string path;
        string TestReportName = "Smoke Test (Direct Conv Cash Out loan)";


        [GetTestSet("Test")]
        [TestCaseSource(typeof(GetTestData), "Screen")]

        public void Loan_Creation (IDictionary<string, string> data)
        {
            MasterData = new objMasterData(data);
            className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            testMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //MasterData.TestResultPathStem = string.Format(FileUtilities.DefaultTestResultDirectory, className);
            MasterData.TestResultPathStem = string.Format("{0}\\{1}\\{2}\\{3} - {4}", FileUtilities.DefaultTestResultDirectory_ShareDrive, className, testMethodName, Environment.UserName, runTime);
            path = string.Format("{0}\\{1}.html", MasterData.TestResultPathStem, TestReportName);

            if (!Directory.Exists(string.Format("{0}", MasterData.TestResultPathStem)))
                Directory.CreateDirectory(string.Format("{0}", MasterData.TestResultPathStem));

            if (BaseTest.HtmlReport == null)
                InitializeExtentReports(path, TestReportName);

            BaseTest.extentTest = ExtentReport.CreateTest(runTime);

            string StepDetails = string.Format("Smoke Test");
            bool StepStatus = true;
            string MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
			{
				LaunchApplication(DesktopApps.Encompass);

				Launcher
					.Initialize()
					.cmb_EnvironmentID_SelectByText(MasterData.EnvironmentID)
					.btn_Login_Click();

                extentTest.Pass("Launched Encompass environment " + MasterData.EnvironmentID, MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_Launch"), true)).Build());

                AttachToProcess(Processes.Encompass, 5);

				Login
					.Initialize()
					.txt_Username_SendKeys("test_qa_lo")
					.txt_Password_SendKeys("P@ramount1")
					.btn_Login_Click();

                extentTest.Pass("Logged in as Loan Officer, test_qa_lo", MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_Login"), true)).Build());

                Thread.Sleep(10000); EncompassMain.Initialize().Resize().tab_Pipeline_Select(); Pipeline.Initialize().btn_NewLoan_Click();

                NewLoan
					.Initialize()
					.cmb_LoanTemplateFolder_SelectByText("PEM Direct")
					.SelectItem_DirectConvRefinance();

                extentTest.Pass("Created new Direct Conventional Refinance loan from Pipeline", MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_LoanTemplate"), true)).Build());

                FormsTab.Initialize().chk_Show_Check(true).chk_ShowInAlpha_Check(true);

				TestConsole.OpenForm_FromFormsTab().btn_CreateNewLoan_Click(MasterData.LoanCreator); EncompassDialog.Initialize().btn_OK_Click();

				CreditReport.Initialize().lstbx_Provider_Select("Equifax Mortgage Solutions").btn_Submit_Click();

				CreditReportRequest
					.Initialize()
					.txt_UserName_SendKeys("PARAMOUNTIT")
					.txt_Password_SendKeys("P@ramount2")
					.chk_SaveLoginInformation_Check(true)
					.chk_Equifax_Check(true)
					.chk_Experian_Check(true)
					.chk_TransUnion_Check(true)
					.btn_Finish_Click();

                EncompassMain.Initialize().tab_ServicesView_Select(); extentTest.Pass("Credit Report successfully generated", MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_CreditReport"), true)).Build()); Thread.Sleep(500); EncompassMain.Initialize().tab_Loan_Select();

                TestConsole
                     .Initialize()
                     .rdb_NoCashOutRefi_Select()
                     .rdb_Direct_Select()
                     .txt_BorrowerEmail_SendKeys(MasterData.BorrowerEmail);

				TestConsole.Initialize().btn_BLSCertification_Click(); QuickEntryBankerLoanSubmission.Initialize().ScrollDown().btn_BankerCertificationBLS_Click(); extentTest.Pass("Banker Loan Submission Form certified", MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_BLS"), true)).Build()); QuickEntryBankerLoanSubmission.Initialize().btn_Close_Click();

                TestConsole
					.Initialize()
					.txt_SubjectProperty_Address_SendKeys(MasterData.Address)
					.txt_SubjectProperty_City_SendKeys(MasterData.City)
					.txt_SubjectProperty_State_SendKeys(MasterData.State)
					.txt_SubjectProperty_County_SendKeys(MasterData.County)
					.txt_SubjectProperty_ZipCode_SendKeys(MasterData.Zip);

                BorrowerSummary.OpenForm_FromFormsTab(); Thread.Sleep(500); extentTest.Pass("Borrower Summary successfully completed with Borrower email address " + MasterData.BorrowerEmail, MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_BorrowerSummary"), true)).Build());
           
                URLA_Page1.OpenForm_FromFormsTab(); Thread.Sleep(2000); extentTest.Pass("1003 Page 1 successfully completed with address " + MasterData.Address + ", " + MasterData.City + ", " + MasterData.State + ", " + MasterData.Zip + " (" + MasterData.County + " County)", MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_1003Page1"), true)).Build()); 

                URLA_Page2.OpenForm_FromFormsTab(); Thread.Sleep(2000); extentTest.Pass("1003 Page 2 successfully completed", MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_1003Page2"), true)).Build()); 

                URLA_Page3.OpenForm_FromFormsTab(); Thread.Sleep(2000); extentTest.Pass("1003 Page 3 successfully completed", MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_1003Page3"), true)).Build()); 

                FormsTab.Initialize().lstbx_Forms_SelectForm("VOE"); Thread.Sleep(1000); extentTest.Pass("Verification of Employment successfully completed", MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_VOE"), true)).Build());

                FormsTab.Initialize().lstbx_Forms_SelectForm("VOD"); Thread.Sleep(1000); extentTest.Pass("Verification of Depository successfully completed", MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_VOD"), true)).Build());

                TransmittalSummary.OpenForm_FromFormsTab(); Thread.Sleep(1000); extentTest.Pass("Transmittal Summary successfully completed", MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_TransmittalSum"), true)).Build());

                #region eConsent

                eConsentNotYetReceived.Open_FromAlertsandMessagesTab().btn_Request_eConsent_Click();

                SendConsent
                    .Initialize()
                    .chk_BorrowerConsent_Check(true)
                    .chk_NotifyWhenBorrowerReceives_Check(true)
                    .btn_Send_Click();

                BaseSeleniumPage.CreateDriver(BaseSeleniumPage.WebDrivers.Chrome); BaseSeleniumPage.NavigateToURL(@"https://www.mortgage-application.net/myaccount/accountlogin.aspx");

                BorrowerLoanCenterLogIn.Initialize()
                    .txt_Email_SendKeys("hcpemtesting@gmail.com")
                    .txt_Password_SendKeys("P@ramount1")
                    .btn_Login_Click();

                CheckLoanStatus.Initialize().fn_SelectFirstRow();

                //LoanDetail.Initialize().btn_View_Click();

                AgreeToReceiveDisclosuresElectronically.Initialize().btn_Agree_Click(); BaseSeleniumPage.CloseDriver();

                eConsentNotYetReceived.Initialize().btn_View_eConsent_Click();

                extentTest.Pass("eConsent accepted", MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_eConsentAccepted"), true)).Build());

                #endregion eConsent

                #region Product and Pricing

                OB_ProductandPricing.OpenFrom_MainMenu().lstbx_Provider_Select("Optimal Blue - Enhanced").btn_Submit_Click();

				OB_Login
					.Initialize()
					.txt_LoginName_SendKeys(MasterData.OB_Login)
					.txt_Password_SendKeys(MasterData.OB_Password)
					.chk_SaveLoginInformation_Check(true)
					.chk_UpdateUpfrontMIdataforFHAloans_Check(true)
					.btn_Continue_Click();

                OB_ProductSearch.Initialize().btn_Submit_Click(); extentTest.Pass("Loan is ready to execute pricing through Optimal Blue", MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_Pricing"), true)).Build());

                #endregion Run Product and Pricing

            }

            catch (Exception ex)
            {
                StepStatus = false;
                BaseTest.ExtentFailStep(ex, StepDetails, "ErrorOccured");
                //step.ModalText = ex.ToString();
                //step.Status = "Fail";
                //step.ScreenShotLocation = Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format("Failure\\{0}", System.Reflection.MethodBase.GetCurrentMethod().Name));
                Assert.Fail(ex.ToString());
            }
            finally
            {
                if (StepStatus) extentTest.Pass("Test Passed - reached the end of script");
                //Report.addStep(step);
            }

        }

        [TestFixtureSetUp]
        public void OnFixtureSetup()
        {
            runTime = CreateRuntimeString();
            BaseTest.ExtentReport = new ExtentReports();
            //
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
            BaseTest.ExtentReport.Flush();
            BaseTest.NullifyExtentReport();
            //string subject = string.Format("All your tests are finished, good job!");
            //string body = string.Format("All your tests are finished, good job!");
            //EmailUtilities.Email email = new EmailUtilities.Email(subject, body, "hannah.charls@aol.com");

            //EmailUtilities.SendEmail(email);
            //Report.writeReport();
        }
    }
}