﻿///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Conv_NoCashOutRefi>
///   Class:          <TEST_01_LO_AfterPricing>
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
using BaseAutomationFramework.HTML_Report;

namespace BaseAutomationFramework.Tests.Encompass.LoanCreation.Conventional.Conv_NoCashOutRefi
{
	[TestFixture]
	public class TEST_01_LO_AfterPricing : BaseTest
	{
		private StreamWriter SW;
		private StatusReport SR;
		string runTime;
		string className;
		string pathStem;

		[GetTestSet("Test")]
		[TestCaseSource(typeof(GetTestData), "Screen")]
		public void Regression(IDictionary<string, string> data)
		{
			MasterData = new objMasterData(data);
			MasterData.TestResultPathStem = pathStem;
			className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
			Step step = new Step();

			step.Action = string.Format("Test: {0}", MasterData.TestID);
			step.ExpectedResult = string.Format("");
			step.ActualResult = string.Format("");
			step.Status = "Pass";
			step.Time = DateTime.Now.ToString();

			try
			{
				AttachToProcess(Processes.Encompass, 5);

				#region Product and Pricing (floating)

				//OB_ProductandPricing
				//	.OpenFrom_MainMenu()
				//	.lstbx_Provider_Select("Optimal Blue - Enhanced")
				//	.btn_Submit_Click();

				//OB_Login
				//	.Initialize()
				//	.txt_LoginName_SendKeys(MasterData.Login)
				//	.txt_Password_SendKeys(MasterData.Password)
				//	.chk_SaveLoginInformation_Check(true)
				//	.chk_UpdateUpfrontMIdataforFHAloans_Check(true)
				//	.btn_Continue_Click();

				//OB_ProductSearch
				//	.Initialize()
				//	.btn_Submit_Click();

				//Thread.Sleep(10000);

				//OB_LockForm
				//	.Initialize()
				//	.btn_UpdateEncompass_Click();

				//OB_PricingImportEncompassUpdate
				//	.Initialize()
				//	.btn_Close_Click();

				#endregion Run Product and Pricing (floating)

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

				//Thread.Sleep(10000);

				//OB_LockForm
				//	.Initialize()
				//	.btn_RequestLock_Click();

				//OB_PricingImportEncompassUpdate
				//	.Initialize()
				//	.btn_Close_Click();

				#endregion Product and Pricing (locked)

				#region Disclosure Prep (TRID) through milestone completion

				DisclosurePrep
					.OpenForm_FromFormsTab()
					.cmb_WillThereBeSubordination_SendKeys("No")
					.cmb_BetterRateWarranty_SendKeys("No")
					.cmb_ImpoundsWaivedOrNotWaived_SendKeys("Not Waived")
					.cmb_ImpoundsWillBeFor_SendKeys("Taxes and Insurance (T & I)")
					.cmb_AddingRemovingSomeoneFromTitle_SendKeys("No")
					.btn_GenerateEstimatedClosingDatesandStandardFees_Click();

				WVM_TitleAndClosing
					.OpenFrom_MainMenu()
					.Select_WestVMTitle_TEST();

				WVM_LogOn
					.Initialize()
					.txt_Username_SendKeys("PEMAdmin")
					.txt_Password_SendKeys("Pemadmin1")
					.btn_LogOn_Click();

				WVM_PropertyAndOrderInformation
					.Initialize()
					.btn_UploadFees_Click();

				EncompassMain
					.Initialize()
					.tab_Loan_Select();

				DisclosurePrep
					.Initialize()
					.btn_SmartGFE_Click()
					.btn_Review2015Itemization_Click();

				Itemization
					.OpenForm_FromFormsTab();

				PropertyTaxesReserved
					.OpenFromItemization()
					.cmb_ReserveBasedOn_SendKeys("Base Loan Amount")
					.txt_RatePercentage_SendKeys(".25")
					.btn_OK_Click();

				AggregateSetup
					.OpenFromItemization()
					.txt_HazardInsurance_Tab()
					.btn_OK_Click();

				DisclosurePrep
					.OpenForm_FromFormsTab()
					.btn_RunComplianceReport_Click();

				DisclosurePrep
					.OpenForm_FromFormsTab()
					.btn_NotNowContinue_Click()
					.cmb_DocumentDeliveryPreference_SendKeys("Email - eSign")
					.btn_ReadytoDisclose_Click()
					.btn_GenerateDisclosures_Click();

				Order_eDisclosures
					.Initialize()
					.InitialDisclosures_SelectTopPlanCode()
					.btn_Order_eDisclosures_Click();

				SelectDocuments
					.Initialize()
					.btn_Send_Click();

				SendDisclosures
					.Initialize()
					.cmb_BorrowerAuthenticationMethod_SendKeys("Authorization Code")
					.txt_BorrowerAuthorization_SendKeys("13188")
					.btn_Send_Click();

				EncompassDialog
					.Initialize()
					.btn_Yes_Click();

				eSignDocuments
					.Initialize()
					.btn_Next_Click()
					.btn_Start_Click()
					.btn_eSign_Click()
					.btn_eSign_Click()
					.btn_Finish_Click();

				EncompassDialog
					.Initialize()
					.btn_OK_Click();

			






				Retrieve
					.OpenFrom_eFolder()
					.btn_Download_Click();

				FileManager
					.Initialize()
					.btn_Close_Click();

				Encompass_eFolder
					.Initialize()
					.btn_Close_Click();

				LoanEstimatePage1
					.OpenForm_FromFormsTab()
					.chk_IntentToProceed_Check(true);

				DisclosedLESnapshot
					.Initialize()
					.btn_OK_Click();

				Application
					.Open_FromLogTab()
					.cmb_UnderwritingRiskAccessType_SendKeys("DU")
					.btn_ProcessingMgr_Click();

				SelectLoanTeamMember
					.Initialize()
					.Application_SelectProcessingMgr();

				Application
					.Initialize()
					.chk_Finish_Check();

				EncompassMain
					.Initialize()
					.ExitEncompass();

				EncompassDialog
					.Initialize()
					.btn_Yes_Click();

				ComplianceAlert
					.Initialize()
					.btn_Close_Click();

				#endregion Disclosure Prep (TRID) through milestone completion

			}

			catch (Exception ex)
			{
				step.ModalText = ex.ToString();
				step.Status = "Fail";
				step.ScreenShotLocation = Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format("Failure\\{0}", System.Reflection.MethodBase.GetCurrentMethod().Name));
				Assert.Fail(ex.ToString());
			}
			finally
			{
				Report.addStep(step);
			}

		}

		[TestFixtureSetUp]
		public void OnFixtureSetup()
		{
			runTime = CreateRuntimeString();
			Report = StatusReport.getStatusReport();
			string sub1 = string.Format("Tester: {0}", Environment.UserName);
			string sub2 = string.Format("Release Version: {0}", "Not Assigned");
			List<string> subheaders = new List<string>() { sub1, sub2 };
			this.pathStem = string.Format("{0}\\{1}\\{2} - {3}", FileUtilities.DefaultTestResultDirectory, className, Environment.UserName, runTime);
			string path = string.Format("{0}\\{1}.html", pathStem, "Results");
			Report.reportSetup("Demo Script", path, null, subheaders);
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
			//string subject = string.Format("All your tests are finished, good job!");
			//string body = string.Format("All your tests are finished, good job!");
			//EmailUtilities.Email email = new EmailUtilities.Email(subject, body, "hannah.charls@aol.com");

			//EmailUtilities.SendEmail(email);
			//Report.writeReport();
		}
	}
}