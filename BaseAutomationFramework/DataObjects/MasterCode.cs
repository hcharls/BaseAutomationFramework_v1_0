///------------------------------------------------------------------------------------------------------------------------
///   Namespace:      <Namespace>
///   Class:          <MasterCode>
///   Description:    <Columns_for_MasterCode_Spreadsheet>
///   Author:         <Hannah_Charls>           Date: <Novmeber_21_2017>
///   Notes:          <ALL_spreadsheet_columns_must_appear_exactly_as_listed_here>
///   Revision History:
///   Name:				 Date:					Description:
///   
/// 
///------------------------------------------------------------------------------------------------------------------------

using BaseAutomationFramework.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseAutomationFramework.DataObjects
{
	public class objMasterData
	{
		public const string MasterCodeFileLocalDirectory = @"C:\Automation_Data\";

		#region Excel Sheet Headers

		private string colTestID = @"Test ID";
		private string colTestDescription = @"Test Description";
		private string colImpoundsDueDates = @"Impounds Due Date(s)";
		private string colImpoundsFirstPayment = @"Impounds First Payment";
		private string colImpoundsMonths = @"Impounds Months";
		private string colImpounds904Months = @"Impounds 904 Months";
		private string colEnvironmentID = @"Environment ID";
		private string colLoanFolder = @"Loan Folder";
		private string colLoanNumber = @"[364] Loan Number";
		private string colOB_Login = @"OB Login";
		private string colOB_Password = @"OB Password";
        private string colAuthorizationCode = @"Authorization Code";
        private string colLoanCenterPassword = @"Loan Center Password";
        private string colLoanProgram = @"[1401] Loan Program";
		private string colBorrowerFirstName = @"[4000] Borrower First Name";
		private string colBorrowerLastName = @"[4002] Borrower Last Name";
		private string colBorrowerSSN = @"[65] Borrower SSN";
		private string colBorrowerDOB = @"[1402] Borrower DOB";
		private string colHomePhone = @"[66] Home Phone";
		private string colHomeEmail = @"[1240] Home Email";
		private string colAddress = @"[11] Address";
		private string colCity = @"[12] City";
		private string colState = @"[14] State";
		private string colZip = @"[15] Zip";
		private string colCounty = @"[13] County";
		private string colInformationProvidedBy = @"[479] Information Provided By";
		private string colBorrowerSex = @"[471] Borrower Sex";
		private string colBorrowerEthnicity = @"[1523] Borrower Ethnicity";
		private string colBorrowerRace = @"[1528] Borrower Race";
		private string colCreditScore = @"Credit Score";
		private string colEstimatedValue = @"[1821] Estimated Value";
		private string colAppraisedValue = @"[356] Appraised Value";
		private string colPropertyWillBe = @"[1811] Property Will Be";
		private string colAmortizationType = @"[608] Amortization Type";
		private string colPurchasePrice = @"[136] Purchase Price";
		private string colLoanAmount = @"[1109] Loan Amount";
		private string colNoUnits = @"[16] No. Units";
		private string colPropertyType = @"[1041] Property Type";
		private string colTransPropertyType = @"[1553] Trans Property Type";
		private string colFirstPaymentDate = @"[682] First Payment Date";
		private string colCoBorrowerFirstName = @"[4004] CoBorrower First Name";
		private string colCoBorrowerLastName = @"[4005] CoBorrower Last Name";
		private string colCoBorrowerSSN = @"[97] CoBorrower SSN";
		private string colCoBorrowerDOB = @"[1403] CoBorrower DOB";
		private string colCoBorrowerSex = @"[478] CoBorrower Sex";
		private string colCoBorrowerEthnicity = @"[1531] CoBorrower Ethnicity";
		private string colCoBorrowerRace = @"[1533] CoBorrower Race";

		#endregion

		#region Object Properties

		public string TestResultPathStem { get; set; }
		public string TestID { get; private set; }
		public string TestDescription { get; set; }
		public string ImpoundsDueDates { get; set; }
		public string ImpoundsFirstPayment { get; set; }
		public string ImpoundsMonths { get; set; }
		public string Impounds904Months { get; set; }
		public string Environment { get; private set; }
		public string EnvironmentID { get; set; }
		public string LoanFolder { get; set; }
		public string LoanNumber { get; set; }
		public string OB_Login { get; set; }
		public string OB_Password { get; set; }
        public string AuthorizationCode { get; set; }
        public string LoanCenterPassword { get; set; }
        public string LoanProgram { get; set; }
		public string BorrowerFirstName { get; set; }
		public string BorrowerLastName { get; set; }
		public string BorrowerSSN { get; set; }
		public string BorrowerDOB { get; set; }
		public string HomePhone { get; set; }
		public string HomeEmail { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public string County { get; set; }
		public string InformationProvidedBy { get; set; }
		public string BorrowerSex { get; set; }
		public string BorrowerEthnicity { get; set; }
		public string BorrowerRace { get; set; }
		public string CreditScore { get; set; }
		public string EstimatedValue { get; set; }
		public string AppraisedValue { get; set; }
		public string PropertyWillBe { get; set; }
		public string AmortizationType { get; set; }
		public string PurchasePrice { get; set; }
		public string LoanAmount { get; set; }
		public string NoUnits { get; set; }
		public string PropertyType { get; set; }
		public string TransPropertyType { get; set; }
		public string FirstPaymentDate { get; set; }
		public string CoBorrowerFirstName { get; set; }
		public string CoBorrowerLastName { get; set; }
		public string CoBorrowerSSN { get; set; }
		public string CoBorrowerDOB { get; set; }
		public string CoBorrowerSex { get; set; }
		public string CoBorrowerEthnicity { get; set; }
		public string CoBorrowerRace { get; set; }


		public objMasterData(IDictionary<string, string> TestData)
		{
			this.TestID = TestData[colTestID];
			this.TestDescription = TestData[colTestDescription];
			this.ImpoundsDueDates = TestData[colImpoundsDueDates];
			this.ImpoundsFirstPayment = TestData[colImpoundsFirstPayment];
			this.ImpoundsMonths = TestData[colImpoundsMonths];
			this.Impounds904Months = TestData[colImpounds904Months];
			this.EnvironmentID = TestData[colEnvironmentID];
			this.LoanFolder = TestData[colLoanFolder];
			this.LoanNumber = TestData[colLoanNumber];
			this.OB_Login = TestData[colOB_Login];
			this.OB_Password = TestData[colOB_Password];
            this.AuthorizationCode = TestData[colAuthorizationCode];
            this.LoanCenterPassword = TestData[colLoanCenterPassword];
            this.LoanProgram = TestData[colLoanProgram];
			this.BorrowerFirstName = TestData[colBorrowerFirstName];
			this.BorrowerLastName = TestData[colBorrowerLastName];
			this.BorrowerSSN = TestData[colBorrowerSSN];
			this.BorrowerDOB = TestData[colBorrowerDOB];
			this.HomePhone = TestData[colHomePhone];
			this.HomeEmail = TestData[colHomeEmail];
			this.Address = TestData[colAddress];
			this.City = TestData[colCity];
			this.State = TestData[colState];
			this.Zip = TestData[colZip];
			this.County = TestData[colCounty];
			this.InformationProvidedBy = TestData[colInformationProvidedBy];
			this.BorrowerSex = TestData[colBorrowerSex];
			this.BorrowerEthnicity = TestData[colBorrowerEthnicity];
			this.BorrowerRace = TestData[colBorrowerRace];
			this.CreditScore = TestData[colCreditScore];
			this.EstimatedValue = TestData[colEstimatedValue];
			this.AppraisedValue = TestData[colAppraisedValue];
			this.PropertyWillBe = TestData[colPropertyWillBe];
			this.AmortizationType = TestData[colAmortizationType];
			this.PurchasePrice = TestData[colPurchasePrice];
			this.LoanAmount = TestData[colLoanAmount];
			this.NoUnits = TestData[colNoUnits];
			this.PropertyType = TestData[colPropertyType];
			this.TransPropertyType = TestData[colTransPropertyType];
			this.FirstPaymentDate = TestData[colFirstPaymentDate];
			this.CoBorrowerFirstName = TestData[colCoBorrowerFirstName];
			this.CoBorrowerLastName = TestData[colCoBorrowerLastName];
			this.CoBorrowerSSN = TestData[colCoBorrowerSSN];
			this.CoBorrowerDOB = TestData[colCoBorrowerDOB];
			this.CoBorrowerSex = TestData[colCoBorrowerSex];
			this.CoBorrowerEthnicity = TestData[colCoBorrowerEthnicity];
			this.CoBorrowerRace = TestData[colCoBorrowerRace];

			#endregion

		}



	}
}
