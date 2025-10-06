/*using System;

class Program
{
    static void Main()
    {
        string str1 = "Hello";
        string str2 = "hello";
        string str3 = "Hello";

        // EQUALITY COMPARISON
        Console.WriteLine("=== EQUALITY COMPARISON ===");
        Console.WriteLine($"'{str1}' == '{str3}': {str1 == str3}");                 // True
        Console.WriteLine($"'{str1}' == '{str2}': {str1 == str2}");                 // False
        Console.WriteLine($"'{str1}'.Equals('{str2}'): {str1.Equals(str2)}");       // False

        // STRING COMPARISON OPTIONS
        Console.WriteLine("\n=== STRING COMPARISON OPTIONS ===");
        Console.WriteLine($"Ordinal (default): {string.Equals(str1, str2, StringComparison.Ordinal)}"); // False
        Console.WriteLine($"OrdinalIgnoreCase: {string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase)}"); // True
        Console.WriteLine($"CurrentCulture: {string.Equals(str1, str2, StringComparison.CurrentCulture)}"); // False (depends on culture)
        Console.WriteLine($"CurrentCultureIgnoreCase: {string.Equals(str1, str2, StringComparison.CurrentCultureIgnoreCase)}"); // True
        Console.WriteLine($"InvariantCulture: {string.Equals(str1, str2, StringComparison.InvariantCulture)}"); // False
        Console.WriteLine($"InvariantCultureIgnoreCase: {string.Equals(str1, str2, StringComparison.InvariantCultureIgnoreCase)}"); // True


        // ORDER COMPARISON (SORTING)
        Console.WriteLine("\n=== ORDER COMPARISON ===");
        string[] words = { "apple", "Banana", "cherry", "Date" };
        Console.WriteLine("Original order: " + string.Join(", ", words));

        // Default culture-sensitive sort
        Array.Sort(words, string.Compare);
        Console.WriteLine("Culture sort: " + string.Join(", ", words));

        // Reset array
        words = new[] { "apple", "Banana", "cherry", "Date" };

        // Ordinal comparison (based on Unicode)
        Array.Sort(words, StringComparer.Ordinal);
        Console.WriteLine("Ordinal sort: " + string.Join(", ", words));

        // Case-insensitive ordinal comparison
        Array.Sort(words, StringComparer.OrdinalIgnoreCase);
        Console.WriteLine("Ordinal ignore case: " + string.Join(", ", words));

        // COMPARETO EXAMPLES
        Console.WriteLine("\n=== COMPARETO EXAMPLES ===");
        Console.WriteLine($"'Boston'.CompareTo('Austin'): {string.Compare("Boston", "Austin")}");   // > 0
        Console.WriteLine($"'Boston'.CompareTo('Boston'): {string.Compare("Boston", "Boston")}");   // 0
        Console.WriteLine($"'Boston'.CompareTo('Chicago'): {string.Compare("Boston", "Chicago")}"); // < 0

        // ORDINAL VS CULTURE COMPARISON
        Console.WriteLine("\n=== ORDINAL VS CULTURE COMPARISON ===");
        string a = "Atom";
        string b = "atom";
        Console.WriteLine($"Ordinal: '{a}' vs '{b}' = {string.Compare(a, b, StringComparison.Ordinal)}"); // -32
        Console.WriteLine($"Culture: '{a}' vs '{b}' = {string.Compare(a, b, StringComparison.CurrentCulture)}"); // depends on culture, often -1 or 0
        Console.WriteLine("Note: Ordinal treats 'A' (65) and 'a' (97) by Unicode values");
        Console.WriteLine("Culture comparison considers language rules for proper alphabetical ordering");

        Console.WriteLine();
    }
}*/
