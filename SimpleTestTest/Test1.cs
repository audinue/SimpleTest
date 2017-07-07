using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTest;

namespace SimpleTestTest
{
    public class Test1 : Test
    {
        public void TestSuccess()
        {
        }

        public void TestFailed()
        {
            throw new Exception("Wow amazing! This test is failing!");
        }

        public void TestAssertSuccess()
        {
            Assert(true);
        }

        public void TestAssertFailed()
        {
            Assert(false);
        }

        public void TestAssertFailedMessage()
        {
            Assert(false, "WTF dude??!");
        }

        public void TestAssertEqualSuccess()
        {
            AssertEqual(1, 1);
        }

        public void TestAssertEqualFailed()
        {
            AssertEqual(1, 2);
        }
    }
}
