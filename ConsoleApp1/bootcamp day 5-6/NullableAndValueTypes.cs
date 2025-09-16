using System;
// Basic Null types
class Program
{
    static void DemonstrateTheBasicProblem()
    {
        // Reference types can naturally represent "no value" with null
        string? someText = null;  // Perfectly valid - means "no text"
        object? someObject = null;  // Also valid - means "no object"
        
        Console.WriteLine($"Reference type (string): {someText ?? "null"}");
        Console.WriteLine($"Reference type (object): {someObject ?? "null"}");

        // But value types always contain some value - they can't be "empty"
        int regularInt = default;    // This gives us 0, not "nothing"
        bool regularBool = default;  // This gives us false, not "unknown"
        DateTime regularDate = default;  // This gives us 1/1/0001, not "no date"

        Console.WriteLine($"Value type (int): {regularInt}");
        Console.WriteLine($"Value type (bool): {regularBool}");
        Console.WriteLine($"Value type (DateTime): {regularDate}");

        Console.WriteLine("\nThe Problem:");
        Console.WriteLine("- What if we need to represent 'unknown age' in a Person class?");
        Console.WriteLine("- What if a database column allows NULL for an integer field?");
        Console.WriteLine("- What if a user hasn't provided their birth date yet?");
        
        // This won't compile - demonstrates the problem
        // int impossibleInt = null;  // Compile error!

        // Examples of nullable value types
        int? nullableInt = null;
        bool? nullableBool = null;
        DateTime? nullableDate = null;

        Console.WriteLine($"Nullable int: {(nullableInt.HasValue ? nullableInt.Value.ToString() : "null")}");
        Console.WriteLine($"Nullable bool: {(nullableBool.HasValue ? nullableBool.Value.ToString() : "null")}");
        Console.WriteLine($"Nullable DateTime: {(nullableDate.HasValue ? nullableDate.Value.ToString() : "null")}");

        // Assigning values later
        nullableInt = 25;
        nullableBool = true;
        nullableDate = DateTime.Today;

        Console.WriteLine("\nAfter assigning values:");
        Console.WriteLine($"Nullable int: {(nullableInt.HasValue ? nullableInt.Value.ToString() : "null")}");
        Console.WriteLine($"Nullable bool: {(nullableBool.HasValue ? nullableBool.Value.ToString() : "null")}");
        Console.WriteLine($"Nullable DateTime: {(nullableDate.HasValue ? nullableDate.Value.ToString() : "null")}");
    }

    static void Main()
    {
        DemonstrateTheBasicProblem();
    }
}
