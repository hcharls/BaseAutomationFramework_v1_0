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
            Point LogTab = new Point(182, 182);
            Point Collapse = new Point(15, 281);
            
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
			
			Point FileStarted = new Point(82, 206);

			Mouse.Instance.Location = FileStarted;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_Application()
		{
			Point Application = new Point(82, 225);

			Mouse.Instance.Location = Application;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_PreProcReview()
		{
			Point PreProcReview = new Point(61, 245);

			Mouse.Instance.Location = PreProcReview;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_ProcPreApproval()
		{
			Point ProcPreApproval = new Point(66, 263);

			Mouse.Instance.Location = ProcPreApproval;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_SubmitToUW()
		{
			Point SubmitToUW = new Point(66, 280);

			Mouse.Instance.Location = SubmitToUW;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_InitialUWDecision()
		{
			Point InitialUWDecision = new Point(82, 297);

			Mouse.Instance.Location = InitialUWDecision;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_ConditionsSent()
		{
			Point ConditionsSent = new Point(82, 316);

			Mouse.Instance.Location = ConditionsSent;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_FinalUWApproval()
		{
			Point FinalUWApproval = new Point(66, 335);

			Mouse.Instance.Location = FinalUWApproval;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_QCReview()
		{
			Point QCReview = new Point(57, 368);

			Mouse.Instance.Location = QCReview;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_DocsOut()
        { 
			Point DocsOut = new Point(82, 369);

			Mouse.Instance.Location = DocsOut;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_DocsBack()
		{
			Point DocsBack = new Point(82, 389);

			Mouse.Instance.Location = DocsBack;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_FundingReview()
		{
			Point FundingReview = new Point(82, 405);

			Mouse.Instance.Location = FundingReview;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_Funding()
		{
			Point Funding = new Point(82, 425);

			Mouse.Instance.Location = Funding;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}
		

		public void SelectItem_Shipping()
		{
			Point Shipping = new Point(82, 442);

			Mouse.Instance.Location = Shipping;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_Purchase()
		{
			Point Purchase = new Point(82, 460);

			Mouse.Instance.Location = Purchase;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(3000);
		}

		public void SelectItem_Completion()
		{
			Point Completion = new Point(82, 478);

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
