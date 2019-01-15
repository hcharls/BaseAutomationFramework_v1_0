using System;
using System.Collections.Generic;
using BaseAutomationFramework.PageObjects.Encompass;
using NUnit.Framework;
using BaseAutomationFramework.Tools;
using BaseAutomationFramework.DataObjects;
using System.Threading;
using System.IO;
using BaseAutomationFramework.HTML_Report;


namespace BaseAutomationFramework.Tests.Encompass.TicketTesting
{
        [TestFixture]
        public class PersonaAccessTesting : BaseTest
        {
        //private StreamWriter SW;
        //private StatusReport SR;
        //string runTime;
        //string className;
        //string pathStem;
        private string TestID = null;
        private string Username = null;
        private string Password = null;

        //[GetTestSet("Test")]
        //[TestCaseSource(typeof(GetTestData), "Screen")]
           
        [Test, TestCaseSource(typeof(BaseTest.TestData), "UserLogin")]
        public void UserLogin(IDictionary<string, string> data)
        {
            //MasterData = new objMasterData(data);
            //MasterData.TestResultPathStem = pathStem;
            //className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            //Step step = new Step();

            //step.Action = string.Format("Test: {0}", MasterData.TestID);
            //step.ExpectedResult = string.Format("");
            //step.ActualResult = string.Format("");
            //step.Status = "Pass";
            //step.Time = DateTime.Now.ToString();

            this.Username = data["Test ID"];
            this.Username = data["Username"];
            this.Password = data["Password"];

            string LoanNumber = "5472172STG";

            //string EnvironmentID = "TEBE11141905";
            string EnvironmentID = "TEBE11166948";
            //string EnvironmentID = "BE799584";

            //try
            //{

                LaunchApplication(DesktopApps.Encompass);

                Launcher.Initialize().cmb_EnvironmentID_SelectByText(EnvironmentID).btn_Login_Click();

                AttachToProcess(Processes.Encompass, 5);

                Login.Initialize().txt_Username_SendKeys(this.Username).txt_Password_SendKeys(this.Password).btn_Login_Click(); Thread.Sleep(10000);

                EncompassMain.Initialize().Resize().tab_Pipeline_Select();

            Pipeline.Initialize();  Thread.Sleep(5000);
            
            BorrowerSummary.OpenForm_FromFormsTab().NavigateToTransactionDetails();

                //Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), @"C:\Users\hcharls\Desktop\Test Screenshots\" + this.TestID);
                
                //EncompassMain.Initialize().ExitEncompass(); EncompassDialog.Initialize().btn_Yes_Click(); ComplianceAlert.Initialize().btn_Close_Click(); TestedApplication.Kill();

            //}

            //catch (Exception ex)
            //{
            //    step.ModalText = ex.ToString();
            //    step.Status = "Fail";
            //    step.ScreenShotLocation = Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format("Failure\\{0}", System.Reflection.MethodBase.GetCurrentMethod().Name));
            //    Assert.Fail(ex.ToString());
            //}
            //finally
            //{
            //    Report.addStep(step);
            //}

        }

        [TestFixtureSetUp]
        public void OnFixtureSetup()
        {
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
            //string subject = string.Format("All your tests are finished, good job!");
            //string body = string.Format("All your tests are finished, good job!");
            //EmailUtilities.Email email = new EmailUtilities.Email(subject, body, "hannah.charls@aol.com");

            //EmailUtilities.SendEmail(email);
            //Report.writeReport();
        }
    }
}