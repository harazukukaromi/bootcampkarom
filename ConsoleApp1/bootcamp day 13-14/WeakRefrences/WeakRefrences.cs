/*
using System;
using System.Text;
//How Weak References Work
class Program
{
    static void Main()
    {
        Console.WriteLine("=== WeakReference: Strongly Referenced ===");

        var sb = new StringBuilder("this is a test");
        var weak1 = new WeakReference(sb);

        Console.WriteLine("Before GC: " + (weak1.Target ?? "collected")); // Should print the string
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("After GC (strong ref exists): " + (weak1.Target ?? "collected")); // Still prints

        Console.WriteLine("\n=== WeakReference: No Strong Reference ===");

        var weak2 = GetWeakRef(); // The object is only weakly referenced
        Console.WriteLine("Before GC: " + (weak2.Target ?? "collected")); // May or may not be collected yet

        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("After GC: " + (weak2.Target ?? "collected")); // Likely collected
    }

    static WeakReference GetWeakRef()
    {
        var sb = new StringBuilder("weak");
        var weak = new WeakReference(sb);

        // sb goes out of scope after this method ends, making it eligible for GC
        return weak;
    }
}
*/