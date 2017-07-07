using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTest
{
    public class TestResult
    {
        public string Name { get; private set; }
        public IEnumerable<TestResultGroup> Groups { get; private set; }

        public TestResult(string name, IEnumerable<TestResultGroup> groups)
        {
            Name = name;
            Groups = groups;
        }

        public int TotalSuccess
        {
            get
            {
                return Groups
                    .SelectMany(group => group.Items)
                    .Aggregate(0, (accumulator, item) => accumulator + (item.Success ? 1 : 0));
            }
        }

        public int TotalFailed
        {
            get
            {
                return Groups
                    .SelectMany(group => group.Items)
                    .Aggregate(0, (accumulator, item) => accumulator + (item.Success ? 0 : 1));
            }
        }

        public int TestCount
        {
            get
            {
                return TotalSuccess + TotalFailed;
            }
        }
    }
}
