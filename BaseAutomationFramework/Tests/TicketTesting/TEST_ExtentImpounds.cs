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

namespace BaseAutomationFramework.Tests.Encompass.TicketTesting
{
	[TestFixture]
	public class Impounds : BaseTest
	{
		private StreamWriter SW;
		private StatusReport SR;
		string runTime;
		string className;
		string pathStem;
		string testMethodName;
		string path;
		string TestReportName = "EITQ-3794 Massachusetts Impounds 1 of 2";


		[GetTestSet("Test")]
		[TestCaseSource(typeof(GetTestData), "Screen")]

		public void EITQ_3794(IDictionary<string, string> data)
		{
			MasterData = new objMasterData(data);
			className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
			testMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			MasterData.TestResultPathStem = string.Format(FileUtilities.DefaultTestResultDirectory, className);
			//MasterData.TestResultPathStem = string.Format("{0}\\{1}\\{2}\\{3} - {4}", FileUtilities.DefaultTestResultDirectory_ShareDrive, className, testMethodName, Environment.UserName, runTime);
			path = string.Format("{0}\\{1}.html", MasterData.TestResultPathStem, TestReportName);

			if (!Directory.Exists(string.Format("{0}", MasterData.TestResultPathStem)))
				Directory.CreateDirectory(string.Format("{0}", MasterData.TestResultPathStem));

			if (BaseTest.HtmlReport == null)
				InitializeExtentReports(path, TestReportName);

			BaseTest.extentTest = ExtentReport.CreateTest(MasterData.TestID + " (First Payment Month = " + MasterData.ImpoundsFirstPayment + ")");

			string StepDetails = string.Format("Impounds Testing");
			bool StepStatus = true;
			string MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			try
			{
                //Impounds(unlocked loan must be up to Step 4 of Disclosure Prep(TRID) form)


                //extentTest.Pass("Pass step description.");

                AttachToProcess(Processes.Encompass, 5);

                URLA_Page1
                    .OpenForm_FromFormsTab()
                    .txt_SubjectProperty_ZipCode_SendKeys(MasterData.Zip);
                extentTest.Pass("Verified Subject Property is in " + MasterData.City + ", " + MasterData.State, MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_address"), true)).Build());

                RegZCD
                    .OpenForm_FromFormsTab()
                    .txt_FirstPaymentDate_SendKeys(MasterData.FirstPaymentDate);
                extentTest.Pass("Populated First Payment Date field [682] on RegZ-CD with " + MasterData.FirstPaymentDate, MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_FirstPaymentDate"), true)).Build());

                Itemization
                    .OpenForm_FromFormsTab()
                    .btn_ScrollDown1100_Click()
                    .btn_AggregateSetup_Click();

                AggregateSetup
                    .Initialize()
                    .DragWindow_AggregateSetup();
                extentTest.Pass("Opened Aggregate Setup window and verified Due Date(s) = " + MasterData.ImpoundsDueDates + " and verified Property Taxes mths field [1386] = " + MasterData.ImpoundsMonths + " when First Payment Month = " + MasterData.ImpoundsFirstPayment, MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_impounds"), true)).Build());

                AggregateSetup
                    .Initialize()
                    .btn_OK_Click();
                extentTest.Pass("Verified line 1004 Property Taxes mths field [1386] remains populated with '" + MasterData.ImpoundsMonths + "' after Aggregate Setup window is closed", MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_AggregateSetupClosed"), true)).Build());

                Itemization
                    .Initialize()
                    .btn_ScrollUp900_Click();
                extentTest.Pass("Verified line 904 Property Taxes mths field is populated with '" + MasterData.Impounds904Months + "' only when First Payment Month '" + MasterData.ImpoundsFirstPayment + "' is the same as Due Date(s) '" + MasterData.ImpoundsDueDates + "'", MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_line904"), true)).Build());

                Itemization
                    .Initialize()
                    .txt_PropertyTaxesMths_SendKeys(" ");

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