using BaseAutomationFramework.Tests;
using NLog;
using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.TabItems;
using TestStack.White.UIItems.TableItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.Utility;
using TestStack.White.WindowsAPI;
using System.Windows;
using BaseAutomationFramework.Tools;
using System.Diagnostics;
using TestStack.White.Configuration;
using TestStack.White.AutomationElementSearch;
using System.Drawing;

namespace BaseAutomationFramework.PageObjects
{
	public class BaseScreen
	{
		public static Logger logger = LogManager.GetCurrentClassLogger();

		public const double RETRYTIMEOUT_DEFAULT = 10.0;
		public static double RetryTimeout = 10.0;
		public static Window Screen { get; set; }
		public static AutomationElement aeScreen { get; set; }
		public static AutomationElement aElement { get; set; }
		public AutomationElement[] allElements;
		public LegacyIAccessiblePattern patt_LegacyIAccessiblePattern { get; private set; }
		public GridItemPattern patt_GridItemPattern { get; private set; }
		public static int iterationCounter = 0;

		#region Window Setters

		//public BaseScreen Set_Screen(Condition condition, bool isMaximized)
		//{
		//	return this;
		//}

		public BaseScreen Set_Screen(SearchCriteria[] scParams, bool isMaximized)
		{
			try
			{
				BaseTest.TestedApplication.WaitWhileBusy();
			}
			catch (InvalidOperationException e) { Thread.Sleep(5000); } //consume & wait, some PO may throw here (like LoanDepotLauncher) before GUI exists

			Screen = WaitUntilWindowReady(scParams[0], scParams.Length > 1 ? scParams[1] : null, scParams.Length > 2 ? scParams[2] : null, RetryTimeout);
			if(Screen == null)
				throw new Exception("Screen must not be null");

			if(isMaximized)
			{
				Screen.DisplayState = DisplayState.Maximized;
				Screen.WaitTill(() => Screen.DisplayState == DisplayState.Maximized, TimeSpan.FromSeconds(10));
			}

			return this;
		}

		public BaseScreen fn_SetScreen_DynamicWindowStructure(SearchCriteria windowSC, bool isMaximized, int maxAttempts = 10)
		{
			Screen = null;
			int cnt = -1;
			while (++cnt != maxAttempts)
			{
				List<Window> windows = Retry.For(() => BaseTest.TestedApplication.GetWindows(), TimeSpan.FromSeconds(RetryTimeout));
				foreach (Window win in windows) //outter windows in heirarchy
					if (checkForWindowExists(win, windowSC, isMaximized))
						return this;
				System.Threading.Thread.Sleep(500);
			}
			throw new Exception("Could not identify the window");
		}

		/// <summary>
		/// Intended for use with problematic windows only!
		/// </summary>
		/// <param name="titleText"></param>
		/// <param name="isMaximized"></param>
		/// <returns></returns>
		public BaseScreen fn_SetScreen_ByTitle(string titleText, bool isMaximized)
		{
			Thread.Sleep(500);
			try
			{
				BaseTest.TestedApplication.WaitWhileBusy();
			}
			catch (InvalidOperationException e) { Thread.Sleep(5000); } //consume & wait, some PO may throw here (like LoanDepotLauncher) before GUI exists

			Screen = Retry.For(() => BaseTest.TestedApplication.Find(s => s.Equals(titleText), InitializeOption.NoCache), TimeSpan.FromSeconds(RetryTimeout));
			if (Screen == null)
				throw new NullReferenceException("Screen must not be null");
			else if(isMaximized)
			{
				Screen.DisplayState = DisplayState.Maximized;
				Screen.WaitTill(() => Screen.DisplayState == DisplayState.Maximized, TimeSpan.FromSeconds(10));
			}
			//Thread.Sleep(1000);
			//Screen.ReloadIfCached();
			//Screen.ReInitialize(InitializeOption.NoCache);
			Screen.WaitWhileBusy();
			Screen.WaitTill(() => Screen.Enabled, TimeSpan.FromSeconds(10));
			Screen.WaitTill(() => Screen.Visible, TimeSpan.FromSeconds(10));
			Screen.Focus();
			return this;
		}

