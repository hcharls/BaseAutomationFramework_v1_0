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
	public class DisclosurePrep : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public DisclosurePrep()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static DisclosurePrep OpenForm_FromFormsTab()
		{
			new FormsTab()
				.lstbx_Forms_SelectForm("Disclosure Prep (TRID)");

			return new DisclosurePrep();
		}

		public static DisclosurePrep Initialize()
		{
			return new DisclosurePrep();
		}

		#region Combo Boxes
		private PropertyCondition cmb_WilltherebeSubordination = new PropertyCondition(AutomationElement.AutomationIdProperty, "subDropdown");
		private PropertyCondition cmb_BetterRateWarranty = new PropertyCondition(AutomationElement.AutomationIdProperty, "betterRateWarrantyDropDown");
		private PropertyCondition cmb_ImpoundsWaivedorNotWaived = new PropertyCondition(AutomationElement.AutomationIdProperty, "impoundRequiredDropdown");
		private PropertyCondition cmb_Impoundswillbefor = new PropertyCondition(AutomationElement.AutomationIdProperty, "impoundTypesDropdown");
		private PropertyCondition cmb_AddingRemovingSomeoneFromTitle = new PropertyCondition(AutomationElement.AutomationIdProperty, "addRemoveTitleDropdown");
		private PropertyCondition cmb_DocumentDeliveryPreference = new PropertyCondition(AutomationElement.AutomationIdProperty, "docPrefBox");
		//

		public DisclosurePrep cmb_WilltherebeSubordination_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_WilltherebeSubordination);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public DisclosurePrep cmb_BetterRateWarranty_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_BetterRateWarranty);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public DisclosurePrep cmb_ImpoundsWaivedorNotWaived_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_ImpoundsWaivedorNotWaived);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public DisclosurePrep cmb_Impoundswillbefor_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Impoundswillbefor);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public DisclosurePrep cmb_AddingRemovingSomeoneFromTitle_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_AddingRemovingSomeoneFromTitle);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public DisclosurePrep cmb_DocumentDeliveryPreference_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_DocumentDeliveryPreference);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		#endregion

		#region Buttons
		private PropertyCondition btn_GenerateEstimatedClosingDatesandStandardFees = new PropertyCondition(AutomationElement.AutomationIdProperty, "disclosureDatesButton");
		private PropertyCondition btn_RunWestVM = new PropertyCondition(AutomationElement.AutomationIdProperty, "gfeButton");
		private PropertyCondition btn_Review2015Itemization = new PropertyCondition(AutomationElement.AutomationIdProperty, "reviewItemizationButton");
		private PropertyCondition btn_RunComplianceReport = new PropertyCondition(AutomationElement.AutomationIdProperty, "complianceButton");
		private PropertyCondition btn_RunDUorLP = new PropertyCondition(AutomationElement.AutomationIdProperty, "undButton");
		private PropertyCondition btn_NotNowContinue = new PropertyCondition(AutomationElement.AutomationIdProperty, "undContinueButton");
		private PropertyCondition btn_ReadytoDisclose = new PropertyCondition(AutomationElement.AutomationIdProperty, "readyButton");
		private PropertyCondition btn_GenerateDisclosures = new PropertyCondition(AutomationElement.AutomationIdProperty, "genDisclosureButton");
		//
		public DisclosurePrep btn_GenerateEstimatedClosingDatesandStandardFees_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_GenerateEstimatedClosingDatesandStandardFees);
			aElement.ClickCenterOfBounds();
			Thread.Sleep(10000);

			return new DisclosurePrep();
		}
		public DisclosurePrep btn_RunWestVM_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_RunWestVM);
			aElement.ClickCenterOfBounds();

			return new DisclosurePrep();
		}
		public DisclosurePrep btn_Review2015Itemization_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_Review2015Itemization);
			aElement.ClickCenterOfBounds();

			return new DisclosurePrep();
		}
		public DisclosurePrep btn_RunComplianceReport_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_RunComplianceReport);
			aElement.ClickCenterOfBounds();

			return new DisclosurePrep();
		}
		public DisclosurePrep btn_ReadytoDisclose_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_ReadytoDisclose);
			aElement.ClickCenterOfBounds();

			return new DisclosurePrep();
		}
		public DisclosurePrep btn_GenerateDisclosures_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_GenerateDisclosures);
			aElement.ClickCenterOfBounds();

			return new DisclosurePrep();
		}
		#endregion

		#region Text Boxes
		private PropertyCondition txt_GenerateEstimatedDateLastUpdated = new PropertyCondition(AutomationElement.AutomationIdProperty, "TextBox5");
		private PropertyCondition txt_WestVMLastRunDate = new PropertyCondition(AutomationElement.AutomationIdProperty, "gfeDateBox");
		private PropertyCondition txt_ComplianceLastRunDate = new PropertyCondition(AutomationElement.AutomationIdProperty, "TextBox6");
		private PropertyCondition txt_AUSLastRunDate = new PropertyCondition(AutomationElement.AutomationIdProperty, "duLastRunBox");
		private PropertyCondition txt_ValidationErrors = new PropertyCondition(AutomationElement.AutomationIdProperty, "validationErrorsBox");
		//

		#endregion

	}
}