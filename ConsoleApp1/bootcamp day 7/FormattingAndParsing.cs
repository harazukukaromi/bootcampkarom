/*using System;
using System.Globalization;

//Basic ToString() and Parse()/TryParse()
class Program
{
    static void Main()
    {
        // Boolean to string and back
        string s = true.ToString();       // s = "True"
        bool b = bool.Parse(s);           // b = true
        Console.WriteLine($"Boolean string: {s}, Parsed back: {b}");

        // Integer parsing with TryParse
        bool failure = int.TryParse("qwerty", out int i1);   // invalid input
        bool success = int.TryParse("123", out int i2);       // valid input
        bool wasParsed = int.TryParse("456", out int result); // another valid input
        bool isValidInput = int.TryParse("789", out _);       // using discard for value

        Console.WriteLine($"\nParsing 'qwerty': success={failure}, value={i1}");
        Console.WriteLine($"Parsing '123': success={success}, value={i2}");
        Console.WriteLine($"Parsing '456': success={wasParsed}, value={result}");
        Console.WriteLine($"Parsing '789' (discard value): success={isValidInput}");

        // Culture-specific parsing
        Console.WriteLine("\n--- Culture-Specific Parsing ---");

        // Simulate German culture
        CultureInfo germanCulture = new CultureInfo("de-DE");

        double germanParsed1 = double.Parse("1.234", germanCulture); // "1.234" in German = 1234
        double germanParsed2 = double.Parse("1,234", germanCulture); // "1,234" in German = 1.234

        Console.WriteLine($"German culture - Parse '1.234': {germanParsed1}");
        Console.WriteLine($"German culture - Parse '1,234': {germanParsed2}");

        // Invariant culture parsing
        double invariantParsed = double.Parse("1.234", CultureInfo.InvariantCulture);
        string invariantString = 1.234.ToString(CultureInfo.InvariantCulture);

        Console.WriteLine("\n--- Invariant Culture ---");
        Console.WriteLine($"Invariant parse of '1.234': {invariantParsed}");
        Console.WriteLine($"Invariant string of 1.234: {invariantString}");
    }
}*/
