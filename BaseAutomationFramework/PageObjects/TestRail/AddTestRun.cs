using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace BaseAutomationFramework.PageObjects.TestRail
    
{
	public class AddTestRun : BaseSeleniumPage
	{
		public AddTestRun()
		{
			WaitForPageLoadToComplete(300);
			WaitForAjax();
			PageFactory.InitElements(webDriver, this);
		}
		public static AddTestRun Initialize()
		{
			return new AddTestRun();
		}

        private By txt_Name = By.XPath("//input[@id='name']");
        private By cmb_Milestone = By.XPath("//select[@id='milestone_id']");
        private By cmb_AssignTo = By.XPath("//select[@id='assignedto_id']");
        private By txt_Description = By.XPath("//textarea[@id='description']");
        private By rdb_SelectSpecific = By.XPath("//input[@id='includeSpecific']");
        private By txt_ChangeSelection = By.XPath("//a[contains(text(),'change selection')]");
        private By btn_AddTestRun = By.XPath("//button[contains(text(),'Add Test Run')]");
		//
        public AddTestRun txt_Name_SendKeys(string input)
        {
            wElement = txt_Name.GetWebElement();
            wElement.Click();
            wElement.SendKeys(Keys.Control + "a");
            wElement.SendKeys(input);

            return this;
        }
        public AddTestRun cmb_Milestone_SendKeys(string input)
        {
            wElement = cmb_Milestone.GetWebElement();
            wElement.Click();
            wElement.SendKeys(input);
            Thread.Sleep(250);
            return this;
        }
        public AddTestRun cmb_AssignTo_SendKeys(string input)
        {
            wElement = cmb_AssignTo.GetWebElement();
            wElement.Click();
            wElement.SendKeys(input);
            Thread.Sleep(250);
            return this;
        }
        public AddTestRun txt_Description_SendKeys(string input)
        {
            wElement = txt_Description.GetWebElement();
            wElement.SendKeys(input);

            return this;
        }
        public AddTestRun rdb_SelectSpecific_Click()
        {
            wElement = rdb_SelectSpecific.GetWebElement();
            wElement.Click();

            return this;
        }
        public void txt_ChangeSelection_Click()
        {
            wElement = txt_ChangeSelection.GetWebElement();
            wElement.Click();
            
        }



        public void btn_AddTestRun_Click()
        {
            webDriver.FindElement(btn_AddTestRun).Click();
        }


    }
}


