/*using System;
//Enums conversion
[Flags] // Indicates this enum can be treated as a bit field
public enum BorderSides
{
    Left = 1,
    Right = 2,
    Top = 4,
    Bottom = 8
}

class Program
{
    static void Main()
    {
        // Enum member to integral:
        int i = (int)BorderSides.Top;      // i == 4
        Console.WriteLine($"(int)BorderSides.Top = {i}");

        // Integral to enum member:
        BorderSides side = (BorderSides)i; // side == BorderSides.Top
        Console.WriteLine($"(BorderSides){i} = {side}");

        // Get integral value (unsafe for long enums)
        int integralUnsafe = GetIntegralValue(BorderSides.Right);
        Console.WriteLine($"GetIntegralValue(BorderSides.Right) = {integralUnsafe}");

        // Safe decimal conversion
        decimal integralDecimal = GetAnyIntegralValue(BorderSides.Bottom);
        Console.WriteLine($"GetAnyIntegralValue(BorderSides.Bottom) = {integralDecimal}");

        // Boxed integral value
        object boxedValue = GetBoxedIntegralValue(BorderSides.Top);
        Console.WriteLine($"GetBoxedIntegralValue(BorderSides.Top) = {boxedValue}");
        Console.WriteLine($"Type of boxed value: {boxedValue.GetType()}");

        // Using Enum.ToObject to create combined flags from int
        object bs = Enum.ToObject(typeof(BorderSides), 3);
        Console.WriteLine($"Enum.ToObject(typeof(BorderSides), 3) = {bs}"); // Output: Left, Right

        // Equivalent direct cast
        BorderSides directCast = (BorderSides)3;
        Console.WriteLine($"Direct cast (BorderSides)3 = {directCast}");

        // Parsing from string
        BorderSides parsed = (BorderSides)Enum.Parse(typeof(BorderSides), "Left, Right");
        Console.WriteLine($"Parsed from string \"Left, Right\" = {parsed}");
    }

    static int GetIntegralValue(Enum anyEnum)
    {
        // Unsafe if underlying type is long or ulong
        return (int)(object)anyEnum;
    }

    static decimal GetAnyIntegralValue(Enum anyEnum)
    {
        return Convert.ToDecimal(anyEnum);
    }

    static object GetBoxedIntegralValue(Enum anyEnum)
    {
        Type integralType = Enum.GetUnderlyingType(anyEnum.GetType());
        return Convert.ChangeType(anyEnum, integralType);
    }
}*/
