/*
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
//Ressurction
public class TempFileRef
{
    // Static collection to hold resurrected objects
    internal static readonly ConcurrentQueue<TempFileRef> FailedDeletions = new ConcurrentQueue<TempFileRef>();

    public readonly string FilePath;
    public Exception? DeletionError { get; private set; }

    public TempFileRef(string filePath)
    {
        FilePath = filePath;
        Console.WriteLine($"TempFileRef created for file: {filePath}");
    }

    ~TempFileRef()
    {
        Console.WriteLine($"Finalizer running for file: {FilePath}");

        try
        {
            File.Delete(FilePath);
            Console.WriteLine($"File deleted: {FilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Deletion failed for file: {FilePath}");
            DeletionError = ex;

            // RESURRECTION: the object is still reachable via static queue
            FailedDeletions.Enqueue(this);
            Console.WriteLine($"Object resurrected and added to FailedDeletions.");
        }
    }
}
class Program
{
    static void Main()
    {
        string tempFile = Path.GetTempFileName();

        // Lock the file to simulate a failure during deletion
        FileStream fs = new FileStream(tempFile, FileMode.Open, FileAccess.Read, FileShare.None);

        // Create a TempFileRef (goes out of scope after this block)
        CreateTempFileRef(tempFile);

        Console.WriteLine("\nTriggering garbage collection...");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect(); // Needed to clean up resurrected objects in next cycle

        Console.WriteLine("\nChecking failed deletions:");
        while (TempFileRef.FailedDeletions.TryDequeue(out TempFileRef? item))
        {
            Console.WriteLine($"Resurrected object for file: {item.FilePath}");
            Console.WriteLine($"Error: {item.DeletionError?.Message}");
        }

        fs.Dispose(); // Now the file can be deleted

        Console.WriteLine("\nProgram ended.");
    }

    static void CreateTempFileRef(string path)
    {
        var tempRef = new TempFileRef(path);
        // Goes out of scope — no Dispose or reference — GC can collect it
    }
}
*/