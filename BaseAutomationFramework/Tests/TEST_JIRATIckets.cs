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
	public class JIRATickets : BaseTest
	{
		private StreamWriter SW;
		private StatusReport SR;
		string runTime;
		string className;
		string pathStem;

		[GetTestSet("Test")]
		[TestCaseSource(typeof(GetTestData), "Screen")]
		public void EncompassNewLoanCreation(IDictionary<string, string> data)
		{
			MasterData = new objMasterData(data);
			MasterData.TestResultPathStem = pathStem;
			className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
			Step step = new Step();

			step.Action = string.Format("Test: {0}", MasterData.TestDescription);
			step.ExpectedResult = string.Format("");
			step.ActualResult = string.Format("");
			step.Status = "Pass";
			step.Time = DateTime.Now.ToString();

			try
			{
				AttachToProcess(Processes.Encompass, 5);

				#region Impounds (Screenshots at 1003 Page 1, 2015 Itemization line 904, and line 1001/Aggregate Setup)
				// EITQ-3095 (GA), EITQ-3093 (PA)

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

				AggregateSetup
					.Initialize()
					.btn_Cancel_Click();

				URLA_Page1
					.OpenForm_FromFormsTab()
					//.txt_SubjectProperty_County_SendKeys(MasterData.County)
					//.txt_SubjectProperty_City_SendKeys(MasterData.City)
					.txt_SubjectProperty_ZipCode_SendKeys(MasterData.Zip);
					//.ChangeSubjectProperty(MasterData.County, MasterData.City, MasterData.Zip);

				Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), @"C:\Users\hcharls\Documents\Ticket Notes\29. January 7, 2018\EITQ-3136 PA County Impounds\EITQ-3136 Test Screenshots\" + MasterData.TestID);

				RegZCD
					.OpenForm_FromFormsTab()
					.txt_FirstPaymentDate_SendKeys(MasterData.FirstPaymentDate);

				Itemization
					.OpenForm_FromFormsTab()
					.btn_ScrollDown900_Click();

				Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), @"C:\Users\hcharls\Documents\Ticket Notes\29. January 7, 2018\EITQ-3136 PA County Impounds\EITQ-3136 Test Screenshots\" + MasterData.TestID + "line 904 populated");

				Itemization
					.Initialize()
					.txt_PropertyTaxesMths_SendKeys(" ");

				Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), @"C:\Users\hcharls\Documents\Ticket Notes\29. January 7, 2018\EITQ-3136 PA County Impounds\EITQ-3136 Test Screenshots\" + MasterData.TestID + "line 904 blank");

				Itemization
					.Initialize()
					.btn_ScrollDown1100_Click()
					.btn_AggregateSetup_Click();

				AggregateSetup
					.Initialize()
					.DragWindow_AggregateSetup();

				Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), @"C:\Users\hcharls\Documents\Ticket Notes\29. January 7, 2018\EITQ-3136 PA County Impounds\EITQ-3136 Test Screenshots\" + MasterData.TestID + MasterData.TestDescription);

				#endregion EITQ-3095 Impounds (Screenshots at 1003 Pge 1, 2015 Itemization line 904, and line 1001/Aggregate Setup)
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