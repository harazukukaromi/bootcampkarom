/*using System;
using System.Collections.Generic;
// Collection Initalizer
class Program
{
    static void Main()
    {
        // --- List<int> examples ---

        // Inline initializer
        var list1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
        Console.WriteLine("List1 contents (using inline initializer):");
        foreach (int num in list1)
        {
            Console.WriteLine($"  {num}");
        }

        // Manual Add
        List<int> list2 = new List<int>();
        list2.Add(1);
        list2.Add(2);
        list2.Add(3);
        list2.Add(4);
        list2.Add(5);
        list2.Add(6);
        list2.Add(7); 

        Console.WriteLine("\nList2 contents (using Add method):");
        foreach (int num in list2)
        {
            Console.WriteLine($"  {num}");
        }

        // --- Dictionary<int, string> examples ---

        // Key-value pair initializer
        var dict1 = new Dictionary<int, string>()
        {
            { 5, "five" },
            { 10, "ten" },
            { 15, "fifteen"},
            { 20, "twenty"}
        };
        Console.WriteLine("\nDictionary1 contents (using key-value pair syntax):");
        foreach (var kvp in dict1)
        {
            Console.WriteLine($"  Key: {kvp.Key}, Value: {kvp.Value}");
        }

        // Indexer initializer (C# 6.0+)
        var dict2 = new Dictionary<int, string>()
        {
            [3] = "three",
            [10] = "ten",
            [13] = "thirteen",
            [20] = "twenty"
        };
        Console.WriteLine("\nDictionary2 contents (using indexer initializer syntax):");
        foreach (var kvp in dict2)
        {
            Console.WriteLine($"  Key: {kvp.Key}, Value: {kvp.Value}");
        }
    }
}*/
