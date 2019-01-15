using System;
using System.Collections.Generic;
using BaseAutomationFramework.PageObjects.Encompass;
using NUnit.Framework;
using BaseAutomationFramework.Tools;
using BaseAutomationFramework.DataObjects;
using System.IO;
using BaseAutomationFramework.HTML_Report;
using TestStack.White.InputDevices;
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.Tests.Encompass.TicketTesting
{
	[TestFixture]
	public class Old_VA_Appraisal : BaseTest
	{
		private StreamWriter SW;
		private StatusReport SR;
		string runTime;
		string className;
		string pathStem;

		[GetTestSet("Test")]
		[TestCaseSource(typeof(GetTestData), "Screen")]
		public void TicketTesting(IDictionary<string, string> data)
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

                //#region VA Appraisals: Appraisal Order and Tracking (VA loan must have Intent to Proceed)

                ////TransmittalSummary
                ////   .OpenForm_FromFormsTab()
                ////   .cmb_PropertyType_SendKeys(MasterData.TransPropertyType);

                //AppraisalOrderAndTracking
                //    .Initialize()
                //    .cmb_PropertyType_SendKeys(MasterData.PropertyType)
                //    .txt_NoUnits_SendKeys(MasterData.NoUnits)
                //    .chk_EnterPaymentInfoForBorrower_("Uncheck")
                //    .chk_EnterPaymentInfoForBorrower_("Check")
                //    .DragPaymentProcessingWindow();

                //Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), @"C:\Users\hcharls\Desktop\Test Screenshots\" + MasterData.TestID + " Payment Processing");

                //PaymentProcessing
                //    .Initialize()
                //    .btn_Close_Click();

                //#endregion


                #region Appraisal Fees: 2015 Itemization (loan has already clicked Generate Estimated Closing Dates and Standard Fees)

                //FeeDetails804.Initialize().btn_Close_Click();

                //URLA_Page1
                //    .OpenForm_FromFormsTab()
                //    .txt_NoUnits_SendKeys(MasterData.NoUnits);

                //BorrowerSummary
                //    .OpenForm_FromFormsTab()
                //    .cmb_PropertyType_SendKeys(MasterData.PropertyType);

                //TransmittalSummary
                //    .OpenForm_FromFormsTab()
                //    .cmb_PropertyType_SendKeys(MasterData.TransPropertyType);

                //DisclosurePrep
                //    .OpenForm_FromFormsTab()
                //    .btn_GenerateEstimatedClosingDatesandStandardFees_Click();

                //Itemization
                //    .OpenForm_FromFormsTab()
                //    .btn_ScrollDownToAppraisal_Click();

                //FeeDetails804.OpenFromItemization().DragWindow_FeeDetails804();

                //Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), @"C:\Users\hcharls\Desktop\Test Screenshots\" + MasterData.TestID + " 2015 Itemization BRW = Yes");


                #endregion

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