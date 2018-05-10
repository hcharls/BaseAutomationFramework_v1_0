///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Namespace>
///   Class:          <LoanDocuments>
///   Description:    <Loan_Documents_page_for_eSigning_Disclosures>
///   Author:         <Hannah_Charls>           Date: <May_3_2018>
///   Notes:          <>
///   Revision History:
///   Name:				 Date:					Description:
///   
/// 
///------------------------------------------------------------------------------------------------------------------------

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            wElement.WaitUntilStale();

            return this;
        }
        public LoanDocuments btn_Start_Click()
        {
            wElement = btn_Start.GetWebElement();
            wElement.Click();
            wElement.WaitUntilStale();

            return this;
        }
        public LoanDocuments btn_RequiredSignHere_Click()
        {
            wElement = btn_RequiredSignHere.GetWebElement();
            wElement.Click();
            wElement.WaitUntilStale();

            return this;
        }

        #endregion

    }
}