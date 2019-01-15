using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using BaseAutomationFramework.DataObjects;
using BaseAutomationFramework.HTML_Report;
using BaseAutomationFramework.PageObjects;
using BaseAutomationFramework.Tests;
using BaseAutomationFramework.Tools;
using NLog;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Utility;

namespace BaseAutomationFramework.Tests
{
    public class BaseTest
    {
        public class TestData
        {
            private static IEnumerable<TestCaseData> SprintTickets()
            {
                IEnumerable<TestCaseData> testcases = GetData(BaseTest.ExcelDataPath, "Tickets");
                return testcases;
            }
            private static IEnumerable<TestCaseData> SprintSections()
            {
                IEnumerable<TestCaseData> sections = GetData(BaseTest.ExcelDataPath, "Sections");
                return sections;
            }

            private static IEnumerable<TestCaseData> GetData(string path, string sheetName)
            {
                var testcases = ExcelDataReader.New().FromFileSystem(path).AddSheet(sheetName).GetTestCases(delegate (string sheet, System.Data.DataRow row, int rowNum)
                {
                    var testDataArgs = new Dictionary<string, string>();
                    foreach (System.Data.DataColumn column in row.Table.Columns)
                    {
                        testDataArgs[column.ColumnName] = Convert.ToString(row[column]);
                    }
                    string testName = sheet + " - " + row.ItemArray[0];
                    return new TestCaseData(testDataArgs).SetName(testName);
                });
                foreach (TestCaseData testCaseData in testcases)
                {
                    yield return testCaseData;
                }
            }
        }


        #region Extent Report

        public static ExtentReports ExtentReport = null;
        public static ExtentHtmlReporter HtmlReport = null;
        public static ExtentTest extentTest = null;
        public static void NullifyExtentReport()
        {
            ExtentReport = null;
            HtmlReport = null;
            extentTest = null;
            GC.Collect();
        }
        public void InitializeExtentReports(string Path, string NameOfReport)
        {
            BaseTest.HtmlReport = new ExtentHtmlReporter(Path);
            BaseTest.HtmlReport.Configuration().DocumentTitle = NameOfReport;
            BaseTest.HtmlReport.Configuration().Protocol = Protocol.HTTPS;
            BaseTest.HtmlReport.Configuration().Theme = Theme.Standard;
            BaseTest.HtmlReport.Configuration().ReportName = NameOfReport;
            BaseTest.ExtentReport.AttachReporter(BaseTest.HtmlReport);
        }
        public static void ExtentFailStep(Exception ex, string StepDetails, string Filename)
        {
            string ssLocation = Screenshot.TakeScreenShot(Screenshot.TakeSS_FullDesktop(), string.Format("Failure\\{0}", Filename), true);
            extentTest.Fail(StepDetails);
            extentTest.AddScreenCaptureFromPath(ssLocation);
            extentTest.Error(ex.ToString());
            Assert.Fail(ex.ToString());
        }

        #endregion Extent Report

        public static Logger logger = LogManager.GetCurrentClassLogger();
        public static StatusReport Report { get; set; }
        public static objMasterData MasterData { get; set; }
        public static UserConfig Config { get; set; }
        public static string ApplicationPath { get; private set; }
        public static int ProcessID { get; set; }

        public const int BUSYTIMEOUT_DEFAULT = 30000;

        public static Application TestedApplication { get; set; }
        public const string ExcelDataPath = objMasterData.MasterCodeFileLocalDirectory + "MasterData.xlsx";

        //public string testFixtureName = TestContext.CurrentContext.Test.Name;

        #region Launching and Attaching to Applications

        /// <summary>
        /// Useful when timing of attach is crucial, otherwise AttachToProcess(Processes) should be preferred. As this method does 
        /// not extra steps (logging, waiting, and so on)
        /// Note: Internally resets value of TestedApplication, if return is null, so will be BaseTest.TestedApplication
        /// </summary>
        /// <param name="DesiredProcess"></param>
        /// <param name="maxAttempts"></param>
        /// <returns>The Application reference that was identified, or null if no application was found for the DesiredProcess</returns>
        public static Application QuickAttachToProcess(Processes DesiredProcess, int maxAttempts = 50000)
        {
            TestedApplication = null;
            string desiredProcName = DesiredProcess.GetName();
            for (int attempts = 0; attempts < maxAttempts; attempts++)
                foreach (Process procs in Process.GetProcesses())
                    if (procs.ProcessName.Equals(desiredProcName))
                    {
                        TestedApplication = Application.Attach(desiredProcName);
                        ConfigureTestStackDefaults();
                        return TestedApplication;
                    }
            return null;
        }

