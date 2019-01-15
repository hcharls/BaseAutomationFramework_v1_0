using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BaseAutomationFramework.PageObjects.TestRail
   
{
	public class TestRailLogin : BaseSeleniumPage
	{
		public TestRailLogin()
		{
			WaitForPageLoadToComplete(300);
			WaitForAjax();
			PageFactory.InitElements(webDriver, this);
		}
		public static TestRailLogin Initialize()
		{
			return new TestRailLogin();
		}

        private By txt_EmailAddress = By.XPath("//input[@id='name']");
        private By txt_Password = By.XPath("//input[@id='password']");
        private By btn_Login = By.XPath("//span[@class='single-sign-on']");

        public TestRailLogin txt_EmailAddress_SendKeys(string input)
        {
            wElement = txt_EmailAddress.GetWebElement();
            wElement.SendKeys(input);

            return this;
        }
        public TestRailLogin txt_Password_SendKeys(string input)
        {
            wElement = txt_Password.GetWebElement();
            wElement.SendKeys(input);

            return this;
        }
        public void btn_Login_Click()
        {
            wElement = btn_Login.GetWebElement();
            wElement.Click();
            wElement.xtWaitUntilStale();
        }


    }
}


