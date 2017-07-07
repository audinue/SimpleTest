using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTest
{
    public static class Application
    {
        public static void Run()
        {
            var result = new TestExecutor().Execute();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(new string('*', Console.BufferWidth));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(result.Name);
            foreach (var group in result.Groups)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(new string('=', Console.BufferWidth));
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(group.Name);
                foreach (var item in group.Items)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(new string('-', Console.BufferWidth));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("  {0}: ", item.Name);
                    if (item.Success)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Success");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Failed");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("    \"{0}\"", item.Error.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(item.Error.StackTrace);
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(new string('*', Console.BufferWidth));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Total Success: {0}", result.TotalSuccess);
            Console.WriteLine("Total Failed : {0}", result.TotalFailed);
            Console.WriteLine("Test Count   : {0}", result.TestCount);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(new string('*', Console.BufferWidth));
            Console.ResetColor();
        }

        public static void RunPaused()
        {
            Run();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
