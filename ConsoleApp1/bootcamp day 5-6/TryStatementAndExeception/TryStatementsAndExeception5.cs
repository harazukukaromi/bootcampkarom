/*using System;
//finally block
class Program
{
    static void Main()
    {
        Console.WriteLine("Starting program...");

        try
        {
            Console.WriteLine("Inside try block.");
            //int result = 10 / 0; // This will throw DivideByZeroException
            Console.WriteLine("This line will not execute.");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Caught a divide by zero exception.");
        }
        finally
        {
            Console.WriteLine("Finally block executed — cleaning up.");
        }

        Console.WriteLine("Program finished.");
    }
    void Test()
    {
        try
        {
            Console.WriteLine("In try block.");
            return;
        }
        finally
        {
            Console.WriteLine("Finally block still runs.");
        }
    }
}*/