		/// <summary>
		/// This method attempts to make a "best effort" to locate a window denoted by the given locator heirarchy of tier1-3 locators (where 2 & 3 are optional).
        /// This method will make attempt to find EACH PART of the heirarchy or hit the provided timeout. If the f
		/// </summary>
		/// <param name="app"></param>
		/// <param name="ParentWindowLocator"></param>
		/// <param name="ModalLocator"></param>
		/// <param name="ChildModalLocator"></param>
		/// <param name="timeoutSeconds"></param>
		/// <returns></returns>
        public static Window WaitUntilWindowReady(SearchCriteria ParentWindowLocator, SearchCriteria ModalLocator = null, SearchCriteria ChildModalLocator = null, double timeoutSeconds = 10.0)
        {
			Window nestedWindow = Retry.For(() => BaseTest.TestedApplication.GetWindow(ParentWindowLocator, InitializeOption.NoCache), TimeSpan.FromSeconds(timeoutSeconds));
            if (nestedWindow == null)
                throw new Exception("Failed to locate window, failed at tier1");
            else if (ModalLocator != null)
            {
                nestedWindow = Retry.For(() => nestedWindow.ModalWindow(ModalLocator, InitializeOption.NoCache), TimeSpan.FromSeconds(timeoutSeconds));
                if (nestedWindow == null)
                    throw new Exception("Failed to locate window, failed at tier2");
                else if (ChildModalLocator != null)
                {
                    nestedWindow = Retry.For(() => nestedWindow.ModalWindow(ChildModalLocator, InitializeOption.NoCache), TimeSpan.FromSeconds(timeoutSeconds));
                    if (nestedWindow == null)
                        throw new Exception("Failed to locate window, failed at tier3");
                }
            }

            nestedWindow.WaitTill(() => nestedWindow.Enabled , TimeSpan.FromSeconds(timeoutSeconds));
            nestedWindow.WaitTill(() => nestedWindow.Visible , TimeSpan.FromSeconds(timeoutSeconds));
            nestedWindow.WaitWhileBusy();
            return nestedWindow;
        }

		/// <summary>
		/// This method attempts to make a "best effort" to locate a window denoted by the given locator heirarchy of tier1-3 locators (where 2 & 3 are optional).
		/// This method will make attempt to find EACH PART of the heirarchy or hit the provided timeout. If the f
		/// </summary>
		/// <param name="SCparams">A SearchCriteria Array that contains the parent/child structure of where the window is located.</param>
		/// <param name="timeoutSeconds"></param>
		/// <returns></returns>
		public void SetScreenAndWaitWhileBusy(SearchCriteria[] SCparams, double timeoutSeconds = 10.0)
		{
			Window nestedWindow = null;

			switch (SCparams.Length)
			{
				case 0:
					break;
				case 1:					
					nestedWindow = Retry.For(() => BaseTest.TestedApplication.GetWindow(SCparams[0], InitializeOption.NoCache), TimeSpan.FromSeconds(timeoutSeconds));
					if (nestedWindow == null)
						throw new Exception("Failed to locate window, failed at tier1");
					break;
				case 2:
					nestedWindow = Retry.For(() => BaseTest.TestedApplication.GetWindow(SCparams[0], InitializeOption.NoCache), TimeSpan.FromSeconds(timeoutSeconds));
					nestedWindow = Retry.For(() => nestedWindow.ModalWindow(SCparams[1], InitializeOption.NoCache), TimeSpan.FromSeconds(timeoutSeconds));
					if (nestedWindow == null)
						throw new Exception("Failed to locate window, failed at tier2");
					break;
				case 3:
					nestedWindow = Retry.For(() => BaseTest.TestedApplication.GetWindow(SCparams[0], InitializeOption.NoCache), TimeSpan.FromSeconds(timeoutSeconds));
					nestedWindow = Retry.For(() => nestedWindow.ModalWindow(SCparams[1], InitializeOption.NoCache), TimeSpan.FromSeconds(timeoutSeconds));
					nestedWindow = Retry.For(() => nestedWindow.ModalWindow(SCparams[2], InitializeOption.NoCache), TimeSpan.FromSeconds(timeoutSeconds));
					if (nestedWindow == null)
						throw new Exception("Failed to locate window, failed at tier3");
					break;
				default:
					break;
			}
			nestedWindow.WaitTill(() => nestedWindow.Enabled , TimeSpan.FromSeconds(timeoutSeconds));
			nestedWindow.WaitTill(() => nestedWindow.Visible , TimeSpan.FromSeconds(timeoutSeconds));
			nestedWindow.WaitWhileBusy();
			Screen = nestedWindow;
		}

