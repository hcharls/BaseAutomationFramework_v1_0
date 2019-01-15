using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BaseAutomationFramework.PageObjects.TestRail
{
	public class AddTestSuite : BaseSeleniumPage
	{
		public AddTestSuite()
		{
			WaitForPageLoadToComplete(300);
			WaitForAjax();
			PageFactory.InitElements(webDriver, this);
		}
		public static AddTestSuite Initialize()
		{
			return new AddTestSuite();
		}

        private By txt_Name = By.XPath("//input[@id='name']");
        private By txt_Description = By.XPath("//textarea[@id='description']");
        private By btn_AddTestSuite = By.XPath("//button[contains(text(),'Add Test Suite')]");

        public AddTestSuite txt_Name_SendKeys(string input)
        {
            wElement = txt_Name.GetWebElement();
            wElement.SendKeys(input);

            return this;
        }
        public AddTestSuite txt_Description_SendKeys(string input)
        {
            wElement = txt_Description.GetWebElement();
            wElement.SendKeys(input);

            return this;
        }
        public void btn_AddTestSuite_Click()
        {
            wElement = btn_AddTestSuite.GetWebElement();
            wElement.Click();
        }


    }
}


