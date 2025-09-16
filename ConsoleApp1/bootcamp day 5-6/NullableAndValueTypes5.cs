using System;
//Operator Lifting
class Program
{
    static void Main()
    {
        int? x = 5;
        int? y = 10;
        int? z = null;

        //Equality Operations != dan ==
        Console.WriteLine((int?)null == (int?)null); // True
        Console.WriteLine(x == y);    // False (5 == 10)
        Console.WriteLine(x == z);    // False (5 == null)
        Console.WriteLine(y == z);    // True (null == null)
        Console.WriteLine(y != 5);    // True (null != 5)
        Console.WriteLine();
        //Relational Operators <, <=, >= dan >
        Console.WriteLine(x < 6); // True (5 < 6)
        Console.WriteLine(z < 6); // False (null < 6)
        Console.WriteLine(z > 6); // False (null > 6)
        Console.WriteLine(x >= 5); // True Comparing literal 5 >= 5
        Console.WriteLine(x <= 5); // True Comparing literal 5 <= 5
        Console.WriteLine(z <= 10); // False Comparing null with literal
        Console.WriteLine(z >= 10); // False Comparing null with literal
        //Any Realtional operator with null it will be False

        Console.WriteLine();
        //other Operations (+, -, *, /, %, &, |, ^, <<, >>, !, ~, ++, --)
        Console.WriteLine(x + 5);  // 10 (5 + (int?)5)
        Console.WriteLine(x + z);  // null (any null operand makes result null)
        Console.WriteLine(x * z);  // null x * null = null
        Console.WriteLine(x / z);  // null x /   null = null
        //Console.WriteLine(x++);    // 5 dulu baru increment
        //Console.WriteLine(z++);    // null dulu baru increment hasilnya null
        //Console.WriteLine(++x);    // increment 5 jadi 6
        //Console.WriteLine(++z);    // increment null jadi null
        //semua aritmatematika dengan null angka menghasilkan null
        Console.WriteLine("\nThe rule: If ANY operand is null, arithmetic result is null");
        Console.WriteLine("(This is similar to SQL's NULL behavior)\n");
        Console.WriteLine();
        //Bool Operations
        bool? comp1 = (x > z);  // true becasue null treated as unknown
        bool? comp2 = (z > x);  // null because (null > 5)
        bool? comp3 = (z == null); // true

        Console.WriteLine("x > z = " + comp1);  // false
        Console.WriteLine("z > x = " + comp2);  // null
        Console.WriteLine("z == null = " + comp3);  // true

        bool? b1 = null;
        bool? b2 = true;
        bool? b3 = false;

        Console.WriteLine("\nThree-valued logic with bool?:");
        Console.WriteLine("null | true = " + (b1 | b2));   // true
        Console.WriteLine("null & false = " + (b1 & b3));  // false
        Console.WriteLine("null | false = " + (b1 | b3));  // null
        Console.WriteLine("null & true = " + (b1 & b2));   // null

          // 4. Use of conditional logic (avoiding exception with nullable bool)
        if ((x > 0) == true)
        {
            Console.WriteLine("\nx is greater than 0");
        }

        if ((z > 0) == true)
        {
            Console.WriteLine("z is greater than 0"); // This won't run because z > 0 is null
        }
        else
        {
            Console.WriteLine("z is NOT greater than 0 (or unknown)");
        }
    }
}
