/*using System;
//Enums Work Underhood
[Flags]
public enum BorderSides
{
    Left = 1,
    Right = 2,
    Top = 4,
    Bottom = 8
}

class Program
{
    static void Main()
    {
        BorderSides b = BorderSides.Left;

        Console.WriteLine($"Original value: {b} ({(int)b})");

        // Cast to int, add, then cast back to BorderSides
        b = (BorderSides)((int)b + 1234);

        Console.WriteLine($"After adding 1234: {b} ({(int)b})");

        // Check if the resulting value is defined or valid by comparing bits
        bool isValid = Enum.IsDefined(typeof(BorderSides), b);
        Console.WriteLine($"Is value defined? {isValid}");

        // Alternatively, mask out known flags and see what's left
        int knownFlags = (int)(BorderSides.Left | BorderSides.Right | BorderSides.Top | BorderSides.Bottom);
        int unknownBits = ((int)b) & ~knownFlags;
        Console.WriteLine($"Unknown bits set: 0x{unknownBits:X}");
    }
}*/
