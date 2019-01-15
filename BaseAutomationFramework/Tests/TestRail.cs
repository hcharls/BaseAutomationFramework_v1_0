using System;
using System.Collections.Generic;
using NUnit.Framework;
using BaseAutomationFramework.Tools;
using BaseAutomationFramework.DataObjects;
using System.IO;
using BaseAutomationFramework.HTML_Report;
using BaseAutomationFramework.PageObjects;
using BaseAutomationFramework.PageObjects.TestRail;
using BaseAutomationFramework.Tests;

namespace BaseAutomationFramework.TestRail
{
    [TestFixture]
    public class _0_CreateTestSuite : BaseTest
    {
        private string Sprint = null;
        private string IssueKey = null;
        private string Summary = null;
        private string QA = null;
        private string AcceptanceCriteria = null;


        [Test, TestCaseSource(typeof(BaseTest.TestData), "SprintTickets")]
        public void TestSuite(IDictionary<string, string> data)
        {

            this.Sprint = data["Sprint"];
            this.IssueKey = data["Issue key"];
            this.Summary = data["Summary"];
            this.QA = data["QA"];
            this.AcceptanceCriteria = data["Acceptance Criteria"];


            BaseSeleniumPage.CreateDriver(BaseSeleniumPage.WebDrivers.Chrome); BaseSeleniumPage.NavigateToURL(@"https://paramountequity.testrail.com/index.php?/suites/overview/27");

            TestRailLogin.Initialize().txt_EmailAddress_SendKeys("hcharls@loanpal.com").txt_Password_SendKeys("P@ramount1").btn_Login_Click();

            TestSuitesAndCases.Initialize().btn_AddTestSuite_Click();

            AddTestSuite.Initialize().txt_Name_SendKeys(this.Sprint).btn_AddTestSuite_Click();

            AddSection.Initialize().txt_Name_SendKeys("test").btn_AddSection_Click();

            BaseSeleniumPage.CloseDriver();

        }
    }


    [TestFixture]
    public class _1_CreateSections : BaseTest
    {
        private string Sprint = null;
        private string IssueKey = null;
        private string Summary = null;
        private string QA = null;
        private string AcceptanceCriteria = null;


        [Test, TestCaseSource(typeof(BaseTest.TestData), "SprintTickets")]
        public void Sections(IDictionary<string, string> data)
        {

            this.Sprint = data["Sprint"];
            this.IssueKey = data["Issue key"];
            this.Summary = data["Summary"];
            this.QA = data["QA"];
            this.AcceptanceCriteria = data["Acceptance Criteria"];
            


            BaseSeleniumPage.CreateDriver(BaseSeleniumPage.WebDrivers.Chrome); BaseSeleniumPage.NavigateToURL(@"https://paramountequity.testrail.com/index.php?/suites/overview/27");

            TestRailLogin.Initialize().txt_EmailAddress_SendKeys("hcharls@loanpal.com").txt_Password_SendKeys("P@ramount1").btn_Login_Click();

            TestSuitesAndCases.Initialize().SelectCurrentTestSuite_Click(this.Sprint).btn_AddSection_Click();

            AddSection.Initialize().txt_Name_SendKeys(this.IssueKey + ": " + this.Summary).btn_AddSection_Click();

            BaseSeleniumPage.CloseDriver();

        }
    }

    [TestFixture]
    public class _2_CreateTestCases : BaseTest
    {
        private StreamWriter SW;
        private StatusReport SR;
        string runTime;
        string className;
        string pathStem;

        [GetTestSet("Test")]
        [TestCaseSource(typeof(GetTestData), "Screen")]
        public void TestCases(IDictionary<string, string> data)
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
                BaseSeleniumPage.CreateDriver(BaseSeleniumPage.WebDrivers.Chrome); BaseSeleniumPage.NavigateToURL(@"https://paramountequity.testrail.com/index.php?/suites/overview/27");

                TestRailLogin.Initialize().txt_EmailAddress_SendKeys("hcharls@loanpal.com").txt_Password_SendKeys("P@ramount1").btn_Login_Click();

