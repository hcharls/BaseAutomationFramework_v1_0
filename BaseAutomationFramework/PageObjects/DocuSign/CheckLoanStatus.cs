///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Namespace>
///   Class:          <CheckLoanStatus>
///   Description:    <Check_Loan_Status>
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.Utility;
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.PageObjects.EncompassLoanCenter
{
	public class CheckLoanStatus : BaseSeleniumPage
	{		
		public CheckLoanStatus()
		{
			WaitForPageLoadToComplete(300);
			WaitForAjax();
			PageFactory.InitElements(webDriver, this);
		}

		public static CheckLoanStatus Initialize()
		{
			return new CheckLoanStatus();
		}


		//td[@class='tableBodyColumn']/input[@id='ctl01_contentContainerHolder_gvLoans_ctl02_cb']
		//td[@id='ctl01_contentContainerHolder_gvLoans']//input[@id='ctl01_contentContainerHolder_gvLoans_ctl02_cb']

		public void fn_SelectFirstRow()
		{
			wElement = By.XPath("//input[@id='ctl01_contentContainerHolder_gvLoans_ctl02_cb']/../../td[2]").GetWebElement();
			wElement.Click();
		}

	}
}
