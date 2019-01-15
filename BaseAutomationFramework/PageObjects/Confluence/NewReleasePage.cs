using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace BaseAutomationFramework.PageObjects.Confluence
    
{
	public class NewReleasePage : BaseSeleniumPage
	{
		public NewReleasePage()
		{
			WaitForPageLoadToComplete(300);
			WaitForAjax();
			PageFactory.InitElements(webDriver, this);
		}
		public static NewReleasePage Initialize()
		{
			return new NewReleasePage();
		}

        #region Text Boxes

        private By txt_Title = By.XPath("//input[@id='content-title']");
        //
        public NewReleasePage txt_Title_SendKeys(string input)
        {
            wElement = txt_Title.GetWebElement();
            wElement.Click();
            wElement.SendKeys(Keys.Control + "a");
            wElement.SendKeys(input);

            return this;
        }

        #endregion

        #region Macros

        private By mcr_TicketReleaseListIssueCount = By.CssSelector("body.mce-content-body.aui-theme-default.mceContentBody.wiki-content.fullsize.notranslate.page-edit.adg3-editor:nth-child(2) div.contentLayout2 div.columnLayout.single:nth-child(1) div.cell.normal div.innerCell table.relative-table.wrapped.confluenceTable:nth-child(2) th.highlight-blue.confluenceTh div.content-wrapper h2:nth-child(1) strong:nth-child(3) > img.editor-inline-macro");
        private By mcr_TicketReleaseList = By.CssSelector("body.mce-content-body.aui-theme-default.mceContentBody.wiki-content.fullsize.notranslate.page-edit.adg3-editor:nth-child(2) div.contentLayout2 div.columnLayout.single:nth-child(1) div.cell.normal div.innerCell p:nth-child(4) strong:nth-child(1) > img.editor-inline-macro");
        private By mcr_JIRAChart = By.CssSelector("body.mce-content-body.aui-theme-default.mceContentBody.wiki-content.fullsize.notranslate.page-edit.adg3-editor:nth-child(2) div.contentLayout2 div.columnLayout.two-right-sidebar:nth-child(5) div.cell.aside:nth-child(2) div.innerCell p:nth-child(1) u:nth-child(1) strong:nth-child(1) > img.editor-inline-macro");
        private By mcr_AllTicketsIssueCount = By.CssSelector("body.mce-content-body.aui-theme-default.mceContentBody.wiki-content.fullsize.notranslate.page-edit.adg3-editor:nth-child(2) div.contentLayout2 div.columnLayout.single:nth-child(7) div.cell.normal div.innerCell table.relative-table.wrapped.confluenceTable:nth-child(2) th.highlight-red.confluenceTh div.content-wrapper h2:nth-child(2) strong:nth-child(2) > img.editor-inline-macro");
        private By mcr_AllTickets = By.CssSelector("body.mce-content-body.aui-theme-default.mceContentBody.wiki-content.fullsize.notranslate.page-edit.adg3-editor:nth-child(2) div.contentLayout2 div.columnLayout.single:nth-child(7) div.cell.normal div.innerCell p:nth-child(3) > img.editor-inline-macro");

        //
        public NewReleasePage TicketReleaseListIssueCount(string input)
        {
            webDriver.FindElement(mcr_TicketReleaseListIssueCount).Click();
            btn_Edit_Click();
            txt_Project_SendKeys("project = 'EITQ' AND fixVersion in ('" + input + "')").btn_Search_Click().btn_Insert_Click();

            return this;
        }
        public NewReleasePage TicketReleaseList(string input)
        {
            webDriver.FindElement(mcr_TicketReleaseList).Click();
            btn_Edit_Click();
            txt_Project_SendKeys("project = 'EITQ' AND fixVersion in ('" + input + "')").btn_Search_Click().btn_Insert_Click();

            return this;
        }
        public NewReleasePage JIRAChart(string input)
        {
            webDriver.FindElement(mcr_JIRAChart).Click();
            btn_Edit_Click();
            txt_Project_SendKeys("project = 'EITQ' AND fixVersion in ('" + input + "')").btn_Search_Click().btn_Insert_Click();

            return this;
        }
        public NewReleasePage AllTicketsIssueCount(string input)
        {
            webDriver.FindElement(mcr_AllTicketsIssueCount).Click();
            btn_Edit_Click();
            txt_Project_SendKeys("project = 'EITQ' AND Sprint =  " + input).btn_Search_Click().btn_Insert_Click();

            return this;
        }
        public NewReleasePage AllTickets(string input)
        {
            webDriver.FindElement(mcr_AllTickets).Click();
            btn_Edit_Click();
            txt_Project_SendKeys("project = 'EITQ' AND Sprint =  " + input).btn_Search_Click().btn_Insert_Click();

            return this;
        }


        #endregion

        #region Insert JIRA Issue/Filter

        private By txt_Project = By.CssSelector("body.theme-default.dashboard.aui-layout.aui-theme-default.synchrony-active.contenteditor.edit.adg3-editor:nth-child(2) div.aui-popup.aui-dialog:nth-child(9) div.dialog-components div.dialog-page-body div.dialog-panel-body:nth-child(1) div.jira-search-form form.aui fieldset.inline div.search-input.one-server > input.text.one-server.long-field");
        private By btn_Search = By.XPath("//button[@title='Search']");
        private By btn_Insert = By.XPath("//button[@class='button-panel-button insert-issue-button']");

        //
        public NewReleasePage txt_Project_SendKeys(string input)
        {
            wElement = txt_Project.GetWebElement();
            wElement.Click();
            wElement.SendKeys(Keys.Control + "a");
            wElement.SendKeys(input);

            return this;
        }
        public NewReleasePage btn_Search_Click()
        {
            webDriver.FindElement(btn_Search).Click();

            return new NewReleasePage();
        }
        public NewReleasePage btn_Insert_Click()
        {
            webDriver.FindElement(btn_Insert).Click();

            return new NewReleasePage();
        }

        #endregion

        #region Buttons

        private By btn_Edit = By.XPath("//span[@class='panel-button-text'][contains(text(),'Edit')]");
        private By btn_Publish = By.XPath("//button[@id='rte-button-publish']");
        //
        
        public NewReleasePage btn_Edit_Click()
        {
            webDriver.FindElement(btn_Edit).Click();

            return new NewReleasePage();
        }
        public void btn_Publish_Click()
        {
            webDriver.FindElement(btn_Publish).Click();
        }

        #endregion
    }
}


