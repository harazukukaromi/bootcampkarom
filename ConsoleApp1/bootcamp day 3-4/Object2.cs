using System;

class Object2
{
    static void Main()
    {
        double value = 123.45; //value Double
        Console.WriteLine($"Original value (int): {value}");

        // Boxing: value type 'double' is boxed into an object
        object boxedValue = value;  
        Console.WriteLine($"Boxed value (object): {boxedValue}");

        // Unboxing: cast the object back to double
        double unboxedValue = (double)boxedValue;
        Console.WriteLine($"Unboxed value (double): {unboxedValue}");

        // Modify unboxed value
        unboxedValue = 230.45;
        Console.WriteLine($"Modified unboxed value: {unboxedValue}");
        Console.WriteLine($"Original boxed value still: {boxedValue}");
    }
}
