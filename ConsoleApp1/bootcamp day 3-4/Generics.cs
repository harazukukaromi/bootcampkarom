/*using System;

class Generics
{
    // Generic method to swap two values
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    public static void Main()
    {
        // Demonstrate Swap
        double a = 40.78;
        double b = 60.45;
        Swap<double>(ref a, ref b);
        Console.WriteLine("After Swap: a = {0}, b = {1}", a, b);

        // Create a generic array of size 10 (index 0 to 10)
        MyGenericArray<int> intArray = new MyGenericArray<int>(10);

        // Set values in the array
        for (int i = 0; i <= 10; i++)
        {
            intArray.setItem(i, i * 20);  // set value at index i = i * 10
        }

        Console.WriteLine("\nBefore swapping in array:");
        for (int i = 0; i <= 10; i++)
        {
            Console.WriteLine("Index {0}: {1}", i, intArray.getItem(i));
        }

        // Swap values in the array: index in this case using 10 index
        intArray.SwapItems(1, 9);
        intArray.SwapItems(2, 10);
        intArray.SwapItems(9, 10);

        Console.WriteLine("\nAfter swapping index :");
        for (int i = 0; i <= 10; i++)
        {
            Console.WriteLine("Index {0}: {1}", i, intArray.getItem(i));
        }
    }

    // Generic array class
    public class MyGenericArray<T>
    {
        private T[] array;

        public MyGenericArray(int size)
        {
            array = new T[size + 1];  // Allow index 0 to size
        }

        public T getItem(int index)
        {
            return array[index];
        }

        public void setItem(int index, T value)
        {
            array[index] = value;
        }

        // Swap two elements in the array using generic Swap method
        public void SwapItems(int index1, int index2)
        {
            // Pastikan index valid (opsional: bisa tambahkan pengecekan di sini)
            Swap(ref array[index1], ref array[index2]);
        }
    }
}*/
