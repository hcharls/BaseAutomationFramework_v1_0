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
		private PropertyCondition txt_Refinance = new PropertyCondition(AutomationElement.NameProperty, "1092: If this is a refinance loan, the total liens and other debts to be paid from the loan proceeds. Liabilities included in the total are marked as 'to be paid off' on the VOL.");
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
			Thread.Sleep(500);

			return this;
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

			return new URLA_Page3();
		}

		#endregion
	}
}