// See https://aka.ms/new-console-template for more information
using System;

class LogicExercise
{
    static void Main()
    {
        Console.Write("Masukkan nilai n: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine(i);
        }
    }
}