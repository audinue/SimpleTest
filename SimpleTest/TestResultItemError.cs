using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTest
{
    public class TestResultItemError
    {
        public string Message { get; private set; }
        public string StackTrace { get; private set; }

        public TestResultItemError(string message, string stackTrace)
        {
            Message = message;
            StackTrace = stackTrace;
        }

        public static readonly TestResultItemError Empty = new TestResultItemError(string.Empty, string.Empty);
    }
}
