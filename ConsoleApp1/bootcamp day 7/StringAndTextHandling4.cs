/*using System;
using System.Text;
//String Builder
class Program
{
    static void Main()
    {
        // StringBuilder for efficient string building - mutable strings
        // Critical when you need to build strings in loops or with many operations
        Console.WriteLine("=== BASIC STRINGBUILDER OPERATIONS ===");

        StringBuilder sb = new StringBuilder();
        Console.WriteLine($"Initial capacity: {sb.Capacity}");
        Console.WriteLine($"Initial length: {sb.Length}");

        // Building strings efficiently
        for (int i = 0; i < 20; i++)
        {
            sb.Append($"Item {i}, ");
        }

        Console.WriteLine($"After appending 20 items:");
        Console.WriteLine($"Length: {sb.Length}, Capacity: {sb.Capacity}");
        Console.WriteLine($"Content: {sb.ToString()}");

        // StringBuilder with initial capacity - performance optimization
        Console.WriteLine("\n=== CAPACITY MANAGEMENT ===");
        StringBuilder sbWithCapacity = new StringBuilder(200); // Pre-allocate capacity
        Console.WriteLine($"StringBuilder with initial capacity 200: {sbWithCapacity.Capacity}");

        // Various StringBuilder methods
        Console.WriteLine("\n=== STRINGBUILDER METHODS ===");
        sb.Clear();
        sb.AppendLine("First line");
        sb.AppendLine("Second line");
        sb.Insert(0, "Header: ");
        sb.Replace("First", "Primary");
        sb.AppendFormat("Formatted number: {0:N2}", 12345.67);
        sb.AppendLine();

        Console.WriteLine("StringBuilder after various operations:");
        Console.WriteLine(sb.ToString());

        // Writable indexer - you can modify individual characters
        Console.WriteLine("\n=== MUTABLE CHARACTER ACCESS ===");
        StringBuilder demo = new StringBuilder("Hello World");
        Console.WriteLine($"Original: {demo}");
        demo[0] = 'h'; // Change 'H' to 'h'
        Console.WriteLine($"After changing index 0: {demo}");


        // Method chaining with StringBuilder
        StringBuilder chained = new StringBuilder()
            .Append("Method ")
            .Append("chaining ")
            .Append("works ")
            .AppendLine("great!");
        Console.WriteLine($"Method chaining result: {chained}");

        Console.WriteLine();
    }
}*/
