/*using System;

public class Point
{
    public int X, Y;
}

class Object3
{
    static void Main()
    {
        // Object of reference type Gettype and TypeOf
        Point p = new Point { X = 25, Y = 30};

        Console.WriteLine("Reference Type: Point");
        Console.WriteLine($"p.GetType().Name: {p.GetType().Name}");               // Runtime type
        Console.WriteLine($"typeof(Point).Name: {typeof(Point).Name}");           // Compile-time type
        Console.WriteLine($"p.GetType() == typeof(Point): {p.GetType() == typeof(Point)}");

        Console.WriteLine($"p.X.GetType().Name: {p.X.GetType().Name}");           // Value type: Int32
        Console.WriteLine($"p.Y.GetType().FullName: {p.Y.GetType().FullName}");

        Console.WriteLine();

        // Value type
        double d = 3.14;
        Console.WriteLine("Value Type: double");
        Console.WriteLine($"d.GetType(): {d.GetType()}");                         // System.Double
        Console.WriteLine($"typeof(double): {typeof(double)}");
        Console.WriteLine($"d.GetType() == typeof(double): {d.GetType() == typeof(double)}");

        Console.WriteLine();

        // Object with different runtime type
        object obj = "Hello world";
        Console.WriteLine("Object with runtime type: string");
        Console.WriteLine($"obj.GetType(): {obj.GetType()}");                     // System.String
        Console.WriteLine($"typeof(string): {typeof(string)}");
        Console.WriteLine($"obj.GetType() == typeof(string): {obj.GetType() == typeof(string)}");

        Console.WriteLine();

        // Example of boxing
        int number = 42;
        object boxed = number;  // Boxing occurs
        Console.WriteLine("Boxing Example");
        Console.WriteLine($"boxed.GetType(): {boxed.GetType()}");                // System.Int32
        Console.WriteLine($"typeof(int): {typeof(int)}");
        Console.WriteLine($"boxed.GetType() == typeof(int): {boxed.GetType() == typeof(int)}");
    }
}*/
