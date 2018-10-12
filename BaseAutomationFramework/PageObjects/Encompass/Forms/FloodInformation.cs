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
	public class FloodInformation : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public FloodInformation()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

        public static FloodInformation Initialize()
        {
            return new FloodInformation();
        }

		public static FloodInformation OpenForm_FromFormsTab()
		{
			new FormsTab()
				.lstbx_Forms_SelectForm("Flood Information");

			return new FloodInformation();
		}

        #region Flood Certification

        private PropertyCondition txt_CertificationNumber = new PropertyCondition(AutomationElement.AutomationIdProperty, "TextBox48");
        private PropertyCondition txt_DeterminationDate = new PropertyCondition(AutomationElement.AutomationIdProperty, "TextBox62");
        private PropertyCondition cmb_FloodZone = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox5");
       
        public FloodInformation txt_CertificationNumber_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CertificationNumber);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }
        public FloodInformation txt_DeterminationDate_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_DeterminationDate);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }
        public FloodInformation cmb_FloodZone_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_FloodZone);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }

        #endregion

        public FloodInformation CompleteFields_FloodCertification()
        {
            txt_CertificationNumber_SendKeys("65656576")
            .txt_DeterminationDate_SendKeys("10/10/2018")
            .cmb_FloodZone_SendKeys("No");

            return this;
        }

    }
}