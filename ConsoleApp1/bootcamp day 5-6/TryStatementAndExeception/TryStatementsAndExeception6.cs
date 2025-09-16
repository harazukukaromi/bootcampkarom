/*using System;
//throwing Exeception
class Program
{
    static void Main()
    {
        // 1. Expression-bodied method that throws
        try
        {
            string result = GetNotImplementedFeature();
            Console.WriteLine(result); // This line won't run
        }
        catch (NotImplementedException ex)
        {
            Console.WriteLine($"Caught from expression-bodied method: {ex.Message}");
        }

        // 2. Throw in ternary conditional - null input
        try
        {
            string result = ProperCase(null);
            Console.WriteLine(result); // This line won't run
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Caught from ternary expression: {ex.Message}");
        }

        // 3. Valid input
        try
        {
            string result = ProperCase("hello world");
            Console.WriteLine($"ProperCase result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✗ Unexpected error: {ex.Message}");
        }

        Console.WriteLine("Program completed.");
    }

    // Expression-bodied method that throws an exception
    static string GetNotImplementedFeature() =>
        throw new NotImplementedException("This feature is planned for version 2.0");

    // Uses throw expressions inside a ternary conditional
    static string ProperCase(string? value) =>
        value == null ? throw new ArgumentException("Value cannot be null") :
        value == "" ? "" :
        char.ToUpper(value[0]) + value.Substring(1).ToLower();
}*/