        public static void AttachToProcess(Processes ProcessName, int MaxSecondsToWait = 300)
        {
            AttachToProcess(ProcessName.GetName(), MaxSecondsToWait);
            logger.Info("Attaching to Process: {0}", ProcessName.ToString());
        }
        public static void AttachToProcess(string ProcessName, int MaxSecondsToWait = 300)
        {
            bool found = false;
            int counter = 0;
            do
            {
                foreach (Process _pcs in Process.GetProcesses())
                {
                    if (_pcs.ProcessName.Equals(ProcessName))
                    {
                        ProcessID = _pcs.Id;
                        TestedApplication = Application.Attach(ProcessName);
                        ConfigureTestStackDefaults();
                        return;
                    }
                }
                System.Threading.Thread.Sleep(1000);
                counter++;
            } while (!found && (counter <= MaxSecondsToWait));
        }
        public static void LaunchApplication(DesktopApps application)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = application.GetApplicationLocation();
            LaunchApplication(psi);
        }
        private static void LaunchApplication(ProcessStartInfo psi)
        {
            TestedApplication = Application.AttachOrLaunch(psi);
            ConfigureTestStackDefaults();
        }

        public static void ConfigureTestStackDefaults()
        {
            //Console.WriteLine("BusyTimeout: " + CoreAppXmlConfiguration.Instance.BusyTimeout);
            //Console.WriteLine("ComboBoxItemSelectionTimeout: " + CoreAppXmlConfiguration.Instance.ComboBoxItemSelectionTimeout);
            //Console.WriteLine("ComboBoxItemsPopulatedWithoutDropDownOpen: " + CoreAppXmlConfiguration.Instance.ComboBoxItemsPopulatedWithoutDropDownOpen);
            //Console.WriteLine("DefaultDateFormat: " + CoreAppXmlConfiguration.Instance.DefaultDateFormat);
            //Console.WriteLine("DoubleClickInterval: " + CoreAppXmlConfiguration.Instance.DoubleClickInterval);
            //Console.WriteLine("DragStepCount: " + CoreAppXmlConfiguration.Instance.DragStepCount);
            //Console.WriteLine("FindWindowTimeout: " + CoreAppXmlConfiguration.Instance.FindWindowTimeout);
            //Console.WriteLine("HighlightTimeout: " + CoreAppXmlConfiguration.Instance.HighlightTimeout);
            //Console.WriteLine("InProc: " + CoreAppXmlConfiguration.Instance.InProc);
            //Console.WriteLine("KeepOpenOnDispose: " + CoreAppXmlConfiguration.Instance.KeepOpenOnDispose);
            //Console.WriteLine("MaxElementSearchDepth: " + CoreAppXmlConfiguration.Instance.MaxElementSearchDepth);
            //Console.WriteLine("MoveMouseToGetStatusOfHourGlass: " + CoreAppXmlConfiguration.Instance.MoveMouseToGetStatusOfHourGlass);
            //Console.WriteLine("PopupTimeout: " + CoreAppXmlConfiguration.Instance.PopupTimeout);
            //Console.WriteLine("RawElementBasedSearch: " + CoreAppXmlConfiguration.Instance.RawElementBasedSearch);
            //Console.WriteLine("RawInputQueueProcessingTime: " + CoreAppXmlConfiguration.Instance.RawInputQueueProcessingTime);
            //Console.WriteLine("SuggestionListTimeout: " + CoreAppXmlConfiguration.Instance.SuggestionListTimeout);
            //Console.WriteLine("TooltipWaitTime: " + CoreAppXmlConfiguration.Instance.TooltipWaitTime);
            ////Console.WriteLine("TooltipWaitTimeSpan: " + CoreAppXmlConfiguration.Instance.TooltipWaitTimeSpan.ToString());
            //Console.WriteLine("UIAutomationZeroWindowBugTimeout: " + CoreAppXmlConfiguration.Instance.UIAutomationZeroWindowBugTimeout);
            //Console.WriteLine("WaitBasedOnHourGlass: " + CoreAppXmlConfiguration.Instance.WaitBasedOnHourGlass);
            //Console.WriteLine("WorkSessionLocation: " + CoreAppXmlConfiguration.Instance.WorkSessionLocation.FullName);

            CoreAppXmlConfiguration.Instance.WaitBasedOnHourGlass = true;

            CoreAppXmlConfiguration.Instance.BusyTimeout = 120000;
            //CoreAppXmlConfiguration.Instance.ComboBoxItemSelectionTimeout = 15000;
            //CoreAppXmlConfiguration.Instance.ComboBoxItemsPopulatedWithoutDropDownOpen = true;
            //CoreAppXmlConfiguration.Instance.DoubleClickInterval = 0;
            //CoreAppXmlConfiguration.Instance.DragStepCount = 1;
            CoreAppXmlConfiguration.Instance.FindWindowTimeout = 30000;
            //CoreAppXmlConfiguration.Instance.HighlightTimeout = 5000;
            //CoreAppXmlConfiguration.Instance.InProc = false; //reasearch this more
            //CoreAppXmlConfiguration.Instance.KeepOpenOnDispose = false;
            //CoreAppXmlConfiguration.Instance.MaxElementSearchDepth = 10;
            //CoreAppXmlConfiguration.Instance.MoveMouseToGetStatusOfHourGlass = true;
            //CoreAppXmlConfiguration.Instance.PopupTimeout = 30000;
            //CoreAppXmlConfiguration.Instance.RawElementBasedSearch = false; //research this more
            //CoreAppXmlConfiguration.Instance.RawInputQueueProcessingTime = 150; //research this more
            //CoreAppXmlConfiguration.Instance.SuggestionListTimeout = 10000;
            //CoreAppXmlConfiguration.Instance.TooltipWaitTime = 6000;
            //CoreAppXmlConfiguration.Instance.UIAutomationZeroWindowBugTimeout = 15000;
            //CoreAppXmlConfiguration.Instance.WaitBasedOnHourGlass = true;
            //CoreAppXmlConfiguration.Instance.WorkSessionLocation = ".";
        }

