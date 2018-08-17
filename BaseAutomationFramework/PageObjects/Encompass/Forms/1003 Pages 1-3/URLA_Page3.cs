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
	public class URLA_Page3 : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public URLA_Page3()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static URLA_Page3 OpenForm_FromFormsTab()
		{
			new FormsTab()
				.lstbx_Forms_SelectForm("1003 Page 3");

			return new URLA_Page3();
		}

		#region Text Boxes
		//Details of Transaction
		private PropertyCondition txt_Refinance = new PropertyCondition(AutomationElement.AutomationIdProperty, "l_1092");
		//Borrower Declarations
		private PropertyCondition txt_Declaration_a = new PropertyCondition(AutomationElement.NameProperty, "169: If Y, type an explanation on the Continuation Sheet (Page 4).");
		private PropertyCondition txt_Declaration_b = new PropertyCondition(AutomationElement.NameProperty, "265: If Y, type an explanation on the Continuation Sheet (Page 4).");
		private PropertyCondition txt_Declaration_c = new PropertyCondition(AutomationElement.NameProperty, "170: If Y, type an explanation on the Continuation Sheet (Page 4).");
		private PropertyCondition txt_Declaration_d = new PropertyCondition(AutomationElement.NameProperty, "172: If Y, type an explanation on the Continuation Sheet (Page 4).");
		private PropertyCondition txt_Declaration_e = new PropertyCondition(AutomationElement.NameProperty, "1057: If Y, type an explanation on the Continuation Sheet (Page 4).");
		private PropertyCondition txt_Declaration_f = new PropertyCondition(AutomationElement.NameProperty, "463: If Y, type an explanation on the Continuation Sheet (Page 4).");
		private PropertyCondition txt_Declaration_g = new PropertyCondition(AutomationElement.NameProperty, "173: If Y, type an explanation on the Continuation Sheet (Page 4).");
		private PropertyCondition txt_Declaration_h = new PropertyCondition(AutomationElement.NameProperty, "174: If Y, type an explanation on the Continuation Sheet (Page 4).");
		private PropertyCondition txt_Declaration_i = new PropertyCondition(AutomationElement.NameProperty, "171: If Y, type an explanation on the Continuation Sheet (Page 4).");
		private PropertyCondition txt_Declaration_j = new PropertyCondition(AutomationElement.NameProperty, "965: Type Y (yes) or N (no).");
		private PropertyCondition txt_Declaration_k = new PropertyCondition(AutomationElement.NameProperty, "466: Type Y (yes) or N (no).");
		private PropertyCondition txt_Declaration_l = new PropertyCondition(AutomationElement.NameProperty, "418: Type Y (yes) or N (no).");
		private PropertyCondition txt_Declaration_m = new PropertyCondition(AutomationElement.NameProperty, "403: If Y, answer (1) and (2) below.");
		private PropertyCondition txt_Declaration_m1 = new PropertyCondition(AutomationElement.NameProperty, "981: Type PR (principal residence), SH (second home), or IP (investment property).");
		private PropertyCondition txt_Declaration_m2 = new PropertyCondition(AutomationElement.NameProperty, "1069: Type S (sole ownership), SP (jointly with spouse), or O (jointly with another person).");
		//Co-Borrower Declarations
		private PropertyCondition txt_CoBorrowerDeclaration_a = new PropertyCondition(AutomationElement.NameProperty, "175: If Y, type an explanation on the Continuation Sheet (Page 4).");
		private PropertyCondition txt_CoBorrowerDeclaration_b = new PropertyCondition(AutomationElement.NameProperty, "266: If Y, type an explanation on the Continuation Sheet (Page 4).");
		private PropertyCondition txt_CoBorrowerDeclaration_c = new PropertyCondition(AutomationElement.NameProperty, "176: If Y, type an explanation on the Continuation Sheet (Page 4).");
		private PropertyCondition txt_CoBorrowerDeclaration_d = new PropertyCondition(AutomationElement.NameProperty, "178: If Y, type an explanation on the Continuation Sheet (Page 4).");
		private PropertyCondition txt_CoBorrowerDeclaration_e = new PropertyCondition(AutomationElement.NameProperty, "1197: If Y, type an explanation on the Continuation Sheet (Page 4).");
		private PropertyCondition txt_CoBorrowerDeclaration_f = new PropertyCondition(AutomationElement.NameProperty, "464: If Y, type an explanation on the Continuation Sheet (Page 4).");
		private PropertyCondition txt_CoBorrowerDeclaration_g = new PropertyCondition(AutomationElement.NameProperty, "179: If Y, type an explanation on the Continuation Sheet (Page 4).");
		private PropertyCondition txt_CoBorrowerDeclaration_h = new PropertyCondition(AutomationElement.NameProperty, "180: If Y, type an explanation on the Continuation Sheet (Page 4).");
		private PropertyCondition txt_CoBorrowerDeclaration_i = new PropertyCondition(AutomationElement.NameProperty, "177: If Y, type an explanation on the Continuation Sheet (Page 4).");
		private PropertyCondition txt_CoBorrowerDeclaration_j = new PropertyCondition(AutomationElement.NameProperty, "985: Type Y (yes) or N (no).");
		private PropertyCondition txt_CoBorrowerDeclaration_k = new PropertyCondition(AutomationElement.NameProperty, "467: Type Y (yes) or N (no).");
		private PropertyCondition txt_CoBorrowerDeclaration_l = new PropertyCondition(AutomationElement.NameProperty, "1343: Type Y (yes) or N (no).");
		private PropertyCondition txt_CoBorrowerDeclaration_m = new PropertyCondition(AutomationElement.NameProperty, "1108: If Y, answer (1) and (2) below.");
		private PropertyCondition txt_CoBorrowerDeclaration_m1 = new PropertyCondition(AutomationElement.NameProperty, "1015: Type PR (principal residence), SH (second home), or IP (investment property).");
		private PropertyCondition txt_CoBorrowerDeclaration_m2 = new PropertyCondition(AutomationElement.NameProperty, "1070: Type S (sole ownership), SP (jointly with spouse), or O (jointly with another person).");


		//Details of Transaction
		public URLA_Page3 txt_Refinance_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Refinance);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			aElement.WaitWhileBusy();
			Thread.Sleep(1000);

            return new URLA_Page3();
		}
		//Borrower Declarations
		public URLA_Page3 txt_Declaration_a_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Declaration_a);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_Declaration_b_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Declaration_b);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_Declaration_c_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Declaration_c);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_Declaration_d_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Declaration_d);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_Declaration_e_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Declaration_e);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_Declaration_f_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Declaration_f);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_Declaration_g_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Declaration_g);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_Declaration_h_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Declaration_h);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_Declaration_i_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Declaration_i);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_Declaration_j_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Declaration_j);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_Declaration_k_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Declaration_k);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_Declaration_l_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Declaration_l);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_Declaration_m_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Declaration_m);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_Declaration_m1_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Declaration_m1);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_Declaration_m2_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Declaration_m2);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}

		//Co-Borrower Declarations
		public URLA_Page3 txt_CoBorrowerDeclaration_a_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CoBorrowerDeclaration_a);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_CoBorrowerDeclaration_b_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CoBorrowerDeclaration_b);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_CoBorrowerDeclaration_c_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CoBorrowerDeclaration_c);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_CoBorrowerDeclaration_d_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CoBorrowerDeclaration_d);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_CoBorrowerDeclaration_e_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CoBorrowerDeclaration_e);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_CoBorrowerDeclaration_f_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CoBorrowerDeclaration_f);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_CoBorrowerDeclaration_g_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CoBorrowerDeclaration_g);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_CoBorrowerDeclaration_h_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CoBorrowerDeclaration_h);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_CoBorrowerDeclaration_i_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CoBorrowerDeclaration_i);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_CoBorrowerDeclaration_j_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CoBorrowerDeclaration_j);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_CoBorrowerDeclaration_k_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CoBorrowerDeclaration_k);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_CoBorrowerDeclaration_l_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CoBorrowerDeclaration_l);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_CoBorrowerDeclaration_m_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CoBorrowerDeclaration_m);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_CoBorrowerDeclaration_m1_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CoBorrowerDeclaration_m1);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public URLA_Page3 txt_CoBorrowerDeclaration_m2_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_CoBorrowerDeclaration_m2);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}

		#endregion

		#region Buttons

		private PropertyCondition btn_EnterDataManually_Refinance = new PropertyCondition(AutomationElement.AutomationIdProperty, "FieldLock2");
		//

		public URLA_Page3 btn_EnterDataManually_Refinance_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_EnterDataManually_Refinance);
			aElement.ClickCenterOfBounds();
			Thread.Sleep(3000);

			return new URLA_Page3();
		}

		#endregion

		#region Checkboxes

		public URLA_Page3 chk_PrimaryBorrower_Ethnicity_Check(string Ethnicity)
		{
			string id = "";
			switch (Ethnicity)
			{
				case "Hispanic or Latino": id = "__cid_CheckBox21_Ctrl"; break;
				case "Mexican": id = "__cid_checkboxMexican_Ctrl"; break;
				case "Puerto Rican": id = "__cid_checkboxPuertoRican_Ctrl"; break;
				case "Cuban": id = "__cid_checkboxCuban_Ctrl"; break;
				case "Not Hispanic or Latino": id = "__cid_CheckBox32_Ctrl"; break;
				case "I do not wish to provide this information": id = "__cid_chkborrethnicitydonotwish_Ctrl"; break;
				case "Information Not Provided": id = "__cid_chkBorEthInfoNotProvided_Ctrl"; break;
				default: throw new Exception("Did not specify a proper ethnicity!!!");
			}

			aElement = aeScreen.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, id));
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);

			return this;
		}

		public URLA_Page3 chk_PrimaryBorrower_Race_Check(string Race)
		{
			string id = "";
			switch (Race)
			{
				case "American Indian or Alaska Native": id = "__cid_checkboxAmericanIndian_Ctrl"; break;
				case "Asian": id = "__cid_checkboxAsian_Ctrl"; break;
				case "Asian Indian": id = "__cid_checkboxAsianIndian_Ctrl"; break;
				case "Chinese": id = "__cid_checkboxChinese_Ctrl"; break;
				case "Filipino": id = "__cid_checkboxFilipino_Ctrl"; break;
				case "Japanese": id = "__cid_checkboxJapanese_Ctrl"; break;
				case "Korean": id = "__cid_checkboxKorean_Ctrl"; break;
				case "Vietnamese": id = "__cid_checkboxVietnamese_Ctrl"; break;
				case "Black or African American": id = "__cid_CheckBox33_Ctrl"; break;
				case "Native Hawaiian or Other Pacific Islander": id = "__cid_checkboxNativeHawaiianIndicator_Ctrl"; break;
				case "Native Hawaiian": id = "__cid_checkboxHawaiian_Ctrl"; break;
				case "Guamanian or Chamorro": id = "__cid_checkboxGuam_Ctrl"; break;
				case "Samoan": id = "__cid_checkboxSamoan_Ctrl"; break;
				case "White": id = "__cid_CheckBox39_Ctrl"; break;
				case "I do not wish to provide this information": id = "__cid_CheckBox40_Ctrl"; break;
				case "Information Not Provided": id = "__cid_chkBorRaceInfoNotProvided_Ctrl"; break;
				default: throw new Exception("Did not specify a proper race!!!");
			}

			aElement = aeScreen.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, id));
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);

			return this;
		}

		public URLA_Page3 chk_PrimaryBorrower_Sex_Check(string Sex)
		{
			string id = "";
			switch (Sex)
			{
				case "Female": id = "__cid_CheckBox12_Ctrl"; break;
				case "Male": id = "__cid_CheckBox35_Ctrl"; break;
				case "I do not wish to provide this information": id = "__cid_CheckBox36_Ctrl"; break;
				case "Information Not Provided": id = "__cid_chkBorSexInfoNotProvided_Ctrl"; break;
				default: throw new Exception("Did not specify a proper sex!!!");
			}

			aElement = aeScreen.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, id));
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);

			return this;
		}

		public URLA_Page3 chk_CoBorrower_Ethnicity_Check(string Ethnicity)
		{
			string id = "";
			switch (Ethnicity)
			{
				case "Hispanic or Latino": id = "__cid_CheckBox37_Ctrl"; break;
				case "Mexican": id = "__cid_checkboxCoBorrowerMexican_Ctrl"; break;
				case "Puerto Rican": id = "__cid_checkboxCoBorrowerPuertoRican_Ctrl"; break;
				case "Cuban": id = "__cid_checkboxCoBorrowerCuban_Ctrl"; break;
				case "Not Hispanic or Latino": id = "__cid_CheckBox44_Ctrl"; break;
				case "I do not wish to provide this information": id = "__cid_chkcoborrethnicitydonotwish_Ctrl"; break;
				case "Information Not Provided": id = "__cid_chkCoBorEthInfoNotProvided_Ctrl"; break;
				default: throw new Exception("Did not specify a proper ethnicity!!!");
			}

			aElement = aeScreen.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, id));
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);

			return this;
		}

		public URLA_Page3 chk_CoBorrower_Race_Check(string Race)
		{
			string id = "";
			switch (Race)
			{
				case "American Indian or Alaska Native": id = "__cid_checkboxCoBorrowerAmericanIndian_Ctrl"; break;
				case "Asian": id = "__cid_checkboxCoBorrowerAsian_Ctrl"; break;
				case "Asian Indian": id = "__cid_checkboxCoBorrowerAsianIndian_Ctrl"; break;
				case "Chinese": id = "__cid_checkboxCoBorrowerChinese_Ctrl"; break;
				case "Filipino": id = "__cid_checkboxCoBorrowerFilipino_Ctrl"; break;
				case "Japanese": id = "__cid_checkboxCoBorrowerJapanese_Ctrl"; break;
				case "Korean": id = "__cid_checkboxCoBorrowerKorean_Ctrl"; break;
				case "Vietnamese": id = "__cid_checkboxCoBorrowerVietnamese_Ctrl"; break;
				case "Black or African American": id = "__cid_CheckBox63_Ctrl"; break;
				case "Native Hawaiian or Other Pacific Islander": id = "__cid_checkboxCoBorrowerNativeHawaiianIndicator_Ctrl"; break;
				case "Native Hawaiian": id = "__cid_checkboxCoBorrowerHawaiian_Ctrl"; break;
				case "Guamanian or Chamorro": id = "__cid_checkboxCoBorrowerGuam_Ctrl"; break;
				case "Samoan": id = "__cid_checkboxCoBorrowerSamoan_Ctrl"; break;
				case "White": id = "__cid_CheckBox69_Ctrl"; break;
				case "I do not wish to provide this information": id = "__cid_CheckBox70_Ctrl"; break;
				case "Information Not Provided": id = "__cid_chkCoBorRaceInfoNotProvided_Ctrl"; break;
				default: throw new Exception("Did not specify a proper race!!!");
			}

			aElement = aeScreen.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, id));
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);

			return this;
		}

		public URLA_Page3 chk_CoBorrower_Sex_Check(string Sex)
		{
			string id = "";
			switch (Sex)
			{
				case "Female": id = "__cid_CheckBox38_Ctrl"; break;
				case "Male": id = "__cid_CheckBox42_Ctrl"; break;
				case "I do not wish to provide this information": id = "__cid_chkCoBorSexDonotWish_Ctrl"; break;
				case "Information Not Provided": id = "__cid_chkCoBorSexInfoNotProvided_Ctrl"; break;
				default: throw new Exception("Did not specify a proper sex!!!");
			}

			aElement = aeScreen.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, id));
			setLegacyIAccessiblePattern(aElement);
			if (patt_LegacyIAccessiblePattern.Current.DefaultAction == "Check")
				DoDefaultAction(aElement);

			return this;
		}

        #endregion

        public URLA_Page3 cmb_InformationProvidedBy_SendKeys(string Input)
        {
            AndCondition andCond = new AndCondition(
                    new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox5"),
                    new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "combo box")
                );
            aElement = aeScreen.FindFirst(TreeScope.Descendants, andCond);
            aElement.SetFocus();
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(1000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
            Thread.Sleep(1000);
            return this;
        }

    }
}