using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class ClosingVendorInformation : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public ClosingVendorInformation()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static ClosingVendorInformation Initialize()
		{
			return new ClosingVendorInformation();
		}

		public static ClosingVendorInformation OpenForm_FromFormsTab()
		{
			new FormsTab()
				.lstbx_Forms_SelectForm("Closing Vendor Information");

			return new ClosingVendorInformation();
		}

		#region Text Boxes

		private PropertyCondition txt_TitleCompanyName = new PropertyCondition(AutomationElement.NameProperty, "411: The name of the company providing the title insurance. Right-click to select a title insurance company from your business contacts, or type a company name.");
        private PropertyCondition txt_EscrowCompanyName = new PropertyCondition(AutomationElement.NameProperty, "610: The name of the escrow company providing the closing services. Right-click to select an escrow company from the your business contacts, or type a company name.");
        private PropertyCondition txt_EscrowAddress = new PropertyCondition(AutomationElement.NameProperty, "612: The street address of the escrow company.");
        private PropertyCondition txt_EscrowCity = new PropertyCondition(AutomationElement.NameProperty, "613: The city in which the escrow company is located.");
        private PropertyCondition txt_EscrowState = new PropertyCondition(AutomationElement.NameProperty, "1175: The state in which the escrow company is located.");
        private PropertyCondition txt_EscrowZip = new PropertyCondition(AutomationElement.NameProperty, "614: The zip code in which the escrow company is located.");
        private PropertyCondition txt_EscrowOfficerName = new PropertyCondition(AutomationElement.NameProperty, "611: The contact person at the escrow company.");
        private PropertyCondition txt_EscrowPhone = new PropertyCondition(AutomationElement.NameProperty, "615: The escrow company's phone number in the format nnn-nnn-nnnn nnnn.");
        private PropertyCondition txt_EscrowEmail = new PropertyCondition(AutomationElement.NameProperty, "87: The escrow company's email address.");

        public ClosingVendorInformation txt_TitleCompanyName_SendKeys()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_TitleCompanyName);
            aElement.SetFocus();
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.Enter("test");
            Thread.Sleep(1000);

            return this;
        }
        public ClosingVendorInformation txt_EscrowCompanyName_SendKeys()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_EscrowCompanyName);
            aElement.SetFocus();
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.Enter("test");
            Thread.Sleep(1000);

            return this;
        }
        public ClosingVendorInformation txt_EscrowAddress_SendKeys()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_EscrowAddress);
            aElement.SetFocus();
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.Enter("test");
            Thread.Sleep(1000);

            return this;
        }
        public ClosingVendorInformation txt_EscrowCity_SendKeys()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_EscrowCity);
            aElement.SetFocus();
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.Enter("Burbank");
            Thread.Sleep(1000);

            return this;
        }
        public ClosingVendorInformation txt_EscrowState_SendKeys()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_EscrowState);
            aElement.SetFocus();
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.Enter("CA");
            Thread.Sleep(1000);

            return this;
        }
        public ClosingVendorInformation txt_EscrowZip_SendKeys()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_EscrowZip);
            aElement.SetFocus();
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.Enter("91502");
            Thread.Sleep(1000);

            return this;
        }
        public ClosingVendorInformation txt_EscrowOfficerName_SendKeys()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_EscrowOfficerName);
            aElement.SetFocus();
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.Enter("test");
            Thread.Sleep(1000);

            return this;
        }
        public ClosingVendorInformation txt_EscrowPhone_SendKeys()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_EscrowPhone);
            aElement.SetFocus();
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.Enter("345-345-3456");
            Thread.Sleep(1000);

            return this;
        }
        public ClosingVendorInformation txt_EscrowEmail_SendKeys()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_EscrowEmail);
            aElement.SetFocus();
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.Enter("test@test.com");
            Thread.Sleep(1000);

            return this;
        }

        #endregion

        public ClosingVendorInformation CompleteTitleEscrowFields()
        {
            txt_TitleCompanyName_SendKeys()
            .txt_EscrowCompanyName_SendKeys()
            .txt_EscrowAddress_SendKeys()
            .txt_EscrowCity_SendKeys()
            .txt_EscrowState_SendKeys()
            .txt_EscrowZip_SendKeys()
            .txt_EscrowOfficerName_SendKeys()
            .txt_EscrowPhone_SendKeys()
            .txt_EscrowEmail_SendKeys();

            return this;
        }

    }
}
