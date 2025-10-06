/*
using System;
using System.IO;

namespace IDisposableExample
{
    // Step 1: Implement IDisposable
    public class MyResource : IDisposable
    {
        private FileStream _fileStream;
        private bool _disposed = false;

        public MyResource(string filePath)
        {
            _fileStream = new FileStream(filePath, FileMode.Create);
            Console.WriteLine("File stream opened.");
        }

        public void WriteData(string data)
        {
            if (_disposed)
                throw new ObjectDisposedException("MyResource");

            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
            _fileStream.Write(bytes, 0, bytes.Length);
            Console.WriteLine("Data written to file.");
        }

        // Step 2: Implement Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // Prevent finalizer from running if Dispose has already been called
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Clean up managed resources
                    if (_fileStream != null)
                    {
                        _fileStream.Close();
                        _fileStream.Dispose();
                        _fileStream = null;
                        Console.WriteLine("File stream closed and disposed.");
                    }
                }

                // Clean up unmanaged resources here if any (none in this example)

                _disposed = true;
            }
        }

        // Optional: Finalizer (only needed if unmanaged resources are used)
        ~MyResource()
        {
            Dispose(false);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Step 3: Use using statement to auto-dispose
            using (var resource = new MyResource("example.txt"))
            {
                resource.WriteData("Hello, IDisposable!");
            } // Dispose is automatically called here

            Console.WriteLine("Resource has been disposed.");
        }
    }
}*/
