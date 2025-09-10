// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;
class ConsoleApp1
{
    static void Main()
    {
        //Perhitungan dua bilangan integer
        Console.Write("Masukan Nilai integer: ");
        int x = int.Parse(Console.ReadLine());

        Console.Write("Masukan Nilai Integer: ");
        int y = int.Parse(Console.ReadLine());

        int z = x * y;
        Console.WriteLine("hasil perkalian: " + z);

        //Perhitungan dua bilangan decimal
        Console.Write("masukan Nilai decimal pertama: ");
        double a = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("masukan Nilai decimal kedua: ");
        double b = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        double c = a + b;
        Console.WriteLine("Hasil pemjumlahan: " + c);

        //pengurangan dua bilangan decimal
        Console.Write("masukan Nilai decimal pertama: ");
        double i = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("masukan Nilai decimal kedua: ");
        double j = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        double k = i - j;
        Console.WriteLine("Hasil pengurangan: " + k);

        //pembagian dua bilangan decimal
        Console.Write("masukan Nilai decimal pertama: ");
        double m = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("masukan Nilai decimal kedua: ");
        double n = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        double o = m / n;
        Console.WriteLine("Hasil pembagian: " + o);

        //modulus dua bilangan integer
        Console.Write("Masukan Nilai integer: ");
        int s = int.Parse(Console.ReadLine());

        Console.Write("Masukan Nilai Integer: ");
        int t = int.Parse(Console.ReadLine());

        int u = s % t;
        Console.WriteLine("hasil modulus: " + u);
    }
}