		public static Window CheckIfWindowReady(SearchCriteria[] scParams)
		{
			return CheckIfWindowReady(scParams[0], scParams.Length > 1 ? scParams[1] : null, scParams.Length > 2 ? scParams[2] : null);
		}

        /// <summary>
        /// Unlike WaitUnitlWindowReady() this method performs a single check for the windows presence denoted by the teir1-3 locators (where 2 and 3 are optional parameters)
        /// If you know a window will become ready, use WaitUntilWindowReady(),
        /// If you are unsure of a windows existence DO NOT use this method, BaseScreen.CheckForWindow may be more appropriate.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="Tier1Locator"></param>
        /// <param name="Tier2Locator">optional param</param>
        /// <param name="Tier3Locator">optional param</param>
        /// <returns>The Window if it is ready, null otherwise</returns>
        public static Window CheckIfWindowReady(SearchCriteria Tier1Locator, SearchCriteria Tier2Locator = null, SearchCriteria Tier3Locator = null)
        {
            Window nestedWindow = null;
            try
            {
				nestedWindow = BaseTest.TestedApplication.GetWindow(Tier1Locator, InitializeOption.NoCache);
            }
            catch(Exception e)
            {
                nestedWindow = null;
            }
            if (nestedWindow == null)
                return null;
            if (Tier2Locator != null)
            {
                try
                {
                    nestedWindow = nestedWindow.ModalWindow(Tier2Locator, InitializeOption.NoCache);
                }
                catch(Exception e)
                {
                    nestedWindow = null;
                }
                if (nestedWindow == null)
                    return null;
                if (Tier3Locator != null)
                    try
                    {
                        nestedWindow = nestedWindow.ModalWindow(Tier3Locator, InitializeOption.NoCache);
                    }
                    catch(Exception e)
                    {
                        nestedWindow = null;
                    }
            }

            if (nestedWindow != null && nestedWindow.Enabled && nestedWindow.Visible)
            {
                try
                {
                    nestedWindow.WaitWhileBusy();
                }
                catch(Exception e)
                {
                    return null;
                }
                return nestedWindow;
            }
            else
                return null;
        }

		#endregion

		#region BaseLocators

	
		public void DoDefaultAction(AutomationElement AE)
		{
			setLegacyIAccessiblePattern(AE);
			patt_LegacyIAccessiblePattern.DoDefaultAction();
		}

		public void DoDefaultAction(UIItem item)
		{
			setLegacyIAccessiblePattern(item.AutomationElement);
			patt_LegacyIAccessiblePattern.DoDefaultAction();
		}
		public void setGridPattern(AutomationElement AE)
		{
			patt_GridItemPattern = Retry.For(() =>
				((GridItemPattern)AE.GetCurrentPattern(GridItemPattern.Pattern)),
				TimeSpan.FromSeconds(10));
		}

		public void setLegacyIAccessiblePattern(AutomationElement AE)
		{
			patt_LegacyIAccessiblePattern = patt_LegacyIAccessiblePattern = Retry.For(() =>
				((LegacyIAccessiblePattern)AE.GetCurrentPattern(LegacyIAccessiblePattern.Pattern)),
				TimeSpan.FromSeconds(10));
		}
		public string getLegacyIAccessiblePattern_Value(AutomationElement AE)
		{
			setLegacyIAccessiblePattern(AE);
			return Retry.For(() => patt_LegacyIAccessiblePattern.Current.Value, TimeSpan.FromSeconds(5));
		}
		public string getLegacyIAccessiblePattern_Value(UIItem uiItem)
		{
			setLegacyIAccessiblePattern(uiItem.AutomationElement);
			return Retry.For(() => patt_LegacyIAccessiblePattern.Current.Value, TimeSpan.FromSeconds(5));
		}		
		
		public AutomationElement GetElement(Condition condition, bool popup=false, int timeoutInSeconds=15)
		{
			AutomationElement element = null;

			if (popup)
			{
				element = Screen.Popup.AutomationElement;	
			}
			else
			{
				element = Screen.AutomationElement;
			}

			return Retry.For(() => element.FindFirst(TreeScope.Descendants, condition), TimeSpan.FromSeconds(timeoutInSeconds));
		}

		/// <summary>
		/// Returns a button object.
		/// </summary>
		/// <param name="gettype">The search criteria type to locate the object.</param>
		public Button GetButton(SearchCriteria GetType)
		{
			return Retry.For(() => Screen.Get<Button>(GetType), TimeSpan.FromSeconds(10));
		}

