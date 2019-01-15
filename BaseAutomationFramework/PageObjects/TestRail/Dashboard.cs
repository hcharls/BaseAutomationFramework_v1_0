using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BaseAutomationFramework.PageObjects.TestRail

{
	public class Dashboard : BaseSeleniumPage
	{
		public Dashboard()
		{
			WaitForPageLoadToComplete(300);
			WaitForAjax();
			PageFactory.InitElements(webDriver, this);
		}
		public static Dashboard Initialize()
		{
			return new Dashboard();
		}

        public Dashboard btn_Project_Click(string input)
        {
            By btn_Project = By.XPath("//a[contains(text(),'" + (input) + "')]");
            wElement = btn_Project.GetWebElement();
            wElement.Click();

            return new Dashboard();
        }
        public void btn_AddProject_Click()
		{
            By btn_AddProject = By.XPath("//a[@id='addProject']");
            webDriver.FindElement(btn_AddProject).Click();

		}

    }
}


