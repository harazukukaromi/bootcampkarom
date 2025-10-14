using System;

namespace FactoryDemo.TanpaFactory
{
    public static class TanpaFactoryMethod
    {
        public static void Run()
        {
            Console.WriteLine("\n=== Calculator Tanpa Factory Method ===");

            IOperation add = new AddOperation();
            IOperation sub = new SubtractOperation();
            IOperation mul = new MultiplyOperation();
            IOperation div = new DivideOperation();

            Console.WriteLine($"10 + 5 = {add.Calculate(10, 5)}");
            Console.WriteLine($"10 - 5 = {sub.Calculate(10, 5)}");
            Console.WriteLine($"10 * 5 = {mul.Calculate(10, 5)}");
            Console.WriteLine($"10 / 5 = {div.Calculate(10, 5)}");
        }
    }

    public interface IOperation
    {
        double Calculate(double a, double b);
    }

    public class AddOperation : IOperation
    {
        public double Calculate(double a, double b) => a + b;
    }

    public class SubtractOperation : IOperation
    {
        public double Calculate(double a, double b) => a - b;
    }

    public class MultiplyOperation : IOperation
    {
        public double Calculate(double a, double b) => a * b;
    }

    public class DivideOperation : IOperation
    {
        public double Calculate(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException("Tidak bisa membagi dengan nol!");
            return a / b;
        }
    }
}
