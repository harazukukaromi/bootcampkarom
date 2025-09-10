// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;
class ConsoleApp1
{
    static void Main()
    {
        Console.Write("Masukan Nilai integer atau Decimal: ");
        double input = Convert.ToDouble(Console.ReadLine());
        
        if (input % 1 == 0)
        {
            Console.WriteLine("Merupakan nilai integer: " + Convert.ToInt32(input));
        }
        else
        {
            Console.WriteLine("Merupakan nilai decimal: " + input.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}