                TestSuitesAndCases.Initialize().SelectCurrentTestSuite_Click(MasterData.Sprint).btn_AddCase_Click();

                AddTestCase.Initialize()
                    .txt_Title_SendKeys(MasterData.TestCaseTitle + " " + MasterData.Examples)
                    .cmb_Section_SendKeys(MasterData.IssueKey)
                    .txt_References_SendKeys(MasterData.IssueKey)
                    .cmb_QA_SendKeys(MasterData.QA)
                    .cmb_PO_SendKeys(MasterData.PO)
                    .cmb_DevConfig_SendKeys(MasterData.Dev)
                    .txt_Given_SendKeys(MasterData.Given)
                    .txt_When_SendKeys(MasterData.When)
                    .txt_Then_SendKeys(MasterData.Then)
                    .txt_Examples_SendKeys(MasterData.ExampleHeader, MasterData.Examples)
                    .btn_AddTestCase_Click();

                BaseSeleniumPage.CloseDriver();

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

    [TestFixture]
    public class _3_CreateTestRuns : BaseTest
    {
        private string Sprint = null;
        private string IssueKey = null;
        private string Summary = null;
        private string QA = null;
        private string AcceptanceCriteria = null;
       

        [Test, TestCaseSource(typeof(BaseTest.TestData), "SprintTickets")]
        public void TestRuns(IDictionary<string, string> data)
        {

            this.Sprint = data["Sprint"];
            this.IssueKey = data["Issue key"];
            this.Summary = data["Summary"];
            this.QA = data["QA"];
            this.AcceptanceCriteria = data["Acceptance Criteria"];
        

            BaseSeleniumPage.CreateDriver(BaseSeleniumPage.WebDrivers.Chrome); BaseSeleniumPage.NavigateToURL(@"https://paramountequity.testrail.com/index.php?/suites/overview/27");

            TestRailLogin.Initialize().txt_EmailAddress_SendKeys("hcharls@loanpal.com").txt_Password_SendKeys("P@ramount1").btn_Login_Click();

            TestSuitesAndCases.Initialize().SelectCurrentTestSuite_Click(this.Sprint).btn_RunTest_Click();

            AddTestRun.Initialize().txt_Name_SendKeys(this.IssueKey + ": " + this.Summary).cmb_Milestone_SendKeys(this.Sprint).cmb_AssignTo_SendKeys(this.QA).rdb_SelectSpecific_Click().txt_ChangeSelection_Click();

            SelectCases.Initialize().txt_References_Click().cmb_ReferencesContains_SendKeys().txt_ReferencesText_SendKeys(this.IssueKey).btn_SetSelection_Click().btn_OK_Click();

            AddTestRun.Initialize().btn_AddTestRun_Click();

            BaseSeleniumPage.CloseDriver();

        }
    }

    [TestFixture]
    public class _4_CloseTestRuns : BaseTest
    {
        private string Sprint = null;
        private string IssueKey = null;
        private string Summary = null;
        private string QA = null;
        private string AcceptanceCriteria = null;


        [Test, TestCaseSource(typeof(BaseTest.TestData), "SprintTickets")]
        public void TestRuns(IDictionary<string, string> data)
        {

            this.Sprint = data["Sprint"];
            this.IssueKey = data["Issue key"];
            this.Summary = data["Summary"];
            this.QA = data["QA"];
            this.AcceptanceCriteria = data["Acceptance Criteria"];


            BaseSeleniumPage.CreateDriver(BaseSeleniumPage.WebDrivers.Chrome); BaseSeleniumPage.NavigateToURL(@"https://paramountequity.testrail.com/index.php?/runs/overview/27");

            TestRailLogin.Initialize().txt_EmailAddress_SendKeys("hcharls@loanpal.com").txt_Password_SendKeys("P@ramount1").btn_Login_Click();

            TestRunsAndResults.Initialize().OpenTestRun_Click(this.IssueKey).btn_CloseRun_Click().btn_Yes_Click();

            BaseSeleniumPage.CloseDriver();

        }
    }
}