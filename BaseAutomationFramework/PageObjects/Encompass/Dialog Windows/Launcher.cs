using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems.Finders;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class Launcher : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("AuthenticationForm");
		public static SearchCriteria[] scArray = { scWindow };
		public const bool SET_MAXIMIZED = false;

		public Launcher()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static Launcher Initialize()
		{
			return new Launcher();
		}

		#region Buttons

		private SearchCriteria btn_Login = SearchCriteria.ByAutomationId("btnLogin");
		//
		public void btn_Login_Click()
		{
			GetButton(btn_Login).Click();
		}

		#endregion

		#region Combo Boxes

		private SearchCriteria cmb_EnvironmentID = SearchCriteria.ByAutomationId("cmbBoxUserid");
		//
		public Launcher cmb_EnvironmentID_SelectByText(string Input)
		{
			GetComboBox(cmb_EnvironmentID).Select(Input);

			return new Launcher();
		}

		#endregion


	}
}
