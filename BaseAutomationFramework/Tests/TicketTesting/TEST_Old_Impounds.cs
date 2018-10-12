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
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.Tests.Encompass.TicketTesting
{
	[TestFixture]
	public class OldImpounds : BaseTest
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

			step.Action = string.Format("Test: {0}", MasterData.TestDescription);
			step.ExpectedResult = string.Format("");
			step.ActualResult = string.Format("");
			step.Status = "Pass";
			step.Time = DateTime.Now.ToString();

			try
			{

				AttachToProcess(Processes.Encompass, 5);

                //Impounds (unlocked loan must be up to Step 4 of Disclosure Prep (TRID) form)

                URLA_Page1
                    .OpenForm_FromFormsTab()            
                    //.txt_SubjectProperty_City_SendKeys(MasterData.City)
                    //.txt_SubjectProperty_County_SendKeys(MasterData.County)
                    .txt_SubjectProperty_ZipCode_SendKeys(MasterData.Zip);
                //Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.ESCAPE); Thread.Sleep(3000); //when Select a City window needs to be bypassed (must populate City, State, County, AND Zip Code beforehand)
                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN); Thread.Sleep(3000); //when zip code or top entry of Select a City window will populate City/State/County (City, State, and County can be commented out)

                RegZCD
                    .OpenForm_FromFormsTab()
                    .txt_FirstPaymentDate_SendKeys(MasterData.FirstPaymentDate);
                
                Itemization
                    .OpenForm_FromFormsTab()
                    .btn_ScrollDown1100_Click()
                    .btn_AggregateSetup_Click();

                AggregateSetup
                    .Initialize()
                    .DragWindow_AggregateSetup();
                Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), @"C:\Users\hcharls\Desktop\Test Screenshots\" + MasterData.TestID + " " + MasterData.State + " - Due date(s) " + MasterData.ImpoundsDueDates + " and field [1386] is set to " + MasterData.ImpoundsMonths + " when first payment date is " + MasterData.FirstPaymentDate);

                Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);Thread.Sleep(2000);
                Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), @"C:\Users\hcharls\Desktop\Test Screenshots\" + MasterData.TestID + " " + MasterData.State + " - Field [1386] remains populated with " + MasterData.ImpoundsMonths + " after aggregate setup is closed");

                Itemization
                    .Initialize()
                    .btn_ScrollUp900_Click();
                Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), @"C:\Users\hcharls\Desktop\Test Screenshots\" + MasterData.TestID + " " + MasterData.State + " - Line 904 is populated with " + MasterData.Impounds904Months + " only when first payment month " + MasterData.ImpoundsFirstPayment + " is in due date(s) " + MasterData.ImpoundsDueDates);

                Itemization
                    .Initialize()
                    .txt_PropertyTaxesMths_SendKeys(" ");


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