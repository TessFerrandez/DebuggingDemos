using Microsoft.Diagnostics.Runtime;
using System;
using System.Linq;

namespace AutomationWithCLRMD
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTarget target = DataTarget.LoadCrashDump(@"C:\Old Stuff\Presentations\debugging\Demo Dumps\Crash 1 - ThePresidents.exe_170302_234416.dmp");
            target.SymbolLocator.SymbolCache = @"c:\symbols";
            target.SymbolLocator.SymbolPath = "http://msdl.microsoft.com/download/symbols";
            var runtime = target.ClrVersions[0].CreateRuntime();

            Console.WriteLine("Is Server GC: {0}", runtime.ServerGC);
            Console.WriteLine("Number of heaps: {0}", runtime.HeapCount);
            Console.WriteLine("Number of threads: {0}", runtime.Threads.Count);

            #region list modules
            //PRINT THE MODULES
            if (args.Contains("-lm"))
            {
                foreach (var module in runtime.Modules)
                {
                    Console.WriteLine(module.AssemblyName);
                }
            }
            #endregion

            #region display all objects
            if (args.Contains("-dao"))
            {
                var heap = runtime.GetHeap();
                Console.WriteLine("Total heap size {0}", heap.TotalHeapSize);
                foreach (var type in heap.EnumerateTypes())
                {
                    Console.WriteLine(type.Name);
                }
            }
            #endregion

            foreach (var thread in runtime.Threads)
            {
                if (args.Contains("-at"))
                {
                    #region all threads
                    //PRINT ALL THREADS
                    Console.WriteLine("Thread {0}", thread.ManagedThreadId);
                    Console.WriteLine("----------------------------------");
                    foreach (var frame in thread.StackTrace)
                    {
                        Console.WriteLine(frame.DisplayString);
                    }
                    #endregion
                }
                else
                {
                    #region only threads with exceptions
                    //DISPLAY ONLY THREADS WITH EXCEPTIONS
                    var e = thread.CurrentException;
                    if (e != null)
                    {
                        Console.WriteLine("Thread {0}", thread.ManagedThreadId);
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("\t{0} - {1}", e.Type.Name, e.Message);
                        Console.WriteLine("----------------------------------");
                        foreach (var frame in e.StackTrace)
                            Console.WriteLine("\t" + frame.DisplayString);
                    }
                    #endregion  
                }
            }

            Console.ReadLine();
        }
    }
}
