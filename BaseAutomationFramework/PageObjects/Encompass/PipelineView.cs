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
	public class PipelineView : BaseScreen
	{
		public static SearchCriteria[] scArray = { EncompassMain.scWindow };
		public const bool SET_MAXIMIZED = true;

		public PipelineView()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}
		public static PipelineView Initialize()
		{
			return new PipelineView();
		}

		#region Buttons

		private SearchCriteria btn_NewLoan = SearchCriteria.ByAutomationId("btnNew");
		//
		public void btn_NewLoan_Click()
		{
			GetPanel(btn_NewLoan).Click();
		}

		#endregion

		#region

		public void Pipeline_som_SelectCurrentLoan(string Input)
		{
			Point LoanNumber = new Point(665, 238);
			Point CurrentLoan = new Point(665, 257);

			Mouse.Instance.Location = LoanNumber;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Keyboard.Instance.Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
			Thread.Sleep(3000);
			Mouse.Instance.Location = CurrentLoan;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(5000);
		}
		public void thingy()
		{
			SearchCriteria sc = SearchCriteria.ByAutomationId("SizableTextBox").AndIndex(0);
			Panel pne = GetPanel(sc);
			pne.AutomationElement.ClickCenterOfBounds();
			Thread.Sleep(500);
			Keyboard.Instance.Enter("12345");
		}

		#endregion

	}
}
