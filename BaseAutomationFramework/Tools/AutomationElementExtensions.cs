using BaseAutomationFramework.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.Utility;

namespace BaseAutomationFramework
{
	public static class AutomationElementExtensions
	{
        private static TogglePattern _TogglePattern;
        private static LegacyIAccessiblePattern _LegacyIAccessiblePattern;

        public static bool xtGetCheckedState(this AutomationElement element)
        {
            bool IsChecked;
            _TogglePattern = Retry.For(() =>
                ((TogglePattern)element.GetCurrentPattern(TogglePattern.Pattern)),
                TimeSpan.FromSeconds(10));

            return IsChecked = _TogglePattern.Current.ToggleState == ToggleState.On;
        }
        public static string xtGetDefaultAction(this AutomationElement element)
        {
            _LegacyIAccessiblePattern = Retry.For(() =>
                ((LegacyIAccessiblePattern)element.GetCurrentPattern(LegacyIAccessiblePattern.Pattern)),
                TimeSpan.FromSeconds(10));

            return _LegacyIAccessiblePattern.Current.DefaultAction;
        }


        public static void WaitWhileBusy(this AutomationElement ae)
		{
			Retry.For(() => ShellIsBusy(ae), isBusy => isBusy, TimeSpan.FromSeconds(30));


		}

		static bool ShellIsBusy(AutomationElement ae)
		{
			var currentPropertyValue = ae.GetCurrentPropertyValue(AutomationElement.HelpTextProperty);
			return currentPropertyValue != null && ((string)currentPropertyValue).Contains("Busy");
		}

		public static void DoDefaultAction(this AutomationElement ae)
		{
			var thing = new BaseScreen();
			thing.setLegacyIAccessiblePattern(ae);
			thing.patt_LegacyIAccessiblePattern.DoDefaultAction();
		}

		public static Point Center(this Rect bounds)
		{
			return new Point((bounds.Left + bounds.Right) / 2.0, (bounds.Top + bounds.Bottom) / 2.0);
		}
		public static void ClickCenterOfBounds(this AutomationElement element, int maxWaitInSeconds = 30)
		{
			try
			{
				element.SetFocus();
			}
			catch (Exception e)
			{
			}
			Retry.For(() => Mouse.Instance.Click(MouseButton.Left, element.Current.BoundingRectangle.Center()), TimeSpan.FromSeconds(maxWaitInSeconds));
		}

		public static void SendKeys(this AutomationElement element, string input)
		{
			element.SetFocus();
			Keyboard.Instance.Enter(input);
			Keyboard.Instance.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.TAB);
			Thread.Sleep(300);
		}

		public static string GetText(this AutomationElement element)
		{
			object patternObj;
			if (element.TryGetCurrentPattern(ValuePattern.Pattern, out patternObj))
			{
				var valuePattern = (ValuePattern)patternObj;
				return valuePattern.Current.Value;
			}
			else if (element.TryGetCurrentPattern(TextPattern.Pattern, out patternObj))
			{
				var textPattern = (TextPattern)patternObj;
				return textPattern.DocumentRange.GetText(-1).TrimEnd('\r'); // often there is an extra '\r' hanging off the end.
			}
			else
			{
				return element.Current.Name;
			}
		}
	}
}
