using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace BaseAutomationFramework.PageObjects.EncompassLoanCenter
{
	public class LoanOfficerLoanCenterLogIn : BaseSeleniumPage
	{
		public LoanOfficerLoanCenterLogIn()
		{
			WaitForPageLoadToComplete(300);
			WaitForAjax();
			PageFactory.InitElements(webDriver, this);
		}		
		public static LoanOfficerLoanCenterLogIn Initialize()
		{
			return new LoanOfficerLoanCenterLogIn();
		}

		#region Buttons

		private By btn_Login = By.XPath("//span[contains(.,'Login')]");
		//
		public void btn_Login_Click()
		{
			wElement = btn_Login.GetWebElement();
			wElement.Click();
			wElement.xtWaitUntilStale();
		}

		#endregion

		#region Text Boxes

		private By txt_ClientID = By.XPath("//input[@id='ctl01_contentContainerHolder_textboxClientID']");
        private By txt_UserID = By.XPath("//input[@id='ctl01_contentContainerHolder_textboxUserID']");
        private By txt_Password = By.XPath("//input[@id='ctl01_contentContainerHolder_textboxPassword']");
		//
		public LoanOfficerLoanCenterLogIn txt_ClientID_SendKeys(string ClientID)
		{
			wElement = txt_ClientID.GetWebElement();
			wElement.SendKeys(ClientID);

			return this;
		}
        public LoanOfficerLoanCenterLogIn txt_UserID_SendKeys(string UserID)
        {
            wElement = txt_UserID.GetWebElement();
            wElement.SendKeys(UserID);

            return this;
        }
        public LoanOfficerLoanCenterLogIn txt_Password_SendKeys(string Password)
		{
			wElement = txt_Password.GetWebElement();
			wElement.SendKeys(Password);

			return this;
		}

		#endregion



	}
}
