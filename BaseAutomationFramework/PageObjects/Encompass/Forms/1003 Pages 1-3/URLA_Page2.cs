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
	public class URLA_Page2 : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public URLA_Page2()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static URLA_Page2 OpenForm_FromFormsTab()
		{
			new FormsTab()
				.lstbx_Forms_SelectForm("1003 Page 2");

			return new URLA_Page2();
		}

		#region Buttons

		private PropertyCondition btn_EditFieldValueBorrowerBase = new PropertyCondition(AutomationElement.AutomationIdProperty, "StandardButton1"); 
		private PropertyCondition btn_ShowAllVOD = new PropertyCondition(AutomationElement.AutomationIdProperty, "Button9");

		public URLA_Page2 btn_ShowAllVOD_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_ShowAllVOD);
			aElement.ClickCenterOfBounds();

			return new URLA_Page2();
		}
		public URLA_Page2 btn_EditFieldValueBorrowerBase_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_EditFieldValueBorrowerBase);
			aElement.ClickCenterOfBounds();

			return new URLA_Page2();
		}

        #endregion

        #region Combo Boxes

        private PropertyCondition cmb_MortgageType1 = new PropertyCondition(AutomationElement.AutomationIdProperty, "DropdownBox9");

        public URLA_Page2 cmb_MortgageType1_SendKeys(string Input)
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_MortgageType1);
            aElement.SetFocus();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(500);

            return this;
        }

        #endregion
    }
}