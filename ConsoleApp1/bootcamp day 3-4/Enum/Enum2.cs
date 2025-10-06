/*using System;

public enum MoveDirection
{
    //Enum using Increment and Decrement
    IncreaseX,  // X++
    DecreaseX,  // X--
    IncreaseY,  // Y++
    DecreaseY   // Y--
}

public class Point
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Point(int x = 0, int y = 0)
    {
        X = x;
        Y = y;
    }

    public void Move(MoveDirection direction)
    {
        switch (direction)
        {
            case MoveDirection.IncreaseX:
                X++;
                break;
            case MoveDirection.DecreaseX:
                X--;
                break;
            case MoveDirection.IncreaseY:
                Y++;
                break;
            case MoveDirection.DecreaseY:
                Y--;
                break;
        }
    }

    public override string ToString() => $"({X}, {Y})";
}

class Enum2
{
    static void Main()
    {
        var point = new Point(0, 0);
        Console.WriteLine("Start at " + point);

        point.Move(MoveDirection.IncreaseX);
        Console.WriteLine("After IncreaseX: " + point);  // X++

        point.Move(MoveDirection.IncreaseX);
        Console.WriteLine("After IncreaseX: " + point);  // X++

        point.Move(MoveDirection.IncreaseY);
        Console.WriteLine("After IncreaseY: " + point);  // Y++

        point.Move(MoveDirection.IncreaseY);
        Console.WriteLine("After IncreaseY: " + point);  // Y++

        point.Move(MoveDirection.DecreaseX);
        Console.WriteLine("After DecreaseX: " + point);  // X--

        point.Move(MoveDirection.DecreaseY);
        Console.WriteLine("After DecreaseY: " + point);  // Y--

        point.Move(MoveDirection.DecreaseY);
        Console.WriteLine("After DecreaseY: " + point);  // Y--

        point.Move(MoveDirection.DecreaseX);
        Console.WriteLine("After DecreaseX: " + point);  // X--
    }
}*/
