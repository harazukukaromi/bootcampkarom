// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;
using System.Text.RegularExpressions;

class ConsoleApp1
{
    static void Main()
    {
        //Increment by 1
        Console.Write("input nilai n: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.Write(i);
            if (i < n)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();

        //increment pada string
        Console.Write("input huruf (a-z): ");
        string? inputHuruf = Console.ReadLine();
        char HurufAkhir = 'a';
        if (!string.IsNullOrEmpty(inputHuruf))
        {
            HurufAkhir = inputHuruf[0];
        }
        else
        {
            Console.WriteLine("Input huruf tidak valid, menggunakan 'a'.");
        }
        for (char c = 'a'; c <= HurufAkhir; c++)
        {
            Console.Write(c + " ");
        }
        //Decrement by 2
        Console.WriteLine();
        Console.Write("input nilai m: ");
        int m = int.Parse(Console.ReadLine());
        for (int i = m; i >= 1; i -= 2)
        {
            Console.Write(i);
            if (i - 2 >= 1)
            {
                Console.Write(", ");
            }
        }
        //segitiga bintang
        Console.WriteLine();
        Console.Write("Input nilai p: ");
        int p = int.Parse(Console.ReadLine());
        for (int i = 1; i <= p; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
        for (int i = p - 1; i >= 1; i--)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}

