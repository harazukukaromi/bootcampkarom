/*using System;
public class Object
{
    static void Main()
    {
        //Stack is using (LIFO) Last in First out
        Object obj = new Object();
        obj.push(10);
        obj.push("Hola");
        obj.push(3.14);
        obj.push(true);
        obj.print(); // Outputs: 10
        obj.print(); // Outputs: Hola
        obj.print(); // Outputs: 3.14
        obj.print(); // Outputs: true
    }
    // push pop print object
    private System.Collections.Generic.Stack<object> stack = new System.Collections.Generic.Stack<object>();
    public void push(object item)
    {
        stack.Push(item);
    }
    public object pop()
    {
        return stack.Pop();
    }
    public void print()
    {
        if (stack.Count > 0)
        {
            Console.WriteLine(stack.Pop());
        }
        else
        {
            Console.WriteLine("Stack is empty");
        }
    }
}*/