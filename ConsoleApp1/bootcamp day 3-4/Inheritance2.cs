using System;

public class Inheritance2
{
    //virtual Property dan Liability
    public string Name;
    public virtual decimal Liability => 0; // Virtual property
}

public class Stock : Inheritance2
{
    public long SharesOwned;
    // Uses default Liability = 0
}

public class House : Inheritance2
{
    public decimal Mortgage;

    // Override virtual property
    public override decimal Liability => Mortgage;
}

public class Program
{
    public static void Main()
    {
        House mansion = new House { Name = "McMansion", Mortgage = 123000 };
        Inheritance2 a = mansion; // Upcasting to base class

        Console.WriteLine(mansion.Liability); // Output: 123000 (House's overridden implementation)
        Console.WriteLine(a.Liability);       // Output: 123000 (Polymorphism in action)

        Stock stock = new Stock { Name = "Tech Corp", SharesOwned = 100 };
        Console.WriteLine(stock.Liability);   // Output: 0 (Uses Asset's default)
    }
}
