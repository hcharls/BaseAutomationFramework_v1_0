using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace BaseAutomationFramework.PageObjects.TestRail
    
{
	public class AddTestCase : BaseSeleniumPage
	{
		public AddTestCase()
		{
			WaitForPageLoadToComplete(300);
			WaitForAjax();
			PageFactory.InitElements(webDriver, this);
		}
		public static AddTestCase Initialize()
		{
			return new AddTestCase();
		}

		private By btn_AddTestCase = By.XPath("//button[@id='accept']");
		//
		public void btn_AddTestCase_Click()
		{
            webDriver.FindElement(btn_AddTestCase).Click();
        }

        #region Text Boxes

        private By txt_Title = By.XPath("//input[@id='title']");
        private By txt_References = By.XPath("//input[@id='refs']");
        private By txt_Given = By.XPath("//textarea[@id='custom_given']");
        private By txt_When = By.XPath("//textarea[@id='custom_when']");
        private By txt_Then = By.XPath("//textarea[@id='custom_then']");
        private By txt_Examples = By.XPath("//textarea[@id='custom_examples']");

        //
        public AddTestCase txt_Title_SendKeys(string input)
        {
            wElement = txt_Title.GetWebElement();
            wElement.SendKeys(input);

            return this;
        }
        public AddTestCase txt_References_SendKeys(string input)
        {
            wElement = txt_References.GetWebElement();
            wElement.SendKeys(input);

            return this;
        }
        public AddTestCase txt_Given_SendKeys(string input)
        {
            wElement = txt_Given.GetWebElement();
            wElement.SendKeys(input);

            return this;
        }
        public AddTestCase txt_When_SendKeys(string input)
        {
            wElement = txt_When.GetWebElement();
            wElement.SendKeys(input);

            return this;
        }
        public AddTestCase txt_Then_SendKeys(string input)
        {
            wElement = txt_Then.GetWebElement();
            wElement.SendKeys(input);

            return this;
        }
        public AddTestCase txt_Examples_SendKeys(string header, string example)
        {
            wElement = txt_Examples.GetWebElement();
            wElement.SendKeys(header);
            wElement.SendKeys(Keys.Return);
            wElement.SendKeys(Keys.Return);
            wElement.SendKeys(example);

            return this;
        }

        #endregion

        #region Combo Boxes

        private By cmb_Section = By.XPath("//select[@id='section_id']");
        private By cmb_Milestone = By.XPath("//select[@id='milestone_id']");
        private By cmb_QA = By.XPath("//select[@id='custom_qa']");
        private By cmb_PO = By.XPath("//select[@id='custom_po']");
        private By cmb_DevConfig = By.XPath("//select[@id='custom_devconfig']");

        //
        public AddTestCase cmb_Section_SendKeys(string input)
        {
            wElement = cmb_Section.GetWebElement();
            wElement.Click();
            wElement.SendKeys(input);
            Thread.Sleep(250);
            return this;
        }
        public AddTestCase cmb_Milestone_SendKeys(string input)
        {
            wElement = cmb_Milestone.GetWebElement();
            wElement.Click();
            wElement.SendKeys(input);
            Thread.Sleep(250);
            return this;
        }
        public AddTestCase cmb_QA_SendKeys(string input)
        {
            wElement = cmb_QA.GetWebElement();
            wElement.Click();
            wElement.SendKeys(input);
            Thread.Sleep(250);
            return this;
        }
        public AddTestCase cmb_PO_SendKeys(string input)
        {
            wElement = cmb_PO.GetWebElement();
            wElement.Click();
            wElement.SendKeys(input);
            Thread.Sleep(250);
            return this;
        }
        public AddTestCase cmb_DevConfig_SendKeys(string input)
        {
            wElement = cmb_DevConfig.GetWebElement();
            wElement.Click();
            wElement.SendKeys(input);
            Thread.Sleep(250);
            return this;
        }

        #endregion

    }
}


