/*using System;

// Catch Clause Example
class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter a number between 0 and 255: ");
            string input = Console.ReadLine(); // Get user input at runtime
            byte b = byte.Parse(input);        // Try to parse input as byte
            Console.WriteLine($"Parsed byte value: {b}");
        }
        catch (FormatException)
        {
            Console.WriteLine("That's not a number!");
        }
        catch (OverflowException)
        {
            Console.WriteLine("You've given me more than a byte!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}*/