using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTest
{
    public class TestResultGroup
    {
        public string Name { get; private set; }
        public IEnumerable<TestResultItem> Items { get; private set; }

        public TestResultGroup(string name, IEnumerable<TestResultItem> items)
        {
            Name = name;
            Items = items;
        }
    }
}
