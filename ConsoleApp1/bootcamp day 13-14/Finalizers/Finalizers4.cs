/*
using System;
using System.IO;
using System.Threading;

public class TempFileRef
{
    public readonly string FilePath;
    private int _deleteAttempt; // Retry counter

    public TempFileRef(string filePath)
    {
        FilePath = filePath;
        Console.WriteLine($"TempFileRef created for file: {FilePath}");
    }

    ~TempFileRef()
    {
        Console.WriteLine($"Finalizer running for file: {FilePath}, attempt #{_deleteAttempt + 1}");

        try
        {
            File.Delete(FilePath);
            Console.WriteLine($"File deleted successfully: {FilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to delete file: {FilePath}. Exception: {ex.Message}");

            if (_deleteAttempt++ < 3)
            {
                Console.WriteLine($"Retrying deletion later (attempt {_deleteAttempt})...");
                GC.ReRegisterForFinalize(this); // Reregister for finalization (resurrection)
            }
            else
            {
                Console.WriteLine("Max retry attempts reached. Giving up on deleting the file.");
                // Optional: enqueue to a failure list here
            }
        }
    }
}

class Program
{
    static void Main()
    {
        // Create a temporary file
        string tempFile = Path.GetTempFileName();

        // Open the file with exclusive lock to cause deletion failure in finalizer
        using (var fs = new FileStream(tempFile, FileMode.Open, FileAccess.Read, FileShare.None))
        {
            // Create TempFileRef object (will try deleting the file in finalizer)
            CreateTempFileRef(tempFile);

            Console.WriteLine("\nForcing garbage collection...");
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("\nSecond GC to try finalizers for resurrected objects...");
            GC.Collect();
            GC.WaitForPendingFinalizers();

            // File is still locked here, so deletion should have failed again and retried
        }

        // Now file is unlocked, finalizer should be able to delete it on next GC
        Console.WriteLine("\nFile unlocked, forcing GC again...");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("\nProgram ended.");
    }

    static void CreateTempFileRef(string path)
    {
        var tempRef = new TempFileRef(path);
        // tempRef goes out of scope immediately, eligible for GC
    }
}
*/