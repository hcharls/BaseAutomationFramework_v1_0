using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class ClosingDocsAudit : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("AuditDialog");
		public static SearchCriteria[] scArray = { scWindow };
		public const bool SET_MAXIMIZED = false;

		public ClosingDocsAudit()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static ClosingDocsAudit Initialize()
		{
			return new ClosingDocsAudit();
		}


		#region Combo Box

		private SearchCriteria cmb_OrderType = SearchCriteria.ByAutomationId("cboOrderType");

		public ClosingDocsAudit cmb_OrderType_SelectByText(string Input)
		{
			GetComboBox(cmb_OrderType).Select(Input);

			return new ClosingDocsAudit();
		}

		#endregion

		#region Buttons

		private SearchCriteria btn_OrderDocs = SearchCriteria.ByAutomationId("orderBtn");

		//
		public void btn_OrderDocs_Click()
		{
			GetButton(btn_OrderDocs).Click();
		}

		#endregion

	}
}
