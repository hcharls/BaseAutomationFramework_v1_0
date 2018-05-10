///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Conv_NoCashOutRefi>
///   Class:          <TEST_0_NewTestConsoleForm>
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
using BaseAutomationFramework.PageObjects.Yahoo;
using BaseAutomationFramework.PageObjects;
using BaseAutomationFramework.PageObjects.EncompassLoanCenter;

namespace BaseAutomationFramework.Tests.Encompass.LoanCreation.Conventional.Conv_NoCashOutRefi
{
	[TestFixture]
	public class TEST_0_NewTestConsoleForm : BaseTest
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
				LaunchApplication(DesktopApps.Encompass);

				Launcher
					.Initialize()
					.cmb_EnvironmentID_SelectByText(MasterData.EnvironmentID)
					.btn_Login_Click();

				AttachToProcess(Processes.Encompass, 5);

				Login
					.Initialize()
					.txt_Username_SendKeys("test_qa_lo")
					.txt_Password_SendKeys("P@ramount1")
					.btn_Login_Click();

				Thread.Sleep(10000);

				EncompassMain.Initialize().Resize().tab_Pipeline_Select();

				Pipeline.Initialize().btn_NewLoan_Click();

				NewLoan
					.Initialize()
					.cmb_LoanTemplateFolder_SelectByText("PEM Direct")
					.SelectItem_DirectConvRefinance();

				FormsTab.Initialize().chk_Show_Check(true).chk_ShowInAlpha_Check(true);

				TestConsole.OpenForm_FromFormsTab().btn_KenCustomer_Click();

				EncompassDialog.Initialize().btn_OK_Click();

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

				EncompassMain.Initialize().tab_Loan_Select();

               TestConsole
					.Initialize()
					.btn_CashOutRefi_Click()
					.btn_Direct_Click()
					.btn_HannahEmail_Click()
					.btn_BLSCertification_Click();

				QuickEntryBankerLoanSubmission.Initialize().ScrollDown().btn_BankerCertificationBLS_Click().btn_Close_Click();

				TestConsole
					.Initialize()
					.txt_SubjectProperty_Address_SendKeys(MasterData.Address)
					.txt_SubjectProperty_City_SendKeys(MasterData.City)
					.txt_SubjectProperty_State_SendKeys(MasterData.State)
					.txt_SubjectProperty_County_SendKeys(MasterData.County)
					.txt_SubjectProperty_ZipCode_SendKeys(MasterData.Zip);

				#region eConsent

				eConsentNotYetReceived.Open_FromAlertsandMessagesTab().btn_Request_eConsent_Click();

				SendConsent
					.Initialize()
					.chk_BorrowerConsent_Check(true)
					.chk_NotifyWhenBorrowerReceives_Check(true)
					.btn_Send_Click();

				BaseSeleniumPage.CreateDriver(BaseSeleniumPage.WebDrivers.Chrome);BaseSeleniumPage.NavigateToURL(@"https://www.mortgage-application.net/myaccount/accountlogin.aspx");

				BorrowerLoanCenterLogIn.Initialize()
					.txt_Email_SendKeys("hcpemtesting@gmail.com")
					.txt_Password_SendKeys("P@ramount1")
					.btn_Login_Click();

				CheckLoanStatus.Initialize().fn_SelectFirstRow();

                //LoanDetail.Initialize().btn_View_Click();

                AgreeToReceiveDisclosuresElectronically.Initialize().btn_Agree_Click();BaseSeleniumPage.CloseDriver();

				eConsentNotYetReceived.Initialize().btn_View_eConsent_Click();

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

				OB_ProductSearch.Initialize().btn_Submit_Click();Thread.Sleep(10000);OB_LockForm.Initialize().btn_UpdateEncompass_Click();Thread.Sleep(10000); OB_PricingImportEncompassUpdate.Initialize().btn_Close_Click();

				#endregion Run Product and Pricing


				#region Disclosure Prep (TRID)

				DisclosurePrep
				    .OpenForm_FromFormsTab()
				    .cmb_WillThereBeSubordination_SendKeys("No")
				    .cmb_BetterRateWarranty_SendKeys("No")
				    .cmb_ImpoundsWillBeFor_SendKeys("Taxes and Insurance (T & I)")
				    .cmb_AddingRemovingSomeoneFromTitle_SendKeys("No")
				    .btn_GenerateEstimatedClosingDatesandStandardFees_Click()
				    .btn_SmartGFE_Click();

				WVM_TitleAndClosing.OpenFrom_MainMenu().Select_WestVMTitle_TEST();

				WVM_LogOn
				    .Initialize()
				    .txt_Password_SendKeys("Pemadmin1")
				    .btn_LogOn_Click()
				    .WestVM_UploadFees_Click();

				EncompassMain.Initialize().tab_Loan_Select();DisclosurePrep.Initialize().btn_Review2015Itemization_Click();Itemization.OpenForm_FromFormsTab();

				PropertyTaxesReserved
					.OpenFromItemization()
					.cmb_ReserveBasedOn_SendKeys("Base Loan Amount")
					.txt_RatePercentage_SendKeys(".25")
					.btn_OK_Click();

				DisclosurePrep.OpenForm_FromFormsTab().btn_RunComplianceReport_Click();

				DisclosurePrep
					.OpenForm_FromFormsTab()
					.btn_NotNowContinue_Click()
					.cmb_DocumentDeliveryPreference_SendKeys("Email - eSign")
					.btn_ReadytoDisclose_Click()
					.btn_GenerateDisclosures_Click();

				DisclosurePlanCode.SelectPlanCode().btn_Order_eDisclosures_Click();SelectDocuments.Initialize().btn_Send_Click();

				SendDisclosures
					.Initialize()
					.cmb_BorrowerAuthenticationMethod_SendKeys("Authorization Code")
					.txt_BorrowerAuthorization_SendKeys("13188")
					.btn_Send_Click();

                #endregion Disclosure Prep (TRID)

                #region Initial Disclosures

                BorrowerLoanCenterLogIn.Initialize()
                    .txt_Email_SendKeys("hcpemtesting@gmail.com")
                    .txt_Password_SendKeys("P@ramount1")
                    .btn_Login_Click();

                CheckLoanStatus.Initialize().fn_SelectFirstRow();

                //LoanDetail.Initialize().btn_eSign_Click();

                VerifyIdentity.Initialize().txt_AuthorizationCode_SendKeys("13188").btn_Next_Click();

                LoanDocuments.Initialize().btn_Next_Click().btn_Start_Click().btn_RequiredSignHere_Click();


                Retrieve.OpenFrom_eFolder().btn_Download_Click();Encompass_eFolder.Initialize().btn_Close_Click();

                #endregion Initial Disclosures

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