		/// <summary>
		/// Returns a textbox object.
		/// </summary>
		/// <param name="gettype">The search criteria type to locate the object.</param>
		public TextBox GetTextBox(SearchCriteria GetType)
		{
			TextBox uiItem = Retry.For(() => Screen.Get<TextBox>(GetType), TimeSpan.FromSeconds(10));
			return uiItem;
		}

		/// <summary>
		/// Returns a CheckBox object.
		/// </summary>
		/// <param name="gettype">The search criteria type to locate the object.</param>
		public CheckBox GetCheckBox(SearchCriteria GetType)
		{
			CheckBox uiItem = Retry.For(() => Screen.Get<CheckBox>(GetType), TimeSpan.FromSeconds(10));
			return uiItem;
		}

		/// <summary>
		/// Returns a combobox object.
		/// </summary>
		/// <param name="gettype">The search criteria type to locate the object.</param>
		public ComboBox GetComboBox(SearchCriteria GetType)
		{
			ComboBox uiItem = Retry.For(() => Screen.Get<ComboBox>(GetType), TimeSpan.FromSeconds(10));
			return uiItem;
		}

		/// <summary>
		/// Returns a Panel object (Pane UIitem).
		/// </summary>
		/// <param name="gettype">The search criteria type to locate the object.</param>
		public Panel GetPanel(SearchCriteria GetType)
		{
			Panel uiItem = Retry.For(() => Screen.Get<Panel>(GetType), TimeSpan.FromSeconds(5));
			return uiItem;
		}		

		/// <summary>
		/// Returns a ListBox object.
		/// </summary>
		/// <param name="gettype">The search criteria type to locate the object.</param>
		public ListBox GetListBox(SearchCriteria GetType)
		{
			ListBox uiItem = Retry.For(() => Screen.Get<ListBox>(GetType), TimeSpan.FromSeconds(5));
			return uiItem;
		}
		/// <summary>
		/// Returns a listview object.
		/// </summary>
		/// <param name="gettype">The search criteria type to locate the object.</param>
		public ListView GetListView(SearchCriteria GetType)
		{
			ListView uiItem = Retry.For(() => Screen.Get<ListView>(GetType), TimeSpan.FromSeconds(5));
			return uiItem;
		}

		/// <summary>
		/// Returns a tab object.
		/// </summary>
		/// <param name="gettype">The search criteria type to locate the object.</param>
		public Tab GetTab(SearchCriteria GetType)
		{
			Tab uiItem = Retry.For(() => Screen.Get<Tab>(GetType), TimeSpan.FromSeconds(5));
			return uiItem;
		}

        public Table GetTable(SearchCriteria GetType)
        {
            Table table = Retry.For(() => Screen.Get<Table>(GetType), TimeSpan.FromSeconds(5));
            return table;
        }

		/// <summary>
		/// Returns a label object.
		/// </summary>
		/// <param name="gettype">The search criteria type to locate the object.</param>
		public Label GetLabel(SearchCriteria GetType)
		{
			Label uiItem = Retry.For(() => Screen.Get<Label>(GetType), TimeSpan.FromSeconds(5));
			return uiItem;
		}

		/// <summary>
		/// Returns a MenuBar object.
		/// </summary>
		/// <param name="gettype">The search criteria type to locate the object.</param>
		public MenuBar GetMenuBar(SearchCriteria GetType)
		{
			MenuBar uiItem = Retry.For(() => Screen.Get<MenuBar>(GetType), TimeSpan.FromSeconds(5));
			return uiItem;
		}
		/// <summary>
		/// Returns a Menu object.
		/// </summary>
		/// <param name="gettype">The search criteria type to locate the object.</param>
		public Menu GetMenuItem(SearchCriteria GetType)
		{
			Menu uiItem = Retry.For(() => Screen.Get<Menu>(GetType), TimeSpan.FromSeconds(5));
			return uiItem;
		}

		/// <summary>
		/// Returns a RadioButton object.
		/// </summary>
		/// <param name="gettype">The search criteria type to locate the object.</param>
		public RadioButton GetRadioButton(SearchCriteria GetType)
		{
			RadioButton uiItem = Retry.For(() => Screen.Get<RadioButton>(GetType), TimeSpan.FromSeconds(5));
			return uiItem;
		}

