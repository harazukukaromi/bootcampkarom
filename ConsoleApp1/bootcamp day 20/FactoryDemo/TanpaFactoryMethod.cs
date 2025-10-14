using System;
//Penggunaan Without Factory Method
namespace FactoryDemo.TanpaFactory
{
    public static class TanpaFactoryMethod
    {
        public static void Run()
        {
            //Bisa dilihat pada method Run ini, kita harus membuat instance dari setiap operasi secara manual
            //Jika ada operasi baru, kita harus menambahkannya di sini
            //dan ini melanggar prinsip Open/Closed Principle
            //dan jika ada banyak operasi, kode ini akan menjadi sangat panjang dan sulit di-maintain
            //jika ingin melakukan perubahan pada cara pembuatan operasi, kita harus mengubah kode di banyak tempat
            //dan penggunaan ini harus dilakukan secara sekaligus di awal sehingga membuat kode sangat tidak fleksibel
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

    // Pengunaan Interface Dengan Menggunakan IOperation
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
