using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BaseAutomationFramework.Tools
{
    public sealed class FileUtilities
    {
        public const string DefaultDataDir = @"C:\Automation_Data\";
        public const string DefaultTestResultDirectory = @"C:\Automation_Data\Test_Results";
		public const string DefaultTestResultDirectory_ShareDrive = @"\\pem\homedrive\Business Systems Support\QA\Automation\Test Results";

		public static Dictionary<string, string> ReadConfig_CreateDictionary(string FilePath)
		{
			Dictionary<string, string> dic = new Dictionary<string, string>();

			StreamReader reader = new StreamReader(FilePath);

			Dictionary<string, string> parameters = new Dictionary<string, string>();

			string line = "";
			string[] lineArray;
			while (!reader.EndOfStream)
			{
				line = reader.ReadLine();
				lineArray = line.Split('=');
				string key = lineArray[0];
				string value = lineArray[1];

				dic.Add(key, value);
			}

			reader.Close();

			return dic;
		}

	}
}
