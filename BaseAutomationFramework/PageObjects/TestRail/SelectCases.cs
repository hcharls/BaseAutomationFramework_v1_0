using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace BaseAutomationFramework.PageObjects.TestRail
    
{
	public class SelectCases : BaseSeleniumPage
	{
		public SelectCases()
		{
			WaitForPageLoadToComplete(300);
			WaitForAjax();
			PageFactory.InitElements(webDriver, this);
		}
		public static SelectCases Initialize()
		{
			return new SelectCases();
		}

        private By txt_References = By.XPath("//a[contains(text(),'References')]");
        private By cmb_ReferencesContains = By.CssSelector("div.ui-dialog.ui-widget.ui-widget-content.ui-corner-all.dialog.ui-draggable.ui-resizable:nth-child(27) div.dialog.ui-dialog-content.ui-widget-content:nth-child(2) div.dialog-body div.select-dialog-container div.select-dialog-content div.select-dialog-column.select-dialog-column-filter:nth-child(4) div.select-dialog-scroll div.select-dialog-filter div.filter-group.filter:nth-child(11) div.filterContent.hidden table.filter-list tbody:nth-child(2) tr.filterLine td.op:nth-child(1) > select.form-control.form-control-full.form-select");
        private By txt_ReferencesText = By.CssSelector("div.ui-dialog.ui-widget.ui-widget-content.ui-corner-all.dialog.ui-draggable.ui-resizable:nth-child(27) div.dialog.ui-dialog-content.ui-widget-content:nth-child(2) div.dialog-body div.select-dialog-container div.select-dialog-content div.select-dialog-column.select-dialog-column-filter:nth-child(4) div.select-dialog-scroll div.select-dialog-filter div.filter-group.filter:nth-child(11) div.filterContent.hidden table.filter-list tbody:nth-child(2) tr.filterLine td.value:nth-child(2) > input.form-control.form-control-full");
        private By btn_SetSelection = By.XPath("//a[@id='selectCasesFilterApply']");
        private By btn_OK = By.XPath("//button[@id='selectCasesSubmit']");
		//
        public SelectCases txt_References_Click()
        {
            wElement = txt_References.GetWebElement();
            wElement.Click();

            return this;
        }
        public SelectCases cmb_ReferencesContains_SendKeys()
        {
            wElement = cmb_ReferencesContains.GetWebElement();
            wElement.Click();
            wElement.SendKeys("Contains");
            wElement.SendKeys(Keys.Return);
            Thread.Sleep(250);
            return this;
        }
        public SelectCases txt_ReferencesText_SendKeys(string input)
        {
            wElement = txt_ReferencesText.GetWebElement();
            wElement.SendKeys(input);

            return this;
        }
        public SelectCases btn_SetSelection_Click()
        {
            webDriver.FindElement(btn_SetSelection).Click();

            return new SelectCases();
        }
        public void btn_OK_Click()
        {
            webDriver.FindElement(btn_OK).Click();
        }


    }
}


