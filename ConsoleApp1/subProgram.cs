/*
using System;
using System.Collections.Generic;

public class MyClass
{
    private readonly Dictionary<int, string> rules = new Dictionary<int, string>();

    public void AddRule(int input, string output)
    {
        if (input <= 0) // pembaginya harus lebih dari 0
            throw new ArgumentException("Divisor must be greater than zero.");

        rules[input] = output;
    }

    public void Generate(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            string result = "";

            foreach (var rule in rules)
            {
                if (i % rule.Key == 0)
                {
                    result += rule.Value;
                }
            }

            if (string.IsNullOrEmpty(result))
                Console.Write(i);
            else
                Console.Write(result);

            Console.Write(i == n ? "" : ",");
        }

        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Input integer n: ");
        int n = int.Parse(Console.ReadLine());

        var MyClass = new MyClass();

        MyClass.AddRule(3, "foo");
        MyClass.AddRule(4, "baz");
        MyClass.AddRule(5, "bar");
        MyClass.AddRule(7, "jazz");
        MyClass.AddRule(9, "huzz");

        //print output dari integer n
        MyClass.Generate(n);
    }
}
*/