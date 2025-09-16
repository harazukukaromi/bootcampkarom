/*using System;

//event handler part2
public delegate void PriceChangedHandler(decimal oldPrice, decimal newPrice); // Custom delegate

// Broadcaster class
public class BasicPriceMonitor
{
    public string Symbol { get; }
    private decimal _price;

    // Event declaration using custom delegate
    public event PriceChangedHandler PriceChanged;

    public BasicPriceMonitor(string symbol)
    {
        Symbol = symbol;
        _price = 0.0m;
    }

    // Method to simulate price updates
    public void UpdatePrice(decimal newPrice)
    {
        if (_price != newPrice)
        {
            decimal oldPrice = _price;
            _price = newPrice;

            Console.WriteLine($"[{Symbol}] Price updated: {oldPrice:C} -> {newPrice:C}");

            // Raise the event
            OnPriceChanged(oldPrice, newPrice);
        }
        else
        {
            Console.WriteLine($"[{Symbol}] No price change: {newPrice:C}");
        }
    }

    // Protected method to invoke the event
    protected virtual void OnPriceChanged(decimal oldPrice, decimal newPrice)
    {
        PriceChanged?.Invoke(oldPrice, newPrice);
    }
}

public class Program
{
    static void BasicEventDeclarationDemo()
    {

        // Create a basic broadcaster using custom delegate
        var priceMonitor = new BasicPriceMonitor("AAPL");
        
        // Create subscribers - these are just methods that match our delegate signature
        void Trader1Handler(decimal oldPrice, decimal newPrice) => 
            Console.WriteLine($"  Trader 1: Price changed from ${oldPrice} to ${newPrice}");

        void Trader2Handler(decimal oldPrice, decimal newPrice) => 
            Console.WriteLine($"  Trader 2: Significant move! ${oldPrice} -> ${newPrice}");

        // Subscribe to the event
        priceMonitor.PriceChanged += Trader1Handler;
        priceMonitor.PriceChanged += Trader2Handler;

        Console.WriteLine("Subscribed two traders to price changes");
        Console.WriteLine("Triggering price changes...\n");

        // Trigger some price changes
        priceMonitor.UpdatePrice(125.00m);
        priceMonitor.UpdatePrice(150.50m);

        // Remove one subscriber
        priceMonitor.PriceChanged -= Trader1Handler;
        Console.WriteLine("\nTrader 1 unsubscribed. Only Trader 2 should receive this update:");
        priceMonitor.UpdatePrice(150.90m);

        Console.WriteLine();
    }

    static void Main()
    {
        BasicEventDeclarationDemo();
    }
}*/
