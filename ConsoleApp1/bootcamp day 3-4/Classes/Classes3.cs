/*using System;

class Classes3
{
    public readonly double Width, Height;

    // Constructor
    public Classes3(double width, double height)
    {
        Width = width;
        Height = height;
    }

    // Deconstruct method using double
    public void Deconstruct(out double width, out double height)
    {
        width = Width;
        height = Height;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var rect = new Classes3(19, 24);

        // Deconstruction with double
        (double width, double height) = rect;
        Console.WriteLine(width + " " + height); 
    }
}*/

