/*using System;
using System.Net;
class Program

{
    static void Main()
    {
        Console.WriteLine("Testing exception filters with 'when' keyword:\n");

        SimulateWebException(WebExceptionStatus.Timeout);
        SimulateWebException(WebExceptionStatus.SendFailure);
        SimulateWebException(WebExceptionStatus.ConnectFailure);

        Console.WriteLine("\nDone testing.");
    }

    static void SimulateWebException(WebExceptionStatus status)
    {
        try
        {
            // Simulate throwing a WebException with a specific status
            throw new WebException("Simulated exception", status);
        }
        catch (WebException ex) when (ex.Status == WebExceptionStatus.Timeout)
        {
            Console.WriteLine("Handled Timeout: Web request timed out.");
        }
        catch (WebException ex) when (ex.Status == WebExceptionStatus.SendFailure)
        {
            Console.WriteLine("Handled SendFailure: Failed to send the request.");
        }
        catch (WebException ex)
        {
            Console.WriteLine($"Handled Other WebException: {ex.Status}");
        }
    }
    */ /*static void SimulateWebException(WebExceptionStatus status)
    {
        try
        {
            // Create and throw a WebException with specific status
            var ex = new WebException("Simulated web error", status);
            throw ex;
        }
        catch (WebException ex) when (ex.Status == WebExceptionStatus.Timeout)
        {
            Console.WriteLine("  Handled: Request timeout - retrying with longer timeout");
        }
        catch (WebException ex) when (ex.Status == WebExceptionStatus.SendFailure)
        {
            Console.WriteLine("  Handled: Send failure - checking network connection");
        }
        catch (WebException ex) when (ex.Status == WebExceptionStatus.ConnectFailure)
        {
            Console.WriteLine("  Handled: Connection failure - server might be down");
        }
        catch (WebException ex)
        {
            Console.WriteLine($"  Handled: Other web exception - {ex.Status}");
        }
    }*/
//}
