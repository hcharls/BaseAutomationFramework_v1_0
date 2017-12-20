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
	public class DocumentDetails : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("DocumentDetailsDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, Encompass_eFolder.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		public DocumentDetails()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static DocumentDetails Initialize()
		{
			return new DocumentDetails();
		}

		#region Text Boxes

		private PropertyCondition txt_DocumentName = new PropertyCondition(AutomationElement.AutomationIdProperty, "1001");

		public DocumentDetails txt_DocumentName_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_DocumentName);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}

		internal object chk_Requested_Check(bool v)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Checkboxes

		private SearchCriteria chk_Requested = SearchCriteria.ByAutomationId("chkRequested");

		public DocumentDetails Chk_Requested_Check(bool Check)
		{
			ClickCheckBox(Check, chk_Requested);

			return this;
		}

		#endregion

		#region Buttons

		private SearchCriteria btn_Close = SearchCriteria.ByAutomationId("btnClose");
		private PropertyCondition btn_BrowseAndAttach = new PropertyCondition(AutomationElement.NameProperty, "btnAttachBrowse");
		//
		public DocumentDetails btn_BrowseAndAttach_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_BrowseAndAttach);
			aElement.ClickCenterOfBounds();
			new DocumentDetails();
			Thread.Sleep(1000);

			return new DocumentDetails();
		}
		//
		public void btn_Close_Click()
		{
			GetButton(btn_Close).Click();
		}

		#endregion


	}
}