/*using System;
using System.Collections.Generic;
//Iteration
class Program
{
    static void Main()
    {
        // Demonstrate Fibonacci generator
        Console.WriteLine("Fibonacci Sequence (first 10 numbers):");
        foreach (int fib in Fibs(10))
        {
            Console.Write(fib + "  ");
        }

        Console.WriteLine("\n");

        // Demonstrate iteration of Circles from 1 to 8
        Console.WriteLine("Circles of numbers from 1 to 8:");
        foreach (int circle in Circles(1, 8))
        {
            Console.Write(circle + "  ");
        }
        Console.WriteLine();
    }

    // Generator: Fibonacci sequence
    // Iterator method that generates Fibonacci sequence
    // Notice: this method doesn't execute immediately when called
    // It returns an IEnumerable that produces values on-demand

    static IEnumerable<int> Fibs(int count)
    {
        for (int i = 0, prev = 1, curr = 1; i < count; i++)
        {
            yield return prev; // Yields current value and pauses execution
            int newFib = prev + curr;
            prev = curr;
            curr = newFib;
        }
    }

    // Generator: Squares of numbers from start to end
    static IEnumerable<int> Circles(int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            yield return (int)(Math.PI * i * i);
        }
    }
}*/
