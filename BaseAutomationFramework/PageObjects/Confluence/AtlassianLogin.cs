using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace BaseAutomationFramework.PageObjects.Confluence
    
{
	public class AtlassianLogin : BaseSeleniumPage
	{
		public AtlassianLogin()
		{
			WaitForPageLoadToComplete(300);
			WaitForAjax();
			PageFactory.InitElements(webDriver, this);
		}
		public static AtlassianLogin Initialize()
		{
			return new AtlassianLogin();
		}

        #region Text Boxes

        private By txt_Username = By.XPath("//input[@id='username']");
        private By txt_Password = By.XPath("//input[@id='password']");

        //
        public AtlassianLogin txt_Username_SendKeys(string input)
        {
            wElement = txt_Username.GetWebElement();
            wElement.SendKeys(input);

            return this;
        }
        public AtlassianLogin txt_Password_SendKeys(string input)
        {
            wElement = txt_Password.GetWebElement();
            wElement.SendKeys(input);

            return this;
        }

        #endregion

        #region Buttons

        private By btn_Continue = By.XPath("//span[contains(text(),'Continue')]");
        private By btn_LogIn = By.XPath("//button[@id='login-submit']//span//span//span[contains(text(),'Log in')]");

        //

        public AtlassianLogin btn_Continue_Click()
        {
            webDriver.FindElement(btn_Continue).Click();

            return new AtlassianLogin();
        }
        public void btn_LogIn_Click()
        {
            webDriver.FindElement(btn_LogIn).Click();
        }

        #endregion
    }
}


