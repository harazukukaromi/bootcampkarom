/*using System;

class Interface
{
    //expicit Interface 
    interface I1 { void Foo(); }
    interface I2 { int Foo(); }

    public class Widget : I1, I2 // Implements both interfaces
    {
        // Implicit implementation for I1.Foo()
        public void Foo()
        {
            Console.WriteLine("Widget's implementation of I1.Foo");
        }

        // Explicit implementation for I2.Foo()
        // Note the interface name preceding the member name, and no access modifier.
        int I2.Foo()
        {
            Console.WriteLine("Widget's implementation of I2.Foo");
            return 36;
        }
    }
    public static void Main()
    {
        Widget widget = new Widget();

        // Memanggil Foo() dari I1 (implicit)
        widget.Foo();

        // Memanggil Foo() dari I2 (explicit) harus melalui interface
        I2 i2Widget = widget;
        int result = i2Widget.Foo();
        Console.WriteLine($"Result from I2.Foo(): {result}");
    }
}*/

