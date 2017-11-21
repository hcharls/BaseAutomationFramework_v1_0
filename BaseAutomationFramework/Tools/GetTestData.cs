using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;

namespace BaseAutomationFramework.Tools
{
    using Tests;

    public class GetTestData
    {
        public IEnumerable<TestCaseData> Screen
        {
            get
            {
                IEnumerable<TestCaseData> testcases = GetData(BaseTest.ExcelDataPath);

                return testcases;
            }
        }

        private static string lastPath = null;
        private static List<TestCaseData> lastResult = null;

        private IEnumerable<TestCaseData> GetData(string path)
        {
            List<TestCaseData> tcd = null;
            if (lastPath != null && path.Equals(lastPath))
                tcd = lastResult;
            else
            {
                lastPath = path; //for next call to GetData
                var testcases = ExcelDataReader.New().FromFileSystem(path).AddSheet(GetTestSet.testSetName).GetTestCases(delegate(string sheet, DataRow row, int rowNum)
                {
                    var testDataArgs = new Dictionary<string, string>();
                    foreach (DataColumn column in row.Table.Columns)
                    {
                        testDataArgs[column.ColumnName] = Convert.ToString(row[column]);
                    }
                    string testName = sheet + " - " + row.ItemArray[0];
                    return new TestCaseData(testDataArgs).SetName(testName);
                });
                lastResult = tcd = testcases;
            }
            foreach (TestCaseData testCaseData in tcd)
            {
                yield return testCaseData;
            }
        }
    }
}
