///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Conv_NoCashOutRefi>
///   Class:          <TEST_06_FinalUWApproval>
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
	public class TEST_06_FinalUWApproval : BaseTest
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

				Encompass_eFolder
					.Open_eFolder()
					.eFolder_UnderwriterReview("1003");

				DocumentDetails
					.Initialize()
					.Chk_Reviewed_Check(true)
					.btn_Close_Click();

				Encompass_eFolder
					.Initialize()
					.eFolder_UnderwriterReview("Credit Report");

				DocumentDetails
					.Initialize()
					.Chk_Reviewed_Check(true)
					.btn_Close_Click();

				Encompass_eFolder
					.Initialize()
					.eFolder_UnderwriterReview("Underwriting");

				DocumentDetails
					.Initialize()
					.Chk_Reviewed_Check(true)
					.btn_Close_Click();

				Encompass_eFolder
					.Initialize()
					.btn_Close_Click();

				FinalUWApproval
					.Open_FromLogTab()
					.cmb_ULDDPropertyValuationMethodType_SendKeys("None")
					.txt_TotalMortgagedPropertiesCount_SendKeys("1")
					.txt_ULDDInvestorFeatureID_SendKeys("5645646446")
					.cmb_UnderwritingLevelOfPrptyReview_SendKeys("No Appraisal")
					.cmb_DayOneCertainty_SendKeys("NO")
					.txt_UnderwritingClearToCloseDate_SendKeys("030518")
					.chk_FinalUWApprovalTasks_Check()
					.btn_QualityControl_Click();

				SelectLoanTeamMember
					.Initialize()
					.FinalUWApproval_SelectQualityControl();

				FinalUWApproval
					.Initialize()
					.chk_Finish_Check();

				EncompassMain
					.Initialize()
					.ExitEncompass();

				ExitEncompass
					.Initialize()
					.btn_Yes_Click();

				ComplianceReview
					.Initialize()
					.btn_Close_Click();
				

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