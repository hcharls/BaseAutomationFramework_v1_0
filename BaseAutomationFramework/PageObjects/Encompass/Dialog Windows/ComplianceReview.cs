///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Namespace>
///   Class:          <ComplianceReview>
///   Description:    <Compliance_Review_window>
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
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.Utility;
using TestStack.White.WindowsAPI;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class ComplianceReview : BaseScreen
	{
		public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("FailedReviewDialog");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow };
		public const bool SET_MAXIMIZED = false;
		private AutomationElement aePanel = null;

		public ComplianceReview()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		public static ComplianceReview Initialize()
		{
			return new ComplianceReview();
		}

		private SearchCriteria btn_Close = SearchCriteria.ByAutomationId("btnClose");

		//
		public ComplianceReview btn_Close_Click()
		{
			GetButton(btn_Close).Click();
			return new ComplianceReview();
		}

	}
}