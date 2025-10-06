/*using System;

//try, catch, and finaly exeception part 1
namespace ExceptionHandlingDemo
{
    // Custom exception classes
    class ExceptionX : Exception
    {
        public ExceptionX (string message) : base(message) { }
    }

    class ExceptionY : Exception
    {
        public ExceptionY (string message) : base(message) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter 'x' or 'y' to throw an exception:");
                string input = Console.ReadLine();

                if (input == "x" || input == "X")
                {
                    throw new ExceptionX("ExceptionX was thrown.");
                }
                else if (input == "y" || input == "Y")
                {
                    throw new ExceptionY("ExceptionY was thrown.");
                }
                else
                {
                    Console.WriteLine("No exception thrown.");
                }
            }
            catch (ExceptionX ex)
            {
                Console.WriteLine($"Caught ExceptionX: {ex.Message}");
            }
            catch (ExceptionY ex)
            {
                Console.WriteLine($"Caught ExceptionY: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Finally block executed.");
            }
            */ /*
            //this program will ocucrs Unhandled Exception this call will stack make program crashes
            Console.WriteLine("Enter 'x' or 'y' to throw an exception:");
            string input = Console.ReadLine();

            if (input == "x" || input == "X")
            {
                throw new ExceptionX("ExceptionX was thrown.");
            }
            else if (input == "y" || input == "Y")
            {
                throw new ExceptionY("ExceptionY was thrown.");
            }
            else
            {
                Console.WriteLine("No exception thrown.");
            }
            Console.WriteLine("This line will not run if an exception occurs.");*/ /*
        }
    }
}*/
