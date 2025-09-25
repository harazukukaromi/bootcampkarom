/*
using System;

using System.Collections.Generic;
using System.Threading;

class Program
{
    static List<byte[]> memoryLeakSimulator = new List<byte[]>();

    static void Main()
    {
        Console.WriteLine("Starting memory diagnostic...");
        Console.WriteLine("Press any key to stop.\n");

        int iteration = 0;

        while (!Console.KeyAvailable)
        {
            // Simulate a memory leak (comment this out to test without a leak)
            SimulateLeak();

            // Force full GC for accurate measurement
            long memoryUsed = GC.GetTotalMemory(forceFullCollection: true);
            Console.WriteLine($"[{++iteration}] Memory used: {memoryUsed / 1024.0 / 1024.0:F2} MB");

            Thread.Sleep(1000);
        }

        Console.WriteLine("\nDiagnostic stopped. Press any key to exit.");
        Console.ReadKey(true);
    }

    static void SimulateLeak()
    {
        // Simulate holding onto memory that won't be released
        memoryLeakSimulator.Add(new byte[1024 * 100]); // 100 KB
    }
}
*/