using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ReportApp
{
    // ====== Model ======
    public class Sale
    {
        public string Item { get; set; }
        public decimal Amount { get; set; }
    }

    // ====== Service: Formatting ======
    public class SalesFormatter
    {
        public string FormatSalesData(List<Sale> sales, decimal total)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Sales Report:");
            sb.AppendLine("-----------------");
            foreach (var sale in sales)
                sb.AppendLine($"{sale.Item}: {sale.Amount:C}");
            sb.AppendLine("-----------------");
            sb.AppendLine($"Total: {total:C}");
            return sb.ToString();
        }
    }

    // ====== Service: Email ======
    public class EmailService
    {
        public void Send(string recipient, string body)
        {
            Console.WriteLine("=== Sending Email ===");
            Console.WriteLine($"To: {recipient}");
            Console.WriteLine(body);
            Console.WriteLine("=====================\n");
        }
    }

    // ====== Service: File ======
    public class FileService
    {
        public void SaveToFile(string fileName, string content)
        {
            File.WriteAllText(fileName, content);
            Console.WriteLine($"File '{fileName}' has been saved.\n");
        }
    }

    // ====== Service: Logger ======
    public interface ILogger
    {
        void Log(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[LOG] {message}");
        }
    }

    // ====== Main Service ======
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

            _emailService.Send("manager@company.com", formattedData);
            _fileService.SaveToFile("report.txt", formattedData);
            _logger.Log($"Report generated successfully at {DateTime.Now}");
        }
    }

    // ====== Test Run ======
    class Program
    {
        static void Main(string[] args)
        {
            var sales = new List<Sale>
            {
                new Sale { Item = "Laptop", Amount = 1500.00m },
                new Sale { Item = "Mouse", Amount = 25.50m },
                new Sale { Item = "Keyboard", Amount = 45.99m }
            };

            var formatter = new SalesFormatter();
            var emailService = new EmailService();
            var fileService = new FileService();
            var logger = new ConsoleLogger();

            var reportGenerator = new ReportGenerator(formatter, emailService, fileService, logger);
            reportGenerator.GenerateReport(sales);
        }
    }
}
