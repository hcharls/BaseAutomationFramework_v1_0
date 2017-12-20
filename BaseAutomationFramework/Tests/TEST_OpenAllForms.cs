using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseAutomationFramework.PageObjects.Encompass;
using BaseAutomationFramework.PageObjects.Firefox;
using NUnit.Framework;

namespace BaseAutomationFramework.Tests.Encompass
{
	[TestFixture]
	public class OpenAllForms : BaseTest
	{
		[Test]
		public void OpenAllFormsandTools()
		{
			AttachToProcess(Processes.Encompass, 5);

			FormsTab
				.Initialize()
				.OpenAllForms_SelectForm("1003 Page 1")
				.OpenAllForms_SelectForm("1003 Page 2")
				.OpenAllForms_SelectForm("1003 Page 3")
				.OpenAllForms_SelectForm("1003 Page 4")
				.OpenAllForms_SelectForm("1098 Mortgage Interest")
				.OpenAllForms_SelectForm("2015 Itemization")
				.OpenAllForms_SelectForm("Activity Tracking")
				.OpenAllForms_SelectForm("Additional Disclosures Information")
				.OpenAllForms_SelectForm("Additional Requests Information")
				.OpenAllForms_SelectForm("Admin - BizRuleAnalyzer")
				.OpenAllForms_SelectForm("Admin - Export Audit Fields")
				.OpenAllForms_SelectForm("Admin - Field Explorer")
				.OpenAllForms_SelectForm("Admin - Field Explorer Pro")
				.OpenAllForms_SelectForm("Admin - Macro Debugger")
				.OpenAllForms_SelectForm("Admin Console")
				.OpenAllForms_SelectForm("Admin Form Export Field Descriptions")
				.OpenAllForms_SelectForm("Admin Form Locked Fields")
				.OpenAllForms_SelectForm("Affiliated Business Arrangements")
				.OpenAllForms_SelectForm("Affiliated Business Disclosure")
				.OpenAllForms_SelectForm("Aggregate Escrow Account")
				.OpenAllForms_SelectForm("Appraisal Delivery Tracking")
				.OpenAllForms_SelectForm("Appraisal Order and Tracking")
				.OpenAllForms_SelectForm("ATR/QM Management")
				.OpenAllForms_SelectForm("Banker Loan Submission Form")
				.OpenAllForms_SelectForm("Bi-weekly Loan Payment Summary")
				.OpenAllForms_SelectForm("Borrower Information - Vesting")
				.OpenAllForms_SelectForm("Borrower Summary")
				.OpenAllForms_SelectForm("Borrower Summary - Origination")
				.OpenAllForms_SelectForm("Borrower Summary - Processing")
				.OpenAllForms_SelectForm("Borrower Trust Reconcilation")
				.OpenAllForms_SelectForm("Business Rule Dumper")
				.OpenAllForms_SelectForm("Buydown Dispursement Summary")
				.OpenAllForms_SelectForm("Checklist to Pipe a Loan")
				.OpenAllForms_SelectForm("Closing Checklist")
				.OpenAllForms_SelectForm("Closing Conditions")
				.OpenAllForms_SelectForm("Closing Disclosure Page 1")
				.OpenAllForms_SelectForm("Closing Disclosure Page 2")
				.OpenAllForms_SelectForm("Closing Disclosure Page 3")
				.OpenAllForms_SelectForm("Closing Disclosure Page 4")
				.OpenAllForms_SelectForm("Closing Disclosure Page 5")
				.OpenAllForms_SelectForm("Closing Form")
				.OpenAllForms_SelectForm("Closing Tracking")
				.OpenAllForms_SelectForm("Closing Vendor Information")
				.OpenAllForms_SelectForm("Comments Repository")
				.OpenAllForms_SelectForm("Compliance Activity Form")
				.OpenAllForms_SelectForm("Construction Management")
				.OpenAllForms_SelectForm("Custom Fields")
				.OpenAllForms_SelectForm("Disclosure Prep")
				.OpenAllForms_SelectForm("Disclosure Prep (TRID)")
				.OpenAllForms_SelectForm("Energy Efficient Mortgage Calculation")
				.OpenAllForms_SelectForm("Escrow Holdback Request")
				.OpenAllForms_SelectForm("Excluded Investors")
				.OpenAllForms_SelectForm("FACT Act Disclosure")
				.OpenAllForms_SelectForm("FHA Management")
				.OpenAllForms_SelectForm("FHA Maximum Mortgage and Cash Needed Worksheet")
				.OpenAllForms_SelectForm("Finance Activity")
				.OpenAllForms_SelectForm("FL Broker Contract Disclosure")
				.OpenAllForms_SelectForm("FL Lender Disclosure")
				.OpenAllForms_SelectForm("Flood Information")
				.OpenAllForms_SelectForm("FNMA Streamlined 1003")
				.OpenAllForms_SelectForm("Freddie Mac Additional Data")
				.OpenAllForms_SelectForm("HMDA Information")
				.OpenAllForms_SelectForm("Home Counseling Providers")
				.OpenAllForms_SelectForm("HUD 1003 Addendum")
				.OpenAllForms_SelectForm("HUD-56001 Property Improvement")
				.OpenAllForms_SelectForm("HUD-928005b Conditional Commitment")
				.OpenAllForms_SelectForm("HUD-92900LT FHA Loan Transmittal")
				.OpenAllForms_SelectForm("Income Calc Worksheet")
				.OpenAllForms_SelectForm("Insurance Tracking")
				.OpenAllForms_SelectForm("Lead Management/Velocify")
				.OpenAllForms_SelectForm("leads360-lt")
				.OpenAllForms_SelectForm("Loan Estimate Page 1")
				.OpenAllForms_SelectForm("Loan Estimate Page 2")
				.OpenAllForms_SelectForm("Loan Estimate Page 3")
				.OpenAllForms_SelectForm("Loan Submission")
				.OpenAllForms_SelectForm("LoanPal Data")
				.OpenAllForms_SelectForm("MLDS - CA GFE")
				.OpenAllForms_SelectForm("Module - Cure Log Entry")
				.OpenAllForms_SelectForm("Mortgage Insurance Information")
				.OpenAllForms_SelectForm("Mortgage Payoff")
				.OpenAllForms_SelectForm("Nearest Living Relative/Child Care Statement")
				.OpenAllForms_SelectForm("NY Application Log")
				.OpenAllForms_SelectForm("NY Preapplication Disclosure")
				.OpenAllForms_SelectForm("Order Outs Tracking")
				.OpenAllForms_SelectForm("Payment Processing")
				.OpenAllForms_SelectForm("Pipeline Kickbacks")
				.OpenAllForms_SelectForm("Post Closing")
				.OpenAllForms_SelectForm("Post-Close Activity")
				.OpenAllForms_SelectForm("Price Adjustmnent Request")
				.OpenAllForms_SelectForm("Price Exception Request")
				.OpenAllForms_SelectForm("Privacy Policy")
				.OpenAllForms_SelectForm("Property Information")
				.OpenAllForms_SelectForm("QC Review")
				.OpenAllForms_SelectForm("Re-Disclosure Prep - COC")
				.OpenAllForms_SelectForm("Re-Disclosure Prep - COC (TRID)")
				.OpenAllForms_SelectForm("RegZ - CD")
				.OpenAllForms_SelectForm("RegZ - LE")
				.OpenAllForms_SelectForm("Request for Copy of Tax Return")
				.OpenAllForms_SelectForm("Request for Copy of Tax Return (Classic)")
				.OpenAllForms_SelectForm("Request for Transcript of Tax")
				.OpenAllForms_SelectForm("Request for Transcript of Tax (Classic)")
				.OpenAllForms_SelectForm("Request Orders Form")
				.OpenAllForms_SelectForm("RESPA Servicing Disclosure")
				.OpenAllForms_SelectForm("Resubmission for Final and CLosing Checklist")
				.OpenAllForms_SelectForm("Sales Operations Comments Log")
				.OpenAllForms_SelectForm("Second Review Request")
				.OpenAllForms_SelectForm("Section 32 HOEPA")
				.OpenAllForms_SelectForm("Section 35 HPML")
				.OpenAllForms_SelectForm("Self-Employed Income 1084")
				.OpenAllForms_SelectForm("Settlement Service Provider List")
				.OpenAllForms_SelectForm("Statement of Denial")
				.OpenAllForms_SelectForm("State-Specific Disclosure Information")
				.OpenAllForms_SelectForm("Third Day Disclosure Prep (QC) - TRID")
				.OpenAllForms_SelectForm("Third Day Initial Disclsoure Prep (QC)")
				.OpenAllForms_SelectForm("Tolerance Cure Tracking")
				.OpenAllForms_SelectForm("Transmittal Summary")
				.OpenAllForms_SelectForm("TX Broker Disclosure")
				.OpenAllForms_SelectForm("ULDD/PDD")
				.OpenAllForms_SelectForm("USDA Management")
				.OpenAllForms_SelectForm("UW Comparison")
				.OpenAllForms_SelectForm("UW Custom Form")
				.OpenAllForms_SelectForm("VA 26-0286 Loan Summary")
				.OpenAllForms_SelectForm("VA 26-1805 Reasonable Value")
				.OpenAllForms_SelectForm("VA 26-1820 Loan Dispursement")
				.OpenAllForms_SelectForm("VA 26-6393 Loan Analysis")
				.OpenAllForms_SelectForm("VA 26-8261A Veteran Status")
				.OpenAllForms_SelectForm("VA 26-8923 Rate Reduction WS")
				.OpenAllForms_SelectForm("VA Cert of Eligibility")
				.OpenAllForms_SelectForm("VA Management")
				.OpenAllForms_SelectForm("VA Residual Income Guideline Table")
				.OpenAllForms_SelectForm("Velocify Update Tracking")
				.OpenAllForms_SelectForm("Verbal Verification of Employment")
				.OpenAllForms_SelectForm("VOD")
				.OpenAllForms_SelectForm("VOE")
				.OpenAllForms_SelectForm("VOL")
				.OpenAllForms_SelectForm("VOM")
				.OpenAllForms_SelectForm("VOR");

			ToolsTab
				.Initialize()
				.OpenAllTools_SelectForm("Amortization Schedule")
				.OpenAllTools_SelectForm("Anti-Steering Safe Harbor Disclosure")
				.OpenAllTools_SelectForm("Audit Trail")
				.OpenAllTools_SelectForm("AUS Tracking")
				.OpenAllTools_SelectForm("Broker Check Calculation")
				.OpenAllTools_SelectForm("Business Contacts")
				.OpenAllTools_SelectForm("Cash-to-Close")
				.OpenAllTools_SelectForm("Collateral Tracking")
				.OpenAllTools_SelectForm("Co-Mortgagors")
				.OpenAllTools_SelectForm("Compliance Review")
				.OpenAllTools_SelectForm("Conversation Log")
				.OpenAllTools_SelectForm("Correspondent Loan Status")
				.OpenAllTools_SelectForm("Correspondent Purchase Advice Form")
				.OpenAllTools_SelectForm("Debt Consolidation")
				.OpenAllTools_SelectForm("Disclosure Tracking")
				.OpenAllTools_SelectForm("ECS Data Viewer")
				.OpenAllTools_SelectForm("Fee Variance Worksheet")
				.OpenAllTools_SelectForm("File Contacts")
				.OpenAllTools_SelectForm("Funding Balance Worksheet")
				.OpenAllTools_SelectForm("Funding Worksheet")
				.OpenAllTools_SelectForm("Interim Servicing Worksheet")
				.OpenAllTools_SelectForm("LO Compensation")
				.OpenAllTools_SelectForm("Loan Comparison")
				.OpenAllTools_SelectForm("Lock Request Form")
				.OpenAllTools_SelectForm("Net Tanglible Benefit")
				.OpenAllTools_SelectForm("Piggyback Loans")
				.OpenAllTools_SelectForm("Prequalification")
				.OpenAllTools_SelectForm("Profit Management")
				.OpenAllTools_SelectForm("Purchase Advice Form")
				.OpenAllTools_SelectForm("Rent vs. Own")
				.OpenAllTools_SelectForm("Secondary Registration")
				.OpenAllTools_SelectForm("Secure Form Transfer")
				.OpenAllTools_SelectForm("Shipping Detail")
				.OpenAllTools_SelectForm("Status Online")
				.OpenAllTools_SelectForm("Tasks")
				.OpenAllTools_SelectForm("TPO Information")
				.OpenAllTools_SelectForm("TQL Services")
				.OpenAllTools_SelectForm("Trust Account")
				.OpenAllTools_SelectForm("Underwriter Summary")
				.OpenAllTools_SelectForm("Verification and Documentation Tracking");

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
