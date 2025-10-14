using System;

namespace FactoryDemo.DenganFactory
{
    public static class FactoryMethod
    {
        public static void Run()
        {
            Console.WriteLine("\n=== Calculator Dengan Factory Method ===");
            // ini dalah calculator yang menggunakan Factory method
            // jadi kita tidak perlu membuat instance dari setiap operasi secara manual
            // kita hanya perlu memilih operasi yang diinginkan, dan factory yang sesuai akan membuatkan instance-nya untuk kita
            // kita bisa menambahkan operasi baru tanpa mengubah kode yang sudah ada

            Console.Write("Masukkan operasi (+, -, *, /): ");
            string op = Console.ReadLine();

            OperationFactory factory = op switch
            {
                "+" => new AddFactory(),
                "-" => new SubtractFactory(),
                "*" => new MultiplyFactory(),
                "/" => new DivideFactory(),
                _ => throw new InvalidOperationException("Operasi tidak dikenal!")
            };

            IOperation operation = factory.CreateOperation();

            Console.Write("Masukkan angka pertama: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Masukkan angka kedua: ");
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine($"Hasil: {operation.Calculate(a, b)}");
        }
    }

    // Interface sama seperti sebelumnya
    public interface IOperation
    {
        double Calculate(double a, double b);
    }

    // Concrete Operations
    // Implementasi dari Operasi pada matematika
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

    // perbedaan utama ada di bagian Factory
    // jadi kita buat Factory untuk membuat objek Operation
    // sehingga jika ada perubahan pada Operation, kita hanya perlu mengubah di factory saja tanpa menganggu kode lainnya
    // Abstract Factory
    public abstract class OperationFactory
    {
        public abstract IOperation CreateOperation();
    }

    // Concrete Factories
    // jadi dalam case ini tiap factory hanya bertanggung jawab untuk membuat satu jenis operasi saja
    // sehingga jika ada masalah pada pembuatan operasi tertentu, kita hanya perlu mengubah di factory tersebut tanpa menganggu kode lainnya
    public class AddFactory : OperationFactory
    {
        public override IOperation CreateOperation() => new AddOperation();
    }

    public class SubtractFactory : OperationFactory
    {
        public override IOperation CreateOperation() => new SubtractOperation();
    }

    public class MultiplyFactory : OperationFactory
    {
        public override IOperation CreateOperation() => new MultiplyOperation();
    }

    public class DivideFactory : OperationFactory
    {
        public override IOperation CreateOperation() => new DivideOperation();
    }
}


