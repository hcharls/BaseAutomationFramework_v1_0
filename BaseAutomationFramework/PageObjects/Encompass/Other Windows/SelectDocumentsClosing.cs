using TestStack.White.UIItems.Finders;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class SelectDocumentsClosing : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("FormSelectionDialog");
        public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;

		public SelectDocumentsClosing()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static SelectDocumentsClosing Initialize()
		{
			return new SelectDocumentsClosing();
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
