﻿///------------------------------------------------------------------------------------------------------------------------
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
            AttachToProcess(Processes.Encompass, 5);


            DisclosurePrep
                   .OpenForm_FromFormsTab()
                   .btn_NotNowContinue_Click()
                   .cmb_DocumentDeliveryPreference_SendKeys("Email - eSign")
                   .btn_ReadytoDisclose_Click()
                   .btn_GenerateDisclosures_Click();

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
        [Test]
        public void LogInspect()
        {
            //AttachToProcess(Processes.Encompass, 5);



            TestStack.White.InputDevices.Mouse.Instance.Location = new Point(96.0, 209.0);
            Thread.Sleep(3000);
            var el = AutomationElement.FocusedElement;
            Console.WriteLine($"Name: {el.Current.Name}");
            Console.WriteLine($"ID: {el.Current.AutomationId}");
            Console.WriteLine($"Help: {el.Current.HelpText}");
            
            return;

        }

        [Test]
        public void WestVM()
        {

            AttachToProcess(Processes.Encompass, 5);
            WVM_LogOn
                  .Initialize()
                  .txt_Username_SendKeys("PEMAdmin")
                  .txt_Password_SendKeys("Pemadmin1")
                  .btn_LogOn_Click();

            WVM_PropertyAndOrderInformation.Initialize().chk_Appraisal_included_Check(false).btn_UploadFees_Click(); EncompassMain.Initialize().tab_Loan_Select();

        }

        [Test, TestCaseSource(typeof(BaseTest.TestData), "DataforThisThing")]
        public void dummy1(IDictionary<string, string> data)
        {

        }
        [Test, TestCaseSource(typeof(BaseTest.TestData), "dummy2")]
        public void dummy2(IDictionary<string, string> data)
        {
           
        }
        [Test]
        public void eConsent()
        {
            AttachToProcess(Processes.Encompass, 5);

            eConsentNotYetReceived.Open_FromAlertsandMessagesTab().btn_Request_eConsent_Click();

            SendConsent
                .Initialize()
                        .chk_BorrowerConsent_Check(true)
                        .chk_NotifyWhenBorrowerReceives_Check(true)
                        .btn_Send_Click();

            BaseSeleniumPage.CreateDriver(BaseSeleniumPage.WebDrivers.Chrome);
            BaseSeleniumPage.NavigateToURL(@"https://www.mortgage-application.net/myaccount/accountlogin.aspx");

            BorrowerLoanCenterLogIn.Initialize()
                .txt_Email_SendKeys("hcpemtesting@gmail.com")
                .txt_Password_SendKeys("P@ramount1")
                .btn_Login_Click();

            CheckLoanStatus.Initialize().fn_SelectFirstRow();

            LoanDetail
                .Initialize()
                .btn_View_Click();

            AgreeToReceiveDisclosuresElectronically.Initialize().btn_Agree_Click(); BaseSeleniumPage.CloseDriver();

            eConsentNotYetReceived.Initialize().btn_View_eConsent_Click();


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
