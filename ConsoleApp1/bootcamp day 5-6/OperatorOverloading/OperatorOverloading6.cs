/*using System;
//Overloading true and false Operators
public struct MaybeBool
{
    private byte _value; // 0 = Unknown, 1 = False, 2 = True

    private MaybeBool(byte value) => _value = value;

    public static readonly MaybeBool Unknown = new MaybeBool(0);
    public static readonly MaybeBool False   = new MaybeBool(1);
    public static readonly MaybeBool True    = new MaybeBool(2);

    // Operator 'true': used when evaluating "if (maybeBool)"
    public static bool operator true(MaybeBool x)
        => x._value == True._value;

    // Operator 'false': used when evaluating "else if (!maybeBool)"
    public static bool operator false(MaybeBool x)
        => x._value == False._value;

    // Logical NOT
    public static MaybeBool operator !(MaybeBool x)
    {
        if (x._value == True._value) return False;
        if (x._value == False._value) return True;
        return Unknown;
    }

    public override string ToString()
        => _value switch
        {
            0 => "Unknown",
            1 => "False",
            2 => "True",
            _ => "Invalid"
        };
}

class Program
{
    static void Main()
    {
        MaybeBool a = MaybeBool.Unknown;
        MaybeBool b = MaybeBool.True;
        MaybeBool c = MaybeBool.False;

        Console.WriteLine("a is " + a);
        if (a)
            Console.WriteLine("a evaluated to True");
        else if (!a)
            Console.WriteLine("a evaluated to False");
        else
            Console.WriteLine("a evaluated to Unknown");

        Console.WriteLine();

        Console.WriteLine("b is " + b);
        if (b)
            Console.WriteLine("b evaluated to True");
        else if (!b)
            Console.WriteLine("b evaluated to False");
        else
            Console.WriteLine("b evaluated to Unknown");

        Console.WriteLine();

        Console.WriteLine("c is " + c);
        if (c)
            Console.WriteLine("c evaluated to True");
        else if (!c)
            Console.WriteLine("c evaluated to False");
        else
            Console.WriteLine("c evaluated to Unknown");
    }
}*/
