using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTest
{
    public class TestExecutor
    {
        public TestResult Execute()
        {
            var types = Assembly.GetEntryAssembly()
               .GetTypes()
               .Where(type => type.IsSubclassOf(typeof(Test)));
            var groups = new List<TestResultGroup>();
            foreach (var type in types)
            {
                var methods = type.GetMethods()
                    .Where(method => method.GetParameters().Length == 0 && !";GetType;Equals;GetHashCode;ToString;OnInitialize;OnFinalize;OnBeforeExecute;OnAfterExecute;".Contains(method.Name));
                var instance = Activator.CreateInstance(type);
                var items = new List<TestResultItem>();
                var onInitialize = type.GetMethod("OnInitialize");
                var onFinalize = type.GetMethod("OnFinalize");
                var onBeforeExecute = type.GetMethod("OnBeforeExecute");
                var onAfterExecute = type.GetMethod("OnAfterExecute");
                try
                {
                    ((Action)Delegate.CreateDelegate(typeof(Action), instance, onInitialize))();
                }
                catch (Exception e)
                {
                    items.Add(new TestResultItem(onInitialize.Name, new TestResultItemError(e.Message, e.StackTrace)));
                }
                foreach (var method in methods)
                {
                    try
                    {
                        try
                        {
                            ((Action<string>)Delegate.CreateDelegate(typeof(Action<string>), instance, onBeforeExecute))(method.Name);
                        }
                        catch (Exception e)
                        {
                            items.Add(new TestResultItem(onInitialize.Name, new TestResultItemError(e.Message, e.StackTrace)));
                        }
                        ((Action)Delegate.CreateDelegate(typeof(Action), instance, method))();
                        try
                        {
                            ((Action<string>)Delegate.CreateDelegate(typeof(Action<string>), instance, onAfterExecute))(method.Name);
                        }
                        catch (Exception e)
                        {
                            items.Add(new TestResultItem(onInitialize.Name, new TestResultItemError(e.Message, e.StackTrace)));
                        }
                        items.Add(new TestResultItem(method.Name));
                    }
                    catch (Exception e)
                    {
                        items.Add(new TestResultItem(method.Name, new TestResultItemError(e.Message, e.StackTrace)));
                    }
                }
                groups.Add(new TestResultGroup(type.FullName, items));
                try
                {
                    ((Action)Delegate.CreateDelegate(typeof(Action), instance, onFinalize))();
                }
                catch (Exception e)
                {
                    items.Add(new TestResultItem(onFinalize.Name, new TestResultItemError(e.Message, e.StackTrace)));
                }
            }
            return new TestResult(Assembly.GetEntryAssembly().GetName().Name, groups);
        }
    }
}
