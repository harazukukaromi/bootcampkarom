// See https://aka.ms/new-console-template for more information
using System;
using System.Text.RegularExpressions;

class ConsoleApp1
{
    static void Main()
    {
        //iteration statement
        Console.Write("Masukkan nilai n: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            Console.Write(i); // Tambahkan titik koma di akhir baris ini
            if (i < n)
            {
                Console.Write(", ");
            }
        }
        //while-do statement
        Console.WriteLine("\n\nMasukkan nilai m: ");
        int m = int.Parse(Console.ReadLine());
        int j = 1;
        while (j <= m)
        {
            Console.Write(j);
            if (j < m)
            {
                Console.Write(", ");
            }
            j++;
        }
        //do-while statement
        Console.WriteLine("\n\nMasukkan nilai p: ");
        //int p = int.Parse(Console.ReadLine());
        int k = 1;
        do
        {
            Console.Write(k);
            if (k < p)
            {
                Console.Write(", ");
            }
            k++;
        } 
        while (k <= p);
        //loops
        //memberikan baris baru
        Console.WriteLine("\n\n Loop dari 0 sampai 10:");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(i);
        }
        //foreach loops
        string[] nama = { "Alfi", "Karom", "Syah" };
        Console.WriteLine("\nMenampilkan elemen array nama:");
        foreach (string n in nama)
        {
            Console.WriteLine(n);
        } 
    }
}
