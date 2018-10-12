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
using TestStack.White.Utility;
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class AdditionalRequestsInformation : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public AdditionalRequestsInformation()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

        public static AdditionalRequestsInformation Initialize()
        {
            return new AdditionalRequestsInformation();
        }

		public static AdditionalRequestsInformation OpenForm_FromFormsTab()
		{
			new FormsTab()
				.lstbx_Forms_SelectForm("Additional Requests Information");

			return new AdditionalRequestsInformation();
		}

        #region Textboxes

        private PropertyCondition txt_HazardInsCompany = new PropertyCondition(AutomationElement.AutomationIdProperty, "l_L252");
        private PropertyCondition txt_HazardInsAddress = new PropertyCondition(AutomationElement.AutomationIdProperty, "l_VENDX157");
        private PropertyCondition txt_HazardInsCity = new PropertyCondition(AutomationElement.AutomationIdProperty, "l_VENDX158");
        private PropertyCondition txt_HazardInsState = new PropertyCondition(AutomationElement.AutomationIdProperty, "l_VENDX159");
        private PropertyCondition txt_HazardInsZip = new PropertyCondition(AutomationElement.AutomationIdProperty, "l_VENDX160");
        private PropertyCondition txt_HazardInsPhone = new PropertyCondition(AutomationElement.AutomationIdProperty, "l_VENDX163");
       
        public AdditionalRequestsInformation txt_HazardInsCompany_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_HazardInsCompany);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }
        public AdditionalRequestsInformation txt_HazardInsAddress_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_HazardInsAddress);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }
        public AdditionalRequestsInformation txt_HazardInsCity_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_HazardInsCity);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }
        public AdditionalRequestsInformation txt_HazardInsState_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_HazardInsState);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }
        public AdditionalRequestsInformation txt_HazardInsZip_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_HazardInsZip);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }
        public AdditionalRequestsInformation txt_HazardInsPhone_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_HazardInsPhone);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }

        #endregion

        public AdditionalRequestsInformation CompleteFields_HazardInsurance()
        {
            txt_HazardInsCompany_SendKeys("test")
            .txt_HazardInsAddress_SendKeys("test")
            .txt_HazardInsCity_SendKeys("Burbank")
            .txt_HazardInsState_SendKeys("CA")
            .txt_HazardInsZip_SendKeys("91502")
            .txt_HazardInsPhone_SendKeys("646-675-5545");

            return this;
        }

    }
}