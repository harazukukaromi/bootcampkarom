/*using System;

class Program
{
    // Method returns a integer
    static int RetrieveInteger() => 120;

    // Delegate returns an object
    delegate int IntRetriever();

    static void Main()
    {
        // Assign method returning string to delegate returning object - this is allowed (covariance)
        IntRetriever o = new IntRetriever(RetrieveInteger);

        // Invoke delegate - the string result is implicitly upcast to object
        int result = o();

        Console.WriteLine(result);  // Output: 120
        Console.WriteLine(result.GetType());  // Output: System.Int32
    }*/
    /*
    // Method returns a string
    static string RetrieveString() => "hello";

    // Delegate returns an object
    delegate object ObjectRetriever();

    static void Main()
    {
        // Assign method returning string to delegate returning object - this is allowed (covariance)
        ObjectRetriever o = new ObjectRetriever(RetrieveString);

        // Invoke delegate - the string result is implicitly upcast to object
        object result = o();

        Console.WriteLine(result);  // Output: hello
        Console.WriteLine(result.GetType());  // Output: System.String
    }*/
//}
