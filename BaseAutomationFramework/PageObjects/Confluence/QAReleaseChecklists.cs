using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace BaseAutomationFramework.PageObjects.Confluence
    
{
	public class QAReleaseChecklists : BaseSeleniumPage
	{
		public QAReleaseChecklists()
		{
			WaitForPageLoadToComplete(300);
			WaitForAjax();
			PageFactory.InitElements(webDriver, this);
		}
		public static QAReleaseChecklists Initialize()
		{
			return new QAReleaseChecklists();
		}

		private By btn_CreateNewReleasePage = By.XPath("//button[@class='aui-button create-from-template-button conf-macro output-inline']");
		//
		public void btn_CreateNewReleasePage_Click()
		{
            webDriver.FindElement(btn_CreateNewReleasePage).Click();
        }

    }
}


