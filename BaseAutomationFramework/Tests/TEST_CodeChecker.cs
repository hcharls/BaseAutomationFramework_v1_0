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
	public class TEST_CodeChecker : BaseTest
	{
		[Test]
		public void ControlChecker()
			
			{
				AttachToProcess(Processes.Encompass, 5);

				LaunchApplication(DesktopApps.Encompass);

				Launcher
					.Initialize()
					.cmb_EnvironmentID_SelectByText("TEBE11141905")
					.btn_Login_Click();

				Login
					.Initialize()
					.txt_Username_SendKeys("test_qa_lo")
					.txt_Password_SendKeys("P@ramount1")
					.btn_Login_Click();

				EncompassMain
					.Initialize();
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
