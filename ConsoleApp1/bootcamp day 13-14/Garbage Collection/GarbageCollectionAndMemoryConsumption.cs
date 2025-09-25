/*using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        // Get the name of the current process
        string procName = Process.GetCurrentProcess().ProcessName;

        // Create a performance counter to monitor private bytes (memory) of the current process
        using PerformanceCounter pc = new PerformanceCounter("Process", "Private Bytes", procName);

        Console.WriteLine($"Monitoring private bytes of process: {procName}\n");

        // Read the counter value a few times
        for (int i = 0; i < 10; i++)
        {
            float bytesUsed = pc.NextValue();
            Console.WriteLine($"Private Bytes: {bytesUsed} bytes ({bytesUsed / (1024 * 1024):F2} MB)");
            Thread.Sleep(1000); // Wait 1 second between reads
        }

        Console.WriteLine("\nDone monitoring.");
    }
}*/