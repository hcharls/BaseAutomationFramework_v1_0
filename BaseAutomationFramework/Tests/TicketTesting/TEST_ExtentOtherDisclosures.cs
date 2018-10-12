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
	public class OtherDisclosures : BaseTest
	{
		private StreamWriter SW;
		private StatusReport SR;
		string runTime;
		string className;
		string pathStem;
		string testMethodName;
		string path;
		string TestReportName = "EITQ-3708: Set Other Disclosures [CD5.X6] earlier in the process";


		[GetTestSet("Test")]
		[TestCaseSource(typeof(GetTestData), "Screen")]

		public void EITQ_3708_Other_Disclosures(IDictionary<string, string> data)
		{
			MasterData = new objMasterData(data);
			className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
			testMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			//MasterData.TestResultPathStem = string.Format(FileUtilities.DefaultTestResultDirectory, className);
			MasterData.TestResultPathStem = string.Format("{0}\\{1}\\{2}\\{3} - {4}", FileUtilities.DefaultTestResultDirectory_ShareDrive, className, testMethodName, Environment.UserName, runTime);
            //MasterData.TestResultPathStem = string.Format("{0}\\{1}\\{2} - {3}", FileUtilities.DefaultTestResultDirectory_ShareDrive, className, Environment.UserName, runTime);
            path = string.Format("{0}\\{1}.html", MasterData.TestResultPathStem, TestReportName);

			if (!Directory.Exists(string.Format("{0}", MasterData.TestResultPathStem)))
				Directory.CreateDirectory(string.Format("{0}", MasterData.TestResultPathStem));

			if (BaseTest.HtmlReport == null)
				InitializeExtentReports(path, TestReportName);

			BaseTest.extentTest = ExtentReport.CreateTest(MasterData.TestID + " Property State Trigger");

			string StepDetails = string.Format("Property State Trigger");
			bool StepStatus = true;
			string MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			try
			{
                AttachToProcess(Processes.Encompass, 5);

                //bool expectedFirstBoxChecked = data["FirstBoxChecked"].ToLower() == "true" ? true : false;
                //bool expectedSecondBoxChecked = data["SecondBoxChecked"].ToLower() == "true" ? true : false;

                //if (data["FirstBoxChecked"].ToLower() == "true")               
                //    expectedFirstBoxChecked = true;
                //else
                //    expectedFirstBoxChecked = false;

                //bool actualFirstBoxChecked;
                //bool actualSecondBoxChecked;

                //Assert.AreEqual(expectedMessage, actualMessage, "Test Failed!!!");


                //Subject Property State trigger
                ClosingDisclosurePage5
                    .Initialize()
                    .chk_StateLawMayProtect_Check()
                    .chk_StateLawDoesNotProtect_Check();
				extentTest.Pass("Other Disclosures fields are not populated", MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_FieldsBlank"), true)).Build());

				URLA_Page1
					.OpenForm_FromFormsTab()
					.txt_SubjectProperty_ZipCode_SendKeys(MasterData.Zip);
				extentTest.Pass("Changed Subject Property State field [14] to " + MasterData.State, MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_StateChange"), true)).Build());

                ClosingDisclosurePage5
                    .OpenForm_FromFormsTab(); Thread.Sleep(2000);
					//.GetFirstCheckBoxState(out actualFirstBoxChecked)
     //               .GetSecondCheckBoxState(out actualSecondBoxChecked);
                extentTest.Pass("Verified Other Disclosures field [CD5.X6] is set to '" + MasterData.TestDescription + "' when Subject Property State field [14] is changed to " + MasterData.State, MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_FieldSet"), true)).Build());


                ////Document Date field trigger
                //RegZCD
                //    .OpenForm_FromFormsTab()
                //    .txt_DocumentDate_SendKeys(" ");

                //URLA_Page1
                //    .OpenForm_FromFormsTab()
                //    .txt_SubjectProperty_ZipCode_SendKeys(MasterData.Zip);
                //extentTest.Pass("Subject Property State field [14] = " + MasterData.State, MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_State"), true)).Build());

                //ClosingDisclosurePage5
                //    .Initialize()
                //    .chk_StateLawMayProtect_Check(false)
                //    .chk_StateLawDoesNotProtect_Check(false);
                //extentTest.Pass("Other Disclosures fields are not populated", MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_FieldsBlank"), true)).Build());

                //RegZCD
                //    .OpenForm_FromFormsTab()
                //    .txt_DocumentDate_SendKeys("09/21/18");
                //extentTest.Pass("Changed Document Date field [L770]", MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_DocumentDate"), true)).Build());

                //ClosingDisclosurePage5
                //    .OpenForm_FromFormsTab()
                //    .GetFirstCheckBoxState(out actualFirstBoxChecked)
                //    .GetSecondCheckBoxState(out actualSecondBoxChecked);
                //extentTest.Pass("Verified Other Disclosures field [CD5.X6] is set to '" + MasterData.TestDescription + "' when Subject Property State field [14] = " + MasterData.State + ", and Document Date field [L770] is changed", MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.TestID + "_FieldSet"), true)).Build());

            }
            catch (Exception ex)
			{
				StepStatus = false;
				BaseTest.ExtentFailStep(ex, StepDetails, "Test Failed.");				
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