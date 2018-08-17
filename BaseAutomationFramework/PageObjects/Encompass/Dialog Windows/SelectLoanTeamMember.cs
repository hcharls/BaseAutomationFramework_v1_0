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

		public void Application_SelectProcessingMgr()
		{
			Point ProcessingMgr = new Point(750, 563);

			Mouse.Instance.Location = ProcessingMgr;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void PreProcReview_SelectLoanProcessor()
		{
			Point ScrollBarTop = new Point(1205, 335);
			Point ScrollBarBottom = new Point(1205, 700);
			Point LoanProcessor = new Point(744, 602);

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

		public void ProcPreApproval_SelectLoanProcessor()
		{
			Point ScrollBarTop = new Point(1205, 335);
			Point ScrollBarBottom = new Point(1205, 708);
			Point LoanProcessor = new Point(744, 420);

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

		public void SubmitToUW_SelectUnderwriter()
		{
			Point ScrollBarTop = new Point(1205, 335);
			Point ScrollBarBottom = new Point(1205, 673);
			Point Underwriter = new Point(758, 564);

			Mouse.Instance.Location = ScrollBarTop;
			Mouse.LeftDown();
			Mouse.Instance.Location = ScrollBarBottom;
			Mouse.LeftUp();
			Mouse.Instance.Location = Underwriter;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void InitialUWDecision_SelectUnderwriter()
		{
			Point ScrollBarTop = new Point(1205, 335);
			Point ScrollBarBottom = new Point(1205, 700);
			Point LoanProcessor = new Point(744, 581);

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

		public void FinalUWApproval_SelectQualityControl()
		{
			Point ScrollBarTop = new Point(1205, 335);
			Point ScrollBarBottom = new Point(1205, 723);
			Point QualityControl = new Point(744, 330);

			Mouse.Instance.Location = ScrollBarTop;
			Mouse.LeftDown();
			Mouse.Instance.Location = ScrollBarBottom;
			Mouse.LeftUp();
			Mouse.Instance.Location = QualityControl;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void QCReview_SelectDocDrawer()
		{
			Point ScrollBarTop = new Point(1205, 335);
			Point ScrollBarBottom = new Point(1205, 700);
			Point DocDrawer = new Point(749, 673);

			Mouse.Instance.Location = ScrollBarTop;
			Mouse.LeftDown();
			Mouse.Instance.Location = ScrollBarBottom;
			Mouse.LeftUp();
			Mouse.Instance.Location = DocDrawer;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void DocsOut_SelectFunder()
		{
			Point ScrollBarTop = new Point(1205, 335);
			Point ScrollBarBottom = new Point(1205, 700);
			Point LoanProcessor = new Point(744, 581);

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

		public void DocsBack_SelectFunder()
		{
			Point ScrollBarTop = new Point(1205, 335);
			Point ScrollBarBottom = new Point(1205, 700);
			Point LoanProcessor = new Point(744, 581);

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

		public void FundingReview_SelectFunder()
		{
			Point ScrollBarTop = new Point(1205, 335);
			Point ScrollBarBottom = new Point(1205, 700);
			Point LoanProcessor = new Point(744, 581);

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

		public void Funding_SelectShipper()
		{
			Point ScrollBarTop = new Point(1205, 335);
			Point ScrollBarBottom = new Point(1205, 700);
			Point LoanProcessor = new Point(744, 581);

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

		public void Shipper_SelectSecondary()
		{
			Point ScrollBarTop = new Point(1205, 335);
			Point ScrollBarBottom = new Point(1205, 700);
			Point LoanProcessor = new Point(744, 581);

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

		public void Purchase_SelectPostCloser()
		{
			Point ScrollBarTop = new Point(1205, 335);
			Point ScrollBarBottom = new Point(1205, 700);
			Point LoanProcessor = new Point(744, 581);

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