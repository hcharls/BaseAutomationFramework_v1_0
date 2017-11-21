using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseAutomationFramework.PageObjects;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems;

namespace BaseAutomationFramework.PageObjects.Calculator
{
    public class CalculatorMain : BaseScreen
    {
        public static SearchCriteria scWindow = SearchCriteria.ByText("Calculator");
		public static SearchCriteria[] scArray = { scWindow };
		public const bool SET_MAXIMIZED = false;

        public CalculatorMain()
		{
			Set_Screen(scArray, SET_MAXIMIZED);
        }

        public CalculatorMain btn_GeneralNumber_Click(int x)
        {
            GetButton(SearchCriteria.ByText(x.ToString())).Click();
            return this;
        }



        #region Buttons

        private SearchCriteria btn_Add = SearchCriteria.ByText("Add");
        private SearchCriteria btn_Equals = SearchCriteria.ByText("Equals");
        private SearchCriteria btn_One = SearchCriteria.ByText("1");
        //
        public CalculatorMain btn_Add_Click()
        {
            GetButton(btn_Add).Click();

            return this;
        }
        public CalculatorMain btn_Equals_Click()
        {
            GetButton(btn_Equals).Click();

            return new CalculatorMain();
        }
        public CalculatorMain btn_One_Click()
        {            
            GetButton(btn_One).Click();           

            return this;
        }

        #endregion

        #region Combo Boxes

        private SearchCriteria cmb_UnitType = SearchCriteria.ByAutomationId("221");
        //
        public CalculatorMain cmb_UnitType_SelectByText(string Selection)
        {
            GetComboBox(cmb_UnitType).Enter(Selection);

            return this;
        }

        #endregion

        #region Labels

        private SearchCriteria lbl_Result = SearchCriteria.ByAutomationId("158");
        //
        public string lbl_Result_GetText()
        {
            return GetLabel(lbl_Result).Name;
        }

        #endregion


    }
}
