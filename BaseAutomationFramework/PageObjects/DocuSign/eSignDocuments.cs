///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Namespace>
///   Class:          <eSignDocuments>
///   Description:    <eSign_Documents_window_for_LO_to_sign_disclosures>
///   Author:         <Hannah_Charls>           Date: <May_3_2018>
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
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace BaseAutomationFramework.PageObjects.Encompass
{
    public class SignDocuments : BaseScreen
    {
        public static SearchCriteria scWindow = SearchCriteria.ByAutomationId("DocuSignSigning");
        public static SearchCriteria[] scArray = { EncompassMain.scWindow, SendDisclosures.scWindow, scWindow };
        public const bool SET_MAXIMIZED = false;
        public SignDocuments()
        {
            Set_Screen(scArray, SET_MAXIMIZED);
        }

        public static FileManager Initialize()
        {
            return new FileManager();
        }

        #region Buttons

        private SearchCriteria btn_Close = SearchCriteria.ByAutomationId("btnClose");

        public void btn_Close_Click()
        {
            GetButton(btn_Close).Click();

        }

        #endregion


    }
}