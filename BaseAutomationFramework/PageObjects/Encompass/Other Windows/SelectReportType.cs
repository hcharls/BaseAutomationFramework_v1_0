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
	public class SelectReportType : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("AuditSelectReportType");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		public SelectReportType()
		{
            Set_Screen(scArray, SET_MAXIMIZED);
            aeScreen = Screen.AutomationElement;
        }

		public static SelectReportType Initialize()
		{
			return new SelectReportType();
		}

		#region Buttons

		private SearchCriteria btn_OK = SearchCriteria.ByAutomationId("btnOK");

		//
		public void btn_OK_Click()
		{
			GetButton(btn_OK).Click();
		}

		#endregion

		#region Radio Buttons

		private SearchCriteria rdb_Preview = SearchCriteria.ByAutomationId("rdoPreview");
		//
		public SelectReportType rdb_Preview_Select()
		{
			GetRadioButton(rdb_Preview).Click();

			return new SelectReportType();
		}

		#endregion 

	}
}