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
	public class AppraisalOrderAndTracking : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public AppraisalOrderAndTracking()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static AppraisalOrderAndTracking OpenForm_FromFormsTab()
		{
			new FormsTab()
				.lstbx_Forms_SelectForm("Appraisal Order and Tracking");
				Thread.Sleep(250);

			return new AppraisalOrderAndTracking();
		}

		public static AppraisalOrderAndTracking Initialize()
		{
			return new AppraisalOrderAndTracking();
		}

		public void DragPaymentProcessingWindow()
		{
			new PaymentProcessing()
			.DragWindow_PaymentProcessing();
			Thread.Sleep(5000);
		}


		#region Combo Boxes

		private PropertyCondition cmb_PropertyType = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox4");

		public AppraisalOrderAndTracking cmb_PropertyType_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_PropertyType);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Thread.Sleep(250);
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(1000);

			return this;
		}

		#endregion

		#region Text Boxes

		private PropertyCondition txt_NoUnits = new PropertyCondition(AutomationElement.AutomationIdProperty, "TextBox6");
		
		public AppraisalOrderAndTracking txt_NoUnits_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_NoUnits);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(100);

			return this;
		}

		#endregion

		#region Checkboxes

		private SearchCriteria chk_EnterPaymentInfoForBorrower = SearchCriteria.ByAutomationId("__cid_getPaymentLinkCheckbox_Ctrl");

		public AppraisalOrderAndTracking chk_EnterPaymentInfoForBorrower_Check(bool Check)
		{
			ClickCheckBox(Check, chk_EnterPaymentInfoForBorrower);
			Thread.Sleep(3000);

			return this;
		}

		#endregion


	}
}