using System;

class AccessModifiers
{
    public string publicField = "Hola, Saya Public"; // Bisa Diakses dari mana saja
    private string privateField = "Hola, Saya Private"; // Hanya bisa diakses dalam kelas yang sama
    protected string protectedField = "Hola, Saya Protected"; // Bisa diakses dalam kelas yang sama atau kelas turunan
    internal string internalField = "Hola, Saya Internal"; // Bisa diakses dalam assembly yang sama
    protected internal string protectedInternalField = "Hola, Saya Protected Internal"; // Bisa diakses dalam assembly yang sama atau dari kelas turunan di assembly lain
    private protected string privateProtectedField = "Hola, saya Private Protected"; // Bisa diakses dalam kelas yang sama atau kelas turunan dalam assembly yang sama

    //call public method
    public void PublicMethod()
    {
        Console.WriteLine("Ini Method Public Hehe.");
    }
    //call private method
    private void PrivateMethod()
    {
        Console.WriteLine("Ini Method Private Hehe.");
    }
    //call protected method
    protected void ProtectedMethod()
    {
        Console.WriteLine("Ini Method Protected Hehe.");
    }
    //call internal method
    internal void InternalMethod()
    {
        Console.WriteLine("Ini Method Internal Hehe.");
    }
    //call protected internal method
    protected internal void ProtectedInternalMethod()
    {
        Console.WriteLine("Ini Method Protected Internal Hehe.");
    }
    //call private protected method
    private protected void PrivateProtectedMethod()
    {
        Console.WriteLine("Ini Method Private Protected Hehe.");
    }
    //different accessibilty public, private, protected, internal, protected internal, private protected,
    //example usage
    static void Main()
    {
        AccessModifiers accessModifiers = new AccessModifiers();
        Console.WriteLine(accessModifiers.publicField); // Accessible
        Console.WriteLine(accessModifiers.privateField); // Not Accessible
        Console.WriteLine(accessModifiers.protectedField); // Not Accessible
        Console.WriteLine(accessModifiers.internalField); // Accessible
        Console.WriteLine(accessModifiers.protectedInternalField); // Accessible
        //Console.WriteLine(accessModifiers.privateProtectedField); // Not Accessible

        accessModifiers.PublicMethod(); // Accessible
        //accessModifiers.PrivateMethod(); // Not Accessible
        //accessModifiers.ProtectedMethod(); // Not Accessible
        accessModifiers.InternalMethod(); // Accessible
        accessModifiers.ProtectedInternalMethod(); // Accessible
        //accessModifiers.PrivateProtectedMethod(); // Not Accessible
    }
}