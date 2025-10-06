/*using System;
using System.Collections.Generic;
//Composing Sequences part 2
class Program
{
    static void Main()
    {
        Console.WriteLine("Fibonacci Numbers Divisible by 4 (first 10 Fibs):");
        foreach (int fib in FilterByDivisor(Fibs(10), 4))
        {
            Console.Write(fib + "  ");
        }

        Console.WriteLine("\n");

        Console.WriteLine("Squares Divisible by 2 (from 1 to 8):");
        foreach (int sq in FilterByDivisor(Squares(1, 8), 2))
        {
            Console.Write(sq + "  ");
        }

        Console.WriteLine();
    }

    // Fibonacci generator
    static IEnumerable<int> Fibs(int count)
    {
        for (int i = 0, prev = 1, curr = 1; i < count; i++)
        {
            yield return prev;
            int newFib = prev + curr;
            prev = curr;
            curr = newFib;
        }
    }

    // Squares generator
    static IEnumerable<int> Squares(int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            yield return i * i;
        }
    }

    // Generic filter for divisibility
    static IEnumerable<int> FilterByDivisor(IEnumerable<int> sequence, int divisor)
    {
        foreach (int x in sequence)
        {
            if (x % divisor == 0)
            {
                yield return x;
            }
        }
    }
}*/

