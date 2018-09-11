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
	public class ClosingDisclosurePage5 : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public ClosingDisclosurePage5()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "LoanPage");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

        public static ClosingDisclosurePage5 Initialize()
        {
            return new ClosingDisclosurePage5();
        }

		public static ClosingDisclosurePage5 OpenForm_FromFormsTab()
		{
			new FormsTab()
				.lstbx_Forms_SelectForm("Closing Disclosure Page 5");

			return new ClosingDisclosurePage5();
		}

        public ClosingDisclosurePage5 GetFirstCheckBoxState(out bool IsChecked)
        {
            IsChecked = Screen.Get<CheckBox>(chk_StateLawMayProtect).AutomationElement.xtGetCheckedState();
            return this;
        }
        public ClosingDisclosurePage5 GetSecondCheckBoxState(out bool IsChecked)
        {
            IsChecked = Screen.Get<CheckBox>(chk_StateLawDoesNotProtect).AutomationElement.xtGetCheckedState();
            return this;
        }

        #region Checkboxes

        private SearchCriteria chk_StateLawMayProtect = SearchCriteria.ByAutomationId("__cid_CheckBox1_Ctrl");
        private SearchCriteria chk_StateLawDoesNotProtect = SearchCriteria.ByAutomationId("__cid_CheckBox2_Ctrl");

        public ClosingDisclosurePage5 chk_StateLawMayProtect_Check(bool Check)
        {
            ClickCheckBox(Check, chk_StateLawMayProtect);

            return this;
        }
        public ClosingDisclosurePage5 chk_StateLawDoesNotProtect_Check(bool Check)
        {
            ClickCheckBox(Check, chk_StateLawDoesNotProtect);

            return this;
        }
        
        #endregion

    }
}