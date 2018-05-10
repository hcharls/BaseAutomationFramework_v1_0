///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Namespace>
///   Class:          <AgreeToReceiveDisclosuresElectronically>
///   Description:    <Agree_to_Receive_Disclosures_Electronically>
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
			wElement.WaitUntilStale();
		}

		#endregion
		
	}
}


