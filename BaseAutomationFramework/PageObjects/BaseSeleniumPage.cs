using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace BaseAutomationFramework.PageObjects
{
	public class BaseSeleniumPage
	{

		public static IWebDriver webDriver { get; private set; }
		public static IWebElement wElement { get; set; }
		public static SelectElement sElement { get; set; }
		

		public static IJavaScriptExecutor jscriptexec;

        public static void setWebDriverNull()
        {
            webDriver = null;
        }
		public static void StopPageLoad()
		{
			IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
			js.ExecuteScript("return window.stop");
		}

		public static void ExecuteJavascript(string javascript)
		{
			IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
			js.ExecuteScript(javascript);
		}

		public enum WebDrivers
		{
			IE,
			Firefox,
			Chrome
		}
		public static void CreateDriver(WebDrivers WD)
		{
			switch (WD)
			{
				case WebDrivers.IE:	CreateDriver("IE");	break;
				case WebDrivers.Firefox: CreateDriver("Firefox"); break;
				case WebDrivers.Chrome: CreateDriver("Chrome"); break;
			}
		}
		private static void CreateDriver(string Driver)
		{
			switch (Driver)
			{
				case "IE":
					var ieService = InternetExplorerDriverService.CreateDefaultService();
					//ieService.HideCommandPromptWindow = true;

					InternetExplorerOptions ieOptions = new InternetExplorerOptions();
					ieOptions.SetLoggingPreference(LogType.Driver, LogLevel.Severe);


					//ieOptions.RequireWindowFocus = true;
					//ieOptions.EnablePersistentHover = true;
					//ieOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;

					//ieOptions.AddAdditionalCapability("requireWindowFocus", true);
					//ieOptions.AddAdditionalCapability("enablePersistentHover", false);

					webDriver = new InternetExplorerDriver(ieService, ieOptions, TimeSpan.FromSeconds(300));
					webDriver.Manage().Window.Maximize();
					webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
					webDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(300));
					break;
				case "Firefox":
					var options = new FirefoxOptions();
					FirefoxDriverService ffService = FirefoxDriverService.CreateDefaultService(@"\\s-files\QA_IT\Ascendum_Automation", "geckodriver.exe");
					//ffService.HideCommandPromptWindow = true;
					
					
					//FirefoxDriverService service2 = new FirefoxDriverService//new FirefoxDriverService(@"\\s-files\QA_IT\Ascendum_Automation\geckodriver.exe");

					//System.setProperty("webdriver.gecko.driver", "G:\\Selenium\\Firefox driver\\geckodriver.exe");
					webDriver = new FirefoxDriver(ffService);					
					webDriver.Manage().Window.Maximize();

					//ITimeouts time;
					//time. = TimeSpan.FromSeconds(30);
					webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
					webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
					break;
				case "Chrome":
					OpenQA.Selenium.Remote.DesiredCapabilities cap = new OpenQA.Selenium.Remote.DesiredCapabilities();
					ChromeOptions op = new ChromeOptions();					
					op.LeaveBrowserRunning = true;
					webDriver = new ChromeDriver(op);
					webDriver.Manage().Window.Maximize();
					webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
					break;
			}
		}
		public static void SetAttributeOfElement(IWebElement el, string attribute, string input)
		{			
			IJavaScriptExecutor executor = (IJavaScriptExecutor)webDriver;
			string script = "document.getElementById(\"" + el.GetAttribute("id") + "\").setAttribute(\""+ attribute + "\", \""+ input + "\");";
			executor.ExecuteScript(script);
		}
		
		public static void NavigateToURL(string ServerURL)
		{
			//logFileCreator.writeLine(string.Concat("Navigating to Server URL: ", ServerURL, " . . ."));
			webDriver.Navigate().GoToUrl(ServerURL);
		}

		public static void CloseDriver()
		{
			//logFileCreator.writeLine("Closing the WebDriver . . .");
			webDriver.Quit();
			//if (globals.BrowserVersion == "IE 11")
			//{
			//    a1.application_IEDriverServer().Kill();
			//}
		}
		public static void CloseDriver(IWebDriver webDriver)
		{
			//logFileCreator.writeLine("Closing the WebDriver . . .");
			webDriver.Quit();
		}
		/// <summary>
		/// <para>=====</para>
		/// <para>Takes a screenshot of the browser and saves as a jpeg.</para>
		/// <para>Uses 'MethodName' in the file name and 'SS_Type' to determine the reason for use and the save location.</para>
		/// <para>'SS_Type' must be either "Check" or "Error"</para>
		/// <para>=====</para>
		/// </summary>
		/// <param name="MethodName">The name of the parent method or Test Case.</param>
		/// <param name="SS_Type">The reason for taking the Screenshot</param>
		public static void TakeSS(string MethodName, string SS_Type)
		{
			Screenshot ss = ((ITakesScreenshot)webDriver).GetScreenshot();
			string strDirectory = "";
			if (SS_Type.Equals("Error"))
			{
				//strDirectory = string.Format(@"{0}\Screenshots\Selenium\Errors", globals.FILELOCATIONS.localData);
			}
			if (SS_Type.Equals("Check"))
			{
				//strDirectory = string.Format(@"{0}\Screenshots\Selenium\Checkpoints", globals.FILELOCATIONS.localData);
			}
			Directory.CreateDirectory(strDirectory);

			string Month;
			string Day;
			string Year;
			string Hour;
			string Minute;
			string Second;
			if (DateTime.Now.Month < 10)
				Month = string.Concat("0", DateTime.Now.Month.ToString());
			else
				Month = DateTime.Now.Month.ToString();
			if (DateTime.Now.Day < 10)
				Day = string.Concat("0", DateTime.Now.Day.ToString());
			else
				Day = DateTime.Now.Day.ToString();
			if (DateTime.Now.Year < 10)
				Year = string.Concat("0", DateTime.Now.Year.ToString());
			else
				Year = DateTime.Now.Year.ToString();
			if (DateTime.Now.Hour < 10)
				Hour = string.Concat("0", DateTime.Now.Hour.ToString());
			else
				Hour = DateTime.Now.Hour.ToString();
			if (DateTime.Now.Minute < 10)
				Minute = string.Concat("0", DateTime.Now.Minute.ToString());
			else
				Minute = DateTime.Now.Minute.ToString();
			if (DateTime.Now.Second < 10)
				Second = string.Concat("0", DateTime.Now.Second.ToString());
			else
				Second = DateTime.Now.Second.ToString();

			string time = string.Concat(Hour, Minute, Second);
			string TimeStamp = string.Concat("_", Month, Day, Year, "_", time);
			string strFileName = string.Concat(strDirectory, "\\", MethodName, TimeStamp, ".jpg");

			ss.SaveAsFile(strFileName, System.Drawing.Imaging.ImageFormat.Jpeg);

			//logFileCreator.writeLine(string.Concat("Taking Screenshot: ", strFileName, " . . ."));
		}	
		
		/// <summary>
		/// <para>=====</para>
		/// <para>Takes a screenshot of the browser and saves as a jpeg.</para>
		/// <para>Uses 'MethodName' in the file name and 'SS_Type' to determine the reason for use and the save location.</para>
		/// <para>'SS_Type' must be either "Check" or "Error"</para>
		/// <para>=====</para>
		/// </summary>
		/// <param name="MethodName">The name of the parent method or Test Case.</param>
		/// <param name="SS_Type">true = Good, false = Fail</param>
		public static void TakeSS(string MethodName, bool SS_Type)
		{
			Screenshot ss = ((ITakesScreenshot)webDriver).GetScreenshot();
			string strDirectory = "";
			if (!SS_Type)
			{
				//strDirectory = string.Format(@"{0}\Screenshots\Selenium\Errors", globals.FILELOCATIONS.localData);
			}
			if (SS_Type)
			{
				//strDirectory = string.Format(@"{0}\Screenshots\Selenium\Checkpoints", globals.FILELOCATIONS.localData);
			}
			Directory.CreateDirectory(strDirectory);

			string Month;
			string Day;
			string Year;
			string Hour;
			string Minute;
			string Second;
			if (DateTime.Now.Month < 10)
				Month = string.Concat("0", DateTime.Now.Month.ToString());
			else
				Month = DateTime.Now.Month.ToString();
			if (DateTime.Now.Day < 10)
				Day = string.Concat("0", DateTime.Now.Day.ToString());
			else
				Day = DateTime.Now.Day.ToString();
			if (DateTime.Now.Year < 10)
				Year = string.Concat("0", DateTime.Now.Year.ToString());
			else
				Year = DateTime.Now.Year.ToString();
			if (DateTime.Now.Hour < 10)
				Hour = string.Concat("0", DateTime.Now.Hour.ToString());
			else
				Hour = DateTime.Now.Hour.ToString();
			if (DateTime.Now.Minute < 10)
				Minute = string.Concat("0", DateTime.Now.Minute.ToString());
			else
				Minute = DateTime.Now.Minute.ToString();
			if (DateTime.Now.Second < 10)
				Second = string.Concat("0", DateTime.Now.Second.ToString());
			else
				Second = DateTime.Now.Second.ToString();

			string time = string.Concat(Hour, Minute, Second);
			string TimeStamp = string.Concat("_", Month, Day, Year, "_", time);
			string strFileName = string.Concat(strDirectory, "\\", MethodName, TimeStamp, ".jpg");

			ss.SaveAsFile(strFileName, System.Drawing.Imaging.ImageFormat.Jpeg);

			//logFileCreator.writeLine(string.Concat("Taking Screenshot: ", strFileName, " . . ."));
		}
		public void ClickCheckBox(bool desiredState, By chk_Identifier)
		{
			IWebElement cb = chk_Identifier.GetWebElement();
			if (desiredState != cb.Selected)
				cb.Click();
		}

		public static void WaitForPageLoadToComplete(int intTimeOutFromSeconds = 120)
		{
			var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(intTimeOutFromSeconds));
			wait.Until(d => ((IJavaScriptExecutor)webDriver).ExecuteScript("return document.readyState").Equals("complete"));
		}

		public static void WaitForAjax()
		{
			IJavaScriptExecutor executor = (IJavaScriptExecutor)webDriver;
			if ((Boolean)executor.ExecuteScript("return window.jQuery != undefined"))
			{
				while (!(Boolean)executor.ExecuteScript("return jQuery.active == 0"))
				{
					Thread.Sleep(1000);
				}
			}
		}

		public static bool IsElementPresent(By by, int timeOutInSeconds = 5)
		{
			bool results = false;
			try
			{
				webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(timeOutInSeconds));
				results = webDriver.FindElement(by).Displayed;
				return results;
			}
			catch (NoSuchElementException ex)
			{
				return false;
			}
			finally
			{
				webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
			}
		}


	}
}
