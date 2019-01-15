using System;
using System.Threading;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.UIItems.Finders;
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.PageObjects.AutomationTool
{
	public class AutomationTool : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("FancyAutomationTool");
		public static SearchCriteria[] scArray = new SearchCriteria[] { scWindow };
		public const bool SET_MAXIMIZED = false;
		public AutomationTool()
		{
			PropertyCondition pcWindow = new PropertyCondition(AutomationElement.AutomationIdProperty, "FancyAutomationTool");
			aeScreen = AutomationElement.RootElement.FindFirst(TreeScope.Children, pcWindow);
			aeScreen.WaitWhileBusy();

			if (aeScreen == null)
				throw new Exception("Application is not present.");
		}

		public static AutomationTool Launch()
		{
			

			return new AutomationTool();
		}

		public static AutomationTool Initialize()
		{
			return new AutomationTool();
		}

		#region Combo Boxes

		private PropertyCondition cmb_UserID = new PropertyCondition(AutomationElement.AutomationIdProperty, "cmb_UserID");
		private PropertyCondition cmb_OBLogin = new PropertyCondition(AutomationElement.AutomationIdProperty, "cmb_OBLogin");
		private PropertyCondition cmb_SalesChannel = new PropertyCondition(AutomationElement.AutomationIdProperty, "cmb_SalesChannel");
		private PropertyCondition cmb_LoanType = new PropertyCondition(AutomationElement.AutomationIdProperty, "cmb_LoanType");
        private PropertyCondition cmb_LoanPurpose = new PropertyCondition(AutomationElement.AutomationIdProperty, "cmb_LoanPurpose");
        private PropertyCondition cmb_Amortization = new PropertyCondition(AutomationElement.AutomationIdProperty, "cmb_Amortization");
        
        public AutomationTool cmb_UserID_Get()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_UserID);
            aElement.GetText();

            return this;
        }
        public AutomationTool cmb_OBLogin_Get()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_OBLogin);
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(1000);

            return this;
        }
        public AutomationTool cmb_SalesChannel_Get()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_SalesChannel);
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(1000);

            return this;
        }
        public AutomationTool cmb_LoanType_Get()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_LoanType);
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(1000);

            return this;
        }
        public AutomationTool cmb_LoanPurpose_Get()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_LoanPurpose);
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(1000);

            return this;
        }
        public AutomationTool cmb_Amortization_Get()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_Amortization);
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(1000);

            return this;
        }
        
        #endregion

        #region Text Boxes

        private PropertyCondition txt_EnvironmentID = new PropertyCondition(AutomationElement.AutomationIdProperty, "txt_EnvironmentID");
        private PropertyCondition txt_Password = new PropertyCondition(AutomationElement.AutomationIdProperty, "txt_Password");
        private PropertyCondition txt_OBPassword = new PropertyCondition(AutomationElement.AutomationIdProperty, "txt_OBPassword");
        private PropertyCondition txt_BorrowerEmail = new PropertyCondition(AutomationElement.AutomationIdProperty, "txt_BorrowerEmail");
        private PropertyCondition txt_LoanNumber = new PropertyCondition(AutomationElement.AutomationIdProperty, "txt_LoanNumber");
        private PropertyCondition txt_Address = new PropertyCondition(AutomationElement.AutomationIdProperty, "txt_Address");
        private PropertyCondition txt_City = new PropertyCondition(AutomationElement.AutomationIdProperty, "txt_City");
        private PropertyCondition txt_State = new PropertyCondition(AutomationElement.AutomationIdProperty, "txt_State");
        private PropertyCondition txt_Zip = new PropertyCondition(AutomationElement.AutomationIdProperty, "txt_Zip");

        public AutomationTool txt_EnvironmentID_Get()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_EnvironmentID);
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(1000);

            return this;
        }
        public AutomationTool txt_Password_Get()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Password);
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(1000);

            return this;
        }
        public AutomationTool txt_OBPassword_Get()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_OBPassword);
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(1000);

            return this;
        }
        public AutomationTool txt_BorrowerEmail_Get()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_BorrowerEmail);
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(1000);

            return this;
        }
        public AutomationTool txt_LoanNumber_Get()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_LoanNumber);
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(1000);

            return this;
        }
        public AutomationTool txt_Address_Get()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Address);
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(1000);

            return this;
        }
        public AutomationTool txt_City_Get()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_City);
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(1000);

            return this;
        }
        public AutomationTool txt_State_Get()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_State);
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(1000);

            return this;
        }
        public AutomationTool txt_Zip_Get()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_Zip);
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(1000);

            return this;
        }

        #endregion

        #region Checkboxes

        private PropertyCondition chk_LoanIsOpen = new PropertyCondition(AutomationElement.AutomationIdProperty, "chk_LoanIsOpen");
      
        public AutomationTool chk_LoanIsOpen_Get()
        {
            aElement = aeScreen.FindFirst(TreeScope.Descendants, chk_LoanIsOpen);
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(1000);

            return this;
        }

        #endregion

        #region Buttons

        private PropertyCondition btn_Launch = new PropertyCondition(AutomationElement.AutomationIdProperty, "btn_Launch");
		private PropertyCondition btn_Kill = new PropertyCondition(AutomationElement.AutomationIdProperty, "btn_Kill");

		//
		public AutomationTool btn_Launch_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_Launch);
			aElement.ClickCenterOfBounds();
			Thread.Sleep(2000);

			return new AutomationTool();
		}
		public AutomationTool btn_Kill_Click()
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, btn_Kill);
			aElement.ClickCenterOfBounds();
			Thread.Sleep(2000);

			return new AutomationTool();
		}

		#endregion
	}
}
