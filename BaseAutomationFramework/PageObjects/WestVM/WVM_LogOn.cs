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
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class WVM_LogOn : BaseScreen
	{
        public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("mainPanel");
        public static SearchCriteria[] scArray = new SearchCriteria[] { EncompassMain.scWindow, scWindow };
        public const bool SET_MAXIMIZED = true;

        public WVM_LogOn()
        {
            Set_Screen(scArray, SET_MAXIMIZED);

            PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "MainForm");
            PropertyCondition pcsubWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "mainPanel");
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

        public static WVM_LogOn Initialize()
		{
			return new WVM_LogOn();
		}
		
		#region Text Boxes

		private PropertyCondition txt_Username = new PropertyCondition(AutomationElement.AutomationIdProperty, "UserName");
		private PropertyCondition txt_Password = new PropertyCondition(AutomationElement.AutomationIdProperty, "Password");

		public WVM_LogOn txt_Username_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Username);
			aElement.SetFocus();
			Keyboard.Instance.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
			Keyboard.Instance.Enter("a");
			Keyboard.Instance.LeaveAllKeys();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
       
        public WVM_LogOn txt_Password_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Password);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
       

        #endregion

        #region Buttons

        private PropertyCondition btn_LogOn = new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button");

		//
		public WVM_LogOn btn_LogOn_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_LogOn);
			aElement.ClickCenterOfBounds();
			Thread.Sleep(1000);

			return new WVM_LogOn();
		}

        #endregion

    }
}