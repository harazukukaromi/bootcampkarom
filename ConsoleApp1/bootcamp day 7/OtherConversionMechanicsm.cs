/*using System;

class Program
{
    static void Main()
    {
        // Rounding behavior with Convert.ToInt32(double)
        double d1 = 3.9;
        int i1 = Convert.ToInt32(d1);    // i1 == 4 (rounds up)
        Console.WriteLine($"i1 = {i1}");

        double d2 = 3.2;
        int i2 = Convert.ToInt32(d2);    // i2 == 3 (rounds down)
        Console.WriteLine($"i2 = {i2}");

        double d3 = 3.5;
        int i3 = Convert.ToInt32(d3);    // i3 == 4 (banker's rounding)
        Console.WriteLine($"i3 = {i3}");

        double d4 = 4.5;
        int i4 = Convert.ToInt32(d4);    // i4 == 4 (banker's rounding)
        Console.WriteLine($"i4 = {i4}");

        // Parsing string to int with base 16 (hex)
        int thirty = Convert.ToInt32("1E", 16);    // 1E hex == 30 decimal
        Console.WriteLine($"thirty = {thirty}");

        // Parsing string to uint with base 2 (binary)
        uint seven = Convert.ToUInt32("111", 2);    // 111 binary == 7 decimal
        Console.WriteLine($"seven = {seven}");

        // Using Convert.ChangeType to convert object to int
        Type targetType = typeof(int);
        object source = "42";
        object result = Convert.ChangeType(source, targetType);

        Console.WriteLine(result);             // 42
        Console.WriteLine(result.GetType());  // System.Int32
    }
}*/
