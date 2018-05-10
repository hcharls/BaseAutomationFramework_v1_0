///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Namespace>
///   Class:          <Services_Tab>
///   Description:    <Services_Tab>
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
using System.Threading.Tasks;
using TestStack.White.UIItems.Finders;

namespace BaseAutomationFramework.PageObjects.Encompass
{
	public class ServicesTab : BaseScreen
	{
		//public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("LoanPage");
		public static SearchCriteria[] scArray = { EncompassMain.scWindow };//, scWindow };
		public const bool SET_MAXIMIZED = false;
		public ServicesTab()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
		}

		#region List Boxes

		private SearchCriteria lstbx_Services = SearchCriteria.ByAutomationId("servicesPage");
		//
		public void lstbx_Services_SelectService(string ServiceName)
		{
			GetListBox(lstbx_Services).Select(ServiceName);
		}

		#endregion

		//private PropertyCondition btn_SearchProductandPricing = new PropertyCondition(AutomationElement.AutomationIdProperty, "EpassCategoryControl");

	}
}
