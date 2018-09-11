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
	public class LogTab : BaseScreen
	{
		//public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow };
		public const bool SET_MAXIMIZED = false;
		public LogTab()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static LogTab Initialize()
		{
            return new LogTab();
		}

        public LogTab CollapseAll()
        {
            Point LogTab = new Point(180, 185);
            Point Collapse = new Point(25, 565);
            
            Mouse.Instance.Location = LogTab;
            Mouse.LeftDown();
            Mouse.LeftUp();
            Thread.Sleep(1000);
            Mouse.Instance.Location = Collapse;
            Mouse.RightDown();
            Mouse.RightUp();
            Thread.Sleep(500);
            Keyboard.Instance.Enter("c");
            Thread.Sleep(1000);
            return this;
        }

        public void SelectItem_FileStarted()
		{
			
			Point FileStarted = new Point(43, 218);

			Mouse.Instance.Location = FileStarted;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_Application()
		{
			Point Application = new Point(43, 225);

			Mouse.Instance.Location = Application;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_PreProcReview()
		{
			Point PreProcReview = new Point(43, 253);

			Mouse.Instance.Location = PreProcReview;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_ProcPreApproval()
		{
			Point ProcPreApproval = new Point(43, 270);

			Mouse.Instance.Location = ProcPreApproval;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_SubmitToUW()
		{
			Point SubmitToUW = new Point(43, 289);

			Mouse.Instance.Location = SubmitToUW;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_InitialUWDecision()
		{
			Point InitialUWDecision = new Point(43, 307);

			Mouse.Instance.Location = InitialUWDecision;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_ConditionsSent()
		{
			Point ConditionsSent = new Point(43, 324);

			Mouse.Instance.Location = ConditionsSent;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_FinalUWApproval()
		{
			Point FinalUWApproval = new Point(43, 343);

			Mouse.Instance.Location = FinalUWApproval;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_QCReview()
		{
			Point QCReview = new Point(43, 361);

			Mouse.Instance.Location = QCReview;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_DocsOut()
        { 
			Point DocsOut = new Point(43, 379);

			Mouse.Instance.Location = DocsOut;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_DocsBack()
		{
			Point DocsBack = new Point(43, 397);

			Mouse.Instance.Location = DocsBack;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_FundingReview()
		{
			Point FundingReview = new Point(43, 415);

			Mouse.Instance.Location = FundingReview;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_Funding()
		{
			Point Funding = new Point(43, 433);

			Mouse.Instance.Location = Funding;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}
		

		public void SelectItem_Shipping()
		{
			Point Shipping = new Point(43, 452);

			Mouse.Instance.Location = Shipping;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_Purchase()
		{
			Point Purchase = new Point(43, 470);

			Mouse.Instance.Location = Purchase;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_Completion()
		{
			Point Completion = new Point(43, 486);

			Mouse.Instance.Location = Completion;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		//Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gvLog"));

		//Point point = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 25), Convert.ToInt32(thing.Bounds.TopLeft.Y + 276));

		//Mouse.Instance.Location = point;
		//System.Threading.Thread.Sleep(500);
		//Mouse.Instance.Click(MouseButton.Left);
		//System.Threading.Thread.Sleep(1000);

	}
}
