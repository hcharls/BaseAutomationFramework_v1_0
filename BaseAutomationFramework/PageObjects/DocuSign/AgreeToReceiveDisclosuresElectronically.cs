using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace BaseAutomationFramework.PageObjects.EncompassLoanCenter
{
	public class AgreeToReceiveDisclosuresElectronically : BaseSeleniumPage
	{
		public AgreeToReceiveDisclosuresElectronically()
		{
			WaitForPageLoadToComplete(300);
			WaitForAjax();
			PageFactory.InitElements(webDriver, this);
		}
		public static AgreeToReceiveDisclosuresElectronically Initialize()
		{
			return new AgreeToReceiveDisclosuresElectronically();
		}

		#region Buttons

		private By btn_Agree = By.XPath("//span[contains(.,'I Agree')]");
		//
		public void btn_Agree_Click()
		{
			wElement = btn_Agree.GetWebElement();
			wElement.Click();
			wElement.xtWaitUntilStale();
		}

		#endregion
		
	}
}


