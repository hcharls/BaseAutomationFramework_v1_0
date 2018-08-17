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
	public class TEST_07_QCReview : BaseTest
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

				QCReview
					.Open_FromLogTab()
					.chk_QCReviewTasks_Check()
					.btn_DocDrawer_Click();

				SelectLoanTeamMember
					.Initialize()
					.QCReview_SelectDocDrawer();

				QCReview
					.Initialize()
					.chk_Finish_Check();

				EncompassMain
					.Initialize()
					.ExitEncompass();

				ExitEncompass
					.Initialize()
					.btn_Yes_Click();


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