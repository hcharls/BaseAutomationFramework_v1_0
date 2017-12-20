using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using BaseAutomationFramework.PageObjects.Encompass;
using BaseAutomationFramework.PageObjects.Firefox;
using NUnit.Framework;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using BaseAutomationFramework.Tools;
using BaseAutomationFramework.DataObjects;
using System.Threading;
using System.IO;

namespace BaseAutomationFramework.Tests.Encompass
{
	[TestFixture]
	public class CodeChecker : BaseTest
	{
		[Test]
		public void ControlChecker()
			
			{

			//AttachToProcess(Processes.Encompass, 5);

			LaunchApplication(DesktopApps.Encompass);
			return;
			//Launcher
			//	.Initialize()
			//	.cmb_EnvironmentID_SelectByText("TEBE11141905")
			//	.btn_Login_Click();

			//	PipelineView.Initialize().thingy();

			#region eFolder Bypass

			//Encompass_eFolder
			//	.Open_eFolder()
			//	.AddNewDocument();

			//AddDocument
			//	.Initialize()
			//	.rdb_NewDocument_Select()
			//	.btn_OK_Click();

			//DocumentDetails
			//	.Initialize()
			//	.btn_BrowseAndAttach_Click();

			//BrowseAndAttach
			//	.Initialize()
			//	.btn_TestDocument_DoubleClick();

			//DocumentDetails
			//	.Initialize()
			//	.txt_DocumentName_SendKeys("Credit Report")
			//	.Chk_Requested_Check(true)
			//	.btn_Close_Click();

			//AddDocument
			//	.Initialize()
			//	.rdb_NewDocument_Select()
			//	.btn_OK_Click();

			//DocumentDetails
			//	.Initialize()
			//	.btn_BrowseAndAttach_Click();

			//BrowseAndAttach
			//	.Initialize()
			//	.btn_TestDocument_DoubleClick();

			//DocumentDetails
			//	.Initialize()
			//	.txt_DocumentName_SendKeys("Underwriting")
			//	.Chk_Requested_Check(true)
			//	.btn_Close_Click();

			//Encompass_eFolder
			//	.Initialize()
			//	.btn_Close_Click();

			#endregion eFolder Bypass

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

			#region eConsent

			//eConsentNotYetReceived
			//	.Open_FromAlertsandMessagesTab()
			//	.btn_RequesteConsent_Click();

			//SendConsent
			//	.Initialize()
			//	.chk_BorrowerConsent_Check(true)
			//	.chk_NotifyWhenBorrowerReceives_Check(false)
			//	.btn_Send_Click();

			AttachToProcess(Processes.Firefox, 5);
			LaunchApplication(DesktopApps.Firefox);

			//FirefoxMain
			//	.Initialize()
			//	.btn_BorrowerLoanCenter_Click();

			//BorrowerLoanCenterLogIn
			//	.Initialize()
			//	.btn_Login_Click();

			#endregion eConsent

			#region Disclosure Prep (TRID)

			//DisclosurePrep
			//	.OpenForm_FromFormsTab()
			//	.cmb_WillThereBeSubordination_SendKeys("No")
			//	.cmb_BetterRateWarranty_SendKeys("No")
			//	.cmb_ImpoundsWillBeFor_SendKeys("Taxes and Insurance (T & I)")
			//	.cmb_AddingRemovingSomeoneFromTitle_SendKeys("No")
			//	.btn_GenerateEstimatedClosingDatesandStandardFees_Click()
			//	.btn_SmartGFE_Click();

			//WVM_TitleAndClosing
			//	.OpenFrom_MainMenu()
			//	.Select_WestVMTitle_TEST();

			//WVM_LogOn
			//	.Initialize()
			//	//.txt_Username_SendKeys("PEMAdmin")
			//	.txt_Password_SendKeys("Pemadmin1")
			//	.btn_LogOn_Click();

			//WVM_PropertyAndOrderInformation
			//	.Initialize();

			//EncompassMain
			//	.Initialize()
			//	.tab_Loan_Select();

			//QuickEntry2015Itemization
			//	.OpenFromDisclosurePrep();

			//DisclosurePrep
			//	.Initialize()
			//	.btn_Review2015Itemization_Click();

			#endregion Disclosure Prep (TRID)

			return;

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
