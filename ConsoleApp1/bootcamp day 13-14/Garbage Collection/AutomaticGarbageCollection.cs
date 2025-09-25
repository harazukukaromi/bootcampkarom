/*using System;

class MyObject
{
    private int[] _data;

    public MyObject(int size)
    {
        _data = new int[size];
        Console.WriteLine($"MyObject created with size {size}.");
    }

    ~MyObject()
    {
        Console.WriteLine("MyObject finalized (collected by GC).");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Starting Garbage Collection Demo\n");

        CreateObjects();

        // Force garbage collection manually
        Console.WriteLine("\nForcing Garbage Collection...");
        GC.Collect();
        GC.WaitForPendingFinalizers(); // Wait for finalizers to run
        GC.Collect(); // Second collection to reclaim finalized objects

        Console.WriteLine("\nGC completed.");
        Console.WriteLine($"Total memory: {GC.GetTotalMemory(false)} bytes");
    }

    static void CreateObjects()
    {
        for (int i = 0; i < 5; i++)
        {
            MyObject obj = new MyObject(1000000); // ~4MB per object
        }

        Console.WriteLine("Objects created, exiting method...");
    }
}*/
