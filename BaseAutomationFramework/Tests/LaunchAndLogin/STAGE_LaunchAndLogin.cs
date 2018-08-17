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

namespace BaseAutomationFramework.Tests.Encompass.EnvironmentLogin
{
    [TestFixture]
    public class LaunchAndLogin_2_STAGE : BaseTest
    {
 
        private string Username = null;
        private string Password = null;


        [Test, TestCaseSource(typeof(BaseTest.TestData), "UserLogin")]
        public void UserLogin(IDictionary<string, string> data)
        {
          
            this.Username = data["Username"];
            this.Password = data["Password"];


            LaunchApplication(DesktopApps.Encompass);

            Launcher
                .Initialize()
                .cmb_EnvironmentID_SelectByText("TEBE11166948")
                .btn_Login_Click();

            AttachToProcess(Processes.Encompass, 5);

            Login
                .Initialize()
                .txt_Username_SendKeys(this.Username)
                .txt_Password_SendKeys(this.Password)
                .btn_Login_Click();

            Thread.Sleep(10000);

            EncompassMain
                .Initialize()
                .Resize()
                .tab_Pipeline_Select();

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
