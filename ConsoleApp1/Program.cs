// See https://aka.ms/new-console-template for more information
using System;
using System.Text.RegularExpressions;

class ConsoleApp1
{
    static void Main()
    {
        //break statement
        int n = 10;
        for (int i = 1; i <= n; i++)
        {
            if (i == 5)
            {
                break; // Keluar dari loop ketika i sama dengan 5
            }
            Console.Write(i + " ");
        }
        //continue statement
        Console.WriteLine();
        for (int i = 1; i <= n; i++)
        {
            if (i == 5)
            {
                continue; // Lewati iterasi ketika i sama dengan 5
            }
            Console.Write(i + " ");
        }
        //goto statement
        int i = 1;
        startLoop: // This is a label
        if (i <= 5)
        {
            Console.Write(i + " ");
            i++;
            goto startLoop; // Jumps back to the 'startLoop' label
        }
    }
}
