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
	class Encompass_eFolder : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("eFolderDialog");
		public static SearchCriteria[] scArray = { scWindow };
		public const bool SET_MAXIMIZED = false;
		private AutomationElement aePanel = null;

		public Encompass_eFolder()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
			aePanel = null;
		}

		public static Encompass_eFolder Initialize()
		{
			return new Encompass_eFolder();
		}

		public static Encompass_eFolder Open_eFolder()
		{
			new EncompassMain()
				.Open_eFolder();
				Thread.Sleep(2000);
				
			return new Encompass_eFolder();
		}

		#region Panel

		private PropertyCondition pne_MainPanel = new PropertyCondition(AutomationElement.AutomationIdProperty, "pnlToolbar");
		//
		private void SetPanel()
		{
			int i = 0;
			do
			{
				aePanel = null;
				aeScreen = null;
				Screen = null;
				GC.Collect();
				new VerificationOfEmployment();
				Thread.Sleep(1000);
				aePanel = Screen.AutomationElement.FindFirst(TreeScope.Descendants, pne_MainPanel);

			} while (aePanel == null && i++ < 60);
			if (aePanel == null)
				throw new Exception("Could not find the embedded IE panel!!!");
		}

		#endregion

		#region Buttons

		private SearchCriteria btn_Close = SearchCriteria.ByAutomationId("btnClose");
		private SearchCriteria btn_Retrieve = SearchCriteria.ByAutomationId("btnRetrieve");
		private SearchCriteria btn_New = SearchCriteria.ByAutomationId("btnNew");

		public void btn_Close_Click()
		{
			GetButton(btn_Close).Click();
		}

		public void btn_Retrieve_Click()
		{
			GetButton(btn_Retrieve).Click();
		}
		public void btn_New_Click()
		{
			GetPanel(btn_New).Click();
		}

		#endregion

		#region Documents

		public void eFolder_UnderwriterReview(string Input)
		{
			SearchCriteria LoanNumber = SearchCriteria.ByAutomationId("SizableTextBox").AndIndex(2);
			Panel pne = GetPanel(LoanNumber);
			pne.AutomationElement.ClickCenterOfBounds();
			Thread.Sleep(500);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
			Keyboard.Instance.Enter("a");
			Keyboard.Instance.LeaveAllKeys();
			Thread.Sleep(250);
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			Point Document = new Point(165, 252);
			Mouse.Instance.Location = Document;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(10000);

		}

		#endregion

	}
}