using System;

namespace ConsoleApp1
{
    // Define the delegate type
    delegate int Transformer(int x);

    class Program
    {
        static int Square(int x) => x * x;
        static int Cube(int x) => x * x * x;

        static void Transform(int[] values, Transformer t)
        {
            for (int i = 0; i < values.Length; i++)
                values[i] = t(values[i]);
        }

        static void Main(string[] args)
        {
            int[] values = { 1, 2, 3 };

            //Transform(values, Square); // Use Square method as the plug-in
            //foreach (int i in values)
            //Console.Write(i + "  "); // Output: 1 4 9 


            Transform(values, Cube);
            foreach (int i in values)
            Console.Write(i + "  "); // Output: 1 8 27
            // running two in same time make last output input to new values

            Transform(values, Square); // Use Square method as the plug-in
            foreach (int i in values)
            Console.Write(i + "  "); // if start cube it will be 1 64 729
        }
    }
}


