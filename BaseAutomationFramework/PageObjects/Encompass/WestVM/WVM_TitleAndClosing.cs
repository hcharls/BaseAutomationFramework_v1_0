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
	public class WVM_TitleAndClosing : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("TitleProviderDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;

		public WVM_TitleAndClosing()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static WVM_TitleAndClosing Initialize()
		{
			return new WVM_TitleAndClosing();
		}

		public static WVM_TitleAndClosing OpenFrom_MainMenu()
		{
			new EncompassMain()
				.mnu_Services_Click()
				.mnu_TitleAndClosing_Click();

			return new WVM_TitleAndClosing();
		}

		#region List Items

		//private SearchCriteria lstbx_Providers = SearchCriteria.ByAutomationId("myLst");
		////
		//private ListBox lstbx_Providers_Return()
		//{
		//	return GetListBox(lstbx_Providers);
		//}
		//public WVM_TitleAndClosing lstbx_Provider_Select(string ProviderName)
		//{
		//	lstbx_Providers_Return().Select(ProviderName);

		//	return new WVM_TitleAndClosing();
		//}

		public void Select_WestVMTitle_TEST()
		{
			Point WESTVMTitle = new Point(298, 163);
			Mouse.Instance.Location = WESTVMTitle;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(5000);
		}

		#endregion

		#region Buttons

		private SearchCriteria btn_Next = SearchCriteria.ByAutomationId("orderBtn");
		//

		public void btn_Next_Click()
		{
			GetButton(btn_Next).Click();
		}

		#endregion
	}
}