/*using System;

// Generic class
public class GenericArray<T>
{
    private T[] items;
    private int count;

    public GenericArray(int size)
    {
        items = new T[size];
        count = 0;
    }

    public void Push(T item)
    {
        if (count >= items.Length)
        {
            Console.WriteLine("Array is full. Cannot push more items.");
            return;
        }

        items[count++] = item;
    }

    public T Pop()
    {
        if (count == 0)
        {
            Console.WriteLine("Array is empty. Cannot pop.");
            return default(T)!;
        }

        return items[--count];
    }

    public T Peek()
    {
        if (count == 0)
        {
            Console.WriteLine("Array is empty.");
            return default(T)!;
        }

        return items[count - 1];
    }

    public void Print()
    {
        if (count == 0)
        {
            Console.WriteLine("Array is empty.");
            return;
        }

        Console.Write("Items in array: ");
        for (int i = 0; i < count; i++)
        {
            Console.Write(items[i] + " ");
        }
        Console.WriteLine();
    }
}
public class Generics2
{
    public static void Main()
    {
        // Using integers
        var intArray = new GenericArray<int>(5);
        intArray.Push(10);
        intArray.Push(20);
        intArray.Push(30);
        intArray.Push(40);
        intArray.Push(50);
        //intArray.Push(60); array is 5 so array index 6 can't be put anymore
        //intArray.Push("karom"); can't push string because value is Integer
        intArray.Print();

        Console.WriteLine("Popped: " + intArray.Pop());
        Console.WriteLine("Popped: " + intArray.Pop());
        //Console.WriteLine("Popped: " + intArray.Pop());
        //Console.WriteLine("Popped: " + intArray.Pop());
        //Console.WriteLine("Popped: " + intArray.Pop());
        //Console.WriteLine("Popped: " + intArray.Pop()); //Can't be pop anymore because nothing in Array
        Console.WriteLine("Peek: " + intArray.Peek());
        intArray.Print();

        // Using strings
    }
}*/
