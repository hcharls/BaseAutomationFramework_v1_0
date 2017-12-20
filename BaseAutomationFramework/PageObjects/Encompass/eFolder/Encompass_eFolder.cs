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
using TestStack.White.UIItems.TabItems;
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	class Encompass_eFolder : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("eFolderDialog");
		public static SearchCriteria[] scArray = { scWindow };
		public const bool SET_MAXIMIZED = false;

		public Encompass_eFolder()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static Encompass_eFolder Initialize()
		{
			return new Encompass_eFolder();
		}

		public static Encompass_eFolder Open_eFolder()
		{
			new EncompassMain()
				.Open_eFolder();
				
			return new Encompass_eFolder();
		}

		#region Buttons

		private SearchCriteria btn_Close = SearchCriteria.ByAutomationId("btnClose");

		public void btn_Close_Click()
		{
			GetButton(btn_Close).Click();
		}

		#endregion

		#region Functions

		private PropertyCondition tab_Documents = new PropertyCondition(AutomationElement.NameProperty,"Documents View");

		public void AddNewDocument()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, tab_Documents);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Thread.Sleep(300);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.ALT);
			Keyboard.Instance.Enter("m");
			Keyboard.Instance.LeaveAllKeys();
			Thread.Sleep(250);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
			Keyboard.Instance.Enter("n");
			Keyboard.Instance.LeaveAllKeys();
			Thread.Sleep(250);
		}

		#endregion


	}
}