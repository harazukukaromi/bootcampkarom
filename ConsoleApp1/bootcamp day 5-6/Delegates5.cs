using System;

namespace GenericDelegateDemo
{
    class Program
    {
        // Generic delegate - works with any type TArg and TResult
        public delegate TResult Transformer<TArg, TResult>(TArg arg);

        static void Main()
        {
            GenericDelegatesDemo();
        }

        static void GenericDelegatesDemo()
        {
            Console.WriteLine("Generic Delegate");

            // Same delegate type, different type arguments
            Transformer<int, int> intSquarer = x => x * x;
            Transformer<string, int> stringLength = s => s.Length;
            Transformer<double, string> doubleFormatter = d => $"Value: {d:F3}";

            Console.WriteLine($"Int squarer (20): {intSquarer(20)}");
            Console.WriteLine($"String length ('Hikaromi'): {stringLength("Hikaromi")}");
            Console.WriteLine($"Double formatter (3.14159): {doubleFormatter(3.14159)}");

            // Using generic Transform method
            Console.WriteLine("\nGeneric Transform method demo:");

            int[] numbers = { 2, 4, 6, 8 };
            Console.WriteLine($"Original numbers: [{string.Join(", ", numbers)}]");

            TransformGeneric(numbers, x => x * x);  // Square each number
            Console.WriteLine($"Squared numbers: [{string.Join(", ", numbers)}]");

            string[] words = { "Kucing" , "Anjing" , "Kelinci" , "Serigala" };
            Console.WriteLine($"Original words: [{string.Join(", ", words)}]");

            TransformGeneric(words, s => s.ToUpper());  // Uppercase each word
            Console.WriteLine($"Uppercase words: [{string.Join(", ", words)}]");

            double[] angka = { 4.1, 8.2, 12.3, 16.4 };
            Console.WriteLine($"square Double numbers: [{string.Join(", ", angka)}]");
           
            TransformGeneric(angka, x => x * x);  // Square each number
            Console.WriteLine($"Squared numbers: [{string.Join(", ", angka)}]");

            bool[] booleans = { true, false, true, false };
            Console.WriteLine($"Original booleans: [{string.Join(", ", booleans)}]");

            // Transform: Negasi (flip true/false)
            TransformGeneric(booleans, b => !b);  // NOT operation
            Console.WriteLine($"Flipped booleans: [{string.Join(", ", booleans)}]");

            Console.WriteLine();
        }

        // Truly generic transform method
        public static void TransformGeneric<T>(T[] values, Transformer<T, T> transformer)
        {
            for (int i = 0; i < values.Length; i++)
                values[i] = transformer(values[i]);
        }
    }
}
