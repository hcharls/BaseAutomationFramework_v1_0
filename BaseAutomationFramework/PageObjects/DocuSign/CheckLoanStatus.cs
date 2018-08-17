using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using TestStack.White.InputDevices;
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.PageObjects.EncompassLoanCenter
{
	public class CheckLoanStatus : BaseSeleniumPage
	{		
		public CheckLoanStatus()
		{
			WaitForPageLoadToComplete(300);
			WaitForAjax();
			PageFactory.InitElements(webDriver, this);
		}

		public static CheckLoanStatus Initialize()
		{
			return new CheckLoanStatus();
		}

		//td[@class='tableBodyColumn']/input[@id='ctl01_contentContainerHolder_gvLoans_ctl02_cb']
		//td[@id='ctl01_contentContainerHolder_gvLoans']//input[@id='ctl01_contentContainerHolder_gvLoans_ctl02_cb']

		public void fn_SelectFirstRow()
		{
			wElement = By.XPath("//input[@id='ctl01_contentContainerHolder_gvLoans_ctl02_cb']/../../td[2]").GetWebElement();
			wElement.Click();
		}

        #region Buttons

        private By btn_Search = By.XPath("//span[contains(.,' Search ')]");
        //

        public CheckLoanStatus btn_Search_Click()
        {
            wElement = btn_Search.GetWebElement();
            wElement.Click();
            Thread.Sleep(2000);
            return new CheckLoanStatus();

        }

        #endregion

        #region Text Boxes

        private By txt_SearchValue = By.XPath("//input[contains(@name,'tbSearchValue')]");

        //
        public CheckLoanStatus txt_SearchValue_SendKeys(string ClientID)
        {
            wElement = txt_SearchValue.GetWebElement();
            wElement.SendKeys(ClientID);

            return this;
        }

        #endregion

        #region Combo Boxes

        private By cmb_SearchBy = By.XPath("//select[contains(@id,'ddlSearchType')]");

        //
        public CheckLoanStatus cmb_SearchBy_SendKeys(string input)
        {
            wElement = cmb_SearchBy.GetWebElement();
            wElement.Click();
            wElement.SendKeys(input);
            Thread.Sleep(1000);
            return this;
        }

        #endregion

    }
}
