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

		public void SelectItem_FileStarted()
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gvLog"));
			Point point = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 25), Convert.ToInt32(thing.Bounds.TopLeft.Y + 10));

			Mouse.Instance.Location = point;
			System.Threading.Thread.Sleep(500);
			Mouse.Instance.Click(MouseButton.Left);
			System.Threading.Thread.Sleep(1000);
		}

		public void SelectItem_Application()
		{

			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gvLog"));

			Point point = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 25), Convert.ToInt32(thing.Bounds.TopLeft.Y + 27));

			Mouse.Instance.Location = point;
			System.Threading.Thread.Sleep(500);
			Mouse.Instance.Click(MouseButton.Left);
			System.Threading.Thread.Sleep(1000);
		}

		public void SelectItem_PreProcReview()
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gvLog"));

			Point point = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 25), Convert.ToInt32(thing.Bounds.TopLeft.Y + 44));

			Mouse.Instance.Location = point;
			System.Threading.Thread.Sleep(500);
			Mouse.Instance.Click(MouseButton.Left);
			System.Threading.Thread.Sleep(1000);
		}

		public void SelectItem_InitialUWDecision()
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gvLog"));

			Point point = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 25), Convert.ToInt32(thing.Bounds.TopLeft.Y + 95));

			Mouse.Instance.Location = point;
			System.Threading.Thread.Sleep(500);
			Mouse.Instance.Click(MouseButton.Left);
			System.Threading.Thread.Sleep(1000);
		}

		public void SelectItem_ConditionsSent()
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gvLog"));

			Point point = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 25), Convert.ToInt32(thing.Bounds.TopLeft.Y + 113));

			Mouse.Instance.Location = point;
			System.Threading.Thread.Sleep(500);
			Mouse.Instance.Click(MouseButton.Left);
			System.Threading.Thread.Sleep(1000);
		}

		public void SelectItem_FinalUWApproval()
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gvLog"));

			Point point = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 25), Convert.ToInt32(thing.Bounds.TopLeft.Y + 132));

			Mouse.Instance.Location = point;
			System.Threading.Thread.Sleep(500);
			Mouse.Instance.Click(MouseButton.Left);
			System.Threading.Thread.Sleep(1000);
		}

		public void SelectItem_QCReview()
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gvLog"));

			Point point = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 25), Convert.ToInt32(thing.Bounds.TopLeft.Y + 150));

			Mouse.Instance.Location = point;
			System.Threading.Thread.Sleep(500);
			Mouse.Instance.Click(MouseButton.Left);
			System.Threading.Thread.Sleep(1000);
		}

		public void SelectItem_DocsOut()
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gvLog"));

			Point point = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 25), Convert.ToInt32(thing.Bounds.TopLeft.Y + 168));

			Mouse.Instance.Location = point;
			System.Threading.Thread.Sleep(500);
			Mouse.Instance.Click(MouseButton.Left);
			System.Threading.Thread.Sleep(1000);
		}

		public void SelectItem_DocsBack()
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gvLog"));

			Point point = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 25), Convert.ToInt32(thing.Bounds.TopLeft.Y + 186));

			Mouse.Instance.Location = point;
			System.Threading.Thread.Sleep(500);
			Mouse.Instance.Click(MouseButton.Left);
			System.Threading.Thread.Sleep(1000);
		}

		public void SelectItem_FundingReview()
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gvLog"));

			Point point = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 25), Convert.ToInt32(thing.Bounds.TopLeft.Y + 204));

			Mouse.Instance.Location = point;
			System.Threading.Thread.Sleep(500);
			Mouse.Instance.Click(MouseButton.Left);
			System.Threading.Thread.Sleep(1000);
		}

		public void SelectItem_Funding()
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gvLog"));

			Point point = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 25), Convert.ToInt32(thing.Bounds.TopLeft.Y + 222));

			Mouse.Instance.Location = point;
			System.Threading.Thread.Sleep(500);
			Mouse.Instance.Click(MouseButton.Left);
			System.Threading.Thread.Sleep(1000);
		}

		public void SelectItem_Shipping()
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gvLog"));

			Point point = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 25), Convert.ToInt32(thing.Bounds.TopLeft.Y + 240));

			Mouse.Instance.Location = point;
			System.Threading.Thread.Sleep(500);
			Mouse.Instance.Click(MouseButton.Left);
			System.Threading.Thread.Sleep(1000);
		}

		public void SelectItem_Purchase()
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gvLog"));

			Point point = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 25), Convert.ToInt32(thing.Bounds.TopLeft.Y + 258));

			Mouse.Instance.Location = point;
			System.Threading.Thread.Sleep(500);
			Mouse.Instance.Click(MouseButton.Left);
			System.Threading.Thread.Sleep(1000);
		}

		public void SelectItem_Completion()
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gvLog"));

			Point point = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 25), Convert.ToInt32(thing.Bounds.TopLeft.Y + 276));

			Mouse.Instance.Location = point;
			System.Threading.Thread.Sleep(500);
			Mouse.Instance.Click(MouseButton.Left);
			System.Threading.Thread.Sleep(1000);
		}
	}
}
