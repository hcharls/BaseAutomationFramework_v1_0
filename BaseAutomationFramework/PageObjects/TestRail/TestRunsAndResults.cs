using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BaseAutomationFramework.PageObjects.TestRail

{
	public class TestRunsAndResults : BaseSeleniumPage
	{
		public TestRunsAndResults()
		{
			WaitForPageLoadToComplete(300);
			WaitForAjax();
			PageFactory.InitElements(webDriver, this);
		}
		public static TestRunsAndResults Initialize()
		{
			return new TestRunsAndResults();
		}

        private By btn_CloseRun = By.XPath("//div[@id='content-header']//a[@class='link-tooltip']");
        private By btn_Yes = By.XPath("//a[@class='button button-ok button-left button-positive dialog-action-default'][contains(text(),'Yes')]");


        public TestRunsAndResults OpenTestRun_Click(string input)
        {
            By TestRun = By.XPath("//a[contains(text(),'" + (input) + "')]");
            webDriver.FindElement(TestRun).Click();

            return new TestRunsAndResults();
        }

        public TestRunsAndResults btn_CloseRun_Click()
        {
            webDriver.FindElement(btn_CloseRun).Click();

            return new TestRunsAndResults();
        }
        public void btn_Yes_Click()
        {
            webDriver.FindElement(btn_Yes).Click();

        }

    }
}


