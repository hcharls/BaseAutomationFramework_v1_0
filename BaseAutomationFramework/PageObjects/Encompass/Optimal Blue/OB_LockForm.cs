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

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class OB_LockForm : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("RequestDialog");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };
		public const bool SET_MAXIMIZED = true;

		public OB_LockForm()
		{
			Set_Screen(scArray, SET_MAXIMIZED);

			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "ctl00_PageBody");
			for (int i = 0; i < 30; i++) // ~30 Seconds
			{
				Thread.Sleep(1000);
				aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
				aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
				if (aeScreen != null)
					break;
			}

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static OB_LockForm Initialize()
		{
			return new OB_LockForm();
		}

		#region Buttons

		private PropertyCondition btn_UpdateEncompass = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnSubmit_Save360_TransferAndLogout_1");
		private PropertyCondition btn_RequestLock = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnSubmit_LockRequest360_TransferAndLogout_1");
		//

		public OB_LockForm btn_UpdateEncompass_Click()
		{
			int i = 0;
			do
			{
				aElement = null;
				aeScreen = null;
				Screen = null;
				GC.Collect();
				new OB_ProductSearch();
				Thread.Sleep(1000);
				aElement = fn_DoActionWhileCOMException<TreeScope, PropertyCondition, AutomationElement>((treeScope, condition) => {
					return aeScreen.FindFirst(treeScope, condition);
				}, TreeScope.Descendants, btn_UpdateEncompass);

				//aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_Submit);

			} while (aElement == null && ++i < 60);
			if (aElement == null)
				throw new Exception("Element could not be located!!!");
			aElement.ClickCenterOfBounds();

			return new OB_LockForm();
		}

		public OB_LockForm btn_RequestLock_Click()
		{
			int i = 0;
			do
			{
				aElement = null;
				aeScreen = null;
				Screen = null;
				GC.Collect();
				new OB_ProductSearch();
				Thread.Sleep(1000);
				aElement = fn_DoActionWhileCOMException<TreeScope, PropertyCondition, AutomationElement>((treeScope, condition) => {
					return aeScreen.FindFirst(treeScope, condition);
				}, TreeScope.Descendants, btn_RequestLock);

				//aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_Submit);

			} while (aElement == null && ++i < 60);
			if (aElement == null)
				throw new Exception("Element could not be located!!!");
			aElement.ClickCenterOfBounds();

			return new OB_LockForm();
		}

		#endregion







	}
}
