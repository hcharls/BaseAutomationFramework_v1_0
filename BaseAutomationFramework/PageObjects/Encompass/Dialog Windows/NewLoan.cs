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
	public class NewLoan : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanTemplateSelectDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;

		public NewLoan()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static NewLoan Initialize()
		{
			return new NewLoan();
		}

		public void SelectItem_DirectConvPurchase()
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gvDirectory"));
			Point point = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 15), Convert.ToInt32(thing.Bounds.TopLeft.Y + 27.0 + 18.0));

			Mouse.Instance.Location = point;
			System.Threading.Thread.Sleep(500);
			Mouse.Instance.DoubleClick(MouseButton.Left);
		}
		
		public void SelectItem_DirectConvRefinance()
		{

			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gvDirectory"));
			Point point = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 15), Convert.ToInt32(thing.Bounds.TopLeft.Y + 63.0 + 18.0));

			Mouse.Instance.Location = point;
			System.Threading.Thread.Sleep(500);
			Mouse.Instance.DoubleClick(MouseButton.Left);
		}

		public void SelectItem_DirectFHAPurchase()
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gvDirectory"));
			Point point = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 15), Convert.ToInt32(thing.Bounds.TopLeft.Y + 45.0 + 18.0));

			Mouse.Instance.Location = point;
			System.Threading.Thread.Sleep(500);
			Mouse.Instance.DoubleClick(MouseButton.Left);
		}

		public void SelectItem_DirectFHARefinance()
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gvDirectory"));
			Point point = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 15), Convert.ToInt32(thing.Bounds.TopLeft.Y + 81.0 + 18.0));

			Mouse.Instance.Location = point;
			System.Threading.Thread.Sleep(500);
			Mouse.Instance.DoubleClick(MouseButton.Left);
		}

		public void SelectItem_DirectFHAStreamline()
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gvDirectory"));
			Point point = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 15), Convert.ToInt32(thing.Bounds.TopLeft.Y + 99.0 + 18.0));

			Mouse.Instance.Location = point;
			System.Threading.Thread.Sleep(500);
			Mouse.Instance.DoubleClick(MouseButton.Left);
		}

		public void SelectItem_DirectVAPurchase()
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gvDirectory"));
			Point point = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 15), Convert.ToInt32(thing.Bounds.TopLeft.Y + 117.0 + 18.0));

			Mouse.Instance.Location = point;
			System.Threading.Thread.Sleep(500);
			Mouse.Instance.DoubleClick(MouseButton.Left);
		}

		public void SelectItem_DirectVARefinance()
		{
			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gvDirectory"));
			Point point = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 15), Convert.ToInt32(thing.Bounds.TopLeft.Y + 135.0 + 18.0));

			Mouse.Instance.Location = point;
			System.Threading.Thread.Sleep(500);
			Mouse.Instance.DoubleClick(MouseButton.Left);
		}

		public void SelectTemplate(string ExactTemplateName)
		{
			var pnl = GetPanel(SearchCriteria.ByAutomationId("gcListView"));
			int maxCount = Convert.ToInt32(pnl.Name.Substring(pnl.Name.Length - 2, 1));

			Panel thing = PageObjects.BaseScreen.Screen.Get<Panel>(SearchCriteria.ByAutomationId("gvDirectory"));
			//Point startPoint = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 15), Convert.ToInt32(thing.Bounds.TopLeft.Y + 27.0));
			double increment = 0.0;
			for (int i = 0; i <= maxCount; i++)
			{				
				Point point = new Point(Convert.ToInt32(thing.Bounds.TopLeft.X + 15), Convert.ToInt32(thing.Bounds.TopLeft.Y + 27.0 + increment));
				Mouse.Instance.Location = point;
				System.Threading.Thread.Sleep(500);
				increment += 18.0;
			}
		}





		//int y = 257;
		//Mouse.Instance.Location = new Point(500, y);
		//System.Threading.Thread.Sleep(1000);
		//y += 18;
		//Mouse.Instance.Location = new Point(500, y);
		//System.Threading.Thread.Sleep(1000);
		//y += 18;
		//Mouse.Instance.Location = new Point(500, y);
		//System.Threading.Thread.Sleep(1000);
		//y += 18;
		//Mouse.Instance.Location = new Point(500, y);
		//System.Threading.Thread.Sleep(1000);
		//y += 18;
		//Mouse.Instance.Location = new Point(500, y);
		//System.Threading.Thread.Sleep(1000);
		//y += 18;
		//Mouse.Instance.Location = new Point(500, y);
		//System.Threading.Thread.Sleep(1000);
		//y += 18;
		//Mouse.Instance.Location = new Point(500, y);
		//System.Threading.Thread.Sleep(1000);
		//y += 18;
		//Mouse.Instance.Location = new Point(500, y);
		//System.Threading.Thread.Sleep(1000);
		//y += 18;
		//Mouse.Instance.Location = new Point(500, y);
		//System.Threading.Thread.Sleep(1000);

	}
}
