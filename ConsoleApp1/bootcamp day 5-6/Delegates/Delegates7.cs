/*using System;

// Delegates vs Interfaces part 1
namespace InterfaceTransformerDemo
{
    // Interface declaration
    public interface ITransformer
    {
        int Transform(int x);
    }

    // Utility class that uses the interface
    public class Util
    {
        public static void TransformAll(int[] values, ITransformer transformer)
        {
            for (int i = 0; i < values.Length; i++)
                values[i] = transformer.Transform(values[i]);
        }
    }

    // Concrete implementation: Squaring
    public class Squarer : ITransformer
    {
        public int Transform(int x) => x * x;
    }

    // Concrete implementation: Cubing
    public class Cuber : ITransformer
    {
        public int Transform(int x) => x * x * x;
    }

    class Program
    {
        static void Main()
        {
            int[] numbers = { 1, 2, 3, 4};

            Console.WriteLine("Original numbers: " + string.Join(", ", numbers));

            // Apply squaring using interface
            Util.TransformAll(numbers, new Squarer());
            Console.WriteLine("After squaring: " + string.Join(", ", numbers));

            // Apply cubing (after squaring, now cube the squared results)
            Util.TransformAll(numbers, new Cuber());
            Console.WriteLine("After cubing the squared results: " + string.Join(", ", numbers));
        }
    }
}*/
