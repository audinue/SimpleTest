using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTest
{
    public class TestResultItem
    {
        public string Name { get; private set; }
        public bool Success { get; private set; }
        public TestResultItemError Error { get; private set; }

        private TestResultItem(string name, bool success, TestResultItemError error)
        {
            Name = name;
            Success = success;
            Error = error;
        }

        public TestResultItem(string methodName)
            : this(methodName, true, TestResultItemError.Empty)
        {
        }

        public TestResultItem(string methodName, TestResultItemError error)
            : this(methodName, false, error)
        {
        }
    }
}
