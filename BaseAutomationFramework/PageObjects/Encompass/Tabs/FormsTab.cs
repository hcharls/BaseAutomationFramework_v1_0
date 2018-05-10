///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Namespace>
///   Class:          <Forms_Tab>
///   Description:    <Forms_Tab>
///   Author:         <Hannah_Charls>           Date: <Novmeber_21_2017>
///   Notes:          <>
///   Revision History:
///   Name:				 Date:					Description:
///   
/// 
///------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TestStack.White.InputDevices;
using TestStack.White.UIItems.Finders;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class FormsTab : BaseScreen
	{
		//public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow };
		public const bool SET_MAXIMIZED = false;
		public FormsTab()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static FormsTab Initialize()
		{
			return new FormsTab();
		}

		public FormsTab OpenFormsTab()
		{
			Point FormsTab = new Point(37, 597);

			Mouse.Instance.Location = FormsTab;
			Mouse.LeftDown();
			Mouse.LeftUp();
			Thread.Sleep(1000);

			return this;
	
		}

		#region List Boxes

		private SearchCriteria lstbx_Forms = SearchCriteria.ByAutomationId("emFormMenuBox");
		//
		public void lstbx_Forms_SelectForm(string FormName)
		{
			aElement = GetListBox(lstbx_Forms).GetElement(SearchCriteria.ByText(FormName));
			aElement.SetFocus();
			Thread.Sleep(500);
			aElement.ClickCenterOfBounds();
		}

		#endregion

		#region Checkboxes

		private SearchCriteria chk_Show = SearchCriteria.ByAutomationId("allFormBox");
		private SearchCriteria chk_ShowInAlpha = SearchCriteria.ByAutomationId("chkAlphaForms");

		public FormsTab chk_Show_Check(bool Check)
		{
			OpenFormsTab();
			ClickCheckBox(Check, chk_Show);

			return this;
		}
		public FormsTab chk_ShowInAlpha_Check(bool Check)
		{
			ClickCheckBox(Check, chk_ShowInAlpha);

			return this;
		}

		#endregion

	}
}
