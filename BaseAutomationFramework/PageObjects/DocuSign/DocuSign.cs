using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BaseAutomationFramework.PageObjects.EncompassLoanCenter
{
    public class DocuSign : BaseSeleniumPage
    {
        public DocuSign()
        {
            WaitForPageLoadToComplete(300);
            WaitForAjax();            
        }
        public static DocuSign Initialize()
        {
            return new DocuSign();
        }


        public void fn_ESignWholeDocument()
        {
            btn_Next_Click();
            btn_Start_Click();
           
            var allBoxes = webDriver.FindElements(By.XPath("//button[contains(@data-qa,'signature-tab-required')]"));
            for (int i = 0; i < allBoxes.Count; i++)
            {
                allBoxes[i].xtWaitForElementToBeClickable(5);
                allBoxes[i].Click();
                Thread.Sleep(500);
                new DocuSign();
            }

            btn_Finish_Click();

        }

        #region Buttons

        private By btn_Next = By.XPath("//button[@id='action-bar-btn-continue']");
        private By btn_Start = By.XPath(".//*[@id='navigate-btn']");
        private By btn_eSign = By.XPath("//button[contains(@data-qa,'signature-tab-required')]");
        private By btn_Finish = By.XPath("//button[@data-qa='action-bar-finish']");
        private By btn_eSigned = By.XPath("//span[contains(.,'eSigned')]");
        //

        public DocuSign btn_Next_Click()
        {
            wElement = btn_Next.GetWebElement();
            wElement.Click();
            Thread.Sleep(2000);
            return new DocuSign();
            
        }
        public DocuSign btn_Start_Click()
        {
            wElement = btn_Start.GetWebElement();
            wElement.Click();
            Thread.Sleep(3000);
            return new DocuSign();
        }
        public DocuSign btn_Finish_Click()
        {
            wElement = btn_Finish.GetWebElement();
            wElement.Click();
            Thread.Sleep(3000);
            return new DocuSign();
        }

        //public DocuSign btn_eSign_Click()
        //{
        //    int i = 1;
        //    do
        //    {
        //        wElement = btn_eSign.GetWebElement();
        //        wElement.Click();
        //        wElement = btn_Finish.GetWebElement();
        //        wElement.Click();
        //        i++;
        //        Thread.Sleep(2000);
        //        return new DocuSign();

        //    } while (webDriver.FindElement(btn_eSigned).Equals(null) && (i <= 15));

        //}


        #endregion



    }
}
