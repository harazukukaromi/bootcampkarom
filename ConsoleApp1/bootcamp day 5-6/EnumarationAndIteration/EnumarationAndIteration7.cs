/*using System;
using System.Collections.Generic;
//Composing Sequences
class Program
{
    // Generates the first fibCount Fibonacci numbers
    static IEnumerable<int> Fibs(int fibCount)
    {
        int a = 0, b = 1;
        for (int i = 0; i < fibCount; i++)
        {
            yield return b;
            int temp = a + b;
            a = b;
            b = temp;
        }
    }

    // Filters the input sequence, returning only even numbers
    static IEnumerable<int> EvenNumbersOnly(IEnumerable<int> sequence)
    {
        foreach (int x in sequence)
        {
            //if ((x % 2) == 0)
            if ((x % 2) == 1)
            {
                yield return x;
            }
        }
    }

    static void Main()
    {
        foreach (int fib in EvenNumbersOnly(Fibs(20)))
        {
            Console.Write(fib + "  ");
        }
        //output 1 1 3 5 21 55
    }
}*/
