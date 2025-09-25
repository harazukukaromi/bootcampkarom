/*
using System;
using System.Buffers;

class Program
{
    static void Main()
    {
        Console.WriteLine("Renting array from ArrayPool<int>...");

        // Rent an array of at least 100 integers
        int[] array = ArrayPool<int>.Shared.Rent(100);

        Console.WriteLine($"Array length received: {array.Length}");

        // Fill part of the array with data
        for (int i = 0; i < 10; i++)
        {
            array[i] = i * 10;
        }

        // Display the first 10 values
        Console.WriteLine("First 10 elements:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();

        // Return the array to the pool
        // TRUE: clear the array (zero out the contents) before returning it
        Console.WriteLine("Returning array to pool (with clearing)...");
        ArrayPool<int>.Shared.Return(array, clearArray: true);

        // Rent the array again (might be the same one!)
        int[] reusedArray = ArrayPool<int>.Shared.Rent(100);
        Console.WriteLine($"Reused array length: {reusedArray.Length}");

        // Display the first 10 elements after clearing
        Console.WriteLine("First 10 elements of reused array (after clearing):");
        for (int i = 0; i < 10; i++)
        {
            Console.Write(reusedArray[i] + " ");
        }
        Console.WriteLine();

        // Return without clearing this time
        Console.WriteLine("Returning array to pool (without clearing)...");
        ArrayPool<int>.Shared.Return(reusedArray, clearArray: false);

        Console.WriteLine("\nDone.");
    }
}
*/