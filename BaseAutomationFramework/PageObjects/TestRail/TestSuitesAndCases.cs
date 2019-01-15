using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BaseAutomationFramework.PageObjects.TestRail

{
	public class TestSuitesAndCases : BaseSeleniumPage
	{
		public TestSuitesAndCases()
		{
			WaitForPageLoadToComplete(300);
			WaitForAjax();
			PageFactory.InitElements(webDriver, this);
		}
		public static TestSuitesAndCases Initialize()
		{
			return new TestSuitesAndCases();
		}

        private By tab_TestSuitesAndCases = By.XPath("//a[contains(text(),'Test Suites & Cases')]");
        private By btn_AddSection = By.XPath("//a[@id='addSection']");
        private By btn_AddInitialSection = By.XPath("//a[@id='addSectionInline']");
        private By btn_AddCase = By.XPath("//span[contains(text(),'Add Case')]");
        private By btn_RunTest = By.XPath("//a[@class='toolbar-button content-header-button button-responsive button-start']");
        private By btn_AddTestSuite = By.XPath("//span[contains(text(),'Add Test Suite')]");


        //
        public TestSuitesAndCases tab_TestSuitesAndCases_Click()
        {
            webDriver.FindElement(tab_TestSuitesAndCases).Click();
            return new TestSuitesAndCases();
        }
        public TestSuitesAndCases SelectCurrentTestSuite_Click(string input)
        {
            By currentTestSuite = By.XPath("//a[contains(text(),'" + (input) + "')]");
            webDriver.FindElement(currentTestSuite).Click();

            return new TestSuitesAndCases();
        }

        public void btn_AddSection_Click()
        {
            webDriver.FindElement(btn_AddSection).Click();

        }
        public void btn_AddInitialSection_Click()
        {
            webDriver.FindElement(btn_AddInitialSection).Click();

        }

        public void btn_AddCase_Click()
		{
            webDriver.FindElement(btn_AddCase).Click();

		}
        public void btn_RunTest_Click()
        {
            webDriver.FindElement(btn_RunTest).Click();

        }
        public void btn_AddTestSuite_Click()
        {
            webDriver.FindElement(btn_AddTestSuite).Click();

        }


    }
}


