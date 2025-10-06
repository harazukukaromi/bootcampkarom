/*using System;

//event vs delegates
//Define a delegate that matches the event handler signature
public delegate void PriceChangedHandler(decimal oldPrice, decimal newPrice);

// Stock class that uses the event
public class Stock
{
    private string symbol;
    private decimal price;

    public Stock(string symbol)
    {
        this.symbol = symbol;
        price = 0.0m;
    }

    //Event declaration
    public event PriceChangedHandler PriceChanged;

    // Property that raises the event when the price changes
    public decimal Price
    {
        get => price;
        set
        {
            if (price == value)
            {
                Console.WriteLine($"[{symbol}] Price unchanged at {price:C}. No event triggered.");
                return;
            }

            decimal oldPrice = price;
            price = value;

            Console.WriteLine($"[{symbol}] Price updated from {oldPrice:C} to {price:C}");

            //Raise the event if there are subscribers
            PriceChanged?.Invoke(oldPrice, price);
        }
    }
}

public class Program
{
    public static void Main()
    {
        // Create a stock
        Stock apple = new Stock("AAPL");

        // Define event handlers (subscribers)
        void Logger(decimal oldPrice, decimal newPrice)
        {
            Console.WriteLine($"  Logger: Price changed from {oldPrice:C} to {newPrice:C}");
        }

        void Alert(decimal oldPrice, decimal newPrice)
        {
            if (Math.Abs(newPrice - oldPrice) > 30)
                Console.WriteLine($"  Alert: Significant price change detected!");
        }

        // Subscribe handlers to the event
        apple.PriceChanged += Logger;
        apple.PriceChanged += Alert;

        // Simulate price updates
        apple.Price = 100.00m;
        apple.Price = 130.00m;
        apple.Price = 175.75m;
        apple.Price = 175.75m; // No event, price unchanged
        apple.Price = 90.00m;
        //apple.Price = -20.00m; // for checking between minus integer and positif integer
        apple.Price = 20.00m;
    }
}*/
