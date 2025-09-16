/*using System;
//Implicit and Explicit Nullable and Value Types
class Program
{
    static void Main()
    {
        Console.WriteLine("=== IMPLICIT CONVERSION (Safe) ===");
        int number = 20;
        int? nullableNumber = number; // Implicit: Always safe
        Console.WriteLine($"Implicitly converted int to int?: {nullableNumber}");

        Console.WriteLine("\n=== EXPLICIT CONVERSION (Dangerous) ===");
        int? maybeNumber = null;

        try
        {
            // 🚨 Dangerous: Will throw InvalidOperationException
            int extracted = (int)maybeNumber;
            Console.WriteLine($"Extracted value: {extracted}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("💥 Exception caught during explicit cast from null:");
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\n=== SAFE ACCESS WITH .HasValue ===");
        maybeNumber = 10;
        if (maybeNumber.HasValue)
        {
            int value = maybeNumber.Value;
            Console.WriteLine($"Safely extracted using .HasValue: {value}");
        }

        Console.WriteLine("\n=== SAFE ACCESS WITH GetValueOrDefault() ===");
        maybeNumber = null;
        int defaultValue = maybeNumber.GetValueOrDefault(); // default(int) = 0
        Console.WriteLine($"Used GetValueOrDefault(): {defaultValue}");

        Console.WriteLine("\n=== SAFE ACCESS WITH NULL-COALESCING OPERATOR (??) ===");
        maybeNumber = null;
        int result = maybeNumber ?? -1; // Use -1 if null
        Console.WriteLine($"Used ?? operator: {result}");

        maybeNumber = 100;
        result = maybeNumber ?? -1;
        Console.WriteLine($"Used ?? operator (with value): {result}");
    }
}*/
