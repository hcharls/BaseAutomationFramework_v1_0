///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Namespace>
///   Class:          <CodeChecker>
///   Description:    <>
///   Author:         <Hannah_Charls>           Date: <Novmeber_21_2017>
///   Notes:          <>
///   Revision History:
///   Name:				 Date:					Description:
///   
/// 
///------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using BaseAutomationFramework.PageObjects.Encompass;
using NUnit.Framework;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using BaseAutomationFramework.Tools;
using BaseAutomationFramework.DataObjects;
using System.Threading;
using System.IO;
using BaseAutomationFramework.PageObjects.Yahoo;
using BaseAutomationFramework.PageObjects;
using BaseAutomationFramework.PageObjects.EncompassLoanCenter;

namespace BaseAutomationFramework.Tests.Encompass
{
	[TestFixture]
	public class CodeChecker : BaseTest
	{
		[Test]
		public void ControlChecker()
			
			{

            //	Pipeline.Initialize().thingy();

            AttachToProcess(Processes.Encompass, 5);

            WVM_LogOn
                .Initialize()
                .txt_Password_SendKeys("Pemadmin1")
                .btn_LogOn_Click()
                .WestVM_UploadFees_Click();

            EncompassMain.Initialize().tab_Loan_Select(); DisclosurePrep.Initialize().btn_Review2015Itemization_Click(); Itemization.OpenForm_FromFormsTab();

            PropertyTaxesReserved
                .OpenFromItemization()
                .cmb_ReserveBasedOn_SendKeys("Base Loan Amount")
                .txt_RatePercentage_SendKeys(".25")
                .btn_OK_Click();

            DisclosurePrep.OpenForm_FromFormsTab().btn_RunComplianceReport_Click();

            DisclosurePrep
                .OpenForm_FromFormsTab()
                .btn_NotNowContinue_Click()
                .cmb_DocumentDeliveryPreference_SendKeys("Email - eSign")
                .btn_ReadytoDisclose_Click()
                .btn_GenerateDisclosures_Click();

            DisclosurePlanCode.SelectPlanCode().btn_Order_eDisclosures_Click(); SelectDocuments.Initialize().btn_Send_Click();

            SendDisclosures
                .Initialize()
                .cmb_BorrowerAuthenticationMethod_SendKeys("Authorization Code")
                .txt_BorrowerAuthorization_SendKeys("13188")
                .btn_Send_Click();


            #region Product and Pricing (floating)

            //OB_ProductandPricing
            //	.OpenFrom_MainMenu()
            //	.lstbx_Provider_Select("Optimal Blue - Enhanced")
            //	.btn_Submit_Click();

            //OB_Login
            //	.Initialize()
            //	.txt_LoginName_SendKeys("qa_testlo_direct")
            //	.txt_Password_SendKeys("12345")
            //	.chk_SaveLoginInformation_Check(true)
            //	.chk_UpdateUpfrontMIdataforFHAloans_Check(true)
            //	.btn_Continue_Click();

            //OB_ProductSearch
            //	.Initialize()
            //	.btn_Submit_Click();

            //OB_SearchResults
            //	.Initialize()
            //	.SelectLoanProgram_Click("PEM CONF 30YR FIXED")
            //	.SelectRateClosestToZero();

            //OB_LockForm
            //	.Initialize()
            //	.btn_UpdateEncompass_Click();

            //OB_PricingImportEncompassUpdate
            //	.Initialize()
            //	.btn_Close_Click();

            #endregion Product and Pricing (floating)

            #region Product and Pricing (locked)

            //OB_ProductandPricing
            //	.OpenFrom_MainMenu()
            //	.lstbx_Provider_Select("Optimal Blue - Enhanced")
            //	.btn_Submit_Click();

            //OB_Login
            //	.Initialize()
            //	.txt_LoginName_SendKeys("qa_testlo_direct")
            //	.txt_Password_SendKeys("12345")
            //	.chk_SaveLoginInformation_Check(true)
            //	.chk_UpdateUpfrontMIdataforFHAloans_Check(true)
            //	.btn_Continue_Click();

            //OB_ProductSearch
            //	.Initialize()
            //	.btn_Submit_Click();

            //OB_SearchResults
            //	.Initialize()
            //	.lp_PEMCONF30YRFIXED_Click()
            //	.SelectRateClosestToZero();

            //OB_LockForm
            //	.Initialize()
            //	.btn_RequestLock_Click();

            //OB_PricingImportEncompassUpdate
            //	.Initialize()
            //	.btn_Close_Click();

            #endregion Product and Pricing (locked)

            #region Disclosure Prep (TRID)

            //DisclosurePrep
            //.OpenForm_FromFormsTab()
            //.cmb_WillThereBeSubordination_SendKeys("No")
            //.cmb_BetterRateWarranty_SendKeys("No")
            //.cmb_ImpoundsWillBeFor_SendKeys("Taxes and Insurance (T & I)")
            //.cmb_AddingRemovingSomeoneFromTitle_SendKeys("No")
            //.btn_GenerateEstimatedClosingDatesandStandardFees_Click()
            //.btn_SmartGFE_Click();

            //WVM_TitleAndClosing
            //	.OpenFrom_MainMenu()
            //	.Select_WestVMTitle_TEST();

            //WVM_LogOn
            //.Initialize()
            //.txt_Password_SendKeys("Pemadmin1")
            //.btn_LogOn_Click()
            //.WestVM_UploadFees_Click();

            //EncompassMain
            //.Initialize()
            //.tab_Loan_Select();

            //DisclosurePrep
            //	.Initialize()
            //	.btn_Review2015Itemization_Click();

            //Itemization
            //	.OpenForm_FromFormsTab();

            //PropertyTaxesReserved
            //	.OpenFromItemization()
            //	.cmb_ReserveBasedOn_SendKeys("Base Loan Amount")
            //	.txt_RatePercentage_SendKeys(".25")
            //	.btn_OK_Click();

            //DisclosurePrep
            //	.OpenForm_FromFormsTab()
            //	.btn_RunComplianceReport_Click();

            //DisclosurePrep
            //	.OpenForm_FromFormsTab()
            //	.btn_NotNowContinue_Click()
            //	.cmb_DocumentDeliveryPreference_SendKeys("Email - eSign")
            //	.btn_ReadytoDisclose_Click()
            //	.btn_GenerateDisclosures_Click();

            //DisclosurePlanCode
            //	.SelectPlanCode()
            //	.btn_Order_eDisclosures_Click();

            //SelectDocuments
            //	.Initialize()
            //	.btn_Send_Click();

            //SendDisclosures
            //	.Initialize()
            //	.cmb_BorrowerAuthenticationMethod_SendKeys("Authorization Code")
            //	.txt_BorrowerAuthorization_SendKeys("13188")
            //	.btn_Send_Click();

            #endregion Disclosure Prep (TRID)


            return;

			}

