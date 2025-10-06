/*using System;
//string: Immutable Sequences of Characters
class Program
{
    static void Main()
    {
        // =============================
        // 1. String Literals
        // =============================

        string s1 = "Hello"; // Regular string
        Console.WriteLine("s1: " + s1);

        string s2 = "First Line\r\nSecond Line"; // Escape sequences
        Console.WriteLine("s2:\n" + s2);

        string s3 = @"C:\Path\File.txt"; // Verbatim string literal
        Console.WriteLine("s3: " + s3);

        // =============================
        // 2. String Constructor (repeating character)
        // =============================

        Console.WriteLine("Asterisks: " + new string('*', 20)); // Print 20 asterisks

        // =============================
        // 3. Char Array Manipulation
        // =============================

        char[] chara = s1.ToCharArray();
        Console.WriteLine("Char Array: " + string.Join(", ", chara));

        string sFull = new string(chara); // Full string from char array
        Console.WriteLine("sFull: " + sFull);

        string sPartial = new string(chara, 1, 2); // Partial string (index 1, length 2)
        Console.WriteLine("sPartial (index 1, length 2): " + sPartial); // "el"

        // =============================
        // 4. Empty vs Null Strings
        // =============================

        string empty = "";
        Console.WriteLine("Empty string length == 0: " + (empty.Length == 0));      // True
        Console.WriteLine("Empty == string.Empty: " + (empty == string.Empty));     // True

        string nullString = null;
        Console.WriteLine("Null string == null: " + (nullString == null));          // True
        Console.WriteLine("Null string == \"\": " + (nullString == ""));            // False

        // Use null-conditional operator to avoid exception
        Console.WriteLine("Null string length: " + (nullString?.Length ?? 0));      // Safe, prints 0

        // =============================
        // 5. Accessing Characters
        // =============================

        string str = "abcde";
        char letter = str[1]; // Index access
        Console.WriteLine("Character at index 1 of \"abcde\": " + letter); // 'b'

        Console.Write("Characters using foreach: ");
        foreach (char c in "123") Console.Write(c + ","); // 1,2,3,
        Console.WriteLine(); // for newline
    }
}*/

