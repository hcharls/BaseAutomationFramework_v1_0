using TestStack.White.UIItems.Finders;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class SelectDocumentsInitial : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("FormSelectionDialog");
		public static SearchCriteria[] scArray = { Encompass_eFolder.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;

		public SelectDocumentsInitial()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static SelectDocumentsInitial Initialize()
		{
			return new SelectDocumentsInitial();
		}

		#region Buttons

		private SearchCriteria btn_Send = SearchCriteria.ByAutomationId("btnSend");

		//
		public void btn_Send_Click()
		{
			GetButton(btn_Send).Click();
		}

		#endregion

	}
}
