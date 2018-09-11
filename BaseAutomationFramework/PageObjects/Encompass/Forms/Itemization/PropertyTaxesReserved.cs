﻿using System;
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
	public class PropertyTaxesReserved : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("InsuranceDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
        public const bool SET_MAXIMIZED = false;
        private AutomationElement aePanel = null;

        public PropertyTaxesReserved()
        {
            Set_Screen(scArray, SET_MAXIMIZED);
            aeScreen = Screen.AutomationElement;
            aePanel = null;
        }
        
        public static PropertyTaxesReserved OpenFromItemization()
		{
			new Itemization()
				.btn_PropertyTaxes_Click();

			return new PropertyTaxesReserved();
		}
       

        public static PropertyTaxesReserved Initialize()
		{
			return new PropertyTaxesReserved();
		}


		#region Combo Boxes

		private PropertyCondition cmb_ReserveBasedOn = new PropertyCondition(AutomationElement.AutomationIdProperty, "typeCombo");
		//

		public PropertyTaxesReserved cmb_ReserveBasedOn_SendKeys(string Input)
		{

            aElement = aeScreen.FindFirst(TreeScope.Descendants, cmb_ReserveBasedOn);
            aElement.SetFocus();
            aElement.ClickCenterOfBounds();
            Keyboard.Instance.Enter(Input);
            Thread.Sleep(1000);

            return this;

        }

		#endregion

		#region Text Boxes

		private PropertyCondition txt_RatePercentage = new PropertyCondition(AutomationElement.AutomationIdProperty, "rateTxt");
		//

		public PropertyTaxesReserved txt_RatePercentage_SendKeys(string Input)
		{
			aElement = aeScreen.FindFirst(TreeScope.Descendants, txt_RatePercentage);
			aElement.SetFocus();
			aElement.ClickCenterOfBounds();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(1000);

			return this;
		}

		#endregion

		#region Buttons

		private SearchCriteria btn_OK = SearchCriteria.ByAutomationId("okBtn");

		public void btn_OK_Click()
		{
			GetButton(btn_OK).Click();
			Thread.Sleep(5000);
		}

		#endregion

	}
}