		/// <summary>
		/// Returns a StatusStrip object.
		/// </summary>
		/// <param name="gettype">The search criteria type to locate the object.</param>
		public StatusStrip GetStatusStrip(SearchCriteria GetType)
		{
			StatusStrip uiItem = Retry.For(() => Screen.Get<StatusStrip>(GetType), TimeSpan.FromSeconds(5));
			return uiItem;
		}

		/// <summary>
		/// Returns an array of UIItem defined by ControlType
		/// </summary>
		/// <param name="gettype">The search criteria type to locate the object.</param>
		public IUIItem[] GetMultiple(ControlType ControlType)
		{
			return GetMultiple(SearchCriteria.ByControlType(ControlType));
		}

		/// <summary>
		/// Returns an array of UIItem defined by the speicified SearchCriteria
		/// </summary>
		/// <param name="gettype">The search criteria type to locate the object.</param>
		public IUIItem[] GetMultiple(SearchCriteria searchCriteria)
		{
			return Retry.For(() => Screen.GetMultiple(searchCriteria), TimeSpan.FromSeconds(5));
		}

		#endregion

		#region BaseAction

		public void EnterTextToTextBox(AutomationElement ae, string TextToEnter, int maxWaitInSeconds = 60)
		{
			string currentText = null;
			int i = 0;
			ae.SetFocus();
			ae.ClickCenterOfBounds();
			if (string.IsNullOrEmpty(currentText))
				Keyboard.Instance.Enter(TextToEnter);
			do
			{
				Thread.Sleep(10);
				currentText = getLegacyIAccessiblePattern_Value(AutomationElement.FocusedElement);
				if (currentText == TextToEnter)
					return;
				Thread.Sleep(500);
				i++;
			} while (i < maxWaitInSeconds * 2);

			throw new Exception(string.Format("Was not able to set the text of the textbox in the alotted time of {0} seconds!!!", maxWaitInSeconds));
		}

		public void SelectFromComboBox(AutomationElement box, string Option, int numberOfOptions = 150)
		{
			string currentOption = null;
			AutomationElement ae = box;
			Option = Option.ToLower();
			// Pressing space should set the option to the blank default
			ae.SetFocus();
			Thread.Sleep(250);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.SPACE);

