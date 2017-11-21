using NLog;
using NLog.Targets;
using System;
using System.IO;

namespace BaseAutomationFramework.Tools
{
    public class LoggerMethods
    {
        public DateTime dateTime { get; private set; }

        public LoggerMethods()
        {
            dateTime = getCurrentDateTime();
        }
        private static DateTime getCurrentDateTime()
        {
            DateTime dt = DateTime.Now;
            DateTime dtime = dt;
            return dtime;
        }
        public static void createLogPath(string testContextName, DateTime dt)
        {
            foreach (FileTarget file in LogManager.Configuration.AllTargets)
            {
                string path = string.Format("C:\\Automation_Data\\{0}.txt", file.Name);
                if (File.Exists(path))
                    File.Delete(path);
                File.Create(path);
            }
            Directory.CreateDirectory(string.Format("C:\\Automation_Data\\{0}", testContextName));
            Directory.CreateDirectory(string.Format("C:\\Automation_Data\\{0}\\Run - {1}_{2}_{3}-{4}_{5}", testContextName, dt.Month, dt.Day, dt.Year, dt.Hour, dt.Minute));
            Directory.CreateDirectory(string.Format("C:\\Automation_Data\\{0}\\Run - {1}_{2}_{3}-{4}_{5}\\Screenshots", testContextName, dt.Month, dt.Day, dt.Year, dt.Hour, dt.Minute));
        }
        public static void moveLogs(string testContextName, DateTime dt)
        {
            foreach (FileTarget file in LogManager.Configuration.AllTargets)
            {
                File.Move(string.Format("C:\\Automation_Data\\{0}.txt", file.Name), string.Format("C:\\Automation_Data\\{0}\\Run - {1}_{2}_{3}-{4}_{5}\\{6}.txt", testContextName, dt.Month, dt.Day, dt.Year, dt.Hour, dt.Minute, file.Name));
            }
        }








    }
}
