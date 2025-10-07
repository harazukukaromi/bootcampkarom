using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text; 
public class Sale
{
    public string Item { get; set; }
    public decimal Amount { get; set; }
}

// 1. Kelas untuk menghitung laporan (business logic)
public class ReportGenerator
{
    private readonly SalesFormatter _formatter;
    private readonly EmailService _emailService;
    private readonly FileService _fileService;
    private readonly ILogger _logger;

    public ReportGenerator(
        SalesFormatter formatter,
        EmailService emailService,
        FileService fileService,
        ILogger logger)
    {
        _formatter = formatter;
        _emailService = emailService;
        _fileService = fileService;
        _logger = logger;
    }

    public void GenerateReport(List<Sale> sales)
    {
        var total = sales.Sum(s => s.Amount);

        var formattedData = _formatter.FormatSalesData(sales, total);

        _emailService.Send("manager@company.com", $"Report:\n{formattedData}");

        _fileService.SaveToFile("report.txt", formattedData);

        _logger.Log($"Report generated at {DateTime.Now}");
    }
}

// 2. Format data penjualan
public class SalesFormatter
{
    public string FormatSalesData(List<Sale> sales, decimal total)
    {
        var sb = new StringBuilder();
        foreach (var sale in sales)
            sb.AppendLine($"{sale.Item}: {sale.Amount:C}");
        sb.AppendLine($"Total: {total:C}");
        return sb.ToString();
    }
}

// 3. Layanan pengiriman email
public class EmailService
{
    public void Send(string recipient, string body)
    {
        // simulasi kirim email
        Console.WriteLine($"Email sent to {recipient}:\n{body}");
    }
}

// 4. Layanan penyimpanan file
public class FileService
{
    public void SaveToFile(string fileName, string content)
    {
        File.WriteAllText(fileName, content);
    }
}

// 5. Logging
public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message) => Console.WriteLine(message);
}
