using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace BaseAutomationFramework.PageObjects.EncompassLoanCenter
{
	public class LoanDetail : BaseSeleniumPage
	{
		public LoanDetail()
		{
			WaitForPageLoadToComplete(300);
			WaitForAjax();
			PageFactory.InitElements(webDriver, this);
		}
		public static LoanDetail Initialize()
		{
			return new LoanDetail();
		}

		#region Buttons

		private By btn_View = By.XPath("//a[@class='btnRight Normal9Bold']");
        private By btn_eSign = By.XPath("");

        //
        public void btn_View_Click()
		{
			wElement = btn_View.GetWebElement();
			wElement.Click();
            wElement.xtWaitUntilStale();
        }
        public void btn_eSign_Click()
        {
            wElement = btn_eSign.GetWebElement();
            wElement.Click();
            wElement.xtWaitUntilStale();
        }

        #endregion


    }
}
