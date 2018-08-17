using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace BaseAutomationFramework.PageObjects.EncompassLoanCenter
{
    public class VerifyIdentity : BaseSeleniumPage
    {
        public VerifyIdentity()
        {
            WaitForPageLoadToComplete(300);
            WaitForAjax();
            PageFactory.InitElements(webDriver, this);
        }
        public static VerifyIdentity Initialize()
        {
            return new VerifyIdentity();
        }

        #region Buttons

        private By btn_Next = By.XPath("//span[contains(.,' Next >')]");
        //
        public void btn_Next_Click()
        {
            wElement = btn_Next.GetWebElement();
            wElement.Click();
            wElement.xtWaitUntilStale();
        }
        
        #endregion

        #region Text Boxes

        private By txt_AuthorizationCode = By.XPath("//input[@type='password']");
        //
        public VerifyIdentity txt_AuthorizationCode_SendKeys(string AuthorizationCode)
        {
            wElement = txt_AuthorizationCode.GetWebElement();
            wElement.SendKeys(AuthorizationCode);

            return this;
        }

        #endregion



    }
}
