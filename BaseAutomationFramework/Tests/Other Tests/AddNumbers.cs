using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseAutomationFramework.PageObjects.Calculator;
using BaseAutomationFramework.PageObjects;
using BaseAutomationFramework.PageObjects.Yahoo;
using BaseAutomationFramework.DataObjects;
using BaseAutomationFramework.Tools;

namespace BaseAutomationFramework.Tests.OtherTests
{
    [TestFixture]
    public class AddNumbers : BaseTest
    {
		/*
		[GetTestSet("Test")]
		[TestCaseSource(typeof(GetTestData), "Screen")]
		*/

		//[Test]
		//      public void AddTwoNumbers_DataDriven(IDictionary<string, string> data)
		//      {
		//          BaseTest.MasterData = new objMasterData(data);


		//          new CalculatorMain()
		//              .btn_GeneralNumber_Click(MasterData.FirstNumber)
		//              .btn_Add_Click()
		//              .btn_GeneralNumber_Click(MasterData.SecondNumber)
		//              .btn_Equals_Click();

		//          string ActualResult = new CalculatorMain().lbl_Result_GetText();

		//          Assert.AreEqual(MasterData.ExpectedSum.ToString(), ActualResult, "The numbers just don't add up!!!");


		//      }

		//      [Test]
		//      public void AddTwoNumbers()
		//      {
		//          BaseTest.MasterData = new objMasterData(1, 2, 4);

		//          new CalculatorMain()
		//              .btn_GeneralNumber_Click(MasterData.FirstNumber)
		//              .btn_Add_Click()
		//              .btn_GeneralNumber_Click(MasterData.SecondNumber)
		//              .btn_Equals_Click();

		//          string ActualResult = new CalculatorMain().lbl_Result_GetText();

		//          Assert.AreEqual(MasterData.ExpectedSum.ToString(), ActualResult, "The numbers just don't add up!!!");


		//      }

		[Test]
		public void Test()
		{
			Config = new UserConfig("OtherFile");
			Console.WriteLine(Config.DoThisThing.ToString());
			Console.WriteLine(Config.PieceOfData);
		}



        [TestFixtureSetUp]
        public void OnFixtureSetup()
        {

        }

        [SetUp]
        public void BeforeEachTest()
        {
            //LaunchApplication(DesktopApps.Calculator);
        }        

        [TearDown]
        public void AfterEachTest()
        {
           // TestedApplication.Kill();
        }

        [TestFixtureTearDown]
        public void OnFixtureTearDown()
        {

        }
    }
}
