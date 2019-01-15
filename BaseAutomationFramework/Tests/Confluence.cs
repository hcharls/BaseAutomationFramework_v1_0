using System;
using System.Collections.Generic;
using NUnit.Framework;
using BaseAutomationFramework.PageObjects;
using BaseAutomationFramework.Tests;
using BaseAutomationFramework.PageObjects.Confluence;

namespace BaseAutomationFramework.Confluence
{
    [TestFixture]
    public class ReleasePage : BaseTest
    {
        
        [Test]
        public void CreatNewReleasePage()
        {

            string Sprint = "Sprint r.2018.12.25";
            string FixVersion = "r.2018.12.21";
            string SprintNumber = "253";
            

            BaseSeleniumPage.CreateDriver(BaseSeleniumPage.WebDrivers.Chrome); BaseSeleniumPage.NavigateToURL(@"https://paramountequity.atlassian.net/wiki/spaces/QA/pages/96202873/QA+Release+Checklists");

            AtlassianLogin.Initialize().txt_Username_SendKeys("hcharls@paramountequity.com").btn_Continue_Click().txt_Password_SendKeys("hlotmt2GA").btn_LogIn_Click();

            QAReleaseChecklists.Initialize().btn_CreateNewReleasePage_Click();

            NewReleasePage.Initialize()
                .txt_Title_SendKeys(Sprint)
                .TicketReleaseListIssueCount(FixVersion)
                .TicketReleaseList(FixVersion)
                .JIRAChart(FixVersion)
                .AllTicketsIssueCount(SprintNumber)
                .AllTickets(SprintNumber)
                .btn_Publish_Click();

            BaseSeleniumPage.CloseDriver();
            

        }
    }
}