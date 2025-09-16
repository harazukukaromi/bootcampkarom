/*using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== BOXING AND UNBOXING NULLABLE TYPES ===");

        int? nullableWithValue = 10;
        int? nullableWithNull = null;

        // BOXING
        object boxedValue = nullableWithValue;  // Boxes to object containing int
        object boxedNull = nullableWithNull;    // Becomes null

        Console.WriteLine($"Boxed value type: {boxedValue}");   // 10
        Console.WriteLine($"Boxed null type: {(boxedNull == null ? "null" : boxedNull.ToString())}"); // null

        // UNBOXING - safe if actual type matches
        int? unboxedCorrect = boxedValue as int?;
        Console.WriteLine($"Unboxed (correct type): {unboxedCorrect} (HasValue: {unboxedCorrect.HasValue})");

        // UNBOXING - fails if types don't match
        object o = "string";
        int? unboxedWrong = o as int?;  // o is not an int => null
        Console.WriteLine($"Unboxed (wrong type): {unboxedWrong} (HasValue: {unboxedWrong.HasValue})");

        // UNBOXING with explicit cast — throws exception if types don't match
        try
        {
            int forceUnboxed = (int)boxedValue; // OK
            Console.WriteLine($"Force unboxed value: {forceUnboxed}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception during forced unboxing (correct type): {ex.Message}");
        }

        try
        {
            int forceUnboxed = (int)boxedNull; // Throws NullReferenceException
            Console.WriteLine($"Force unboxed null: {forceUnboxed}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception during forced unboxing (null): {ex.Message}");
        }

        try
        {
            int forceUnboxed = (int)o; //InvalidCastException
            Console.WriteLine($"Force unboxed string: {forceUnboxed}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception during forced unboxing (wrong type): {ex.Message}");
        }
    }
}*/
