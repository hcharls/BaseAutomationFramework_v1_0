using BaseAutomationFramework.DataObjects;
using BaseAutomationFramework.Tools;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseAutomationFramework.PageObjects;
using BaseAutomationFramework.PageObjects.Yahoo;

namespace BaseAutomationFramework.Tests.OtherTests
{
    [TestFixture]
    public class YahooSearch : BaseTest
    {        
        [Test]
        public void EnterSearchTerm()
        {
            BaseSeleniumPage.CreateDriver(BaseSeleniumPage.WebDrivers.Chrome);

            BaseSeleniumPage.NavigateToURL(@"https://www.yahoo.com/");

            new YahooMain()
                .txt_Search_SendKeys("Gibberish")
                .btn_Search_Click();


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
