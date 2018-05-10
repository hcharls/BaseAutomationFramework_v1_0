///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Namespace>
///   Class:          <YahooMain>
///   Description:    <Yahoo_Main>
///   Author:         <Hannah_Charls>           Date: <Novmeber_21_2017>
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

namespace BaseAutomationFramework.PageObjects.Yahoo
{
    public class YahooMain : BaseSeleniumPage
    {
        public YahooMain()
		{
			WaitForPageLoadToComplete(300);
			WaitForAjax();
			PageFactory.InitElements(webDriver, this);
        }

        #region Buttons

        private By btn_Search = By.XPath("//button[@id='uh-search-button']");
        //
        public YahooMain btn_Search_Click()
        {
            wElement = btn_Search.GetWebElement();
            wElement.Click();
            wElement.WaitUntilStale();
            return new YahooMain();
        }

        #endregion

        #region Text Boxes

        private By txt_Search = By.XPath("//input[@id='uh-search-box']");
        //
        public YahooMain txt_Search_SendKeys(string input)
        {
            txt_Search.WaitUntilExists();
            txt_Search.GetWebElement().SendKeys(input);

            return this;
        }


        #endregion


    }
}
