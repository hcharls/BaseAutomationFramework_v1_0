using AventStack.ExtentReports;
using BaseAutomationFramework.Tools;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseAutomationFramework.Tests.OtherTests

{
	public class ExtentTestSample : BaseTest
	{
		string className;
		string testMethodName;
		string path;
		string TestReportName = "Sample Test";
		string runTime;

		[TestFixtureSetUp]
		public void OnFixtureSetup()
		{
			runTime = CreateRuntimeString();
			BaseTest.ExtentReport = new ExtentReports();
		}

		[SetUp]
		public void BeforeEachTest()
		{

		}

		[GetTestSet("Test")]
		[TestCaseSource(typeof(GetTestData), "Screen")]
		public void MyTestNameHere(IDictionary<string, string> data)
		{
			MasterData = new DataObjects.objMasterData(data);
			if (BaseTest.HtmlReport == null)
			{
				className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
				testMethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
				MasterData.TestResultPathStem = string.Format("{0}\\{1}\\{2}\\{3} - {4}", FileUtilities.DefaultTestResultDirectory_ShareDrive, className, testMethodName, Environment.UserName, runTime);
				path = string.Format("{0}\\{1}.html", MasterData.TestResultPathStem, TestReportName);

				Directory.CreateDirectory(string.Format("{0}", MasterData.TestResultPathStem));
				Console.WriteLine(path);
				InitializeExtentReports(path, TestReportName);
			}
			BaseTest.extentTest = ExtentReport.CreateTest(MasterData.TestID + " - " + MasterData.TestDescription);

			//extentTest.Pass("Pass step description.");
			//extentTest.AddScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format("Failure\\{0}", testMethodName), true));
			DoAStep();
		}

		private void ExtentFailStep(Exception ex, string StepDetails, string Filename)
		{
			string ssLocation = Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format("Failure\\{0}", Filename), true);
			extentTest.Fail(StepDetails);
			extentTest.AddScreenCaptureFromPath(ssLocation);
			extentTest.Error(ex.ToString());
			Assert.Fail(ex.ToString());
		}
		private void DoAStep()
		{
			string StepDetails = string.Format("Filling some page.");
			bool StepStatus = true;
			string MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			try
			{

				throw new DivideByZeroException("Dummy Exception");



			}
			catch (Exception ex)
			{
				StepStatus = false;
				ExtentFailStep(ex, StepDetails, MethodName);
			}
			finally
			{
				if (StepStatus) extentTest.Pass(StepDetails);
			}
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
		}
	}
}
