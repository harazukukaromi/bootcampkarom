/*using System;
using System.Text;
//Nullaable value types with ?? and ?.

class Program
{
    static void Main()
    {
        // --- Example 1: null-coalescing operator with int? ---
        int? x = null;
        int y = x ?? 5;  // If x is null, y = 5
        Console.WriteLine("y = " + y); // Output: y = 5

        // --- Example 2: null-conditional operator with StringBuilder ---
        StringBuilder sb = null;

        // This safely calls sb.ToString().Length only if sb is not null
        int? lengthNullable = sb?.ToString().Length;
        Console.WriteLine("lengthNullable = " + (lengthNullable?.ToString() ?? "null")); // Output: null

        // --- Example 3: Combine null-conditional and null-coalescing ---
        // If sb is null, the whole left side is null, so ?? provides default
        int length = sb?.ToString().Length ?? 0;
        Console.WriteLine("length = " + length); // Output: 0

        // --- Bonus: Example when sb is NOT null ---
        sb = new StringBuilder("Hello");
        lengthNullable = sb?.ToString().Length;
        Console.WriteLine("lengthNullable (not null sb) = " + lengthNullable); // Output: 5

        length = sb?.ToString().Length ?? 0;
        Console.WriteLine("length (not null sb) = " + length); // Output: 5
    }
}*/
