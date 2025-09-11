/*using System;

public interface IUndoable
{
    void Undo();
}

public class TextBox : IUndoable
{
    // Explicit interface implementation:
    // Undo() is NOT visible on TextBox reference, only via IUndoable reference
    void IUndoable.Undo() => Console.WriteLine("TextBox.Undo");
}

public class RichTextBox : TextBox, IUndoable
{
    // New implicit implementation of Undo, visible on RichTextBox reference
    public void Undo() => Console.WriteLine("RichTextBox.Undo");
}

class Program
{
    static void Main()
    {
        TextBox tb = new TextBox();
        IUndoable iUndoableTb = tb;

        // tb.Undo(); // ERROR! Undo() is not visible on TextBox reference because of explicit implementation

        iUndoableTb.Undo(); // Calls TextBox explicit Undo => prints "TextBox.Undo"

        RichTextBox rtb = new RichTextBox();
        IUndoable iUndoableRtb = rtb;

        rtb.Undo();         // Calls RichTextBox public Undo => prints "RichTextBox.Undo"
        iUndoableRtb.Undo(); // Calls RichTextBox public Undo => prints "RichTextBox.Undo"
    }
}*/