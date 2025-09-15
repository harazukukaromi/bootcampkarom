/*using System;

//Delegate Compability (variance)
class Program
{
    // Define two delegate types with the same signature
    delegate void D1();
    delegate void D2();

    static void Main()
    {
        void Method1()
        {
            Console.WriteLine("Method1 invoked");
        }

        D1 d1 = Method1;

        // This line causes a compile-time error because
        // D1 and D2 are different delegate types, even though signatures match.
        // D2 d2 = d1; // Uncommenting this will cause a compilation error because cannot convert from D1 to D2

        // But this is allowed: creating a new D2 instance from d1 delegate instance
        D2 d2 = new D2(d1);

        // Invoke both delegates
        d1();
        d2();
    }
}*/