        [Test]
		public void GetMortgageInsurance()
		{
            //BaseSeleniumPage.CreateDriver(BaseSeleniumPage.WebDrivers.Chrome);
            //BaseSeleniumPage.NavigateToURL(@"https://www.mortgage-application.net/myaccount/accountlogin.aspx");

            //BorrowerLoanCenterLogIn.Initialize()
            //	.txt_Email_SendKeys("hcpemtesting@gmail.com")
            //	.txt_Password_SendKeys("P@ramount1")
            //	.btn_Login_Click();

            //CheckLoanStatus
            //	.Initialize()
            //	.fn_SelectFirstRow();

            //BaseSeleniumPage.CloseDriver();

            AttachToProcess(Processes.Encompass, 5);

            BorrowerSummary.Initialize().chk_AmortizationType_Check("Fixed Rate").txt_NoteRate_SendKeys("4").txt_Term_SendKeys("360").txt_LoanAmount_SendKeys("250000").chk_LoanPurpose_Check("No Cash-Out Refi");

            URLA_Page3.OpenForm_FromFormsTab().btn_EnterDataManually_Refinance_Click().txt_Refinance_SendKeys("250000");

            MortgageInsurance.OpenFrom_MainMenu().lstbx_Provider_Select("Genworth - Direct Connect").btn_Submit_Click();Thread.Sleep(2000);

            GenworthMortgageInsuranceRequest.Initialize().cmb_PremiumPaymentOption_SendKeys("s").txt_MI_Coverage_SendKeys("6").chk_PremiumFinanced_Check(true).btn_RateQuote_Click(); Thread.Sleep(10000);

            EncompassDialog.Initialize().btn_OK_Click();Thread.Sleep(2000);

            //MI_FeeImport.Initialize().btn_ImportFee_Click();Thread.Sleep(2000);

            //EncompassDialog.Initialize().btn_OK_Click(); Thread.Sleep(2000);

            //GenworthMortgageInsuranceRequest.Initialize().btn_Cancel_Click();

            //OB_ProductandPricing.OpenFrom_MainMenu().lstbx_Provider_Select("Optimal Blue - Enhanced").btn_Submit_Click();

            //OB_Login
            //    .Initialize()
            //    .txt_LoginName_SendKeys("stg_testlo_direct")
            //    .txt_Password_SendKeys("12345")
            //    .chk_SaveLoginInformation_Check(true)
            //    .chk_UpdateUpfrontMIdataforFHAloans_Check(true)
            //    .btn_Continue_Click();

            //OB_ProductSearch.Initialize().btn_Submit_Click(); Thread.Sleep(10000); 

            //OB_LockForm
            //    .Initialize()
            //    .btn_RequestLock_Click();

            //OB_PricingImportEncompassUpdate
            //    .Initialize()
            //    .btn_Close_Click();

            //OB_LockRequestDialog.Initialize().btn_ExitLoan_Click();


        }
        [Test]
        public void Lock()
        {
            
            AttachToProcess(Processes.Encompass, 5);

            //MI_FeeImport.Initialize().btn_ImportFee_Click(); Thread.Sleep(2000);

           // EncompassDialog.Initialize().btn_OK_Click(); Thread.Sleep(2000);

            GenworthMortgageInsuranceRequest.Initialize().btn_Cancel_Click();

            OB_ProductandPricing.OpenFrom_MainMenu().lstbx_Provider_Select("Optimal Blue - Enhanced").btn_Submit_Click();

            OB_Login
                .Initialize()
                .txt_LoginName_SendKeys("stg_testlo_direct")
                .txt_Password_SendKeys("12345")
                .chk_SaveLoginInformation_Check(true)
                .chk_UpdateUpfrontMIdataforFHAloans_Check(true)
                .btn_Continue_Click();

            OB_ProductSearch.Initialize().btn_Submit_Click(); Thread.Sleep(10000);

            OB_LockForm
                .Initialize()
                .btn_RequestLock_Click();

            OB_PricingImportEncompassUpdate
                .Initialize()
                .btn_Close_Click();

           // OB_LockRequestDialog.Initialize().btn_ExitLoan_Click();

        }

        [Test, TestCaseSource(typeof(BaseTest.TestData), "DataforThisThing")]
        public void dummy1(IDictionary<string, string> data)
        {

        }
        [Test, TestCaseSource(typeof(BaseTest.TestData), "dummy2")]
        public void dummy2(IDictionary<string, string> data)
        {
           
        }


        [TestFixtureSetUp]
		public void OnFixtureSetup()
		{

		}

		[SetUp]
		public void BeforeEachTest()
		{

		}

		[TearDown]
		public void AfterEachTest()
		{
			
		}

		[TestFixtureTearDown]
		public void OnFixtureTearDown()
		{

		}
	}
}
