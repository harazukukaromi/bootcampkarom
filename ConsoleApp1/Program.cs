// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;
class ConsoleApp1
{
    static void Main()
    {
        // Boolean Equality
        Console.WriteLine("Input nilai x dalam integer:");
        int x = Convert.ToInt32(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.WriteLine("Input nilai y dalam integer:");
        int y = Convert.ToInt32(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.WriteLine("Input nilai z dalam integer:");
        int z = Convert.ToInt32(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.WriteLine($"{x} == {y} : {x == y}");
        Console.WriteLine($"{x} == {z} : {x == z}");
        Console.WriteLine($"{x} != {y} : {x != y}");
        Console.WriteLine($"{x} != {z} : {x != z}");
    }
}

