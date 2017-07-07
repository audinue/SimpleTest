using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTest
{
    public abstract class Test
    {
        public virtual void OnInitialize()
        {
        }

        public virtual void OnFinalize()
        {
        }

        public virtual void OnBeforeExecute(string methodName)
        {
        }

        public virtual void OnAfterExecute(string methodName)
        {
        }

        protected void Assert(bool condition, string format, params object[] args)
        {
            if (!condition)
            {
                throw new Exception(string.Format(format, args));
            }
        }

        protected void Assert(bool condition)
        {
            Assert(condition, "Assertion failed.");
        }

        protected void AssertEqual<T>(T a, T b)
        {
            Assert(EqualityComparer<T>.Default.Equals(a, b), "Equal assertion failed. (a={0}; b={1})", a, b);
        }
    }
}
