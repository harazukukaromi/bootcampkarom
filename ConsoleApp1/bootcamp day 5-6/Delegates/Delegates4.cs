/*using System;

//multicast Delegate
namespace MulticastDelegateDemo
{
    class Program
    {
        // For multicast demos, we need void return type
        // With non-void return types, only the last method's return value is kept
        delegate void ProgressReporter(int percentComplete);
        delegate int Transformer(int x);
        //delegate void Transformer(int x); // jika ingin mengembalikan nilai square and cube

        static void Main()
        {
            MulticastDelegatesDemo();
        }

        static void MulticastDelegatesDemo()
        {

            // Start with a single method
            ProgressReporter reporter = WriteProgressToConsole;

            // Add more methods using += operator
            // Remember: delegates are immutable, so += creates a new delegate
            reporter += WriteProgressToFile;
            reporter += SendProgressAlert;

            Console.WriteLine("Progress reporting with multicast delegate (3 methods):");
            reporter(50);  // This calls ALL three methods in the order they were added

            Console.WriteLine("\nRemoving console reporter using -= operator:");
            reporter -= WriteProgressToConsole;

            Console.WriteLine("Progress reporting after removal (2 methods):");
            if (reporter != null)
                reporter(90);

            // Demonstrate that return values are lost in multicast (except the last one)
            Console.WriteLine("\nMulticast with return values (only last one is kept):");

            Transformer multiTransformer = Square;
            multiTransformer += Cube;  // Now has two methods

            int lastResult = multiTransformer(8);  // Calls Square(8) then Cube(8)
            Console.WriteLine($"Only the last result is returned: {lastResult}");  // Will be 512 (cube), not 9 (square)

            Console.WriteLine();
        */
            /* Console.WriteLine("\nMulticast Transformer with void return type:");

            Transformer multiTransformer = Square;
            multiTransformer += Cube;

            Console.WriteLine("Calling multicast Transformer (void):");
            multiTransformer(8); // Akan memanggil Square(8), lalu Cube(8) */ 
        /*
            
        }

        static void WriteProgressToConsole(int percentComplete)
        {
            Console.WriteLine($"  Console Log: {percentComplete}% complete");
        }

        static void WriteProgressToFile(int percentComplete)
        {
            Console.WriteLine($"  File Log: Writing {percentComplete}% to progress.log");
        }

        static void SendProgressAlert(int percentComplete)
        {
            if (percentComplete >= 75)
                Console.WriteLine($"  Alert: High progress reached - {percentComplete}%!");
        }

        static int Square(int x) => x * x;
        static int Cube(int x) => x * x * x;
        
        */ /*static void Square(int x)
        {
            int result = x * x;
            Console.WriteLine($"  Square({x}) = {result}");
        }

        static void Cube(int x)
        {
            int result = x * x * x;
            Console.WriteLine($"  Cube({x}) = {result}");
        }*/ /*
    }
}*/
