using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems.Finders;

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

	}
}
