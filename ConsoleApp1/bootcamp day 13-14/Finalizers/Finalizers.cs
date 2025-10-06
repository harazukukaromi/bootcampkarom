/*using System;
//Finalizer
class Test
{
    public Test()
    {
        Console.WriteLine("Test object created.");
    }

    ~Test() // Finalizer
    {
        Console.WriteLine("Test object finalized (collected by GC).");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Program started.\n");

        CreateTestObject();

        // Force garbage collection
        Console.WriteLine("\nForcing garbage collection...");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("\nProgram ended.");
    }

    static void CreateTestObject()
    {
        Test t = new Test();
        // The object becomes unreachable after this method ends
    }
}*/
