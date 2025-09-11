using System;

class Struct
{
    static void Main()
    {
        Point point = new Point(3, 4);
        point.Display();
        Circle circle = new Circle(91);
        Console.WriteLine($"Lingkaran ini memiliki {circle.radius} Dan Luas{circle.Area()}");
        Rectangle rectangle = new Rectangle(10, 5);
        Console.WriteLine($"Persegi Panjang ini memiliki panjang {rectangle.length} Dan Lebar {rectangle.width} dan Luas {rectangle.Area()}");
    }
    //struct
    struct Point
    {
        //fields
        public int x;
        public int y;

        //constructor
        public Point(int x, int y)
        {
            this.x = x * 2 * y; // testing operation
            this.y = y;
        }

        //method
        public void Display()
        {
            Console.WriteLine($"Point({x}, {y})");
        }
    }
    //readonly struct
    readonly struct Circle
    {
        public readonly double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double Area()
        {
            return Math.PI * radius * radius;
        }
    }
    //readonly function
    readonly struct Rectangle
    {
        public readonly double length;
        public readonly double width;

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        public readonly double Area()
        {
            return length * width;
        }
    }
    //ref Struct System.Span<T>
    ref struct Point1 {public int x, y; }
}