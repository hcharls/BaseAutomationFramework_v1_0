///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Conv_NoCashOutRefi>
///   Class:          <TEST_08_DocsAndFunding>
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

namespace BaseAutomationFramework.Tests.Encompass.LoanCreation.Conventional.Conv_NoCashOutRefi
{
	[TestFixture]
	public class TEST_08_DocsAndFunding : BaseTest
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

				//LaunchApplication(DesktopApps.Encompass);

				//Launcher
				//	.Initialize()
				//	.cmb_EnvironmentID_SelectByText(MasterData.EnvironmentID)
				//	.btn_Login_Click();

				AttachToProcess(Processes.Encompass, 5);

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

				//ClosingForm
				//	.OpenForm_FromFormsTab()
				//	.btn_DocsAddData_Click();

				//BorrowerInformationVesting
				//	.OpenForm_FromFormsTab()
				//	.btn_BuildFinal_Click();

				//ClosingVendorInformation
				//	.OpenForm_FromFormsTab()
				//	.txt_EscrowCompanyName_SendKeys("test");

				ClosingTracking
					.OpenForm_FromFormsTab()
					.txt_EarliestClosingDate_SendKeys("c");

				RegZCD
					.OpenForm_FromFormsTab()
					.txt_DocumentDate_SendKeys("v")
					.txt_ClosingDate_SendKeys("v")
					.txt_DocSigningDate_SendKeys("v")
					.btn_Audit_Click();

				SelectPlanCode
					.Initialize()
					.ClosingDocs_SelectPlanCode();

				SelectReportType
					.Initialize()
					.rdb_Preview_Select()
					.btn_OK_Click();

				ClosingDocsAudit
					.Initialize()
					.cmb_OrderType_SelectByText("Pre-Closing")
					.btn_OrderDocs_Click();

				SelectDocuments
					.Initialize()
					.btn_Send_Click();

				SendDisclosures
					.Initialize()
					.cmb_BorrowerAuthenticationMethod_SendKeys("Authorization Code")
					.txt_BorrowerAuthorization_SendKeys("13188")
					.btn_Send_Click();

				EncompassDialog
					.Initialize()
					.btn_OK_Click();

				






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

				//FundingReview
				//	.Open_FromLogTab()
				//	.btn_Funder_Click();

				//SelectLoanTeamMember
				//	.Initialize()
				//	.FundingReview_SelectLoanFunder();

				//FundingReview
				//	.Initialize()
				//	.chk_Finish_Check();

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