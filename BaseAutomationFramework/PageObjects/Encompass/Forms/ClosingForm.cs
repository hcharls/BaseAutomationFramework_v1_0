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
	public class ClosingForm : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public ClosingForm()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static ClosingForm Initialize()
		{
			return new ClosingForm();
		}

		public static ClosingForm OpenForm_FromFormsTab()
		{
			new FormsTab()
				.OpenFormsTab()
				.lstbx_Forms_SelectForm("Closing Form");
			Thread.Sleep(2000);

			return new ClosingForm();
		}

		#region Text Boxes
		private PropertyCondition txt_CurrentVesting = new PropertyCondition(AutomationElement.NameProperty, "CX.CF.CURRENT.VESTING");
		private PropertyCondition txt_VestingForDocs = new PropertyCondition(AutomationElement.NameProperty, "CX.CF.VESTING.DOCS");
		private PropertyCondition txt_GrantDeedRequested = new PropertyCondition(AutomationElement.NameProperty, "CX.CF.GRANT.DEED.REQ");
		private PropertyCondition txt_NonObligorSigning = new PropertyCondition(AutomationElement.NameProperty, "CX.CF.NON.OB.SIGN");


		public ClosingForm txt_CurrentVesting_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CurrentVesting);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(1000);

			return this;
		}
		public ClosingForm txt_VestingForDocs_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_VestingForDocs);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(1000);

			return this;
		}
		public ClosingForm txt_GrantDeedRequested_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_GrantDeedRequested);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(1000);

			return this;
		}
		public ClosingForm txt_NonObligorSigning_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_NonObligorSigning);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(1000);

			return this;
		}
		#endregion

		#region Buttons

		private PropertyCondition btn_ProcessorAddData = new PropertyCondition(AutomationElement.AutomationIdProperty, "condSentAddDataButton");
		private PropertyCondition btn_ProcessorClicktoCertify = new PropertyCondition(AutomationElement.AutomationIdProperty, "procCertifyButton");
		private PropertyCondition btn_DocsAddData = new PropertyCondition(AutomationElement.AutomationIdProperty, "docsAddDataButton");

		//
		public ClosingForm btn_ProcessorAddData_Click()
        {

            aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_ProcessorAddData);
			aElement.ClickCenterOfBounds();
            Thread.Sleep(35000);

            return new ClosingForm();
		}
		public ClosingForm btn_ProcessorClicktoCertify_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_ProcessorClicktoCertify);
			aElement.ClickCenterOfBounds();
			Thread.Sleep(1000);

            new EncompassDialog().btn_OKtoCertify_Click();

			return new ClosingForm();
		}
		public ClosingForm btn_DocsAddData_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_DocsAddData);
			aElement.ClickCenterOfBounds();
			Thread.Sleep(25000);

			return new ClosingForm();
		}

		#endregion

		#region Combo Boxes
		private PropertyCondition cmb_ChangeVesting = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox1");
		private PropertyCondition cmb_IsFileReadyForUnderwriting = new PropertyCondition(AutomationElement.AutomationIdProperty, "readyForUnderwritingDropdown");

		public ClosingForm cmb_ChangeVesting_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_ChangeVesting);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(1000);

			return this;
		}
		//{
		//	AndCondition andCond = new AndCondition(
		//			new PropertyCondition(AutomationElement.NameProperty, Input),
		//			new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "combo box")
		//		);

		//	aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_ChangeVesting);
		//	aElement.ClickCenterOfBounds();
		//	Thread.Sleep(500);
		//	AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
		//	item.ClickCenterOfBounds();

		//	return this;
		//}
		public ClosingForm cmb_IsFileReadyForUnderwriting_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_IsFileReadyForUnderwriting);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(3000);

			return this;
		}



        //public void SelectFromComboBox(UIItem box, string Option, int numberOfOptions = 150)
        //{
        //	string currentOption = null;
        //	AutomationElement ae = box.AutomationElement;
        //	Option = Option.ToLower();
        //	// Pressing space should set the option to the blank default
        //	ae.SetFocus();
        //	Thread.Sleep(250);
        //	Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.SPACE);

        //	for (int i = 0; i < numberOfOptions; i++)
        //	{
        //		ae.SetFocus();
        //		Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
        //		Thread.Sleep(10);
        //		currentOption = getLegacyIAccessiblePattern_Value(AutomationElement.FocusedElement).ToLower();
        //		if (currentOption == Option)
        //			return;
        //	}
        //	throw new Exception("Did not find intended ComboBox Option or reached the end of the list of Options!!!");
        //}


        //{
        //	AndCondition andCond = new AndCondition(
        //			new PropertyCondition(AutomationElement.NameProperty, Input),
        //			new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "combo box")
        //		);

        //	aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_IsFileReadyForUnderwriting);
        //	aElement.ClickCenterOfBounds();
        //	Thread.Sleep(500);
        //	new ClosingForm();
        //	AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
        //	item.ClickCenterOfBounds();

        //	return this;
        //}

        #endregion

        public ClosingForm CompleteCurrentVesting()
        {
            txt_CurrentVesting_SendKeys("n")
            .cmb_ChangeVesting_SendKeys("n")
            .txt_VestingForDocs_SendKeys("n")
            .txt_GrantDeedRequested_SendKeys("n")
            .txt_NonObligorSigning_SendKeys("n");
           
            return this;
        }

	}
}






















































































































































































































































































































































































































































































































































