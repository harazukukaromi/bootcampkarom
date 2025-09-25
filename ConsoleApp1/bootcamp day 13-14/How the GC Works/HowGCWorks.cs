/*
using System;
using System.Runtime;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WriteLine("Setting LOH compaction mode to CompactOnce...");

        // Request LOH compaction on the next full blocking GC
        GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;

        // Allocate some large objects to fill LOH
        byte[] largeArray1 = new byte[850_000]; // > 85,000 bytes to go to LOH
        byte[] largeArray2 = new byte[900_000];

        Console.WriteLine("Allocated large objects on the LOH.");

        // Now force a full GC to trigger compaction
        Console.WriteLine("Forcing full GC to trigger LOH compaction...");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        Console.WriteLine("LOH compaction should have occurred once.");

        // Further GCs won't compact LOH until you set this property again
    }
}
*/
