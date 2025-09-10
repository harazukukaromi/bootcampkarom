// See https://aka.ms/new-console-template for more information
using System;
using System.Text.RegularExpressions;

class ConsoleApp1
{
    static void Main()
    {
        // tenary operator
        int a = 40;
        int b = 60;
        int max = (a > b) ? a : b;
        Console.WriteLine("Nilai maksimum adalah: " + max);

        //primary expression
        int n = 5;
        for (int i = 1; i <= n; i++)
        {
            Console.Write(i); // Tambahkan titik koma di akhir baris ini
            if (i < n)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();
        //void expression
        void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
        PrintMessage("Hello, World!");
        //assignment expression
        int x;
        x = 42;
        Console.WriteLine("Nilai x adalah: " + x);
        //precendence expression
        int result = 10 + 5 * 2; // Perkalian (*) memiliki
        // presedensi lebih tinggi daripada penjumlahan (+)
        Console.WriteLine("Hasilnya adalah: " + result); // Output: 20
        //associativity expression
        int value = 100 / 5 / 2; // Pembagian (/) memiliki
        // asosiativitas kiri ke kanan
        Console.WriteLine("Nilai akhirnya adalah: " + value);// Output: 10
        //right to left associativity
        int y = 10;
        y += 5; // Sama dengan y = y + 5
        Console.WriteLine("Nilai y adalah: " + y); // Output: 15
    }
}
