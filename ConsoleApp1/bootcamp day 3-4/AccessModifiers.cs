using System;

public class BaseClass
{
    public string publicField = "Public Field"; // Bisa diakses dari mana saja
    private string privateField = "Private Field"; // Hanya di dalam BaseClass
    protected string protectedField = "Protected Field"; // Di BaseClass dan derived class
    internal string internalField = "Internal Field"; // Di assembly yang sama
    protected internal string protectedInternalField = "Protected Internal Field"; // Di assembly sama atau derived class luar assembly
    private protected string privateProtectedField = "Private Protected Field"; // Di BaseClass dan derived class di assembly sama

    public void ShowAccess()
    {
        Console.WriteLine(publicField);
        Console.WriteLine(privateField);
        Console.WriteLine(protectedField);
        Console.WriteLine(internalField);
        Console.WriteLine(protectedInternalField);
        Console.WriteLine(privateProtectedField);
    }
}

public class DerivedClass : BaseClass
{
    public void TestAccess()
    {
        Console.WriteLine(publicField); // Accessible
        // Console.WriteLine(privateField); // Not accessible
        Console.WriteLine(protectedField); // Accessible (karena turunan)
        Console.WriteLine(internalField); // Accessible (sama assembly)
        Console.WriteLine(protectedInternalField); // Accessible
        Console.WriteLine(privateProtectedField); // Accessible (karena turunan dalam assembly)

        // Method calls
        PublicMethod();
        // PrivateMethod();   // Not accessible
        ProtectedMethod();
        InternalMethod();
        ProtectedInternalMethod();
        PrivateProtectedMethod();
    }

    public void AccessPrivateFieldInBase()
    {
        // Tidak bisa akses privateField langsung karena private
        // tapi bisa lewat method publik BaseClass
        ShowAccess();
    }

    // Mengakses method dari BaseClass
    public void PublicMethod() => Console.WriteLine("Public method");
    private void PrivateMethod() => Console.WriteLine("Private method");
    protected void ProtectedMethod() => Console.WriteLine("Protected method");
    internal void InternalMethod() => Console.WriteLine("Internal method");
    protected internal void ProtectedInternalMethod() => Console.WriteLine("Protected Internal method");
    private protected void PrivateProtectedMethod() => Console.WriteLine("Private Protected method");
}


public class OtherClassInSameAssembly
{
    public void TestAccess()
    {
        BaseClass obj = new BaseClass();

        Console.WriteLine(obj.publicField); // Accessible
        // Console.WriteLine(obj.privateField); // Not accessible
        // Console.WriteLine(obj.protectedField); // Not accessible
        Console.WriteLine(obj.internalField); // Accessible (assembly sama)
        Console.WriteLine(obj.protectedInternalField); // Accessible (assembly sama)
        // Console.WriteLine(obj.privateProtectedField); // Not accessible
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Base Class");
        BaseClass baseObj = new BaseClass();
        baseObj.ShowAccess();

        Console.WriteLine("DerivedClass TestAccess()");
        DerivedClass derivedObj = new DerivedClass();
        derivedObj.TestAccess();

        Console.WriteLine("OtherClassInSameAssembly TestAccess()");
        OtherClassInSameAssembly otherObj = new OtherClassInSameAssembly();
        otherObj.TestAccess();
    }
}

