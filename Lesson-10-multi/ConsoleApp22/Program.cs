using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Sean2.Run();
            stopwatch.Stop();
            Console.WriteLine("Time: "+ stopwatch.Elapsed.ToString("c"));

            Parallel.For(0, 100_000, (index) =>
            {
                var myClass = new MyClass();
            });

            Console.WriteLine(MyClass._noCreated);


        }

        class MyClass
        {
            public static int _noCreated = 0;
            private static object _myLock = new object();

            public MyClass()
            {
                Interlocked.Increment(ref _noCreated);
            }
        }
    }
}
