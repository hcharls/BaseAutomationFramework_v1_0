using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncompassAutomationTool
{
    public class FieldValues
    {
        #region Combo Boxes

        public List<string> Environments { get; set; }
        public List<string> EnvironmentIDs { get; set; }
        public List<string> ClientIDs { get; set; }
        public List<string> UserIDs { get; set; }
        public List<string> OBLoginsTest { get; set; }
        public List<string> OBLoginsStage { get; set; }
        public List<string> OBLoginsProd { get; set; }
        public List<string> SalesChannels { get; set; }
        public List<string> LoanTypes { get; set; }
        public List<string> LoanPurposes { get; set; }
        public List<string> AmortizationTypes { get; set; }
        public List<string> States { get; set; }
        public List<string> StateAbbreviations { get; set; }

        public FieldValues()
        {
            Environments = new List<string>()
            {
                "TEST",
                "STAGING",
                "PROD"
            };

            EnvironmentIDs = new List<string>()
            {
                "TEBE11141905",
                "TEBE11166948",
                "BE799584"
            };

            ClientIDs = new List<string>()
            {
                "3011141905",
                "3011166948",
                "3000799584"
            };

            UserIDs = new List<string>()
            {
                "test_qa_admin",
                "test_qa_supadmin",
                "tpaolini",
                "test_qa_lo",
                "test_lo_pemp",
                "test_qa_som",
                "test_qa_proc",
                "test_qa_uw",
                "test_qa_qc",
                "test_qa_doc",
                "test_qa_funder",
                "test_qa_investor",
                "test_qa_shipper",
                "test_qa_sec",
                "test_qa_pc",
                "test_qa_mops",
                "test_qa_pa",
                "test_qa_sa",
                "test_qa_sm",
                "test_qa_msp",
                "test_qa_serv",
                "test_qa_smpa",
                "test_qa_se",
                "test_qa_fundd",
                "test_qa_cc",
                "test_qa_em",
                "test_insurer",
                "test_india_tm",
                "test_qa_ld",
                "test_qa_fin",
            };

            OBLoginsTest = new List<string>()
            {
                "qa_testlo_retail",
                "qa_testlo_direct",
                "qa_testlo_lendtr",
                "test_secondaryqa",
            };

            OBLoginsStage = new List<string>()
            {
                "stg_testlo_retail",
                "stg_testlo_direct",
                "stg_testlo_lendtr",
                "test_stagingqa",
                "stg_secondaryqa",
            };

            OBLoginsProd = new List<string>()
            {
                "test_lo_retail",
                "test_lo_direct"
            };

            SalesChannels = new List<string>()
            {
                "PEM Direct",
                "PEM Partners",
                "PEM Phoenix"
            };

            LoanTypes = new List<string>()
            {
                "Conventional",
                "FHA",
                "VA"
            };

            LoanPurposes = new List<string>()
            {
                "Purchase",
                "Cash-Out Refi",
                "No Cash-Out Refi",
                "IRRRL",
                "Streamline"
            };

            AmortizationTypes = new List<string>()
            {
                "Fixed Rate",
                "ARM"
            };

            States = new List<string>()
            {
                "Alabama",
                "Alaska",
                "Arizona",
                "Arkansas",
                "California",
                "Colorado",
                "Connecticut",
                "District of Columbia",
                "Delaware",
                "Florida",
                "Georgia",
                "Hawaii",
                "Idaho",
                "Illinois",
                "Indiana",
                "Iowa",
                "Kansas",
                "Kentucky",
                "Louisiana",
                "Maine",
                "Maryland",
                "Massachusetts",
                "Michegan",
                "Minnesota",
                "Mississippi",
                "Missouri",
                "Montana",
                "Nebraska",
                "Nevada",
                "New Hampshire",
                "New Jersey",
                "New Mexico",
                "New York",
                "North Carolina",
                "North Dakota",
                "Ohio",
                "Oklahoma",
                "Oregon",
                "Pennsylvania",
                "Rhode Island",
                "South Carolina",
                "South Dakota",
                "Tennessee",
                "Texas",
                "Utah",
                "Vermont",
                "Virginia",
                "Washington",
                "West Virginia",
                "Wisconsin",
                "Wyoming"
            };

            StateAbbreviations = new List<string>()
            {
                "AL",
                "AK",
                "AZ",
                "AR",
                "CA",
                "CO",
                "CT",
                "DC",
                "DE",
                "FL",
                "GA",
                "HI",
                "ID",
                "IL",
                "IN",
                "IA",
                "KS",
                "KY",
                "LA",
                "ME",
                "MD",
                "MA",
                "MI",
                "MN",
                "MS",
                "MO",
                "MT",
                "NE",
                "NV",
                "NH",
                "NJ",
                "NM",
                "NY",
                "NC",
                "ND",
                "OH",
                "OK",
                "OR",
                "PA",
                "RI",
                "SC",
                "SD",
                "TN",
                "TX",
                "UT",
                "VTt",
                "VA",
                "WA",
                "WV",
                "WI",
                "WY"
            };
        }

        #endregion

        #region Textboxes

        //private string EnvironmentID;

        //public string TestEnvironment
        //{
        //    get { return EnvironmentID}
        //    set
        //    {
        //        if (EnvironmentID != value)
        //        {
        //            EnvironmentID = value;
        //            OnPropertyChanged("");
        //            OnPropertyChanged("IsEnabled");
        //        }

        //    }

        //}

        //public bool IsEnabled
        //{
        //    get { return EnvironmentID != ""; }
        //}


        #endregion

    }
}
