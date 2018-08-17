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
using TestStack.White.Utility;
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class VerificationOfEmployment : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("QuickEntryPopupDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow, scWindow };
		public const bool SET_MAXIMIZED = false;
		private AutomationElement aePanel = null;

		public VerificationOfEmployment()
		{
			Set_Screen(scArray, SET_MAXIMIZED);			
			aePanel = null;					
		}

			public static VerificationOfEmployment Initialize()
		{
			return new VerificationOfEmployment();
		}

		public static VerificationOfEmployment OpenFromURLA_Page1()
		{
			new URLA_Page1()
				.btn_ShowAllVOE_Click();

			return new VerificationOfEmployment();
		}

        #region Panel

        private PropertyCondition pne_MainPanel = new PropertyCondition(AutomationElement.ClassNameProperty, "Internet Explorer_Server");
		//
		private void SetPanel()
		{
			int i = 0;
			do
			{
				aePanel = null;
				aeScreen = null;
				Screen = null;
				GC.Collect();
				new VerificationOfEmployment();
				Thread.Sleep(1000);
				aePanel = Screen.AutomationElement.FindFirst(TreeScope.Descendants, pne_MainPanel);

			} while (aePanel == null && i++ < 60);		
			if (aePanel == null)
				throw new Exception("Could not find the embedded IE panel!!!");			
		}

		#endregion
		
		#region Text Boxes

		private PropertyCondition txt_EmployerName = new PropertyCondition(AutomationElement.NameProperty, "BE0102: The name of the borrower's employer. Right-click to open the Business Contacts window and select an employer, or type the employer's name.");
		private PropertyCondition txt_EmployerAttn = new PropertyCondition(AutomationElement.NameProperty, "BE0103: The contact person at the employer who will verify the information on the VOE.");
		private PropertyCondition txt_EmployerAddress = new PropertyCondition(AutomationElement.NameProperty, "BE0104: The employer's street address.");
		private PropertyCondition txt_EmployerCity = new PropertyCondition(AutomationElement.NameProperty, "BE0105: The city in which the employer is located.");
		private PropertyCondition txt_EmployerState = new PropertyCondition(AutomationElement.NameProperty, "BE0106: The state in which the employer is located.");
		private PropertyCondition txt_EmployerZip = new PropertyCondition(AutomationElement.NameProperty, "BE0107: The employer's zip code.");
		private PropertyCondition txt_EmployerPhone = new PropertyCondition(AutomationElement.NameProperty, "BE0117: The employer's business phone number in the format nnn-nnn-nnnn nnnn.");
		private PropertyCondition txt_EmployerEmail = new PropertyCondition(AutomationElement.NameProperty, "BE0130: The employer's email address.");
		private PropertyCondition txt_BusinessName = new PropertyCondition(AutomationElement.NameProperty, "BE0132: The business name of the employer. For example, the Employer Name is typically the address where the verification is sent, while the Business Name could be the name of the parent company.");
		private PropertyCondition txt_BusinessPhone = new PropertyCondition(AutomationElement.NameProperty, "BE0128: The employer's business phone number in the format nnn-nnn-nnnn nnnn.");
		private PropertyCondition txt_BusinessPosition = new PropertyCondition(AutomationElement.NameProperty, "BE0110: The employee's position or title, or the employer's type of business.");
		private PropertyCondition txt_DateHired = new PropertyCondition(AutomationElement.NameProperty, "BE0111: The date the employee was hired by the employer.");
		private PropertyCondition txt_YearsinthisJob = new PropertyCondition(AutomationElement.NameProperty, "BE0113: The number of years and months the borrower has worked for the employer.");
		private PropertyCondition txt_MonthsinthisJob = new PropertyCondition(AutomationElement.NameProperty, "BE0133: The number of years and months in this job.");
		private PropertyCondition txt_YearsinLineofWork = new PropertyCondition(AutomationElement.NameProperty, "BE0116: The number of years the borrower has worked in this type of occupation or business.");
		private PropertyCondition txt_BasePay = new PropertyCondition(AutomationElement.NameProperty, "BE0119: The employee's current (or ending) monthly base pay.");
		//
		public VerificationOfEmployment txt_EmployerName_SendKeys(string Input)
		{
			SetPanel();
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_EmployerName);
			Thread.Sleep(1000);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return new VerificationOfEmployment();
		}
		public VerificationOfEmployment txt_EmployerAttn_SendKeys(string Input)
		{
			SetPanel();
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_EmployerAttn);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfEmployment txt_EmployerAddress_SendKeys(string Input)
		{
			SetPanel();
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_EmployerAddress);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfEmployment txt_EmployerCity_SendKeys(string Input)
		{
			SetPanel();
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_EmployerCity);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfEmployment txt_EmployerState_SendKeys(string Input)
		{
			SetPanel();
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_EmployerState);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfEmployment txt_EmployerZip_SendKeys(string Input)
		{
			SetPanel();
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_EmployerZip);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfEmployment txt_EmployerPhone_SendKeys(string Input)
		{
			SetPanel();
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_EmployerPhone);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfEmployment txt_EmployerEmail_SendKeys(string Input)
		{
			SetPanel();
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_EmployerEmail);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfEmployment txt_BusinessName_SendKeys(string Input)
		{
			SetPanel();
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_BusinessName);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfEmployment txt_BusinessPhone_SendKeys(string Input)
		{
			SetPanel();
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_BusinessPhone);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfEmployment txt_BusinessPosition_SendKeys(string Input)
		{
			SetPanel();
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_BusinessPosition);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfEmployment txt_DateHired_SendKeys(string Input)
		{
			SetPanel();
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_DateHired);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfEmployment txt_YearsinthisJob_SendKeys(string Input)
		{
			SetPanel();
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_YearsinthisJob);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfEmployment txt_MonthsinthisJob_SendKeys(string Input)
		{
			SetPanel();
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_MonthsinthisJob);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfEmployment txt_YearsinLineofWork_SendKeys(string Input)
		{
			SetPanel();
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_YearsinLineofWork);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}
		public VerificationOfEmployment txt_BasePay_SendKeys(string Input)
		{
			SetPanel();
			aElement = aePanel.FindFirst(TreeScope.Descendants, txt_BasePay);
			aElement.SetFocus();
			Keyboard.Instance.Enter(Input);
			Thread.Sleep(500);

			return this;
		}

		#endregion

		#region Buttons

		private SearchCriteria btn_VOENewVerif = SearchCriteria.ByAutomationId("btnNew");
		private SearchCriteria btn_VOEClose = SearchCriteria.ByAutomationId("btnClose");
		//
		public void btn_VOENewVerif_Click()
		{
			GetPanel(btn_VOENewVerif).Click();
		}
		public void btn_VOEClose_Click()
		{
			GetButton(btn_VOEClose).Click();
		}

		#endregion
	}
}