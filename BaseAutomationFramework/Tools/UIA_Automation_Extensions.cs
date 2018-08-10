using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TestStack.White.InputDevices;
using UIAutomationClient;

namespace BaseAutomationFramework.PageObjects
{
	
	public static class UIA_Extensions
	{
		public static CUIAutomationClass AUTOCLASS = new CUIAutomationClass();
		public static IUIAutomationElement ROOT = new CUIAutomationClass().GetRootElement();
		private static IUIAutomationLegacyIAccessiblePattern _LegacyIAccessiblePattern;
		private static IUIAutomationScrollItemPattern _ScrollItemPattern;
		private static IUIAutomationWindowPattern _WindowPattern;
		private static IUIAutomationExpandCollapsePattern _ExpandCollapsePattern;

		public static void xtExpand(this IUIAutomationElement element)
		{
			_ExpandCollapsePattern = (IUIAutomationExpandCollapsePattern)element.GetCurrentPattern(UIA_PatternIds.UIA_ExpandCollapsePatternId);
			_ExpandCollapsePattern.Expand();
		}
		public static void xtMaximizeWindow(this IUIAutomationElement element)
		{
			_WindowPattern = (IUIAutomationWindowPattern)element.GetCurrentPattern(UIA_PatternIds.UIA_WindowPatternId);
			_WindowPattern.SetWindowVisualState(WindowVisualState.WindowVisualState_Maximized);
		}
		public static void xtScrollIntoView(this IUIAutomationElement element)
		{
			_ScrollItemPattern = (IUIAutomationScrollItemPattern)element.GetCurrentPattern(UIA_PatternIds.UIA_ScrollItemPatternId);
			_ScrollItemPattern.ScrollIntoView();
		}
		public static IUIAutomationElementArray xtGetAllChildren(this IUIAutomationElement element)
		{
			return element.FindAll(TreeScope.TreeScope_Children, AUTOCLASS.CreateTrueCondition());
		}		
		public static string xtGetValue(this IUIAutomationElement element)
		{
			_LegacyIAccessiblePattern = (IUIAutomationLegacyIAccessiblePattern)element.GetCurrentPattern(UIA_PatternIds.UIA_LegacyIAccessiblePatternId);
			return _LegacyIAccessiblePattern.CurrentValue;
		}
		/// <summary>
		/// This method will attempt to set the LegacyIAccessible Value of an element and then press TAB.
		/// </summary>
		/// <param name="element"></param>
		/// <param name="value"></param>
		public static void xtSetValue(this IUIAutomationElement element, string value)
		{
			_LegacyIAccessiblePattern = (IUIAutomationLegacyIAccessiblePattern)element.GetCurrentPattern(UIA_PatternIds.UIA_LegacyIAccessiblePatternId);
			_LegacyIAccessiblePattern.SetValue(value);
			Thread.Sleep(100);
			Keyboard.Instance.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.TAB);
		}
		public static void xtClickCenterOfBounds(this IUIAutomationElement element, int maxWaitInSeconds = 30)
		{
			var rectangle = element.CurrentBoundingRectangle;
			Point center = new Point();
			center.X = rectangle.left + ((rectangle.right - rectangle.left) / 2);
			center.Y = rectangle.top + ((rectangle.bottom - rectangle.top) / 2);
			Mouse.Instance.Location = center;
			Mouse.Instance.Click(MouseButton.Left, center);
		}
        public static void xtHoverThenClickCenterOfBounds(this IUIAutomationElement element, int maxWaitInSeconds = 30)
        {
            var rectangle = element.CurrentBoundingRectangle;
            Point center = new Point();
            center.X = rectangle.left + ((rectangle.right - rectangle.left) / 2);
            center.Y = rectangle.top + ((rectangle.bottom - rectangle.top) / 2);
            Mouse.Instance.Location = center;
            Thread.Sleep(1000);
            Mouse.Instance.Click(MouseButton.Left, center);
        }

    }
}
