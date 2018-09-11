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
	public class VA_AppraisalFees : BaseTest
	{
		private StreamWriter SW;
		private StatusReport SR;
		string runTime;
		string className;
		string pathStem;
		string testMethodName;
		string path;
		string TestReportName = "EITQ-3276 Maryland Tax Impounds Primary Retest";


		[GetTestSet("Test")]
		[TestCaseSource(typeof(GetTestData), "Screen")]

		public void EITQ_3624_VA_Appraisal_Fees_Updates (IDictionary<string, string> data)
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

			//BaseTest.extentTest = ExtentReport.CreateTest(MasterData.TestID + " (First Payment Month = " + MasterData.ImpoundsFirstPayment + ")");

			string StepDetails = string.Format("Impounds Testing");
			bool StepStatus = true;
			string MethodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
			try
			{
				//extentTest.Pass("Pass step description.");

				//#region VA Appraisal Fees: 2015 Itemization (loan has already clicked Generate Estimated Closing Dates and Standard Fees)

				//URLA_Page1
				//	.OpenForm_FromFormsTab()
				//	.txt_NoUnits_SendKeys(MasterData.NoUnits)
				//	.txt_SubjectProperty_ZipCode_SendKeys(MasterData.Zip);
				//extentTest.Pass("Set VA loan to " + MasterData.NoUnits + " " + MasterData.PropertyType + " unit(s) in " + MasterData.County + " County, " + MasterData.State, MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.County + " " + MasterData.NoUnits + " " + MasterData.PropertyType + " - 1003Page1"), true)).Build());
    //            Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), @"C:\Users\hcharls\Desktop\Test Screenshots\" + MasterData.County + " County, " + MasterData.NoUnits + " " + MasterData.PropertyType + " unit(s) - 1003 Page 1");

				//BorrowerSummary
				//	.OpenForm_FromFormsTab()
				//	.cmb_PropertyType_SendKeys(MasterData.TransPropertyType);
				//extentTest.Pass("Set Property Type field [1041] to '" + MasterData.PropertyType + "'", MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.County + " " + MasterData.NoUnits + " " + MasterData.PropertyType + " - BorSum"), true)).Build());
    //            Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), @"C:\Users\hcharls\Desktop\Test Screenshots\" + MasterData.County + " County, " + MasterData.NoUnits + " " + MasterData.PropertyType + " unit(s) - Borrower Summary");

				//DisclosurePrep
				//	.OpenForm_FromFormsTab()
				//	.btn_GenerateEstimatedClosingDatesandStandardFees_Click();

				//Itemization
				//	.OpenForm_FromFormsTab()
				//	.btn_ScrollDownToAppraisal_Click();
    //            extentTest.Pass("Verified line field [641] is populated with " + MasterData.VAAppraisalFee + " for " + MasterData.NoUnits + " " + MasterData.PropertyType + " unit(s) in " + MasterData.County + " County, " + MasterData.State, MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.County + " " + MasterData.NoUnits + " " + MasterData.PropertyType + " - 2015Itemization"), true)).Build());
    //            Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), @"C:\Users\hcharls\Desktop\Test Screenshots\" + MasterData.County + " County, " + MasterData.NoUnits + " " + MasterData.PropertyType + " unit(s) - 2015 Itemization");

    //            #endregion


    //            #region VA Appraisal Fees: Appraisal Order and Tracking (loan must have Intent to Proceed)

    //            URLA_Page1
    //                .OpenForm_FromFormsTab()
    //                .txt_SubjectProperty_ZipCode_SendKeys(MasterData.Zip);
    //            extentTest.Pass("Subject Property on VA loan is in " + MasterData.County + " County, " + MasterData.State, MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.County + " " + MasterData.NoUnits + " " + MasterData.PropertyType + " - 1003Page1"), true)).Build());
    //            Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), @"C:\Users\hcharls\Desktop\Test Screenshots\" + MasterData.County + " County, " + MasterData.NoUnits + " unit(s) - 1003 Page 1");

    //            AppraisalOrderAndTracking
    //                .OpenForm_FromFormsTab()
    //                .cmb_PropertyType_SendKeys(MasterData.PropertyType)
    //                .txt_NoUnits_SendKeys(MasterData.NoUnits)
    //                .chk_EnterPaymentInfoForBorrower_Check(false)
    //                .chk_EnterPaymentInfoForBorrower_Check(true)
    //                .DragPaymentProcessingWindow();
    //            extentTest.Pass("Verify fee is " + MasterData.VAAppraisalFee + " for " + MasterData.NoUnits + " " + MasterData.PropertyType + " unit(s) in " + MasterData.County + " County, " + MasterData.State, MediaEntityBuilder.CreateScreenCaptureFromPath(Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format(MasterData.County + " " + MasterData.NoUnits + " " + MasterData.PropertyType + " - 2015Itemization"), true)).Build());
    //            Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), @"C:\Users\hcharls\Desktop\Test Screenshots\" + MasterData.County + " County, " + MasterData.NoUnits + " " + MasterData.PropertyType + " unit(s) - PaymentProcessing");

    //            PaymentProcessing
    //                .Initialize()
    //                .btn_Close_Click();

    //            #endregion

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