			for (int i = 0; i < numberOfOptions; i++)
			{
				ae.SetFocus();
				Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DOWN);
				Thread.Sleep(10);
				currentOption = getLegacyIAccessiblePattern_Value(AutomationElement.FocusedElement).ToLower();
				if (currentOption == Option)
					return;
			}
			throw new Exception("Did not find intended ComboBox Option or reached the end of the list of Options!!!");
		}
		
		public static void DeleteField_KeyCombo()
		{
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.SHIFT);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			Keyboard.Instance.LeaveAllKeys();
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.DELETE);
		}
		public static void TabShiftTab()
		{
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.SHIFT);
			Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.TAB);
			Keyboard.Instance.LeaveAllKeys();
		}

		/// <summary>
		/// Given a function & parameter this function will continue to try and call the function until it does not throw a COMException.
		/// Example use:
		/// StatusStrip ss = fn_DoActionWhileCOMException(GetStatusStrip, myStatusStripSC)
		/// </summary>
		/// <typeparam name="I">input parameter type</typeparam>
		/// <typeparam name="O">return type</typeparam>
		/// <param name="functionToCall"></param>
		/// <param name="sc"></param>
		/// <param name="maxAttempts"></param>
		/// <returns></returns>
		public static O fn_DoActionWhileCOMException<I, O>(Func<I, O> functionToCall, I param, int maxAttempts = 20)
		{
			int attempts = -1;
			while (++attempts != maxAttempts)
				try
				{					
					return functionToCall.Invoke(param);
				}
				catch (COMException e)
				{
					Thread.Sleep(100);
				}
				catch (WhiteException e)
				{
					Thread.Sleep(100);
				}

			throw new Exception("fn_DoActionWhileCOMException failed to wait for function to stop throwing COMException");
		}
		public static O fn_DoActionWhileCOMException<I, I2, O>(Func<I, I2, O> functionToCall, I param, I2 param2, int maxAttempts = 20)
		{
			int attempts = -1;
			while (++attempts != maxAttempts)
				try
				{
					return functionToCall.Invoke(param, param2);
				}
				catch (COMException e)
				{
					Thread.Sleep(100);
				}
				catch (WhiteException e)
				{
					Thread.Sleep(100);
				}

			throw new Exception("fn_DoActionWhileCOMException failed to wait for function to stop throwing COMException");
		}



		/// <summary>
		/// Given a function, this function will continue to try and call the function until it does not throw a COMException.
		/// Example use:
		/// StatusStrip ss = fn_DoActionWhileCOMException(GetStatusStrip, myStatusStripSC);
		/// </summary>
		/// <typeparam name="O">Return type</typeparam>
		/// <param name="functionToCall"></param>
		/// <param name="maxAttempts"></param>
		/// <returns></returns>
		public static O fn_DoActionWhileCOMException<O>(Func<O> functionToCall, int maxAttempts = 20)
		{
			int attempts = -1;
			while (++attempts != maxAttempts)
				try
				{
					return functionToCall.Invoke();
				}
				catch (COMException e)
				{
					Thread.Sleep(100);
				}
				catch (WhiteException e)
				{
					Thread.Sleep(100);
				}

			throw new Exception("fn_DoActionWhileCOMException failed to wait for function to stop throwing COMException");
		}
		/// <summary>
		/// Given a function, this function will continue to try and call the function until it does not throw a COMException.
		/// Example use:
		/// StatusStrip ss = fn_DoActionWhileCOMException(GetStatusStrip, myStatusStripSC)
		/// </summary>
		/// <typeparam name="O">Return type</typeparam>
		/// <param name="functionToCall"></param>
		/// <param name="maxAttempts"></param>
		/// <returns></returns>
		public static void fn_DoActionWhileCOMException(Action functionToCall, int maxAttempts = 20)
		{
			int attempts = -1;
			while (++attempts != maxAttempts)
			{
				try
				{
					functionToCall.Invoke();
					return;
				}
				catch (COMException e)
				{
					Thread.Sleep(100);
				}
				catch (WhiteException e)
				{
					Thread.Sleep(100);
				}
			}				

			throw new Exception("fn_DoActionWhileCOMException failed to wait for function to stop throwing COMException");
		}
		public static void fn_DoActionWhileCOMException<I>(Action<I> functionToCall, I param, int maxAttempts = 20)
		{
			int attempts = -1;
			while (++attempts != maxAttempts)
			{
				try
				{
					functionToCall.Invoke(param);
					return;
				}
				catch (COMException e)
				{
					Thread.Sleep(100);
				}
				catch (WhiteException e)
				{
					Thread.Sleep(100);
				}
			}

			throw new Exception("fn_DoActionWhileCOMException failed to wait for function to stop throwing COMException");
		}
		

        public void ClickCheckBox(bool desiredState, SearchCriteria chk_Identifier)
        {
            CheckBox cb = GetCheckBox(chk_Identifier);
            if (desiredState != cb.IsSelected)
                cb.Click();
        }

		public bool waitForControlToEnable(UIItem Control, int maxWait = 10)
		{
			bool enabled = false;
			int counter = 0;
			do
			{
				enabled = Control.Enabled;
				if (enabled)
					return true;
				else
				{
					Thread.Sleep(1000);
					counter++;					
				}					

			} while (!enabled && counter < maxWait);
			
			return enabled;
		}



        //public static void clickElement_Rectangle(UIItem uiItem)
        //{
        //    Mouse.Instance.Click(CenterOfBounds(uiItem.AutomationElement.Current.BoundingRectangle));
        //}
        //public static void clickElement_Rectangle(AutomationElement AE)
        //{
        //    Mouse.Instance.Click(CenterOfBounds(AE.Current.BoundingRectangle));
        //}
        //public static void doubleClickElement_Rectangle(AutomationElement AE)
        //{
        //    Mouse.Instance.DoubleClick(CenterOfBounds(AE.Current.BoundingRectangle));
        //}
        ///// <summary>
        ///// Returns the center of System.Windows.Rect, this could probably be moved to a helper math class.
        ///// </summary>
        ///// <param name="bounds"></param>
        ///// <returns></returns>
        //private static System.Drawing.Point CenterOfBounds(Rect bounds)
        //{
        //    return new System.Drawing.Point((bounds.Left + bounds.Right) / 2.0, (bounds.Top + bounds.Bottom) / 2.0);
        //}

        public static string transformValidDateString(string DateTime_ShortDateString)
		{
			string[] dtArray = DateTime_ShortDateString.Split('/');
			if (dtArray[0].Length == 1)
				dtArray[0] = "0" + dtArray[0];
			if (dtArray[1].Length == 1)
				dtArray[1] = "0" + dtArray[1];
			return String.Join("/", dtArray);
		}
		public static string transformValidDateString(DateTime dt)
		{
			string[] dtArray = dt.ToShortDateString().Split('/');
			if (dtArray[0].Length == 1)
				dtArray[0] = "0" + dtArray[0];
			if (dtArray[1].Length == 1)
				dtArray[1] = "0" + dtArray[1];
			return String.Join("/", dtArray);
		}

		#endregion
		
		#region Common Functions

        private bool checkForWindowExists(Window parent, SearchCriteria sc, bool isMaximized, int tier = 0)
        {
			if (parent == null)
				return false;

            if (BaseTest.CheckCriteriaMatch(sc, parent.AutomationElement))
            {
				Screen = parent;
				if(isMaximized)
				{
					Screen.DisplayState = DisplayState.Maximized;
					Screen.WaitTill(() => Screen.DisplayState == DisplayState.Maximized, TimeSpan.FromSeconds(10));
				}
				//Screen.ReloadIfCached();
				//Screen.ReInitialize(InitializeOption.NoCache);
				Screen.WaitWhileBusy();
				Screen.WaitTill(() => Screen.Visible, TimeSpan.FromSeconds(10));
                Screen.WaitTill(() => Screen.Enabled, TimeSpan.FromSeconds(10));
                Screen.Focus();
                return true;
            }
            if (tier == 4)
                return false;

			Thread.Sleep(500);
			List<Window> children = Retry.For(() => parent.ModalWindows(), TimeSpan.FromSeconds(10));
			if (children != null && children.Count > 0)
				foreach (Window child in children)
					if (checkForWindowExists(child, sc, isMaximized, tier + 1))
						return true;
            return false;
        }
		
		public static void Debug_DetailAutomationElement(AutomationElement ae)
		{
			if (ae == null)
			{
				Console.WriteLine("Debug_DetailAutomationElement, element null");
				return;
			}

			Console.WriteLine("==Debug_DetailAutomationElement==");
			if (!string.IsNullOrEmpty(ae.Current.Name))
				Console.WriteLine("Element Name: " + ae.Current.Name);
			if (!string.IsNullOrEmpty(ae.Current.AutomationId))
				Console.WriteLine("Element AutomationID: " + ae.Current.AutomationId);
			if (!string.IsNullOrEmpty(ae.Current.ClassName))
				Console.WriteLine("Element ClassName: " + ae.Current.ClassName);
			if (!string.IsNullOrEmpty(ae.Current.ItemType))
				Console.WriteLine("Element ItemType: " + ae.Current.ItemType);
			if (ae.Current.ControlType != null)
				Console.WriteLine("Element ControlType: programmticName[" + ae.Current.ControlType.ProgrammaticName + "] Id[" + ae.Current.ControlType.Id + "] localizedControlType[" + ae.Current.ControlType.LocalizedControlType + "]");
			if (!string.IsNullOrEmpty(ae.Current.LocalizedControlType))
				Console.WriteLine("Element LocalizedControlType: " + ae.Current.LocalizedControlType);
			if (!string.IsNullOrEmpty(ae.Current.ItemStatus))
				Console.WriteLine("Element ItemStatus: " + ae.Current.ItemStatus);
			if (!string.IsNullOrEmpty(ae.Current.AriaRole))
				Console.WriteLine("Element AriaRole: " + ae.Current.AriaRole);
			if (!string.IsNullOrEmpty(ae.Current.AriaProperties))
				Console.WriteLine("Element AriaRole: " + ae.Current.AriaProperties);
			if (!string.IsNullOrEmpty(ae.Current.HelpText))
				Console.WriteLine("Element AriaRole: " + ae.Current.HelpText);

			Console.WriteLine("Element IsContentElement: " + ae.Current.IsContentElement);
			Console.WriteLine("Element IsControlElement: " + ae.Current.IsControlElement);
			Console.WriteLine("Element isEnabled: " + ae.Current.IsEnabled);
			Console.WriteLine("Element IsKeyboardFocusable: " + ae.Current.IsKeyboardFocusable);
			Console.WriteLine("Element isOffscreen: " + ae.Current.IsOffscreen);
		}

		#endregion

	}
}
