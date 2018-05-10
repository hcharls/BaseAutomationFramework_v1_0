///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Namespace>
///   Class:          <LoanDetail>
///   Description:    <Loan_Detail>
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

		private By btn_View = By.XPath("//span[contains(.,'Agree To Receive Disclosures electronically')]");
        private By btn_eSign = By.XPath("");

        //
        public void btn_View_Click()
		{
			wElement = btn_View.GetWebElement();
			wElement.Click();
            wElement.WaitUntilStale();
        }
        public void btn_eSign_Click()
        {
            wElement = btn_eSign.GetWebElement();
            wElement.Click();
            wElement.WaitUntilStale();
        }

        #endregion


    }
}
