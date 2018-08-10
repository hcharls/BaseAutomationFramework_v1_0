using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.Utility;

namespace BaseAutomationFramework.PageObjects
{
    static class UIItemExtensions
    {
		// Extension class for any and all TestStack White UI Objects

		private static LegacyIAccessiblePattern patt_LegacyIAccessible = null;
		private static ScrollItemPattern patt_ScrollItemPattern = null;

		public static void xtScrollIntoView(this UIItem item)
		{
			patt_ScrollItemPattern = Retry.For(() => ((ScrollItemPattern)item.AutomationElement.GetCurrentPattern(ScrollItemPattern.Pattern)), TimeSpan.FromSeconds(10));
			patt_ScrollItemPattern.ScrollIntoView();
		}
		public static string xtGetValue(this UIItem item)
		{
			patt_LegacyIAccessible = Retry.For(() => ((LegacyIAccessiblePattern)item.AutomationElement.GetCurrentPattern(LegacyIAccessiblePattern.Pattern)), TimeSpan.FromSeconds(10));
			return patt_LegacyIAccessible.Current.Value;
		}

		public static void xtClickCenterOfBounds(this UIItem item)
        {
            item.AutomationElement.ClickCenterOfBounds();
        }

		public static void xtDoDefaultAction(this UIItem item)
		{
			patt_LegacyIAccessible = Retry.For(() => ((LegacyIAccessiblePattern)item.AutomationElement.GetCurrentPattern(LegacyIAccessiblePattern.Pattern)), TimeSpan.FromSeconds(10));
			try
			{
				patt_LegacyIAccessible.DoDefaultAction();
			}
			catch (System.Runtime.InteropServices.COMException e)
			{

			}
			
		}

		/// <summary>
		/// Custom Method to select from ComboBox (Tailored to Empower 8.0+)
		/// </summary>
		/// <param name="box">The ComboBox UIItem.</param>
		/// <param name="OptionToSelect">The option text that you wish to select.</param>
		public static void SelectFromComboBox(this ComboBox box, string OptionToSelect)
		{
			if (!box.Item(OptionToSelect).IsSelected)
				box.Enter(OptionToSelect);
			Thread.Sleep(100);
			if (!box.Item(OptionToSelect).IsSelected)
				throw new Exception($"ComboBox list item was not properly selected!!! Element Name: {box.Name} - Element ID: {box.Id} .");
			box.Collapse();
		}
    }
}
