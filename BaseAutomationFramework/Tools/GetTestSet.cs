using System;

namespace BaseAutomationFramework.Tools
{
    [AttributeUsage(AttributeTargets.Method)]
    public class GetTestSet : Attribute
    {
        public static string testSetName { get; set; }

        public GetTestSet(string name)
        {
            testSetName = name;
        }
    }
}
