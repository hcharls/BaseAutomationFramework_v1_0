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

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class ChecklisttoPipe : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public ChecklisttoPipe()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static ChecklisttoPipe OpenForm_FromFormsTab()
		{
			new FormsTab()
				.lstbx_Forms_SelectForm("Checklist to Pipe a Loan");

			return new ChecklisttoPipe();
		}

		#region Text Boxes
		private PropertyCondition txt_Income_AdditionalNotes = new PropertyCondition(AutomationElement.AutomationIdProperty, "MultilineTextBox1");
		private PropertyCondition txt_Mortgage_AdditionalNotes = new PropertyCondition(AutomationElement.AutomationIdProperty, "MultilineTextBox2");
		private PropertyCondition txt_Appraisal_AdditionalNotes = new PropertyCondition(AutomationElement.AutomationIdProperty, "MultilineTextBox3");
		private PropertyCondition txt_Title_AdditionalNotes = new PropertyCondition(AutomationElement.AutomationIdProperty, "MultilineTextBox4");
		private PropertyCondition txt_Cash_Reserves_AdditionalNotes = new PropertyCondition(AutomationElement.AutomationIdProperty, "MultilineTextBox5");
		private PropertyCondition txt_Hazard_Insurance_AdditionalNotes = new PropertyCondition(AutomationElement.AutomationIdProperty, "MultilineTextBox6");
		private PropertyCondition txt_Disclosures_AdditionalNotes = new PropertyCondition(AutomationElement.AutomationIdProperty, "MultilineTextBox7");
		private PropertyCondition txt_Loan_Modification = new PropertyCondition(AutomationElement.AutomationIdProperty, "MultilineTextBox9");
		private PropertyCondition txt_Condo_AdditionalNotes = new PropertyCondition(AutomationElement.AutomationIdProperty, "MultilineTextBox8");
		//
		public ChecklisttoPipe txt_Income_AdditionalNotes_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Income_AdditionalNotes);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ChecklisttoPipe txt_Mortgage_AdditionalNotes_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Mortgage_AdditionalNotes);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ChecklisttoPipe txt_Appraisal_AdditionalNotes_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Appraisal_AdditionalNotes);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ChecklisttoPipe txt_Title_AdditionalNotes_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Title_AdditionalNotes);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ChecklisttoPipe txt_Cash_Reserves_AdditionalNotes_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Cash_Reserves_AdditionalNotes);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ChecklisttoPipe txt_Hazard_Insurance_AdditionalNotes_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Hazard_Insurance_AdditionalNotes);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ChecklisttoPipe txt_Disclosures_AdditionalNotes_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Disclosures_AdditionalNotes);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ChecklisttoPipe txt_Loan_Modification_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Loan_Modification);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public ChecklisttoPipe txt_Condo_AdditionalNotes_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Condo_AdditionalNotes);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}

		#endregion

		#region Combo Boxes

		private PropertyCondition cmb_Income_1 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox1");
		private PropertyCondition cmb_Income_2 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox1");
		private PropertyCondition cmb_Income_3 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox4");
		private PropertyCondition cmb_Income_4 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox3");
		private PropertyCondition cmb_Income_5 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox5");
		private PropertyCondition cmb_Income_6 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox6");

		private PropertyCondition cmb_Mortgage_1 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox8");
		private PropertyCondition cmb_Mortgage_2 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox9");
		private PropertyCondition cmb_Mortgage_3 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox10");

		private PropertyCondition cmb_Appraisal_1 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox11");
		private PropertyCondition cmb_Appraisal_2 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox12");

		private PropertyCondition cmb_Title_1 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox13");
		private PropertyCondition cmb_Title_2 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox14");
		private PropertyCondition cmb_Title_3 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox15");
		private PropertyCondition cmb_Title_4 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox16");
		private PropertyCondition cmb_Title_5 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox17");

		private PropertyCondition cmb_Cash_Reserves_1 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox18");
		private PropertyCondition cmb_Cash_Reserves_2 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox19");
		private PropertyCondition cmb_Cash_Reserves_3 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox7");

		private PropertyCondition cmb_Hazard_Insurance_1 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox21");
		private PropertyCondition cmb_Hazard_Insurance_2 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox22");
		private PropertyCondition cmb_Hazard_Insurance_3 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox23");
		private PropertyCondition cmb_Hazard_Insurance_4 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox24");

		private PropertyCondition cmb_Disclosures_1 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox25");
		private PropertyCondition cmb_Disclosures_2 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox26");

		private PropertyCondition cmb_Framing_the_Process_1 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox27");
		private PropertyCondition cmb_Framing_the_Process_2 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox30");
		private PropertyCondition cmb_Framing_the_Process_3 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox28");
		private PropertyCondition cmb_Framing_the_Process_4 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox31");
		private PropertyCondition cmb_Framing_the_Process_5 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox29");

		private PropertyCondition cmb_Loan_Modification_1 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox32");

		private PropertyCondition cmb_Condo_1 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox33");
		private PropertyCondition cmb_Condo_2 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox34");
		private PropertyCondition cmb_Condo_3 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox35");

		//
		public ChecklisttoPipe cmb_Income_1_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Income_1);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public ChecklisttoPipe cmb_Income_2_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Income_2);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public ChecklisttoPipe cmb_Income_3_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Income_3);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public ChecklisttoPipe cmb_Income_4_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Income_4);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public ChecklisttoPipe cmb_Income_5_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Income_5);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public ChecklisttoPipe cmb_Income_6_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Income_6);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}

		public ChecklisttoPipe cmb_Mortgage_1_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Mortgage_1);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public ChecklisttoPipe cmb_Mortgage_2_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Mortgage_2);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public ChecklisttoPipe cmb_Mortgage_3_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Mortgage_3);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}

		public ChecklisttoPipe cmb_Appraisal_1_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Appraisal_1);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public ChecklisttoPipe cmb_Appraisal_2_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Appraisal_2);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}

		public ChecklisttoPipe cmb_Title_1_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Title_1);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public ChecklisttoPipe cmb_Title_2_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Title_2);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public ChecklisttoPipe cmb_Title_3_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Title_3);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public ChecklisttoPipe cmb_Title_4_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Title_4);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public ChecklisttoPipe cmb_Title_5_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Title_5);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}

		public ChecklisttoPipe cmb_Cash_Reserves_1_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Cash_Reserves_1);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public ChecklisttoPipe cmb_Cash_Reserves_2_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Cash_Reserves_2);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public ChecklisttoPipe cmb_Cash_Reserves_3_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Cash_Reserves_3);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}

		public ChecklisttoPipe cmb_Hazard_Insurance_1_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Hazard_Insurance_1);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public ChecklisttoPipe cmb_Hazard_Insurance_2_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Hazard_Insurance_2);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public ChecklisttoPipe cmb_Hazard_Insurance_3_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Hazard_Insurance_3);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public ChecklisttoPipe cmb_Hazard_Insurance_4_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Hazard_Insurance_4);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}

		public ChecklisttoPipe cmb_Disclosures_1_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Disclosures_1);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public ChecklisttoPipe cmb_Disclosures_2_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Disclosures_2);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}

		public ChecklisttoPipe cmb_Framing_the_Process_1_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Framing_the_Process_1);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public ChecklisttoPipe cmb_Framing_the_Process_2_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Framing_the_Process_2);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public ChecklisttoPipe cmb_Framing_the_Process_3_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Framing_the_Process_3);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public ChecklisttoPipe cmb_Framing_the_Process_4_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Framing_the_Process_4);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public ChecklisttoPipe cmb_Framing_the_Process_5_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Framing_the_Process_5);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}

		public ChecklisttoPipe cmb_Loan_Modification_1_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Loan_Modification_1);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}

		public ChecklisttoPipe cmb_Condo_1_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Condo_1);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public ChecklisttoPipe cmb_Condo_2_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Condo_2);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}
		public ChecklisttoPipe cmb_Condo_3_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Condo_3);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);

			return this;
		}

		#endregion

		#region Buttons

		private PropertyCondition btn_BankerCertification = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button1");
		private PropertyCondition btn_DSMCertification = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button2");
		//
		public ChecklisttoPipe btn_BankerCertification_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_BankerCertification);
			aElement.ClickCenterOfBounds();

			return new ChecklisttoPipe();
		}
		public ChecklisttoPipe btn_DSMCertification_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_DSMCertification);
			aElement.ClickCenterOfBounds();
			return new ChecklisttoPipe();
		}

		#endregion

		#region Checkboxes

		private PropertyCondition chk_Sales_Manager_Certification_1 = new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox1_Ctrl");
		private PropertyCondition chk_Sales_Manager_Certification_2 = new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox2_Ctrl");
		private PropertyCondition chk_Sales_Manager_Certification_3 = new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox3_Ctrl");
		private PropertyCondition chk_Sales_Manager_Certification_4 = new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox4_Ctrl");
		private PropertyCondition chk_Sales_Manager_Certification_5 = new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox5_Ctrl");
		private PropertyCondition chk_Sales_Manager_Certification_6 = new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox6_Ctrl");
		private PropertyCondition chk_Sales_Manager_Certification_7 = new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox7_Ctrl");
		private PropertyCondition chk_Sales_Manager_Certification_8 = new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox8_Ctrl");
		private PropertyCondition chk_Sales_Manager_Certification_9 = new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox9_Ctrl");

		//
		public ChecklisttoPipe chk_Sales_Manager_Certification_1_Check()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox1_Ctrl"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "check box")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);

			return this;
		}
		public ChecklisttoPipe chk_Sales_Manager_Certification_2_Check()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox2_Ctrl"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "check box")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);

			return this;
		}
		public ChecklisttoPipe chk_Sales_Manager_Certification_3_Check()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox3_Ctrl"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "check box")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);

			return this;
		}
		public ChecklisttoPipe chk_Sales_Manager_Certification_4_Check()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox4_Ctrl"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "check box")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);

			return this;
		}
		public ChecklisttoPipe chk_Sales_Manager_Certification_5_Check()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox5_Ctrl"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "check box")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);

			return this;
		}
		public ChecklisttoPipe chk_Sales_Manager_Certification_6_Check()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox6_Ctrl"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "check box")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);

			return this;
		}
		public ChecklisttoPipe chk_Sales_Manager_Certification_7_Check()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox7_Ctrl"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "check box")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);

			return this;
		}
		public ChecklisttoPipe chk_Sales_Manager_Certification_8_Check()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox8_Ctrl"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "check box")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);

			return this;
		}
		public ChecklisttoPipe chk_Sales_Manager_Certification_9_Check()
		{
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.AutomationIdProperty, "__cid_CheckBox9_Ctrl"),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "check box")
				);
			aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);

			return this;
		}

		#endregion
	}
}