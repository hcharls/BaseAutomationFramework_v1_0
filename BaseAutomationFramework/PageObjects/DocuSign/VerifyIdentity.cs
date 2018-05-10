///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Namespace>
///   Class:          <VerifyIdentity>
///   Description:    <Enter_Authorization_Code_to_eSign_Disclosures>
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
            wElement.WaitUntilStale();
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
