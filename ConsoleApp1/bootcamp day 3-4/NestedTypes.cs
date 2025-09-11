using System;

public class NestedTypes
{
    // Nested class
    public class NestedClass
    {
        private NestedTypes? parent;

        public NestedClass()
        {
            Console.WriteLine("NestedClass Class Constructor");
        }

        public NestedClass(NestedTypes parent)
        {
            this.parent = parent;
            Console.WriteLine("NestedClass constructor with NestedTypes parent");
        }

        public void ShowParentStatus()
        {
            if (parent == null)
                Console.WriteLine("No parent assigned.");
            else
                Console.WriteLine("Parent assigned.");
        }
    }

    // Nested struct
    public struct NestedStruct
    {
        public int Value;

        public void Display()
        {
            Console.WriteLine($"NestedStruct Value: {Value}");
        }
    }

    // Nested enum
    public enum Status
    {
        Started,
        InProgress,
        Completed
    }

    public Status CurrentStatus { get; set; } = Status.Started;
}

class Program
{
    static void Main()
    {
        NestedTypes container = new NestedTypes();

        // Membuat instance NestedClass dengan parent
        NestedTypes.NestedClass nestedWithParent = new NestedTypes.NestedClass(container);
        nestedWithParent.ShowParentStatus();

        // Membuat instance NestedClass tanpa parent
        NestedTypes.NestedClass nestedWithoutParent = new NestedTypes.NestedClass();
        nestedWithoutParent.ShowParentStatus();

        // Membuat dan gunakan NestedStruct
        NestedTypes.NestedStruct nestedStruct = new NestedTypes.NestedStruct();
        nestedStruct.Value = 400;
        nestedStruct.Display();

        // Menggunakan nested enum
        container.CurrentStatus = NestedTypes.Status.Completed;
        Console.WriteLine($"Current status: {container.CurrentStatus}");
    }
}
