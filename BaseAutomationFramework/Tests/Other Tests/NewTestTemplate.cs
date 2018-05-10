using NUnit.Framework;
using System;

namespace BaseAutomationFramework.Tests.OtherTests
{
    [TestFixture]
	public class NewTestTemplate : BaseTest
	{
        public NewTestTemplate()
        {
            //Default constructor is required for NUnit
        }

        [TestFixtureSetUp]
        public void OnFixtureSetup()
        {
        }

        [SetUp]
        public void BeforeEachTest()
        {
        }

        [Test]
        public void MyTestNameHere()
        {
            Console.WriteLine("Test Code Here");
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
