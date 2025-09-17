using System;

[Flags]
public enum BorderSides
{
    Left = 1,
    Right = 2,
    Top = 4,
    Bottom = 8,
    LeftRight = Left | Right,
    RightTop = Right | Top,    // New combined flag
    TopTopLeft = Top | Top | Left
}

class Program
{
    static void Main()
    {
        foreach (Enum value in Enum.GetValues(typeof(BorderSides)))
        {
            Console.WriteLine(value);
        }
    }
}

