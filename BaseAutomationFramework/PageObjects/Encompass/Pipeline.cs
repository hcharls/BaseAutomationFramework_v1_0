using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.Utility;
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class Pipeline : BaseScreen
	{
		public static SearchCriteria[] scArray = { EncompassMain.scWindow };
		public const bool SET_MAXIMIZED = true;

		public Pipeline()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}
		public static Pipeline Initialize()
		{
			return new Pipeline();
		}

		#region Buttons

		private SearchCriteria btn_NewLoan = SearchCriteria.ByAutomationId("btnNew");
		//
		public void btn_NewLoan_Click()
		{
			GetPanel(btn_NewLoan).Click();
		}

		#endregion

		#region Combo Box

		private SearchCriteria cmb_PipelineView = SearchCriteria.ByAutomationId("cboView");
		private SearchCriteria cmb_LoanFolder = SearchCriteria.ByAutomationId("cboFolder");

		public Pipeline cmb_PipelineView_SelectByText(string Input)
		{
			GetComboBox(cmb_PipelineView).Select(Input);

			return new Pipeline();
		}
		public Pipeline cmb_LoanFolder_SelectByText(string Input)
		{
			GetComboBox(cmb_LoanFolder).Select(Input);

			return new Pipeline();
		}

		#endregion

		#region Pipeline Views

		public void Pipeline_SelectCurrentLoan(string input)
        {
            cmb_PipelineView_SelectByText("QA View").cmb_LoanFolder_SelectByText("Testing_Training");

            SearchCriteria LoanNumber = SearchCriteria.ByAutomationId("SizableTextBox").AndIndex(0);
			Panel pne = GetPanel(LoanNumber);
            pne.AutomationElement.ClickCenterOfBounds(); Thread.Sleep(500);
            //Mouse.LeftDown(); Mouse.LeftUp(); Mouse.LeftDown(); Mouse.LeftUp(); Thread.Sleep(1000);
            //Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            Keyboard.Instance.Enter(input);
            //Keyboard.Instance.LeaveAllKeys();
            Thread.Sleep(1000);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(1000);

            Point CurrentLoan = new Point(665, 257);
			Mouse.Instance.Location = CurrentLoan;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(10000);

		}

        #endregion

      

    }
}
