/*using System;

//function and action in Delegates
//Func dan Action adalah jenis delegate yang umum digunakan dalam C# untuk mengelola fungsi dan aksi.
//Func digunakan untuk delegate yang mengembalikan nilai, sedangkan Action digunakan untuk delegate yang tidak mengembalikan nilai.
namespace FuncAndActionDemo
{
    class Program
    {
        static void Main()
        {
            FuncAndActionDelegatesDemo();
        }

        static void FuncAndActionDelegatesDemo()
        {

            // FUNC: Delegate yang mengembalikan nilai
            Func<int, int> squareFunc = x => x * x * x;
            Func<double, double, double> addFunc = (a, b) => a + b;
            Func<string> getTimeFunc = () => DateTime.Now.ToString("HH:mm:ss");

            Console.WriteLine("Func delegates:");
            Console.WriteLine($"  cube of 7: {squareFunc(7)}");
            Console.WriteLine($"  Add 2 nilai double (6,2 + 7,8): {addFunc(6.2, 7.8)}");
            Console.WriteLine($"  Current time: {getTimeFunc()}");
            Console.WriteLine();

            // ACTION: Delegate yang tidak mengembalikan nilai
            Action simpleAction = () => Console.WriteLine("  Simple action executed");
            Action<string> messageAction = msg => Console.WriteLine($"  Message: {msg}");
            Action<int, string> complexAction = (num, text) =>
                Console.WriteLine($"  Number: {num}, Text: {text}");

            Console.WriteLine("Action demonstrations:");
            simpleAction();
            messageAction("Hello Ai, Karamba!"); // action untuk mengembalikan string as message
            complexAction(42, "The Final"); // mengembalikan nilai int, dan string
            Console.WriteLine();

            // FUNC + Transform Array
            Console.WriteLine("Using Func with array transformation:");
            int[] values = { 1, 2, 3, 4, 5 };
            Console.WriteLine($"  Original values: [{string.Join(", ", values)}]");

            TransformWithFunc(values, x => x * x); // menggandakannya dengan original value
            //TransformWithFunc(values, x => x * 2); // Making double value

            Console.WriteLine($" Kuadrat values: [{string.Join(", ", values)}]");
            //Console.WriteLine($" double values: [{string.Join(", ", values)}]");
            Console.WriteLine();

            // ACTION + Process Array
            Console.WriteLine("Using Action to process array elements:");
            ProcessWithAction(values, x => Console.WriteLine($"  Value is: {x}"));
            Console.WriteLine();
        }

        // Method generic menggunakan Func<T, T> untuk transformasi
        public static void TransformWithFunc<T>(T[] values, Func<T, T> transformer)
        {
            for (int i = 0; i < values.Length; i++)
                values[i] = transformer(values[i]);
        }

        // Method generic menggunakan Action<T> untuk proses void
        public static void ProcessWithAction<T>(T[] values, Action<T> action)
        {
            for (int i = 0; i < values.Length; i++)
                action(values[i]);
        }
    }
}*/