        #endregion


        #region Custom Functions



        /// <summary>
        /// 
        /// </summary>
        /// <param name="SC"></param>
        /// <param name="maxWaitSeconds"></param>
        /// <returns>true if the window specified by SC exists, false otherwise</returns>
        public static bool checkForWindow(SearchCriteria SC, int maxWaitSeconds = 10)
        {
            bool Found = false;
            int counter = 0;
            string criteriaMatch1 = SC.ToString().Substring(SC.ToString().IndexOf('=') + 1);
            List<Window> windows = new List<Window>();
            AutomationElementCollection AEdescendants;
            PropertyCondition windowType = new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "window");
            PropertyCondition dialogType = new PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "dialog");
            OrCondition windowTypeConditions = new OrCondition(new Condition[] { windowType, dialogType });
            do
            {
                windows.Clear();
                TestedApplication.WaitWhileBusy();
                windows = Retry.For(() => TestedApplication.GetWindows(), TimeSpan.FromSeconds(2));
                if (windows.Count != 0)
                {
                    foreach (Window window in windows)
                    {
                        if (CheckCriteriaMatch(SC, window.AutomationElement))
                            return Found = true;
                        else
                        {
                            AEdescendants = Retry.For(() => window.AutomationElement.FindAll(TreeScope.Descendants, windowTypeConditions), TimeSpan.FromSeconds(2));
                            foreach (AutomationElement desc in AEdescendants)
                            {
                                if (CheckCriteriaMatch(SC, desc))
                                {
                                    return Found = true;
                                }
                            }
                        }
                    }
                }
                System.Threading.Thread.Sleep(1000);
                counter++;
            } while (!Found && counter < maxWaitSeconds);
            return Found;
        }

        public static bool checkForEmpowerMain_AtLogon(SearchCriteria SC, int maxWait = 10)
        {
            bool Found = false;
            int counter = 0;
            string criteriaMatch = SC.ToString().Substring(SC.ToString().IndexOf('=') + 1);
            //List<AutomationElement> descendants = new List<AutomationElement>();
            string id, name, className;
            List<Window> windows = new List<Window>();
            do
            {
                windows.Clear();
                windows = TestedApplication.GetWindows();
                if (windows.Count != 0)
                {
                    foreach (Window window in windows)//for (int i = 0; i < windows.Count; i++)
                    {
                        id = window.Id;
                        name = window.Name;
                        className = window.AutomationElement.Current.ClassName;
                        if ((id == criteriaMatch) || (name == criteriaMatch) || (className == criteriaMatch))
                            return Found = true;
                        else
                        {

                        }
                    }
                }
                System.Threading.Thread.Sleep(1000);
                counter++;
            } while (!Found && counter < maxWait);
            return Found;
        }

        public static string addLeadingZeroToDate(string MM_DD_YYYY)
        {
            string[] date = MM_DD_YYYY.Split('/');
            string newDate = "";

            string Month, Day;
            Month = date[0].Length == 1 ? string.Concat("0", date[0]) : date[0];
            Day = date[1].Length == 1 ? string.Concat("0", date[1]) : date[1];

            newDate = string.Format("{0}/{1}/{2}", Month, Day, date[2]);

            return newDate;
        }
        public static void ExecuteCmdLine(string CMD)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = ("/K" + CMD);

            using (Process exeProcess = Process.Start(startInfo))
            {
                exeProcess.WaitForExit(1000);
                exeProcess.Kill();
            }


        }
        public static string CreateRuntimeString()
        {
            string RunTimeString, Month, Day, Year, Hour, Minute, Second;
            DateTime dt = DateTime.Now;
            Month = dt.Month < 10 ? string.Concat("0", dt.Month.ToString()) : dt.Month.ToString();
            Day = dt.Day < 10 ? string.Concat("0", dt.Day.ToString()) : dt.Day.ToString();
            Year = dt.Year.ToString();
            Hour = dt.Hour < 10 ? string.Concat("0", dt.Hour.ToString()) : dt.Hour.ToString();
            Minute = dt.Minute < 10 ? string.Concat("0", dt.Minute.ToString()) : dt.Minute.ToString();
            Second = dt.Second < 10 ? string.Concat("0", dt.Second.ToString()) : dt.Second.ToString();
            RunTimeString = string.Format("Run {0}-{1}-{2}_{3}-{4}-{5}{6}", Month, Day, Year, Hour, Minute, Second, dt.ToString("tt"));
            return RunTimeString;
        }
        public static bool CheckCriteriaMatch(SearchCriteria SC, AutomationElement AE)
        {
            string searchCriteria, criteriaType, criteriaMatch;
            int indexEqualsign;
            searchCriteria = SC.ToString();
            indexEqualsign = searchCriteria.IndexOf('=');
            criteriaType = searchCriteria.Substring(0, indexEqualsign);
            criteriaMatch = searchCriteria.Substring(searchCriteria.IndexOf('=') + 1);
            switch (criteriaType)
            {
                case "AutomationId":
                    if (AE.Current.AutomationId == criteriaMatch)
                        return true;
                    break;
                case "ClassName":
                    if (AE.Current.ClassName == criteriaMatch)
                        return true;
                    break;
                case "Name":
                    if (AE.Current.Name == criteriaMatch)
                        return true;
                    break;
                default:
                    throw new Exception("Search Criteria Type does not match a type inside switch.");
            }
            return false;
        }
        public static PropertyCondition ConvertSearchCriteriaToPropertyCondition(SearchCriteria SC)
        {
            string searchCriteria, criteriaType, searchCriteriaString;
            int indexEqualsign;
            searchCriteria = SC.ToString();
            indexEqualsign = searchCriteria.IndexOf('=');
            criteriaType = searchCriteria.Substring(0, indexEqualsign);
            searchCriteriaString = searchCriteria.Substring(searchCriteria.IndexOf('=') + 1);
            switch (criteriaType)
            {
                case "AutomationId":
                    return new PropertyCondition(AutomationElement.AutomationIdProperty, searchCriteriaString);
                    break;
                case "ClassName":
                    return new PropertyCondition(AutomationElement.ClassNameProperty, searchCriteriaString);
                    break;
                case "Name":
                    return new PropertyCondition(AutomationElement.NameProperty, searchCriteriaString);
                    break;
                default:
                    throw new Exception("Search Criteria Type does not match a type inside switch.");
            }
        }


        #endregion
    }

    public enum Processes
    {
        Calculator,
        Encompass,
        Firefox,
        Jing
    };

    public enum DesktopApps
    {
        Calculator,
        Encompass,
        Firefox,
        Jing
    };

    public static class Extensions
    {
        public static void AttachToProcess(this Processes process, int maxSecondsToWait = 300)
        {
            bool found = false;
            int counter = 0;
            do
            {
                foreach (Process _pcs in Process.GetProcesses())
                {
                    if (_pcs.ProcessName.Equals(process.GetName()))
                    {
                        BaseTest.ProcessID = _pcs.Id;
                        BaseTest.TestedApplication = Application.Attach(process.GetName());
                        BaseTest.ConfigureTestStackDefaults();
                        return;
                    }

                }
                System.Threading.Thread.Sleep(1000);
                counter++;
            } while (!found && (counter <= maxSecondsToWait));

        }
        public static string GetName(this Processes proc)
        {
            switch (proc)
            {
                case Processes.Calculator: return "calc";
                case Processes.Encompass: return "Encompass";
                case Processes.Firefox: return "Mozilla Firefox";
                case Processes.Jing: return "Jing Preview";
                default: throw new Exception("The Processes enum provided is not implemented!");
            }
        }

        public static string GetApplicationLocation(this DesktopApps deskApp)
        {
            switch (deskApp)
            {
                case DesktopApps.Calculator: return @"C:\Windows\System32\calc.exe";
                case DesktopApps.Encompass: return @"C:\SmartClientCache\Apps\Ellie Mae\Encompass\AppLauncher.exe";
                case DesktopApps.Firefox: return @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                case DesktopApps.Jing: return @"C:\Users\hcharls\Downloads\jing.exe";
                default: throw new Exception("The DesktopApps enum provided is not implemented!");
            }
        }
    }
}
