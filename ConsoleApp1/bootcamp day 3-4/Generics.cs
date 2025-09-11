/*using System;

class Generics
{
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
    public static void Main()
    {
        int a = 40;
        int b = 60;
        Swap<int>(ref a, ref b);
        Console.WriteLine("a = {0}, b = {1}", a, b);
    }
    public class MyGenericArray<T>
    {
        private T[] array;
        public MyGenericArray(int size)
        {
            array = new T[size + 1];
        }
        public T getItem(int index)
        {
            return array[index];
        }
        public void setItem(int index, T value)
        {
            array[index] = value;
        }
    }
}*/