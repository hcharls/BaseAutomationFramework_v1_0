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
	public class DocumentDetails : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("DocumentDetailsDialog");
		public static SearchCriteria[] scArray = { scWindow };
		public const bool SET_MAXIMIZED = false;
		private AutomationElement aePanel = null;

		public DocumentDetails()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
			aePanel = null;
		}

		public static DocumentDetails Initialize()
		{
			return new DocumentDetails();
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
				new DocumentDetails();
				Thread.Sleep(1000);
				aePanel = Screen.AutomationElement.FindFirst(TreeScope.Descendants, pne_MainPanel);

			} while (aePanel == null && i++ < 60);
			if (aePanel == null)
				throw new Exception("Could not find the main panel!!!");
		}

		#endregion

		#region Combo Boxes

		//private PropertyCondition cmb_DocumentName = new PropertyCondition(AutomationElement.AutomationIdProperty, "cboTitle");

		//public DocumentDetails cmb_DocumentName_SendKeys(string Input)
		//{
		//	aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_DocumentName);
		//	aElement.SetFocus();
		//	aElement.ClickCenterOfBounds();
		//	Keyboard.Instance.Enter(Input);
		//	Thread.Sleep(1000);

		//	return new DocumentDetails();
		//}

		private SearchCriteria cmb_DocumentName = SearchCriteria.ByAutomationId("cboTitle");

		public DocumentDetails cmb_DocumentName_SelectByText(string Input)
		{
			GetComboBox(cmb_DocumentName).Enter(Input);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			Thread.Sleep(2000);

			return new DocumentDetails();
		}

		#endregion

		#region Checkboxes

		internal object Chk_Requested_Check(bool v)
		{
			throw new NotImplementedException();
		}
		internal object Chk_Reviewed_Check(bool v)
		{
			throw new NotImplementedException();
		}

		private SearchCriteria chk_Requested = SearchCriteria.ByAutomationId("chkRequested");
		private SearchCriteria chk_Reviewed = SearchCriteria.ByAutomationId("chkReviewed");

		public DocumentDetails chk_Requested_Check(bool Check)
		{
			ClickCheckBox(Check, chk_Requested);

			return this;
		}
		public DocumentDetails chk_Reviewed_Check(bool Check)
		{
			ClickCheckBox(Check, chk_Reviewed);

			return this;
		}

		#endregion

		#region Buttons

		private SearchCriteria btn_Close = SearchCriteria.ByAutomationId("btnClose");
		private SearchCriteria btn_BrowseAndAttach = SearchCriteria.ByAutomationId("btnAttachBrowse");
		
		public void btn_Close_Click()
		{
			GetButton(btn_Close).Click();
		}
		public void btn_BrowseAndAttach_Click()
		{
			GetPanel(btn_BrowseAndAttach).Click();
			Thread.Sleep(2000);
			Keyboard.Instance.Enter("1");
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
			
		}

		#endregion


	}
}