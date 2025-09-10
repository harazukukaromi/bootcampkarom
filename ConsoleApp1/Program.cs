// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;
class ConsoleApp1
{
    static void Main()
    {
        // Oprational boolean &&, ||, !
        bool a = false;
        bool b = false;
        bool c = true;
        bool d = true;
        Console.WriteLine(a && b); 
        Console.WriteLine(a && c); 
        Console.WriteLine(c && d); 
        Console.WriteLine(a || c); 
        Console.WriteLine(a || b);
        Console.WriteLine(c || d); 
        Console.WriteLine(!a); 
        Console.WriteLine(!c); 
        Console.WriteLine(!a && c || d);
        Console.WriteLine(!(a && c) || d); 
        Console.WriteLine(!(a && c || d)); 
        Console.WriteLine(!a && (c || d));
        Console.WriteLine(!a && c || !d); 
        Console.WriteLine(!a && (c || !d));
    }
}

