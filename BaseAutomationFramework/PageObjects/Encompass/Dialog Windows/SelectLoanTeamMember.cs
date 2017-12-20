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
	public class SelectLoanTeamMember : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByText("Select Loan Team Member");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		private AutomationElement aePanel = null;

		public SelectLoanTeamMember()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static SelectLoanTeamMember Initialize()
		{
			return new SelectLoanTeamMember();
		}


		public void PreProcReview_SelectLoanProcessor()
		{
			Point ScrollBarTop = new Point(1204, 335);
			Point ScrollBarBottom = new Point(1196, 703);
			Point LoanProcessor = new Point(744, 510);

			Mouse.Instance.Location = ScrollBarTop;
			Mouse.LeftDown();
			Mouse.Instance.Location = ScrollBarBottom;
			Mouse.LeftUp();
			Mouse.Instance.Location = LoanProcessor;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);

		}

	}
}