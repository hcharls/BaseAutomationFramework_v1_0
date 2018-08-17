using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace BaseAutomationFramework.PageObjects
{
    public static class IWebElementExtensions
    {
        public static Dictionary<string, object> GetAllAttributes(this IWebElement element)
        {
            ExpectedConditions.StalenessOf(element);
            ExpectedConditions.TextToBePresentInElement(element, "");

            string js =
                "var items = {};" +
                "for (i = 0; i < arguments[0].attributes.length; ++i) {" +
                "   if (arguments[0].attributes[i].value != undefined) {" +
                "       items[arguments[0].attributes[i].name] = arguments[0].attributes[i].value;" +
                "   }" +
                "}" +
                "return items;";

            Dictionary<string, object> attributes = null;

            try
            {
                attributes = (Dictionary<string, object>)((IJavaScriptExecutor)BaseSeleniumPage.webDriver).ExecuteScript(js, element);
            }
            catch (Exception)
            {
            }

            return attributes;
        }

		public static string GetText(string id)
		{
			string js =
				"var element = document.getElementById(\"" + id + "\"); " +
				"var text = element.textContent; " +
				"return text;";
			string str = (string)((IJavaScriptExecutor)BaseSeleniumPage.webDriver).ExecuteScript(js);
			return str;
		}
		
		public static void xtWaitUntilStale(this IWebElement element, int timeoutInSeconds=30)
        {
            var wait = new WebDriverWait(BaseSeleniumPage.webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.StalenessOf(element));
        }

        public static void xtWaitForTextToBePresent(this IWebElement element, string str, int timeoutInSeconds=30)
        {
            var wait = new WebDriverWait(BaseSeleniumPage.webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.TextToBePresentInElement(element, str));
        }
        public static void xtWaitForElementToBeClickable(this IWebElement element, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(BaseSeleniumPage.webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
    }
}
