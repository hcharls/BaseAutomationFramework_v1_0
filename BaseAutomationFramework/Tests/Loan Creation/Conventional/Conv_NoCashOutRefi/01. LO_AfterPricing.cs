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


namespace BaseAutomationFramework.Tests.Encompass.LoanCreation.Conventional.Conv_NoCashOutRefi
{
	[TestFixture]
	public class TEST_01_LO_AfterPricing : BaseTest
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

                #region Disclosure Prep (TRID) 

                //DisclosurePrep
                //.OpenForm_FromFormsTab()
                //.cmb_WillThereBeSubordination_SendKeys("No")
                //.cmb_BetterRateWarranty_SendKeys("No")
                //.cmb_ImpoundsWaivedOrNotWaived_SendKeys("Not Waived")
                //.cmb_ImpoundsWillBeFor_SendKeys("Taxes and Insurance (T & I)")
                //.cmb_AddingRemovingSomeoneFromTitle_SendKeys("No")
                //.btn_GenerateEstimatedClosingDatesandStandardFees_Click()
                //.btn_WestVM_Click();

                //EncompassMain.Initialize().ExecuteQuickWestVM().tab_Loan_Select();

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

                //LoanEstimatePage1.OpenForm_FromFormsTab().chk_IntentToProceed_Check(true);

                //DisclosedLESnapshot.Initialize().btn_OK_Click();



                //BankerLoanSubmission.OpenForm_FromFormsTab().btn_CopyCashBackSTC_Click(); EncompassDialog.Initialize().btn_OKtoCertify_Click(); BankerLoanSubmission.Initialize().btn_BankerCertificationBLS_Click();

                //Application.Open_FromLogTab().cmb_UnderwritingRiskAccessType_SendKeys("DU").cmb_LoanInfoRefiPurpose_SendKeys("Cash-Out Other").btn_ProcessingMgr_Click();

                //SelectLoanTeamMember.Initialize().Application_SelectProcessingMgr();

                //Application.Initialize().chk_Finish_Check();

                //EncompassMain.Initialize().ExitEncompass(); EncompassDialog.Initialize().btn_Yes_Click(); ComplianceAlert.Initialize().btn_Close_Click();


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
			//string subject = string.Format("All your tests are finished, good job!");
			//string body = string.Format("All your tests are finished, good job!");
			//EmailUtilities.Email email = new EmailUtilities.Email(subject, body, "hannah.charls@aol.com");

			//EmailUtilities.SendEmail(email);
			//Report.writeReport();
		}
	}
}