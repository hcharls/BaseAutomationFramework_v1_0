///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Namespace>
///   Class:          <FileManager>
///   Description:    <File_Manager_window_in_eFolder>
///   Author:         <Hannah_Charls>           Date: <Novmeber_21_2017>
///   Notes:          <>
///   Revision History:
///   Name:				 Date:					Description:
///   
/// 
///------------------------------------------------------------------------------------------------------------------------

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
	public class FileManager : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("AllFilesDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, Encompass_eFolder.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		public FileManager()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static FileManager Initialize()
		{
			return new FileManager();
		}

		#region Buttons

		private SearchCriteria btn_Close = SearchCriteria.ByAutomationId("btnClose");

		public void btn_Close_Click()
		{
			GetButton(btn_Close).Click();

		}

		#endregion


	}
}