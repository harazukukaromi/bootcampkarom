/*
using System;

class SampleObject
{
    private int _id;

    public SampleObject(int id)
    {
        _id = id;
        Console.WriteLine($"Object {_id} created.");
    }

    ~SampleObject()
    {
        Console.WriteLine($"Finalizer called for object {_id}.");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Starting program...\n");

        CreateObjects();

        Console.WriteLine("\n--- Forcing Garbage Collection ---\n");

        // Step 1: Force a full GC
        GC.Collect();

        // Step 2: Wait for finalizers to complete
        GC.WaitForPendingFinalizers();

        // Step 3: Collect objects that became unreachable after finalization
        GC.Collect();

        Console.WriteLine("\nGarbage Collection complete.");
    }

    static void CreateObjects()
    {
        for (int i = 1; i <= 5; i++)
        {
            var obj = new SampleObject(i);
        }

        // All SampleObject instances become unreachable here
    }
}*/
