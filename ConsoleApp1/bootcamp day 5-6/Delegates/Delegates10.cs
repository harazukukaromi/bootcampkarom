/*using System;
//Parameter Compatibility (Contravariance)
class Program
{
    // Method that takes an object and prints it
    static void ActOnObject(object o) => Console.WriteLine(o);

    // Delegate that takes a string
    delegate void StringAction(string s);

    static void Main()
    {
        // Assigning a method that takes object to a delegate that expects string is legal
        StringAction sa = new StringAction(ActOnObject);

        // Invoke the delegate with a string
        sa("Hikaromi");  // Output: Hikaromi
    }
}*/
