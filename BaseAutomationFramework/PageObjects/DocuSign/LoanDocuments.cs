using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace BaseAutomationFramework.PageObjects.EncompassLoanCenter
{
    public class LoanDocuments : BaseSeleniumPage
    {
        public LoanDocuments()
        {
            WaitForPageLoadToComplete(300);
            WaitForAjax();
            PageFactory.InitElements(webDriver, this);
        }
        public static LoanDocuments Initialize()
        {
            return new LoanDocuments();
        }

        #region Buttons

        private By btn_Next = By.XPath("//span[contains(.,' Next >')]");
        private By btn_Start = By.XPath("//button[@data-qa='autoNavigate']");
        private By btn_RequiredSignHere = By.XPath("//button[@data-qa='signature-tab-required-c8298957-7c10-42cb-ab7a-e16109c69e75']");

        //
        public LoanDocuments btn_Next_Click()
        {
            wElement = btn_Next.GetWebElement();
            wElement.Click();
            wElement.xtWaitUntilStale();

            return this;
        }
        public LoanDocuments btn_Start_Click()
        {
            wElement = btn_Start.GetWebElement();
            wElement.Click();
            wElement.xtWaitUntilStale();

            return this;
        }
        public LoanDocuments btn_RequiredSignHere_Click()
        {
            wElement = btn_RequiredSignHere.GetWebElement();
            wElement.Click();
            wElement.xtWaitUntilStale();

            return this;
        }

        #endregion

    }
}