/*using System;

interface I
{
    void Foo();
}

struct S : I
{
    public int X;

    public void Foo()
    {
        X = 40;
        Console.WriteLine($"S.Foo called. X = {X}");
    }
}

class Interface3
{
    static void Main()
    {
        S s = new S();

        Console.WriteLine("Call Foo() directly on struct:");
        s.Foo(); // No boxing
        Console.WriteLine($"s.X after direct call: {s.X}\n");

        Console.WriteLine("Call Foo() via interface (boxing occurs):");
        I i = s;  // Boxing occurs here
        i.Foo();  // Called on boxed copy
        Console.WriteLine($"s.X after boxing call: {s.X} (unchanged!)\n");

        Console.WriteLine("Call Foo() via generic method (no boxing):");
        CallWithoutBoxing(s);  // No boxing via generic constraint
        Console.WriteLine($"s.X after generic call: {s.X} (unchanged again!)");
    }

    // This method avoids boxing by using generic constraint
    static void CallWithoutBoxing<T>(T value) where T : struct, I
    {
        value.Foo(); // Called directly on value type without boxing
    }
}*/
