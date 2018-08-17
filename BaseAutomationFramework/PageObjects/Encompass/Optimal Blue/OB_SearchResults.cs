using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.Utility;
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class OB_SearchResults : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("RequestDialog");
		public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow };
		public const bool SET_MAXIMIZED = true;

		public OB_SearchResults()
		{
			Set_Screen(scArray, SET_MAXIMIZED);

			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
			PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "ctl00_PageBody");
			for (int i = 0; i < 30; i++) // ~30 Seconds
			{
				Thread.Sleep(1000);
				aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
				aeScreen = aeScreen.FindFirst(TreeScope.Descendants, pcsubWindow);
				if (aeScreen != null)
					break;
			}

			if (aeScreen == null)
				throw new Exception("Screen is null!!!");
		}

		public static OB_SearchResults Initialize()
		{
			return new OB_SearchResults();
		}

		private PropertyCondition tbl_Rates = new PropertyCondition(AutomationElement.AutomationIdProperty, "ctl00_CPH_ctl100");
		//
		public void SelectRateClosestToZero()
		{
			AutomationElementCollection cells = null;
			int i = 0;
			do
			{
				aElement = null;
				aeScreen = null;
				Screen = null;
				GC.Collect();
				new OB_ProductSearch();
				Thread.Sleep(1000);
				aElement = aeScreen.FindFirst(TreeScope.Descendants, tbl_Rates);

			} while (aElement == null && ++i < 60);
			if (aElement == null)
				throw new Exception("Element could not be located!!!");

			cells = aElement.FindAll(TreeScope.Children, Condition.TrueCondition);

			List<AutomationElement> cellRates = new List<AutomationElement>();
			List<AutomationElement> cellSelect = new List<AutomationElement>();
			int colRates = 2;
			int colSelect = 7;
			int rowToSelect = 0;
			double cellRate;
			double lowestRate = Double.MaxValue;
			string rate = "";

			foreach (AutomationElement cell in cells)
			{
				setGridPattern(cell);
				if (patt_GridItemPattern.Current.Column == colRates && patt_GridItemPattern.Current.Row > 0)
					cellRates.Add(cell);
				if (patt_GridItemPattern.Current.Column == colSelect && patt_GridItemPattern.Current.Row > 0)
					cellSelect.Add(cell);
			}

			foreach (AutomationElement ae in cellRates)
			{
				rate = ae.FindFirst(TreeScope.Children, Condition.TrueCondition).Current.Name;
				rate = rate.Split('%')[0];
				cellRate = Math.Abs(Convert.ToDouble(rate));
				if (cellRate < lowestRate)
				{
					lowestRate = cellRate;
					setGridPattern(ae);
					rowToSelect = patt_GridItemPattern.Current.Row;
				}

			}
			cellSelect[rowToSelect - 1].ClickCenterOfBounds();
		}


		#region Loan Programs

		//private PropertyCondition SelectLoanProgram = new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "text");
		//
		//public OB_SearchResults lp_PEMCONF30YRFIXED_Click()
		//{
		//	aElement = aeScreen.FindFirst(TreeScope.Descendants, lp_PEMCONF30YRFIXED);
		//	aElement.ClickCenterOfBounds();
		//	Thread.Sleep(500);

		//	return this;
		//}

		public OB_SearchResults SelectLoanProgram_Click(string Input)
		{			
			AndCondition andCond = new AndCondition(
					new PropertyCondition(AutomationElement.NameProperty, Input),
					new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "text")
					);

			//aElement = aeScreen.FindFirst(TreeScope.Descendants, SelectLoanProgram);
			//aElement.SetFocus();
			//aElement.ClickCenterOfBounds();
			//Thread.Sleep(1000);
			AutomationElement item = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, andCond);
			item.ClickCenterOfBounds();
			Thread.Sleep(5000);

			return new OB_SearchResults();

			#endregion


		}
	}
}

