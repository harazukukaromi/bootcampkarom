/*using System;

//Standard Event
// EventArgs Subclass
public class PriceChangedEventArgs : EventArgs
{
    public readonly decimal LastPrice;
    public readonly decimal NewPrice;

    public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
    {
        LastPrice = lastPrice;
        NewPrice = newPrice;
    }
}

// 2. Stock Class
public class Stock
{
    private string symbol;
    private decimal price;

    public Stock(string symbol)
    {
        this.symbol = symbol;
        price = 24.5m;
    }

    // 3. Event Declaration using EventHandler<T>
    public event EventHandler<PriceChangedEventArgs> PriceChanged;

    // 4. Protected virtual method to raise the event
    protected virtual void OnPriceChanged(PriceChangedEventArgs e)
    {
        PriceChanged?.Invoke(this, e); // Thread-safe event invocation
    }

    // 5. Price property
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

            // Raise the event
            OnPriceChanged(new PriceChangedEventArgs(oldPrice, price));
        }
    }
}

// 6. Main Program
public class Program
{
    public static void Main()
    {
        Stock stock = new Stock("THPW");

        // Subscribe to the PriceChanged event
        stock.PriceChanged += Stock_PriceChanged;

        // Simulate price changes
        stock.Price = 27.10M;  // Initial set
        stock.Price = 28.10M;  // price increase but not triggred alert
        stock.Price = 31.59M;  // Should trigger alert (over 10% increase)
        stock.Price = 31.59M;  // No event (price unchanged)
        stock.Price = 28.00M;  // Should trigger alert (price droped over 10%)
        stock.Price = 27.10M;  // price dropped but not triggred alert
    }

    // Event handler (subscriber)
    private static void Stock_PriceChanged(object sender, PriceChangedEventArgs e)
    {
        decimal changePercent = (e.NewPrice - e.LastPrice) / e.LastPrice;
        Console.WriteLine($"  Price Changed: {e.LastPrice:C} → {e.NewPrice:C} ({changePercent:P})");

        if (changePercent > 0.1M)
        {
            Console.WriteLine("Alert: Stock price increased more than 10%!");
        }
        else if (changePercent < -0.1M)
        {
            Console.WriteLine("Alert: Stock price Decreased more than 10%!");
        }
    }
}*/
