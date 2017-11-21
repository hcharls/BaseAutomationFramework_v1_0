using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace BaseAutomationFramework.PageObjects
{
    public static class ByExtensions
    {
        public static IWebElement GetWebElement(this By by, int timeoutInSeconds = 30)
        {
            by.WaitUntilVisible(timeoutInSeconds);
            return BaseSeleniumPage.webDriver.FindElement(by);
        }

		public static IWebElement Find(this By by, int timeoutInSeconds = 30)
		{
			return null;
		}

		public static SelectElement GetSelectElement(this By by)
		{
			return new SelectElement(by.GetWebElement());
		}

        public static bool WaitUntilExists(this By by, int timeoutInSeconds = 30)
        {
			try
			{
				var wait = new WebDriverWait(BaseSeleniumPage.webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
				wait.Until(ExpectedConditions.ElementExists(by));
				return true;
			}
			catch(Exception ex)
			{
				return false;
			}
            
        }

        public static void WaitForTextToBePresentInElementValue(this By by, string text, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(BaseSeleniumPage.webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(by, text));
        }

        public static void WaitUntilClickable(this By by, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(BaseSeleniumPage.webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public static void WaitUntilVisible(this By by, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(BaseSeleniumPage.webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public static void WaitForSelectionStateToBe(this By by, bool selected, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(BaseSeleniumPage.webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementSelectionStateToBe(by, selected));
        }

        public static void WaitUntilInvisible(this By by, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(BaseSeleniumPage.webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        public static void WaitForText(this By by, string text, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(BaseSeleniumPage.webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(by, text));
        }
    }
}
