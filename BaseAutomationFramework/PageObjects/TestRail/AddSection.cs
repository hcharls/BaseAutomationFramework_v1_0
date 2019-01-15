using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BaseAutomationFramework.PageObjects.TestRail

    //suite that houses test cases for the sprint
{
	public class AddSection : BaseSeleniumPage
	{
		public AddSection()
		{
			WaitForPageLoadToComplete(300);
			WaitForAjax();
			PageFactory.InitElements(webDriver, this);
		}
		public static AddSection Initialize()
		{
			return new AddSection();
		}

        private By txt_Name = By.XPath("//input[@id='editSectionName']");
        private By txt_Description = By.XPath("//textarea[@id='editSectionDescription']");
        private By btn_AddSection = By.XPath("//span[@class='editSectionAdd']");

        public AddSection txt_Name_SendKeys(string input)
        {
            wElement = txt_Name.GetWebElement();
            wElement.SendKeys(input);

            return this;
        }
        public AddSection txt_Description_SendKeys(string input)
        {
            wElement = txt_Description.GetWebElement();
            wElement.SendKeys(input);

            return this;
        }
        public void btn_AddSection_Click()
        {
            wElement = btn_AddSection.GetWebElement();
            wElement.Click();
        }


    }
}


