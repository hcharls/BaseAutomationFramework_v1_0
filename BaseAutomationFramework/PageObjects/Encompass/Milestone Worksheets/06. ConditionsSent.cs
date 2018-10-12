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
	public class ConditionsSent : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public ConditionsSent()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static ConditionsSent Initialize()
		{
			return new ConditionsSent();
		}

		public static ConditionsSent Open_FromLogTab()
		{
			new LogTab()
                .CollapseAll().SelectItem_ConditionsSent();

			return new ConditionsSent();
		}

		#region Required Fields
		private PropertyCondition txt_HazardInsCoName = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_L252");
		private PropertyCondition txt_HazardInsCoAddress = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_VEND.X157");
		private PropertyCondition txt_HazardInsCoCity = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_VEND.X158");
		private PropertyCondition txt_HazardInsCoState = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_VEND.X159");
		private PropertyCondition txt_HazardInsCoZip = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_VEND.X160");
		private PropertyCondition txt_HazardInsCoPhone = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_VEND.X163");
		private PropertyCondition txt_HazardInsCoRef = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_VEND.X166");
		private PropertyCondition txt_TaxPayHazardInsurance = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_VEND.X445");
		private PropertyCondition txt_HazardInsLastPaidDate = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CX.HAZ.LAST.PAID");

		private PropertyCondition txt_SettlementAgentName = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X55");
		private PropertyCondition txt_SettlementAgentAddress = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X56");
		private PropertyCondition txt_SettlementAgentCity = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X57");
		private PropertyCondition txt_SettlementAgentState = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X58");
		private PropertyCondition txt_SettlementAgentZip = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X59");
		private PropertyCondition txt_SettlementAgentContact = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X62");
		private PropertyCondition txt_SettlementAgentEmail = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X65");
		private PropertyCondition txt_SettlementAgentPhone = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X66");

		private PropertyCondition txt_RealEstateBrokerBuyerName = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X31");
		private PropertyCondition txt_RealEstateBrokerBuyerAddress = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X32");
		private PropertyCondition txt_RealEstateBrokerBuyerCity = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X33");
		private PropertyCondition txt_RealEstateBrokerBuyerState = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X34");
		private PropertyCondition txt_RealEstateBrokerBuyerZip = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X35");
		private PropertyCondition txt_RealEstateBrokerBuyerLicenseID = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X37");
		private PropertyCondition txt_RealEstateBrokerBuyerContact = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X38");
		private PropertyCondition txt_RealEstateBrokerBuyerContactLicenseID = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X40");
		private PropertyCondition txt_RealEstateBrokerBuyerEmail = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X41");
		private PropertyCondition txt_RealEstateBrokerBuyerPhone = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X42");

		private PropertyCondition txt_RealEstateBrokerSellerName = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X43");
		private PropertyCondition txt_RealEstateBrokerSellerZip = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X47");
		private PropertyCondition txt_RealEstateBrokerSellerLicenseID = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X49");
		private PropertyCondition txt_RealEstateBrokerSellerContact = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X50");
		private PropertyCondition txt_RealEstateBrokerSellerContactLicenseID = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X52");
		private PropertyCondition txt_RealEstateBrokerSellerEmail = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X53");
		private PropertyCondition txt_RealEstateBrokerSellerPhone = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X54");
		private PropertyCondition txt_RealEstateBrokerSellerAddress = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X44");
		private PropertyCondition txt_RealEstateBrokerSellerState = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X46");
		private PropertyCondition txt_RealEstateBrokerSellerCity = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_CD5.X45");

		private PropertyCondition txt_SellerAddress = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_701");
		private PropertyCondition txt_SellerCity = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_702");
		private PropertyCondition txt_SellerZip = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_703");
		private PropertyCondition txt_SellerState = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_1249");
		private PropertyCondition txt_SellerName = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_638");

        private PropertyCondition cmb_PropertyInfoFloodZone = new PropertyCondition(AutomationElement.AutomationIdProperty, "l_541");
        private PropertyCondition txt_FloodInfoDeterminationDate = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_2365");
        private PropertyCondition txt_FloodInfoCertNumber = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_2363");
        private PropertyCondition txt_PropertyInfoFloodCertification = new PropertyCondition(AutomationElement.AutomationIdProperty, "b_2977");
        

        public ConditionsSent txt_HazardInsCoName_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_HazardInsCoName);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_HazardInsCoAddress_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_HazardInsCoAddress);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_HazardInsCoCity_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_HazardInsCoCity);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_HazardInsCoState_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_HazardInsCoState);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_HazardInsCoZip_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_HazardInsCoZip);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_HazardInsCoPhone_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_HazardInsCoPhone);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_HazardInsCoRef_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_HazardInsCoRef);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_TaxPayHazardInsurance_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_TaxPayHazardInsurance);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_HazardInsLastPaidDate_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_HazardInsLastPaidDate);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}

		public ConditionsSent txt_SettlementAgentName_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SettlementAgentName);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_SettlementAgentAddress_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SettlementAgentAddress);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_SettlementAgentCity_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SettlementAgentCity);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_SettlementAgentState_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SettlementAgentState);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_SettlementAgentZip_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SettlementAgentZip);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_SettlementAgentContact_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SettlementAgentContact);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_SettlementAgentEmail_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SettlementAgentEmail);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_SettlementAgentPhone_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SettlementAgentPhone);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}

		public ConditionsSent txt_RealEstateBrokerBuyerName_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_RealEstateBrokerBuyerName);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_RealEstateBrokerBuyerAddress_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_RealEstateBrokerBuyerAddress);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_RealEstateBrokerBuyerCity_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_RealEstateBrokerBuyerCity);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_RealEstateBrokerBuyerState_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_RealEstateBrokerBuyerState);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_RealEstateBrokerBuyerZip_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_RealEstateBrokerBuyerZip);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_RealEstateBrokerBuyerLicenseID_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_RealEstateBrokerBuyerLicenseID);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_RealEstateBrokerBuyerContact_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_RealEstateBrokerBuyerContact);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_RealEstateBrokerBuyerContactLicenseID_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_RealEstateBrokerBuyerContactLicenseID);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_RealEstateBrokerBuyerEmail_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_RealEstateBrokerBuyerEmail);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_RealEstateBrokerBuyerPhone_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_RealEstateBrokerBuyerPhone);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}

		public ConditionsSent txt_RealEstateBrokerSellerName_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_RealEstateBrokerSellerName);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_RealEstateBrokerSellerZip_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_RealEstateBrokerSellerZip);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_RealEstateBrokerSellerLicenseID_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_RealEstateBrokerSellerLicenseID);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_RealEstateBrokerSellerContact_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_RealEstateBrokerSellerContact);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_RealEstateBrokerSellerContactLicenseID_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_RealEstateBrokerSellerContactLicenseID);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_RealEstateBrokerSellerEmail_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_RealEstateBrokerSellerEmail);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_RealEstateBrokerSellerPhone_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_RealEstateBrokerSellerPhone);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_RealEstateBrokerSellerAddress_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_RealEstateBrokerSellerAddress);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_RealEstateBrokerSellerState_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_RealEstateBrokerSellerState);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_RealEstateBrokerSellerCity_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_RealEstateBrokerSellerCity);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}

		public ConditionsSent txt_SellerAddress_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SellerAddress);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_SellerCity_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SellerCity);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_SellerZip_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SellerZip);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_SellerState_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SellerState);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ConditionsSent txt_SellerName_SendKeys(string Input)
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_SellerName);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
        public ConditionsSent cmb_PropertyInfoFloodZone_SendKeys(string Input)
        {
            Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
            aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_PropertyInfoFloodZone);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }
        public ConditionsSent txt_FloodInfoDeterminationDate_SendKeys(string Input)
        {
            Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_FloodInfoDeterminationDate);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }
        public ConditionsSent txt_FloodInfoCertNumber_SendKeys(string Input)
        {
            Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_FloodInfoCertNumber);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }
        public ConditionsSent txt_PropertyInfoFloodCertification_SendKeys(string Input)
        {
            Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("panelFields"));
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_PropertyInfoFloodCertification);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }

        #endregion

        #region Checkboxes

        private SearchCriteria chk_Finish = SearchCriteria.ByAutomationId("checkBoxFinished");

		public ConditionsSent chk_Finish_Check()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, "Finished"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "check box")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);

			return this;
		}

        #endregion

        #region Loan Type Methods

        public ConditionsSent CompleteReqFields_DirectConvNoCashOutRefi()
        {
            txt_HazardInsCoRef_SendKeys("7676565576")
            .txt_TaxPayHazardInsurance_SendKeys("100,000")
            .txt_HazardInsLastPaidDate_SendKeys("09/01/2018");
            
            return this;
        }
        #endregion

    }
}